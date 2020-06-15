using Kira.Genealogy.DS.TestApi.ViewModel.Construction;
using Kira.Genealogy.DS.TestApi.ViewModel.Construction.Enumerator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kira.Genealogy.DS.TestApi.ViewModel
{
    public class NodeMap
    {
        private Block _block;
        private int _cardWidth = 250;
        private int _cardHeigth = 100;

        public List<NodeViewModel> Nodes { get; private set; }
        public List<Union> Unions { get; private set; }

        public NodeMap(List<NodeViewModel> nodes) 
        {
            Nodes = nodes;
            Unions = new List<Union>();

            CreateBlock();
            CenterBlock(_block);
            CreateUnions(nodes.FirstOrDefault());
        }

        private void CreateUnions(NodeViewModel node)
        {
            foreach (var mate in node.Mates) 
            {
                Union union = CreateMateUnion(node.Position, mate.Position);
                Unions.Add(union);

                foreach (var child in mate.Children) 
                {
                    Unions.Add(CreateChildUnion(union.ConnectPoint, child.Position));
                    CreateUnions(child);
                }
            }
        }

        private Union CreateChildUnion(Point connectPoint, Point position)
        {
            return new Union(
                new Point { X = connectPoint.X, Y = connectPoint.Y },
                new Point {X = position.X + (_cardWidth/2), Y = position.Y },
                UnionTypeEnum.ParentChildUnion );
        }

        private Union CreateMateUnion(Point position1, Point position2)
        {
            return new Union(
                new Point { 
                    X = position1.X + _cardWidth, 
                    Y = position1.Y + (_cardHeigth /2) },
                new Point { 
                    X = position2.X,
                    Y = position2.Y + (_cardHeigth / 2)
                },  UnionTypeEnum.MateUnion );
        }

        private void CenterBlock(Block block)
        {
            block.Center();
            foreach (var child in block.Children)
                CenterBlock(child);
        }

        private void CreateBlock()
        {
            _block = new Block();

            foreach (var node in Nodes) 
                ProcessNode(_block, node);
        }

        private void ProcessNode(Block block, NodeViewModel node)
        {
            block.AddNode(node);
            var areMoreMates = false;

            foreach (var mate in node.Mates) 
            {
                if (areMoreMates) {
                    var parent = block.Parent;
                    block = new Block();
                    parent.AddChild(block);
                }

                block.AddNode(mate);

                if (!mate.HasChilds) continue;

                foreach (var child in mate.Children) 
                {
                    var newBlock = new Block();
                    block.AddChild(newBlock);

                    ProcessNode(newBlock, child);
                }

                areMoreMates = true;
            }
        }
    }
}
