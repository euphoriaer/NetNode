namespace NetNodeLib
{
    public partial class NetNode : UserControl
    {
        public NetNode()
        {
            InitializeComponent();
        }

        private void NetNode_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
}