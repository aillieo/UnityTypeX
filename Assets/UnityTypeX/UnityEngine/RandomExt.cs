// -----------------------------------------------------------------------
// <copyright file="RandomExt.cs" company="AillieoTech">
// Copyright (c) AillieoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace AillieoUtils.TypeX.Vector3Ext
{
    using System;
    using Random = UnityEngine.Random;

    public static class RandomExt
    {
        public static T OneOf<T>(T item0, T item1)
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    return item0;
                case 1:
                    return item1;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        public static T OneOf<T>(T item0, T item1, T item2)
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    return item0;
                case 1:
                    return item1;
                case 2:
                    return item2;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        public static T OneOf<T>(T item0, T item1, T item2, T item3)
        {
            switch (Random.Range(0, 4))
            {
                case 0:
                    return item0;
                case 1:
                    return item1;
                case 2:
                    return item2;
                case 3:
                    return item3;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        public static T OneOf<T>(T item0, T item1, T item2, T item3, T item4)
        {
            switch (Random.Range(0, 5))
            {
                case 0:
                    return item0;
                case 1:
                    return item1;
                case 2:
                    return item2;
                case 3:
                    return item3;
                case 4:
                    return item4;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}
