using System;
//using Gamingflix.Classes pra importar entidade base

namespace Gamingflix
{
    public class Games : EntidadeBase
    //Atributos
    {
        private Genero Genero { get; set; }
        private string Nome { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private ushort Classfic_indicatoria { get; set; }
        private bool Excluido { get; set; }


        //Construtor
        public Games(int id, Genero genero, string nome, string descri, int ano, ushort idade)
        {
            this.ID = id;
            this.Genero = genero;
            this.Nome = nome;
            this.Descricao = descri;
            this.Ano = ano;
            this.Classfic_indicatoria = idade;
            this.Excluido = false;
        }

        //Metodos

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de lançamento: " + this.Ano + Environment.NewLine;
            retorno += "Classificação Indicatória: " + this.Classfic_indicatoria + Environment.NewLine;
            if (this.Excluido == true)
                retorno += "Excluído: " + this.Excluido + Environment.NewLine;
            return retorno;
        }

        public string retornaNome()
        {
            return this.Nome;
        }

        public int retornaID()
        {
            return this.ID;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Exclui()
        {
            this.Excluido = true;
        }

        //se tem metodo exclui seria uma boa criar um metodo restaurar???
    }


}