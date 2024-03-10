using AutonomoApp.Business.Models;
using AutonomoApp.Data.Context;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.EF;

namespace AutonomoApp.ConsoleApp
{
    public static class ObterDados
    {
        public static IQueryable<TAbela> Consultar<TAbela>() where TAbela : EntityBase
        {
            AutonomoAppContext Db = new AutonomoAppContext();
            return Db.Set<TAbela>();
        }

        public static void GetCatSub()
        {
            using AutonomoAppContext db = new AutonomoAppContext();

            var result = Consultar<AutonomoApp.Business.Models.Categoria>()
                .Include(x => x.Subcategorias)
                .ToList();
            // entry.Property("LastUpdated").CurrentValue = DateTime.UtcNow;
            //var tt = db.Subcategorias.Where(x => EF.Property<Guid>(x, "FKSUBCategoria") == Guid.Parse("{a06433e9-9104-4f5f-a08f-c789055754b9}")).ToList();

            var t2t = db.Beneficios.Where(x => EF.Property<Guid>(x, "ContaId") == Guid.Parse("{a06433e9-9104-4f5f-a08f-c789055754b9}")).ToList();



            Console.WriteLine(result.ToString());
        }

        public static void GetServico()
        {
            using AutonomoAppContext db = new AutonomoAppContext();

            //var servicoUsuario = db.Servico
            //    .Include(x => x.Prestador)
            //    //.Include(x => x.Categoria)
            //    //.Include(x => x.Subcategoria)
            //    .Where(x => x.Prestador.Documento == "14494943700")
            //    //.Select(p => p.Subcategorias.Where( c => c.SubCatEnumId == (int)Tecnologia.DevenvolvimetoBackEnd))
            //    .Select(x => x)
            //    .AsNoTracking()
            //    .First();
            
            var Tags = new List<string>() { "aspnet", "microsoft", "petshop", " ", "", " " };
            var TagsResuklt = string.Join(",", Tags.Where(x => !string.IsNullOrWhiteSpace(x)).ToList());


            // teste de remover tags
            string tags = "aspnet,microsoft,petshop, ,, ";
            tags = tags.Replace(" ", "");


            var result = tags.Split(',', StringSplitOptions.RemoveEmptyEntries);

            var re = tags.Replace(" ", string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries).Where(x => x != ""/* && x != null */).ToList();

            var servicoUsuario = db.Servico
                .Include(x => x.ClientePrestador)
                .Include(x => x.Categoria)
                .Include(x => x.Subcategoria)
                //.Where(x => x.Prestador.Documento == "14494943700")
                //.Select(p => p.Subcategorias.Where( c => c.SubCatEnumId == (int)Tecnologia.DevenvolvimetoBackEnd))
                .Select(x => x)
                .AsNoTracking()
                .First();
            string tt = "gfg";

            //tt.IsNullOrEmpty(); //Extensions está no WebAPI

            //db.ChangeTracker.Clear();
            List<Servico> servicoAll = db.Servico
            .Include(x => x.ClientePrestador)
            //  .Include(x => x.ServicoCategoria)
            .ToList();

            var categoriasSubAll = db.Subcategorias
                //.Include(c => c.Subcategorias)
                .ToList();

            List<Categoria> categoriasAll = db.Categorias
                .ToList();


            // refatorar nome de variaveis
            //Console.ReadKey();
        }


    }
}
