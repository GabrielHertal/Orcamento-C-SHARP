using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orçamento
{
    public class Formatar
    {
        public void ativar(Form formulario)
        {
            foreach(Control controle in formulario.Controls) 
            {
                if(controle is TextBox || controle is MaskedTextBox)
                {
                    controle.Enabled = true;
                }
            }
        }
        public void desativar(Form formulario)
        {
            foreach (Control controle in formulario.Controls)
            {
                if (controle is TextBox || controle is MaskedTextBox)
                {
                    controle.Enabled = false;
                }
            }
        }
    }
}
