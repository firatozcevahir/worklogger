using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkLogger.Models
{
    public partial class WorkingLog
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string EntranceTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string ExitTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
