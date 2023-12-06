using Trebuchet.Core;
using Trebuchet.Sanitize;

namespace Trebuchet.Decypher;
internal class ConfigurationDecypher : IConfigurationDecypher
{
    private readonly IRowSanitizer _rowSanitizer;
    private readonly IRowDecypher _rowDecypher;

    public ConfigurationDecypher(
        IRowSanitizer rowSanitizer,
        IRowDecypher rowDecypher)
    {
        _rowSanitizer = rowSanitizer;
        _rowDecypher = rowDecypher;
    }

    public CalibrationResult DecypherConfiguration(TrebuchetConfiguration configuration)
    {
        int result = 0;
        foreach (var row in configuration.Rows)
        {
            var sanitizedRow = _rowSanitizer.SanitizeRow(row);
            var decypheredRow = _rowDecypher.DecypherRow(sanitizedRow);
            result += decypheredRow.Value;
        }

        return new CalibrationResult(result);
    }
}
