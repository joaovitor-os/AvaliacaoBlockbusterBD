using System;
using Models;

namespace Controllers
{
    public class LocacaoController
    {

        /// Este método insere locação do cliente no banco de dados.
        public static Locacao CadastrarLocacao(
            Cliente cliente
        )
        {
            return Locacao.CadastrarLocacao(cliente, DateTime.Now);
        }

        /// Este método insere um filme na locação do cliente.
        public static void CadastrarFilme(
            Locacao locacao,
            Filme filme
        )
        {
            locacao.CadastrarFilme(filme);
        }

        /// Este método obtém o valor total da locação.
        /// Retorna o valor da locação.
        public static double GetValorTotal(Locacao locacao)
        {
            double valorTotal = 0;

            foreach (FilmeLocacao filme in locacao.Filmes)
            {
                valorTotal += filme.Filme.Valor;
            }

            return valorTotal;
        }

        /// Este método obtém a quantidade de filmes.
        /// Retorna a quantidade de filmes.
        public static double GetQtdFilmes(Locacao locacao)
        {
            return locacao.Filmes.Count;
        }

        /// Este método calcula a data de devolução.
        /// Retorna a data de devolução do cliente
        public static DateTime GetDataDevolucao(DateTime DtLocacao, Cliente Cliente)
        {
            return DtLocacao.AddDays(Cliente.DiasPDevolucao);
        }

        /// Este método encontra uma locação do cliente.
        public static Locacao GetLocacao(int idLocacao)
        {
            return Locacao.GetLocacao(idLocacao);
        }
    }
}