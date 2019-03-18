using System.Windows.Forms;

namespace Game_Of_Life
{
    public partial class Cell : UserControl
    {
        private bool _Alive;
        public bool Alive
        {
            get => _Alive;
            set
            {
                _Alive = value;
                this.BackColor = (_Alive) ? Options.AliveColor : Options.DeadColor;
            }
        }

        public Cell()
        {
            InitializeComponent();
            Alive = true;
        }
    }
}
