using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusProject.eventbus {
    class Publisher<T> : Observable<T> {
        private List<Observer<T>> observers = new List<Observer<T>>();
        private T lastEmittedValue = default(T);
        public void register(Observer<T> observer, bool emittLastValue = false) {
            observers.Add(observer);
            if (emittLastValue)
                observer.Invoke(lastEmittedValue);
        }

        public void unregister(Observer<T> observer) {
            observers.Remove(observer);
        }

        public void publish(T value) {
            lastEmittedValue = value;
            foreach (Observer<T> observer in observers)
                if (observer != null)
                    observer.Invoke(value);
        }
    }

}
