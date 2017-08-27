using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacIOC.Comm
{
    class MyComponent {

        public MyComponent() { /* ... */ }
        public MyComponent(ILogger logger) { /* ... */ }
        public MyComponent(ILogger logger, IConfigReader reader) { /* ... */ }

    }
}
