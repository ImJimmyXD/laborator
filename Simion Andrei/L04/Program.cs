//using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGrease.Activities;

namespace L04
{
    class Program
    {
        private static readonly string StorageConnectionString = Environment.GetEnvironmentVariable("accesKey");

        private static CloudTableClient _tableClient;
        private static CloudTable _studentsTable;

        static async Task AddStudent()
        {
            var student = new Student("UPT", "LO16659")
            {
                FirstName = "Simion",
                LastName = "Andrei",
                Email = "SimionAndrei@goomail.com",
                Year = 4,
                PhoneNumber = "0722222222",
                Faculty = "AC"
            };

            var insertOperation = TableOperation.Insert(student);

            await _studentsTable.ExecuteAsync(insertOperation);
        }

        private static async Task DisplayStudents()
        {
            Console.WriteLine("Universitate\tID\tNume\tEmail\tNumar telefon\tAn");
            TableQuery<Student> query = new TableQuery<Student>();

            TableContinuationToken token = null;
            do
            {
                TableQuerySegment<Student> resultSegment = await _studentsTable.ExecuteQuerySegmentedAsync(query, token);
                token = resultSegment.ContinuationToken;

                foreach (Student entity in resultSegment.Results)
                {
                    Console.WriteLine("{0}\t{1}\t{2} {3}\t{4}\t{5}\t{6}\t{7}", entity.PartitionKey, entity.RowKey, entity.FirstName,
                        entity.LastName, entity.Email, entity.Year, entity.PhoneNumber, entity.Faculty);
                }
            } while (token != null);
        }

        private static async Task GetStudent(string partitionKey, string rowKey)
        {
            var retrieveOperation = TableOperation.Retrieve(partitionKey, rowKey);
            await _studentsTable.ExecuteAsync(retrieveOperation);
        }

        private static async Task UpdateStudent(string PartitionKey_, string RowKey_)
        {
            var entity = new Student
            {
                PartitionKey = PartitionKey_,
                RowKey = RowKey_,
                //ETag = "*",
                FirstName = "Simion",
                LastName = "Andrei",
                Email = "SimionAndrei@goomail.com",
                Year = 4,
                PhoneNumber = "0722222222",
                Faculty = "AC"
            };

            var updateOperation = TableOperation.InsertOrReplace(entity);
            await _studentsTable.ExecuteAsync(updateOperation);
        }

        private static async Task DeleteStudent(string PartitionKey_,string RowKey_)
        {
            try
            {
                var entity = new Student
                {
                    PartitionKey = PartitionKey_,
                    RowKey = RowKey_,
                    ETag = "*"
                };
                CloudTable table = _tableClient.GetTableReference("studenti");
                TableOperation delteOperation = TableOperation.Delete(entity);
                await table.ExecuteAsync(delteOperation);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! {0}\t", ex);
                throw;
            }
        }

        static void Main()
        {
            Task.Run(async () => { await Initialize(); })
                .GetAwaiter()
                .GetResult();
        }

        static string ReadValue(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        static async Task Initialize()
        {
            var account = CloudStorageAccount.Parse(StorageConnectionString);
            _tableClient = account.CreateCloudTableClient();
            _studentsTable = _tableClient.GetTableReference("studenti");

            await _studentsTable.CreateIfNotExistsAsync();

            //await AddStudent();
            //await DisplayStudents();

            //Console.Write("University: ");
            //string university = Console.ReadLine();
            //string university = "UPT";
            //Console.Write("ID: ");
            //string id = Console.ReadLine();
            //string id = "LO15567";
            //await GetStudent(university, id);
            //await UpdateStudent(university, id);
            //await DisplayStudents();
            //await DeleteStudent(university, id);

            string _tempPartitionKey, _tempRowKey;

            int option;
            bool ok = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Press 0 for exit!");
                Console.WriteLine("Press 1 to display students!");
                Console.WriteLine("Press 2 add student!");
                Console.WriteLine("Press 3 display student information!");
                Console.WriteLine("Press 4 update student information!");
                Console.WriteLine("Press 5 delete student!");
                Console.Write("Enter option: ");
                option = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (option)
                {
                    case 0:
                        return;
                    case 1: 
                        await DisplayStudents();
                        break;
                    case 2:
                        await AddStudent();
                        break;
                    case 3:
                        _tempPartitionKey = ReadValue("PartitionKey: ");
                        _tempRowKey = ReadValue("RownKey: ");
                        await GetStudent(_tempPartitionKey,_tempRowKey);
                        break;
                    case 4:
                        _tempPartitionKey = ReadValue("PartitionKey: ");
                        _tempRowKey = ReadValue("RownKey: ");
                        await UpdateStudent(_tempPartitionKey, _tempRowKey);
                        break;
                    case 5:
                        _tempPartitionKey = ReadValue("PartitionKey: ");
                        _tempRowKey = ReadValue("RownKey: ");
                        await DeleteStudent(_tempPartitionKey, _tempRowKey);
                        break;
                    default:
                        return;
                }
            } while (ok);

            //ToBeContinued...
        }
    }
}