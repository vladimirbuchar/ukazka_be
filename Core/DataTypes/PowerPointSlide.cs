using System.Collections.Generic;

namespace Core.DataTypes
{
    public class PowerPointSlide
    {
        public PowerPointSlide()
        {
            Text = new List<string>();
        }
        public string Name { get; set; }
        public List<string> Text { get; set; }
    }
}
