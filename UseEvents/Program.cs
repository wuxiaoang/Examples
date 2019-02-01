using System;

namespace UseEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            // 演示泛型版本事件参数的使用
            Publisher pub = new Publisher();
            Subscriber sub1 = new Subscriber("sub1", pub);
            Subscriber sub2 = new Subscriber("sub2", pub);
            Subscriber sub3 = new Subscriber("sub3", pub);

            // Call the method that raises the event.
            pub.DoSomething();

            // Keep the console window open
            Console.WriteLine("Press Enter to close this window.");
            Console.ReadLine();
        }
    }

    /// <summary>
    /// 定义一个保存自定义事件信息的类
    /// </summary>
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string s)
        {
            message = s;
        }
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }

    /// <summary>
    /// 定义一个保存自定义事件信息的泛型类，可以在其中保持不同类型的信息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T target)
        {
            this.Info = target;
        }

        public T Info { get; set; }
    }

    /// <summary>
    /// 发布事件的类
    /// </summary>
    public class Publisher
    {
        // Declare the event using EventHandler<T>
        public event EventHandler<EventArgs<string>> RaiseGenericVersionCustomEvent;
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;

        public void DoSomething()
        {
            // Write some code that does something useful here
            // then raise the event. You can also raise(提高、提出、引发 ) an event
            // before you execute a block of code.
            OnRaiseGenericVersionCustomEvent(new EventArgs<string>("OnRaiseGenericVersionCustomEvent: Did something"));
            OnRaiseCustomEvent(new CustomEventArgs("OnRaiseCustomEvent: Did something"));
        }

        // Wrap event invocations(调用) inside a protected virtual method
        // to allow derived classes to override the event invocation behavior
        protected virtual void OnRaiseGenericVersionCustomEvent(EventArgs<string> e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<EventArgs<string>> handler = RaiseGenericVersionCustomEvent;

            // Event will be null if there are no subscribers
            if (handler != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                e.Info += String.Format(" at {0}", DateTime.Now.ToString());

                // Use the () operator to raise the event.
                handler(this, e);
            }
        }

        // Wrap event invocations inside a protected virtual method
        // to allow derived classes to override the event invocation behavior
        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<CustomEventArgs> handler = RaiseCustomEvent;

            // Event will be null if there are no subscribers
            if (handler != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                e.Message += String.Format(" at {0}", DateTime.Now.ToString());

                // Use the () operator to raise the event.
                handler(this, e);
            }
        }
    }

    /// <summary>
    /// 订阅事件的类
    /// </summary>
    public class Subscriber
    {
        private string id;
        public Subscriber(string ID, Publisher pub)
        {
            id = ID;
            // Subscribe to the event using C# 2.0 syntax
            pub.RaiseGenericVersionCustomEvent += GenericVersionCustomEvent;
            pub.RaiseCustomEvent += GenericCustomEvent;
        }

        // Define what actions to take when the event is raised.
        void GenericVersionCustomEvent(object sender, EventArgs<string> e)
        {
            Console.WriteLine(id + " received this message: {0}", e.Info);
        }

        void GenericCustomEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine(id + " received this message: {0}", e.Message);
        }
    }
}
