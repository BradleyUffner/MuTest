using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MuTest.Domain
{
    public class MutationResult<TTarget>
    {
        internal MutationResult()
        {
            _mutations = new List<MutationEntry>();
        }

        internal void AddMutation(PropertyInfo property, object oldValue, object newValue)
        {
            _mutations.Add(new MutationEntry(property, oldValue, newValue));
        }

        public TTarget Value { get; internal set; }

        private readonly List<MutationEntry> _mutations;

        public IReadOnlyCollection<MutationEntry> Mutations => _mutations;

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var mutationEntry in _mutations)
            {
                sb.AppendLine(mutationEntry.ToString());
            }

            return sb.ToString();
        }
    }
}
