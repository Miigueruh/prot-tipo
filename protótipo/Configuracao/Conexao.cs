using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;

namespace protótipo.Configuracao
{
    class Conexao
    {
        private string _servidor = "localhost";

        private string _porta = "3360";

        private string _usuario = "root";

        private string _senha = "root";
        
        private string _bancoDadosNome =  "dssistemas_db";

        private MySqlConnection connection;

        private MySqlCommand command;

        public Conexao()
        {
            try
            {
                connection = new MySqlConnection($"server={_servidor};database={_bancoDadosNome};port={_porta};user={_usuario};password={_senha}");
                connection.Open();
            }

            catch (Exception e)
            {
                throw e;
            }
        }   

        public MySqlCommand Comando(string comando)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = comando;

                return command;
            }

            catch (Exception e)
            {
                throw e;
            }
        }





    }
}
