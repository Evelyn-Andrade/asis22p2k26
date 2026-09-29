using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista_Seguridad.Mantenimiento2p2k26
{
    public partial class FrmMantenimientoFacultades : Form
    {
        private const int ID_MODULO = 4;
        private const int ID_APLICACION = 16;
        //tabla ,idmodulo, idaplicacion
        public FrmMantenimientoFacultades()
        {
            InitializeComponent();
            navegador3.NavegadorMetConfigurar("facultades", ID_MODULO, ID_APLICACION);
        }
    }
}
