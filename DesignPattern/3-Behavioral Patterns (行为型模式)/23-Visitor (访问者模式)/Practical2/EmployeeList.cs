using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern._3_Behavioral_Patterns__行为型模式_._23_Visitor__访问者模式_.Practical2
{
    //员工列表类：对象结构    
    public class EmployeeList {
        //定义一个集合用于存储员工对象    
        private List<Employee> list = new List<Employee>();

        public void addEmployee(Employee employee)
        {
            list.Add(employee);
        }

        //遍历访问员工集合中的每一个员工对象    
        public void accept(Department handler)
        {
            foreach(var employee  in list) {
                employee.accept(handler);
            }
        }
    }
}
