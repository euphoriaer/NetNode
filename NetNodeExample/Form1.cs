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
                    CreateNode(dot2);
                },
            };
            node.options.Add(op);
            netNodeEditor1.DrawNode(node);
        }

        void CreateNode(NodeDot rightDot)
        {
            NetNode node = new NetNode();
            node.Name = "Child";
            var randomX = Random.Shared.Next(0, 40);
            var randomY = Random.Shared.Next(-80, 40);
            node.Position.X=rightDot.Point.X+ randomX;
            node.Position.Y=rightDot.Point.Y+ randomY;
            var dot= node.CreateLeftDot();
            var dot2= node.CreateRightDot();
            var op = new LineOption()
            {
                Name = "click",
                Clicked = () =>
                {
                    CreateNode(dot2);
                },
            };
            node.options.Add(op);
            node.ConnectNodeDot(rightDot, dot);
            netNodeEditor1.DrawNode(node);
        }


        private void netNodeEditor1_Load(object sender, EventArgs e)
        {

        }
    }
}