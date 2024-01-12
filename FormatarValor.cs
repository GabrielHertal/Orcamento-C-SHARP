using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orçamento
{
    public class FormatarValor
    {
        private string _valor;
        public void TratarKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',' || e.KeyChar == '-')
                {
                    TextBox textBox = (TextBox)sender;
                    if (e.KeyChar == ',' && textBox.Text.Contains(","))
                    {
                        e.Handled = true;
                    }
                    else if (e.KeyChar == '-' && textBox.Text.Contains("-"))
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        public void TratarLeave(object sender, EventArgs e)
        {
            _valor = ((TextBox)sender).Text.Replace("R$", "").Replace(" ", "");
            if (double.TryParse(_valor, NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out double valorConvertido))
            {
                if (Math.Abs(valorConvertido) > 0.0001)
                {
                    ((TextBox)sender).Text = string.Format("{0:C}", valorConvertido);
                }
            }
            else
            {
                ((TextBox)sender).Text = "R$ 0,00";
            }
        }
        public void TratarKeyUp(object sender, KeyEventArgs e)
        {
            _valor = ((TextBox)sender).Text.Replace("R$", "").Replace(",", "").Replace(" ", "").Replace("00,", "");
            if (_valor.StartsWith("-"))
            {
                _valor = "-" + new string(_valor.Where(char.IsDigit).ToArray());
            }
            if (_valor.Length == 0)
            {
                ((TextBox)sender).Text = "0,00";
            }
            else if (_valor.Length == 1)
            {
                ((TextBox)sender).Text = "0,0" + _valor;
            }
            else if (_valor.Length == 2)
            {
                ((TextBox)sender).Text = "0," + _valor;
            }
            else if (_valor.Length >= 3)
            {
                if (((TextBox)sender).Text.StartsWith("0,"))
                {
                    ((TextBox)sender).Text = _valor.Insert(_valor.Length - 2, ",").Replace("0,", "");
                }
                else if (((TextBox)sender).Text.Contains("00,"))
                {
                    ((TextBox)sender).Text = _valor.Insert(_valor.Length - 2, ",").Replace("00,", "");
                }
                else
                {
                    ((TextBox)sender).Text = _valor.Insert(_valor.Length - 2, ",");
                }
            }
            _valor = ((TextBox)sender).Text;
            ((TextBox)sender).Text = string.Format("{0:C}", Convert.ToDouble(_valor.Trim()));
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }
    }
}
