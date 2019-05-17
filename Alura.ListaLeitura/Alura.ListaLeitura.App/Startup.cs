using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsProduction() || env.IsStaging())
            {
                app.UseExceptionHandler("/Error");
            }

            var routes = new RouteBuilder(app);

            routes.MapRoute("/Livros/ParaLer", LivrosParaLer);
            routes.MapRoute("/Livros/ParaLer/{id:int}", DetalhesDoLivro);

            routes.MapRoute("/Livros/Lendo", LivrosLendo);
            routes.MapRoute("/Livros/Lendo/{id:int}", DetalhesDoLivro);

            routes.MapRoute("/Livros/Lidos", LivrosLidos);
            routes.MapRoute("/Livros/Lidos/{id:int}", DetalhesDoLivro);

            routes.MapRoute("/Error", ExibePaginaErro);

            app.UseRouter(routes.Build());

            app.Run(async context =>
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("404 - Not Found");
            });


        }

        private Task ExibePaginaErro(HttpContext context)
        {
            context.Response.StatusCode = 500;
            return context.Response.WriteAsync("500 - Internal Server Error");
        }

        public Task DetalhesDoLivro(HttpContext context)
        {

            var id = Convert.ToInt32(context.GetRouteValue("id"));

            var _repo = new LivroRepositorioCSV();
            var livro = _repo.Todos.First(l => l.Id == id);

            return context.Response.WriteAsync(livro.Detalhes());
        }

        private Task LivrosParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.ParaLer.ToString());
        }

        private Task LivrosLendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lendo.ToString());
        }

        private Task LivrosLidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lidos.ToString());
        }

    }
}