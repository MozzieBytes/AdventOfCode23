using Trebuchet.Core;

namespace Trebuchet.Configuration;

public interface ITrebuchetConfigurations
{
    Task<TrebuchetConfiguration> LoadConfiguration();
}