using System;

namespace PlainClasses.Application.EduBlocks.Queries.GetEduBlocks
{
    public class EduBlockViewModel
    {
        public Guid Id { get; set; }
        public string EduBlockSubjectName { get; set; }
        public DateTime StartEduBlock { get; set; }
        public DateTime EndEduBlock { get; set; }
        public string Remarks { get; set; }
        public string Place { get; set; }
    }
}