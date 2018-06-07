using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoStandard
{
    public class ValidacionesStandard
    {
        public void NoAdmiteLetras (KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public void NoAdmiteLetrasPerosiNumerosconUnPunto(object sender, KeyPressEventArgs e)
        {            
            if (e.KeyChar == 46 || e.KeyChar == 44)
            {
                TextBox textBox = (TextBox)sender;
                e.Handled = valido_si_ya_tiene_un_punto(textBox);
            }

            else if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public void NoAdmiteLetrasPerosiNumerosconUnaComa(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 44)
            {
                TextBox textBox = (TextBox)sender;
                e.Handled = valido_si_ya_tiene_un_punto(textBox);
            }
                //No admito punto
            else if (e.KeyChar == 46)
            {
                e.Handled = true;
            }
            else if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private bool valido_si_ya_tiene_un_punto(TextBox textbox)
        {
            bool boTieneComa;
            bool boTienePunto;
            boTieneComa = textbox.Text.Contains(',');
            boTienePunto = textbox.Text.Contains('.');

            if (boTienePunto || boTieneComa)
                return true;
            else
                return false;
        }

    }
}
