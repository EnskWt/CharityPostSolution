using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Helpers
{
    public static class QueryParametersKeysNormalizerHelper
    {
        private static readonly Dictionary<string, string> _keysPattern = new Dictionary<string, string>
        {
            { "filters[Title]", "CurrentTitleFilter" },
            // add more keys here
        };

        public static string Normalize(string key)
        {
            if (_keysPattern.ContainsKey(key))
            {
                return _keysPattern[key];
            }

            return key;            
        }
    }
}
