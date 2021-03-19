using System;
using System.Linq;
using System.Threading.Tasks;

//Mongo
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBApp
{
    class MongoDB_Tools
    {
        static void Main1(string[] args)
        {
            /*
            string connectionString = "mongodb://localhost:27017";
            string con = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;
            */

            MongoClient client = new MongoClient();

            //Get database
            IMongoDatabase database = client.GetDatabase("DS_DB");

            //Get collection
            IMongoCollection<BsonDocument> col = database.GetCollection<BsonDocument>("users");

            //GetCollectionsNamesOneDB(database).GetAwaiter();

            //GetDatabaseNames(client).GetAwaiter();


            Console.WriteLine(col.CollectionNamespace);
            Console.ReadLine();
        }

        private static async Task GetDatabaseNames(MongoClient client)
        //Get all databases names from server
        {
            using (var cursor = await client.ListDatabasesAsync())
            {
                var databaseDocuments = await cursor.ToListAsync();
                foreach (var databaseDocument in databaseDocuments)
                {
                    Console.WriteLine(databaseDocument["name"]);
                }
            }
        }

        private static async Task GetCollectionsNames(MongoClient client)
        //Get all collections names from all DBs
        {
            using (var cursor = await client.ListDatabasesAsync())
            {
                var dbs = await cursor.ToListAsync();
                foreach (var db in dbs)
                {
                    Console.WriteLine("В базе данных {0} имеются следующие коллекции:", db["name"]);

                    IMongoDatabase database = client.GetDatabase(db["name"].ToString());

                    using (var collCursor = await database.ListCollectionsAsync())
                    {
                        var colls = await collCursor.ToListAsync();
                        foreach (var col in colls)
                        {
                            Console.WriteLine(col["name"]);
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        private static async Task GetCollectionsNamesOneDB(IMongoDatabase database)
        //Get all collections names from DB
        {
            using (var collCursor = await database.ListCollectionsAsync())
            {
                var colls = await collCursor.ToListAsync();
                foreach (var col in colls)
                {
                    Console.WriteLine(col["name"]);
                }
            }
        }


    }

    class MongoCollections
    {
        static MongoClient client = new MongoClient();


        static void Main2(string[] args)
        {
            //Get database
            IMongoDatabase database = client.GetDatabase("DS_DB");

            //IMongoCollection<BsonDocument> NewCol = CreateCollection();

            //Get collection
            IMongoCollection<BsonDocument> col = database.GetCollection<BsonDocument>("users");

            col.Indexes.CreateOne(new BsonDocument("i", 1));

            Console.WriteLine("Collection {0} has been created.", col.CollectionNamespace);
            Console.ReadLine();
        }

        private static IMongoCollection<BsonDocument> CreateCollection()
        {
            //Get database
            IMongoDatabase database = client.GetDatabase("DS_DB");

            //New collection name
            string ColName = "NewCol";

            //Create new collection
            //var options = new CreateCollectionOptions { Capped = true, MaxSize = 1024 * 1024 };
            database.CreateCollection(ColName);

            //Get collection
            IMongoCollection<BsonDocument> col = database.GetCollection<BsonDocument>(ColName);

            return col;

        }


    }

    class MongoDoc
    {
        static readonly MongoClient client = new MongoClient();
        static readonly string DBname = "DS_DB";
        static readonly string ColName = "NewCol";


        static void Main3(string[] args)
        {


            //BsonDocument NewDoc = InsertOneDoc();

            //Console.WriteLine("Document {0} has been created.", NewDoc.Names);

            IMongoCollection<BsonDocument> Newcol = GetDBCollection(DBname, ColName);

            //Counting documents
            var count = Newcol.CountDocuments(new BsonDocument());

            //Find first document in the collection
            //var document = Newcol.Find(new BsonDocument()).FirstOrDefault();

            //Get a Single Document with a Filter
            var filter1 = Builders<BsonDocument>.Filter.Eq("counter", 100);
            var filter2 = Builders<BsonDocument>.Filter.Gte("counter", 100);

            //Deleting many docs
            //var result = Newcol.DeleteMany(filter2);


            //var document = Newcol.Find(filter2).First();

            //Deleting docs
            //Newcol.DeleteOne(filter1);

            BulkWrites();

            //Console.WriteLine(result.DeletedCount);
            Console.WriteLine("Done!");


            Console.ReadLine();
        }

        private static BsonDocument InsertOneDoc()
        {
            //Get database
            IMongoDatabase database = client.GetDatabase("DS_DB");

            //New collection name
            string ColName = "NewCol";

            //Get collection
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(ColName);

            var document = new BsonDocument
                {
                    { "name", "MongoDB" },
                    { "type", "Database" },
                    { "count", 1 },
                    { "info", new BsonDocument
                        {
                            { "x", 203 },
                            { "y", 102 }
                        }}
                };

            collection.InsertOne(document);

            return document;
        }

        private static void InsertManyDocs()
        {
            IMongoCollection<BsonDocument> Newcol = GetDBCollection(DBname, ColName);

            // generate 100 documents with a counter ranging from 0 - 99
            var documents = Enumerable.Range(0, 100).Select(i => new BsonDocument("counter", i));

            Newcol.InsertMany(documents);

        }

        private static IMongoCollection<BsonDocument> GetDBCollection(string DBname, string ColName)
        //Get collection from DB
        {
            //Get database
            IMongoDatabase database = client.GetDatabase(DBname);
          
            //Get collection
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(ColName);

            return collection;

        }

        private static void IterateDocs(IMongoCollection<BsonDocument> collection)
            //Iterate over documents of collection
        {
            var cursor = collection.Find(new BsonDocument()).ToCursor();
            foreach (var document in cursor.ToEnumerable())
            {
                Console.WriteLine(document);
            }
        }

        private static void GetSetDocsWithFilter()
            //Get a set Document with a Filter
        {
            IMongoCollection<BsonDocument> Newcol = GetDBCollection(DBname, ColName);

            var filter = Builders<BsonDocument>.Filter.Gt("counter", 71);

            var cursor = Newcol.Find(filter).ToCursor();
            foreach (var document in cursor.ToEnumerable())
            {
                Console.WriteLine(document);
            }
        }

        private static void SortDocs()
        //Sorting docs with a Filter
        {
            IMongoCollection<BsonDocument> Newcol = GetDBCollection(DBname, ColName);

            var filter = Builders<BsonDocument>.Filter.Exists("counter");
            var sort = Builders<BsonDocument>.Sort.Descending("counter");

            var cursor = Newcol.Find(filter).Sort(sort).ToCursor();

            foreach (var document in cursor.ToEnumerable())
            {
                Console.WriteLine(document);
            }
        }

        private static void FieldsProjecting()
        //exclude the “_id” field and output the first matching document
        {
            IMongoCollection<BsonDocument> Newcol = GetDBCollection(DBname, ColName);

            var projection = Builders<BsonDocument>.Projection.Exclude("_id");

            var document = Newcol.Find(new BsonDocument()).Project(projection).First();
            Console.WriteLine(document.ToString());
        }

        private static void UpdateDoc()
        //update the first document that meets the filter
        {
            IMongoCollection<BsonDocument> Newcol = GetDBCollection(DBname, ColName);

            var filter = Builders<BsonDocument>.Filter.Eq("counter", 10);
            var update = Builders<BsonDocument>.Update.Set("counter", 110);

            Newcol.UpdateOne(filter, update);
        }

        private static void UpdateDocs()
        //update all documents matching the filter
        {
            IMongoCollection<BsonDocument> Newcol = GetDBCollection(DBname, ColName);

            var filter = Builders<BsonDocument>.Filter.Lt("counter", 100);
            var update = Builders<BsonDocument>.Update.Inc("counter", 100);

            var result = Newcol.UpdateMany(filter, update);

            if (result.IsModifiedCountAvailable)
            {
                Console.WriteLine(result.ModifiedCount);
            }
        }

        private static void BulkWrites()
        //update all documents matching the filter
        {
            IMongoCollection<BsonDocument> Newcol = GetDBCollection(DBname, ColName);

            var models = new WriteModel<BsonDocument>[]
                {
                    new InsertOneModel<BsonDocument>(new BsonDocument("_id", 1)),
                    new InsertOneModel<BsonDocument>(new BsonDocument("_id", 2)),
                    new InsertOneModel<BsonDocument>(new BsonDocument("_id", 3)),
                    new UpdateOneModel<BsonDocument>(
                        new BsonDocument("_id", 1),
                        new BsonDocument("$set", new BsonDocument("x", 2))),
                    new DeleteOneModel<BsonDocument>(new BsonDocument("_id", 3)),
                    new ReplaceOneModel<BsonDocument>(
                        new BsonDocument("_id", 3),
                        new BsonDocument("_id", 3).Add("x", 4))
                };

            // 1. Ordered bulk operation - order of operation is guaranteed
            Newcol.BulkWrite(models);

            // 2. Unordered bulk operation - no guarantee of order of operation
            //collection.BulkWrite(models, new BulkWriteOptions { IsOrdered = false });
        }
    }

    class Person
    {
        static readonly MongoClient client = new MongoClient();
        static readonly string DBname = "DS_DB";
        static readonly string ColName = "NewCol_1";

        [BsonId]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [BsonIgnoreIfDefault]
        public int Age { get; set; }
        [BsonIgnoreIfNull]
        public Company Company { get; set; }

        static void Main(string[] args)
        {
            Person p = new Person { Name = "Bill", Surname = "Gates", Age = 48 };
            //p.Company = new Company { Name = "Microsoft" };

            IMongoCollection<BsonDocument> Newcol = GetDBCollection(DBname, ColName);

            //Newcol.InsertOne(p.ToBsonDocument());

            //Console.WriteLine(p.ToJson());

            DocsFieldsOutput().GetAwaiter();

            Console.ReadLine();
        }

        private static async Task DocsFieldsOutput()
        {
            var filter = new BsonDocument();

            //Get database
            IMongoDatabase database = client.GetDatabase(DBname);

            var collection = database.GetCollection<Person>(ColName);
            var people = await collection.Find(filter).ToListAsync();
           
                    foreach (Person doc in people)
                    {
                        Console.WriteLine("{0} - {1} - {2}", doc.PersonId, doc.Name, doc.Age);
                    }
        }

        private static IMongoCollection<BsonDocument> GetDBCollection(string DBname, string ColName)
        //Get collection from DB
        {
            //Get database
            IMongoDatabase database = client.GetDatabase(DBname);

            //Get collection
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(ColName);

            return collection;

        }
    }

    class Company
    {
        public string Name { get; set; }
    }

}