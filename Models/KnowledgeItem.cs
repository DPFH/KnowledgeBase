using System;

namespace KnowledgeBaseDPFH
{
    public class KnowledgeItem
    {   
        public long id { get; set; }

        public string title { get; set; }

        public string summary { get; set; }

        public DateTime createdDate { get; set; }

        public DateTime editedDate { get; set; }

        public string createdBy { get; set; }

        public string editedBy { get; set; }

    }
}
