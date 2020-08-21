using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreAppUsingMVC.Services
{
    public class MyDependencyService : IMyDependencyService
    {
        public MyDependencyService(IMyDependencyService2 myDependencyService2)
        {
        }

        int counter;

        public void IncrementCounter()
        {
            counter++;
        }


        public void DecrementCounter()
        {
            counter--;
        }


        public int GetCounterValue()
        {
            return counter;
        }

    }

    public interface IMyDependencyService
    {
        void IncrementCounter();
        void DecrementCounter();
        int GetCounterValue();
    }



    public class MOCKMyDependencyService : IMyDependencyService
    {
        public void DecrementCounter()
        {
            throw new NotImplementedException();
        }

        public int GetCounterValue()
        {
            throw new NotImplementedException();
        }

        public void IncrementCounter()
        {
            throw new NotImplementedException();
        }
    }
}
