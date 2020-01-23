using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace MuTest.Domain
{
    public class MutatorFactory<TTarget>
    {
        public MutatorFactory()
        {
            _mutations = new List<IMutation<TTarget, object>>();
        }

        public Mutator<TTarget> Build()
        {
            return new Mutator<TTarget>(_mutations);
        }

        public MutatorFactory<TTarget> AddMutation<TProperty>(Expression<Func<TTarget, TProperty>> property,
                                                              TProperty newValue,
                                                              Action<MutationOptions<TTarget>> options)
        {
            var opt = MutationOptions<TTarget>.Default;
            options?.Invoke(opt);
            var mutation = new Mutation<TTarget, object>(GetPropertyInfo(property), opt, newValue);
            _mutations.Add(mutation);
            return this;
        }

        public MutatorFactory<TTarget> AddMutation<TProperty>(Expression<Func<TTarget, TProperty>> property,
                                                              TProperty newValue)
        {
            return AddMutation(property, newValue, null);
        }





        public MutatorFactory<TTarget> AddMutation<TProperty>(Expression<Func<TTarget, TProperty>> property,
                                                              Func<TTarget, TProperty> newValueGenerator,
                                                              Action<MutationOptions<TTarget>> options)
        {
            var opt = MutationOptions<TTarget>.Default;
            options?.Invoke(opt);
            var mutation = new Mutation<TTarget, object>(GetPropertyInfo(property), opt, newValueGenerator);
            _mutations.Add(mutation);
            return this;
        }

        public MutatorFactory<TTarget> AddMutation<TProperty>(Expression<Func<TTarget, TProperty>> property,
                                                              Func<TTarget, TProperty> newValueGenerator)
        {
            return AddMutation(property, newValueGenerator, null);
        }




        private readonly List<IMutation<TTarget, object>> _mutations;

        public static PropertyInfo GetPropertyInfo<TProperty>(Expression<Func<TTarget, TProperty>> expression)
        {
            var body = expression.Body;
            while (body.NodeType == ExpressionType.Convert ||
                   body.NodeType == ExpressionType.ConvertChecked)
            { body = ((UnaryExpression)body).Operand; }

            var property = body is MemberExpression me
                               ? me.Member as PropertyInfo
                               : throw new InvalidOperationException($"Expression does not refer to a property: {expression}");
            return property;
        }
    }
}
