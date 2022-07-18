using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp1.Entity
{
    public class QueueMessageStatus
    {
        [Key]
        public int QueueMessageStatusID { get; set; }

        public string QueueMessageStatusDescription { get; set; }
    }
}
