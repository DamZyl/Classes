using System;

namespace PlainClasses.Api.EduBlocks
{
    public class UpdateEduBlockRequest
    {
        public string Remarks { get; set; }
        public string Place { get; set; }
        public DateTime StartEduBlock { get; set; }
        public DateTime EndEduBlock { get; set; }
    }
}