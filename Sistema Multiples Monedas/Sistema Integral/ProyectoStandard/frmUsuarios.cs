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
    public partial class frmUsuarios : Form
    {
        Usuarios objUsuarios;
        ManejaUsuarios objManejaUsuarios;
        public frmUsuarios()
        {
            InitializeComponent();
            objUsuarios = new Usuarios();
            CargoGrilla();
        }
        private void Limpiar()
        {
            txtUsuario.Text = "";
            txtNombreApellido.Text = "";
            txtContraseña.Text = "";
            txtRepetirContraseña.Text = "";
            ckEsAdministrador.Checked = false;
            objUsuarios = new Usuarios();
            CargoGrilla();
        }
        private bool Valido( Usuarios objUsuario )
        {
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("El usuario debe estar completo");
                return true;
            }
            if (txtNombreApellido.Text == "")
            {
                MessageBox.Show("El campo Nombre y Apellido debe estar completo");
                return true;
            }
            if (txtContraseña.Text == "")
            {
                MessageBox.Show("La contraseña debe estar completa");
                return true;
            }
            if (txtRepetirContraseña.Text == "")
            {
                MessageBox.Show("El campo Repetir contraseña debe estar completa");
                return true;
            }

            if (txtContraseña.Text != txtRepetirContraseña.Text)
            {
                MessageBox.Show("La contraseña debe coincidir con el campo Repetir contraseña");
                return true;
            }

            if (objUsuario.IntCodigo > 0)
            {
                if (objUsuario.StrUsuario.ToUpper().Trim() != txtUsuario.Text.ToUpper().Trim())
                {
                    objManejaUsuarios = new ManejaUsuarios();
                    if (objManejaUsuarios.ExisteUsuario(txtUsuario.Text.ToUpper().Trim()))
                    {
                        MessageBox.Show("El Usuario ya existe en la base de datos");
                        return true;
                    }
                }
            }

            else
            {
                objManejaUsuarios = new ManejaUsuarios();
                if (objManejaUsuarios.ExisteUsuario(txtUsuario.Text.ToUpper().Trim()))
                {
                    MessageBox.Show("El Usuario ya existe en la base de datos");
                    return true;
                }
            }

            return false;
        }

        private void HabilitaDesabilitaCampos(bool boRes)
        {
            grbUsuarios.Enabled = boRes;
            btnAceptar.Enabled = boRes;
            btnEliminar.Enabled = boRes;
        }

        private void AsignoDatosAlObjeto()
        {
            objUsuarios.StrUsuario = txtUsuario.Text.ToUpper().Trim();
            objUsuarios.StrNombreApellido = txtNombreApellido.Text.ToUpper().Trim();
            objUsuarios.IntEsAdmin = Convert.ToInt32(ckEsAdministrador.Checked);
            objUsuarios.StrContraseña = txtContraseña.Text;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Valido(objUsuarios))
                return;

            if (objUsuarios.IntCodigo != 0)
            {
                Modifico();

                MessageBox.Show("El Usuario " + objUsuarios.StrUsuario + " ha sido modificado correctamente");
            }
            else
            {
                Grabo();
                MessageBox.Show("El Usuario " + objUsuarios.StrUsuario + " ha sido grabado correctamente");
            }
            CargoGrilla();
        }

        private void Grabo()
        {
            AsignoDatosAlObjeto();
            objManejaUsuarios = new ManejaUsuarios();
            objUsuarios.IntCodigo = objManejaUsuarios.GrabarUsuarios(objUsuarios);

        }
        private void Modifico()
        {
            AsignoDatosAlObjeto();
            objManejaUsuarios = new ManejaUsuarios();
            objManejaUsuarios.ModificarUsuarios(objUsuarios);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string message;
            string caption = "Mensaje";
            //Primero me tengo que fijar si el cliente tiene alguna Carta de Porte asociada
            ManejaUsuarios objManejaUsuarios = new ManejaUsuarios();
            message = "Desea Eliminar el Usuario";


            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Si me dice que si, lo elimino
                objManejaUsuarios.EliminaUsuario(objUsuarios.IntCodigo);

                MessageBox.Show("El Usuario " + objUsuarios.StrUsuario + " ha sido eliminado correctamente");

                Limpiar();


            }
        }

        private void CargoGrilla()
        {
            gridUsuarios.DataSource = null;
            string strSql;

            strSql = "SELECT id, usuario, nombre_apellido, es_admin, contraseña ";
            strSql += " from USUARIOS";



            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            gridUsuarios.Rows.Clear();
            CargoTituloGrilla();

            if (dt != null)
            {
                for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                {
                    gridUsuarios.Rows.Add();
                    gridUsuarios[0, i].Value = dt.Rows[i]["id"].ToString();
                    gridUsuarios[1, i].Value = dt.Rows[i]["usuario"].ToString();
                    gridUsuarios[2, i].Value = dt.Rows[i]["nombre_apellido"].ToString();
                    gridUsuarios[3, i].Value = dt.Rows[i]["es_admin"].ToString();

                }
            }

        }


        private void CargoTituloGrilla()
        {
            gridUsuarios.DataSource = null;
            gridUsuarios.Rows.Clear();
            gridUsuarios.Columns.Clear();
            gridUsuarios.Columns.Add("ID", null);
            gridUsuarios.Columns.Add("Usuario", null);
            gridUsuarios.Columns.Add("Nombre y Apellido", null);
            gridUsuarios.Columns.Add("Es Administrador?", null);
            this.gridUsuarios.Columns[2].Width = 300;

        }

        private void gridUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridUsuarios.RowCount > 0)
            {
                ManejaUsuarios objManejaUsuarios = new ManejaUsuarios();

                int intCodigo = Convert.ToInt32(gridUsuarios.CurrentRow.Cells[0].Value.ToString());
                
                objUsuarios = objManejaUsuarios.BuscarUsuario(intCodigo);
                AsignoObjetoACampos(objUsuarios);
                               
            }
        }

        private void AsignoObjetoACampos(Usuarios objUsuarios)
        {
            txtUsuario.Text = objUsuarios.StrUsuario;
            txtNombreApellido.Text = objUsuarios.StrNombreApellido;
            txtContraseña.Text = objUsuarios.StrContraseña;
            txtRepetirContraseña.Text = objUsuarios.StrContraseña;
            ckEsAdministrador.Checked = Convert.ToBoolean( objUsuarios.IntEsAdmin);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            string strPermiso = frmLogin.getPermiso("USUARIOS", "USUARIOS_ADMINISTRACION");

            if (strPermiso == "LECTURA")
            {
                btnAceptar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

    }
}
