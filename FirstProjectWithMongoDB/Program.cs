using FirstProjectWithMongoDB.Model;
using MongoDB.Driver;
using System;

namespace FirstProjectWithMongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            //Connect to server
            var client = new MongoClient("mongodb://localhost:27017");

            //Connect to the database
            var database = client.GetDatabase("MyFirstScheduleWithMongoDB");

            //collection to persist
            IMongoCollection<Person> collection = database.GetCollection<Person>("Person");

            //CRUD
            //InsertPerson(collection);
            //UpdatePerson(collection);
            //DeletePerson(collection);
            ReadPerson(collection);

            Console.ReadKey();
        }

        private static void ReadPerson(IMongoCollection<Person> collection)
        {
            //Filter
            var filter = Builders<Person>.Filter.Empty;

            var persons = collection.Find(filter);

            persons.ForEachAsync(x =>
            {
                Console.WriteLine(string.Concat("Name: ", x.Name, " - Email: ", x.Email));
            });
        }

        private static void DeletePerson(IMongoCollection<Person> collection)
        {
            //Filter
            var filter = Builders<Person>.Filter.Where(x => x.Name == "My Name");

            collection.DeleteMany(filter);
        }

        private static void UpdatePerson(IMongoCollection<Person> collection)
        {
            //Filter
            var filter = Builders<Person>.Filter.Empty;

            //Update
            var update = Builders<Person>.Update.Set(x => x.Active, true);

            collection.UpdateMany(filter, update);
        }

        private static void InsertPerson(IMongoCollection<Person> collection)
        {
            var person = new Person("My Name", "myemail@mail.com");

            collection.InsertOne(person);
        }
    }
}