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
    public partial class frmProveedores : Form
    {
        CombosStandard objCombosStandard;
        Proveedores objProveedores;
        ManejaProveedores objManejoProveedores;
        List<Telefonos> listTelefonos;
        List<Contactos> listContactos;
        bool boOtraPantalla;
        public int intCodigoProveedor;

        public frmProveedores()
        {
            InitializeComponent();
            //Cargo los combos
            CargarCombosTodos();

            //Creo los objetos
            objProveedores = new Proveedores();
            objProveedores.ListTelefonos = new List<Telefonos>();
            objProveedores.ListContactos = new List<Contactos>();
            

            //Desabilito el boton de eliminar
            btnEliminar.Enabled = false;
            dtpFechaIngreso.Value = DateTime.Now;
        }

        public frmProveedores(Proveedores objProveedores)
        {            
            InitializeComponent();
            CargarCombosTodos();
            this.objProveedores = objProveedores;
            listTelefonos = objProveedores.ListTelefonos;
            listContactos = objProveedores.ListContactos;
            AsignoCamposConObjetos();
            btnEliminar.Enabled = true;
            this.Text = "Proveedor: " + lblLegajo.Text + " " + txtRazonSocial.Text;
            boOtraPantalla = true;

            if (!string.IsNullOrEmpty(objProveedores.DtFechaBaja))
                HabilitoDesabilitoCampos(false);

        }

        private void HabilitoDesabilitoCampos(bool boRes)
        {
            groupBox1.Enabled = boRes;
            btnAceptar.Enabled = boRes;
            btnEliminar.Enabled = boRes;
        }

        public frmProveedores(string strProveedor)
        {
            InitializeComponent();
            CargarCombosTodos();
            objProveedores = new Proveedores();
            objProveedores.ListTelefonos = new List<Telefonos>();
            objProveedores.ListContactos = new List<Contactos>();
            txtRazonSocial.Text = strProveedor;
            boOtraPantalla = true;
            btnEliminar.Enabled = false;
            dtpFechaIngreso.Value = DateTime.Now;
        }

        private void CargarCombosTodos()
        {
            objCombosStandard = new CombosStandard();
            objCombosStandard.CargarPaises(cboPais);
            objCombosStandard.CargarProvincias(cboProvincia, cboPais.SelectedValue);
            objCombosStandard.CargarLocalidades(cboLocalidad, cboProvincia.SelectedValue);
            objCombosStandard.CargarTipoDocumento(cboTipoDoc);
            objCombosStandard.CargarDiccionario(cboServicio, "PRODUCTOS/SERVICIOS");
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            objCombosStandard.CargarProvincias(cboProvincia, cboPais.SelectedValue);
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            objCombosStandard.CargarLocalidades(cboLocalidad, Convert.ToInt16(cboProvincia.SelectedValue));
        }

        private void btnOtrosTelefonos_Click(object sender, EventArgs e)
        {
            frmTelefonos objfrmTelefonos = new frmTelefonos(objProveedores.ListTelefonos);

            objfrmTelefonos.ShowDialog();
        }

        private void AsignoDatosAlObjeto()
        {
            objProveedores.IntLocalidad = Convert.ToInt32(cboLocalidad.SelectedValue);
            objProveedores.IntPais = Convert.ToInt32(cboPais.SelectedValue);
            objProveedores.IntProvincia = Convert.ToInt32(cboProvincia.SelectedValue);
            objProveedores.IntDocumento = Convert.ToInt32(cboTipoDoc.SelectedValue);
            objProveedores.StrDocumento = txtDni.Text;
            objProveedores.StrRazonSocial = txtRazonSocial.Text.ToUpper();
            objProveedores.DtFechadeIngreso = Convert.ToDateTime(dtpFechaIngreso.Text);
            objProveedores.StrDepto = txtDepto.Text.ToUpper();
            objProveedores.StrDirecccion = txtDireccion.Text.ToUpper();
            objProveedores.StrNro = txtNro.Text.ToUpper();
            objProveedores.StrPiso = txtPiso.Text.ToUpper();
            objProveedores.StrEmail = txtEmail.Text;
            objProveedores.StrUrl = txtUrl.Text;
            objProveedores.BoLunes = ckLunes.Checked;
            objProveedores.BoMartes = ckMartes.Checked;
            objProveedores.BoMiercoles = ckMiercoles.Checked;
            objProveedores.BoJueves = ckJueves.Checked;
            objProveedores.BoViernes = ckViernes.Checked;
            objProveedores.BoSabado = ckSabado.Checked;
            objProveedores.BoDomingo = ckDomingo.Checked;
            objProveedores.StrServicio = cboServicio.Text;
        }

        private void AsignoCamposConObjetos()
        {
            lblLegajo.Text = Convert.ToString(objProveedores.IntCodigo);
            cboLocalidad.SelectedValue = objProveedores.IntLocalidad;
            cboPais.SelectedValue = objProveedores.IntPais;
            cboProvincia.SelectedValue = objProveedores.IntProvincia;
            txtDepto.Text = objProveedores.StrDepto;
            txtDireccion.Text = objProveedores.StrDirecccion;
            txtEmail.Text = objProveedores.StrEmail;
            txtNro.Text = objProveedores.StrNro;
            txtPiso.Text = objProveedores.StrPiso;
            cboTipoDoc.SelectedValue = objProveedores.IntDocumento;
            txtDni.Text = objProveedores.StrDocumento;
            dtpFechaIngreso.Value = objProveedores.DtFechadeIngreso;
            txtRazonSocial.Text = objProveedores.StrRazonSocial;
            txtUrl.Text=objProveedores.StrUrl;
            ckLunes.Checked=objProveedores.BoLunes;
            ckMartes.Checked=objProveedores.BoMartes;
            ckMiercoles.Checked=objProveedores.BoMiercoles;
            ckJueves.Checked=objProveedores.BoJueves;
            ckViernes.Checked=objProveedores.BoViernes;
            ckSabado.Checked=objProveedores.BoSabado;
            ckDomingo.Checked=objProveedores.BoDomingo;
            cboServicio.Text = objProveedores.StrServicio;
        }

        private void LimpioCampos()
        {
            lblLegajo.Text = "";
            cboLocalidad.Text = "FLORENCIO VARELA";
            cboPais.Text = "ARGENTINA";
            cboProvincia.Text = "AMBA";
            cboServicio.SelectedIndex = -1;
            txtDepto.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtNro.Text = "";
            txtPiso.Text = "";
            cboTipoDoc.Text = "";
            txtDni.Text = "";
            txtRazonSocial.Text = "";
            dtpFechaIngreso.Text = Convert.ToString(DateTime.Now);
            txtUrl.Text = "";
            objProveedores = null;
            objProveedores = new Proveedores();
            objProveedores.ListTelefonos = new List<Telefonos>();
            objProveedores.ListContactos = new List<Contactos>();
            btnEliminar.Enabled = false;
            ckLunes.Checked = false;
            ckMartes.Checked = false;
            ckMiercoles.Checked = false;
            ckJueves.Checked = false;
            ckViernes.Checked = false;
            ckSabado.Checked = false;
            ckDomingo.Checked = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!VerificoCamposAntesDeGrabar())
            {
                MessageBox.Show("Campos Obligatorios Incompletos");
                
                return;
            }

            if (objProveedores.IntCodigo != 0)
            {
                Modifico();
                MessageBox.Show("El Proveedor " + objProveedores.IntCodigo + "-" + objProveedores.StrRazonSocial + " ha sido modificado correctamente");
            }
            else
            {
                Grabo();
                MessageBox.Show("El Proveedor " + objProveedores.IntCodigo + "-" + objProveedores.StrRazonSocial +  " ha sido grabado correctamente");
            }

            if (boOtraPantalla)
            {
                intCodigoProveedor = objProveedores.IntCodigo;
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
            objManejoProveedores = new ManejaProveedores();
            ManejaContactoProveedores objManejaContactoProveedores = new ManejaContactoProveedores();
            objProveedores.IntCodigo = objManejoProveedores.GrabarProveedores(objProveedores);
            foreach (var c in objProveedores.ListTelefonos)
            {
                objManejoProveedores.GrabarContactoProveedores(c, objProveedores.IntCodigo);

            }

            foreach (var d in objProveedores.ListContactos)
            {
                d.IntProveedor = objProveedores.IntCodigo;
                d.IntCodigo= objManejaContactoProveedores.GrabarContactos(d);

                foreach (var e in d.ListTelefonos)
                {
                    objManejaContactoProveedores.GrabarContactoContactos(e, d.IntCodigo);

                }

            }




        }

        private void Modifico()
        {
            AsignoDatosAlObjeto();
            ManejaProveedores objManejoProveedores = new ManejaProveedores();
            objManejoProveedores.ModificaProveedores(objProveedores);
            ManejaContactoProveedores objManejaContactoProveedores = new ManejaContactoProveedores();
            //Modifico los telefonos del personal
            foreach (var a in objProveedores.ListTelefonos)
            {
                objManejoProveedores.VerificaModificacionContactoProveedores(a, objProveedores.IntCodigo);
            }

            foreach (var e in objProveedores.ListContactos)
            {
                e.IntProveedor = objProveedores.IntCodigo;
                objManejoProveedores.VerificaModificacionContactos(e, objProveedores.IntCodigo);
                //Aca deberia devolverle el id de contacto
                foreach (var f in e.ListTelefonos)
                {
                    objManejaContactoProveedores.VerificaModificacionContactoProveedores(f, e.IntCodigo);
                }

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string message;
            string caption = "Mensaje";
            //Primero me tengo que fijar si el cliente tiene alguna Carta de Porte asociada
            ManejaProveedores objManejaProveedores = new ManejaProveedores();
            ManejaContactoProveedores objManejaContactoProveedores = new ManejaContactoProveedores();
            message = "Desea Eliminar el Proveedor";


            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Si me dice que si, lo elimino

                objManejaProveedores.EliminaProveedores(objProveedores.IntCodigo);
                foreach (var a in objProveedores.ListTelefonos)
                {
                    objManejaProveedores.EliminaContactoProveedor(a);
                }

                foreach (var b in objProveedores.ListContactos)
                {
                    objManejaContactoProveedores.EliminaContactos(b.IntCodigo);
                    
                    foreach (var c in b.ListTelefonos)
                    {
                        objManejaContactoProveedores.EliminaContactoContactos(c);
                    }

                }

                
                MessageBox.Show("El Proveedor " + objProveedores.IntCodigo + "-" + objProveedores.StrRazonSocial + " ha sido eliminado correctamente");


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

            if ((String.IsNullOrEmpty(cboTipoDoc.Text)) || (String.IsNullOrEmpty(txtRazonSocial.Text)))
                return false;
            else
                return true;

        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetras(e);
        }

        private void btnContactos_Click(object sender, EventArgs e)
        {
            frmContactos objFrmContactos = new frmContactos(objProveedores.ListContactos, txtRazonSocial.Text);
            objFrmContactos.ShowDialog();
        }

        private void btnAltaServicio_Click(object sender, EventArgs e)
        {
            frmDiccionario objFrmDiccionario = new frmDiccionario("PRODUCTOS/SERVICIOS");
            objFrmDiccionario.ShowDialog();
            objCombosStandard.CargarDiccionario(cboServicio, "PRODUCTOS/SERVICIOS");
            cboServicio.SelectedValue = objFrmDiccionario.intCodigo;
        }

        private void cboServicio_Leave(object sender, EventArgs e)
        {

                int variable = 0;
                variable = cboServicio.FindStringExact(cboServicio.Text);
                if (variable == -1)//El servicio no esta dentro de la lista, debo obligarlo a cargar
                {
                    string message = "El servicio no existe o fue eliminado ¿Desea Cargar el Servicio?";
                    string caption = "Servicio Inexistente";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {

                        frmDiccionario objFrmDiccionario = new frmDiccionario("PRODUCTOS/SERVICIOS", cboServicio.Text, false);
                        objFrmDiccionario.ShowDialog();
                        
                        objCombosStandard.CargarDiccionario(cboServicio, "PRODUCTOS/SERVICIOS");
                        cboServicio.SelectedValue = objFrmDiccionario.intCodigo;

                    }
                    else
                    {
                        cboServicio.Text = "";
                    }
                }
            
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            string strPermiso = frmLogin.getPermiso("PROVEEDORES", "PROVEEDORES_NUEVO");

            if (strPermiso == "LECTURA")
            {
                btnAceptar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

    }
}
