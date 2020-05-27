/*
using System;
using Models;
using Controllers;

namespace View
{
    public class ClienteView
    {

        /// Este método é responsável por criar os clientes.
        public static void CadastrarCliente()
        {
            Console.WriteLine("Informações sobre o cliente: ");
            Console.WriteLine("Informe o nome: ");
            String nome = Console.ReadLine();
            Console.WriteLine("Informe a data de nascimento (dd/mm/yyyy): ");
            String sDtNasc = Console.ReadLine();
            Console.WriteLine("Informe o C.P.F.: ");
            String cpf = Console.ReadLine();
            Console.WriteLine("Informe a quantidade de dias para devolução: ");
            int qtdDias = Convert.ToInt32(Console.ReadLine());

            ClienteController.CadastrarCliente(nome, sDtNasc, cpf, qtdDias);
        }

        /// Este método é responsável por listar os clientes
        public static void ListarClientes()
        {
            Console.WriteLine("Lista de Clientes: ");
            ClienteController.GetClientes().ForEach(
                cliente => Console.WriteLine(cliente.ToString(true)));
        }

        /// Este método é responsável por consultar um cliente.
        public static void ConsultarCliente()
        {
            Cliente cliente;

            // Pesquisa o cliente com o ID.
            do
            {
                Console.WriteLine("Informe o cliente que deseja consultar: ");
                int idCliente = Convert.ToInt32(Console.ReadLine());
                cliente = null; // Redefine o valor para evitar lixo.

                // Tenta localizar as informações na collection.
                try
                {
                    cliente = ClienteController.GetCliente(idCliente);
                    if (cliente == null)
                    { // Se a informação não estiver presente, uma mensagem será retornada
                        Console.WriteLine("Cliente não localizado, favor digitar outro id.");
                    }
                }
                catch
                {
                    Console.WriteLine("Cliente não localizado, favor digitar outro id.");
                }
            } while (cliente == null);
            Console.WriteLine(cliente.ToString());
        }
    }
}
*/