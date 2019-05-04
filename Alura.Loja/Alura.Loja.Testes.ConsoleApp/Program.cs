using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
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
            //AtualizarUsandoEntityFramework();

            TestandoEstadosDeObjetos();

            Console.WriteLine("Pressione qualquer tecla para continuar. . .");
            Console.ReadLine();
        }

        private static void TestandoEstadosDeObjetos()
        {

            using (var context = new LojaContext())
            {

                //FOR BATCH OPERATIONS
                //context.ChangeTracker.AutoDetectChangesEnabled = false;

                var produtos = context.Produtos.ToList();
                foreach (var p in produtos)
                {
                    Console.WriteLine(p);
                }

                ListEntitiesState(context.ChangeTracker.Entries());

                //var produto = context.Produtos.FirstOrDefault();
                //produto.Nome = produto.Nome + " - Editado";

                //ListEntitiesState(context.ChangeTracker.Entries());

                var novoProduto = new Produto()
                {
                    Nome = "Produto Teste",
                    Categoria = "Teste",
                    Preco = 1.99
                };

                context.Produtos.Add(novoProduto);
                ListEntitiesState(context.ChangeTracker.Entries());
                context.Produtos.Remove(novoProduto);
                ListEntitiesState(context.ChangeTracker.Entries());

                var entry = context.Entry(novoProduto);

                Console.WriteLine("########################################");
                Console.WriteLine($"{entry.Entity.ToString()} - {entry.State}");
                Console.WriteLine("########################################");

                context.SaveChanges();

                ListEntitiesState(context.ChangeTracker.Entries());

            }
        }

        private static void ListEntitiesState(IEnumerable<EntityEntry> Entries)
        {
            Console.WriteLine("============================");
            foreach (var e in Entries)
            {
                Console.WriteLine($"{e.Entity.ToString()} - {e.State}");
            }
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
