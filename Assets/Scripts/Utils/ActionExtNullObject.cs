using System.Collections.Generic;

namespace System
{
    public static class ActionExt
    {
        private static readonly Delegate nullObject = new Action(() => { });

        private static readonly Dictionary<Type, MulticastDelegate> nullObjects = new Dictionary<Type, MulticastDelegate>();

        public static bool IsNullObject(this Action action) =>
            action.Equals(nullObject);

        public static bool IsNullObject<T>(this Action<T> action) =>
            GetNullObjectSafe<T>().Equals(action);

        public static Action GetNullObject() =>
            (Action)nullObject;

        public static Action<T> GetNullObject<T>() =>
            (Action<T>)GetNullObjectSafe<T>();

        private static MulticastDelegate GetNullObjectSafe<T>()
        {
            Type type = typeof(T);
            if (!nullObjects.ContainsKey(type))
                nullObjects.Add(type, new Action<T>((t) => { }));
            return nullObjects[type];
        }
    }
}