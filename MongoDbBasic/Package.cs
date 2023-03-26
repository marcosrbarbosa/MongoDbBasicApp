using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbBasic
{
	public class Package 
	{
		[BsonId]
		public Guid Id { get; set; }
		public DateTime ReceivedDate { get; set; }
		public decimal Weight { get; set; }
		public string Size { get; set; }

	}
}
