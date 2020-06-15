using Kira.Genealogy.Model.Domain.Drawing.Enumerations;
using Kira.Genealogy.Model.Domain.Tree.Enumerations;
using System;
using System.Collections.Generic;

namespace Kira.Genealogy.DS.TestApi.ViewModel
{
    public class NodeViewModel
    {
        public NodeViewModel() {
            Mates = new List<MateNodeViewModel>();
        }

        public int NodeId { get; set; }
        public NodeType NodeType { get; set; }
        public Guid? PersonId { get; set; }
        public int? ParentNodeId { get; set; }
        public int Level { get; set; }
        public GenderEnum PersonGender { get; set; }
        public Point Position  { get; set; }

        public List<MateNodeViewModel> Mates { get; set; }
    }
}
