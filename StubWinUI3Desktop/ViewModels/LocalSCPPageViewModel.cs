using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubWinUI3Desktop.ViewModels
{
    internal class LocalSCPPageViewModel
    {
        private int m_width, m_height;
        internal int Width
        {
            get { return m_width; }
            set { m_width = value; }
        }
        internal int Height
        {
            get { return m_height; }
            set { m_height = value; }
        }
        internal LocalSCPPageViewModel()
        {
            ;
        }
        
    }
}
