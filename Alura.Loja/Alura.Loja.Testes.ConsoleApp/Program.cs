using Microsoft.EntityFrameworkCore;
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
            //TestandoEstadosDeObjetos();

            //RealizaCompra();

            //CriaPromocao();

            //CriaCliente();

            //ListarProdutosDaPromocao();

            //ListarCliente();

            ListarComprasDeUmProduto();

            Console.WriteLine("Pressione qualquer tecla para continuar. . .");
            Console.ReadLine();
        }

        private static void ListarComprasDeUmProduto()
        {
            using (var context = new LojaContext())
            {
                //BUSCA AS COMPRAS DE UM PRODUTO EM APENAS 1 PASSO
                //var comprasDeUmProduto = context.
                //    Compras
                //    .Include(c => c.Produto)
                //    .Where(c => c.Produto.Id == 3002)
                //    .ToList();

                //BUSCA AS COMPRAS DE UM PRODUTO EM APENAS 2 PASSOS
                //BUSCA UM PRODUTO NO BANCO DE DADOS
                var produto = context.Produtos.Where(p => p.Id == 3002).FirstOrDefault();

                context.Entry(produto)
                    .Collection(p => p.Compras)
                    .Query()
                    .Where(c => c.Preco > 1)
                    .Load();

                foreach (var item in produto.Compras)
                {
                    Console.WriteLine($"{item.Produto.Nome}, {item.Preco}");
                }
            }
        }

        private static void ListarCliente()
        {

            using (var context = new LojaContext())
            {
                var cliente = context.Clientes
                    .Include(c => c.EnderecoDeEntrega)
                    .FirstOrDefault();

                Console.WriteLine($"Endereco de Entrega: {cliente?.EnderecoDeEntrega}");
            }
        }

        private static void ListarProdutosDaPromocao()
        {
            //CRIA PRMOCAO PARA TESTE
            //using (var context = new LojaContext())
            //{
            //    Promocao promocao = new Promocao();
            //    promocao.Descricao = "Queima Total";
            //    promocao.DataInicio = new DateTime(2019, 01, 01);
            //    promocao.DataTermino = new DateTime(2019, 01, 31);

            //    var listProdutos = context.Produtos
            //        .Where(p => p.Categoria == "Bebidas")
            //        .ToList();

            //    foreach (var produto in listProdutos)
            //    {
            //        promocao.AddProduto(produto);
            //    }

            //    context.SaveChanges();
                
            //}

            //LISTAR PRODUTOS DA PROMOCAO
            using (var context = new LojaContext())
            {

                //SELECT * FROM PROMOCAO
                //LEFT JOIN PROMOCAO_PRODUTO ON PROMOCAO_PRODUTO.PROMOCAO_ID = PROMOCAO.ID
                //LEFT JOIN PRODUTO ON PROMOCAO_PRODUTO.PRODUTO_ID = PRODUTO.ID

                var promocao = context.Promocoes.
                    Include(promo => promo.Produtos)
                    .ThenInclude(promoProd => promoProd.Produto)
                    .FirstOrDefault();

                Console.WriteLine(promocao.Descricao);
                Console.WriteLine("Listando produtos da promoção");

                foreach (var produto in promocao.Produtos)
                {
                    Console.WriteLine(produto.Produto);
                }
            }
        }

        private static void CriaCliente()
        {
            var cliente = new Cliente();
            cliente.Nome = "Cliente da Silva";
            cliente.EnderecoDeEntrega = new Endereco()
            {
                    Numero = 12,
                    Logradouro = "Rua do Endereço",
                    Complemento = "Casa",
                    Bairro = "Centro"
            };

            using (var context = new LojaContext())
            {
                context.Clientes.Add(cliente);
            }

        }

        private static void CriaPromocao()
        {
            var promocao = new Promocao();
            promocao.Descricao = "Promoção de Páscoa";
            promocao.DataInicio = DateTime.Now.Date;
            promocao.DataTermino = DateTime.Now.Date.AddMonths(3);

            var p1 = new Produto()
            {
                Nome = "Caixa de Bombom",
                Categoria = "Doces",
                PrecoUnitario = 8.9,
                Unidade = "CX"
            };

            promocao.AddProduto(p1);

            using (var context = new LojaContext())
            {
                context.Promocoes.Add(promocao);
                context.SaveChanges();
            }
        }

        private static void RealizaCompra()
        {
            var produto = new Produto()
            {
                Nome = "Pão Francês",
                Unidade = "KG",
                PrecoUnitario = 9.98,
                Categoria = "Padaria"
            };

            var compra = new Compra()
            {
                Produto = produto,
                Qtde = 0.4,
                Preco = 3.99
            };

            using (var context = new LojaContext())
            {
                context.Compras.Add(compra);
                context.SaveChanges();
            }
        }

        private static void TestandoEstadosDeObjetos()
        {

            using (var context = new LojaContext())
            {

                //FOR BATCH OPERATIONS
                //context.ChangeTracker.AutoDetectChangesEnabled = false;

                //FOR UPDATE DATABASE MANUALLY
                //context.Database.Migrate();

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
                    PrecoUnitario = 1.99
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
                    Console.WriteLine($"{produto.Id} | {produto.Nome} | {produto.Categoria} | {produto.PrecoUnitario}");
                }
            }
        }

        private static void GravarUsandoEntityFramework()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.PrecoUnitario = 19.89;

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
            p.PrecoUnitario = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
