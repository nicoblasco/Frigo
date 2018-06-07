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
    public partial class frmMedioPago : Form
    {
        MedioDePago objMedioDePago;
        ManejaMedioDePagos objManejaMediosDePago;
        //string strPermisos;

        public frmMedioPago()
        {
            InitializeComponent();
            objMedioDePago = new MedioDePago();
            CargoGrilla();
        }

        private void Limpiar()
        {
            txtDescripcion.Text = "";
            ckPredeterminado.Checked = false;
            objMedioDePago = new MedioDePago();
            CargoGrilla();
        }
        private bool Valido()
        {
            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("La descripción del medio de pago debe estar completa");
                return true;
            }

            return false;
        }

        private void HabilitaDesabilitaCampos(bool boRes)
        {
            txtDescripcion.Enabled = boRes;
            ckPredeterminado.Enabled = boRes;
            btnAceptar.Enabled = boRes;
            btnLimpiar.Enabled = boRes;
            btnEliminar.Enabled = boRes;
        }

        private void AsignoDatosAlObjeto()
        {
            objMedioDePago.StrDescripcion = txtDescripcion.Text.ToUpper().Trim();
            objMedioDePago.IntPredeterminado = Convert.ToInt32( ckPredeterminado.Checked);

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Valido())
                return;

            if (objMedioDePago.IntCodigo != 0)
            {
                Modifico();

                MessageBox.Show("El Medio de Pago ha sido modificado correctamente");
            }
            else
            {
                Grabo();
                MessageBox.Show("El Medio de Pago ha sido grabado correctamente");
            }
            Limpiar();
            CargoGrilla();
            
        }

        private void Grabo()
        {
            AsignoDatosAlObjeto();
            objManejaMediosDePago = new ManejaMedioDePagos();
            objMedioDePago.IntCodigo = objManejaMediosDePago.GrabarMedioDePago(objMedioDePago);

        }
        private void Modifico()
        {
            AsignoDatosAlObjeto();
            objManejaMediosDePago = new ManejaMedioDePagos();
            objManejaMediosDePago.ModificaMedioDePago(objMedioDePago);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string message;
            string caption = "Mensaje";
            message = "Desea Eliminar el Medio De Pago";


            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Si me dice que si, lo elimino
                objManejaMediosDePago.EliminaMedioDePago(objMedioDePago.IntCodigo);

                MessageBox.Show("El Medio de Pago " + objMedioDePago.StrDescripcion + " ha sido eliminado correctamente");

                Limpiar();


            }
        }

        private void CargoGrilla()
        {
            grilla.DataSource = null;
            string strSql;

            strSql = "SELECT mediopago, descripcion, predeterminado ";
            strSql += " from Medio_Pago where fechabaja is null";



            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            grilla.Rows.Clear();
            CargoTituloGrilla();

            if (dt != null)
            {
                for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                {
                    grilla.Rows.Add();
                    grilla[0, i].Value = dt.Rows[i]["mediopago"].ToString();
                    grilla[1, i].Value = dt.Rows[i]["descripcion"].ToString();
                    grilla[2, i].Value = dt.Rows[i]["predeterminado"].ToString();

                }
            }

        }


        private void CargoTituloGrilla()
        {
            grilla.DataSource = null;
            grilla.Rows.Clear();
            grilla.Columns.Clear();
            grilla.Columns.Add("ID", null);
            grilla.Columns.Add("Medio de Pago", null);
            grilla.Columns.Add("Predeterminado", null);


        }

        private void grilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grilla.RowCount > 0)
            {
                ManejaMedioDePagos objManejaMediosDePago = new ManejaMedioDePagos();

                int intCodigo = Convert.ToInt32(grilla.CurrentRow.Cells[0].Value.ToString());

                objMedioDePago = objManejaMediosDePago.BuscarMedioDePago(intCodigo);
                AsignoObjetoACampos(objMedioDePago);

            }
        }

        private void AsignoObjetoACampos(MedioDePago objMedioDePago)
        {
            txtDescripcion.Text = objMedioDePago.StrDescripcion;
            ckPredeterminado.Checked = Convert.ToBoolean( objMedioDePago.IntPredeterminado);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void frmMedioPago_Load(object sender, EventArgs e)
        {
            string strPermiso = frmLogin.getPermiso("SISTEMA", "SISTEMA_MEDIO_DE_PAGOS");

            if (strPermiso == "LECTURA")
            {
                btnAceptar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }



    }
}
