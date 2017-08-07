using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Equals
{
    /// <summary>
    /// Contains, IndexOf, LastIndexOf, and Remove. 这些泛型的函数都会用到IEquatable接口
    /// 如果重写这个接口,就要重写 Object.Equals 和 == != 要确保逻辑统一
    /// 重写这些对象,如果这些对象将会放到泛型集合内
    /// </summary>
    public class People : IEquatable<People>{

        public String Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        public bool Equals(People people) {

            if (this == null)
                throw new NullReferenceException("People Can Not Be Null!");

            if (people == null)
                return false;

            if (Object.ReferenceEquals(this, people))
                return true;

            return this.Name == people.Name;
        }

        /// <summary>
        /// Object override Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) {

            if (this == null)
                throw new NullReferenceException("People Can Not Be Null!");

            People people = obj as People;
            if (people == null)
                return false;

            if (Object.ReferenceEquals(this, people))
                return true;

            return this.Name == people.Name;
        }

    }

    public class CityPeople :People {

    }

}
