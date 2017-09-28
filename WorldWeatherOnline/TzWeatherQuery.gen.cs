
using System;

namespace WorldWeatherOnline
{
	/// <summary>
	/// Query to timezone service endpoint
	/// </summary>
	/// <remarks>
	/// Full documentation for REST service can be found at https://developer.worldweatheronline.com/api/docs/time-zone-api.aspx
	/// </remarks>
	public partial class TzWeatherQuery
    {
		
		
		/// <summary>
		/// Location: Finds the nearest ski and mountain location for the provided search criteria.
		///<para /> City name (ex: 'New York', 'New York,ny', 'London,united kingdom'), 
		///<para /> ip address (ex: '101.25.32.325'), 
		///<para /> US zip code, UK postcode, Canada postal code (ex: 'SW1', '90201')
		///<para /> or lot/lan coordinates (ex: 48.834,2.394)
		/// </summary>
		public string Location { get; set; }

		/// <summary>
		/// Sets Location and returns modified query
		/// </summary>
		/// <param name="location">Finds the nearest ski and mountain location for the provided search criteria.
		///<para /> City name (ex: 'New York', 'New York,ny', 'London,united kingdom'), 
		///<para /> ip address (ex: '101.25.32.325'), 
		///<para /> US zip code, UK postcode, Canada postal code (ex: 'SW1', '90201')
		///<para /> or lot/lan coordinates (ex: 48.834,2.394)</param>
		/// <returns>this</returns>
		public TzWeatherQuery WithLocation (string location) { 
			this.Location = location;
			return this;
		}



		
		/// <summary>
		/// IncludeLocation: Whether to return the nearest weather point for which the weather data is returned for a given postcode, zipcode and lat/lon values. Default: false
		/// </summary>
		public bool? IncludeLocation { get; set; }

		/// <summary>
		/// Sets IncludeLocation and returns modified query
		/// </summary>
		/// <param name="include_location">Whether to return the nearest weather point for which the weather data is returned for a given postcode, zipcode and lat/lon values. Default: false</param>
		/// <returns>this</returns>
		public TzWeatherQuery WithIncludeLocation (bool? include_location) { 
			this.IncludeLocation = include_location;
			return this;
		}


		private string _buildQueryString(){
			var s = "";
			if(Location != null){
				s+= $"&q={Location}";
			}
			if(IncludeLocation != null){
				s+= $"&includelocation={(IncludeLocation.Value ? "yes" : "no")}";
			}
			return "tz.ashx?" + s.Substring(1);
		}
    }
}

