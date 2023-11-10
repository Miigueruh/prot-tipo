using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace protótipo
{
    internal class ValidarCPF
    {
        public static bool Validar(string cpf)
        {
            try
            {
                int num1 = 0, num2 = 0;

                cpf = cpf.Replace(".", "").Replace(",", "").Replace("-", "");
                char[] cpfChar = cpf.ToCharArray();

                if (cpfChar.Length != 11)
                {
                    MessageBox.Show($"CPF inválido.");
                    return false;
                }
                else
                {
                    for (int i = 0, j = 10; i<(cpfChar.Length - 2); i++, j--) num1 += (Convert.ToInt32(cpfChar[i].ToString()) * j);
                    num1 = num1 % 11;

                    if (num1 >= 2) num1 = 11 - num1;
                    else if (num1 == 0) { }
                    else
                    {
                    MessageBox.Show($"CPF inválido.");
                    return false;
                    }

                    if (num1 == Convert.ToInt32(cpfChar[9].ToString()))
                    {
                    for (int i = 0, j = 11; i < (cpfChar.Length - 1); i++, j--) num2 += (Convert.ToInt32(cpfChar[i].ToString()) * j);
                    num2 = num2 % 11;

                    if (num2 >= 2) num2 = 11 - num2;
                    else if (num2 == 0) { }
                    else
                    {
                        MessageBox.Show($"CPF inválido.");
                        return false;
                    }

                    if (num2 == Convert.ToInt32(cpfChar[10].ToString())) return true;
                    else
                    {
                        MessageBox.Show($"CPF inválido.");
                        return false;
                    }
                    }
                    else return false;
                }
            }
            catch (Exception ex)
            {
            MessageBox.Show($"Ocorreu um erro.");
            return false;
            }
        }
    }
}
