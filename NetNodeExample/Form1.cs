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
            NetNode node = new NetNode();
            node.Name = "Root";

           var dot1= node.CreateLeftDot();
            node.CreateLeftDot();
            node.CreateLeftDot();
            node.CreateRightDot();
            node.CreateRightDot();
           var dot2= node.CreateRightDot();
            node.CreateRightDot();
            node.CreateRightDot();


            node.options.Add(new LineOption());
            node.options.Add(new LineOption());

            var op = new LineOption()
            {
                Name = "click",
                Clicked = () =>
                {
                   node.ConnectNodeDot(dot1, dot2);
                },
            };
            node.options.Add(op);
            netNodeEditor1.DrawNode(node);
        }

        private void netNodeEditor1_Load(object sender, EventArgs e)
        {

        }
    }
}