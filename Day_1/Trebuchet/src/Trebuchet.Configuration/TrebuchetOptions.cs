namespace Trebuchet.Configuration;
public record TrebuchetOptions
{
    public string ConfigurationFilePath { get; init; } = default!;
}
