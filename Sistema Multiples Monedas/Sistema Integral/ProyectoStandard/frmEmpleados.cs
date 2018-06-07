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
    public partial class frmEmpleados : Form
    {

        CombosStandard objCombosStandard;
        Empleados objEmpleados;
        ManejaEmpleados objManejoEmpleados;
        List<Telefonos> listTelefonos;
        bool boOtraPantalla;
        public int intCodigoEmpleados;
        string strPermiso;

        public frmEmpleados()
        {
            InitializeComponent();
            //Cargo los combos
            CargarCombosTodos();

            //Creo los objetos
            objEmpleados = new Empleados();
            objEmpleados.ListTelefonos = new List<Telefonos>();

            //Desabilito el boton de eliminar
            btnEliminar.Enabled = false;
            dtpFechaEgreso.Checked = false;
            dtpFechaIngreso.Value = DateTime.Now;


        }

        public frmEmpleados(Empleados objEmpleados)
        {
            InitializeComponent();
            CargarCombosTodos();
            this.objEmpleados = objEmpleados;
            listTelefonos = objEmpleados.ListTelefonos;
            AsignoCamposConObjetos();
            if (strPermiso != "LECTURA")
            {
                btnEliminar.Enabled = true;
            }
            this.Text = "Empleado: " + Convert.ToString(objEmpleados.IntCodigo) +" "+txtNombre.Text + " " + txtApellido.Text;
            boOtraPantalla = true;

            if (!string.IsNullOrEmpty(objEmpleados.DtFechaBaja))
                HabilitoDesabilitoCampos(false);
                

        }

        public frmEmpleados(string strEmpleados)
        {
            InitializeComponent();
            CargarCombosTodos();
            objEmpleados = new Empleados();
            objEmpleados.ListTelefonos = new List<Telefonos>();
            txtNombre.Text = strEmpleados;            
            boOtraPantalla = true;
            btnEliminar.Enabled = false;
            dtpFechaEgreso.Checked = false;
            dtpFechaIngreso.Value = DateTime.Now;
        }


        private void CargarCombosTodos()
        {
            objCombosStandard = new CombosStandard();
            objCombosStandard.CargarUsuariosConAdmin(cboUsuarios);
            objCombosStandard.CargarProvincias(cboProvincia);
            objCombosStandard.CargarLocalidades(cboLocalidad, cboProvincia.SelectedValue);
            objCombosStandard.CargarTipoDocumento(cboTipoDoc);
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            objCombosStandard.CargarLocalidades(cboLocalidad, cboProvincia.SelectedValue);
        }

        private void btnOtrosTelefonos_Click(object sender, EventArgs e)
        {
            frmTelefonos objfrmTelefonos = new frmTelefonos(objEmpleados.ListTelefonos);

            objfrmTelefonos.ShowDialog();
        }

        private void AsignoDatosAlObjeto()
        {
            objEmpleados.IntLocalidad = Convert.ToInt32(cboLocalidad.SelectedValue);
            objEmpleados.IntProvincia = Convert.ToInt32(cboProvincia.SelectedValue);
            objEmpleados.IntDocumento = Convert.ToInt32(cboTipoDoc.SelectedValue);
            objEmpleados.StrDocumento = txtDni.Text;
            objEmpleados.StrNombre = txtNombre.Text.ToUpper();
            objEmpleados.StrApellido = txtApellido.Text.ToUpper();
            objEmpleados.DtFechadeIngreso = Convert.ToDateTime(dtpFechaIngreso.Text);
            //objEmpleados.DtFechadeEgreso = Convert.ToDateTime(dtpFechaEgreso.Text);


            if (dtpFechaEgreso.Checked == true)
            {
                objEmpleados.DtFechadeEgreso = Convert.ToString(dtpFechaEgreso.Text);
            }
            else
            {
                objEmpleados.DtFechadeEgreso = "";
            }

            objEmpleados.DtFechadeNac = Convert.ToDateTime(dtpFechaNac.Text);
            objEmpleados.StrDepto = txtDepto.Text.ToUpper();
            objEmpleados.StrDirecccion = txtDireccion.Text.ToUpper();
            objEmpleados.StrNacionalidad = cboNacionalidad.Text.ToUpper();
            objEmpleados.StrNro = txtNro.Text.ToUpper();
            objEmpleados.StrPiso = txtPiso.Text.ToUpper();
            objEmpleados.StrCuit = txtCuil.Text;
            objEmpleados.StrObservaciones = txtObservaciones.Text;
            objEmpleados.BoPredeterminado = ckPredeterminado.Checked;
            objEmpleados.IntUser = Convert.ToInt32(cboUsuarios.SelectedValue);
        }

        private void AsignoCamposConObjetos()
        {
            lblLegajo.Text = Convert.ToString(objEmpleados.IntCodigo);
            cboLocalidad.SelectedValue = objEmpleados.IntLocalidad;            
            cboProvincia.SelectedValue = objEmpleados.IntProvincia;
            txtDepto.Text = objEmpleados.StrDepto;
            txtDireccion.Text = objEmpleados.StrDirecccion;
            cboNacionalidad.Text = objEmpleados.StrNacionalidad;            
            txtNro.Text = objEmpleados.StrNro;
            txtPiso.Text = objEmpleados.StrPiso;
            cboTipoDoc.SelectedValue = objEmpleados.IntDocumento;
            txtDni.Text = objEmpleados.StrDocumento;
            txtNombre.Text = objEmpleados.StrNombre;
            txtApellido.Text = objEmpleados.StrApellido;
            dtpFechaIngreso.Value = objEmpleados.DtFechadeIngreso;
            

            if (objEmpleados.DtFechadeEgreso == "")
            {
                dtpFechaEgreso.Checked = false;
            }
            else
            {
                dtpFechaEgreso.Checked = true;
            }
            dtpFechaEgreso.Text = objEmpleados.DtFechadeEgreso;
            dtpFechaNac.Value = objEmpleados.DtFechadeNac;
            txtObservaciones.Text = objEmpleados.StrObservaciones;
            txtCuil.Text = objEmpleados.StrCuit;
            ckPredeterminado.Checked = objEmpleados.BoPredeterminado;
            cboUsuarios.SelectedValue = objEmpleados.IntUser;
        }

        private void LimpioCampos()
        {
            lblLegajo.Text = "";
            cboLocalidad.Text = "FLORENCIO VARELA";
            cboProvincia.Text = "AMBA";
            txtDepto.Text = "";
            txtDireccion.Text = "";
            txtNro.Text = "";
            txtPiso.Text = "";
            cboTipoDoc.Text = "";
            txtDni.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            dtpFechaIngreso.Text = Convert.ToString(DateTime.Now);
            dtpFechaEgreso.Text = Convert.ToString(DateTime.Now);
            dtpFechaEgreso.Checked = false;
            dtpFechaNac.Text = "01/01/1985";
            txtObservaciones.Text = "";
            txtCuil.Text = "";
            objEmpleados = null;
            objEmpleados = new Empleados();
            objEmpleados.ListTelefonos = new List<Telefonos>();
            btnEliminar.Enabled = false;
            ckPredeterminado.Checked = false;
            cboUsuarios.SelectedIndex = -1;

        }

        private void HabilitoDesabilitoCampos(bool boRes)
        {
            if (strPermiso != "LECTURA" && boRes == true)
            {

                groupBox1.Enabled = boRes;
                groupBox2.Enabled = boRes;
                btnEliminar.Enabled = boRes;
                btnAceptar.Enabled = boRes;
            }
            /*
            lblLegajo.Enabled = boRes;
            cboLocalidad.Enabled = boRes;
            cboProvincia.Enabled = boRes;
            txtDepto.Enabled = boRes;
            txtDireccion.Enabled = boRes;
            txtNro.Enabled = boRes;
            txtPiso.Enabled = boRes;
            cboTipoDoc.Enabled = boRes;
            txtDni.Enabled = boRes;
            txtNombre.Enabled = boRes;
            txtApellido.Enabled = boRes;
            dtpFechaIngreso.Enabled = boRes;
            dtpFechaEgreso.Enabled = boRes;
            dtpFechaEgreso.Enabled = boRes;
            dtpFechaNac.Enabled = boRes;
            txtObservaciones.Enabled = boRes;
            txtCuil.Text = "";
            btnEliminar.Enabled = boRes;
            btnAceptar.Enabled = boRes;
            btnOtrosTelefonos.Enabled = boRes;
            ckPredeterminado.Enabled = boRes;
            cboNacionalidad.Enabled = boRes;*/
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!VerificoCamposAntesDeGrabar())
            {
                MessageBox.Show("Campos Obligatorios Incompletos");
                return;
            }

            if (objEmpleados.IntCodigo != 0)
            {
                Modifico();
                MessageBox.Show("El Empleado " + objEmpleados.IntCodigo + "-" + objEmpleados.StrApellido + " " + objEmpleados.StrNombre + " ha sido modificado correctamente");
            }
            else
            {
                Grabo();
                MessageBox.Show("El Empleado " + objEmpleados.IntCodigo + "-" + objEmpleados.StrApellido + " " + objEmpleados.StrNombre + " ha sido grabado correctamente");
            }


            if (boOtraPantalla)
            {
                intCodigoEmpleados = objEmpleados.IntCodigo;
                this.Close();
            }
            else
            {
                LimpioCampos();
            }
        }

        private void Grabo()
        {
            AsignoDatosAlObjeto();
            objManejoEmpleados = new ManejaEmpleados();
            objEmpleados.IntCodigo = objManejoEmpleados.GrabarEmpleados(objEmpleados);
            foreach (var c in objEmpleados.ListTelefonos)
            {

                objManejoEmpleados.GrabarContactoEmpleados(c, objEmpleados.IntCodigo);

            }
        }

        private void Modifico()
        {
            AsignoDatosAlObjeto();
            ManejaEmpleados objManejoEmpleados = new ManejaEmpleados();
            objManejoEmpleados.ModificaEmpleados(objEmpleados);//Actualizo el Empleado
            //Modifico los telefonos del personal
            foreach (var a in objEmpleados.ListTelefonos)
            {
                objManejoEmpleados.VerificaModificacionContactoEmpleados(a, objEmpleados.IntCodigo);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Este bloque se podria automatizar

            string message;
            string caption = "Mensaje";

            ManejaEmpleados objManejaEmpleados = new ManejaEmpleados();
            message = "¿Desea Eliminar el Empleado?";


            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Si me dice que si, lo elimino
                ManejaEmpleados objManejoEmpleados = new ManejaEmpleados();
                objManejoEmpleados.EliminaEmpleados(objEmpleados.IntCodigo);

                foreach (var a in objEmpleados.ListTelefonos)
                {
                    objManejaEmpleados.EliminaContactoEmpleados(a);
                }
                MessageBox.Show("El Empleado " + objEmpleados.IntCodigo + "-" + objEmpleados.StrApellido + " " + objEmpleados.StrNombre + " ha sido eliminado correctamente");
                if (boOtraPantalla)
                {
                    LimpioCampos();
                    this.Close();
                }
                else
                {
                    LimpioCampos();
                }

            }
        }


        private bool VerificoCamposAntesDeGrabar()
        {
            //Tiene Como obligacion cargar el cuil y la razon social

            if ((String.IsNullOrEmpty(cboTipoDoc.Text)) || (String.IsNullOrEmpty(txtApellido.Text)) || (String.IsNullOrEmpty(txtNombre.Text)) || (String.IsNullOrEmpty(txtDni.Text)))
                return false;
            else
                return true;

        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetras(e);
        }

        private void txtCuil_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetras(e);
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            strPermiso = frmLogin.getPermiso("EMPLEADOS", "EMPLEADOS_ALTA");

            if (strPermiso == "LECTURA")
            {
                btnAceptar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

    }
}
