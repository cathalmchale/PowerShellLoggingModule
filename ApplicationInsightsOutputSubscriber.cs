// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace PSLogging
{
    using System;
    using System.IO;
    using System.Management.Automation;

    public class ApplicationInsightsOutputSubscriber : HostIOSubscriberBase
    {
        private readonly TelemetryClient client;

        public ApplicationInsightsOutputSubscriber(string key, // Azure Application Insights "InstrumentationKey"
                                                   string dateTimeFormat = "r") 
        {
            client = new TelemetryClient();
            client.InstrumentationKey = key;
            DateTimeFormat = dateTimeFormat;
        }


        #region Properties

        public string DateTimeFormat { get; set; }

        #endregion


        public override void WriteDebug(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            if (message.Trim() != String.Empty)
            {
                message = String.Format("{0,-29} - [D] {1}", DateTime.UtcNow.ToString(DateTimeFormat), message);
            }

            client.TrackTrace(message, SeverityLevel.Verbose);
        }

        public override void WriteError(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            if (message.Trim() != String.Empty)
            {
                message = String.Format("{0,-29} - [E] {1}", DateTime.UtcNow.ToString(DateTimeFormat), message);
            }

            client.TrackTrace(message, SeverityLevel.Error);
        }

        public override void WriteVerbose(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            if (message.Trim() != String.Empty)
            {
                message = String.Format("{0,-29} - [V] {1}", DateTime.UtcNow.ToString(DateTimeFormat), message);
            }

            client.TrackTrace(message, SeverityLevel.Verbose);
        }

        public override void WriteWarning(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            if (message.Trim() != String.Empty)
            {
                message = String.Format("{0,-29} - [W] {1}", DateTime.UtcNow.ToString(DateTimeFormat), message);
            }

            client.TrackTrace(message, SeverityLevel.Warning);
        }
    }
}

// ReSharper restore MemberCanBePrivate.Global
// ReSharper restore UnusedMember.Global