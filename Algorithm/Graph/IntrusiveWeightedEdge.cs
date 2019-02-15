using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Graph
{
        /**
         * IntrusiveEdge extension for weighted edges. IntrusiveWeightedEdge encapsulates the internals for
         * the default weighted edge implementation. It is not intended to be referenced directly (which is
         * why it's not public); use DefaultWeightedEdge for that.
         *
         * @author Dimitrios Michail
         */
        public class IntrusiveWeightedEdge : IntrusiveEdge
        {
        //  private static final long serialVersionUID = 2890534758523920741L;

        public double weight = 1.0;

    }
}
