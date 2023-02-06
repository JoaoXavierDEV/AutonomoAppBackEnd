using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutonomoApp.Business.Extensions;
using AutonomoApp.Business.Models;
using AutonomoApp.Business.Models.Enums;
using AutonomoApp.Business.Models.Enums.SubCategoriaEnum;
using AutonomoApp.Data.Context;

namespace AutonomoApp.ConsoleApp;

public class Program
{
    public static void Main()
    {
        try
        {
            bool result = true;
            Marshall();
            do
            {
                //InserirDados.ServicosTeste();
                Menu();
                //Console.WriteLine(" Deseja sair? S - N");
                //var exit = Console.ReadLine();
                //result = exit == "N" || exit == "n";
                // Console.Clear();
            } while (result);
        }
        catch (InvalidOperationException e) // when(e.InnerException != null) 
        {
            Console.WriteLine("\n" +
            $"  ===============================================================================================================  \n"
            + "   " + e.Message +
            $"  ===============================================================================================================  \n"
            );//Console.ReadKey();
            Main();
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
        }

    }
    private static void Menu()
    {
        Console.WriteLine(
            $"   # - MENU - \n" +
            $"  INSERT \n" +
            $"  1 - Resetar Banco de dados\n" +
            $"  2 - Resetar AutonomoApp \n" +
            $"  3 - Resetar Identity \n" +
            $"  4 - Carregar Categorias \n" +
            $"  5 - Carregar DadosPessoa \n" +
            $"  6 - Carregar Servico \n" +
            $"  GET \n" +
            $"  10 - Get Servico \n" +
            $"  11 - Get Categoria e Subcategorias \n" +
            $"  ===============================================================================================================  \n"
            );

        var banco = new InserirDados();

        switch (Console.ReadLine())
        {
            case "1":
                InserirDados.ResetarDb();
                break;
            case "2":
                InserirDados.ResetarAutonomoApp();
                break;
            case "3":
                InserirDados.ResetarIdentity();
                break;
            case "4":
                banco.CarregarDadosCategorias();
                break;
            case "5":
                banco.CarregarDadosPessoa();
                break;
            case "6":
                banco.CarregarServico();
                break;
            case "10":

                ObterDados.GetServico();
                break;

            case "11":
                ObterDados.GetCatSub();
                break;

            case "e":
                return;
            default:
                Console.WriteLine("  - Opção inválida");
                break;
        };

        Console.WriteLine("\n" +
            $"   # ============================================================================================================= #   \n" +
            $"   # - OK\n" +
            $"   # ============================================================================================================= #   \n"
            );
    }

    private static void Marshall()
    {
        Console.WriteLine(
            $"\n" +
            $"   # ============================================================================================================= #   \n" +
            $"   # ||    \n" +
            $"   # ||    ███╗   ███╗   █████╗   ██████╗   ███████╗  ██╗  ██╗   █████╗   ██╗       ██╗      \n" +
            $"   # ||    ████╗ ████║  ██╔══██╗  ██╔══██╗  ██╔════╝  ██║  ██║  ██╔══██╗  ██║       ██║      \n" +
            $"   # ||    ██╔████╔██║  ███████║  ██████╔╝  ███████╗  ███████║  ███████║  ██║       ██║      \n" +
            $"   # ||    ██║╚██╔╝██║  ██╔══██║  ██╔══██╗  ╚════██║  ██╔══██║  ██╔══██║  ██║       ██║      \n" +
            $"   # ||    ██║ ╚═╝ ██║  ██║  ██║  ██║  ██║  ███████║  ██║  ██║  ██║  ██║  ███████╗  ███████╗ \n" +
            $"   # ||    ╚═╝     ╚═╝  ╚═╝  ╚═╝  ╚═╝  ╚═╝  ╚══════╝  ╚═╝  ╚═╝  ╚═╝  ╚═╝  ╚══════╝  ╚══════╝ \n" +
            $"   # ||    \n" +
            $"   # ||    - AutonomoAppBackEnd {RetornarBranch()} - Build: {DateTime.Now:ddMMyyyy.HHmm}_MRSHLL\n" +
            $"   # ||    \n" +
            $"   # ||    - {DateTime.Now:dddd, dd MMMM yyyy HH:mm:ss}\n" +
            $"   # ||    \n" +
            $"   # ============================================================================================================= #   \n"


            );
    }
    private enum Branch
    {
        [Description("DEV")]
        Development = 1,
        [Description("PROD")]
        Production,
        [Description("HMG")]
        Staging,
        [Description("PROJECT")]
        Project
    }
    private static string RetornarBranch()
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        Branch descricao = (Branch)Enum.Parse(typeof(Branch), environmentName);
        return descricao.GetEnumDescription();
    }




}


