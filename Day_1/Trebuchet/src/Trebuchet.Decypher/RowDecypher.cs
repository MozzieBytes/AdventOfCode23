using System.Text.RegularExpressions;

namespace Trebuchet.Decypher;

internal class RowDecypher : IRowDecypher
{
    const string RegexPattern = @"\d";
    public DecypheredRow DecypherRow(string row)
    {
        var matches = Regex.Matches(row, RegexPattern);

        var value = int.Parse($"{matches.First().Value}{matches.Last().Value}");
        return new DecypheredRow(value);
    }
}
