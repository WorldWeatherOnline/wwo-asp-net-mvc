using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WorldWeatherOnline;

namespace AspNetMvcExample.Controllers
{
	public class HomeController : Controller
	{
		static Api api = null;
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Local()
		{
			return View();
		}

		public ActionResult Ski()
		{
			return View();
		}

		public ActionResult Search()
		{
			return View();
		}

		public ActionResult Timezones()
		{
			return View();
		}

		public ActionResult Marine()
		{
			return View();
		}

		public ActionResult PastMarine()
		{
			return View();
		}

		public ActionResult Historical()
		{
			return View();
		}

		public ActionResult Contact()
		{
			return View();
		}

		[System.Web.Mvc.HttpPost]
		public JsonResult UpdateKey([FromBody]string key)
		{
			api = api ?? new Api(key);
			api.Key = key;
			return Json("ok");
		}

		[System.Web.Mvc.HttpPost]
		public async Task<ActionResult> GetLocalWeather([FromBody]string loc, [FromBody] int days)
		{
			// example of request with all possible options enabled
			//var res = await api.BuildLocalWeatherQuery(loc)
			//	.WithNumOfDays(4)
			//	.WithConditions(true)
			//	.WithDate(DateTime.Today)
			//	.WithDateFormat(LocalWeatherQuery.DateFormatOptions.ISO8601)
			//	.WithForecast(true)
			//	.WithIncludeLocation(true)
			//	.WithInterval(LocalWeatherQuery.IntervalOptions.THREE_HOURS)
			//	.WithIsDayTime(true)
			//	.WithLocalObsTime(true)
			//	.WithMap(true)
			//	.WithThreeHourInterval(true)
			//	.WithUtcDateTime(true)
			//	.WithMonthlyAverage(true)
			//	.GetResult();

			// example of minimal request
			var res = await api.BuildLocalWeatherQuery(loc)
				.WithNumOfDays(days)
				.WithIncludeLocation(true)
				.GetResult();

			// serialize and send to client
			var ret = JsonConvert.SerializeObject(res, Formatting.Indented,
				 new JsonSerializerSettings
				 {
					 DateFormatHandling = DateFormatHandling.IsoDateFormat
				 });
			return Content(ret, "application/json");
		}

		[System.Web.Mvc.HttpPost]
		public async Task<ActionResult> GetPastWeather([FromBody]string loc, [FromBody] DateTime date, [FromBody] DateTime enddate)
		{
			// example of request with all possible options enabled
			//var res = await api.BuildPastWeatherQuery(loc, DateTime.Today)
			//	.WithEnddate(DateTime.Today.AddDays(3))
			//	.WithIncludeLocation(true)
			//	.WithIsDayTime(true)
			//	.WithUtcDateTime(true)
			//	.GetResult();

			// example of minimal request
			var res = await api.BuildPastWeatherQuery(loc, date)
				.WithEnddate(enddate)
				.WithIncludeLocation(true)
				.GetResult();

			// serialize and send to client
			var ret = JsonConvert.SerializeObject(res, Formatting.Indented,
				 new JsonSerializerSettings
				 {
					 DateFormatHandling = DateFormatHandling.IsoDateFormat
				 });
			return Content(ret, "application/json");
		}

		[System.Web.Mvc.HttpPost]
		public async Task<ActionResult> GetMarineWeather([FromBody]string loc)
		{
			// example of minimal request
			var res = await api.BuildMarineWeatherQuery(loc)
				.WithIncludeLocation(true)
				.GetResult();

			// serialize and send to client
			var ret = JsonConvert.SerializeObject(res, Formatting.Indented,
				 new JsonSerializerSettings
				 {
					 DateFormatHandling = DateFormatHandling.IsoDateFormat
				 });
			return Content(ret, "application/json");
		}

		[System.Web.Mvc.HttpPost]
		public async Task<ActionResult> GetPastMarineWeather([FromBody]string loc, [FromBody] DateTime date, [FromBody] DateTime enddate)
		{
			// example of minimal request
			var res = await api.BuildPastMarineWeatherQuery(loc, date)
				.WithEnddate(enddate)
				.WithIncludeLocation(true)
				.GetResult();

			// serialize and send to client
			var ret = JsonConvert.SerializeObject(res, Formatting.Indented,
				 new JsonSerializerSettings
				 {
					 DateFormatHandling = DateFormatHandling.IsoDateFormat
				 });
			return Content(ret, "application/json");
		}

		[System.Web.Mvc.HttpPost]
		public async Task<ActionResult> GetSkiWeather([FromBody]string loc, [FromBody]int days)
		{
			// example of minimal request
			var res = await api.BuildSkiWeatherQuery(loc, days)
				.WithIncludeLocation(true)
				.GetResult();

			// serialize and send to client
			var ret = JsonConvert.SerializeObject(res, Formatting.Indented,
				 new JsonSerializerSettings
				 {
					 DateFormatHandling = DateFormatHandling.IsoDateFormat
				 });
			return Content(ret, "application/json");
		}

		[System.Web.Mvc.HttpPost]
		public async Task<ActionResult> SearchWeather([FromBody]string loc)
		{
			// example of minimal request
			var res = await api.BuildSearchWeatherQuery(loc)
				.GetResult();

			// serialize and send to client
			var ret = JsonConvert.SerializeObject(res, Formatting.Indented,
				 new JsonSerializerSettings
				 {
					 DateFormatHandling = DateFormatHandling.IsoDateFormat
				 });
			return Content(ret, "application/json");
		}

		[System.Web.Mvc.HttpPost]
		public async Task<ActionResult> Tz([FromBody]string loc)
		{
			// example of minimal request
			var res = await api.BuildTzWeatherQuery(loc)
				.WithIncludeLocation(true)
				.GetResult();

			// serialize and send to client
			var ret = JsonConvert.SerializeObject(res, Formatting.Indented,
				 new JsonSerializerSettings
				 {
					 DateFormatHandling = DateFormatHandling.IsoDateFormat
				 });
			return Content(ret, "application/json");
		}
	}
}