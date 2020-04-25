using System;
using View;

namespace blockbusterindicador2
{
    class Programa
    { 
        public static void Main (String[] args){
            int opt;
            do {
                // Menu de opções
                Console.WriteLine ("-------------LOCADORA----------- ");
                Console.WriteLine ("+-------------------------------+");
                Console.WriteLine ("|  Digite a opção desejada      |");
                Console.WriteLine ("+-------------------------------+");
                Console.WriteLine ("|  1 - Cadastrar Cliente        |");
                Console.WriteLine ("|  2 - Cadastrar Filme          |");
                Console.WriteLine ("|  3 - Cadastrar Locação        |");
                Console.WriteLine ("+-------------------------------+");
                Console.WriteLine ("|  4 - Consultar Cliente        |");
                Console.WriteLine ("|  5 - Consultar Filme          |");
                Console.WriteLine ("|  6 - Consultar Locação        |");
                Console.WriteLine ("+-------------------------------+");
                Console.WriteLine ("|  7 - Listar Clientes          |");
                Console.WriteLine ("|  8 - Listar Filmes            |");
                Console.WriteLine ("+-------------------------------+");
                Console.WriteLine ("|  0 - Sair                     |");
                Console.WriteLine ("+-------------------------------+");

                try {
                    opt = Convert.ToInt32 (Console.ReadLine ());
                } catch {
                    Console.WriteLine ("Opção inválida");
                    opt = 99;
                }

                switch (opt) {
                    case 1:
                        ClienteView.CadastrarCliente ();
                        break;
                    case 2:
                        FilmeView.CadastrarFilme ();
                        break;
                    case 3:
                        LocacaoView.CadastrarLocacao ();
                        break;
                    case 4:
                        ClienteView.ConsultarCliente ();
                        break;
                    case 5:
                        FilmeView.ConsultarFilme ();
                        break;
                    case 6:
                        LocacaoView.ConsultarLocacao ();
                        break;
                    case 7:
                        ClienteView.ListarClientes ();     
                        break;
                    case 8:
                        FilmeView.ListarFilmes ();      
                        break;
                }
            } while (opt != 0);
        }
    }
}