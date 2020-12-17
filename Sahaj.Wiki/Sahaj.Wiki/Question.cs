using System;
namespace Sahaj.Wiki
{
    public class Question
    {
        public string Id { get; set; }
        public string Data { get; set; }
        public Question(string data)
        {
            Id = Guid.NewGuid().ToString();
            Data = data;
        }
    }
}
