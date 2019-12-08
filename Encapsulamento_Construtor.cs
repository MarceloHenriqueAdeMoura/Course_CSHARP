using System;

namespace OO5
{
    class Produto
    {
        private string _nome;
        private double _preco;
        private int _quantidade;
        //auto properties
        //public double Preco { get; private set; }
        //public int Quantidade { get; private set; }
        
        public Produto(){            
            _quantidade = 0;
        }

        //recebe o contrutor padrao [com a inicializaçao da quantidade = 0]
        public Produto(string nome, double preco) : this()
        {
            _nome = nome;
            _preco = preco;
        }

        //recebe o construtor com dois argumentos [reaproveita o contrutor com dois argumentos]
        public Produto(string nome, double preco, int quantidade) : this(nome, preco)
        {
            _quantidade = quantidade;
        }

        public string GetNome(){
            return _nome;
        }

        public void SetNome(string nome){
            if(_nome != null && _nome.Length > 1){
                _nome = nome;
            }
        }
        
        // Get e Set em C# como Properties (Propriedades)
        public string Nome {
            get { return _nome; }
            set { if(value != null && value.Length > 1){
                _nome = value;
            }
            }
        }

        public double GetPreco(){
            return _preco;
        }

        public double Preco{
            get{ return _preco; }
        }

        public GetQuantidade(){
            return _quantidade;
        }

        public int Quantidade {
            get { return _quantidade; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}