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
    public partial class frmArticulosBusquedaPorImagen : Form
    {
        bool boOtraPantalla;
        public string strCodigo;

        public frmArticulosBusquedaPorImagen(bool boOtraPantalla)
        {
            InitializeComponent();
            this.boOtraPantalla = boOtraPantalla;
            cboSeleccion.Text = "DESCRIPCION";
        }

        private void Buscar()
        {
            CargoImagenes();

        }

        private void CargoImagenes()
        {
            if (String.IsNullOrEmpty(txtDescripcion.Text))
                return;

            int intCantidadDeFilasEnCol = 0;//La primera ya esta creada
            int intCantidadDeCol = 0;
            //x= Sumo 274
            //y= Sumo 274
            int intX = 274;
            int intY = 294;
            string strSql;
            //List<Articulos> ListArticulos = new List<Articulos>();

            strSql = "select top 15 a.id,idextra,descripcion, fechaalta, rubro,a.ubicacion, marca, stock, precioefectivo, preciotarjeta, razonsocial, imagen ";
            strSql += " from dbo.Articulos a LEFT OUTER JOIN dbo.Proveedores  P  ON a.proveedor = P.id where a.fechabaja is null ";

            if (cboSeleccion.Text == "DESCRIPCION")
            {
                if (txtDescripcion.Text != "")
                {
                    strSql += " and  a.descripcion like '" + txtDescripcion.Text.ToUpper() + "%' ";

                }
            }

            if (cboSeleccion.Text == "RUBRO")
            {
                if (txtDescripcion.Text != "")
                {
                    strSql += " and  a.rubro like '" + txtDescripcion.Text.ToUpper() + "%' ";

                }
            }

            if (cboSeleccion.Text == "UBICACION")
            {
                if (txtDescripcion.Text != "")
                {
                    strSql += " and  a.ubicacion like '" + txtDescripcion.Text.ToUpper() + "%' ";

                }
            }


            LlenaCombos objLlenaCombos = new LlenaCombos();
            DataTable dt = objLlenaCombos.GetSqlDataAdapterbySql(strSql);

            if (dt != null)
            {

                for (int i = 0; i <= Convert.ToInt32(dt.Rows.Count) - 1; i++)
                {


                    Articulos objArticulos = new Articulos();
                    objArticulos.IntCodigo = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                    objArticulos.StrCodigo = dt.Rows[i]["idextra"].ToString();
                    objArticulos.DtFechaAlta = Convert.ToDateTime(dt.Rows[i]["fechaalta"].ToString());
                    objArticulos.StrDescripcion = dt.Rows[i]["descripcion"].ToString();
                    objArticulos.StrRubro = dt.Rows[i]["rubro"].ToString();
                    objArticulos.StrMarca = dt.Rows[i]["marca"].ToString();
                    objArticulos.Intstock = Convert.ToInt32(dt.Rows[i]["stock"].ToString());
                    objArticulos.StrImagen = dt.Rows[i]["imagen"].ToString();
                    objArticulos.StrUbicacion = dt.Rows[i]["ubicacion"].ToString();
                    objArticulos.DoPrecioEfectivo = Redondeo( Convert.ToDecimal(dt.Rows[i]["precioefectivo"].ToString()));

                    //CREO EL PANEL

                    //Si esta en 3 la inicializo para que pase a la otra columna
                    if (intCantidadDeFilasEnCol == 3)
                    {
                        intCantidadDeFilasEnCol = 0;
                        intCantidadDeCol++;
                    }


                    addPanel(intX, intY, objArticulos, intCantidadDeCol, intCantidadDeFilasEnCol);

                    //Aumento una fila
                    intCantidadDeFilasEnCol++;

                }
            }

        }


        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            removeControles();
            CargoImagenes();
        }


        private void removeControles()
        {
            //Borro las Imagenes
            for (int i = this.pnlImagenes.Controls.Count - 1; i >= 0; i--)
            {
                PictureBox control = this.pnlImagenes.Controls[i] as PictureBox;
                if (control == null)
                    continue;

                control.Dispose();
            }

            //Borro los botones

            for (int i = this.pnlImagenes.Controls.Count - 1; i >= 0; i--)
            {
                Button control = this.pnlImagenes.Controls[i] as Button;
                if (control == null)
                    continue;

                control.Dispose();
            }

            //Borro los labels
            for (int i = this.pnlImagenes.Controls.Count - 1; i >= 0; i--)
            {
                Label control = this.pnlImagenes.Controls[i] as Label;
                if (control == null)
                    continue;

                control.Dispose();

            }
        }

        private void addPanel(int intX, int intY, Articulos objArticulos, int intCantidadDeCol, int intCantidadDeFilasEnCol)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArticulosBusquedaPorImagen));
            // 
            // Imagen
            //        

            PictureBox objPictureBox = new PictureBox();
            objPictureBox.Size = new System.Drawing.Size(262, 187);

            if (String.IsNullOrEmpty(objArticulos.StrImagen))
                objPictureBox.ImageLocation = Application.StartupPath + "\\Resources\\" + "SIN IMAGEN.jpg";//Imagen Por default
            else
                objPictureBox.ImageLocation = objArticulos.StrImagen;

            objPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            objPictureBox.Location = new Point(intX * intCantidadDeCol, intY * intCantidadDeFilasEnCol);
            //Evento
            objPictureBox.DoubleClick += new System.EventHandler(this.pbImagen_DoubleClick);


            // Boton Agregar
            // 

            Button objButtonAgregar = new Button();

            if (boOtraPantalla)//Si viene de otra pantalla debe poder Agregar, de lo contrario Visualizar
                //objButtonAgregar.Image = ((System.Drawing.Image)(resources.GetObject("cboAgregar.Image")));
                objButtonAgregar.Text = "Agregar";
            else
                //objButtonAgregar.Image = ((System.Drawing.Image)(resources.GetObject("cboAgregar.Image")));
                objButtonAgregar.Text = "Ver";
            objButtonAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            objButtonAgregar.Location = new Point(((intX * intCantidadDeCol) + 71), ((intY * intCantidadDeFilasEnCol)) + 257);
            objButtonAgregar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            objButtonAgregar.Name = objArticulos.StrCodigo;  //"cboAgregar" + Convert.ToString(intX) + Convert.ToString(intY);
            objButtonAgregar.Size = new System.Drawing.Size(84, 26);
            objButtonAgregar.UseVisualStyleBackColor = true;
            objButtonAgregar.Click += new System.EventHandler(this.cboAgregar_Click);


            // 
            // lblPrecio
            // 
            Label objLabelPrecio = new Label();

            objLabelPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            objLabelPrecio.Location = new Point(((intX * intCantidadDeCol) + 4), ((intY * intCantidadDeFilasEnCol)) + 235);
            objLabelPrecio.Name = "lblPrecio" + Convert.ToString(intX) + Convert.ToString(intY);
            objLabelPrecio.Size = new System.Drawing.Size(25, 19);
            objLabelPrecio.Text = "$:";



            // 
            // lblDescripcion
            // 
            Label objLabelDescripcion = new Label();

            objLabelDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            objLabelDescripcion.Location = new Point(((intX * intCantidadDeCol) + 3), ((intY * intCantidadDeFilasEnCol)) + 193);
            objLabelDescripcion.Name = "lblDescripcion" + Convert.ToString(intX) + Convert.ToString(intY);
            objLabelDescripcion.Size = new System.Drawing.Size(78, 18);
            objLabelDescripcion.Text = "Descripción";

            // 
            // lblUbicacion
            // 
            Label objLabelUbicacion = new Label();
            objLabelUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            objLabelUbicacion.Location = new Point(((intX * intCantidadDeCol) + 89), ((intY * intCantidadDeFilasEnCol)) + 235);
            objLabelUbicacion.Name = "lblUbicacion" + Convert.ToString(intX) + Convert.ToString(intY);
            objLabelUbicacion.Size = new System.Drawing.Size(40, 19);
            objLabelUbicacion.Text = "Ubic:";
            // 
            // lblStock
            // 
            Label objLabelStock = new Label();
            objLabelStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            objLabelStock.Location = new Point(((intX * intCantidadDeCol) + 184), ((intY * intCantidadDeFilasEnCol)) + 235);
            objLabelStock.Name = "lblStock" + Convert.ToString(intX) + Convert.ToString(intY);
            objLabelStock.Size = new System.Drawing.Size(41, 19);
            objLabelStock.Text = "Stock:";
            // 
            // lblDescripcionLlenar
            // 
            Label objLabelDescripcionLlenar = new Label();
            objLabelDescripcionLlenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            objLabelDescripcionLlenar.Location = new Point(((intX * intCantidadDeCol) + 87), ((intY * intCantidadDeFilasEnCol)) + 193);
            objLabelDescripcionLlenar.Name = "lblDescripcionLlenar" + Convert.ToString(intX) + Convert.ToString(intY);
            objLabelDescripcionLlenar.Size = new System.Drawing.Size(174, 18);
            objLabelDescripcionLlenar.Text = objArticulos.StrDescripcion;
            objLabelDescripcionLlenar.ForeColor = System.Drawing.SystemColors.HotTrack;
            // 
            // lblPrecioLlenar
            // 
            Label objLabelPrecioLlenar = new Label();
            objLabelPrecioLlenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            objLabelPrecioLlenar.Location = new Point(((intX * intCantidadDeCol) + 27), ((intY * intCantidadDeFilasEnCol)) + 235);
            objLabelPrecioLlenar.Name = "lblPrecioLlenar" + Convert.ToString(intX) + Convert.ToString(intY);
            objLabelPrecioLlenar.Size = new System.Drawing.Size(64, 19);
            objLabelPrecioLlenar.Text = Convert.ToString(objArticulos.DoPrecioEfectivo);
            objLabelPrecioLlenar.ForeColor = System.Drawing.SystemColors.HotTrack;

            // 
            // lblUbicacionLlenar
            // 
            Label objLabelUbicacionLlenar = new Label();
            objLabelUbicacionLlenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            objLabelUbicacionLlenar.Location = new Point(((intX * intCantidadDeCol) + 125), ((intY * intCantidadDeFilasEnCol)) + 235);
            objLabelUbicacionLlenar.Name = "lblUbicacionLlenar" + Convert.ToString(intX) + Convert.ToString(intY);
            objLabelUbicacionLlenar.Size = new System.Drawing.Size(53, 19);
            objLabelUbicacionLlenar.Text = objArticulos.StrUbicacion;
            objLabelUbicacionLlenar.ForeColor = System.Drawing.SystemColors.HotTrack;

            // 
            // lblStockLlenar
            // 
            Label objLabelStockLlenar = new Label();
            objLabelStockLlenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            objLabelStockLlenar.Location = new Point(((intX * intCantidadDeCol) + 223), ((intY * intCantidadDeFilasEnCol)) + 235);
            objLabelStockLlenar.Name = "lblStockLlenar" + Convert.ToString(intX) + Convert.ToString(intY);
            objLabelStockLlenar.Size = new System.Drawing.Size(40, 19);
            objLabelStockLlenar.Text = Convert.ToString(objArticulos.Intstock);
            objLabelStockLlenar.ForeColor = System.Drawing.SystemColors.HotTrack;

            // 
            // lblMarcaLlenar
            // 
            Label objLabelMarcaLlenar = new Label();

            objLabelMarcaLlenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            objLabelMarcaLlenar.Location = new Point(((intX * intCantidadDeCol) + 135), ((intY * intCantidadDeFilasEnCol)) + 211);
            objLabelMarcaLlenar.Name = "lblMarcaLlenar" + Convert.ToString(intX) + Convert.ToString(intY);
            objLabelMarcaLlenar.Size = new System.Drawing.Size(126, 19);
            objLabelMarcaLlenar.Text = objArticulos.StrMarca;
            objLabelMarcaLlenar.ForeColor = System.Drawing.SystemColors.HotTrack;
            // 
            // lblIDLlenar
            // 
            Label objLabelIDLlenar = new Label();

            objLabelIDLlenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            objLabelIDLlenar.Location = new Point(((intX * intCantidadDeCol) + 27), ((intY * intCantidadDeFilasEnCol)) + 211);
            objLabelIDLlenar.Name = "lblIDLlenar" + Convert.ToString(intX) + Convert.ToString(intY);
            objLabelIDLlenar.Size = new System.Drawing.Size(64, 19);
            objLabelIDLlenar.Text = objArticulos.StrCodigo;
            objLabelIDLlenar.ForeColor = System.Drawing.SystemColors.HotTrack;

            // 
            // lblMarca
            // 

            Label objLabelMarca = new Label();

            objLabelMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            objLabelMarca.Location = new Point(((intX * intCantidadDeCol) + 89), ((intY * intCantidadDeFilasEnCol)) + 211);
            objLabelMarca.Name = "lblMarca" + Convert.ToString(intX) + Convert.ToString(intY);
            objLabelMarca.Size = new System.Drawing.Size(52, 19);
            objLabelMarca.Text = "Marca:";
            // 
            // lblID
            // 
            Label objLabelID = new Label();
            objLabelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            objLabelID.Location = new Point(((intX * intCantidadDeCol) + 4), ((intY * intCantidadDeFilasEnCol)) + 211);
            objLabelID.Name = "lblID" + Convert.ToString(intX) + Convert.ToString(intY);
            objLabelID.Size = new System.Drawing.Size(25, 19);
            objLabelID.Text = "ID:";

            //Los agrego al panelDetalle...
            pnlImagenes.Controls.Add(objPictureBox);
            pnlImagenes.Controls.Add(objButtonAgregar);
            pnlImagenes.Controls.Add(objLabelPrecio);
            pnlImagenes.Controls.Add(objLabelDescripcion);
            pnlImagenes.Controls.Add(objLabelUbicacion);
            pnlImagenes.Controls.Add(objLabelStock);
            pnlImagenes.Controls.Add(objLabelDescripcionLlenar);
            pnlImagenes.Controls.Add(objLabelPrecioLlenar);
            pnlImagenes.Controls.Add(objLabelUbicacionLlenar);
            pnlImagenes.Controls.Add(objLabelStockLlenar);
            pnlImagenes.Controls.Add(objLabelMarcaLlenar);
            pnlImagenes.Controls.Add(objLabelIDLlenar);
            pnlImagenes.Controls.Add(objLabelMarca);
            pnlImagenes.Controls.Add(objLabelID);


        }
        private void pbImagen_DoubleClick(object sender, EventArgs e)
        {
            FullScreenImage(((PictureBox)sender).Image);
        }


        private void FullScreenImage(Image imageToShow)
        {
            Form fullScreenForm = new Form()
            {
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.None,
                BackgroundImage = imageToShow,
                BackgroundImageLayout = ImageLayout.Zoom
            };

            fullScreenForm.Click += fullScreen_Click;

            fullScreenForm.ShowDialog();
        }

        private void fullScreen_Click(object sender, EventArgs e)
        {
            ((Form)sender).Close();
        }

        private void cboAgregar_Click(object sender, EventArgs e)
        {
            strCodigo = ((Button)sender).Name;
            if (boOtraPantalla)
                this.Close();//Cierra la pantalla y vuelve a la pantalla de ventas
            else
            {
                ManejaArticulos objManejaArticulos = new ManejaArticulos();
                Articulos objArticulos = objManejaArticulos.BuscarArticulosPorCodigoExtra(strCodigo, boOtraPantalla);
                frmArticulos objfrmArticulos = new frmArticulos(objArticulos);
                objfrmArticulos.Show();
                objfrmArticulos.Activate();
            }
        }

        private decimal Redondeo(decimal deVariable)
        {
            return decimal.Round(deVariable, 2, MidpointRounding.AwayFromZero);
        }
    }
}
