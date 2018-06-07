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
    public partial class frmVentasCuentaCorriente : Form
    {
        Ventas_Pagos objPagos;
        List<Ventas_Pagos> list = new List<Ventas_Pagos>();
        int modifica;
        int intNumeroCaja;
        decimal deDebe;
        decimal deTotalFactura;

        public frmVentasCuentaCorriente(List<Ventas_Pagos> list, decimal deDebe, decimal deTotalFactura, int intNumeroCaja)
        {
            InitializeComponent();
            CargoCombos();
            this.list = list;
            this.intNumeroCaja = intNumeroCaja;
            dtpFecha.Text = Convert.ToString(DateTime.Now);
            txtDebe.Text = Convert.ToString(Redondeo(deDebe));
            this.deDebe = deDebe;
            this.deTotalFactura = deTotalFactura;
        }

        private void CargoCombos()
        {
            CombosStandard objCombos = new CombosStandard();
            objCombos.CargarMedioDePago(cboMedioDePago);
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!VerificoCamposAntesDeGrabar())
            {
                MessageBox.Show("Campos Obligatorios Incompletos");
                return;
            }

            if (this.modifica != -1)
            {
                //Si se esta modificando, modifico la lista en ese indice
                list.ElementAt(this.modifica).DtFecha = Convert.ToDateTime(dtpFecha.Value);
                list.ElementAt(this.modifica).DeImporte = Convert.ToDecimal(txtImporte.Text.Replace('.', ','));
                list.ElementAt(this.modifica).IntMedioPago = Convert.ToInt32(cboMedioDePago.SelectedValue);
                list.ElementAt(this.modifica).IntNumeroCaja = intNumeroCaja;
                list.ElementAt(this.modifica).IntEstado = 2;//Modificacion
            }
            else
            {
                objPagos = new Ventas_Pagos();
                objPagos.DtFecha = Convert.ToDateTime(dtpFecha.Value);
                objPagos.DeImporte = Convert.ToDecimal(txtImporte.Text.Replace('.', ','));
                objPagos.IntMedioPago = Convert.ToInt32(cboMedioDePago.SelectedValue);
                objPagos.IntNumeroCaja = intNumeroCaja;
                objPagos.IntEstado = 1;//Alta

                this.list.Add(objPagos);
            }
            LimpiarControles();
            CargoGrilla();
        }

        private void CargoGrilla()
        {
            int i = 0;
            ManejaVentas objManejaVentas = new ManejaVentas();

            grid_Pagos.DataSource = null;
            grid_Pagos.Rows.Clear();
            decimal dePagado =0;

            CargoTituloGrilla();
            if (list.Count != 0)
            {

                foreach (Ventas_Pagos element in list)
                {
                    /* if (element.IntEstado != 3)
                     {*/
                    grid_Pagos.Rows.Add();
                    grid_Pagos[0, i].Value = element.DtFecha;
                    grid_Pagos[1, i].Value = Convert.ToString(Redondeo(element.DeImporte));
                    grid_Pagos[2, i].Value = element.IntMedioPago;
                    grid_Pagos[3, i].Value =  objManejaVentas.BuscoNombreDeMedioDePago( element.IntMedioPago);
                    if (element.IntEstado == 3)
                        grid_Pagos.Rows[i].Visible = false;
                    i++;
                    //}
                    if (element.IntEstado != 3)
                       {
                           dePagado = dePagado + element.DeImporte;
                          
                    }
                    

                }

                txtDebe.Text = Convert.ToString(Redondeo(deTotalFactura - dePagado));
            }

        }

        private void LimpiarControles()
        {
            dtpFecha.Text = Convert.ToString(DateTime.Now);
            txtImporte.Text = "";
            this.modifica = -1;
            btnEliminar.Enabled = false;

        }

        private void CargoTituloGrilla()
        {
            if (list != null)
            {
                grid_Pagos.DataSource = null;
                grid_Pagos.Rows.Clear();
                grid_Pagos.Columns.Clear();
                grid_Pagos.Columns.Add("Fecha", null);
                grid_Pagos.Columns.Add("Importe", null);
                grid_Pagos.Columns.Add("ID Medio Pago", null);
                grid_Pagos.Columns.Add("Medio Pago", null);
                this.grid_Pagos.Columns[0].Width = 200;
                this.grid_Pagos.Columns[2].Visible = false;
            }
        }

        private bool VerificoCamposAntesDeGrabar()
        {
            //Tiene Como obligacion cargar el Telefono

            if ((String.IsNullOrEmpty(txtImporte.Text)))
                return false;
            else
                return true;

        }


        private void frmVentasCuentaCorriente_Load(object sender, EventArgs e)
        {
            CargoTituloGrilla();
            CargoGrilla();
            this.modifica = -1;
            btnEliminar.Enabled = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void grid_Pagos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = grid_Pagos.CurrentRow;

            if (row != null)
            {
                dtpFecha.Value = Convert.ToDateTime(row.Cells[0].Value.ToString());
                txtImporte.Text = Convert.ToString(Redondeo(Convert.ToDecimal(row.Cells[1].Value.ToString())));
                cboMedioDePago.SelectedValue = Convert.ToInt32(row.Cells[2].Value.ToString());
                this.modifica = row.Index;
                btnEliminar.Enabled = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.modifica != -1)
            {
                grid_Pagos.DataSource = null;
                list.ElementAt(this.modifica).IntEstado = 3;//Baja
                CargoGrilla();
                LimpiarControles();
            }
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
