using System.IO.Abstractions;
using Microsoft.Extensions.Options;
using Trebuchet.Core;

namespace Trebuchet.Configuration;

internal class TrebuchetConfigurations : ITrebuchetConfigurations
{
    private readonly IFileSystem _fileSystem;
    private readonly TrebuchetOptions _trebuchetOptions;

    public TrebuchetConfigurations(
        IFileSystem fileSystem,
        IOptions<TrebuchetOptions> trebuchetOptions)
    {
        _fileSystem = fileSystem;
        _trebuchetOptions = trebuchetOptions.Value;
    }

    public async Task<TrebuchetConfiguration> LoadConfiguration()
    {
        var fileContents = await _fileSystem.File.ReadAllLinesAsync(_trebuchetOptions.ConfigurationFilePath);

        return new TrebuchetConfiguration(fileContents);
    }
}
