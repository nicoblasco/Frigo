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
    public partial class frmUsuariosPerfiles : Form
    {
        CombosStandard objCombosStandard;
        ManejaPerfiles objManejaPerfiles;
        Perfiles objPerfiles;

        public frmUsuariosPerfiles()
        {
            InitializeComponent();
            CargoCombos();
            objPerfiles = new Perfiles();
        }
        private void CargoCombos()
        {
            objCombosStandard = new CombosStandard();
            objCombosStandard.CargarUsuarios(cboUsuarios);
            //objCombosStandard.CargarDiccionario(cboModulo, "MODULOS");
            //cboModulo.Text = "TODOS";

        }

        //private void cboModulo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    objCombosStandard.CargarDiccionarioValor2(cboPantalla, "PANTALLAS", cboModulo.Text);
        //}

        private void Limpiar()
        {
            cboUsuarios.SelectedIndex = -1;
           // cboModulo.SelectedIndex = -1;
            //cboModulo.Text = "TODOS";
            //cboPantalla.SelectedIndex = -1;
            //cboPermiso.SelectedIndex = -1;
            CargoGrilla(null);
            objPerfiles = new Perfiles();
        }

        private bool Valido()
        {
            if (cboUsuarios.Text == "")
            {
                MessageBox.Show("Debe seleccionar un Usuario");
                return true;
            }
            //if (cboModulo.Text == "")
            //{
            //    MessageBox.Show("Debe seleccionar un Modulo");
            //    return true;
            //}
            //if (cboPantalla.Text == "")
            //{
            //    MessageBox.Show("Debe seleccionar una Pantalla");
            //    return true;
            //}
            //if (cboPermiso.Text == "")
            //{
            //    MessageBox.Show("Debe seleccionar un tipo de Permiso");
            //    return true;
            //}
            return false;
        }
        private void HabilitaDesabilitaCampos(bool boRes)
        {
            grbFiltros.Enabled = boRes;
            //btnAceptar.Enabled = boRes;
            //btnEliminar.Enabled = boRes;
        }

        private void AsignoDatosAlObjeto()
        {
            objPerfiles.IntUsuario = Convert.ToInt32(cboUsuarios.SelectedValue);
            //objPerfiles.StrModulo = cboModulo.Text;
            //objPerfiles.StrPantalla = cboPantalla.Text;
            //objPerfiles.StrPermiso = cboPermiso.Text;

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Valido())
                return;
            
            if (objPerfiles.IntCodigo != 0)
            {
                Modifico();

                
            }
            else
            {
                Grabo();
                
            }
            Limpiar();
            CargoGrilla(null);
        }

        private void Grabo()
        {            
            AsignoDatosAlObjeto();
            objManejaPerfiles = new ManejaPerfiles();
            //En la grabacion valido que no exista el Perfil para el usuario

            if (objManejaPerfiles.ExistePerfil(objPerfiles.IntUsuario, objPerfiles.StrModulo, objPerfiles.StrPantalla))
            {
                string message;
                string caption = "Mensaje";
                message = "Ya existe combinaciones para el perfil que esta creando, desea Eliminar la existente para crear la nueva? De lo contrario seleccionela de la grilla para modificarla o eliminarla";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    objManejaPerfiles.EliminaPerfil(objPerfiles.IntUsuario, objPerfiles.StrModulo, objPerfiles.StrPantalla);
                }
                else
                {
                    return;
                }

                if (objPerfiles.StrPantalla == "TODAS")
                {
                    DataTable dt = objManejaPerfiles.obtenerTodasLasPanallas(objPerfiles.StrModulo, objPerfiles.StrPantalla);
                    if (dt != null)
                    {
                        for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                        {
                            objPerfiles.StrModulo = dt.Rows[i]["cc_valor1"].ToString();
                            objPerfiles.StrPantalla = dt.Rows[i]["cc_valor2"].ToString();
                            objPerfiles.IntCodigo = objManejaPerfiles.GrabarPerfiles(objPerfiles);
                        }
                    }
                }
                else
                {
                    objPerfiles.IntCodigo = objManejaPerfiles.GrabarPerfiles(objPerfiles);
                }
            }
            else
            {
                if (objPerfiles.StrPantalla == "TODAS")
                {
                    DataTable dt = objManejaPerfiles.obtenerTodasLasPanallas(objPerfiles.StrModulo, objPerfiles.StrPantalla);
                    if (dt != null)
                    {
                        for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                        {
                            objPerfiles.StrModulo = dt.Rows[i]["cc_valor1"].ToString();
                            objPerfiles.StrPantalla = dt.Rows[i]["cc_valor2"].ToString();
                            objPerfiles.IntCodigo = objManejaPerfiles.GrabarPerfiles(objPerfiles);
                        }
                    }
                }
                else
                {
                    objPerfiles.IntCodigo = objManejaPerfiles.GrabarPerfiles(objPerfiles);
                }
            }
            MessageBox.Show("Se han asiganado Perfiles para el usuario " + cboUsuarios.Text);
        }
        private void Modifico()
        {
            AsignoDatosAlObjeto();
            objManejaPerfiles = new ManejaPerfiles();

            //Si selecciona TODOS o TODAS, borro lo que tenia
            if (objPerfiles.StrPantalla == "TODAS")
            {
                objManejaPerfiles.EliminaPerfil(objPerfiles.IntUsuario, objPerfiles.StrModulo, objPerfiles.StrPantalla);
                //Luego lo creo
                DataTable dt= objManejaPerfiles.obtenerTodasLasPanallas(objPerfiles.StrModulo, objPerfiles.StrPantalla);
                if (dt != null)
                {
                    for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                    {
                        objPerfiles.StrModulo = dt.Rows[i]["cc_valor1"].ToString();
                        objPerfiles.StrPantalla = dt.Rows[i]["cc_valor2"].ToString();
                        objPerfiles.IntCodigo = objManejaPerfiles.GrabarPerfiles(objPerfiles);
                    }
                }
            }
            else
            {
                objManejaPerfiles.ModificarPerfiles(objPerfiles);
            }
            MessageBox.Show("Se han modificado Perfiles para el usuario " + cboUsuarios.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string message;
            string caption = "Mensaje";

            if (objPerfiles == null)
            {
                //Limpio los campos, sino es una eliminacion
                Limpiar();
                return;
            }
            if (objPerfiles.IntCodigo == 0)
            {
                //Limpio los campos, sino es una eliminacion
                Limpiar();
                return;
            }

            ManejaPerfiles objManejaPerfiles = new ManejaPerfiles();
            message = "Desea Eliminar el Perfil";


            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Si me dice que si, lo elimino
                objManejaPerfiles.EliminaPerfil(objPerfiles.IntCodigo);

                MessageBox.Show("Se han eliminado perfiles para el Usuario");

                Limpiar();


            }
        }

        private void CargoGrilla(string strParamAdicional)
        {
            gridPerfiles.DataSource = null;
            string strSql;

            //strSql = "select t1.id, t1.usuarioid, (select usuario from Usuarios t2 where t2.id=t1.usuarioid ) as usuario, modulo, pantalla, permiso ";
            //strSql += " from Perfiles t1 ";
            //if (!string.IsNullOrEmpty(strParamAdicional))
            //    strSql += " where t1.usuarioid = " + strParamAdicional;
            //strSql += " order by  3,4,5,6";


            strSql = "select u.id, u.usuario, u.nombre_apellido, d.cc_valor1, d.cc_valor2, ";
            strSql += " isnull((select 1 from Perfiles p where p.usuarioid=u.id and p.modulo = d.cc_valor1 and p.pantalla = d.cc_valor2 and p.permiso ='LECTURA'),0) as lectura,";
            strSql += " isnull((select 1 from Perfiles p where p.usuarioid=u.id and p.modulo = d.cc_valor1 and p.pantalla = d.cc_valor2 and p.permiso ='LECTURA/ESCRITURA'),0) as escritura";
            strSql += " from Usuarios u, Diccionario d ";
            strSql += " where d.dd_parametro = 'PANTALLAS' ";
            if (!string.IsNullOrEmpty(strParamAdicional))
                strSql += " and u.id = " + strParamAdicional;
            strSql += " and u.es_admin =0 ";
            strSql += " order by u.id,d.dd_id ";


            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            gridPerfiles.Rows.Clear();
            CargoTituloGrilla();

            if (dt != null)
            {
                for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                {
                    gridPerfiles.Rows.Add();
                    gridPerfiles[0, i].Value = dt.Rows[i]["id"].ToString();
                    gridPerfiles[1, i].Value = dt.Rows[i]["usuario"].ToString();
                    gridPerfiles[2, i].Value = dt.Rows[i]["nombre_apellido"].ToString();
                    gridPerfiles[3, i].Value = dt.Rows[i]["cc_valor1"].ToString();
                    gridPerfiles[4, i].Value = dt.Rows[i]["cc_valor2"].ToString();
                    gridPerfiles[5, i].Value = Convert.ToBoolean(Convert.ToInt32(dt.Rows[i]["lectura"].ToString()));
                    gridPerfiles[6, i].Value = Convert.ToBoolean(Convert.ToInt32(dt.Rows[i]["escritura"].ToString()));

                }
            }

        }


        private void CargoTituloGrilla()
        {
            gridPerfiles.DataSource = null;
            gridPerfiles.Rows.Clear();
            gridPerfiles.Columns.Clear();
            gridPerfiles.Columns.Add("ID", null);
            gridPerfiles.Columns[0].ReadOnly = true;
            gridPerfiles.Columns.Add("Usuario", null);
            gridPerfiles.Columns[1].ReadOnly = true;
            gridPerfiles.Columns.Add("Nombre y Apellido", null);
            gridPerfiles.Columns[2].ReadOnly = true;
            gridPerfiles.Columns.Add("Modulo", null);
            gridPerfiles.Columns[3].ReadOnly = true;
            gridPerfiles.Columns.Add("Pantalla", null);
            gridPerfiles.Columns[4].ReadOnly = true;


            //Agrego columna con Check
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Lectura";
            checkColumn.HeaderText = "Lectura";
            checkColumn.Width = 40;
            checkColumn.ReadOnly = false;
            gridPerfiles.Columns.Add(checkColumn);

            //Agrego columna con Check
            DataGridViewCheckBoxColumn checkColumn2 = new DataGridViewCheckBoxColumn();
            checkColumn2.Name = "Lectura/Escritura";
            checkColumn2.HeaderText = "Lectura/Escritura";
            checkColumn2.Width = 40;
            checkColumn2.ReadOnly = false;
            gridPerfiles.Columns.Add(checkColumn2);


            this.gridPerfiles.Columns[0].Visible = false;

        }
        private void AsignoObjetoACampos(Perfiles objPerfiles)
        {
            cboUsuarios.SelectedValue = objPerfiles.IntUsuario;
            //cboModulo.Text = objPerfiles.StrModulo;
            //cboPantalla.Text = objPerfiles.StrPantalla;
            //cboPermiso.Text = objPerfiles.StrPermiso;
        }
        private void gridPerfiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridPerfiles.RowCount > 0)
            {
                ManejaPerfiles objManejaPerfiles = new ManejaPerfiles();

                int intCodigo = Convert.ToInt32(gridPerfiles.CurrentRow.Cells[0].Value.ToString());

                objPerfiles = objManejaPerfiles.BuscarPerfil(intCodigo);
                AsignoObjetoACampos(objPerfiles);

            }
        }

        private void cboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargoGrilla(Convert.ToString(cboUsuarios.SelectedValue));
        }

        private void frmUsuariosPerfiles_Load(object sender, EventArgs e)
        {
            string strPermiso = frmLogin.getPermiso("USUARIOS", "USUARIOS_PERFILES");

            if (strPermiso == "LECTURA")
            {
                //btnAceptar.Enabled = false;
                //btnEliminar.Enabled = false;
            }
        }


        private void ckLectura_CheckedChanged(object sender, EventArgs e)
        {
            if (ckLectura.Checked == true)
            {
                ManejaPerfiles objManejaPerfiles = new ManejaPerfiles();
                Perfiles objPerfiles;
                string message;
                string caption = "Mensaje";
                message = "¿Desea asignarle a todos los elemento de la grilla permisos de LECTURA?";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    ckEscritura.Checked = false;

                    foreach (DataGridViewRow row in gridPerfiles.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[5];
                        DataGridViewCheckBoxCell chk2 = (DataGridViewCheckBoxCell)row.Cells[6];
                        chk.Value = true;
                        chk2.Value = false;

                        
                        objPerfiles = new Perfiles();

                        objPerfiles.IntUsuario = Convert.ToInt32(row.Cells[0].Value.ToString());
                        objPerfiles.StrModulo = Convert.ToString(row.Cells[3].Value.ToString());
                        objPerfiles.StrPantalla = Convert.ToString(row.Cells[4].Value.ToString());
                        objPerfiles.StrPermiso = "LECTURA";

                        objManejaPerfiles.EliminaPerfil(objPerfiles.IntUsuario, objPerfiles.StrModulo, objPerfiles.StrPantalla);

                        objPerfiles.IntCodigo = objManejaPerfiles.GrabarPerfiles(objPerfiles);


                    }


                }
                else
                {
                    ckLectura.Checked = false;
                    return;
                }




            }
            //else
            //{
            //    string message;
            //    string caption = "Mensaje";
            //    message = "¿Desea sacarle a todos los elemento de la grilla permisos de LECTURA?";

            //    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //    DialogResult result;

            //    // Displays the MessageBox.

            //    result = MessageBox.Show(message, caption, buttons);

            //    if (result == System.Windows.Forms.DialogResult.Yes)
            //    {

            //        ckEscritura.Checked = false;

            //        foreach (DataGridViewRow row in gridPerfiles.Rows)
            //        {
            //            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[5];
            //            chk.Value = false;
            //        }
            //    }
            //    else
            //    {
            //        ckLectura.Checked = true;
            //        return;
            //    }
            //}



        }

        private void ckEscritura_CheckedChanged(object sender, EventArgs e)
        {
            if (ckEscritura.Checked == true)
            {
                ManejaPerfiles objManejaPerfiles = new ManejaPerfiles();
                Perfiles objPerfiles;
                string message;
                string caption = "Mensaje";
                message = "¿Desea asignarle a todos los elemento de la grilla permisos de ESCRITURA?";

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    ckLectura.Checked = false;

                    foreach (DataGridViewRow row in gridPerfiles.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[6];
                        DataGridViewCheckBoxCell chk2 = (DataGridViewCheckBoxCell)row.Cells[5];
                        chk2.Value = false;
                        chk.Value = true;

                        objPerfiles = new Perfiles();

                        objPerfiles.IntUsuario = Convert.ToInt32(row.Cells[0].Value.ToString());
                        objPerfiles.StrModulo = Convert.ToString(row.Cells[3].Value.ToString());
                        objPerfiles.StrPantalla = Convert.ToString(row.Cells[4].Value.ToString());
                        objPerfiles.StrPermiso = "LECTURA/ESCRITURA";

                        objManejaPerfiles.EliminaPerfil(objPerfiles.IntUsuario, objPerfiles.StrModulo, objPerfiles.StrPantalla);

                        objPerfiles.IntCodigo = objManejaPerfiles.GrabarPerfiles(objPerfiles);
                        
                    }


                }
                else
                {
                    ckEscritura.Checked = false;
                }




            }
            //else
            //{
            //    string message;
            //    string caption = "Mensaje";
            //    message = "¿Desea sacarle a todos los elemento de la grilla permisos de ESCRITURA?";

            //    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //    DialogResult result;

            //    // Displays the MessageBox.

            //    result = MessageBox.Show(message, caption, buttons);

            //    if (result == System.Windows.Forms.DialogResult.Yes)
            //    {

            //        ckLectura.Checked = false;

            //        foreach (DataGridViewRow row in gridPerfiles.Rows)
            //        {
            //            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[6];
            //            chk.Value = false;
            //        }
            //    }
            //    else
            //    {
            //        ckEscritura.Checked = true;
            //    }
            //}

        }

        private void gridPerfiles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridPerfiles.CurrentCell == null)
                return;

            if (gridPerfiles.CurrentCell.ColumnIndex == 5 || gridPerfiles.CurrentCell.ColumnIndex == 6)
            {
                ManejaPerfiles objManejaPerfiles = new ManejaPerfiles();
                Perfiles objPerfiles = new Perfiles();

                objPerfiles.IntUsuario = Convert.ToInt32(gridPerfiles.CurrentRow.Cells[0].Value.ToString());
                objPerfiles.StrModulo = Convert.ToString(gridPerfiles.CurrentRow.Cells[3].Value.ToString());
                objPerfiles.StrPantalla = Convert.ToString(gridPerfiles.CurrentRow.Cells[4].Value.ToString());

                objManejaPerfiles.EliminaPerfil(objPerfiles.IntUsuario, objPerfiles.StrModulo, objPerfiles.StrPantalla);

                //Si estoy seleccionando Lectura, debo deseleccionar Escritura
                if (gridPerfiles.CurrentCell.ColumnIndex == 5 && Convert.ToBoolean(gridPerfiles.CurrentCell.Value) == true)
                {
                    
                    //Grabo 
                    objPerfiles.StrPermiso = "LECTURA";
                    objPerfiles.IntCodigo = objManejaPerfiles.GrabarPerfiles(objPerfiles);
                    gridPerfiles.CurrentRow.Cells[6].Value = 0;

                }
                //Si estoy seleccionando Escritura, debo deseleccionar Lectura
                if (gridPerfiles.CurrentCell.ColumnIndex == 6 && Convert.ToBoolean(gridPerfiles.CurrentCell.Value) == true)
                {
                    
                    objPerfiles.StrPermiso = "LECTURA/ESCRITURA";
                    objPerfiles.IntCodigo = objManejaPerfiles.GrabarPerfiles(objPerfiles);
                    gridPerfiles.CurrentRow.Cells[5].Value = 0;
                }


                //if (Convert.ToBoolean(gridBuscarClientes.CurrentCell.Value) == true)
                //{

                //    objManejaClientes.ModificarClientesOperacionesFirma(intCodigo, true);
                //}
                //else
                //{

                //    objManejaClientes.ModificarClientesOperacionesFirma(intCodigo, false);
                //}                
            }
        }

    }
}
