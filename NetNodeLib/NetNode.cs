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
        public string Name="Null";

        public bool IsAutoSize=true;

        /// <summary>
        /// 被点击后处于选中状态，只有被选中状态的才会被移动
        /// </summary>
        private bool _IsSelected;

        public Vector2 Position=new Vector2(0,0);

        public int Left=200;

        public int Right
        {
            get { return Left + Width; }
        }

        private int Width = 200;

        public int Top=200;

        public int Bottom = 200;

        public int AllHeight
        {
            get { return Bottom + Top; }
        }

        public int LineHeight = 30;

        public List<NodeDot> LeftDots;

        public List<NodeDot> RightDots;
        private Rectangle TitleRectangle
        {
            get
            {
                return new Rectangle(this.Left, this.Top, this.Right, this.LineHeight);
            }
        }
        public void ConnectNodeDot(NodeDot dot1,NodeDot dot2)
        {
            //连接 1,2
        }

        public void DrawDot(DrawingTools tools)
        {
            for (int i = 0; i < LeftDots.Count; i++)
            {

            }

            for (int i = 0; i < RightDots.Count; i++)
            {

            }
        }

        public void DrawTitle(DrawingTools drawingTools)
        {
            SolidBrush brush = drawingTools.SolidBrush;
            drawingTools.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            var font = new Font("courier new", 8.25f);
            drawingTools.Graphics.DrawString(Name, font, brush, this.TitleRectangle, m_sf);
        }

        public void DrawNode(DrawingTools tools)
        {

        }



    }
}
