using System.Text;

namespace Task1;

public class TablePrinter
{
    public static string CreateTable(int n)
    {
        var table = new string[n, n];
        var columnWidth = new int[n];
        columnWidth[0] = 0;
        table[0, 0] = "";

        for (var x = 1; x < n; x++)
        {
            table[0, x] = new Rational(x, n).ToString();
            table[x, 0] = new Rational(x, n).ToString();
            columnWidth[x] = table[0, x].Length;
            columnWidth[0] = Math.Max(columnWidth[0], table[x, 0].Length);
        }
        for (var r = 1; r < n; r++)
            for (var c = 1; c < n; c++)
            {
                var mul = new Rational(r, n) * new Rational(c, n);
                table[r, c] = mul.ToString();
                columnWidth[c] = Math.Max(columnWidth[c], table[r, c].Length);
            }

        var stringBuilder = new StringBuilder();

        void AppendRow(int r)
        {
            for (var c = 0; c < n; c++)
                stringBuilder.Append(table[r, c].PadRight(columnWidth[c], ' ').Append(c == n - 1 ? '\n' : "  ");
        }
        AppendRow(0);
        stringBuilder.AppendLine(new string('-', stringBuilder.Length - 1));
        for (var r = 1; r < n; r++) AppendRow(r);
        return stringBuilder.ToString();
    }

    public static void PrintTable(int n)
        Console.WriteLine(CreateTable(n));
}