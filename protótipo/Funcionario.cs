using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace protótipo
{
    public class Funcionario
    {
        public string nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string endereco { get; set; }
        public string estadoCivil { get; set; }
        public string funcao { get; set; }
        public double salario { get; set; }

        public Funcionario() 
        {
            


        }
    }
}
