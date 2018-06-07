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

namespace ProyectoStandard
{
    public partial class frmSeguimiento : Form
    {
        List<Seguimiento> list;
        ManejaVentas objManejaVentas;
        public frmSeguimiento( Int32 facturaid)
        {
            InitializeComponent();
            objManejaVentas = new ManejaVentas();
            list = new List<Seguimiento>();
            list= objManejaVentas.BuscoSeguimiento(facturaid);
            CargoGrilla();
        }

        private void CargoGrilla()
        {
            int i = 0;
            grilla.DataSource = null;
            grilla.Rows.Clear();
            CargoTituloGrilla();
            if (this.list.Count != 0)
            {

                foreach (Seguimiento element in list)
                {

                    grilla.Rows.Add();
                    grilla[0, i].Value = element.DtFecha;
                    grilla[1, i].Value = element.StrEstadoDesde;
                    grilla[2, i].Value = element.StrEstadoHasta;
                    grilla[3, i].Value = element.StrUsuario;
                    i++;


                }


            }
        }

        private void CargoTituloGrilla()
        {
            if (list != null)
            {
                grilla.DataSource = null;
                grilla.Rows.Clear();
                grilla.Columns.Clear();
                grilla.Columns.Add("Fecha", null);
                grilla.Columns.Add("Desde Estado", null);
                grilla.Columns.Add("Hasta Estado", null);
                grilla.Columns.Add("Usuario", null);

            }
        }

    }
}
