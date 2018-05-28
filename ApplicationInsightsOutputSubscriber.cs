// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace PSLogging
{
    using System;
    using System.IO;
    using System.Management.Automation;

    public class ApplicationInsightsOutputSubscriber : HostIOSubscriberBase
    {
        private readonly string key;

        public ApplicationInsightsOutputSubscriber(string key, // Azure Application Insights "InstrumentationKey"
                                                   string dateTimeFormat = "r") 
        {
            this.key = key;
            DateTimeFormat = dateTimeFormat;
        }


        #region Properties

        public string DateTimeFormat { get; set; }

        #endregion


        public override void WriteDebug(string message)
        {
            if (string.IsNullOrEmpty(key) ||
                string.IsNullOrEmpty(message))
            {
                return;
            }

            if (message.Trim() != String.Empty)
            {
                message = String.Format("{0,-29} - [D] {1}", DateTime.UtcNow.ToString(DateTimeFormat), message);
            }

            // TODO: Call onto nuget referenced ApplicationInsights dll

        }

        public override void WriteError(string message)
        {
            if (string.IsNullOrEmpty(key) ||
                string.IsNullOrEmpty(message))
            {
                return;
            }

            if (message.Trim() != String.Empty)
            {
                message = String.Format("{0,-29} - [E] {1}", DateTime.UtcNow.ToString(DateTimeFormat), message);
            }

            // TODO: Call onto nuget referenced ApplicationInsights dll

        }

        public override void WriteVerbose(string message)
        {
            if (string.IsNullOrEmpty(key) ||
                string.IsNullOrEmpty(message))
            {
                return;
            }

            if (message.Trim() != String.Empty)
            {
                message = String.Format("{0,-29} - [V] {1}", DateTime.UtcNow.ToString(DateTimeFormat), message);
            }

            // TODO: Call onto nuget referenced ApplicationInsights dll

        }

        public override void WriteWarning(string message)
        {
            if (string.IsNullOrEmpty(key) ||
                string.IsNullOrEmpty(message))
            {
                return;
            }

            if (message.Trim() != String.Empty)
            {
                message = String.Format("{0,-29} - [W] {1}", DateTime.UtcNow.ToString(DateTimeFormat), message);
            }

            // TODO: Call onto nuget referenced ApplicationInsights dll

        }
    }
}

// ReSharper restore MemberCanBePrivate.Global
// ReSharper restore UnusedMember.Global