using System;

namespace Functions.Extensions.Logging
{
    /// <summary>
    /// Helper Class for Environment Settings
    /// </summary>
    internal class Settings
    {
        public static string GetSetting(string key)
        {
            return Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Process);
        }
    }
}
