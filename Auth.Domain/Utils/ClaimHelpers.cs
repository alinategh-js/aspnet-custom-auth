using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Auth.Domain.Utils
{
    public static class ClaimHelpers
    {
        public static IEnumerable<Claim> GetClaims(this object myobj)
        {
            var dict = DictionaryFromType(myobj);
            var claims = DictionaryToClaims(dict);

            return claims;
        }

        private static Dictionary<string, object> DictionaryFromType(object atype)
        {
            if (atype == null) return new Dictionary<string, object>();
            Type t = atype.GetType();
            PropertyInfo[] props = t.GetProperties();
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (PropertyInfo prp in props)
            {
                // Do not include prop if it has [JsonIgnore] attribute
                var skip = prp.GetCustomAttributes(true).Any(a => a.GetType().Equals(typeof(JsonIgnoreAttribute)));
                if (skip) continue;
                object value = prp.GetValue(atype);
                dict.Add(prp.Name, value);
            }
            return dict;
        }

        private static IEnumerable<Claim> DictionaryToClaims(Dictionary<string, object> dict)
        {
            if (dict == null) return new List<Claim>();
            var claims = new List<Claim>();
            foreach (var item in dict)
            {
                var claim = new Claim(item.Key, item.Value.ToString());
                claims.Add(claim);
            }

            return claims;
        }
    }
}
