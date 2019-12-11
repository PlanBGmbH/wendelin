namespace Functions.Extensions.Logging
{
    /// <summary>
    /// ESB Specific Keys
    /// </summary>
    internal class Constants
    {
        /// <summary>
        ///     Property name for logging an operation id
        /// </summary>
        internal const string EsbCorrelationTraceName = "EsbCorrelationId";

        /// <summary>
        /// The ESB build number trace
        /// </summary>
        internal const string EsbBuildNumberTraceName = "EsbBuildNumber";

        /// <summary>
        /// The ESB image source trace name
        /// </summary>
        internal const string EsbImageSourceTraceName = "EsbImageSource";

        /// <summary>
        /// The ESB fabric node name trace name
        /// </summary>
        internal const string EsbFabricNodeNameTraceName = "EsbFabricNodeName";

        /// <summary>
        /// The ESB fabric node ip or FQDN trace name
        /// </summary>
        internal const string EsbFabricNodeIPOrFQDNTraceName = "ESBFabricNodeIPOrFQDN";

        /// <summary>
        ///    ESB correlation header name.
        /// </summary>
        internal const string EsbCorrelationHeader = "Esb-Correlation-Id";
    }
}
