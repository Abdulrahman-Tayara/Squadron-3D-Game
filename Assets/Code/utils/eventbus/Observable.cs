using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public interface Observable<T> {
    void register(Observer<T> observer, bool emittLastValue = false);

    void unregister(Observer<T> observer);

    void publish(T value);
}

