using System;

namespace NightMates.Domain.Interfaces.Services
{
    public interface IAppCenterMetricsService
    {
        void TrackException(Exception exception);
    }
}
