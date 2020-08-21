using System;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;

namespace aztablestorage
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Table Storage sample!");

            var connectionString = "<insert your storage account connection string here>";
            var tableName = "myFirstTable";

            var account = CloudStorageAccount.Parse(connectionString);
            var tableClient = account.CreateCloudTableClient(new TableClientConfiguration());
            var table = tableClient.GetTableReference(tableName);

            // var burton = new Person("Burton", "Rodman", 42);
            // await InsertOrUpdatePerson(table, burton);

            var burton = await QueryPerson(table, "Burton", "Rodman");
            if (burton != null) {
                Console.WriteLine($"{burton.First} {burton.Last}, {burton.Age}");
            } else {
                Console.WriteLine("not found!");
            }

            Console.WriteLine("done.");
        }

        static async Task InsertOrUpdatePerson(CloudTable table, Person person) {
            var op = TableOperation.InsertOrMerge(person);
            var result = await table.ExecuteAsync(op);
            var inserted = result.Result as Person;

            Console.WriteLine("added Person.");
        }

        static async Task<Person> QueryPerson(CloudTable table, string first, string last) {
            var op = TableOperation.Retrieve<Person>(last, first);
            var result = await table.ExecuteAsync(op);
            

            return result.Result as Person;
        }

    }
}
