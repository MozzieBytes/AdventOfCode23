using System.Text.RegularExpressions;
using Trebuchet.Sanitize;

namespace Trebuchet.Decypher;

internal class RowDecypher : IRowDecypher
{
    const string RegexPattern = @"\d";
    public DecypheredRow DecypherRow(SanitizedRow row)
    {
        var matches = Regex.Matches(row.Value, RegexPattern);

        var value = int.Parse($"{matches.First().Value}{matches.Last().Value}");
        return new DecypheredRow(value);
    }
}
