using Newtonsoft.Json;

namespace ForceTouchNavigationSample.Models
{
    [JsonObject]
    public class Employee
    {
        [JsonProperty("first_name")]
		public string FirstName { get; set; }

		[JsonProperty("last_name")]
		public string LastName { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("gender")]
		public string Gender { get; set; }

		[JsonProperty("avatar")]
		public string AvatarUrl { get; set; }

		[JsonProperty("position")]
		public string Position { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
