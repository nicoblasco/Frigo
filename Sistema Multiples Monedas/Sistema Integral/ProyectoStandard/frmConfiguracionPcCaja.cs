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
    public partial class frmConfiguracionPcCaja : Form
    {
        Configuraciones objConfiguracion;
        ManejaConfiguraciones objManejaConfiguraciones;
        ManejaDatosImpresion objDatosImpresion;


        public frmConfiguracionPcCaja()
        {
            InitializeComponent();
            CargoCombo();
            objManejaConfiguraciones = new ManejaConfiguraciones();
            objDatosImpresion = new ManejaDatosImpresion();
            AsignoDatos();
        }

        private void CargoCombo()
        {
            CombosStandard objCombosStadard = new CombosStandard();
            objCombosStadard.CargarImpresoras(cboImpresora);

        }


        private void AsignoDatos()
        {
            objConfiguracion = objManejaConfiguraciones.BuscarConfiguracion(Environment.MachineName);
            if (objConfiguracion != null)
            {

                txtNombrePc.Text = Environment.MachineName;
                txNumeroCaja.Text = Convert.ToString(objConfiguracion.IntNumeroCaja);
                cboImpresora.Text = objConfiguracion.StrNombreImpresora;

            }
            else
            {
                txtNombrePc.Text = Environment.MachineName;
            }


        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (objConfiguracion == null)
                Grabo();
            else
                Modifico();
        }

        private void Grabo()
        {
            if (ValidoDatos())
            {
                //Verifico el numero de Caja
                if (objManejaConfiguraciones.ExisteNumeroDeCaja(txNumeroCaja.Text.Trim(), Environment.MachineName))
                {
                    string message;
                    string caption = "Mensaje";

                    message = "¿El Número de Caja ya existe, Desea compartir la caja?";


                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        //Grabo
                        objConfiguracion = new Configuraciones();
                        CargoDatos();
                        objManejaConfiguraciones.GrabarConfiguracion(objConfiguracion);
                        MessageBox.Show("La configuración se grabo correctamente");
                    }

                }
                else
                {
                    //No existe el numero de caja, Grabo
                    objConfiguracion = new Configuraciones();
                    CargoDatos();
                    objManejaConfiguraciones.GrabarConfiguracion(objConfiguracion);
                    MessageBox.Show("La configuración se grabo correctamente");
                }
            }
        }

        private void Modifico()
        {
            if (ValidoDatos())
            {
                CargoDatos();
                objManejaConfiguraciones.ModificarConfiguracion(objConfiguracion);
                MessageBox.Show("La configuración se modifico correctamente");
            }
        }

        private void CargoDatos()
        {
            objConfiguracion.StrNombrePc = txtNombrePc.Text;
            objConfiguracion.StrNombreImpresora = cboImpresora.Text;
            objConfiguracion.IntNumeroCaja = Convert.ToInt32(txNumeroCaja.Text);
        }

        private void frmConfiguracionPcCaja_Load(object sender, EventArgs e)
        {
            string strPermiso = frmLogin.getPermiso("SISTEMA", "SISTEMA_TICKET");

            if (strPermiso == "LECTURA")
            {
                btnAceptar.Enabled = false;
            }
        }

        private bool ValidoDatos()
        {
            if (string.IsNullOrEmpty(txNumeroCaja.Text))
            {
                MessageBox.Show("El numero de caja es obligatorio");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txNumeroCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetras(e);
        }




    }
}
