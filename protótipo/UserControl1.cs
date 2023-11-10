using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace protótipo
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            lorem.Text = string.Empty;
        }


        private void salvar_Click(object sender, EventArgs e)
        {
            string valor = tb_cpf.Text;

            if (tb_nome.Text == string.Empty ||
            tb_email.Text == string.Empty ||
            tb_cpf.Text == string.Empty ||
            tb_rg.Text == string.Empty ||
            tb_endereco.Text == string.Empty ||
            tb_funcao.Text == string.Empty ||
            tb_salario.Text == string.Empty ||
            cb_estadoCivil.Text == string.Empty ||           
            tb_telefone.Text == string.Empty ||
            tb_cidade.Text == string.Empty ||
            cb_estado.Text == string.Empty)
            {
                lorem.Text = "Preencha todos os campos!";
            }
            
            else
            {
                lorem.Text = string.Empty;
                if (ValidarCPF.Validar(valor) == true)
                {



                }

                else 
                {
                    MessageBox.Show("CPF inválido!");
                }
            }
             
            
            
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            tb_nome.Text = string.Empty;
            tb_email.Text = string.Empty;
            tb_cpf.Text = string.Empty;
            tb_rg.Text = string.Empty;
            tb_endereco.Text = string.Empty;
            tb_funcao.Text = string.Empty;
            tb_salario.Text = string.Empty;
            cb_estadoCivil.Text = string.Empty;
            dateTime.Text = string.Empty;
            tb_telefone.Text = string.Empty;
            tb_cidade.Text = string.Empty;
            cb_estado.Text = string.Empty;
            lorem.Text = string.Empty;
        }
       
    }
}
