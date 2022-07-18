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
                Marshall();
                banco.BuildEntity();
                //Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("CONSOLE: " + e.Message);
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
                $"   # ||    - AutonomoApp Milestone 1 - Build: {DateTime.Now:ddMMyyyy.HHmm}_MRSHLL\n" +
                $"   # ||    \n" +
                $"   # ||    - {DateTime.Now:dddd, dd MMMM yyyy HH:mm:ss}\n" +
                $"   # ||    \n" +
                $"   # ============================================================================================================= #   \n"

                );
        }


    }

}
