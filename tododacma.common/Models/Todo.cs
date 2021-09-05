using System;

namespace tododacma.common.Models
{
    public class Todo
    {
        public string TaskDescription { get; set; }
        public int Id { get; set;  }
        public DateTime CurrentDate { get; set; }

        public int Type { get; set; }

        public bool Consolidated { get; set; }
    }
}
