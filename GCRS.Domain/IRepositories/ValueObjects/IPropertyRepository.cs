using System;
using System.Collections.Generic;

namespace GCRS.Domain
{
    public interface IPropertyRepository
    {
        void AddProperty(Property Property);
        void RemoveProperty(int id);
        Property FindProperty(Func<Property, bool> predicate);
        IEnumerable<Property> GetProperties();
    }
}
