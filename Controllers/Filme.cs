using System;
using Models;
using System.Collections.Generic;

namespace Controllers
{
    public class FilmeController
    {
        /// Este método insere um filme no banco de dados. 
        public static void CadastrarFilme(
            string nome,
            string sDtLancamento,
            string sinopse,
            double valor,
            int estoque
        )
        {
            DateTime dtLancamento;
            try
            {
                dtLancamento = Convert.ToDateTime(sDtLancamento);
            }
            catch
            {
                Console.WriteLine("Formato inválido de data, será utilizada a data atual pra cadastro");
                dtLancamento = DateTime.Now;
            }

            Filme.CadastrarFilme(
                nome,
                dtLancamento,
                sinopse,
                valor,
                estoque
            );
        }

        /// Este método acessa a localização do filme.
        public static Filme GetFilme(int idFilme)
        {
            return Filme.GetFilme(idFilme);
        }

        /// Este método acessa todos os filmes.
        public static List<Filme> GetFilmes()
        {
            return Filme.GetFilmes();
        }
    }
}