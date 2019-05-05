using System;
using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Promocao
    {
        public int Id { get; set; }
        public string Descricao { get; internal set; }
        public DateTime DataInicio { get; internal set; }
        public DateTime DataTermino { get; internal set; }
        public IList<PromocaoProduto> Produtos { get; private set; }

        public Promocao()
        {
            this.Produtos = new List<PromocaoProduto>();
        }

        public void AddProduto(params Produto[] produtos)
        {
            foreach (Produto value in produtos)
            {
                this.Produtos.Add(new PromocaoProduto() { Promocao = this, Produto = value});
            }
        }
    }
}