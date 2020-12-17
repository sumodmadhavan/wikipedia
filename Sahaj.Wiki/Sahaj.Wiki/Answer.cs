using System;
namespace Sahaj.Wiki
{
    public class Answer
    {
        public string Id { get; set; }
        public string Data { get; set; }
        public Answer(string data)
        {
            Id = Guid.NewGuid().ToString();
            Data = data;
        }
    }
}
