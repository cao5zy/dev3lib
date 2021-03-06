﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.DataCheck
{
    public static class DataCheckUtility
    {
        /// <summary>
        /// throw ArgumentOutOfRangeException
        /// </summary>
        /// <param name="data"></param>
        public static void CheckZero(this int data)
        {
            if (data == 0)
                throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// throw ArgumentOutOfRangeException
        /// </summary>
        /// <param name="data"></param>
        public static void CheckZero(this long data)
        {
            if (data == 0)
                throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// throw ArgumentOutOfRangeException
        /// </summary>
        /// <param name="data"></param>
        public static void CheckZero(this decimal data)
        {
            if (data == 0)
                throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// throw ArgumentOutOfRangeException
        /// </summary>
        /// <param name="data"></param>
        public static void CheckZero(this double data)
        {
            if (data == 0)
                throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// throw ArgumentOutOfRangeException
        /// </summary>
        /// <param name="data"></param>
        public static void CheckEmpty(this string data)
        {
            if (data == null)
                throw new ArgumentNullException();
        }

        /// <summary>
        /// throw ArgumentOutOfRangeException
        /// </summary>
        /// <param name="data"></param>
        public static void CheckNull<T>(this T data) where T : class
        {
            if (data == null)
                throw new ArgumentNullException();
        }
    }
}
