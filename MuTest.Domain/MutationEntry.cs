using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MuTest.Domain
{
    public class MutationEntry
    {
        public MutationEntry(PropertyInfo property, object oldValue, object newValue)
        {
            Property = property;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public PropertyInfo Property { get; }
        public object OldValue { get; }
        public object NewValue { get; }

        public override string ToString()
        {
            var oldString = OldValue == null
                          ? "<null>"
                          : $"'{OldValue}'";
            var newString = NewValue == null
                          ? "<null>"
                          : $"'{NewValue}'";

            return $"{Property.Name}: {oldString} => {newString}";
        }
    }
}