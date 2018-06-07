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
    public partial class frmClienteCtaCte : Form
    {
        decimal deDebe;
        Ventas_Pagos objPagos;
        Int32 intClienteid=0;
        ManejaConfiguraciones objManejaConfiguracion = new ManejaConfiguraciones();
        Configuraciones objConfiguracion = new Configuraciones();
        public frmClienteCtaCte(Int32 intClienteid,decimal deDebe)
        {
            InitializeComponent();

            objConfiguracion = objManejaConfiguracion.BuscarConfiguracion(Environment.MachineName);

            CargoCombos();
            this.deDebe = deDebe;
            txtDebe.Text = Convert.ToString(Redondeo(deDebe));
            objPagos = new Ventas_Pagos();
            this.intClienteid = intClienteid;
            dtpFecha.Value = DateTime.Now;
        }

        private void CargoCombos()
        {
            CombosStandard objCombos = new CombosStandard();
            objCombos.CargarMedioDePago(cboMedioDePago);
        }

        private void frmClienteCtaCte_Load(object sender, EventArgs e)
        {
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            string message;
            string caption = "Mensaje";
            
            //Primero me tengo que fijar si el cliente tiene alguna Carta de Porte asociada
            message = "Esta seguro que quiere descontar: $" + Convert.ToString(Redondeo( Convert.ToDecimal(txtImporte.Text.Replace('.', ','))));


            if (!VerificoCamposAntesDeGrabar())
            {
                MessageBox.Show("Campos Obligatorios Incompletos");
                return;
            }
            else
            {
                if (deDebe < Convert.ToDecimal(txtImporte.Text.Replace('.', ',')))
                {
                    MessageBox.Show("El cambo Importe no puede se mayor a lo que debe");
                    return;
                }


               MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    
                    ManejaVentas objManejaVentas = new ManejaVentas();
                    List<Ventas> list = new List<Ventas>();
                    List<Ventas_Pagos> listPagos = new List<Ventas_Pagos>();
                    decimal deDiferencia = deDebe;
                    int i=0;


                    


                    //Debo buscar las facturas impagas que tiene
                    //y descontar del total
                    //Si el total supera el de la factura, descontar de la siguiente y asi sucesivamente

                    //Busco las facturas impagas
                    list = objManejaVentas.BuscoFacturasConDeuda(intClienteid);
                    
                    //Las recorro y voy descontando

                    foreach (var item in list)
                    {
                        if (deDiferencia > 0)
                        {
                            i++;
                            objPagos = new Ventas_Pagos();
                            objPagos.IntEstado = 1;//Alta
                            objPagos.DtFecha = Convert.ToDateTime(dtpFecha.Value);
                            objPagos.IntMedioPago = Convert.ToInt32(cboMedioDePago.SelectedValue);
                            objPagos.IntNumeroCaja = objConfiguracion.IntNumeroCaja;

                            if (i == 1)
                            {
                                if (item.DoDebe > Convert.ToDecimal(txtImporte.Text.Replace('.', ',')))
                                {

                                    objPagos.DeImporte = Convert.ToDecimal(txtImporte.Text.Replace('.', ','));
                                    deDiferencia = 0;
                                    deDebe = deDebe - objPagos.DeImporte;

                                }
                                else
                                {
                                    objPagos.DeImporte = item.DoDebe;
                                    deDiferencia = Convert.ToDecimal(txtImporte.Text.Replace('.', ',')) - item.DoDebe;
                                    deDebe = deDebe - item.DoDebe;


                                }
                            }
                            else
                            {
                                if (item.DoDebe > deDiferencia)
                                {
                                    objPagos.DeImporte = deDiferencia; ;
                                    deDebe = deDebe - deDiferencia;
                                    deDiferencia = 0;


                                }
                                else
                                {
                                    objPagos.DeImporte = item.DoDebe;
                                    deDiferencia = deDiferencia - item.DoDebe;
                                    deDebe = deDebe - item.DoDebe;

                                }

                            }
                            //Grabo el pago
                            objManejaVentas.GrabarVentasPagos(objPagos, item.IntCodigo);
                            
                            //Grabo el detalle de venta
                            item.DoPago = item.DoPago + objPagos.DeImporte;
                            item.DoDebe = item.DoDebe - objPagos.DeImporte;
                            objManejaVentas.ModificaVentas(item);

                        }
                    }
                    

                    

                }

            }
          //  LimpiarControles();
           // ActualizarControles();
            MessageBox.Show("El saldo se ha actualizado correctamente");
            this.Close();
        
        }

        private void LimpiarControles()
        {
            dtpFecha.Text = Convert.ToString(DateTime.Now);
            txtImporte.Text = "";

        }

        private void ActualizarControles()
        {
            LimpiarControles();
            txtDebe.Text = Convert.ToString(Redondeo(deDebe));

        }

        private bool VerificoCamposAntesDeGrabar()
        {
            //Tiene Como obligacion cargar el Telefono

            if ((String.IsNullOrEmpty(txtImporte.Text)))
                return false;
            else
                return true;

        }

        private decimal Redondeo(decimal deVariable)
        {
            return decimal.Round(deVariable, 2, MidpointRounding.AwayFromZero);
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetrasPerosiNumerosconUnPunto(sender, e);

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                btnAceptar_Click(null, null);
        }

    }
}
    