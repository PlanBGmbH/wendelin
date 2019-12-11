using Microsoft.Extensions.Logging;

namespace Functions.Extensions.Logging
{
    /// <summary>
    /// Class for Logging ESB specific events.
    /// </summary>
    public static class LoggerEvents
    {
        public static EventId SplittingStarted = new EventId(100, nameof(SplittingStarted));
        public static EventId SplittingSucceeded = new EventId(101, nameof(SplittingSucceeded));
        public static EventId SplittingPartiallyFailed = new EventId(102, nameof(SplittingPartiallyFailed));
        public static EventId SplittingFailed = new EventId(103, nameof(SplittingFailed));
        public static EventId SplittingFinished = new EventId(199, nameof(SplittingFinished));

        public static EventId DistributionStarted = new EventId(200, nameof(DistributionStarted));
        public static EventId DistributionAccepted = new EventId(201, nameof(DistributionAccepted));
        public static EventId DistributionRejected = new EventId(202, nameof(DistributionRejected));
        public static EventId DistributionFinished = new EventId(299, nameof(DistributionFinished));

        public static EventId PushStarted = new EventId(300, nameof(PushStarted));
        public static EventId PushSucceeded = new EventId(301, nameof(PushSucceeded));
        public static EventId PushFailed = new EventId(302, nameof(PushFailed));
        public static EventId PushFinished = new EventId(399, nameof(PushFinished));

        public static EventId InvalidContent = new EventId(400, nameof(InvalidContent));
        public static EventId MissingTargetUrl = new EventId(401, nameof(MissingTargetUrl));
        public static EventId MissingTargetSubscriptionKey = new EventId(402, nameof(MissingTargetSubscriptionKey));
        public static EventId TargetNotAvailable = new EventId(403, nameof(TargetNotAvailable));

        public static EventId UnexpectedException = new EventId(500, nameof(UnexpectedException));
    }
}
