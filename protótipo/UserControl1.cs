using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using protótipo.Configuracao;

namespace protótipo
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            lorem.Text = string.Empty;
        }

        void Inserir()
        {
            var nomeFunc = "nomeE";
            var cpfFunc = "cpfE";

            try
            {
                Conexao conexao = new Conexao();

                var comando = conexao.Comando("INSERT INTO funcionario (nome_func, cpf_func) VALUES (@nome, @cpf)");

                comando.Parameters.AddWithValue("@nome", nomeFunc);
                comando.Parameters.AddWithValue("@cpf", cpfFunc);

                var resultado = comando.ExecuteNonQuery();

                if(resultado > 0)
                {
                    MessageBox.Show("Funcionário cadastrado com sucesso");
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Consultar()
        {
            try
            {
                var conexao = new Conexao();

                var comando = conexao.Comando("SELECT * FROM funcionario");

                var leitor = comando.ExecuteReader();

                string resultado = null;

                while (leitor.Read())
                {
                    resultado += "\n" + leitor.GetString("nome_func");
                }

                MessageBox.Show(resultado);

            }

            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
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
