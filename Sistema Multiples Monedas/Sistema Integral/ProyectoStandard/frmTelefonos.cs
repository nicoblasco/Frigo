using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;

namespace ProyectoStandard
{
    public partial class frmTelefonos : Form
    {
        
        Telefonos objTelefonos;
        List<Telefonos> list = new List<Telefonos>();
        int modifica;

        public frmTelefonos(List<Telefonos> list)
        {
            InitializeComponent();
            this.list = list;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!VerificoCamposAntesDeGrabar())
            {
                MessageBox.Show("Campos Obligatorios Incompletos");
                return;
            }

            /*Primero me tengo que fijar si ese numero ya lo cargo y luego ver si no lo esta modificando*/

            if (this.modifica != -1)
            {
                //Si se esta modificando, modifico la lista en ese indice
                list.ElementAt(this.modifica).StrTel = txtTelefono.Text;
                list.ElementAt(this.modifica).StrTipotel = cboTipo.Text;
                list.ElementAt(this.modifica).StrVinculo = cboTipoContacto.Text;
                list.ElementAt(this.modifica).StrInterno = txtInterno.Text;
                list.ElementAt(this.modifica).IntEstado = 2;//Modificacion
            }
            else
            {
                objTelefonos = new Telefonos();
                objTelefonos.StrTipotel = cboTipo.Text;
                objTelefonos.StrTel = txtTelefono.Text;
                objTelefonos.StrVinculo = cboTipoContacto.Text;
                objTelefonos.StrInterno = txtInterno.Text;
                objTelefonos.IntEstado = 1;//Alta

                // arreglo.Add(objTelefonoPersonal);
                this.list.Add(objTelefonos);
            }
            LimpiarControles();
            CargoGrilla();
        }
        private void CargoGrilla()
        {
            int i = 0;
            grid_telefonos.DataSource = null;
            grid_telefonos.Rows.Clear();
            CargoTituloGrilla();
            if (list.Count != 0)
            {

                foreach (Telefonos element in list)
                {
                    /* if (element.IntEstado != 3)
                     {*/
                    grid_telefonos.Rows.Add();
                    grid_telefonos[0, i].Value = element.StrTipotel;
                    grid_telefonos[1, i].Value = element.StrTel;
                    grid_telefonos[2, i].Value = element.StrInterno;
                    grid_telefonos[3, i].Value = element.StrVinculo;                    
                    if (element.IntEstado == 3)
                        grid_telefonos.Rows[i].Visible = false;
                    i++;
                    //}


                }


            }

        }
        private void LimpiarControles()
        {
            cboTipoContacto.Text = "";
            cboTipo.Text = "";
            txtInterno.Text = "";
            txtTelefono.Text = "";
            this.modifica = -1;
            btnEliminar.Enabled = false;

        }

        private void CargoTituloGrilla()
        {
//            if (list.Count != 0)
            if (list !=null)
            {
                grid_telefonos.DataSource = null;
                grid_telefonos.Rows.Clear();
                grid_telefonos.Columns.Clear();
                grid_telefonos.Columns.Add("Tipo", null);
                grid_telefonos.Columns.Add("Telefono", null);
                grid_telefonos.Columns.Add("Interno", null);
                grid_telefonos.Columns.Add("Vinculo", null);
            }
        }

        private bool VerificoCamposAntesDeGrabar()
        {
            //Tiene Como obligacion cargar el Telefono

            if ((String.IsNullOrEmpty(txtTelefono.Text)))
                return false;
            else
                return true;

        }

        private void frmTelefonos_Load(object sender, EventArgs e)
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

        private void grid_telefonos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = grid_telefonos.CurrentRow;

            if (row != null)
            {
                
                cboTipo.Text = row.Cells[0].Value.ToString();
                txtTelefono.Text = row.Cells[1].Value.ToString();
                txtInterno.Text = row.Cells[2].Value.ToString();
                cboTipoContacto.Text = row.Cells[3].Value.ToString();
                this.modifica = row.Index;
                btnEliminar.Enabled = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.modifica != -1)
            {
                grid_telefonos.DataSource = null;
                list.ElementAt(this.modifica).IntEstado = 3;//Baja
                CargoGrilla();
                LimpiarControles();
            }
        }


    }
}
