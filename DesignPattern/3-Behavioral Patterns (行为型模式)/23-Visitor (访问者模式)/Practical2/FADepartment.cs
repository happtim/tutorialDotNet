using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._23_Visitor__访问者模式_.Practical2
{
    //财务部类：具体访问者类    
    class FADepartment : Department
    {
        //实现财务部对全职员工的访问    
        public override void visit(FulltimeEmployee employee) {

            int workTime = employee.getWorkTime();
            double weekWage = employee.getWeeklyWage();
            if (workTime > 40)
            {
                weekWage = weekWage + (workTime - 40) * 100;
            } else if (workTime < 40)
            {
                weekWage = weekWage - (40 - workTime) * 80;
                if (weekWage < 0)
                {
                    weekWage = 0;
                }
            }
            Console.WriteLine("正式员工" + employee.getName() + "实际工资为：" + weekWage + "元。");
        }

        //实现财务部对兼职员工的访问    
        public override void visit(ParttimeEmployee employee) {
            int workTime = employee.getWorkTime();
            double hourWage = employee.getHourWage();
            Console.WriteLine("临时工" + employee.getName() + "实际工资为：" + workTime * hourWage + "元。");
        }
}    
}
