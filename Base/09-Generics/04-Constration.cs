using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guide._09_Generics
{
    class Constration
    {
    }


    //1. 值类型约束
    class ClassA<T> where T : struct { }

    //2. 引用类型约束
    class ClassB<T> where T : class { }

    //3. 无参共有构造函数
    class ClassC<T> where T : new() { }

    class Person2 { }

    interface IEmployee { }

    //4. 继承约束
    class Employee<T> where T : Person{ } 

    //5. 接口约束
    class Employee2<T> where T : IEmployee { }

    //6. 继承自U类型
    class D<T,U> where T : U { }


    // 多约束
    class EmploeeList<A> where A : Person,IEmployee , IComparable<A>, new() {

    }

    class EmployeeList<T> : IList<T> where T : IEmployee, new()
    {
        public T this[int index]
        {
            get {
                throw new NotImplementedException();
            }

            set {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get {
                throw new NotImplementedException();
            }
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
