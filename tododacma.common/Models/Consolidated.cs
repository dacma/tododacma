using System;


namespace tododacma.common.Models
{
    public class Consolidated
    {
        public string TaskDescription { get; set; }
        public int Id { get; set; }
        public DateTime CurrentDate { get; set; }

        public int Minutes { get; set; }
    }
}
