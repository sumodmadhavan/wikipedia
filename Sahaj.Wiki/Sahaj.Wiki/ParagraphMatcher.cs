﻿using System;
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
        public SortedList<int, Answer> Result()
        {
            wikiTemplate.Run();
            return wikiTemplate.Result;
        }
    }
}
