using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoDbBasic
{
	public class MongoDbCrud<T> where T: class
	{

		private readonly IMongoDatabase mongoDb;
		private readonly string _tableName;
		public MongoDbCrud(string database)
		{
			var clientDb = new MongoClient();
			mongoDb = clientDb.GetDatabase(database);
			_tableName = typeof(T).Name;
		}

		public void Insert(T record)
		{
			var collection = mongoDb.GetCollection<T>(_tableName);
			collection.InsertOne(record);
		}

		public void Upsert(Guid id, T record)
		{
			var collection = mongoDb.GetCollection<T>(_tableName);
			_ = collection.ReplaceOne(new BsonDocument("_id", BsonBinaryData.Create(id)), record, new ReplaceOptions { IsUpsert = true });
		}
		public void Delete(Guid id)
		{
			var collection = mongoDb.GetCollection<T>(_tableName);
			var filter = Builders<T>.Filter.Eq("Id", id);
			collection.DeleteOne(filter);
		}
		public List<T> ListRecords()
		{
			var collection = mongoDb.GetCollection<T>(_tableName);
			return collection.Find(new BsonDocument()).ToList();
		}

		public T GetRecordById(Guid id)
		{
			var collection = mongoDb.GetCollection<T>(_tableName);
			var filter = Builders<T>.Filter.Eq("Id", id);
			return collection.Find(filter).FirstOrDefault();
		}
	}
}
