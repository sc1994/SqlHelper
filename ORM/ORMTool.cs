﻿using System;
using System.Text;

namespace ORM
{
    /// <summary>
    /// 自定义方法
    /// </summary>
    public static class ORMTool
    {
        public static bool NotIn<T>(this T field, T[] values) where T : struct
        {
            return true;
        }

        public static bool NotIn(this string field, string[] values)
        {
            return true;
        }
        public static bool NotIn(this DateTime field, DateTime[] values)
        {
            return true;
        }

        public static bool In<T>(this T field, T[] values) where T : struct
        {
            return true;
        }
        public static bool In(this string field, string[] values)
        {
            return true;
        }
        public static bool In(this DateTime field, DateTime[] values)
        {
            return true;
        }

        public static int Count(object value)
        {
            return 0;
        }
        public static int Max(object value)
        {
            return 0;
        }
        public static int Min(object value)
        {
            return 0;
        }

        public static StringBuilder TryRemove(this StringBuilder that, int startIndex, int length)
        {
            if (that.Length > startIndex + length)
                return that.Remove(startIndex, length);
            return that;
        }
    }
}
