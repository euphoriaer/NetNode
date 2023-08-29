using System.Diagnostics;
using System.Xml.Linq;

namespace NetNodeLib
{
    public partial class NetNodeEditor : UserControl
    {
        public List<NetNode> Nodes = new List<NetNode>();
        public List<NetNode> HideNodes = new List<NetNode>();
        public List<NetNode> DeleteNodes = new List<NetNode>();
        DrawingTools DrawingTools;
        public NetNodeEditor()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.Paint += NetNodeEditor_Paint;
            DrawingTools = new DrawingTools()
            {
                Pen=new Pen(Color.Black,2),
                SolidBrush=new SolidBrush(Color.Black),
            };
        }

        private void NetNodeEditor_Paint(object? sender, PaintEventArgs e)
        {
            DrawingTools.Graphics = e.Graphics;
            //绘制所有node
            foreach (var node in Nodes)
            {
                node.DrawNode(DrawingTools);
                node.DrawTitle(DrawingTools);
                node.DrawDots(DrawingTools);
            }
        }

        private void NetNode_Load(object sender, EventArgs e)
        {

        }

        public void DrawNode(NetNode node)
        {
            if (Nodes.Contains(node))
            {
                this.Invalidate();
                return;
            }
            
            Nodes.Add(node);
        }

        public bool HideNode(NetNode node)
        {
            if (!Nodes.Contains(node))
            {
                this.Invalidate();
                return false;
            }

            HideNodes.Add(node);//todo 遍历隐藏所有子node
            return true;
        }

        public bool DeleteNode(NetNode node)
        {
            if (!Nodes.Contains(node))
            {
                this.Invalidate();
                return false;
            }

            DeleteNodes.Add(node);//todo  遍历删除所有子node
            return true;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            for (int i = 0; i < Nodes.Count; i++)
            {
                NetNode node = Nodes[i];
                node.OnMouseClick(e);
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            for (int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].OnMouseDown(e);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            for (int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].OnMouseUp(e);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            for (int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].OnMouseMove(e);
            }
            //中键移动画布
            if (e.Button == MouseButtons.Middle)
            {
                for (int i = 0; i < Nodes.Count; i++)
                {
                    Nodes[i].OnMiddleMove(e);
                }
            }

            this.Invalidate();
        }

        private void NetNodeEditor_Load(object sender, EventArgs e)
        {

        }
    }
}