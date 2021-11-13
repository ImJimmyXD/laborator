namespace L05
{
    using Microsoft.WindowsAzure.Storage.Table;
    using System;

    /// <summary>
    /// Defines the <see cref="RaportEntity" />.
    /// </summary>
    public class RaportEntity : TableEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RaportEntity"/> class.
        /// </summary>
        /// <param name="university">The university<see cref="string"/>.</param>
        /// <param name="count">The count<see cref="int"/>.</param>
        public RaportEntity(string university, int count)
        {
            this.PartitionKey = university;
            this.RowKey = DateTime.Now.ToString("HH:mm:ss");
            this.Count = count;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RaportEntity"/> class.
        /// </summary>
        public RaportEntity()
        {
        }

        /// <summary>
        /// Gets or sets the Count.
        /// </summary>
        public int Count { get; set; }
    }
}
