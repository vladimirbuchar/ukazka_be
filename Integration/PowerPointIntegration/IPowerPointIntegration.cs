using Core.DataTypes;
using System.Collections.Generic;

namespace Integration.PowerPointIntegration
{
    public interface IPowerPointIntegration
    {
        System.Threading.Tasks.Task<List<PowerPointSlide>> ConvertToHtmlAsync(string root, string file);
    }
}
