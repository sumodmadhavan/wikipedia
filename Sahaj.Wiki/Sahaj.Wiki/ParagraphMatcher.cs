using System;
using System.Collections.Generic;
namespace Sahaj.Wiki
{
    public class ParagraphMatcher
    {
        private readonly WikiTemplate wikiTemplate = null;
        public ParagraphMatcher(WikiTemplate template)
        {
            wikiTemplate = template;
        }
        public Dictionary<string, Answer> Result()
        {
            wikiTemplate.Run();
            return wikiTemplate.Result;
        }
    }
}
