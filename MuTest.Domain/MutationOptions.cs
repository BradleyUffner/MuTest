using System;
using System.Collections.Generic;
using System.Text;

namespace MuTest.Domain
{
    public class MutationOptions<TTarget>
    {
        internal static MutationOptions<TTarget> Default => new MutationOptions<TTarget> { If = obj => true };

        public Func<TTarget, bool> If { get; set; }
    }
}