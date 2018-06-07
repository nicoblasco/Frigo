using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using DAO;

namespace ProyectoStandard
{
    public partial class frmArticulosDetalleVenta : Form
    {
       public  ArticulosPorVenta objArticulosPorVenta;
        public frmArticulosDetalleVenta(ArticulosPorVenta objArticulosPorVenta )
        {
            InitializeComponent();
            this.objArticulosPorVenta = objArticulosPorVenta;
            AsignoObjetos();
        }
        private decimal Redondeo(decimal deVariable)
        {
            return decimal.Round(deVariable, 2, MidpointRounding.AwayFromZero);
        }

        private void AsignoObjetos()
        {
            txtCodigo.Text = objArticulosPorVenta.ObjArticulo.StrCodigo;
            txtDescripcion.Text = objArticulosPorVenta.ObjArticulo.StrDescripcion;
            txtDescuento.Text = Convert.ToString( objArticulosPorVenta.IntDescuento);
            txtCantidad.Text = Convert.ToString(objArticulosPorVenta.IntCantidad);
            txtPUEfectivo.Text = Convert.ToString(Redondeo(objArticulosPorVenta.DoPrecioUnitarioConEfectivo));
            txtPUTarjeta.Text = Convert.ToString(Redondeo(objArticulosPorVenta.DoPrecioUnitarioConTarjeta));
            txtTotalEfectivo.Text = Convert.ToString(Redondeo(objArticulosPorVenta.DoTotalConEfectivo));
            txtTotalTarjeta.Text = Convert.ToString(Redondeo(objArticulosPorVenta.DoTotalConTarjeta));

            txtCodigo.Enabled = false;
            txtDescripcion.Enabled = false;
            //txtTotalEfectivo.Enabled = false;
            txtTotalTarjeta.Enabled = false;

        }

        private void CalculoPrecioTotalEnEfectivo()
        {
            if (string.IsNullOrEmpty(txtDescuento.Text) || Convert.ToInt32(txtDescuento.Text) < 1)

                txtTotalEfectivo.Text = Convert.ToString(Redondeo( Convert.ToDecimal( txtPUEfectivo.Text.Replace('.', ',')) * Convert.ToInt32 (txtCantidad.Text)));

            else
                txtTotalEfectivo.Text = Convert.ToString((Redondeo(Convert.ToDecimal(txtPUEfectivo.Text.Replace('.', ',')) - ((Convert.ToDecimal(txtPUEfectivo.Text.Replace('.', ',')) * Convert.ToInt32(txtDescuento.Text)) / 100)) * Convert.ToInt32(txtCantidad.Text)));
        }
        private void CalculoPrecioTotalConTarjeta()
        {
            if (string.IsNullOrEmpty(txtDescuento.Text) || Convert.ToInt32(txtDescuento.Text) < 1)

                txtTotalTarjeta.Text = Convert.ToString(Redondeo(Convert.ToDecimal(txtPUTarjeta.Text) * Convert.ToInt32(txtCantidad.Text)));

            else
                txtTotalTarjeta.Text = Convert.ToString((Redondeo(Convert.ToDecimal(txtPUTarjeta.Text) - ((Convert.ToDecimal(txtPUTarjeta.Text) * Convert.ToInt32(txtDescuento.Text)) / 100)) * Convert.ToInt32(txtCantidad.Text)));
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCantidad.Text))
                txtCantidad.Text = "0";

            if (string.IsNullOrEmpty(txtPUEfectivo.Text))
                txtPUEfectivo.Text = "0";

            if (string.IsNullOrEmpty(txtPUTarjeta.Text))
                txtPUTarjeta.Text = "0";

            if (string.IsNullOrEmpty(txtDescuento.Text))
                txtDescuento.Text = "0";

            CalculoPrecioTotalEnEfectivo();
            CalculoPrecioTotalConTarjeta();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            objArticulosPorVenta.ObjArticulo.StrCodigo = txtCodigo.Text;
            objArticulosPorVenta.ObjArticulo.StrDescripcion = txtDescripcion.Text;
            objArticulosPorVenta.IntDescuento = Convert.ToInt32( txtDescuento.Text);
            objArticulosPorVenta.IntCantidad = Convert.ToInt32(txtCantidad.Text);
            objArticulosPorVenta.DoPrecioUnitarioConEfectivo = Redondeo(Convert.ToDecimal(txtPUEfectivo.Text.Replace('.', ',')));
            objArticulosPorVenta.DoPrecioUnitarioConTarjeta = Redondeo(Convert.ToDecimal(txtPUTarjeta.Text));
            objArticulosPorVenta.DoTotalConEfectivo = Redondeo(Convert.ToDecimal(txtTotalEfectivo.Text.Replace('.', ',')));
            objArticulosPorVenta.DoTotalConTarjeta = Redondeo(Convert.ToDecimal(txtTotalTarjeta.Text));
            this.Close();
            
        }

        private void txtPUEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetrasPerosiNumerosconUnPunto(sender, e);         
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetras(e);
        }

    }
}
