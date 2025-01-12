using AutonomoApp.Framework;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutonomoApp.ConsoleApp.View.Color;

namespace AutonomoApp.ConsoleApp.View
{
    public static partial class Menu
    {
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
        public static string RetornarBranch()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Branch descricao = (Branch)Enum.Parse(typeof(Branch), environmentName);
            return descricao.GetEnumDescription();
        }

        public static void ShowErrorMessage(string msg)
        {
            Console.WriteLine("\n" + RED +
            $"  ===============================================================================================================  \n"
            + "  " + msg + System.Environment.NewLine +
            $"  ===============================================================================================================  \n"
             + NORMAL);
        }
        
        public static void ShowSucessMessage(string msg)
        {
            Console.WriteLine("\n" + GREEN +
            $"  ===============================================================================================================  \n"
            + "  " + msg + System.Environment.NewLine +
            $"  ===============================================================================================================  \n"
             + NORMAL);
        }
    }
}
