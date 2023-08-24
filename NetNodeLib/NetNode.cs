using System;
using System.Collections.Generic;
using System.Drawing;
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

        public List<LineOption> options = new List<LineOption>();

        public List<NodeDot> RightDots = new List<NodeDot>();

        public NetNode()
        {
            m_sf = new StringFormat();
            m_sf.Alignment = StringAlignment.Center;
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

        private Rectangle NodeRectangle
        {
            get
            {
                return new Rectangle(this.Left, this.Top, this.Width, this.Height + this.LineHeight);
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
                var dotRect = new Rectangle(Left + 2, Top + LineHeight + i * LineHeight + 2, DotSize, DotSize);
                var dot = LeftDots[i];
                DrawDot(tools, dotRect);
            }

            for (int i = 0; i < options.Count; i++)
            {
                var dotRect = new Rectangle(Left + 2, Top + LineHeight + i * LineHeight + 2, DotSize, DotSize);
                DrawOption(tools, dotRect, options[i]);
            }

            for (int i = 0; i < RightDots.Count; i++)
            {
                var dotRect = new Rectangle(Right - DotSize - 3, Top + LineHeight + i * LineHeight + 2, DotSize, DotSize);
                DrawDot(tools, dotRect);
            }
        }
        private void DrawOption(DrawingTools tools, Rectangle dotRectangle, LineOption option, bool isFill = true)
        {
            Graphics g = tools.Graphics;
            Pen pen = tools.Pen;
            SolidBrush brush = tools.SolidBrush;

            //option 
            tools.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            var font = new Font("courier new", 10f);
            var opRect = new Rectangle(dotRectangle.X, dotRectangle.Y - 8, Width, LineHeight);
            tools.Graphics.DrawString(option.Name, font, brush, opRect, m_sf);

            //click img
            var imgRect = new Rectangle(Left + Width - dotRectangle.Width * 3, dotRectangle.Y, dotRectangle.Width, dotRectangle.Height);
            tools.Graphics.FillRectangle(brush, imgRect);
            option.ClickRect = imgRect;
            if (option.CustomImg != null)
            {
                option?.CustomImg(tools,imgRect);
            }
        }


        private void DrawDot(DrawingTools tools, Rectangle dotRectangle, bool isFill = true)
        {
            Graphics g = tools.Graphics;
            Pen pen = tools.Pen;
            SolidBrush brush = tools.SolidBrush;

            //圆形连接 
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
            var font = new Font("courier new", 10f);
            drawingTools.Graphics.DrawString(Name, font, brush, this.TitleRectangle, m_sf);
        }

        public void DrawNode(DrawingTools drawingTools)
        {
            if (IsAutoSize)
            {
                var count = LeftDots.Count > RightDots.Count ? LeftDots.Count : RightDots.Count;
                Height = count * LineHeight;

            }
            drawingTools.Graphics.DrawRectangle(drawingTools.Pen, Left, Top + LineHeight, Width, Height);
            //line

        }

        internal void OnMouseEnter()
        {

        }


        internal void OnMouseClick(MouseEventArgs e)
        {
            for (int i = 0; i < options.Count; i++)
            {
                var option = options[i];

                if (option.Clicked!=null
                    && option.ClickRect.Contains(e.Location))
                {
                    option?.Clicked();
                }
            }
        }

        internal void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left
                && NodeRectangle.Contains(e.Location))
            {
                _IsSelected = true;
                _lastMovePoint = Vector2.Zero;
            }
        }

        internal void OnMouseUp(MouseEventArgs e)
        {
            _IsSelected = false;
            _lastMovePoint = Vector2.Zero;
        }
        private Vector2 _lastMovePoint = Vector2.Zero;
        internal void OnMouseMove(MouseEventArgs e)
        {
            if (!_IsSelected)
            {
                return;
            }

            if (_lastMovePoint == Vector2.Zero)
            {
                _lastMovePoint = new Vector2(e.Location.X, e.Location.Y);
                return;
            }

            //计算 delta
            var deltaX = e.Location.X - _lastMovePoint.X;
            var deltaY = e.Location.Y - _lastMovePoint.Y;
            Position.X += deltaX;
            Position.Y += deltaY;

            _lastMovePoint = new Vector2(e.Location.X, e.Location.Y);
        }

        internal void OnMouseLeave()
        {

        }

        internal void OnDrag()
        {

        }

    }
}
