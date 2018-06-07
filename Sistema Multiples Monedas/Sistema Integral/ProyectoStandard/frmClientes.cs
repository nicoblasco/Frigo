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
    public partial class frmClientes : Form
    {
        CombosStandard objCombosStandard;
        Clientes objClientes;
        ManejaClientes objManejoClientes;
        List<Telefonos> listTelefonos;
        bool boOtraPantalla;
        public int intCodigoCliente;
        decimal deDebe=0;



        public frmClientes()
        {
            InitializeComponent();
            //Cargo los combos
            CargarCombosTodos();

            //Creo los objetos
            objClientes = new Clientes();
            objClientes.ListTelefonos = new List<Telefonos>();

            //Desabilito el boton de eliminar
            btnEliminar.Enabled = false;
            dtpFechaIngreso.Value = DateTime.Now;
        }


        public frmClientes(Clientes objClientes)
        {
            InitializeComponent();
            CargarCombosTodos();
            this.objClientes = objClientes;
            listTelefonos = objClientes.ListTelefonos;
            AsignoCamposConObjetos();
            btnEliminar.Enabled = true;
            this.Text = "Cliente: " + Convert.ToString(objClientes.IntCodigo) + " "+ txtNombre.Text +" " +txtApellido.Text  ;
            boOtraPantalla = true;
            btnPagar.Visible = true;
            lblMensajeCtaCte.Visible = true;

            if (!string.IsNullOrEmpty(objClientes.DtFechaBaja))
                HabilitaDesabilitaCampos(false);

        }

        private void HabilitaDesabilitaCampos(bool boRes)
        {
            groupBox1.Enabled = boRes;
            btnAceptar.Enabled = boRes;
            btnEliminar.Enabled = boRes;
        }



        public frmClientes(string strCliente)
        {
            InitializeComponent();
            CargarCombosTodos();
            objClientes = new Clientes();
            objClientes.ListTelefonos = new List<Telefonos>();            
            txtNombre.Text = strCliente;
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
            frmTelefonos objfrmTelefonos = new frmTelefonos(objClientes.ListTelefonos);

            objfrmTelefonos.ShowDialog();
        }


        private void AsignoDatosAlObjeto()
        {
            objClientes.IntLocalidad = Convert.ToInt32(cboLocalidad.SelectedValue);
            objClientes.IntPais = Convert.ToInt32(cboPais.SelectedValue);
            objClientes.IntProvincia = Convert.ToInt32(cboProvincia.SelectedValue);
            objClientes.IntDocumento = Convert.ToInt32(cboTipoDoc.SelectedValue);
            objClientes.StrDocumento = txtDni.Text;
            objClientes.StrNombre = txtNombre.Text.ToUpper();
            objClientes.StrApellido = txtApellido.Text.ToUpper();
            objClientes.DtFechadeIngreso = Convert.ToDateTime(dtpFechaIngreso.Text);
            objClientes.DtFechadeNac = Convert.ToDateTime(dtpFechaNac.Text);
            objClientes.StrDepto = txtDepto.Text.ToUpper();
            objClientes.StrDirecccion = txtDireccion.Text.ToUpper();
            objClientes.StrEmail = txtEmail.Text;
            objClientes.StrNro = txtNro.Text.ToUpper();
            objClientes.StrPiso = txtPiso.Text.ToUpper();
            objClientes.BoPredeterminado = ckPredeterminado.Checked;
        }

        private void AsignoCamposConObjetos()
        {
            lblLegajo.Text = Convert.ToString(objClientes.IntCodigo);
            cboLocalidad.SelectedValue = objClientes.IntLocalidad;
            cboPais.SelectedValue = objClientes.IntPais;
            cboProvincia.SelectedValue = objClientes.IntProvincia;
            txtDepto.Text = objClientes.StrDepto;
            txtDireccion.Text = objClientes.StrDirecccion;
            txtEmail.Text = objClientes.StrEmail;
            txtNro.Text = objClientes.StrNro;
            txtPiso.Text = objClientes.StrPiso;
            cboTipoDoc.SelectedValue = objClientes.IntDocumento;
            txtDni.Text = objClientes.StrDocumento;
            txtNombre.Text = objClientes.StrNombre;
            txtApellido.Text = objClientes.StrApellido;
            dtpFechaIngreso.Value = objClientes.DtFechadeIngreso;
            dtpFechaNac.Value = objClientes.DtFechadeNac;
            ckPredeterminado.Checked = objClientes.BoPredeterminado;

        }

        private void LimpioCampos()
        {
            lblLegajo.Text = "";
            cboLocalidad.Text = "FLORENCIO VARELA";
            cboPais.Text = "ARGENTINA";
            cboProvincia.Text = "AMBA";
            txtDepto.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtNro.Text = "";
            txtPiso.Text = "";
            cboTipoDoc.Text = "";
            txtDni.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            dtpFechaIngreso.Value = DateTime.Now;
            dtpFechaNac.Text = "01/01/1985";
            objClientes = null;
            objClientes = new Clientes();
            objClientes.ListTelefonos = new List<Telefonos>();
            btnEliminar.Enabled = false;
            objClientes.BoPredeterminado = false;
            ckPredeterminado.Checked = false;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!VerificoCamposAntesDeGrabar())
            {
                MessageBox.Show("Campos Obligatorios Incompletos");
                return;
            }

            if (objClientes.IntCodigo != 0)
            {
                Modifico();
                
                MessageBox.Show("El Cliente " + objClientes.IntCodigo + "-" + objClientes.StrApellido + " " + objClientes.StrNombre + " ha sido modificado correctamente");
            }
            else
            {
                Grabo();
                MessageBox.Show("El Cliente " + objClientes.IntCodigo + "-" + objClientes.StrApellido + " " + objClientes.StrNombre + " ha sido grabado correctamente");
            }


            if (boOtraPantalla)
            {
                intCodigoCliente = objClientes.IntCodigo;
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
            objManejoClientes = new ManejaClientes();
            objClientes.IntCodigo = objManejoClientes.GrabarClientes(objClientes);
            foreach (var c in objClientes.ListTelefonos)
            {

                objManejoClientes.GrabarContactoCliente(c, objClientes.IntCodigo);

            }
        }

        private void Modifico()
        {
            AsignoDatosAlObjeto();
            ManejaClientes objManejoClientes = new ManejaClientes();
            objManejoClientes.ModificaClientes(objClientes);//Actualizo el Cliente
            //Modifico los telefonos del personal
            foreach (var a in objClientes.ListTelefonos)
            {
                objManejoClientes.VerificaModificacionContactoCliente(a, objClientes.IntCodigo);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string message;
            string caption = "Mensaje";
            //Primero me tengo que fijar si el cliente tiene alguna Carta de Porte asociada
            ManejaClientes objManejaClientes = new ManejaClientes();
            message = "Desea Eliminar el Cliente";


            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Si me dice que si, lo elimino

                objManejaClientes.EliminaCliente(objClientes.IntCodigo);
                foreach (var a in objClientes.ListTelefonos)
                {
                    objManejaClientes.EliminaContactoCliente(a);
                }
                MessageBox.Show("El Cliente " + objClientes.IntCodigo + "-" + objClientes.StrApellido + " " + objClientes.StrNombre + " ha sido eliminado correctamente");
                
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

            if ( (String.IsNullOrEmpty(txtNombre.Text)) )
                return false;
            else
                return true;

        }
        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetras(e);
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {

            string strPermiso= frmLogin.getPermiso("CLIENTES", "CLIENTES_NUEVO");
            ManejaClientes objManejoClientes = new ManejaClientes();
            
            //Calcula Deuda del cliente
            if (objClientes.IntCodigo != 0)
            {
                deDebe = objManejoClientes.CalcularDeudaCliente(objClientes.IntCodigo);
                if (deDebe > 0)
                {
                    lblMensajeCtaCte.Text = "El CLIENTE POSEE DEUDA";
                    btnPagar.Enabled = true;
                }
                else
                {
                    btnPagar.Enabled = false;
                }
            }

            if (strPermiso == "LECTURA")
            {
                btnAceptar.Enabled = false;
                btnEliminar.Enabled = false;
                btnPagar.Enabled = false;
            }

            

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            frmClienteCtaCte objfrmClienteCtaCte = new frmClienteCtaCte(objClientes.IntCodigo, deDebe);
            objfrmClienteCtaCte.ShowDialog();

            ManejaClientes objManejoClientes = new ManejaClientes();
            deDebe = objManejoClientes.CalcularDeudaCliente(objClientes.IntCodigo);
            if (deDebe > 0)
            {
                lblMensajeCtaCte.Text = "El CLIENTE POSEE DEUDA";
                btnPagar.Enabled = true;
            }
            else
            {
                lblMensajeCtaCte.Text = "El Cliente no posee deuda";
                btnPagar.Enabled = false;
            }
        }
    }
}
