using System;
using static AutonomoApp.ConsoleApp.View.Color;
using static System.Console;

namespace AutonomoApp.ConsoleApp.View;

public static partial class Menu
{
    public static string ImageASCII { get; set; }

    private static readonly string[] separator = new[] { "\n" };

    public static void Header(string imageASCII, string color = null)
    {
        string[] linhas = imageASCII.Split(separator, StringSplitOptions.None);

        color ??= Color.RED;

        for (int i = 0; i < linhas.Length; i++)
        {
            if (linhas[i].Length > 10)
            {
                linhas[i] = "   # ||    " + color + linhas[i].Remove(1, 19) + Color.NORMAL;
            }
        }

        string resultado = string.Join("\n", linhas);

        resultado = resultado.TrimStart('\r').TrimStart('\n').TrimEnd('\r').TrimEnd('\n');

        Console.WriteLine(
           $"\n" +
           $"   # ============================================================================================================= # \n" +
           $"   # ||    ");

        Write(resultado);

        DadosBuild();
    }

    private static void Marshall()
    {
        Console.Title = "CREATE SCHEMA";
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
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
            $"   # ||    - {GREEN}CREATE SCHEMA{NORMAL} \n" +
            $"   # ============================================================================================================= #   \n"


            .PadRight(Console.WindowWidth));
    }

    public static void DadosBuild()
    {
        Console.WriteLine("" + Environment.NewLine +
            $"   # ||    \n" +
            $"   # ||    - AutonomoAppBackEnd {RetornarBranch()} - Build: {DateTime.Now:ddMMyyyy.HHmm}_MRSHLL\n" +
            $"   # ||    \n" +
            $"   # ||    - {DateTime.Now:dddd, dd MMMM yyyy HH:mm:ss}\n" +
            $"   # ||    \n" +
            $"   # ||    - {GREEN}CREATE SCHEMA{NORMAL} \n" +
            $"   # ============================================================================================================= #   \n ");
    }


}
