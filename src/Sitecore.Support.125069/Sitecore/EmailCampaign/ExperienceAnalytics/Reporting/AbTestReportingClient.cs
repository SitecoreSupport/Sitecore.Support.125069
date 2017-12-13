using Sitecore.EmailCampaign.ExperienceAnalytics.Reporting;
using System;
using System.Reflection;

namespace Sitecore.Support.EmailCampaign.ExperienceAnalytics.Reporting
{
  #region Original Code
  //public class AbTestReportingClient : ReportingClientBase<AbTestReportingStatistics>
  //{

  //  public AbTestReportingClient() : base(ApiContainer.Repositories.GetReportingService(), Settings.Default.ByAbTestVariantSegmentId)
  //  {
  //  }

  //}
  #endregion Original Code

  #region New Code
  public class AbTestReportingClient : Sitecore.EmailCampaign.ExperienceAnalytics.Reporting.AbTestReportingClient
  {
    public AbTestReportingClient()
    {
      typeof(ReportingClientBase<>).MakeGenericType(new Type[]
      {
                typeof(AbTestReportingStatistics)
      }).GetField("_service", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, new SupportReportingService());
    }
  }
  #endregion New Code
}
