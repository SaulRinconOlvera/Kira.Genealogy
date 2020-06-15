using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace Kira.Genealogy.DS.TestApi.ViewModel
{
    public class MateNodeViewModel : NodeViewModel
    {
        public bool HasChilds { get
            {
                if (Children is null) return false;
                else return Children.Any();
            } 
        }

        public MateNodeViewModel() =>  Children = new List<NodeViewModel>();
        public List<NodeViewModel> Children { get; set; }
    }
}
