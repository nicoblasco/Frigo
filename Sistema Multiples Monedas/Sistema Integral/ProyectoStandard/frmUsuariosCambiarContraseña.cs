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
    public partial class frmUsuariosCambiarContraseña : Form
    {
        ManejaUsuarios objManejaUsuarios;
        Usuarios objUsuarios;
        public frmUsuariosCambiarContraseña()
        {
            InitializeComponent();
            objManejaUsuarios = new ManejaUsuarios();
            objUsuarios = new Usuarios();
            objUsuarios = objManejaUsuarios.BuscarUsuario(frmLogin.Usuarioid);
            txtUsuario.Text = objUsuarios.StrUsuario;
            txtNombreApellido.Text = objUsuarios.StrNombreApellido;
            txtContraseña.Text = objUsuarios.StrContraseña;
            txtRepetirContraseña.Text = objUsuarios.StrContraseña;
            txtUsuario.Enabled = false;
            txtNombreApellido.Enabled = false;

        }

        private void frmUsuariosCambiarContraseña_Load(object sender, EventArgs e)
        {
            string strPermiso = frmLogin.getPermiso("USUARIOS", "USUARIOS_CONTRASEÑA");

            if (strPermiso == "LECTURA")
            {
                btnAceptar.Enabled = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Modifico();

            MessageBox.Show("El Usuario " + objUsuarios.StrUsuario + " ha sido modificado correctamente");
        }

        private void Modifico()
        {
            AsignoDatosAlObjeto();
            objManejaUsuarios = new ManejaUsuarios();
            objManejaUsuarios.ModificarUsuarios(objUsuarios);

        }

        private void AsignoDatosAlObjeto()
        {
            objUsuarios.StrContraseña = txtContraseña.Text;

        }

        private bool Valido()
        {
            /*
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("El usuario debe estar completo");
                return true;
            }
            if (txtNombreApellido.Text == "")
            {
                MessageBox.Show("El campo Nombre y Apellido debe estar completo");
                return true;
            }*/
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
            /*
            objManejaUsuarios = new ManejaUsuarios();
            if (objManejaUsuarios.ExisteUsuario(txtUsuario.Text.ToUpper().Trim()))
            {
                MessageBox.Show("El Usuario ya existe en la base de datos");
                return true;
            }*/
            return false;
        }

    }
}
