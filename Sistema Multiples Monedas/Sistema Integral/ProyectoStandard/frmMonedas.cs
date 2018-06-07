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
    public partial class frmMonedas : Form
    {
        ManejaMonedas objManejaMonedas;
        Monedas objMonedas;
        public frmMonedas()
        {
            InitializeComponent();
            objMonedas = new Monedas();
            CargoGrilla();
        }

        private void Limpiar()
        {
            txtDescripcion.Text = "";
            txtCotizacion.Text = "";
            objMonedas = new Monedas();
            CargoGrilla();
        }

        private bool Valido()
        {
            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("La descripción de la moneda debe estar completa");
                return true;
            }

            if (txtCotizacion.Text == "")
            {
                MessageBox.Show("La cotización de la moneda debe estar completa");
                return true;
            }

            return false;
        }

        private void HabilitaDesabilitaCampos(bool boRes)
        {
            txtDescripcion.Enabled = boRes;
            txtCotizacion.Enabled = boRes;
            btnAceptar.Enabled = boRes;
            btnLimpiar.Enabled = boRes;
            btnEliminar.Enabled = boRes;
        }

        private void AsignoDatosAlObjeto()
        {
            objMonedas.StrDescripcion = txtDescripcion.Text.ToUpper().Trim();
            objMonedas.DeCotizacion = Convert.ToDecimal(txtCotizacion.Text);

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Valido())
                return;

            if (objMonedas.IntCodigo != 0)
            {
                Modifico();

                MessageBox.Show("La moneda ha sido modificada correctamente");
            }
            else
            {
                Grabo();
                MessageBox.Show("La moneda ha sido grabada correctamente");
            }
            Limpiar();
            CargoGrilla();
        }


        private void Grabo()
        {
            AsignoDatosAlObjeto();
            objManejaMonedas = new ManejaMonedas();
            objMonedas.IntCodigo = objManejaMonedas.GrabarMoneda(objMonedas);


        }
        private void Modifico()
        {
            AsignoDatosAlObjeto();
            objManejaMonedas = new ManejaMonedas();
            objManejaMonedas.ModificarMoneda(objMonedas);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string message="";
            string caption = "Mensaje";

            message = ValidaBorrado();

            if (!String.IsNullOrEmpty(message))
            {
                MessageBox.Show(message);
                return;
            }

            message = "Desea Eliminar la Moneda";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Si me dice que si, lo elimino
                objManejaMonedas.EliminaMoneda(objMonedas.IntCodigo);

                MessageBox.Show("La Moneda " + objMonedas.StrDescripcion + " ha sido eliminada correctamente");

                Limpiar();


            }
        }

        private string ValidaBorrado()
        {
            string message = "";
            ManejaMonedas objManejaMonedas = new ManejaMonedas();
            if (objMonedas.IntCodigo == 1)
            {
                message="No se permite eliminar la moneda principal";
                return message;
            }

            if (objManejaMonedas.TieneArticulosAsociados(objMonedas.IntCodigo))
            {
                message = "La moneda se encuentra asociada a Articulos, no se puede borrar";
                return message;
            }
            return null;
        }

        private void CargoGrilla()
        {
            grilla.DataSource = null;
            string strSql;

            strSql = "select monedaid, descripcion, cotizacion ";
            strSql += " from Monedas ";



            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            grilla.Rows.Clear();
            CargoTituloGrilla();

            if (dt != null)
            {
                for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                {
                    grilla.Rows.Add();
                    grilla[0, i].Value = dt.Rows[i]["monedaid"].ToString();
                    grilla[1, i].Value = dt.Rows[i]["descripcion"].ToString();
                    grilla[2, i].Value = dt.Rows[i]["cotizacion"].ToString();

                }
            }

        }


        private void CargoTituloGrilla()
        {
            grilla.DataSource = null;
            grilla.Rows.Clear();
            grilla.Columns.Clear();
            grilla.Columns.Add("ID", null);
            grilla.Columns.Add("Moneda", null);
            grilla.Columns.Add("Descripcion", null);


        }


        private void AsignoObjetoACampos(Monedas objMoneda)
        {
            txtDescripcion.Text = objMoneda.StrDescripcion;
            txtCotizacion.Text = Convert.ToString(objMoneda.DeCotizacion);
        }

        private void grilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grilla.RowCount > 0)
            {
                ManejaMonedas objManejaMonedas = new ManejaMonedas();

                int intCodigo = Convert.ToInt32(grilla.CurrentRow.Cells[0].Value.ToString());

                objMonedas = objManejaMonedas.BuscarMoneda(intCodigo);
                AsignoObjetoACampos(objMonedas);

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void frmMonedas_Load(object sender, EventArgs e)
        {
            string strPermiso = frmLogin.getPermiso("SISTEMA", "SISTEMA_MONEDAS");

            if (strPermiso == "LECTURA")
            {
                btnAceptar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void txtCotizacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetrasPerosiNumerosconUnPunto(sender, e);
        }
    }
}
