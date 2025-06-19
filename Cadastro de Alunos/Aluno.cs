using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_de_Alunos
{
    public class Aluno
    {
        public Guid Id { get; set; }
        public string Cpf;
        public string Nome;
        public int Idade;

        public Aluno(string CpfAdicioanr, string addNome, int addData)
        {
            this.Id = Guid.NewGuid();
            this.Cpf = CpfAdicioanr;
            this.Nome = addNome;
            this.Idade = addData;
        }

    }

}
