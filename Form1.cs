using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace wFrutoProhibidoMDI
{
    public partial class frmFrutoProhibido : Form
    {
        public frmFrutoProhibido()
        {
            InitializeComponent();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistro frmRegistro = new frmRegistro();
            frmRegistro.MdiParent = this;
            frmRegistro.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmDatosEstudiante = this.ActiveMdiChild;
            if (frmDatosEstudiante != null)
            {
                frmDatosEstudiante.Close();
            }
            else
            {
                this.Close();
            }




        }
    }
}
