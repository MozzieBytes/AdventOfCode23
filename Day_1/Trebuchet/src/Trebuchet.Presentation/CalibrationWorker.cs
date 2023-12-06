using Trebuchet.Mediation;

namespace Trebuchet.Presentation;

public class CalibrationWorker : BackgroundService
{
    private readonly ILogger<CalibrationWorker> _logger;
    private readonly ICalibrationMediator _calibrationMediator;

    public CalibrationWorker(
        ILogger<CalibrationWorker> logger,
        ICalibrationMediator calibrationMediator)
    {
        _logger = logger;
        _calibrationMediator = calibrationMediator;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var result = await _calibrationMediator.CalibrateTrebuchet();

        _logger.LogInformation($"{nameof(CalibrationWorker)} - Finished calibration: {result.Value}");
    }
}
