namespace L05
{
    using Microsoft.WindowsAzure.Storage.Table;

    /// <summary>
    /// Defines the <see cref="Student" />.
    /// </summary>
    public class Student : TableEntity
    {
        /// <summary>
        /// Gets or sets the FirstName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Year.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the PhoneNumber.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the Faculty.
        /// </summary>
        public string Faculty { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="university">The university<see cref="string"/>.</param>
        /// <param name="cnp">The cnp<see cref="string"/>.</param>
        public Student(string university, string cnp)
        {
            this.PartitionKey = university;
            this.RowKey = cnp;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        public Student()
        {
        }
    }
}
