using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Force.DeepCloner;

namespace MuTest.Domain
{
    public class Mutator<TTarget>
    {
        private readonly IEnumerable<IMutation<TTarget, object>> _mutations;

        internal Mutator(IEnumerable<IMutation<TTarget, object>> mutations)
        {
            _mutations = mutations;
        }


        public MutationResult<TTarget> Apply(TTarget target)
        {
            var copy = target.DeepClone();

            var result = new MutationResult<TTarget>();
            foreach (var mutation in _mutations)
            {
                if (mutation.Options.If(copy))
                {
                    var prop = mutation.Property;

                    object newValue;
                    if (mutation.NewValue is Delegate d)
                    {
                        newValue = d.DynamicInvoke(copy);
                    }
                    else
                    {
                        newValue = mutation.NewValue;
                    }

                    result.AddMutation(prop, prop.GetValue(copy), newValue);
                    prop.SetValue(copy, newValue);
                }

            }
            result.Value = copy;

            return result;
        }
    }
}
