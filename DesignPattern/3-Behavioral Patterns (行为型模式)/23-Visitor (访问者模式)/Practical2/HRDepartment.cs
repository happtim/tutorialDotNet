using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._23_Visitor__访问者模式_.Practical2
{
    //人力资源部类：具体访问者类    
    class HRDepartment : Department
    {
        //实现人力资源部对全职员工的访问    
        public override void visit(FulltimeEmployee employee)
        {
            int workTime = employee.getWorkTime();
            Console.WriteLine("正式员工" + employee.getName() + "实际工作时间为：" + workTime + "小时。");
            if (workTime > 40) {
                Console.WriteLine("正式员工" + employee.getName() + "加班时间为：" + (workTime - 40) + "小时。");
            } else if (workTime < 40) {
                Console.WriteLine("正式员工" + employee.getName() + "请假时间为：" + (40 - workTime) + "小时。");
            }
        }

        //实现人力资源部对兼职员工的访问    
        public override void visit(ParttimeEmployee employee)
        {
            int workTime = employee.getWorkTime();
            Console.WriteLine("临时工" + employee.getName() + "实际工作时间为：" + workTime + "小时。");
        }
}    
}
