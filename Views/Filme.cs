using System;
using Models;
using Controllers;

namespace View
{
    public class FilmeView
    {

        /// Este método é responsável pela criação dos filmes
        public static void CadastrarFilme()
        {
            Console.WriteLine("Informações sobre o filme: ");
            Console.WriteLine("Informe o nome: ");
            String nome = Console.ReadLine();
            Console.WriteLine("Informe a data de lançamento (dd/mm/yyyy): ");
            String sDtLancamento = Console.ReadLine();
            Console.WriteLine("Informe a Sinopse: ");
            String sinopse = Console.ReadLine();
            Console.WriteLine("Informe o valor para locação: ");
            double valor = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Informe a quantidade em estoque: ");
            int estoque = Convert.ToInt32(Console.ReadLine());

            FilmeController.CadastrarFilme(
                nome,
                sDtLancamento,
                sinopse,
                valor,
                estoque
            );
        }

        /// Este método é responsável por listar os filmes
        public static void ListarFilmes()
        {
            Console.WriteLine("Lista de Filmes: ");
            FilmeController.GetFilmes().ForEach(filme => Console.WriteLine(filme.ToString(true)));
        }

        /// Este método é responsável por consultar um filme
        public static void ConsultarFilme()
        {
            Filme filme;

            // Pesquise o filme com id.
            do
            {
                Console.WriteLine("Informe o filme que deseja consultar: ");
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
            } while (filme == null);
            Console.WriteLine(filme.ToString());
        }
    }
}