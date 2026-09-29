using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista_Seguridad
{
    public partial class FrmVideo : Form
    {
        private const int ID_MODULO = 4;
        private const int ID_APLICACION=16;
        //tabla ,idmodulo, idaplicacion
        public FrmVideo()
        {
            InitializeComponent();
            navegadorPrueba.NavegadorMetConfigurar("direccion", ID_MODULO, ID_APLICACION);
        }


    }
}
