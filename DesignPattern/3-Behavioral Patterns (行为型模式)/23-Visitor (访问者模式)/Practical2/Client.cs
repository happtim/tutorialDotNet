using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._23_Visitor__访问者模式_.Practical2
{
    [TestClass]
    public class Client {

        [TestMethod]
        public void Test() {

            EmployeeList list = new EmployeeList();
            Employee fte1, fte2, fte3, pte1, pte2;

            fte1 = new FulltimeEmployee("张无忌", 3200.00, 45);
            fte2 = new FulltimeEmployee("杨过", 2000.00, 40);
            fte3 = new FulltimeEmployee("段誉", 2400.00, 38);
            pte1 = new ParttimeEmployee("洪七公", 80.00, 20);
            pte2 = new ParttimeEmployee("郭靖", 60.00, 18);

            list.addEmployee(fte1);
            list.addEmployee(fte2);
            list.addEmployee(fte3);
            list.addEmployee(pte1);
            list.addEmployee(pte2);

            Department dep = new FADepartment();
            list.accept(dep);
        }
    }
}
