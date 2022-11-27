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
    public static void Main(string[] args)
    {
        try
        {
            var banco = new InserirDados();
            Marshall();
            banco.BuildEntity();
        }
        catch (Exception e)
        {
            Console.WriteLine("CONSOLE: " + e.Message);
            Console.ReadKey();
        }

    }

    private static void Marshall()
    {
        Console.WriteLine(
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
    internal enum Branch
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
    internal static string RetornarBranch()
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        Branch descricao = (Branch)Enum.Parse(typeof(Branch), environmentName);
        return descricao.GetEnumDescription();
    }




}


