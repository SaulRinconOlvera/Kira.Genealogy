using System.Collections.Generic;
using System.Linq;

namespace Kira.Genealogy.DS.TestApi.ViewModel.Construction
{
    public class Block
    {
        private int _cardSize = 250;
        private int _rowSize = 200;
        private int _spaceSize = 50;

        public Block()
        {
            Nodes = new List<NodeViewModel>();
            Children = new List<Block>();
        }

        public Block Parent { get; private set; }
        public IList<Block> Children { get; private set; }
        public IList<NodeViewModel> Nodes { get; private set; }
        public int Width { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public void AddChild(Block child) 
        {
            child.Parent = this;
            child.Y = Y + _rowSize;
            child.X = X + Children.Sum(c => c.Width);

            Children.Add(child);
        }

        public void AddNode(NodeViewModel node) 
        {
            node.Position = new Point { X = X, Y = Y };
            Nodes.Add(node);

            AddCard();
            AddSpace();

            CheckSize();
        }

        public void Center() 
        {
            if (Nodes.Any()) 
            {
                var nodesWidth = (_cardSize + _spaceSize) * Nodes.Count();
                if (Width <= nodesWidth) CheckForCenterIntoParents();

                var x = X + ((Width - nodesWidth) / 2);

                foreach (var node in Nodes) 
                {
                    node.Position.X = x;
                    x += _cardSize + _spaceSize;
                }
            }
        }

        //  TODO: do this process later
        private void CheckForCenterIntoParents()
        {
            if (Parent.Children.Count() > 1) return;
            X = Parent.X + ((Parent.Width - _cardSize) / 2);
        }

        private void AddSpace() => Width += _spaceSize;

        private void AddCard() => Width += _cardSize;

        private void CheckSize() 
        {
            if (Parent != null)  Parent.Resize();
        }

        private void Resize() 
        {
            var cWidth = Children.Sum(c => c.Width);
            if (cWidth > Width)  { Width = cWidth; CheckSize(); }
        }
    }
}