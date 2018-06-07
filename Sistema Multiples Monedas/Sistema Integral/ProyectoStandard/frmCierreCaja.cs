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
    public partial class frmCierreCaja : Form
    {
        ManejaCierreDeCaja objManejaCierreDeCaja;
        CierreDeCaja objCierreCaja;
        CombosStandard objCombosStandard;
        ManejaConfiguraciones objManejaConfiguracion;
        Configuraciones objConfiguracion;
        Int32 idCierreCaja = 0;
        bool boOtraPantalla = false;


        public frmCierreCaja()
        {
            InitializeComponent();
            CargoConfiguracion();
            
            dtpFechaIngreso.Value = DateTime.Now;

            
            objManejaCierreDeCaja = new ManejaCierreDeCaja();
            txtTotalEfectivo.Enabled = false;
            txtTotalCaja.Enabled = false;
            txtCtaCte.Enabled = false;
            txtVentaEnEfectivo.Enabled = false;
            txtComprasEnEfectivo.Enabled = false;
            
            
        }

        public frmCierreCaja( Int32 idCierreCaja)
        {
            InitializeComponent();
            boOtraPantalla = true;
            this.idCierreCaja = idCierreCaja;
            CargoConfiguracion();

            dtpFechaIngreso.Value = DateTime.Now;


            objManejaCierreDeCaja = new ManejaCierreDeCaja();
            txtTotalEfectivo.Enabled = false;
            txtTotalCaja.Enabled = false;
            txtCtaCte.Enabled = false;
            txtVentaEnEfectivo.Enabled = false;
            txtComprasEnEfectivo.Enabled = false;


        }


        private void ValidacionesDeApertura()
        {
            string message;
            string caption = "Mensaje";
            objManejaCierreDeCaja = new ManejaCierreDeCaja();

            //Valido Si es la primera vez que ingresa al sistema
            if (objManejaCierreDeCaja.ValidaEsInicioDeCaja(objConfiguracion.IntNumeroCaja))
            {
                //Es la primera vez que ingresa al Sistema
                //Pregunto si quiere abrir la caja

                message = "Desea realizar la apertura de la caja";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Grabo();
                    MessageBox.Show("La Apertura se ha realizado correctamente");
                }
                else
                    return;
            }
            else
            {
                //Si no es la primera vez, debo validar si dejo abierta la caja y la desea cerrar
                if (objManejaCierreDeCaja.ValidaCajaAbierta(objConfiguracion.IntNumeroCaja))
                {
                    //Tiene la caja abierta --> Puede querer cerrarla o solo observar
                    message = "La caja se encuentra abierta, desea realizar el cierre de caja?";

                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        GraboCierreDeCaja();
                        MessageBox.Show("La caja se ha cerrado correctamente");
                        this.Close();
                    }
                    else
                        return; //Va a mirar o actualizar el dinero principal
                }
                else
                {
                    //La Caja esta cerrada
                    MessageBox.Show("La caja se encuentra cerrada, para abrirla debe ingresar el dinero inicial y grabar");
                }

            }


        }
        private void CargoConfiguracion()
        {
            //Cargo Configuraciones
            objManejaConfiguracion = new ManejaConfiguraciones();
            objConfiguracion = objManejaConfiguracion.BuscarConfiguracion(Environment.MachineName);
        }

        private void CargoCombosStandard()
        {
            objCombosStandard = new CombosStandard();
            objCombosStandard.CargarTotalesDeVentasPorMedioDePago(listBox, idCierreCaja, dtpFechaIngreso.Text);


        }


        private void CargoValores()
        {
            //Debo Verificar si para el dia de hoy existe dinero inicial cargado

            if (objManejaCierreDeCaja.DineroInicial(idCierreCaja) == null)
            {
                txtDineroInicial.Text = "0";
                objCierreCaja = new CierreDeCaja();

                txtDineroInicial.Text = "0";
                txtVentaEnEfectivo.Text = "0";
                txtCtaCte.Text = "0";
                txtComprasEnEfectivo.Text = "0";
                txtDevoluciones.Text = "0";
                txtTotalCaja.Text = "0";
                txtTotalEfectivo.Text = "0";

            }
            else
            {
                objCierreCaja = objManejaCierreDeCaja.DineroInicial(idCierreCaja);
                txtDineroInicial.Text = Convert.ToString(objCierreCaja.DeTotal);
                dtpFechaIngreso.Value = objCierreCaja.DtFecha;    

                txtVentaEnEfectivo.Text = Convert.ToString(objManejaCierreDeCaja.TotalVentaEnEfectivo(idCierreCaja));
                txtCtaCte.Text = Convert.ToString(objManejaCierreDeCaja.TotalCtaCte(idCierreCaja));
                txtComprasEnEfectivo.Text = Convert.ToString(objManejaCierreDeCaja.TotalCompraEnEfectivo(idCierreCaja));
                txtDevoluciones.Text = Convert.ToString(objManejaCierreDeCaja.TotalDevoluciones(idCierreCaja));
                txtTotalCaja.Text = Convert.ToString(CalculoTotal());


                //txtTotal.Text = Convert.ToString((Convert.ToDecimal(txtDineroInicial.Text.Replace('.', ',')) + Convert.ToDecimal(txtVentaEnEfectivo.Text)) - Convert.ToDecimal(txtComprasEnEfectivo.Text) + Convert.ToDecimal(txtCtaCte.Text));
                txtTotalEfectivo.Text = Convert.ToString(CalculoTotalenEfectivo());
            }

            


        }

        //Este es el total con todos los medio de pago
        private decimal CalculoTotal()
        {
            if ((Convert.ToDecimal(txtDineroInicial.Text) + Convert.ToDecimal(txtVentaEnEfectivo.Text)) - Convert.ToDecimal(txtComprasEnEfectivo.Text) - Convert.ToDecimal(txtDevoluciones.Text) < 0)
                return 0;
            else
                return (Convert.ToDecimal(txtDineroInicial.Text.Replace('.', ',')) + Convert.ToDecimal(txtVentaEnEfectivo.Text)) - Convert.ToDecimal(txtComprasEnEfectivo.Text) - Convert.ToDecimal(txtDevoluciones.Text);
        }

        //Este es el total en efectivo
        private decimal CalculoTotalenEfectivo()
        {
            decimal deTotalEfectivo;
            ManejaVentas objManejaVentas = new ManejaVentas();
            deTotalEfectivo=Redondeo( Convert.ToDecimal( objManejaVentas.BuscoTotalDineroEnEfectivo(idCierreCaja, dtpFechaIngreso.Text)));

            if ((Convert.ToDecimal(txtDineroInicial.Text) + deTotalEfectivo) - Convert.ToDecimal(txtComprasEnEfectivo.Text) - Convert.ToDecimal(txtDevoluciones.Text) < 0)
                return 0;
            else
                return (Convert.ToDecimal(txtDineroInicial.Text.Replace('.', ',')) + deTotalEfectivo )- Convert.ToDecimal(txtComprasEnEfectivo.Text) - Convert.ToDecimal(txtDevoluciones.Text);

        }


        private void frmCierreCaja_Load(object sender, EventArgs e)
        {
            string strPermiso = frmLogin.getPermiso("SISTEMA", "SISTEMA_CIERRE_CAJA");
            if (boOtraPantalla== false)
            {
                //Ya viene Cargado de otra pantalla
                objManejaCierreDeCaja = new ManejaCierreDeCaja();
                idCierreCaja = objManejaCierreDeCaja.getCierreCajaId(objConfiguracion.IntNumeroCaja);
            }
            else
            {
                strPermiso = "LECTURA";
            }
            CargoValores();
            CargoCombosStandard();            
            

            if (strPermiso == "LECTURA")
            {
                btnAceptar.Enabled = false;
            }
            else
            {
                ValidacionesDeApertura();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (objCierreCaja.IntCodigo != 0)
            {
                Modifico();

                MessageBox.Show("El dinero inicial ha sido modificado correctamente");
            }
            else
            {
                Grabo();
                MessageBox.Show("El dinero incial ha sido grabado correctamente");
            }

        }

        private void Grabo()
        {
            AsignoDatosAlObjeto();
            objManejaCierreDeCaja = new ManejaCierreDeCaja();
            objCierreCaja.IntCodigo = objManejaCierreDeCaja.GrabarCierreDeCaja(objCierreCaja);
        }

        private void Modifico()
        {
            AsignoDatosAlObjeto();
            objManejaCierreDeCaja.ModificaCierreDeCaja(objCierreCaja);

        }

        private void GraboCierreDeCaja()
        {
            AsignoDatosAlObjetoParaCierre();
            objManejaCierreDeCaja.ModificaCierreDeCaja_Cierre(objCierreCaja);
        }

        private void AsignoDatosAlObjeto()
        {
            objCierreCaja.DtFecha = Convert.ToDateTime(dtpFechaIngreso.Text);
            if (string.IsNullOrEmpty(txtDineroInicial.Text))
                objCierreCaja.DeTotal = 0;
            else
                objCierreCaja.DeTotal = Convert.ToDecimal(txtDineroInicial.Text.Replace('.', ','));

            objCierreCaja.IntNumeroCaja = objConfiguracion.IntNumeroCaja;
            objCierreCaja.IntUsuarioApertura = frmLogin.Usuarioid;

        }

        private void AsignoDatosAlObjetoParaCierre()
        {
            if (string.IsNullOrEmpty(txtTotalEfectivo.Text))
                objCierreCaja.DeTotalCierre = 0;
            else
                objCierreCaja.DeTotalCierre = Convert.ToDecimal(txtTotalEfectivo.Text.Replace('.', ','));

            objCierreCaja.IntUsuarioCierre = frmLogin.Usuarioid;

        }


        private void txtDineroInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetrasPerosiNumerosconUnPunto(sender, e);
        }

        private void txtDineroInicial_Leave(object sender, EventArgs e)
        {
            txtTotalCaja.Text = Convert.ToString(CalculoTotal());
            txtTotalEfectivo.Text = Convert.ToString((Convert.ToDecimal(txtDineroInicial.Text.Replace('.', ',')) + Convert.ToDecimal(txtVentaEnEfectivo.Text)) - Convert.ToDecimal(txtComprasEnEfectivo.Text) + Convert.ToDecimal(txtCtaCte.Text));
        }



        private decimal Redondeo(decimal deVariable)
        {
            return decimal.Round(deVariable, 2, MidpointRounding.AwayFromZero);
        }


    }


}
