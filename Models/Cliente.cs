using System;
using System.Collections.Generic;
using Repositories;
using Controllers;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Cliente
    {

        [Key]
        public int ClienteId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime DtNasc { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public int DiasPDevolucao { get; set; }
        public List<Locacao> Locacoes { get; set; }

        public Cliente()
        {
            Locacoes = new List<Locacao>();
        }

        /// Construtor do objeto Cliente.
        public static void CadastrarCliente(string nome, DateTime dtNasc, string cpf, int diaspdevolucao)
        {
            Cliente cliente = new Cliente
            {
                Nome = nome,
                DtNasc = dtNasc,
                Cpf = cpf,
                DiasPDevolucao = diaspdevolucao,
                Locacoes = new List<Locacao>()
            };

            var db = new Context();
            db.Clientes.Add(cliente);
            db.SaveChanges();
        }

        /// Este método insere uma nova locação de filme para o cliente.
        public void CadastrarLocacao(Locacao locacao)
        {
            Locacoes.Add(locacao);
        }

        /// Este método encontra um cliente
        public static Cliente GetCliente(int ClienteId)
        {
            var db = new Context();
            return (from cliente in db.Clientes
                    where cliente.ClienteId == ClienteId
                    select cliente).First();
        }

        /// Este método encontra retornar todos os clientes.
        public static List<Cliente> GetClientes()
        {
            var db = new Context();
            return db.Clientes.ToList();
        }

        /// Este método determina a conversão de string.
        public string ToString(bool simple = false)
        {
            Context db = new Context();
            List<Locacao> LocacoesList = (
                    from locacao in db.Locacoes
                    where locacao.ClienteId == ClienteId
                    select locacao).ToList();

            if (simple)
            {
                string retorno = $"Id: {ClienteId} - Nome: {Nome}\n" +
                    "   Locações: \n";
                if (LocacoesList.Count > 0)
                {
                    LocacoesList.ForEach(
                        locacao => retorno += $"    Id: {locacao.LocacaoId} - " +
                        $"Data: {locacao.DtLocacao} - " +
                        $"Data de Devolução: {LocacaoController.GetDataDevolucao(locacao.DtLocacao, this)}\n"
                    );
                }
                else
                {
                    retorno += "    Não há locações";
                }

                return retorno;
            }

            int qtdFilmes = 0;
            foreach (Locacao locacao in LocacoesList)
            {
                qtdFilmes += (from filme in db.FilmeLocacao
                              where filme.LocacaoId == locacao.LocacaoId
                              select filme).Count();
            }

            string dtNasc = DtNasc.ToString("dd/MM/yyyy");

            return $"Nome: {Nome}\n" +
                $"Data de Nasciment: {dtNasc}\n" +
                $"Qtd de Filmes: {qtdFilmes}";
        }
    }
}