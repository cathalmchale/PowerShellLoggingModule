// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global

namespace PSLogging.Commands
{
    using System.Management.Automation;

    [Cmdlet(VerbsLifecycle.Enable, "ApplicationInsights")]
    public class EnableApplicationInsightsCommand : PSCmdlet
    {
        private ApplicationInsightsOutputSubscriber inputObject;
        private string key;
        private string dateTimeFormat = "r";

        #region Parameters

        [Parameter(ParameterSetName = "AttachExisting",
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true)]
        public ApplicationInsightsOutputSubscriber InputObject
        {
            get { return inputObject; }
            set { inputObject = value; }
        }

        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = "New")]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        [Parameter(ParameterSetName = "New")]
        public string DateTimeFormat
        {
            get { return dateTimeFormat; }
            set { dateTimeFormat = value; }
        }

        #endregion

        protected override void EndProcessing()
        {
            ApplicationInsightsOutputSubscriber subscriber;

            if (ParameterSetName == "New")
            {
                subscriber = new ApplicationInsightsOutputSubscriber(key, dateTimeFormat);
                WriteObject(subscriber);
            }
            else
            {
                subscriber = inputObject;
            }

            HostIOInterceptor.Instance.AttachToHost(Host);
            HostIOInterceptor.Instance.AddSubscriber(subscriber);
        }
    }
}

// ReSharper restore MemberCanBePrivate.Global
// ReSharper restore UnusedAutoPropertyAccessor.Global
// ReSharper restore UnusedMember.Global