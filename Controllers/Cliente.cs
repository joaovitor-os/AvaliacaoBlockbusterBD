using System;
using Models;
using System.Collections.Generic;

namespace Controllers
{
    public class ClienteController
    {

        /// Este método insere um cliente no banco de dados.
        public static void CadastrarCliente(
            string nome,
            string sDtNasc,
            string cpf,
            int qtdDias
        )
        {
            DateTime dtNasc;
            try
            {
                dtNasc = Convert.ToDateTime(sDtNasc);
            }
            catch
            {
                Console.WriteLine("Formato inválido de data, será utilizada a data atual pra cadastro");
                dtNasc = DateTime.Now;
            }

            Cliente.CadastrarCliente(
                nome,
                dtNasc,
                cpf,
                qtdDias
            );

        }
        /// Este método acessa a localização de um cliente.
        public static Cliente GetCliente(int idCliente)
        {
            return Cliente.GetCliente(idCliente);
        }

        /// Este método acessa todos os clientes.
        public static List<Cliente> GetClientes()
        {
            return Cliente.GetClientes();
        }
    }
}