using Kira.Genealogy.DS.TestApi.ViewModel.Construction.Enumerator;
using System;

namespace Kira.Genealogy.DS.TestApi.ViewModel.Construction
{
    public class Union
    {
        public Union(Point start, Point end, UnionTypeEnum type) 
        {
            Start = start; End = end; UnionType = type;

            if (type == UnionTypeEnum.MateUnion) 
            {
                ConnectPoint = new Point
                {
                    X = End.X - (Math.Abs(End.X - Start.X) / 2),
                    Y = Start.Y
                };
            }
        }

        public UnionTypeEnum UnionType { get; private set; }
        public Point Start { get; private set; }
        public Point End { get; private set; }
        public Point ConnectPoint { get; private set; }
    }
}
