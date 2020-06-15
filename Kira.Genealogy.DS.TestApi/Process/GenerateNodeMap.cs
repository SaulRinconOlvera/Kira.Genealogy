using Kira.Genealogy.DS.TestApi.ViewModel;
using Kira.Genealogy.Model.Domain.Drawing;
using Kira.Genealogy.Model.Domain.Drawing.Enumerations;
using Kira.Genealogy.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kira.Genealogy.DS.TestApi.Process
{
    public class GenerateNodeMap
    {
        private static List<NodeViewModel> nodesMap;
        private static List<Node> nodes;

        public static NodeMap GetNodes()
        {
            nodesMap = new List<NodeViewModel>();

            GetNodesModel();
            ProcessNode(CheckNodes());

            return new NodeMap(nodesMap);
        }

        private static void ProcessNode(Node node)
        {
            if (node.NodeType == NodeType.JointNode)
            {
                var childs = GetChildsNodes(node);
                ProcessChilds(childs, 1);
            }
        }

        private static void ProcessChilds(IEnumerable<Node> childs, int level, MateNodeViewModel mateNodeViewModel = null)
        {
            if (mateNodeViewModel != null) level++;
            foreach (var child in childs)
            {
                var childViewModel = GetChildNodeData(child, level);

                ProcessMates(child, childViewModel, level);

                if (mateNodeViewModel is null)
                    nodesMap.Add(childViewModel);
                else
                    mateNodeViewModel.Children.Add(childViewModel);
            }
        }

        private static void ProcessMates(Node node, NodeViewModel childViewModel, int level)
        {
            var mates = GetMatesNodes(node);
            foreach (var mate in mates)
            {
                var mateViewModel = GetMateNodeData(mate, level);

                childViewModel.Mates.Add(mateViewModel);
                var childs = GetChildsNodes(mate);
                ProcessChilds(childs, level, mateViewModel);
            }
        }

        private static IEnumerable<Node> GetMatesNodes(Node node) =>
            nodes.Where(n => n.NodeParentId == node.Id && n.NodeType == NodeType.JointNode)
                 .OrderBy(n => n.Person.BornDate);

        private static NodeViewModel GetChildNodeData(Node child, int level) =>
            new NodeViewModel
            {
                NodeId = child.Id,
                PersonId = child.PersonId,
                NodeType = child.NodeType,
                PersonGender = child.Person.Gender,
                ParentNodeId = child.NodeParentId,
                Level = level
            };

        private static MateNodeViewModel GetMateNodeData(Node child, int level) =>
            new MateNodeViewModel
            {
                NodeId = child.Id,
                PersonId = child.PersonId,
                NodeType = child.NodeType,
                ParentNodeId = child.NodeParentId,
                Level = level
            };

        private static IEnumerable<Node> GetChildsNodes(Node node) =>
            nodes.Where(n => n.NodeParentId == node.Id && n.NodeType == NodeType.PersonNode)
                 .OrderBy(n => n.Person.BornDate);

        private static Node CheckNodes()
        {
            var principal = nodes.FirstOrDefault(n => n.NodeType == NodeType.JointNode && n.NodeParentId is null);
            if (principal is null) throw new Exception("No existe nodo principal");
            return principal;
        }

        private static void GetNodesModel()
        {
            using (var ctx = new GenealogyContext())
                nodes = ctx.Nodes
                    .Include(n => n.Person)
                    .OrderBy(n => n.NodeParentId)
                    .ThenBy(n => n.Id).ToList();
        }
    }
}
