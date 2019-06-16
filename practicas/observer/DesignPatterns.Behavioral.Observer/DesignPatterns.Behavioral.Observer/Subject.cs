using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Observer
{
    class Subject
    {
        private int state;

        private List<Observer> observers;

        public Subject()
        {
            observers = new List<Observer>();
        }

        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void SetState(int state)
        {
            this.state = state;
            this.Notify();
        }

        public int GetState()
        {
            return this.state;
        }

        private void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }
    }
}
