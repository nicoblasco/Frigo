using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;
using Model;

namespace ProyectoStandard
{
    public partial class frmImpresion : Form
    {
        DatosImpresion objDatosImpresion;
        ManejaDatosImpresion objManejaDatosImpresion;
 
        public frmImpresion()
        {
            InitializeComponent();
            CargoCombo();
            objManejaDatosImpresion = new ManejaDatosImpresion();
            AsignoDatos();

            

        }

        private void CargoCombo()
        {
            CombosStandard objCombosStadard = new CombosStandard();
            objCombosStadard.CargarImpresoras(cboImpresora);            

        }


        private void AsignoDatos()
        {
           
            objDatosImpresion = objManejaDatosImpresion.BuscarDatosImpresion();
            if (objDatosImpresion != null)
            {
                
                txtNombreComercio.Text = objDatosImpresion.StrComercio;
                txtDireccion.Text = objDatosImpresion.StrDireccion;
                txtLocalidad.Text = objDatosImpresion.StrLocalidad;
                txtProvincia.Text = objDatosImpresion.StrProvincia;
                txtCodigoInterno.Text = objDatosImpresion.StrCodigoInterno;
                txtComentarioLinea1.Text = objDatosImpresion.StrComentarioLinea1;
                txtComentarioLinea2.Text = objDatosImpresion.StrComentarioLinea2;
                txtComentarioLinea3.Text = objDatosImpresion.StrComertarioLinea3;
                //cboImpresora.Text = objDatosImpresion.StrImpresora;

            }


        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (objDatosImpresion==null)
                Grabo();
            else
                Modifico();

        }


        private void Grabo()
        {
            objDatosImpresion = new DatosImpresion();
            CargoDatos();
            objManejaDatosImpresion.GrabarDatosImpresion(objDatosImpresion);
            MessageBox.Show("Los parametros de impresion han sido grabado correctamente");
            
        }

        private void Modifico()
        {
            CargoDatos();
            objManejaDatosImpresion.ModificarDatosImpresion(objDatosImpresion);
            MessageBox.Show("Los parametros de impresion han sido modificados correctamente");
        }

        private void CargoDatos()
        {
            objDatosImpresion.StrComercio = txtNombreComercio.Text;
            objDatosImpresion.StrDireccion = txtDireccion.Text;
            objDatosImpresion.StrLocalidad = txtLocalidad.Text;
            objDatosImpresion.StrProvincia=txtProvincia.Text;
            objDatosImpresion.StrCodigoInterno=txtCodigoInterno.Text;
            objDatosImpresion.StrComentarioLinea1=txtComentarioLinea1.Text;
            objDatosImpresion.StrComentarioLinea2=txtComentarioLinea2.Text;
            objDatosImpresion.StrComertarioLinea3=txtComentarioLinea3.Text;
            objDatosImpresion.StrImpresora=cboImpresora.Text;
        }

        private void frmImpresion_Load(object sender, EventArgs e)
        {
            string strPermiso = frmLogin.getPermiso("SISTEMA", "SISTEMA_TICKET");

            if (strPermiso == "LECTURA")
            {
                btnAceptar.Enabled = false;
            }
        }

    }
}
