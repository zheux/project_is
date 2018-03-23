using System;
using System.Collections.Generic;
using System.Linq;
using GCRS.Domain;

namespace GCRS.Data.Repositories
{
    class TagRepository: ITagRepository
    {

        public void AddTag(Tag tag)
        {
            using (var context = new ApplicationDbContext())
            {
                if (tag != null)
                {
                    context.Tags.Add(tag);
                    context.SaveChanges();
                }
            }
        }

        public void RemoveTag(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var tag = context.Tags.SingleOrDefault(m => m.Id == id);
                if (tag != null)
                {
                    context.Tags.Remove(tag);
                    context.SaveChanges();
                }
            }
        }

        public Tag FindTag(Func<Tag, bool> predicate)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Tags.SingleOrDefault(predicate);
            }
        }

        public IEnumerable<Tag> GetTags()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Tags.ToList();
            }
        }
    }
}