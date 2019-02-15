using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    /// <summary>
    /// Various extension methods to build algorithms
    /// </summary>
    public static class AlgorithmExtensions
    {
        /// <summary>
        /// Returns the method that implement the access indexer.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static Func<TKey, TValue> GetIndexer<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
        {
            Contract.Requires(dictionary != null);
            Contract.Ensures(Contract.Result<Func<TKey, TValue>>() != null);

            return key => dictionary[key];

        }
    }
}
