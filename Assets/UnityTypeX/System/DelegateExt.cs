using System;

namespace AillieoUtils.TypeX.DelegateExt
{
    public static class DelegateExt
    {
        public static void RemoveAll<T>(ref T del) where T : Delegate
        {
            if (del != null)
            {
                foreach (var d in del.GetInvocationList())
                {
                    del = Delegate.Remove(del, d) as T;
                }
            }
        }

        public static void RemoveAll<T>(ref Action del)
        {
            if (del != null)
            {
                foreach (var d in del.GetInvocationList())
                {
                    del -= (Action)d;
                }
            }
        }

        public static void RemoveAll<T>(ref Action<T> del)
        {
            if (del != null)
            {
                foreach (var d in del.GetInvocationList())
                {
                    del -= (Action<T>)d;
                }
            }
        }

        public static void RemoveAll<T1, T2>(ref Action<T1, T2> del)
        {
            if (del != null)
            {
                foreach (var d in del.GetInvocationList())
                {
                    del -= (Action<T1, T2>)d;
                }
            }
        }

        public static void RemoveAll<T1, T2, T3>(ref Action<T1, T2, T3> del)
        {
            if (del != null)
            {
                foreach (var d in del.GetInvocationList())
                {
                    del -= (Action<T1, T2, T3>)d;
                }
            }
        }

        public static void RemoveAll<T1, T2, T3, T4>(ref Action<T1, T2, T3, T4> del)
        {
            if (del != null)
            {
                foreach (var d in del.GetInvocationList())
                {
                    del -= (Action<T1, T2, T3, T4>)d;
                }
            }
        }

        public static void RemoveAll<T1, T2, T3, T4, T5>(ref Action<T1, T2, T3, T4, T5> del)
        {
            if (del != null)
            {
                foreach (var d in del.GetInvocationList())
                {
                    del -= (Action<T1, T2, T3, T4, T5>)d;
                }
            }
        }

        public static void RemoveAll<R>(ref Func<R> del)
        {
            if (del != null)
            {
                foreach (var d in del.GetInvocationList())
                {
                    del -= (Func<R>)d;
                }
            }
        }

        public static void RemoveAll<T, R>(ref Func<T, R> del)
        {
            if (del != null)
            {
                foreach (var d in del.GetInvocationList())
                {
                    del -= (Func<T, R>)d;
                }
            }
        }

        public static void RemoveAll<T1, T2, R>(ref Func<T1, T2, R> del)
        {
            if (del != null)
            {
                foreach (var d in del.GetInvocationList())
                {
                    del -= (Func<T1, T2, R>)d;
                }
            }
        }

        public static void RemoveAll<T1, T2, T3, R>(ref Func<T1, T2, T3, R> del)
        {
            if (del != null)
            {
                foreach (var d in del.GetInvocationList())
                {
                    del -= (Func<T1, T2, T3, R>)d;
                }
            }
        }

        public static void RemoveAll<T1, T2, T3, T4, R>(ref Func<T1, T2, T3, T4, R> del)
        {
            if (del != null)
            {
                foreach (var d in del.GetInvocationList())
                {
                    del -= (Func<T1, T2, T3, T4, R>)d;
                }
            }
        }

        public static void RemoveAll<T1, T2, T3, T4, T5, R>(ref Func<T1, T2, T3, T4, T5, R> del)
        {
            if (del != null)
            {
                foreach (var d in del.GetInvocationList())
                {
                    del -= (Func<T1, T2, T3, T4, T5, R>)d;
                }
            }
        }

        public static void RemoveAll<T>(ref Predicate<T> del)
        {
            if (del != null)
            {
                foreach (var d in del.GetInvocationList())
                {
                    del -= (Predicate<T>)d;
                }
            }
        }
    }
}
