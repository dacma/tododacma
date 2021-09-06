using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace tododacma.Functions.Entities
{
    public class TodoConsolidated : TableEntity
    {
        public int Id { get; set; }
        public DateTime CurrentDate { get; set; }

        public int Minutes { get; set; }
    }
}
