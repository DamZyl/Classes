using System;

namespace PlainClasses.Api.EduBlocks.Requests
{
    public class AddFunctionRequest
    {
        public Guid PersonId { get; set; }
        public string Function { get; set; }
    }
}