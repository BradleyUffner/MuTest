using System;
using System.Linq.Expressions;
using System.Reflection;

namespace MuTest.Domain
{
    internal class Mutation<TTarget, TProperty> : IMutation<TTarget, TProperty>
    {
        public Mutation(PropertyInfo property,
                        MutationOptions<TTarget> options,
                        TProperty newValue)
        {
            Property = property;
            NewValue = newValue;
            Options = options;
        }

        public Mutation(PropertyInfo property,
                        MutationOptions<TTarget> options,
                        Func<TTarget, TProperty> newValueGenerator)
        {
            Property = property;
            NewValueGenerator = newValueGenerator;
            Options = options;
        }

        public PropertyInfo Property { get; }
        public TProperty NewValue { get; }
        public MutationOptions<TTarget> Options { get; }
        public Func<TTarget, TProperty> NewValueGenerator { get; }
    }
}