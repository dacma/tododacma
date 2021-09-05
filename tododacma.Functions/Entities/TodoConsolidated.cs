using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace tododacma.Functions.Entities
{
    public class TodoConsolidated : TableEntity
    {
        public string TaskDescription { get; set; }
        public int Id { get; set; }
        public DateTime CurrentDate { get; set; }

        public int Minutes { get; set; }
    }
}
