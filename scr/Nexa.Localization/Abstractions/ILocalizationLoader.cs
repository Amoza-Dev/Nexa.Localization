using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexa.Localization.Abstractions
{
    public interface ILocalizationLoader
    {
        Task LoadAsync(CancellationToken cancellationToken = default);
    }
}
