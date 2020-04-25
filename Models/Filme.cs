using System;
using System.Collections.Generic;
using Controllers;
using Repositories;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Filme
    {

        [Key]
        public int FilmeId { get; set; }
        [Required]
        public string NomeFilme { get; set; }
        [Required]
        public DateTime DtLancamento { get; set; }
        [Required]
        public string Sinopse { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public int QtdEstoque { get; set; }
        public List<FilmeLocacao> Locacoes { get; set; }

        public Filme()
        {
            Locacoes = new List<FilmeLocacao>();
        }

        /// Construtor do objeto Filme.
        public static void CadastrarFilme(string nomeFilme, DateTime dtLancamento, string sinopse, double valor, int qtdEstoque)
        {
            Filme filme = new Filme
            {
                NomeFilme = nomeFilme,
                DtLancamento = dtLancamento,
                Sinopse = sinopse,
                Valor = valor,
                QtdEstoque = qtdEstoque
            };

            var db = new Context();
            db.Filmes.Add(filme);
            db.SaveChanges();
        }

        /// Este método encontra um filme.
        public static Filme GetFilme(int FilmeId)
        {
            var db = new Context();
            return (from filme in db.Filmes
                    where filme.FilmeId == FilmeId
                    select filme).First();
        }

        /// Este método retorna todos os filmes.
        public static List<Filme> GetFilmes()
        {
            var db = new Context();
            return db.Filmes.ToList();
        }

        /// Este método determina a conversão de string.
        public string ToString(bool simple = false)
        {
            if (simple)
            {
                return $"Id: {FilmeId} - Nome: {NomeFilme}";
            }

            var db = new Context();
            int cnt =
                (from filme in db.FilmeLocacao
                 where filme.FilmeId == FilmeId
                 select filme.FilmeId).Count();

            return $"Nome: {NomeFilme}\n" +
                $"Valor: {Valor:C2}\n" +
                $"Quantidade de Locações: {cnt}\n";
        }
    }
}