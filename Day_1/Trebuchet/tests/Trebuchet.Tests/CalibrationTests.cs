using System.IO.Abstractions;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NSubstitute;
using Trebuchet.Configuration;
using Trebuchet.Mediation;
using Trebuchet.Tests.Helpers;

namespace Trebuchet.Tests;

public class CalibrationTests
{
    [Theory]
    [InlineData("two1nine", 29)]
    [InlineData("eightwothree", 83)]
    [InlineData("abcone2threexyz", 13)]
    [InlineData("xtwone3four", 24)]
    [InlineData("4nineeightseven2", 42)]
    [InlineData("zoneight234", 14)]
    [InlineData("7pqrstsixteen", 76)]
    public async Task GIVEN_Single_input_THEN_Returns_expected_single_output(string input, int expectedResult)
    {
        var serviceProvider = TestServiceProvider.ServiceProvider;

        var file = Substitute.For<IFile>();
        var fileSystem = serviceProvider.GetRequiredService<IFileSystem>();
        var options = serviceProvider.GetRequiredService<IOptions<TrebuchetOptions>>().Value;
        fileSystem.File.Returns(file);
        file
            .ReadAllLinesAsync(options.ConfigurationFilePath, CancellationToken.None)
            .Returns(Task.FromResult(new[] { input }));

        var sut = serviceProvider.GetRequiredService<ICalibrationMediator>();

        var result = await sut.CalibrateTrebuchet(CancellationToken.None);

        result.Should().Be(expectedResult);
    }

    [Theory]
    [InlineData(new[] { "two1nine", "eightwothree", "abcone2threexyz", "xtwone3four", "4nineeightseven2", "zoneight234", "7pqrstsixteen" }, 281)]
    public async Task GIVEN_Multi_line_input_THEN_Returns_expected_total_output(string[] input, int expectedResult)
    {
        var serviceProvider = TestServiceProvider.ServiceProvider;

        var file = Substitute.For<IFile>();
        var fileSystem = serviceProvider.GetRequiredService<IFileSystem>();
        var options = serviceProvider.GetRequiredService<IOptions<TrebuchetOptions>>().Value;
        fileSystem.File.Returns(file);
        file
            .ReadAllLinesAsync(options.ConfigurationFilePath, CancellationToken.None)
            .Returns(Task.FromResult(input));

        var sut = serviceProvider.GetRequiredService<ICalibrationMediator>();

        var result = await sut.CalibrateTrebuchet(CancellationToken.None);

        result.Should().Be(expectedResult);
    }
}