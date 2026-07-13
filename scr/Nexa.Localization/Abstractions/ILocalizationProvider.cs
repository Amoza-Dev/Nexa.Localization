using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexa.Localization.Abstractions
{
    public interface ILocalizationProvider
    {
        string GetString(string culture,string key);

        string GetString(string culture,string key, params object[] arguments);

        bool TryGetString(string culture, string key, out string value);
    }
}
