using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTDDE.Provider.Util
{
    [Serializable]
    public class FontGlyph
    {
        public int index;
        public int advance;

        public char Char => (char)index;
    }
}
