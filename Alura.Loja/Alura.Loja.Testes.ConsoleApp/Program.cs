using System;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            //GravarUsandoEntityFramework();
            //ListarUsandoEntityFramework();
            //RemoverUsandoEntityFramework();
            //ListarUsandoEntityFramework();
            AtualizarUsandoEntityFramework();

            Console.WriteLine("Pressione qualquer tecla para continuar. . .");
            Console.ReadLine();
        }

        private static void AtualizarUsandoEntityFramework()
        {
            using (var context = new ProdutoDAOEntity())
            {
                ListarUsandoEntityFramework();

                var produto = context.Produtos().FirstOrDefault();
                produto.Nome = produto.Nome + " - Editado";
                context.Atualizar(produto);

                ListarUsandoEntityFramework();
            }
        }

        private static void RemoverUsandoEntityFramework()
        {
            using (var context = new ProdutoDAOEntity())
            {
                var produtos = context.Produtos();
                foreach (var produto in produtos)
                {
                    context.Remover(produto);
                }
            }
        }

        private static void ListarUsandoEntityFramework()
        {
            using (var context = new ProdutoDAOEntity())
            {
                var produtos = context.Produtos();
                Console.WriteLine($"{produtos.Count} produto(s) foram encontrados.");
                foreach (var produto in produtos)
                {
                    Console.WriteLine($"{produto.Id} | {produto.Nome} | {produto.Categoria} | {produto.Preco}");
                }
            }
        }

        private static void GravarUsandoEntityFramework()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var context = new ProdutoDAOEntity())
            {
                context.Adicionar(p);
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
