using System.Text.RegularExpressions;

namespace Trebuchet.Sanitize.PatternReplacement;
internal abstract class BasePatternReplacer : IPatternReplacer
{
    private readonly string _pattern;
    private readonly string _replacement;

    protected BasePatternReplacer(string pattern, string replacement)
    {
        _pattern = pattern;
        _replacement = replacement;
    }

    public string ReplacePattern(string row)
    {
        return Regex.Replace(row, _pattern, _replacement);
    }
}
