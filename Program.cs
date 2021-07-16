using System;

namespace Gamingflix
{
    class Program
    {
        static GameRepositorio repositorio = new GameRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() != "X")
           {
               switch (opcaoUsuario)
               {
                    case "1":
                        ListarGames();
                        break;
                    case "2":
                        AdicionarGame();
                        break;
                    case "3":
                        AtualizarGame();
                        break;
                    case "4":
                        ExcluirGame();
                        break;
                    case "5":
                        VisualizarGame();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Digite uma opção válida");
               }

               opcaoUsuario = ObterOpcaoUsuario();
           }

            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }

        private static void ListarGames()
        {
            Console.WriteLine("Listar Games:");

            var lista = repositorio.Lista();

                if(lista.Count == 0)
                {
                    Console.WriteLine("Nenhum jogo cadastrado.");
                    return;
                }

            foreach (var game in lista)
            {
                Console.WriteLine("#ID {0}: · {1} {2}", game.retornaID(), game.retornaNome(), game.retornaExcluido() ? "(Excluído)" : "");
            }
        }


         private static void AdicionarGame()
        {
            Console.WriteLine("Adicionar um novo jogo");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine ("{0}·{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Jogo: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Jogo: ");
            string entradaDescri = Console.ReadLine();

            Console.Write("Digite a Classificação Indicatória do Jogo: ");
            ushort entradaClassIndic = ushort.Parse(Console.ReadLine());

            Games novoGame = new Games(repositorio.ProximoId(), (Genero)entradaGenero, entradaNome, entradaDescri, entradaAno, entradaClassIndic);

            repositorio.Insere(novoGame);
        }

       private static void AtualizarGame()
        {
            Console.Write("Digite o id do jogo: ");
            var lista = repositorio.Lista();
             foreach (var game in lista)
            {
                Console.WriteLine("#ID {0}: · {1} {2}", game.retornaID(), game.retornaNome(), game.retornaExcluido() ? "(Excluído)" : "");
            }
            int idGame = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine ("{0}·{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Jogo: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Jogo: ");
            string entradaDescri = Console.ReadLine();

            Console.Write("Digite a Classificação Indicatória do Jogo: ");
            ushort entradaClassIndic = ushort.Parse(Console.ReadLine());

            Games atualizaGame = new Games(idGame, (Genero)entradaGenero, entradaNome, entradaDescri, entradaAno, entradaClassIndic);

            repositorio.Atualiza(idGame, atualizaGame);
        }

        private static void ExcluirGame()
        {
            var lista = repositorio.Lista();
            Console.WriteLine ("Excluir Games:");
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhum jogo cadastrado.");
                return;
            }
          
            Console.WriteLine("Digite o id do jogo: ");
            foreach (var game in lista)
            {
                if (game.retornaExcluido() == false)
                {
                    Console.WriteLine("#ID {0}: · {1} {2}", game.retornaID(), game.retornaNome(), game.retornaExcluido() ? "(Excluído)" : "");
                }
                else 
                return;
            }
            int idGame = int.Parse(Console.ReadLine());
            string resposta = "";

            while (resposta.ToUpper() != "S" && resposta.ToUpper() !=  "N")
            {
            Console.WriteLine("Deseja realmente excluir o jogo a seguir S/N?"+ Environment.NewLine +repositorio.RetornaPorId(idGame)+ Environment.NewLine+ "Digite S para Sim e N para Não: ");
            resposta = Console.ReadLine().ToUpper();
            if (resposta.ToUpper() == "S")
            {
            repositorio.Exclui(idGame);
            Console.WriteLine ("Jogo excluido com sucesso.");
            Console.ReadLine();
            Console.Clear();
            }
            else
            if (resposta.ToUpper() == "N")
            return;
            }
        }

        private static void VisualizarGame()
        {
             var lista = repositorio.Lista();
             if(lista.Count == 0)
            {
                Console.WriteLine("Nenhum jogo cadastrado.");
                return;
            }
          
            Console.WriteLine("Digite o id do jogo: ");
                foreach (var game in lista)
            {
                Console.WriteLine("#ID {0}: · {1} {2}", game.retornaID(), game.retornaNome(), game.retornaExcluido() ? "(Excluído)" : "");
            }
            int idGame = int.Parse(Console.ReadLine());

            var jogo = repositorio.RetornaPorId(idGame);

            Console.WriteLine(jogo);
            Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem-vindo ao GameFlix!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar Games disponíveis");
            Console.WriteLine("2- Adicionar Games");
            Console.WriteLine("3- Atualizar Games");
            Console.WriteLine("4- Excluir Game");
            Console.WriteLine("5- Visualizar Game");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
