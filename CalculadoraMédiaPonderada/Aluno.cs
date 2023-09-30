using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Pessoa
{
    internal class Aluno
    {
        private int matricula;
        private string nome;
        private double nota1;
        private double nota2;
        private double trabalho;

        private double notaFinal => MediaPonderada(nota1, nota2, trabalho);
        internal string Nome => nome;
        internal double NotaFinal => notaFinal;

        /// <summary>
        /// Cria o objeto com todas as informações preenchidas.
        /// </summary>
        /// <param name="matricula"></param>
        /// <param name="nome"></param>
        /// <param name="nota1"></param>
        /// <param name="nota2"></param>
        /// <param name="trabalho"></param>
        public Aluno(int matricula, string nome, double nota1, double nota2, double trabalho)
        {
            this.matricula = matricula;
            this.nome = nome;
            this.nota1 = nota1;
            this.nota2 = nota2;
            this.trabalho = trabalho;
        }

        /// <summary>
        /// Cria o objeto com matricula e nome preenchidos.
        /// </summary>
        /// <param name="matricula"></param>
        /// <param name="nome"></param>
        public Aluno(int matricula, string nome)
        {
            this.matricula = matricula;
            this.nome = nome;
        }

        /// <summary>
        /// Calcula a média final do aluno sem a necessidade de armazenar os dados.
        /// </summary>
        /// <param name="nota1"></param>
        /// <param name="nota2"></param>
        /// <param name="trabalho"></param>
        /// <returns></returns>
        public static double MediaPonderada(double nota1, double nota2, double trabalho) {
            double notaFinal = double.Parse(((nota1*2.5 + nota2*2.5 + trabalho*2)/(2.5+2.5+2)).ToString("F"));
            return notaFinal;
        }

        /// <summary>
        /// Adiciona nota ao objeto.
        /// </summary>
        /// <param name="nota1"></param>
        /// <param name="nota2"></param>
        /// <param name="trabalho"></param>
        internal void AdicionarNota(double nota1, double nota2, double trabalho)
        {
            { this.nota1 = nota1; }
            { this.nota2 = nota2; }
            { this.trabalho = trabalho; }
        }

    }
}
