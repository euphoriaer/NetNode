using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNodeLib
{
    public class NodeDot
    {
        internal NodeDot() 
        { 
        }
        public PointF Point { get; set; }

        public int Index;

        internal List<NodeDot> Connects=new List<NodeDot>();

    }

    public class LineOption
    {
        public string Name = "Null Option";

        public Action Clicked;

        public Action<DrawingTools,Rectangle> CustomImg;

        public Rectangle ClickRect=new Rectangle();
    }

}
