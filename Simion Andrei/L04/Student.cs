using Microsoft.WindowsAzure.Storage.Table;

namespace L04
{
    class Student : TableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Year { get; set; }
        public string PhoneNumber { get; set; }
        public string Faculty { get; set; }


        public Student(string university, string id)
        {
            this.PartitionKey = university;
            this.RowKey = id;
        }

        public Student() { }
    }
}