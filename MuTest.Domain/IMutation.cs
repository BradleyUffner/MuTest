using System;
using System.Linq.Expressions;
using System.Reflection;

namespace MuTest.Domain
{
    internal interface IMutation<TTarget, out TProperty>
    {
        public PropertyInfo Property { get; }
        public TProperty NewValue { get; }
        MutationOptions<TTarget> Options { get; }
    }
}