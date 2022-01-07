using System;

namespace DIO.FilmesHammer
{
    class Program
    {
        static FilmeHRepositorio repositorio = new FilmeHRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarFilmesHammer();
						break;
					case "2":
						InserirFilmesHammer();
						break;
					case "3":
						AtualizarFilmesHammer();
						break;
					case "4":
						ExcluirFilmesHammer();
						break;
					case "5":
						VisualizarFilmesHammer();
						break;
                    case "6":
                        VisualizarHistoriaDaProdutora();
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

        private static void ExcluirFilmesHammer()
		{
			Console.Write("Digite o id do filme Hammer: ");
			int indiceFilmesHammer = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceFilmesHammer);
		}

        private static void VisualizarFilmesHammer()
		{
			Console.Write("Digite o id do filme Hammer: ");
			int indiceFilmesHammer = int.Parse(Console.ReadLine());

			var filmesHammer = repositorio.RetornaPorId(indiceFilmesHammer);

			Console.WriteLine(filmesHammer);
		}

        private static void AtualizarFilmesHammer()
		{
			Console.Write("Digite o id do filme Hammer: ");
			int indiceFilmesHammer = int.Parse(Console.ReadLine());

			
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme Hammer: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Estréia do Filme Hammer: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme Hammer: ");
			string entradaDescricao = Console.ReadLine();

			FilmesHammer atualizaFilmesHammer = new FilmesHammer(id: indiceFilmesHammer,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceFilmesHammer, atualizaFilmesHammer);
		}
        private static void ListarFilmesHammer()
		{
			Console.WriteLine("Listar Filmes Hammer");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma filme Hammer cadastrado.");
				return;
			}

			foreach (var filmesHammer in lista)
			{
                var excluido = filmesHammer.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", filmesHammer.retornaId(), filmesHammer.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirFilmesHammer()
		{
			Console.WriteLine("Inserir novo filme Hammer");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do filme Hammer: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Estréia do filme Hammer: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do filme Hammer: ");
			string entradaDescricao = Console.ReadLine();

			FilmesHammer novoFilmeH = new FilmesHammer(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoFilmeH);
		}

        private static void VisualizarHistoriaDaProdutora(){
            string historico = "Hammer" + Environment.NewLine;
            historico += "Estúdio cinematográfico britânico registado de forma independente em 1949. Contudo, a sua história remonta a 1934, altura em que William Hinds formou a produtora. No mesmo ano, criou, com Enrique Carreras, uma distribuidora com o objetivo de difundir os filmes da Hammer - a Exclusive Films. Em 1935, foi estreado o seu primeiro filme, The Public Life of Henry the Ninth, a que se seguiu The Mystery of the Mary Celeste (1936), a primeira incursão no género de terror que marcaria para sempre a imagem do estúdio." + Environment.NewLine;
            historico += "Durante a Segunda Guerra Mundial, o estúdio esteve parado, ressurgindo em 1947 como subsidiária da Exclusive. Nesta altura, produzia essencialmente curtas-metragens de baixo orçamento, muitas das quais adaptadas de peças radiofónicas da BBC, destacando-se a bem sucedida série com a popular personagem Dick Barton. Em 1949, é finalmente registada como companhia independente, tendo no mesmo ano o seu primeiro filme oficial: Dr. Morelle - The Case of the Missing Heiress. Em 1951, iniciou uma proveitosa colaboração com o produtor norte-americano Robert Lippert que distribuiu os filmes no mercado americano. Em 1955, dá-se um marco na história da Hammer com o lançamento do êxito The Quatermass Xperiment (O Monstro do Espaço), responsável pela definitiva aposta no género de terror. Dois anos depois, surgiu The Curse of Frankenstein, de Terence Fisher, fazendo reviver a famosa personagem do romance de Mary Shelley, seguindo-se The Horror of Drácula, do mesmo realizador, com recurso à personagem de Bram Stoker. Grandes sucessos de bilheteira e de crítica, os dois filmes estabeleceram a reputação do estúdio e iniciaram um hábito que faria voltar a estas personagens por diversas vezes mais tarde, impondo como grandes estrelas do estúdio os nomes de Christopher Lee e Peter Cushing." + Environment.NewLine;
            historico += "Os anos 60 continuaram a ser muito produtivos com filmes como Dracula - Prince of Darkness (1966), Quatermass and the Pit (1967), The Devil Rides Out (1968), ou ainda do gênero de aventuras como She (1965) ou One Million Years BC (Quando o Mundo Nasceu, 1966). Na década de 70, apesar do número elevado de filmes produzidos, o sucesso foi diminuindo com a concorrência da televisão, o esgotamento da fórmula de sucesso e alguma falta de inspiração. Destaca-se a tendência dos vampiros femininos em filmes de forte carga erótica e diversas alusões ao lesbianismo, nomeadamente com a atriz Ingrid Pitt e a sua Carmilla, em The Vampire Lovers (As Amantes do Vampiro, 1970), Lust for a Vampire (1971) e Twins of Evil (1971). Em 1976, a Hammer lançou a sua última produção cinematográfica, To the Devil a Daughter. Em 1979, a companhia foi comprada por Roy Skeggs, que evitou que a marca Hammer se perdesse. Iniciou-se aqui um período de produção de séries para a televisão que terminaria em 1983 com Hammer House of Mystery and Suspense, realizada por alguns dos maiores valores do estúdio como John Hough, Peter Sasdy ou Val Guest." + Environment.NewLine;
            historico += "Apesar de ter visto a sua atividade produtiva suspensa desde essa altura, a companhia foi adquirida no ano 2000 por um consórcio de investidores que afirmam querer fazer renascer a produção do estúdio, relançando a sua imagem para o século XXI." + Environment.NewLine;
            historico += "Fonte: https://www.infopedia.pt/$hammer"  + Environment.NewLine;

            historico += "" + Environment.NewLine;
            Console.WriteLine(historico);
        }
        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Filmes Hammer a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar filmes Hammer");
			Console.WriteLine("2- Inserir novo filme Hammer");
			Console.WriteLine("3- Atualizar filme Hammer");
			Console.WriteLine("4- Excluir filme Hammer");
			Console.WriteLine("5- Visualizar filme Hammer");
            Console.WriteLine("6- Visualizar histórico da produtora Hammer");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
