using System;

namespace DIO.Series
{
    public class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static AnimeRepositorio repositorioAnime = new AnimeRepositorio();
        static void Main(string[] args)
        {
            string opcaoTipoLista = EscolhaTipoLista();

            if (opcaoTipoLista == "1")
            {
                EscolhaSerie();
            }
            else if (opcaoTipoLista == "2")
            {
                EscolhaAnime();
            }
            else
            {
                Console.WriteLine("Informe uma opção válida");
                return;
            }
        }

        private static string EscolhaTipoLista()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries e Animes ao seu dispor!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Séries");
            Console.WriteLine("2 - Animes");
            Console.WriteLine("X - Sair");

            string opcaoTipoLista = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoTipoLista;
        }

        private static void EscolhaSerie()
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var exluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (exluido ? "**Excluido**" : ""));
            }
        }

        private static void AtualizarSeries()
        {
            Console.Write("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(id: indiceSerie,
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void InserirSeries()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.ProximoId(),
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static void ExcluirSeries()
        {
            Console.Write("Digite o Id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSeries()
        {
            Console.Write("Digite o Id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void EscolhaAnime()
        {
            string opcaoUsuarioAnime = ObterOpcaoUsuarioAnime();

            while (opcaoUsuarioAnime.ToUpper() != "X")
            {
                switch (opcaoUsuarioAnime)
                {
                    case "1":
                        ListarAnimes();
                        break;
                    case "2":
                        InserirAnimes();
                        break;
                    case "3":
                        AtualizarAnimes();
                        break;
                    case "4":
                        ExcluirAnimes();
                        break;
                    case "5":
                        Visualizaranimes();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                    opcaoUsuarioAnime = ObterOpcaoUsuarioAnime();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarAnimes()
        {
            Console.WriteLine("Listar animes");

            var listaAnime = repositorioAnime.Lista();

            if (listaAnime.Count == 0)
            {
                Console.WriteLine("Nenhuma Anime cadastrado.");
                return;
            }

            foreach (var anime in listaAnime)
            {
                var exluido = anime.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} - {2}", anime.retornaId(), anime.retornaTitulo(), (exluido ? "**Excluido**" : ""));
            }
        }

        private static void AtualizarAnimes()
        {
            Console.Write("Digite o id da Anime: ");
            int indiceAnime = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título do Anime: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início do Anime: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição do Anime: ");
            string entradaDescricao = Console.ReadLine();

            Anime atualizaAnime = new Anime(id: indiceAnime,
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);

            repositorioAnime.Atualiza(indiceAnime, atualizaAnime);
        }

        private static void InserirAnimes()
        {
            Console.WriteLine("Inserir novo anime");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título do Anime: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início do Anime: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição do Anime: ");
            string entradaDescricao = Console.ReadLine();

            Anime novoAnime = new Anime(id: repositorioAnime.ProximoId(),
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);

            repositorioAnime.Insere(novoAnime);
        }

        private static void ExcluirAnimes()
        {
            Console.Write("Digite o Id do anime: ");
            int indiceAnime = int.Parse(Console.ReadLine());

            repositorioAnime.Exclui(indiceAnime);
        }

        private static void Visualizaranimes()
        {
            Console.Write("Digite o Id do Anime: ");
            int indiceAnime = int.Parse(Console.ReadLine());

            var anime = repositorioAnime.RetornaPorId(indiceAnime);

            Console.WriteLine(anime);
        }

        private static string ObterOpcaoUsuarioAnime()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar Animes");
            Console.WriteLine("2 - Inserir um novo Anime");
            Console.WriteLine("3 - Atualizar Anime");
            Console.WriteLine("4 - Excluir Anime");
            Console.WriteLine("5 - Visualizar Anime");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuarioAnime = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuarioAnime;
        }
    }
}