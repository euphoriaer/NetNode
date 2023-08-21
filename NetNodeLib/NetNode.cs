using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NetNodeLib
{
    public  class NetNode
    {
        public string Name;

        private bool _IsSelected;

        public Vector2 Position=new Vector2(0,0);

        public int Left;

        public int Right;

        public int Top;

        public int Bottom;

        public List<NodeDot> LeftDots;

        public List<NodeDot> RightDots;

        public void ConnectNodeDot(NodeDot dot1,NodeDot dot2)
        {
            //连接 1,2
        }

        public void DrawDot()
        {

        }

        public void DrawTitle()
        {

        }

        public void DrawNode()
        {

        }

        public void DrawConnectLine()
        {

        }

    }
}
