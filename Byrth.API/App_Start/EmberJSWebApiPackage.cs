using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Byrth.API;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(EmberJSWebApiPackage), "PostStart")]
namespace Byrth.API {

    public static class EmberJSWebApiPackage {
		public static void PostStart() {
            var formatters = GlobalConfiguration.Configuration.Formatters;
			formatters.Insert(0, new EmberJsonMediaTypeFormatter());
            var jsonFormatter = formatters.OfType<EmberJsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }

}
