using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Behavior.State
{
    class Context
    {
        //抽象状态对象的一个引用
        private State state;
        //enum type
        private WeekEnum week;

        public WeekEnum Week
        {
            get
            {
                return week;
            }

            set
            {
                week = value;
            }
        }

        public void setState(State state) {
            this.state = state;
        }

        public string request() {
            //...

            //调用状态对象的业务方法
            return state.handle();

            //...
        }

        public void changeState() {
            if (week == WeekEnum.Sunday)
                this.setState(new SundayState());
            else if (week == WeekEnum.Monday)
                this.setState(new MondayState());
        }
    }
}
