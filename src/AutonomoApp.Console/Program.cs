using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutonomoApp.Business.Models;
using AutonomoApp.Business.Models.Enums;
using AutonomoApp.Business.Models.Enums.SubCategoriaEnum;
using AutonomoApp.Data.Context;

namespace AutonomoApp.ConsoleApp

{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var banco = new InserirDados();
                

                Console.WriteLine("Buildddddd");


                //EnsureCreatedAndDeleted(db);

                //banco.CarregarDadosCategorias();
                banco.ResetarDB();
                //HealthCheckBancoDeDados();
                //TesteFunc();
                //Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }

        }
        static void EnsureCreatedAndDeleted(AutonomoAppContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
        static void HealthCheckBancoDeDados()
        {
            using var db = new AutonomoAppContext();
            var canConnect = db.Database.CanConnect();
            Console.WriteLine(canConnect ? "Posso me conectar" : "Não posso me conectar");
        }



        static void TesteFunc()
        {

            Console.ReadKey();

        }


    }

    public record struct DadosDTO(string rua)
    {
        public string Nome = string.Empty;
    };


}
