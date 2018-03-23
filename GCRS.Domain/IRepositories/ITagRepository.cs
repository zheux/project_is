using System;
using System.Collections.Generic;

namespace GCRS.Domain
{
    public interface ITagRepository
    {
        void AddTag(Tag tag);
        void RemoveTag(int id);
        Tag FindTag(Func<Tag, bool> predicate);
        IEnumerable<Tag> GetTags();
    }
}
