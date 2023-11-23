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

       public void Inserir()
        {
            string nome = tb_nome.Text;
            DateTime dataNascimento = Convert.ToDateTime(dataTime);
            string cpf = tb_cpf.Text;
            string rg = tb_rg.Text;
            string telefone = tb_telefone.Text;
            string email = tb_email.Text;
            string estadoCivil = cb_estadoCivil.Text;
            string funcao = tb_funcao.Text;
            double salario = Convert.ToDouble(tb_salario.Text);

            try
            {
                Conexao conexao = new Conexao();

                var comando = conexao.Comando(
                    "INSERT INTO funcionario (nome_fun, data_nasc_fun, cpf_fun, rg_fun, telefone_fun, email_fun, estado_civil_fun, funcao_fun, funcao_fun, salario_fun) VALUES (@nome, @dataNascimento, @cpf, @rg, @telefone, @email, @estadoCivil, @funcao, @salario)"
                    );

                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@dataNascimento", dataNascimento);
                comando.Parameters.AddWithValue("@cpf", cpf);
                comando.Parameters.AddWithValue("@rg", rg);
                comando.Parameters.AddWithValue("@telefone", telefone);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@estadoCivil", estadoCivil);
                comando.Parameters.AddWithValue("@funcao", funcao);
                comando.Parameters.AddWithValue("@salario", salario);

                var resultado = comando.ExecuteNonQuery();

                if (resultado > 0)
                {
                    MessageBox.Show("Funcionário cadastrado com sucesso");
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string[] Consultar()
        {
            try
            {
                var conexao = new Conexao();

                var comando = conexao.Comando("SELECT * FROM funcionario");

                var leitor = comando.ExecuteReader();

                List<string> resultado = new List<string>();

                while (leitor.Read())
                {
                    resultado.Add($"nome = {leitor.GetString("nome_fun")}");
                }

                return resultado.ToArray();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            
        }

        private void salvar_Click(object sender, EventArgs e)
        {
            Funcionario f = new Funcionario();
            f.nome = tb_nome.Text;
            f.dataNascimento = Convert.ToDateTime(dataTime);
            f.cpf = tb_cpf.Text;
            f.rg = tb_rg.Text;
            f.telefone = tb_telefone.Text;
            f.email = tb_email.Text;
            f.estadoCivil = cb_estadoCivil.Text;
            f.funcao = tb_funcao.Text;
            f.salario = Convert.ToDouble(tb_salario.Text);

            Consultar();
            Inserir();

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
                    string[] funcionarios = Consultar();
                    listBox99.Items.Clear();
                    listBox99.Items.Add(funcionarios);
                    listBox99.Refresh();


                }

                else 
                {
                    MessageBox.Show("CPF inválido!", "disclaimer");
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
            dataTime.Text = string.Empty;
            tb_telefone.Text = string.Empty;
            tb_cidade.Text = string.Empty;
            cb_estado.Text = string.Empty;
            lorem.Text = string.Empty;
        }

       
    }
}
