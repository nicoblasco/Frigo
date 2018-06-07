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
    public partial class frmContactos : Form
    {
        Contactos objContactos;
        List<Contactos> list = new List<Contactos>();
        List<Telefonos> listTelefonos = new List<Telefonos>();
        int modifica;
        string strPermiso;
        public frmContactos(List<Contactos> list, string strRazonSocial)
        {

            InitializeComponent();
            this.list = list;
            txtProveedor.Text = strRazonSocial.ToUpper();
            txtProveedor.Enabled = false;
            
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
                list.ElementAt(this.modifica).StrNombre = txtNombre.Text.ToUpper();
                list.ElementAt(this.modifica).StrApellido = txtApellido.Text.ToUpper();
                list.ElementAt(this.modifica).StrEmail = txtEmail.Text;
                list.ElementAt(this.modifica).StrPuesto = txtPuesto.Text.ToUpper();
                list.ElementAt(this.modifica).StrObservacion = txtObservaciones.Text.ToUpper();
                list.ElementAt(this.modifica).ListTelefonos = listTelefonos;
                list.ElementAt(this.modifica).IntEstado = 2;//Modificacion
                
            }
            else
            {
                objContactos = new Contactos();
                objContactos.StrNombre = txtNombre.Text.ToUpper();
                objContactos.StrApellido = txtApellido.Text.ToUpper();
                objContactos.StrEmail = txtEmail.Text;
                objContactos.StrPuesto = txtPuesto.Text.ToUpper();
                objContactos.StrObservacion = txtObservaciones.Text.ToUpper();
                objContactos.ListTelefonos = listTelefonos;
                objContactos.IntEstado = 1;//Alta

                // arreglo.Add(objTelefonoPersonal);
                this.list.Add(objContactos);
            }
            LimpiarControles();
            CargoGrilla();
        }

        private void CargoGrilla()
        {
            int i = 0;
            gridContactos.DataSource = null;
            gridContactos.Rows.Clear();
            CargoTituloGrilla();
            if (list != null)
            {

                foreach (Contactos element in list)
                {
                    /* if (element.IntEstado != 3)
                     {*/
                    gridContactos.Rows.Add();
                    gridContactos[0, i].Value = element.StrNombre;
                    gridContactos[1, i].Value = element.StrApellido;
                    gridContactos[2, i].Value = element.StrPuesto;
                    gridContactos[3, i].Value = element.StrEmail;
                    gridContactos[4, i].Value = element.StrObservacion;
                    gridContactos[5, i].Value = list.IndexOf(element);
                    if (element.IntEstado == 3)
                        gridContactos.Rows[i].Visible = false;
                    i++;
                    //}


                }


            }

        }

        private void CargoTituloGrilla()
        {
            if (list != null)
            {
                gridContactos.DataSource = null;
                gridContactos.Rows.Clear();
                gridContactos.Columns.Clear();
                gridContactos.Columns.Add("Nombre", null);
                gridContactos.Columns.Add("Apellido", null);
                gridContactos.Columns.Add("Puesto", null);
                gridContactos.Columns.Add("Email", null);
                gridContactos.Columns.Add("Observacion", null);
                gridContactos.Columns.Add("IDInterno", null);
                this.gridContactos.Columns[5].Visible = false;
            }
        }

        private void LimpiarControles()
        {
            txtNombre.Text="";
            txtApellido.Text="";
            txtEmail.Text="";
            txtPuesto.Text="";
            txtObservaciones.Text = "";
            this.modifica = -1;
            btnEliminar.Enabled = false;            
            listTelefonos = new List<Telefonos>();

        }



        private bool VerificoCamposAntesDeGrabar()
        {


            if ((String.IsNullOrEmpty(txtNombre.Text)))
                return false;
            else
                return true;

        }

        private void frmContactos_Load(object sender, EventArgs e)
        {
            CargoTituloGrilla();
            CargoGrilla();
            this.modifica = -1;
            btnEliminar.Enabled = false;

            strPermiso = frmLogin.getPermiso("PROVEEDORES", "EMPLEADOS_ALTA");

            if (strPermiso == "LECTURA")
            {
                btnAceptar.Enabled = false;
                btnEliminar.Enabled = false;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.modifica != -1)
            {
                gridContactos.DataSource = null;
                list.ElementAt(this.modifica).IntEstado = 3;//Baja
                CargoGrilla();
                LimpiarControles();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void gridContactos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = gridContactos.CurrentRow;

            if (row != null)
            {
               /* txtNombre.Text = row.Cells[0].Value.ToString();
                txtApellido.Text = row.Cells[1].Value.ToString();
                txtEmail.Text = row.Cells[2].Value.ToString();
                txtPuesto.Text = row.Cells[3].Value.ToString();
                txtObservaciones.Text = row.Cells[4].Value.ToString();*/

                foreach (Contactos element in list)
                {
                    if (Convert.ToInt32(row.Cells[5].Value.ToString()) ==(list.IndexOf(element)))
                    {
                        txtNombre.Text = element.StrNombre;
                        txtApellido.Text = element.StrApellido;
                        txtEmail.Text = element.StrEmail;
                        txtPuesto.Text = element.StrPuesto;
                        txtObservaciones.Text = element.StrObservacion;
                        listTelefonos = element.ListTelefonos;
                        this.modifica = row.Index;
                        if (strPermiso != "LECTURA")
                        {
                            btnEliminar.Enabled = true;
                        }
                    }
                }
/*                this.modifica = row.Index;
                btnEliminar.Enabled = true;*/
            }
        }

        private void btnOtrosTelefonos_Click(object sender, EventArgs e)
        {

            frmTelefonos objfrmTelefonos = new frmTelefonos(listTelefonos);

            objfrmTelefonos.ShowDialog();
        }

    }
}
