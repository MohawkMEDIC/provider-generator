/*
 * Copyright 2016-2016 Mohawk College of Applied Arts and Technology
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you 
 * may not use this file except in compliance with the License. You may 
 * obtain a copy of the License at 
 * 
 * http://www.apache.org/licenses/LICENSE-2.0 
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
 * License for the specific language governing permissions and limitations under 
 * the License.
 * 
 * User: khannan
 * Date: 2016-5-15
 */
using System.Web;
using System.Web.Optimization;

namespace ProviderGenerator.Web
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/d3").Include(
						"~/Scripts/d3.v3.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			bundles.Add(new ScriptBundle("~/bundles/providergenerator").Include(
						"~/Scripts/slider.js",
						"~/Scripts/app.js"));

			bundles.Add(new ScriptBundle("~/bundles/moment").Include(
						"~/Scripts/moment.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
						"~/Scripts/toastr.min.js",
						"~/Scripts/toastr-logic.js"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
						"~/Content/bootstrap.min.css",
						"~/Content/bootstrap-theme.min.css",
						"~/Content/styles.css",
						"~/Content/toastr.min.css"));

			BundleTable.EnableOptimizations = true;
		}
	}
}
