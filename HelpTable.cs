using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
namespace Game
{
    internal class HelpTable
    {
        internal static void GenerateTable(string[] array)
        {
            var table = new Table();

            table.AddColumn("ˇPC/>User");
            foreach (var i in array)
            {
                table.AddColumn(i);
            }

            for (int i = 0; i < array.Length; i++)
            {
                List<string> list = new List<string>();
                list.Add(array[i]);
                for (int j = 0; j < array.Length; j++)
                {
                    string res = Rules.GetWinner(j,i,array.Length);
                    list.Add(res);
                }
                table.AddRow(list.ToArray());
            }

            AnsiConsole.Write(table);
        }

    }

}

