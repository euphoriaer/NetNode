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

        public List<NetNode> GetChildrenNetNode(NetNode node)
        {
            //只有右侧连接的 视为children
            List<NetNode> notes=new List<NetNode> ();

            for (int i = 0; i < node.RightDots.Count; i++)
            {
                var connectDots= node.RightDots[i].GetConnectDots();
                for (int j = 0; j < connectDots.Count; j++)
                {
                    var connectNode= connectDots[j].NetNode;
                    notes.Add(connectNode);

                    var childrenNodes= GetChildrenNetNode(connectNode);
                    foreach (NetNode child in childrenNodes)
                    {
                       notes.Add(child);
                    }
                }
            }

            return notes;
        }

        private void NetNodeEditor_Paint(object? sender, PaintEventArgs e)
        {
            DrawingTools.Graphics = e.Graphics;
            //绘制所有node
            for (int i = 0; i < DeleteNodes.Count; i++)
            {
                Nodes.Remove(DeleteNodes[i]);
                DeleteNodes[i].Dispose();
            }
            DeleteNodes.Clear();

            for (int i = 0; i < HideNodes.Count; i++)
            {
                Nodes.Remove(HideNodes[i]);
            }

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

            if (HideNodes.Contains(node)) 
            {
                HideNodes.Remove(node);
            }

            var childrens = GetChildrenNetNode(node);//遍历显示所有子节点 包括自己
            for (int i = 0; i < childrens.Count; i++)
            {
                var showNode = childrens[i];
                showNode.IsShow = true;
                Nodes.Add(showNode);
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

            var childrens = GetChildrenNetNode(node);//遍历隐藏所有子节点
            for (int i = 0; i < childrens.Count; i++)
            {
                var hideNode = childrens[i];
                hideNode.IsShow = false;
                HideNodes.Add(hideNode);
            }

            return true;
        }

        public bool DeleteNode(NetNode node)
        {
            if (!Nodes.Contains(node))
            {
                this.Invalidate();
                return false;
            }

            var childrens = GetChildrenNetNode(node);//遍历删除所有子节点，包括自己
            for (int i = 0; i < childrens.Count; i++)
            {
                DeleteNodes.Add(childrens[i]);
            }

            DeleteNodes.Add(node);
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