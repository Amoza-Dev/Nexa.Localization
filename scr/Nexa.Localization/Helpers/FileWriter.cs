using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexa.Localization.Helpers
{
    public sealed class FileWriter
    {
        public void Write(string outputPath, string content)
        {
            var directory = Path.GetDirectoryName(outputPath);

            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllText(outputPath, content);
        }
    }
}
