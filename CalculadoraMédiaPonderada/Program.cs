using Pessoa;
using System.Linq.Expressions;

internal class Program
{
    static void Main()
    {
        List<Aluno> alunos = new();
        bool looping = true;
        while (looping)
        {
            Console.Clear();
            Console.WriteLine("Selecione uma das opções:");
            Console.WriteLine("1 - Cadastrar um aluno");
            Console.WriteLine("2 - Cadastrar nota a um aluno");
            Console.WriteLine("3 - Cadastrar um aluno com nota");
            Console.WriteLine("4 - Calcular média");
            Console.WriteLine("5 - Verificar nota de um aluno");
            Console.WriteLine("6 - Sair");

            if (int.TryParse(Console.ReadLine(), out int opcaoSelecionada))
            {

                switch (opcaoSelecionada)
                {
                    case 1:
                        alunos.Add(AlunoSemNota());
                        break;

                    case 2:
                        CadastrarNota();
                        break;

                    case 3:
                        alunos.Add(AlunoComNota());
                        break;

                    case 4:
                        CalcularMedia();
                        break;

                    case 5:
                        VerificaNota();
                        break;

                    case 6:
                        looping = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }
        }

        static Aluno AlunoSemNota()
        {
            Console.Clear();
            Console.WriteLine("Digite a matricula: ");
            int.TryParse(Console.ReadLine(), out int matricula);
            Console.WriteLine("Digite um nome");
            string nome = Console.ReadLine();

            Aluno alunos = new Aluno(matricula, nome);
            Console.WriteLine($"Aluno {nome} cadastrado com sucesso!");
            return alunos;
        }

        Aluno? CadastrarNota()
        {
            Console.Clear();

            if (alunos.Count > 0)
            {
                SelecaoAlunos();
                Console.WriteLine("Selecione o aluno desejado para cadatrar a nota:");

                if (int.TryParse(Console.ReadLine(), out int selecao) && selecao -1 < alunos.Count)
                {
                    Console.Clear();

                    Aluno alunoSelecionado = alunos[selecao - 1];
                    Console.WriteLine($"Digite as notas para o aluno {alunoSelecionado.Nome}");
                    Console.WriteLine("Nota da primeira prova: ");
                    double.TryParse(Console.ReadLine(), out double nota1);
                    Console.WriteLine("Nota da segunda prova: ");
                    double.TryParse(Console.ReadLine(), out double nota2);
                    Console.WriteLine("Nota do trabalho: ");
                    double.TryParse(Console.ReadLine(), out double trabalho);
                    alunoSelecionado.AdicionarNota(nota1, nota2, trabalho);

                    Console.WriteLine();
                    Console.WriteLine("Nota adicionada com sucesso!");
                    Console.WriteLine($"Média Final: {alunoSelecionado.NotaFinal}");
                }
                else
                {
                    Console.WriteLine("Opção inválida!");
                };
            }
            else
            {
                Console.WriteLine("Sem alunos cadastrados.");
            }

            Console.ReadKey();
            return null;
        }

        Aluno AlunoComNota()
        {
            Console.Clear();
            Console.WriteLine("Digite a matricula: ");
            int.TryParse(Console.ReadLine(), out int matricula);
            Console.WriteLine("Digite um nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite a nota da primeira prova: ");
            double.TryParse(Console.ReadLine(), out double nota1);
            Console.WriteLine("Digite a nota da segunda prova: ");
            double.TryParse(Console.ReadLine(), out double nota2);
            Console.WriteLine("Digite a nota do trabalho");
            double.TryParse(Console.ReadLine(), out double trabalho);

            Aluno alunos = new Aluno(matricula, nome, nota1, nota2, trabalho);
            Console.WriteLine();
            Console.WriteLine($"A nota final de {nome} é {alunos.NotaFinal}!");
            Console.ReadKey();
            return alunos;
        }
        
        static void CalcularMedia()
        {
            Console.Clear();
            Console.WriteLine("Digite a nota da primeira prova: ");
            double.TryParse(Console.ReadLine(), out double nota1);
            Console.WriteLine("Digite a nota da segunda prova: ");
            double.TryParse(Console.ReadLine(), out double nota2);
            Console.WriteLine("Digite a nota do trabalho");
            double.TryParse(Console.ReadLine(), out double trabalho);

            Console.WriteLine();
            Console.WriteLine($"Nota final: {Aluno.MediaPonderada(nota1, nota2, trabalho)}");
            Console.ReadKey();
        }
        
        void VerificaNota()
        {
            Console.Clear();
            if (alunos.Count > 0)
            {
                SelecaoAlunos();
                Console.WriteLine("Qual aluno para verificar a nota?");

                if (int.TryParse(Console.ReadLine(), out int selecao) && selecao - 1 < alunos.Count)
                {
                    Console.Clear();
                    Console.WriteLine($"Nota final de {alunos[selecao - 1].Nome}, " +
                                      $"matrícula: {alunos[selecao-1].Matricula} " +
                                      $"é {alunos[selecao - 1].NotaFinal}.");
                }
                else
                {
                    Console.WriteLine("Opção inválida!");
                }
            }
            else
            {
                Console.WriteLine("Sem alunos cadastrados.");
            }
            Console.ReadKey();
        }
        
        Aluno? SelecaoAlunos()
        {
            Console.WriteLine("Alunos cadastrados: ");
            for (int i = 0; i < alunos.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {alunos[i].Nome}");
            }
            Console.WriteLine();
            return null;
        }
    }
}