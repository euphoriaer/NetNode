namespace NetNodeLib
{
    public partial class NetNodeEditor : UserControl
    {
        public List<NetNode> Nodes = new List<NetNode>();
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
            Nodes.Add(node);
            this.Invalidate();
            //this.Refresh();
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
            this.Invalidate();
        }

        private void NetNodeEditor_Load(object sender, EventArgs e)
        {

        }
    }
}