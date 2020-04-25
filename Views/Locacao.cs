using System;
using Models;
using Controllers;

namespace View
{
    public class LocacaoView
    {

        /// Método responsável por criar as locações.
        public static void CadastrarLocacao()
        {
            Console.WriteLine("Informações sobre a locação: ");
            Cliente cliente;
            Filme filme;

            // Pesquisa o cliente com o ID.
            do
            {
                Console.WriteLine("Informe o id do cliente: ");
                int ClienteId = Convert.ToInt32(Console.ReadLine());
                cliente = null; // Redefina o valor para evitar lixo.

                // Tente localizar as informações na collection.
                try
                {
                    cliente = ClienteController.GetCliente(ClienteId);
                    if (cliente == null)
                    { // Se a informação não estiver presente, uma mensagem será retornada.
                        Console.WriteLine("Cliente não localizado, favor digitar outro id.");
                    }
                }
                catch
                {
                    Console.WriteLine("Cliente não localizado, favor digitar outro id.");
                }

            } while (cliente == null);

            // Insere a locação no cliente
            Locacao locacao = LocacaoController.CadastrarLocacao(cliente);

            // Pesquisa o filme com id.
            int filmOpt = 0;
            do
            {
                Console.WriteLine("Informe o id do filme alugado: ");
                int idFilme = Convert.ToInt32(Console.ReadLine());
                filme = null; // Redefina o valor para evitar lixo.

                // Tente localizar as informações na collection.
                try
                {
                    filme = FilmeController.GetFilme(idFilme);
                    if (filme == null)
                    { // Se a informação não estiver presente, uma mensagem será retornada.
                        Console.WriteLine("Filme não localizado, favor digitar outro id.");
                    }
                }
                catch
                {
                    Console.WriteLine("Filme não localizado, favor digitar outro id.");
                }

                if (filme != null)
                {
                    // Insere o filme na locação.
                    LocacaoController.CadastrarFilme(locacao, filme);
                    Console.WriteLine("Deseja informar outro filme? " +
                        "Informar 1 para Não ou qualquer outro valor para Sim.");
                    filmOpt = Convert.ToInt32(Console.ReadLine());
                }
            } while (filmOpt != 1);
        }

        /// Esse método é responsável por consultar uma locação.
        public static void ConsultarLocacao()
        {
            Locacao locacao;

            // Pesquise a locação com id.
            do
            {
                Console.WriteLine("Informe a locacao que deseja consultar: ");
                int idLocacao = Convert.ToInt32(Console.ReadLine());
                locacao = null; // Redefina o valor para evitar lixo.

                // Tente localizar as informações na collection.
                try
                {
                    locacao = LocacaoController.GetLocacao(idLocacao);
                    if (locacao == null)
                    { // Se a informação não estiver presente, uma mensagem será retornada.
                        Console.WriteLine("Locação não localizada, favor digitar outro id.");
                    }
                }
                catch
                {
                    Console.WriteLine("Locação não localizada, favor digitar outro id.");
                }
            } while (locacao == null);
            Console.WriteLine(locacao.ToString());
        }
    }
}