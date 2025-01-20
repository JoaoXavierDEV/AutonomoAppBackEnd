using AutonomoApp.ConsoleApp.View;
using AutonomoApp.Framework;
using System;
using static AutonomoApp.ConsoleApp.View.Color;
using static AutonomoApp.ConsoleApp.View.Menu;

namespace AutonomoApp.ConsoleApp;

public class Program
{
    public static bool CloseApp { get; set; }
    public static void Main()
    {
        try
        {
            do
            {
                Header(Art.Octopus, Color.MAGENTA);

                MenuPadrao();

                FecharConsole();

            } while (CloseApp);
        }
        catch (InvalidOperationException e) // when(e.InnerException != null) 
        {
            ShowErrorMessage(e.GetAllMessages());
            //Console.ReadKey();
            // Main();
        }
        catch (Exception e)
        {
            ShowErrorMessage(e.GetAllMessages());
        }
        finally
        {
            Main();
        }

    }

    private static void FecharConsole()
    {
        Console.WriteLine("   # - Deseja sair? S - N");
        string exit = Console.ReadLine();
        CloseApp = exit is "N" or "n";

        Console.WriteLine("   # - Limpar Console? S - N");
        if (string.Equals(Console.ReadLine(), "S", StringComparison.OrdinalIgnoreCase))
            Console.Clear();


        System.Diagnostics.Debug.WriteLine("=> ");

    }

    private static void MenuPadrao()
    {
        Console.WriteLine(
            //$"   # -  # - MENU - \n" +
            $"   # - INSERT \n" +
            $"   # - 1 - Resetar Banco de dados\n" +
            $"   # - 2 - Resetar e Carregar \n" +
            $"   # - 3 - Carregar Usuario Identity \n" +
            $"   # - 4 - Carregar Categorias \n" +
            $"   # - 5 - Carregar Servico \n" +
            $"   # - 6 - Carregar Servico \n" +
            $"   # - GET \n" +
            $"   # - 10 - Get Servico \n" +
            $"   # - 11 - Get Categoria e Subcategorias \n" +
            $"  ===============================================================================================================  \n"
            .PadRight(Console.WindowWidth).PadLeft(Console.WindowWidth));

        InserirDados banco = new();
        string key = Console.ReadLine().ToLower();
        switch (key)
        {
            case "1":
                InserirDados.ResetarDb();
                break;
            case "2":
                banco.BuildEntity();
                break;
            case "3":
                banco.CarregarUsuarioIdentity();
                break;
            case "4":
                banco.CarregarDadosCategorias();
                break;
            case "5":
                banco.CarregarServico();
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

            case "r":
                return;
            default:
                Console.Clear();
                Console.WriteLine($"{Environment.NewLine}   # - {key} - Opção inválida");
                throw new InvalidOperationException("hue");
                break;
        };

        //Console.Clear();

        Console.WriteLine("\n" + GREEN +
            $"   # ============================================================================================================= #   \n" +
            $"   # - OK\n" +
            $"   # ============================================================================================================= #   \n"
            + NORMAL.PadRight(Console.WindowWidth).PadLeft(Console.WindowWidth));
    }









}


