// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global

namespace PSLogging.Commands
{
    using System.Management.Automation;

    [Cmdlet(VerbsLifecycle.Disable, "ApplicationInsights")]
    public class DisableApplicationInsightsCommand : PSCmdlet
    {
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            Position = 0)]
        public ApplicationInsightsOutputSubscriber InputObject { get; set; }

        protected override void EndProcessing()
        {
            HostIOInterceptor.Instance.RemoveSubscriber(InputObject);
        }
    }
}

// ReSharper restore MemberCanBePrivate.Global
// ReSharper restore UnusedAutoPropertyAccessor.Global
// ReSharper restore UnusedMember.Global