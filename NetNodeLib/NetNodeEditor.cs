namespace NetNodeLib
{
    public partial class NetNodeEditor : UserControl
    {
        public List<NetNode> Nodes = new List<NetNode>();
        DrawingTools DrawingTools;
        public NetNodeEditor()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
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
                node.DrawDot(DrawingTools);
            }
        }

        private void NetNode_Load(object sender, EventArgs e)
        {

        }

        public void CreateNode(NetNode node)
        {
            Nodes.Add(node);
        }

        private void NetNodeEditor_Load(object sender, EventArgs e)
        {

        }
    }
}