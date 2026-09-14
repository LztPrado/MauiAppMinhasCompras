
using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        string _descricao;
        double _quantidade;

        double _valor;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Descricao
        {
            get => _descricao;
            set
            {
                if (value == null)
                {
                    throw new Exception("Descrição não pode ser vazia");
                }

                _descricao = value;
            }
        }

        public double Quantidade
        {
            get => _quantidade;
            set
            {
                if (value == null)
                {
                    throw new Exception("Quantidade não pode ser vazia");
                }

                _quantidade = value;
            }
        }

        public double Preco
        {
            get => _valor;
            set
            {
                if (value == null)
                {
                    throw new Exception("Preço não pode ser vazia");
                }

                _valor = value;
            }
        }

        public string Categoria { get; set; }

        public double Total { get => Quantidade * Preco; }
    }
}
