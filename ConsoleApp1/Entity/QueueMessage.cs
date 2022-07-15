using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp1.Entity
{
    public class QueueMessage
    {
        [Key]
        public int Sn { get; set; }

        public string MessageID { get; set; }

        public string MessageText { get; set; }

        public int QueueID { get; set; }

        public DateTime InsertionTime { get; set; }

        public int DequeueCount { get; set; }

        public int QueueMessageStatusID { get; set; }
    }
}
