using AutonomoApp.Business.Models;
using AutonomoApp.Data.Context;
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

            var t23t = db.ServicoCategoria.Where(x => EF.Property<Guid>(x, "CategoriaId") == Guid.Empty).ToList();
            var t2d3t = db.ServicoCategoria.Where(x => EF.Property<Guid>(x, "FKCategoriaAas") == Guid.Empty).ToList();

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

            var servicoUsuario = db.Servico
                .Include(x => x.Prestador)
                .Include(x => x.ServicoCategoria)
                .Include(x => x.ServicoSubCategoria)
                //.Where(x => x.Prestador.Documento == "14494943700")
                //.Select(p => p.Subcategorias.Where( c => c.SubCatEnumId == (int)Tecnologia.DevenvolvimetoBackEnd))
                .Select(x => x)
                .AsNoTracking()
                .First();

            //db.ChangeTracker.Clear();
            List<Servico> servicoAll = db.Servico
                .Include(x => x.Prestador)
                .Include(x => x.ServicoCategoria)
                .ToList();

            var categoriasSubAll = db.Subcategorias
                //.Include(c => c.Subcategorias)
                .ToList();

            List<Categoria> categoriasAll = db.Categorias
                .ToList();

            List<ServicoCategoria> ServicoCategoria = db.ServicoCategoria
                .ToList();

            List<ServicoSubCategoria> ServicoSubCategoria = db.ServicoSubCategoria
                .ToList();
            // refatorar nome de variaveis
            //Console.ReadKey();
        }


    }
}
