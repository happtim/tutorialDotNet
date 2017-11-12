using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._2_Structural_Patterns__结构型模式_._06_Adapter__适配器模式_.Practical.ObjectAdapter
{
    public class Adapter : Power12V{

        private Power220V  power220V = new Power220V();

        public override int GetPower() {

            int power = power220V.GetPower();
            return power - 208; //降压
        }
    }
}
