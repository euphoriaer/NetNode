using NetNodeLib;

namespace NetNodeExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NetNode node=new NetNode();
            node.Name = "Root";
            node.LeftDots.Add(new NodeDot());
            node.LeftDots.Add(new NodeDot());
            node.LeftDots.Add(new NodeDot());
            node.RightDots.Add(new NodeDot());
            node.RightDots.Add(new NodeDot());
            node.RightDots.Add(new NodeDot());
            node.RightDots.Add(new NodeDot());
            node.RightDots.Add(new NodeDot());
            netNodeEditor1.DrawNode(node);
        }

        private void netNodeEditor1_Load(object sender, EventArgs e)
        {

        }
    }
}