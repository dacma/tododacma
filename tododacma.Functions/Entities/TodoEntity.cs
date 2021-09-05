using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace tododacma.Functions.Entities
{
    public class TodoEntity : TableEntity
    {
        public string TaskDescription { get; set; }
        public int Id { get; set; }
        public DateTime CurrentDate { get; set; }

        public int Type { get; set; }

        public bool Consolidated { get; set; }

    }
}
