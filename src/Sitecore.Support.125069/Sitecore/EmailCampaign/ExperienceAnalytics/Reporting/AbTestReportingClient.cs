using Microsoft.CSharp.RuntimeBinder;
using Sitecore.EmailCampaign.ExperienceAnalytics.Properties;
using Sitecore.ExM.Framework.Diagnostics;
using Sitecore.ExperienceAnalytics.Api;
using Sitecore.ExperienceAnalytics.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Sitecore.EmailCampaign.ExperienceAnalytics.Reporting;

namespace Sitecore.EmailCampaign.ExperienceAnalytics.Reporting
{
  #region Original Code
  public class AbTestReportingClient : ReportingClientBase<AbTestReportingStatistics>
  {
    
    public AbTestReportingClient() : base(ApiContainer.Repositories.GetReportingService(), Settings.Default.ByAbTestVariantSegmentId)
    {
    }
   
  }
  #endregion Original Code
}
