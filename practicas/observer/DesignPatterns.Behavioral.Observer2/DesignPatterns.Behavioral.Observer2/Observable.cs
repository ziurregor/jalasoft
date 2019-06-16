using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Observer2
{
    class Observable : IObservable<int>
    {
        private List<IObserver<int>> observers;

        public Observable()
        {
            observers = new List<IObserver<int>>();
        }

        public IDisposable Subscribe(IObserver<int> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }

            return new Unsubscriber(observers, observer);
        }

        public void ddd ()
        {
            foreach (var observer in observers)
            {
                
            }
        }

        private class Unsubscriber : IDisposable
        {
            private IList<IObserver<int>> observers;
            private IObserver<int> observer;

            public Unsubscriber(IList<IObserver<int>> observers, IObserver<int> observer)
            {
                this.observers = observers;
                this.observer = observer;
            }

            public void Dispose()
            {
                if (observer != null && observers.Contains(observer))
                    observers.Remove(observer);
            }
        }
    }
}
