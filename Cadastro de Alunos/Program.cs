using System.Xml.Linq;
using Cadastro_de_Alunos;

List<Aluno> listaAlunos = new List<Aluno>();

while (true)
{
    try
    {
        Console.WriteLine("Digite uma opção:");
        Console.WriteLine("1 - Adicionar nome");
        Console.WriteLine("2 - Remover nome");
        Console.WriteLine("3 - Listar nomes");
        Console.WriteLine("4 - Listar nomes em ordem");
        Console.WriteLine("5 - Buscar aluno por CPF");
        Console.WriteLine("6 - Encerrar");

        string PrimeiroValor = Console.ReadLine();
        int OrdemUsuario = int.Parse(PrimeiroValor);

        if (OrdemUsuario == 1)
        {
            Console.WriteLine("Digite seu CPF (somente números):");
            string CpfAdicionar = Console.ReadLine();

            bool cpfExiste = listaAlunos.Any(a => a.Cpf == CpfAdicionar);

            if (cpfExiste)
            {
                Console.WriteLine("Já existe um aluno com esse CPF.");
                continue;
            }

            Console.WriteLine("Digite um nome:");
            string AddNome = Console.ReadLine();

            Console.WriteLine("Digite a idade");
            string dataString = Console.ReadLine();
            int AddData = int.Parse(dataString);

            Aluno novoAluno = new Aluno(CpfAdicionar, AddNome, AddData);
            listaAlunos.Add(novoAluno);

            Console.WriteLine("Aluno adicionado com sucesso.");
        }
        else if (OrdemUsuario == 2)
        {
            Console.WriteLine("Digite o CPF do aluno a ser removido:");
            string RemoveCPF = Console.ReadLine();

            Aluno? alunoEncontrado = listaAlunos.Find(a => a.Cpf == RemoveCPF);

            if (alunoEncontrado != null)
            {
                listaAlunos.Remove(alunoEncontrado);
                Console.WriteLine($"{alunoEncontrado.Nome} com CPF {RemoveCPF} removido.");
            }
            else
            {
                Console.WriteLine($"Aluno com CPF {RemoveCPF} não encontrado.");
            }
        }
        else if (OrdemUsuario == 3)
        {
            var alunosDTO = listaAlunos
                .Select(a => new AlunoResponse
                {
                    Nome = a.Nome,
                    Idade = a.Idade
                }).ToList();

            Console.WriteLine("\nLista de alunos cadastrados:");
            foreach (var aluno in alunosDTO)
            {
                Console.WriteLine($"Nome: {aluno.Nome}, Idade: {aluno.Idade}");
            }
            Console.WriteLine();

        }
        else if (OrdemUsuario == 4)
        {
            Console.WriteLine("deseja ordenar por nome ou idade?");
            string TipoOrder = Console.ReadLine();
            if (TipoOrder == "nome" || TipoOrder == "Nome")
            {
                var resultado = listaAlunos
                .OrderBy(a => a.Nome)
                .Select(a => new AlunoResponse
                {
                    Nome = a.Nome,
                    Idade = a.Idade
                });
                foreach (var aluno in resultado)
                {
                    Console.WriteLine($"Nome: {aluno.Nome}, Idade: {aluno.Idade}");
                }
            }
            else if (TipoOrder == "idade" || TipoOrder == "Idade")
            {
                var resultado = listaAlunos
                .OrderBy(a => a.Idade)
                .Select(a => new AlunoResponse
                {
                    Nome = a.Nome,
                    Idade = a.Idade
                });
                foreach (var aluno in resultado)
                {
                    Console.WriteLine($"Idade: {aluno.Idade}, Nome: {aluno.Nome}");
                }

            }





        }
        else if (OrdemUsuario == 5)
        {
            Console.WriteLine("Digite seu CPF (somente números):");
            string CpfAdicionar = Console.ReadLine();


            Aluno? alunoEncontrado = listaAlunos.FirstOrDefault(a => a.Cpf == CpfAdicionar);

            var alunoDTO = new AlunoDetalhadoResponse
            {
                Nome = alunoEncontrado.Nome,
                Idade = alunoEncontrado.Idade,
                Cpf = alunoEncontrado.Cpf,
                Id = alunoEncontrado.Id
            };

            Console.WriteLine("\nAluno encontrado:");
            Console.WriteLine($"Nome: {alunoDTO.Nome}");
            Console.WriteLine($"Idade: {alunoDTO.Idade}");
            Console.WriteLine($"CPF: {alunoDTO.Cpf}");
            Console.WriteLine($"Id: {alunoDTO.Id}");




        }
        else if (OrdemUsuario == 6)
        {
            Console.WriteLine("Encerrando o programa...");
            break;
        }
        else
        {
            Console.WriteLine("Opção inválida.");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Erro: formato inválido de número. Tente novamente.");
    }
}
