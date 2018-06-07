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
    public partial class frmDiccionario : Form
    {
        int intValor;
        Diccionario objDiccionario;
        ManejaDiccionario objManejaDiccionario;
        public int intCodigo;
        bool boOtraPantalla;
        bool boPantallaPrincial = false;
        string strPermiso;

        public frmDiccionario(string strDescripcion, int intValor)
        {
            InitializeComponent();
            cboDescripcion.Visible = false;
            this.intValor = intValor;
            txtDescripcion.Text = strDescripcion;
            txtDescripcion.Enabled = false;

            //Busco en la tabla diccionario
            objManejaDiccionario = new ManejaDiccionario();
            objDiccionario = objManejaDiccionario.BuscarDiccionario(intValor);
            txtValor.Text = objDiccionario.StrValor1;
            boOtraPantalla = true;
            this.intCodigo = intValor;
            Buscar();
        }
        public frmDiccionario(string strDescripcion)
        {
            InitializeComponent();
            cboDescripcion.Visible = false;
            txtDescripcion.Text = strDescripcion;
            txtDescripcion.Enabled = false;
            btnEliminar.Enabled = false;
            objDiccionario = new Diccionario();
            //Busco en la tabla diccionario
            Buscar();
            boOtraPantalla = true;
        }

        public frmDiccionario(string strDescripcion, string strValor, bool boExiste)
        {
            InitializeComponent();
            cboDescripcion.Visible = false;
            txtDescripcion.Text = strDescripcion;
            txtDescripcion.Enabled = false;
            txtValor.Text = strValor;
            objDiccionario = new Diccionario();
            boOtraPantalla = true;
            this.intCodigo = intValor;
            //Busco en la tabla diccionario
            Buscar();

            if (boExiste)
            {
                if (strPermiso != "LECTURA")
                {
                    btnEliminar.Enabled = true;
                }
            }
            else
                btnEliminar.Enabled = false;


        }


        public frmDiccionario()
        {
            InitializeComponent();
            cboDescripcion.Visible = true;
            btnEliminar.Enabled = false;
            objDiccionario = new Diccionario();
            CargoCombo();
            boPantallaPrincial = true;



        }

        private void CargoCombo()
        {
            CombosStandard objCombosStandar = new CombosStandard();
            objCombosStandar.CargarParametrizaciones(cboDescripcion);
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!VerificoCamposAntesDeGrabar())
            {
                MessageBox.Show("Campos Obligatorios Incompletos");
                return;
            }
            if (intValor != 0)
            {
                //No siempre hace falta actualizar, hay veces que solo lo quiere seleccionar, especialmente cuando viene de otra pantalla
                if (txtValor.Text != objDiccionario.StrValor1.ToUpper())
                {
                    Modifico();
                    MessageBox.Show("El dato ha sido modificado correctamente");
                }
            }
            else
            {
                Grabo();
                MessageBox.Show("El dato ha sido grabado correctamente");
            }

            if (boOtraPantalla)
            {
                intCodigo = objDiccionario.IntCodigo;
                this.Close();
            }
            else
            {
                LimpioCampos();
                Buscar();
            }
            
        }

        private bool VerificoCamposAntesDeGrabar()
        {
            //Tiene Como obligacion cargar el Telefono

            if ((String.IsNullOrEmpty(txtValor.Text)))
                return false;
            else
                return true;

        }

        private void AsignoDatosAlObjeto()
        {
            objDiccionario.StrParametro = txtDescripcion.Text;
            objDiccionario.StrValor1 = txtValor.Text.ToUpper();
            objDiccionario.IntCodigo = intValor;

        }

        private void AsignoCamposConObjetos()
        {
            
            txtDescripcion.Text = objDiccionario.StrParametro;
            txtValor.Text = objDiccionario.StrValor1;
        }

        private void LimpioCampos()
        {
            txtValor.Text = "";
            intValor = 0;
            objDiccionario = null;
            objDiccionario = new Diccionario();
            btnEliminar.Enabled = false;

        }

        private void Grabo()
        {
            AsignoDatosAlObjeto();
            objManejaDiccionario = new ManejaDiccionario();
            objDiccionario.IntCodigo = objManejaDiccionario.GrabarDiccionario(objDiccionario);
        }

        private void Modifico()
        {
            AsignoDatosAlObjeto();
            ManejaDiccionario objManejaDiccionario = new ManejaDiccionario();
            
            objManejaDiccionario.ModificaDiccionario(objDiccionario, intValor);
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string message;
            string caption = "Mensaje";
            ManejaDiccionario objManejaDiccionario = new ManejaDiccionario();
            message = "¿Desea Eliminar el dato?";


            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Si me dice que si, lo elimino

                objManejaDiccionario.EliminaDiccionario(intValor);

                MessageBox.Show("El dato ha sido eliminado correctamente");
                if (boOtraPantalla)
                {
                    LimpioCampos();
                    this.Close();
                }
                else
                {
                    LimpioCampos();
                    Buscar();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpioCampos();
        }

        private void Buscar()
        {
            CargoGrilla();
        }

        private void CargoGrilla()
        {

            grid_diccionario.DataSource = null;
            string strSql;

            strSql = "select dd_id,cc_valor1 from dbo.Diccionario where dd_parametro= '" + txtDescripcion.Text + "'";
            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            grid_diccionario.Rows.Clear();
            CargoTituloGrilla();

            if (dt != null)
            {
                for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                {
                    grid_diccionario.Rows.Add();
                    grid_diccionario[0, i].Value = dt.Rows[i]["dd_id"].ToString();
                    grid_diccionario[1, i].Value = dt.Rows[i]["cc_valor1"].ToString();
                }
            }
        }

        private void CargoTituloGrilla()
        {
            grid_diccionario.DataSource = null;
            grid_diccionario.Rows.Clear();
            grid_diccionario.Columns.Clear();
            grid_diccionario.Columns.Add("ID", null);
            grid_diccionario.Columns.Add("Valor", null);

        }

        private void grid_diccionario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = grid_diccionario.CurrentRow;

            if (row != null)
            {
                intValor = Convert.ToInt32(row.Cells[0].Value.ToString());
                txtValor.Text = row.Cells[1].Value.ToString();
                AsignoDatosAlObjeto();
                if (strPermiso != "LECTURA")
                {
                    btnEliminar.Enabled = true;
                }
            }
        }

        private void cboDescripcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValor.Text = "";
            txtDescripcion.Text= cboDescripcion.Text;
            btnEliminar.Enabled = false;
            Buscar();
        }

        private void frmDiccionario_Load(object sender, EventArgs e)
        {
            if (boPantallaPrincial)
            {
                txtDescripcion.Text = cboDescripcion.Text;
                Buscar();
            }

            strPermiso = frmLogin.getPermiso("SISTEMA", "SISTEMA_PARAMETRIZACIONES");

            if (strPermiso == "LECTURA")
            {
                btnAceptar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }



    }
}
