using Trebuchet.Core;

namespace Trebuchet.Mediation;
public interface ICalibrationMediator
{
    Task<CalibrationResult> CalibrateTrebuchet(CancellationToken cancellation = default);
}