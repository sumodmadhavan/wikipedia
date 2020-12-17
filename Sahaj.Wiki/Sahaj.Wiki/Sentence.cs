using System;
namespace Sahaj.Wiki
{
    public class Sentence
    {
        public string Id { get; set; }
        public string Data { get; set; }
        public Sentence(string data)
        {
            Id = Guid.NewGuid().ToString();
            Data = data;
        }
    }
}
