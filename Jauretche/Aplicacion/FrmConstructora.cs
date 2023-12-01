
namespace Aplicacion
{
    public partial class FrmConstructora : Form
    {
        public FrmConstructora()
        {
            InitializeComponent();
        }

        private void Constructora_Load(object sender, EventArgs e)
        {

        }

        private void obrerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmObreros frmObreros = new FrmObreros();
            frmObreros.ShowDialog();
        }
    }
}
