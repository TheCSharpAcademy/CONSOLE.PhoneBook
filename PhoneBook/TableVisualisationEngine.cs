using ConsoleTableExt;
using System.Diagnostics.CodeAnalysis;

namespace PhoneBook;

internal class TableVisualisationEngine
{
    internal static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T : class
    {
        if (tableName == null)
            tableName = "";

        Console.WriteLine("\n\n");

        ConsoleTableBuilder
            .From(tableData)
            .WithTitle(tableName)
            .ExportAndWriteLine();

        Console.WriteLine("\n\n");
    }
}
