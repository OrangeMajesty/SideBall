using System;

namespace Core
{
    public static partial class Simulation
    {
        
        public abstract class Event : IComparable<Event>
        {
            internal float tick;

            public int CompareTo(Event other)
            {
                return tick.CompareTo(other.tick);
            }

            public abstract void Execute();

            internal virtual void ExecuteEvent()
            {
                Execute();
            }

            internal virtual void CleanUp() {}
        }
        
        public abstract class Event<T> : Event where T : Event<T>
        {
            private static System.Action<T> OnExecute;

            internal override void ExecuteEvent()
            {
                Execute();
                OnExecute?.Invoke((T)this);
            }
        }
    }
}