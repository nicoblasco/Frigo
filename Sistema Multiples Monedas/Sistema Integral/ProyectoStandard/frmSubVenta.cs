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
    public partial class frmSubVenta : Form
    {
        CombosStandard objCombosStandard;
        Ventas objVentas;
        SubVentaTarjeta objSubVentasTarjeta;
        SubVentaCheque objSubVentaCheque;        

        public frmSubVenta(Ventas objVentas)
        {
            InitializeComponent();
            this.objVentas = objVentas;           
            Cargo_Combos();
            CargoDatosConObjeto();

            if (objVentas.IntCodigo != 0)
            {
                
                if (objVentas.StrEstado != "PENDIENTE")
                    HabilitoDesabilitoCampos(false);
                else
                    HabilitoDesabilitoCampos(true);

            }
          /*  else
                //CargoDatosConPantallaAnterior();
                CargoDatosConObjeto();*/


            tabControl1_Leave(null, null);
            
            Subtotales();
            SeteoCampos();
            AsignoDatosAlObjetoVentas();


        }

        private void HabilitoDesabilitoCampos(Boolean booRes)
        {
            txtEfectivoAbona.Enabled = booRes;
            txtEfectivoVuelto.Enabled = booRes;
            btnAceptar.Enabled = booRes;
            txtTarjetaAbona.Enabled = booRes;
            cboTarjeta.Enabled = booRes;
            btnAltaTarjeta.Enabled = booRes;
            txtTarjetaNumero.Enabled = booRes;
            txtTarjetaCuotas.Enabled = booRes;
            txtChequeAbona.Enabled = booRes;
            cboChequeBanco.Enabled = booRes;
            btnAltaCheque.Enabled = booRes;
            txtChequeNumero.Enabled = booRes;
            dtpFechaVencimiento.Enabled = booRes;
            txtCtaCteACuenta.Enabled = booRes;
            txtCtaCteMontoTotal.Enabled = booRes;
            cboTarjetaTipo.Enabled = booRes;
        }

        private void SeteoCampos()
        {
            txtCtaCteACuenta.Enabled = false;
            txtCtaCteMontoTotal.Enabled = false;
            txtSubTotal.Enabled = false;
            dtpFechaVencimiento.Value = DateTime.Now;
            txtTarjetaAbona_Leave(null, null);
            txtChequeAbona_Leave(null, null);
            btnQuitarTarjeta.Enabled = false;
            btnQuitarCheque.Enabled = false;
        }

        private void Cargo_Combos()
        {
            objCombosStandard = new CombosStandard();
            objCombosStandard.CargarDiccionario(cboChequeBanco, "BANCO/CHEQUE");
            objCombosStandard.CargarDiccionario(cboTarjeta, "TARJETA");
        }

        private void tabControl1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtChequeAbona.Text))
                txtChequeAbona.Text = Convert.ToString (Redondeo( Convert.ToDecimal("0")));

            if (string.IsNullOrEmpty(txtTarjetaAbona.Text))
                txtTarjetaAbona.Text = Convert.ToString (Redondeo( Convert.ToDecimal("0")));

            if (string.IsNullOrEmpty(txtEfectivoAbona.Text))
                txtEfectivoAbona.Text = Convert.ToString (Redondeo( Convert.ToDecimal("0")));

            if (string.IsNullOrEmpty(txtCtaCteACuenta.Text))
                txtCtaCteACuenta.Text = Convert.ToString (Redondeo(Convert.ToDecimal("0")));


            //txtCtaCteACuenta.Text = Convert.ToString(Convert.ToDecimal(txtTotal.Text)- (Convert.ToDecimal(txtEfectivoAbona.Text) + Convert.ToDecimal(txtTarjetaAbona.Text) + Convert.ToDecimal(txtChequeAbona.Text)));
            /*if (Convert.ToDecimal(txtCtaCteACuenta.Text) < 0)
                txtCtaCteACuenta.Text =Convert.ToString (Convert.ToDecimal("0"));*/

            //Cuando calculo el vuelto: Siempre que el total abonado de todos sea mayor al total y no sea el vuelto lo q se modifica y tenga algo cargado en efectivo
            if (TotalAbonado() > (Convert.ToDecimal(txtSubTotal.Text) + Convert.ToDecimal(txtEfectivoVuelto.Text)) && Convert.ToDecimal(txtEfectivoAbona.Text) > 0)
                txtEfectivoVuelto.Text = Convert.ToString(Vuelto());

            txtCtaCteACuenta.Text = Convert.ToString(Ctacte());
            Subtotales();
        }

        private decimal TotalAbonado()
        {

            return Redondeo(Convert.ToDecimal(txtEfectivoAbona.Text) + TotalTarjeta() + TotalCheque());
        }

        private decimal TotalTarjeta()
        {
            decimal total = 0;
            //Recorro las lista de tajeta y sumo el total abonado
            if (objVentas.ListSubVentaTarjeta == null)
                return total;


            foreach (var c in objVentas.ListSubVentaTarjeta)
            {
                total = total + c.DoAbona;

            }
            return Redondeo(total);

        }

        private decimal TotalCheque()
        {
            decimal total = 0;
            if (objVentas.ListSubVentaCheque == null)
                return total;

            foreach (var c in objVentas.ListSubVentaCheque)
            {
                total = total + c.DoAbona;
            }
            return Redondeo(total);
        }

        private decimal Vuelto()
        {
            decimal deDevuelvo;

            if (Convert.ToDecimal(txtEfectivoAbona.Text) == 0)
                return 0;

            //Como: La suma de los abonas menos el total, si el efectivo es menor de lo que se tiene que devolver el resto va a ctacte
            deDevuelvo = TotalAbonado() - Convert.ToDecimal(txtSubTotal.Text);

            //Si lo que tengo que devolver es mayor a lo que tengo en efectivo entonces pongo el efecivo en el vuelto y calculo la ctacte
            if (deDevuelvo > Convert.ToDecimal(txtEfectivoAbona.Text))
                return Redondeo( Convert.ToDecimal(txtEfectivoAbona.Text));
            else
                return Redondeo(deDevuelvo);

        }


        private void Subtotales()
        {
            
            lblSubTotalEfectivo.Text = txtEfectivoAbona.Text;
            lblSubTotalTarjeta.Text = Convert.ToString( TotalTarjeta() );

            lblSubTotalCheque.Text = Convert.ToString(TotalCheque());
            lblTotal.Text = Convert.ToString(Redondeo(Convert.ToDecimal(txtEfectivoAbona.Text) + TotalTarjeta() + TotalCheque() - Convert.ToDecimal(txtEfectivoVuelto.Text) - Ctacte()));

            lblSubtotalCtaCte.Text = txtCtaCteACuenta.Text;

            lblVuelto.Text = txtEfectivoVuelto.Text;
             

        }

        private decimal Ctacte()
        {
            return Redondeo((TotalAbonado() - Convert.ToDecimal(txtEfectivoVuelto.Text)) - Convert.ToDecimal(txtSubTotal.Text));
        }

        private void btnAltaCheque_Click(object sender, EventArgs e)
        {
            frmDiccionario objFrmDiccionario = new frmDiccionario("BANCO/CHEQUE");
            objFrmDiccionario.ShowDialog();
            objCombosStandard.CargarDiccionario(cboChequeBanco, "BANCO/CHEQUE");
            cboChequeBanco.SelectedValue = objFrmDiccionario.intCodigo;
        }

        private void btnAltaTarjeta_Click(object sender, EventArgs e)
        {
            frmDiccionario objFrmDiccionario = new frmDiccionario("TARJETA");
            objFrmDiccionario.ShowDialog();
            objCombosStandard.CargarDiccionario(cboTarjeta, "TARJETA");
            //devuelve la que selecciono
            cboTarjeta.SelectedValue = objFrmDiccionario.intCodigo;

        }

        private void Grabo()
        {
            AsignoDatosAlObjetoVentas();
            frmVentas objFrmVentas = new frmVentas();
            if (objVentas.IntCodigo > 0)
                objFrmVentas.Modifico(objVentas);
            else
            {
                objFrmVentas.Grabo(objVentas);                
            }


            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            objVentas.StrEstado = "CUMPLIDA";
            objVentas.DtFecha = DateTime.Now;
            Grabo();

        }


        private void AsignoDatosAlObjetoVentas()
        {

            objVentas.ObjSubVentaEfectivo.DoAbona = Redondeo(Convert.ToDecimal(txtEfectivoAbona.Text));
            objVentas.ObjSubVentaEfectivo.DoVuelto = Redondeo(Convert.ToDecimal(txtEfectivoVuelto.Text));
            /*objVentas.ObjSubVentaTarjeta.DoAbona = Convert.ToDecimal(txtTarjetaAbona.Text);
            objVentas.ObjSubVentaTarjeta.StrCuotas = txtTarjetaCuotas.Text;
            objVentas.ObjSubVentaTarjeta.StrNumero = txtTarjetaNumero.Text;
            objVentas.ObjSubVentaTarjeta.StrTarjeta = cboTarjeta.Text;
            objVentas.ObjSubVentaCheque.DoAbona = Convert.ToDecimal(txtChequeAbona.Text);
            objVentas.ObjSubVentaCheque.DtFechaVencimiento = dtpFechaVencimiento.Value;
            objVentas.ObjSubVentaCheque.StrBanco = cboChequeBanco.Text;
            objVentas.ObjSubVentaCheque.StrNumero = txtChequeNumero.Text;*/

            objVentas.ObjSubVentaACtaCte.doAcuenta = Redondeo(Convert.ToDecimal(txtCtaCteACuenta.Text));
            objVentas.DoTotal = Redondeo(Convert.ToDecimal(lblTotal.Text));

            
            /*Debo Cargar la grilla*/


        }

        private void CargoDatosConObjeto()
        {
            txtEfectivoAbona.Text = Convert.ToString(Redondeo(objVentas.ObjSubVentaEfectivo.DoAbona));
            txtEfectivoVuelto.Text = Convert.ToString(Redondeo (objVentas.ObjSubVentaEfectivo.DoVuelto));

            /*
             * Los list ya deberian estar cargados
             * txtTarjetaAbona.Text = Convert.ToString(objVentas.ObjSubVentaTarjeta.DoAbona);
            txtTarjetaCuotas.Text = objVentas.ObjSubVentaTarjeta.StrCuotas;
            txtTarjetaNumero.Text = objVentas.ObjSubVentaTarjeta.StrNumero;
            cboTarjeta.Text = objVentas.ObjSubVentaTarjeta.StrTarjeta;
            txtChequeAbona.Text = Convert.ToString(objVentas.ObjSubVentaCheque.DoAbona);
            dtpFechaVencimiento.Value = objVentas.ObjSubVentaCheque.DtFechaVencimiento;
            cboChequeBanco.Text = objVentas.ObjSubVentaCheque.StrBanco;
            txtChequeNumero.Text = objVentas.ObjSubVentaCheque.StrNumero;*/
            txtCtaCteACuenta.Text = Convert.ToString(Redondeo(objVentas.ObjSubVentaACtaCte.doAcuenta));
            txtSubTotal.Text = Convert.ToString(Redondeo(objVentas.DoSubtotal));            
            ManejaClientes objManejaClientes = new ManejaClientes();
            txtCtaCteMontoTotal.Text = Convert.ToString(Redondeo(objManejaClientes.CalcularDeudaCliente(objVentas.ObjCliente.IntCodigo)));
            CargoGrillaTarjeta();
            CargoGrillaCheque();

        }

        private void CargoDatosConPantallaAnterior()
        {
            txtSubTotal.Text = Convert.ToString(objVentas.DoSubtotal);
            txtSubTotal.Enabled = false;

            txtEfectivoAbona.Text = Convert.ToString(objVentas.DoSubtotal);
            txtEfectivoVuelto.Text = Convert.ToString(Convert.ToDecimal("0"));            

            txtTarjetaAbona.Text = Convert.ToString(Convert.ToDecimal("0"));
            txtChequeAbona.Text = Convert.ToString(Convert.ToDecimal("0"));
            txtCtaCteACuenta.Text = Convert.ToString(Convert.ToDecimal("0"));
            ManejaClientes objManejaClientes = new ManejaClientes();
            txtCtaCteMontoTotal.Text = Convert.ToString(Redondeo(objManejaClientes.CalcularDeudaCliente(objVentas.ObjCliente.IntCodigo)));
        }


        private void txtEfectivoAbona_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetrasPerosiNumerosconUnPunto(sender, e);
        }

        private void txtTarjetaNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacionesStandard objValidacionesStandard = new ValidacionesStandard();
            objValidacionesStandard.NoAdmiteLetras(e);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            //Tengo q asignar y volver
            AsignoDatosAlObjetoVentas();
            this.Close();

        }

        private void txtEfectivoVuelto_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEfectivoVuelto.Text))
                txtEfectivoVuelto.Text = "0";

           txtCtaCteACuenta.Text= Convert.ToString( Ctacte());

           Subtotales();

        }



        private void cboTarjeta_Leave(object sender, EventArgs e)
        {
            //Esto significa si hizo click en el boton de buscar

                int variable = 0;
                variable = cboTarjeta.FindStringExact(cboTarjeta.Text);
                if (variable == -1 && (!string.IsNullOrEmpty(cboTarjeta.Text)))//La tarjeta no esta dentro de la lista, debo obligarlo a cargar
                {
                    string message = "¿Desea Cargar la Tarjeta?";
                    string caption = "Tarjeta Inexistente";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {

                        frmDiccionario objFrmDiccionario = new frmDiccionario("TARJETA", cboTarjeta.Text, false);
                        objFrmDiccionario.ShowDialog();
                        objCombosStandard.CargarDiccionario(cboTarjeta, "TARJETA");
                        cboTarjeta.SelectedValue = objFrmDiccionario.intCodigo;


                    }
                    else
                    {
                        cboTarjeta.Text = "";
                    }
                }
            
        }

        private void cboChequeBanco_Leave(object sender, EventArgs e)
        {
            //Esto significa si hizo click en el boton de buscar

            int variable = 0;
            variable = cboChequeBanco.FindStringExact(cboChequeBanco.Text);
            if (variable == -1 && (!string.IsNullOrEmpty(cboChequeBanco.Text)))//La tarjeta no esta dentro de la lista, debo obligarlo a cargar
            {
                string message = "¿Desea Cargar el Banco?";
                string caption = "Banco Inexistente";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    frmDiccionario objFrmDiccionario = new frmDiccionario("BANCO/CHEQUE", cboChequeBanco.Text, false);

                    objFrmDiccionario.ShowDialog();
                    objCombosStandard.CargarDiccionario(cboChequeBanco, "BANCO/CHEQUE");
                    cboChequeBanco.SelectedValue = objFrmDiccionario.intCodigo;


                }
                else
                {
                    cboChequeBanco.Text = "";
                }
            }
        }

        private bool ValidoTarjeta()
        {


            //si pago con tarjeta
            if (!string.IsNullOrEmpty(txtTarjetaAbona.Text))
            {
                if (Convert.ToDecimal(txtTarjetaAbona.Text) != 0)
                {
                    if (string.IsNullOrEmpty(cboTarjeta.Text))
                    {
                        MessageBox.Show("Debe cargar la Tarjeta para continuar");
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtTarjetaCuotas.Text))
                    {
                        MessageBox.Show("Debe cargar las cuotas para continuar");
                        return false;
                    }
                }

            }
            return true;

        }

        private bool ValidoCheque()
        {


            //si pago con cheque
            if (!string.IsNullOrEmpty(txtChequeAbona.Text))
            {
                if (Convert.ToDecimal(txtChequeAbona.Text) != 0)
                {
                    if (string.IsNullOrEmpty(cboChequeBanco.Text))
                    {
                        MessageBox.Show("Debe cargar el Banco para continuar");
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtChequeNumero.Text))
                    {
                        MessageBox.Show("Debe cargar el número de cheque para continuar");
                        return false;
                    }
                }
            }
            return true;

        }

        private void btnAgregarTarjeta_Click(object sender, EventArgs e)
        {

            if (!ValidoTarjeta())
                return;
            if (objSubVentasTarjeta == null)
            {
                objSubVentasTarjeta = new SubVentaTarjeta();
                objSubVentasTarjeta.DoAbona = Redondeo( Convert.ToDecimal(txtTarjetaAbona.Text));
                objSubVentasTarjeta.StrTarjeta = cboTarjeta.Text;
                objSubVentasTarjeta.StrTipo = cboTarjetaTipo.Text;
                objSubVentasTarjeta.StrNumero = txtTarjetaNumero.Text;
                objSubVentasTarjeta.StrCuotas = txtTarjetaCuotas.Text;
                this.objVentas.ListSubVentaTarjeta.Add(objSubVentasTarjeta);
            }
            else
            {
                objSubVentasTarjeta.DoAbona = Redondeo(Convert.ToDecimal(txtTarjetaAbona.Text));
                objSubVentasTarjeta.StrTarjeta = cboTarjeta.Text;
                objSubVentasTarjeta.StrTipo = cboTarjetaTipo.Text;
                objSubVentasTarjeta.StrNumero = txtTarjetaNumero.Text;
                objSubVentasTarjeta.StrCuotas = txtTarjetaCuotas.Text;
                
                this.objVentas.ListSubVentaTarjeta.ElementAt(objSubVentasTarjeta.IntIndex).DoAbona = objSubVentasTarjeta.DoAbona;
                this.objVentas.ListSubVentaTarjeta.ElementAt(objSubVentasTarjeta.IntIndex).StrTarjeta = objSubVentasTarjeta.StrTarjeta;
                this.objVentas.ListSubVentaTarjeta.ElementAt(objSubVentasTarjeta.IntIndex).StrTipo = objSubVentasTarjeta.StrTipo;
                this.objVentas.ListSubVentaTarjeta.ElementAt(objSubVentasTarjeta.IntIndex).StrNumero = objSubVentasTarjeta.StrNumero;
                this.objVentas.ListSubVentaTarjeta.ElementAt(objSubVentasTarjeta.IntIndex).StrCuotas = objSubVentasTarjeta.StrCuotas;

            }

            CargoGrillaTarjeta();

            LimpiarTarjeta();
            objSubVentasTarjeta = null;

            tabControl1_Leave(null, null);
            
        }

        private void btnAgregarCheque_Click(object sender, EventArgs e)
        {
            if (!ValidoCheque())
                return ;

            //Lo primero que debo hacer es guardar el objeto articulo en la lista
            if (objSubVentaCheque == null)
            {
                objSubVentaCheque = new SubVentaCheque();

                objSubVentaCheque.DoAbona = Redondeo(Convert.ToDecimal(txtChequeAbona.Text));
                objSubVentaCheque.DtFechaVencimiento = Convert.ToDateTime(dtpFechaVencimiento.Text);
                objSubVentaCheque.StrBanco = cboChequeBanco.Text;
                objSubVentaCheque.StrNumero = txtChequeNumero.Text;

                //Actualizo la lista o lo agrego

                this.objVentas.ListSubVentaCheque.Add(objSubVentaCheque);
            }
            else
            {

                objSubVentaCheque.DoAbona = Redondeo(Convert.ToDecimal(txtChequeAbona.Text));
                objSubVentaCheque.DtFechaVencimiento = Convert.ToDateTime(dtpFechaVencimiento.Text);
                objSubVentaCheque.StrBanco = cboChequeBanco.Text;
                objSubVentaCheque.StrNumero = txtChequeNumero.Text;

                this.objVentas.ListSubVentaCheque.ElementAt(objSubVentaCheque.IntIndex).DoAbona = objSubVentaCheque.DoAbona;
                this.objVentas.ListSubVentaCheque.ElementAt(objSubVentaCheque.IntIndex).StrBanco = objSubVentaCheque.StrBanco;
                this.objVentas.ListSubVentaCheque.ElementAt(objSubVentaCheque.IntIndex).StrNumero = objSubVentaCheque.StrNumero;
                this.objVentas.ListSubVentaCheque.ElementAt(objSubVentaCheque.IntIndex).DtFechaVencimiento = objSubVentaCheque.DtFechaVencimiento;
                
            }

            CargoGrillaCheque();


            CargoGrillaTarjeta();

            LimpiarCheque();
            objSubVentaCheque = null;

            tabControl1_Leave(null, null);
        }

        private void LimpiarTarjeta()
        {
            txtTarjetaAbona.Text="";
            cboTarjeta.Text="";
            cboTarjetaTipo.Text="";
            txtTarjetaNumero.Text="";
            txtTarjetaCuotas.Text = "";

        }


        private void CargoGrillaTarjeta()
        {
            int i = 0;
            grillaTarjetas.DataSource = null;
            grillaTarjetas.Rows.Clear();
            CargoTituloGrillaTarjeta();
            if (this.objVentas.ListSubVentaTarjeta != null)
            {

                foreach (SubVentaTarjeta element in objVentas.ListSubVentaTarjeta)
                {
                    /* if (element.IntEstado != 3)
                     {*/
                    grillaTarjetas.Rows.Add();
                    grillaTarjetas[0, i].Value = Redondeo(element.DoAbona);
                    grillaTarjetas[1, i].Value = element.StrTarjeta;
                    grillaTarjetas[2, i].Value = element.StrTipo;
                    grillaTarjetas[3, i].Value = element.StrNumero;
                    grillaTarjetas[4, i].Value = element.StrCuotas;

                    i++;



                }


            }
        }

        private void CargoTituloGrillaTarjeta()
        {
            //            if (list.Count != 0)
            if (this.objVentas.ListSubVentaTarjeta != null)
            {
                grillaTarjetas.DataSource = null;
                grillaTarjetas.Rows.Clear();
                grillaTarjetas.Columns.Clear();
                grillaTarjetas.Columns.Add("Abona", null);
                grillaTarjetas.Columns.Add("Tarjeta", null);
                grillaTarjetas.Columns.Add("Tipo", null);
                grillaTarjetas.Columns.Add("Numero", null);
                grillaTarjetas.Columns.Add("Cuotas", null);

            }
        }


        private void CargoGrillaCheque()
        {
            int i = 0;
            grillaCheques.DataSource = null;
            grillaCheques.Rows.Clear();
            CargoTituloGrillaCheque();
            if (this.objVentas.ListSubVentaCheque != null)
            {

                foreach (SubVentaCheque element in objVentas.ListSubVentaCheque)
                {
                    /* if (element.IntEstado != 3)
                     {*/
                    grillaCheques.Rows.Add();
                    grillaCheques[0, i].Value = Redondeo(element.DoAbona);
                    grillaCheques[1, i].Value = element.StrBanco;
                    grillaCheques[2, i].Value = element.StrNumero;
                    grillaCheques[3, i].Value = element.DtFechaVencimiento;

                    i++;



                }


            }
        }

        private void CargoTituloGrillaCheque()
        {
            //            if (list.Count != 0)
            if (this.objVentas.ListSubVentaCheque != null)
            {
                grillaCheques.DataSource = null;
                grillaCheques.Rows.Clear();
                grillaCheques.Columns.Clear();
                grillaCheques.Columns.Add("Abona", null);
                grillaCheques.Columns.Add("Banco", null);
                grillaCheques.Columns.Add("Numero", null);
                grillaCheques.Columns.Add("Fec.Venc", null);


            }
        }

        private void btnQuitarTarjeta_Click(object sender, EventArgs e)
        {
            if (this.objVentas.ListSubVentaTarjeta.ElementAt(grillaTarjetas.CurrentRow.Index).IntCodigo > 0)
                objVentas.ListTarjetasBorradas.Add(this.objVentas.ListSubVentaTarjeta.ElementAt(objSubVentasTarjeta.IntIndex));


            //Luego lo borro de la lista y al momento de grabar lo borro de todos lados
            this.objVentas.ListSubVentaTarjeta.RemoveAt(objSubVentasTarjeta.IntIndex);
            grillaTarjetas.Rows.RemoveAt(objSubVentasTarjeta.IntIndex);            
            btnQuitarTarjeta.Enabled = false;
            tabControl1_Leave(null, null);
            LimpiarTarjeta();
            objSubVentasTarjeta = null;
        }



        private void LimpiarCheque()
        {
            txtChequeAbona.Text = "";
            txtChequeNumero.Text = "";
            cboChequeBanco.Text = "";
            dtpFechaVencimiento.Value = DateTime.Now;
        }

        private void btnQuitarCheque_Click(object sender, EventArgs e)
        {
            if (this.objVentas.ListSubVentaCheque.ElementAt(objSubVentaCheque.IntIndex).IntCodigo > 0)
                objVentas.ListChequesBorrados.Add(this.objVentas.ListSubVentaCheque.ElementAt(objSubVentaCheque.IntIndex));


            //Luego lo borro de la lista y al momento de grabar lo borro de todos lados
            this.objVentas.ListSubVentaCheque.RemoveAt(objSubVentaCheque.IntIndex);
            grillaCheques.Rows.RemoveAt(objSubVentaCheque.IntIndex);
            btnQuitarCheque.Enabled = false;
            tabControl1_Leave(null, null);
            LimpiarCheque();
            objSubVentaCheque = null;
        }

        private void txtTarjetaAbona_Leave(object sender, EventArgs e)
        {
            //Habilito o desabilito el boton depende si tiene algo cargado
            if (string.IsNullOrEmpty(txtTarjetaAbona.Text))
                txtTarjetaAbona.Text = "0";

            if (Convert.ToDecimal(txtTarjetaAbona.Text) > 0)
                btnAgregarTarjeta.Enabled = true;
            else
                btnAgregarTarjeta.Enabled = false;


        }

        private void txtChequeAbona_Leave(object sender, EventArgs e)
        {
            //Habilito o desabilito el boton depende si tiene algo cargado
            if (string.IsNullOrEmpty(txtChequeAbona.Text))
                txtChequeAbona.Text = "0";

            if (Convert.ToDecimal(txtChequeAbona.Text) > 0)
                btnAgregarCheque.Enabled = true;
            else
                btnAgregarCheque.Enabled = false;
        }



        private void grillaTarjetas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (objVentas.StrEstado == "PENDIENTE" || string.IsNullOrEmpty(objVentas.StrEstado))
            {
                objSubVentasTarjeta = new SubVentaTarjeta();

                txtTarjetaAbona.Text = Convert.ToString(grillaTarjetas.Rows[grillaTarjetas.CurrentRow.Index].Cells[0].Value.ToString());
                cboTarjeta.Text = Convert.ToString(grillaTarjetas.Rows[grillaTarjetas.CurrentRow.Index].Cells[1].Value.ToString());
                cboTarjetaTipo.Text = Convert.ToString(grillaTarjetas.Rows[grillaTarjetas.CurrentRow.Index].Cells[2].Value.ToString());
                txtTarjetaNumero.Text = Convert.ToString(grillaTarjetas.Rows[grillaTarjetas.CurrentRow.Index].Cells[3].Value.ToString());
                txtTarjetaCuotas.Text = Convert.ToString(grillaTarjetas.Rows[grillaTarjetas.CurrentRow.Index].Cells[4].Value.ToString());
                

                //Aca deberia habilitar el boton de borrado
                btnQuitarTarjeta.Enabled = true;
                btnAgregarTarjeta.Enabled = true;

                objSubVentasTarjeta.DoAbona= Redondeo(Convert.ToDecimal(txtTarjetaAbona.Text));
                objSubVentasTarjeta.StrTarjeta = cboTarjeta.Text;
                objSubVentasTarjeta.StrTipo = cboTarjetaTipo.Text;
                objSubVentasTarjeta.StrNumero = txtTarjetaNumero.Text;
                objSubVentasTarjeta.StrCuotas = txtTarjetaCuotas.Text;
                objSubVentasTarjeta.IntIndex = Convert.ToInt32(grillaTarjetas.CurrentRow.Index);
                

            }
        }

        private void grillaCheques_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (objVentas.StrEstado == "PENDIENTE" || string.IsNullOrEmpty(objVentas.StrEstado))
            {
                objSubVentaCheque = new SubVentaCheque();

                txtChequeAbona.Text = Convert.ToString(grillaCheques.Rows[grillaCheques.CurrentRow.Index].Cells[0].Value.ToString());
                cboChequeBanco.Text = Convert.ToString(grillaCheques.Rows[grillaCheques.CurrentRow.Index].Cells[1].Value.ToString());
                txtChequeNumero.Text = Convert.ToString(grillaCheques.Rows[grillaCheques.CurrentRow.Index].Cells[2].Value.ToString());
                dtpFechaVencimiento.Value = Convert.ToDateTime(grillaCheques.Rows[grillaCheques.CurrentRow.Index].Cells[3].Value.ToString());

                //Aca deberia habilitar el boton de borrado
                btnQuitarCheque.Enabled = true;
                btnAgregarCheque.Enabled = true;

                objSubVentaCheque.DoAbona = Redondeo(Convert.ToDecimal(txtChequeAbona.Text));
                objSubVentaCheque.StrBanco = cboChequeBanco.Text;
                objSubVentaCheque.StrNumero = txtChequeNumero.Text;
                objSubVentaCheque.DtFechaVencimiento = dtpFechaVencimiento.Value;

                objSubVentaCheque.IntIndex = Convert.ToInt32(grillaCheques.CurrentRow.Index);
            }
        }

        private decimal Redondeo(decimal deVariable)
        {
            return decimal.Round(deVariable, 2, MidpointRounding.AwayFromZero);
        }

        private string Convertir (string strVariable)
        {
           return strVariable.Replace('.', ',');
        }

        

    }
}
