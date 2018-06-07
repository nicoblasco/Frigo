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
using System.Data.SqlClient;

namespace ProyectoStandard
{
    public partial class frmLogin : Form
    {
        public static List<Perfiles> listPerfiles = new List<Perfiles>();
        public static bool isAdmin;
        public static int Usuarioid;
        public static string UserName;
        ManejaPerfiles objManejaPerfiles;
        ManejaUsuarios objManejaUsuarios;
        Usuarios objUsuario;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidoCampos())
                return;

            objManejaUsuarios = new ManejaUsuarios();
            objUsuario = new Usuarios();
            
            objUsuario = objManejaUsuarios.ExisteUsuarioContraseña(txtUsuario.Text, txtContraseña.Text);
            if (objUsuario != null )
            {
                if (objUsuario.IntEsAdmin == 1)
                    isAdmin = true;

                Usuarioid = objUsuario.IntCodigo;
                UserName = objUsuario.StrUsuario;
                //Recupero los perfiles
                objManejaPerfiles = new ManejaPerfiles();
                listPerfiles=objManejaPerfiles.BuscarPerfil(txtUsuario.Text);
                mdiPrincipal ObjMdiPrincipal = new mdiPrincipal();
                ObjMdiPrincipal.Show();
                this.Visible = false;
                
            }
            else
            {
                MessageBox.Show("El usuario y/o contraseña no existe");
            }
        }

        private bool ValidoCampos()
        {
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Debe completar el usuario");
                return true;
            }
            if (txtContraseña.Text == "")
            {
                MessageBox.Show("Debe completar la contraseña");
                return true;
            }
            return false;
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                btnIngresar_Click(null,null);
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                btnIngresar_Click(null, null);
        }

        public static string getPermiso(string strModulo, string strPantalla)
        {
            if (isAdmin)
                return "LECTURA/ESCRITURA";

            string strPermiso = "";
            var item = listPerfiles.Find(c => (c.StrModulo == strModulo) && (c.StrPantalla == strPantalla));

            if (item != null)
                strPermiso = item.StrPermiso;
            else
                MessageBox.Show("Usted no tiene permiso para acceder a la pantalla, contacte al administador");

            return strPermiso;
        }

        public static bool getIsAdmin(string strModulo, string strPantalla)
        {
            if (isAdmin)
                return true;
            else
                return false ;
        }

        public static bool PermiteEntrar(string strModulo, string strPantalla)
        {
            if (isAdmin)
                return true;


            foreach (var item in listPerfiles)
            {
                if (item.StrModulo == strModulo && item.StrPantalla == strPantalla)
                    return true;
            }

            //Si no encontro nada

            MessageBox.Show("Usted no tiene permiso para acceder a la pantalla, contacte al administador");
            return false;

            //var item = listPerfiles.Find(c => (c.StrModulo == strModulo) && (c.StrPantalla == strPantalla));

            //if (item != null)
            //    return true;
            //else
            //{
            //    MessageBox.Show("Usted no tiene permiso para acceder a la pantalla, contacte al administador");
            //    return false;
            //}

        }
    }
}
