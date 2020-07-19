using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EventBus<T> : Observable<T> where T : GameEvent {

    private static EventBus<T> INSTANCE = new EventBus<T>();

    private Dictionary<Type, Publisher<T>> publishers = new Dictionary<Type, Publisher<T>>();

    private Publisher<T> getTypedPublisher() {
        Type type = typeof(T);
        Publisher<T> publisher;
        if (!publishers.ContainsKey(type)) {
            publisher = new Publisher<T>();
            publishers.Add(type, publisher);    
        } else {
            publisher = publishers[type];
        }
        Publisher<T> typedPublisher = publishers[type];
        return typedPublisher;
    }

    public static EventBus<T> getInstance() {
        return INSTANCE;
    }

    private EventBus() {
    }

    public void register(Observer<T> observer, bool emittLastValue = false) {
        if (observer == null)
            return;
        Publisher<T> publisher = getTypedPublisher();
        publisher.register(observer, emittLastValue);
    }

    public void unregister(Observer<T> observer) {
        if (observer == null)
            return;
        Publisher<T> publisher = getTypedPublisher();
        publisher.unregister(observer);
    }

    public void publish(T value) {
        Publisher<T> publisher = getTypedPublisher();
        publisher.publish(value);
    }

}

