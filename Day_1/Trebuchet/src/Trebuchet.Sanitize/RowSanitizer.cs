using Trebuchet.Sanitize.PatternReplacement;

namespace Trebuchet.Sanitize;

internal class RowSanitizer : IRowSanitizer
{
    private readonly IEnumerable<IPatternReplacer> _patternReplacers;

    public RowSanitizer(IEnumerable<IPatternReplacer> patternReplacers)
    {
        _patternReplacers = patternReplacers;
    }

    public SanitizedRow SanitizeRow(string row)
    {
        var sanitizedRow = row;
        foreach(var patternReplacer in _patternReplacers)
        {
            sanitizedRow = patternReplacer.ReplacePattern(sanitizedRow);
        }

        return new SanitizedRow(sanitizedRow);
    }
}
