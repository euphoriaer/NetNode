using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NetNodeLib
{
    public class NetNode
    {
        public string Name = "Null";

        public bool IsAutoSize = true;

        /// <summary>
        /// 被点击后处于选中状态，只有被选中状态的才会被移动
        /// </summary>
        private bool _IsSelected;

        public Vector2 Position = new Vector2(0, 0);

        public int Left
        {
            get { return (int)Position.X; }
        }

        public int Right
        {
            get { return Left + Width; }
        }

        public int DotSize = 15;

        private int Width = 200;

        private int Height = 200;

        public int Top
        {
            get { return (int)Position.Y; }
        }

        public int Bottom
        {
            get { return (int)Position.Y + Height; }
        }


        protected StringFormat m_sf;

        public int LineHeight = 30;

        public List<NodeDot> LeftDots = new List<NodeDot>();

        public List<NodeDot> RightDots = new List<NodeDot>();

        public NetNode()
        {
            m_sf = new StringFormat();
            m_sf.Alignment = StringAlignment.Near;
            m_sf.LineAlignment = StringAlignment.Center;
            m_sf.FormatFlags = StringFormatFlags.NoWrap;
            m_sf.SetTabStops(0, new float[] { 40 });

        }

        private Rectangle TitleRectangle
        {
            get
            {
                return new Rectangle(this.Left, this.Top, this.Width, this.LineHeight);
            }
        }

        public void ConnectNodeDot(NodeDot dot1, NodeDot dot2)
        {
            //连接 1,2

        }

        public void DrawDots(DrawingTools tools)
        {
            for (int i = 0; i < LeftDots.Count; i++)
            {
                var dotRect = new Rectangle(Left+2, Top + LineHeight + i * LineHeight+2, DotSize, DotSize);
                DrawDot(tools, dotRect);
            }

            for (int i = 0; i < RightDots.Count; i++)
            {
                var dotRect = new Rectangle(Right- DotSize-3, Top + LineHeight + i * LineHeight+2, DotSize, DotSize);
                DrawDot(tools, dotRect);
            }
        }

        private void DrawDot(DrawingTools tools, Rectangle dotRectangle, bool isFill = true)
        {
            Graphics g = tools.Graphics;
            Pen pen = tools.Pen;
            SolidBrush brush = tools.SolidBrush;

            //单连接 圆形
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            if (isFill)
            {
                g.FillEllipse(brush, dotRectangle);
            }
            else
            {

                g.DrawEllipse(pen, dotRectangle.X, dotRectangle.Y, dotRectangle.Width - 1, dotRectangle.Height - 1);
            }
        }

        public void DrawTitle(DrawingTools drawingTools)
        {
            SolidBrush brush = drawingTools.SolidBrush;
            drawingTools.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            var font = new Font("courier new", 8.25f);
            drawingTools.Graphics.DrawString(Name, font, brush, this.TitleRectangle, m_sf);
        }

        public void DrawNode(DrawingTools drawingTools)
        {
            drawingTools.Graphics.DrawRectangle(drawingTools.Pen, Left, Top + LineHeight, Width, Height);

        }



    }
}
