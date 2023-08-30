using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NetNodeLib
{
    public class NodeDot
    {
        public NetNode NetNode { get; set; }

        internal NodeDot(NetNode node)
        {
            NetNode=node;
        }
        public PointF Point { get; set; }

        public int Index;

        public void AddConnect(NodeDot nodeDot)
        {
            Connects.Add(nodeDot);
            nodeDot.BeConnects.Add(this);
        }

        public List<NodeDot> GetConnectDots()
        {
            return Connects;
        }
        public List<NodeDot> GetBeConnectDots()
        {
            return BeConnects;
        }

        public void RemoveDot(NodeDot dot)
        {
            Connects.Remove(dot);
            BeConnects.Remove(dot);
        }

        private List<NodeDot> Connects=new List<NodeDot>();
        private List<NodeDot> BeConnects=new List<NodeDot>();

    }

    public class LineOption
    {
        public string Name = "Null Option";

        public Action Clicked;

        public Action<DrawingTools,Rectangle> CustomImg;

        public Rectangle ClickRect=new Rectangle();
    }

}
