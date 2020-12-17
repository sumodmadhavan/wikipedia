using System;
using System.Collections.Generic;
namespace Sahaj.Wiki
{
    public class ParagraphMatcher
    {
        private WikiTemplate wikiTemplate = null;
        public ParagraphMatcher(WikiTemplate template)
        {
            wikiTemplate = template;
        }
        public SortedList<int, string> Result()
        {
            wikiTemplate.Run();
            return wikiTemplate.Result;
        }
    }
}
