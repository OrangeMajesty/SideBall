namespace Core
{
    public static partial class Simulation
    {
        static class InstanceRegister<T> where T : class, new()
        {
            public static T instance = new T();
        }
    }
}