using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SW.Framework.Support
{
    public static partial class RegexExpressions
    {
        /// <summary>
        /// Valid mail address
        /// </summary>
        /// <returns></returns>
        [GeneratedRegex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,}$")]
        public static partial Regex ValidateMailRegex();
    }
}
