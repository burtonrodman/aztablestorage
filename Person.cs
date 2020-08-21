using Microsoft.Azure.Cosmos.Table;

namespace aztablestorage
{
    public class Person : TableEntity
    {
        public Person() { }
        public Person(string first, string last, int age)
        {
            PartitionKey = last;
            RowKey = first;
            Age = age;
        }

        public string First => RowKey;
        public string Last => PartitionKey;
        public int Age { get; set; }
    }
}
