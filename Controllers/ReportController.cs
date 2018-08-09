using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AlanJuden.MvcReportViewer.ExampleWebsite.NetCore.Controllers
{
    public class ReportController : AlanJuden.MvcReportViewer.ReportController
    {
		protected override ICredentials NetworkCredentials
		{
			get
			{
				//Custom Domain authentication (be sure to pull the info from a config file)
				//return new System.Net.NetworkCredential("username", "password", "domain");

				//Default domain credentials (windows authentication)
				return System.Net.CredentialCache.DefaultNetworkCredentials;
			}
		}

		protected override string ReportServerUrl
		{
			get
			{
                //You don't want to put the full API path here, just the path to the report server's ReportServer directory that it creates (you should be able to access this path from your browser: https://YourReportServerUrl.com/ReportServer/ReportExecution2005.asmx )
                //return "http://c40-sf-124/ReportServer";
                  return "http://powells-db/ReportServer_GENACIS2016";
                //return "http://216.12.92.186/ReportServer";


            }
        }

        public ActionResult Index()
        {
            return View();
        }
        public IActionResult MyReport()
        {
            string reportname = string.Empty;
            reportname = "AllWorkOrderReportDetail";
            var model = this.GetReportViewerModel(Request);
            model.ReportPath = "/GenacisQAServer/" + reportname + "";
            model.AddParameter("LogID", "15");
            return View("ReportViewer", model);
        }


        public IActionResult MyReport1()
		{
            //var model = this.GetReportViewerModel(Request);
            //model.ReportPath = "/ReconReports/DeviceStatus";

            //model.AddParameter("CustomerID", "86");
            //model.AddParameter("Active", "1");
            //model.AddParameter("Status", "1");
            //model.AddParameter("ContractorID", "");

            //return View("ReportViewer", model);

            string reportname = string.Empty;
            reportname = "UserListReport";
            var model = this.GetReportViewerModel(Request);
            model.ReportPath = "/Report Project2/" + reportname + "";
            model.AddParameter("CustomerID", "2");
            model.AddParameter("Active", "0");
            model.AddParameter("Status", "2");
            model.AddParameter("StartDate", "2/22/2018");
            model.AddParameter("EndDate", "2/23/2018");
            model.AddParameter("DeviceTypeID", "5,2,1");
            model.AddParameter("StartRowIndex", "1");
            model.AddParameter("ENDRowIndex", "50");
            model.AddParameter("SortID", "DeviceSerialNumber ASC");
            model.AddParameter("TotalRows", "10");

            return View("ReportViewer", model);
        }

        public ActionResult DeviceFC1()
        {
            string reportname = string.Empty;
            reportname = "UserDetail";
            var model = this.GetReportViewerModel(Request);
            model.ReportPath = "/GenacisReports/" + reportname + "";
            //  model.ReportPath = "/Reporttest/" + reportname + "";
            // model.AddParameter("IsCDRUser", "0");
            model.AddParameter("CustomerID", "2");
            //model.ReportPath = "/Reporttest/" + reportname + "";
            //model.AddParameter("CustomerID", "1");
            //model.AddParameter("Active", "0");
            //model.AddParameter("Status", "2");
            //model.AddParameter("StartDate", "2/22/2018");
            //model.AddParameter("EndDate", "2/22/2018");
            //model.AddParameter("DeviceTypeID", "5,2,1");
            //model.AddParameter("StartRowIndex", "1");
            //model.AddParameter("ENDRowIndex", "50");
            //model.AddParameter("SortID", "DeviceSerialNumber ASC");
            //model.AddParameter("TotalRows", "10");

            return View("_ShowReport", model);
        }


    }
}
