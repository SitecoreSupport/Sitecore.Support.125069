using Sitecore.Analytics.Reporting;
using Sitecore.ExperienceAnalytics.Api;
using Sitecore.ExperienceAnalytics.Api.Query;
using Sitecore.ExperienceAnalytics.Api.Response;
using System;
using System.Reflection;

namespace Sitecore.Support.EmailCampaign.ExperienceAnalytics.Reporting
{
  internal class SupportReportingService : IReportingService
  {
    private static object reportingService;

    private static object aggregationSegmentReader;

    private static object dimensionDefinitionService;

    private static object segmentReader;

    private static object reportDataService;

    private static MethodInfo mGetData;

    private static MethodInfo mExecuteQuery;

    private static Type tLiveReportResponseBuilder;

    private static MethodInfo mGetReportResponse;

    static SupportReportingService()
    {
      SupportReportingService.reportingService = ApiContainer.Repositories.GetReportingService();
      SupportReportingService.aggregationSegmentReader = typeof(ReportQuery).Assembly.GetType("Sitecore.ExperienceAnalytics.Api.ReportingService").GetField("aggregationSegmentReader", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(SupportReportingService.reportingService);
      SupportReportingService.dimensionDefinitionService = typeof(ReportQuery).Assembly.GetType("Sitecore.ExperienceAnalytics.Api.ReportingService").GetField("dimensionDefinitionService", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(SupportReportingService.reportingService);
      SupportReportingService.segmentReader = typeof(ReportQuery).Assembly.GetType("Sitecore.ExperienceAnalytics.Api.ReportingService").GetField("segmentReader", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(SupportReportingService.reportingService);
      SupportReportingService.reportDataService = typeof(ReportQuery).Assembly.GetType("Sitecore.ExperienceAnalytics.Api.ReportingService").GetField("reportDataService", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(SupportReportingService.reportingService);
      SupportReportingService.mGetData = typeof(ReportQuery).Assembly.GetType("Sitecore.ExperienceAnalytics.Api.Query.QueryData.ReportQueryExtensions").GetMethod("GetData", new Type[]
      {
                typeof(ReportQuery)
      });
      SupportReportingService.mExecuteQuery = typeof(ReportQuery).Assembly.GetType("Sitecore.ExperienceAnalytics.Api.ReportDataService").GetMethod("ExecuteQuery");
      SupportReportingService.tLiveReportResponseBuilder = typeof(ReportQuery).Assembly.GetType("Sitecore.ExperienceAnalytics.Api.Response.ReportResponseData.LiveReportResponseBuilder");
      SupportReportingService.mGetReportResponse = SupportReportingService.tLiveReportResponseBuilder.GetMethod("GetReportResponse");
    }

    public ReportResponse RunQuery(ReportQuery reportQuery)
    {
      object obj = SupportReportingService.mGetData.Invoke(reportQuery, new object[]
      {
                reportQuery
      });
      object obj2 = SupportReportingService.mExecuteQuery.Invoke(SupportReportingService.reportDataService, new object[]
      {
                obj,
                CachingPolicy.WithCacheDisabled
      });
      object obj3 = SupportReportingService.tLiveReportResponseBuilder.GetConstructors()[0].Invoke(new object[]
      {
                SupportReportingService.dimensionDefinitionService,
                SupportReportingService.aggregationSegmentReader,
                SupportReportingService.segmentReader,
                obj,
                obj2
      });
      return (ReportResponse)SupportReportingService.mGetReportResponse.Invoke(obj3, new object[0]);
    }
  }
}