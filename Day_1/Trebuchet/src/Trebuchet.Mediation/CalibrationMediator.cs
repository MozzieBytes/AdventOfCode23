using Trebuchet.Core;
using Trebuchet.Configuration;
using Trebuchet.Decypher;

namespace Trebuchet.Mediation;

internal class CalibrationMediator : ICalibrationMediator
{
    private readonly ITrebuchetConfigurations _trebuchetConfigurations;
    private readonly IConfigurationDecypher _configurationDecypher;

    public CalibrationMediator(
        ITrebuchetConfigurations trebuchetConfigurations,
        IConfigurationDecypher configurationDecypher)
    {
        _trebuchetConfigurations = trebuchetConfigurations;
        _configurationDecypher = configurationDecypher;
    }

    public async Task<CalibrationResult> CalibrateTrebuchet(CancellationToken cancellationToken = default)
    {
        var configuration = await _trebuchetConfigurations.LoadConfiguration(cancellationToken);
        return _configurationDecypher.DecypherConfiguration(configuration);
    }
}

