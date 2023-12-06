using Trebuchet.Core;

namespace Trebuchet.Decypher;
public interface IConfigurationDecypher
{
    CalibrationResult DecypherConfiguration(TrebuchetConfiguration configuration);
}