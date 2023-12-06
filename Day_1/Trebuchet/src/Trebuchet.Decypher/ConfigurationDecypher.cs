using Trebuchet.Core;

namespace Trebuchet.Decypher;
internal class ConfigurationDecypher : IConfigurationDecypher
{
    private readonly IRowDecypher _rowDecypher;

    public ConfigurationDecypher(IRowDecypher rowDecypher)
    {
        _rowDecypher = rowDecypher;
    }

    public CalibrationResult DecypherConfiguration(TrebuchetConfiguration configuration)
    {
        int result = 0;
        foreach (var row in configuration.Rows)
        {
            var decypheredRow = _rowDecypher.DecypherRow(row);
            result += decypheredRow.Value;
        }

        return new CalibrationResult(result);
    }
}
