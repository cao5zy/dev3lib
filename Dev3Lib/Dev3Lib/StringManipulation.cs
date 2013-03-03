using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dev3Lib.Algorithms;

namespace Dev3Lib
{
    public static class StringManipulation
    {
        public static StringBuilder InsertHead(this StringBuilder sb, string str)
        {
            return sb.Insert(0, str);
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNotEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static bool NotExceed(this string str, int len)
        {
            return str.IsNotEmpty() && str.Length <= len;
        }

        public static bool NullOrNotExceed(this string str, int len)
        {
            return str == null || str.Length <= len;
        }

        public static bool OrdinalIngoreCaseCompare(this string str, string target)
        {
            return string.Compare(str, target, StringComparison.OrdinalIgnoreCase) == 0;
        }

        public static int IndexOfT(this string str, char c, int startIndex, int returnAtPosCount)
        {
            int pos = str.IndexOf(c, startIndex);
            int posCount = 0;
            if (pos == -1)
                return pos;
            posCount++;

            for (int i = 0; i < returnAtPosCount && posCount != returnAtPosCount; i++)
            {
                pos = str.IndexOf(c, ++pos);
                if (pos == -1)
                    return pos;
                else
                    posCount++;
            }

            return pos;
        }

        public static string FormatWith(this string targetStr, object val1)
        {
            return string.Format(targetStr, val1);
        }

        public static string FormatWith(this string targetStr, object val1, object val2)
        {
            return string.Format(targetStr, val1, val2);
        }

        public static List<string> SafeSplitWith(this string target, string splitTag)
        {
            List<string> targetList = new List<string>();
            if (string.IsNullOrEmpty(target))
                return targetList;

            int lastIndex = 0;
            for (int i = 0; i < target.Length; )
            {
                int index = target.IndexOf(splitTag, lastIndex);
                if (index != -1)
                {
                    targetList.Add(target.Substring(lastIndex, index - lastIndex));
                    i = ++index;
                    lastIndex = i;
                }
                else
                {
                    targetList.Add(target.Substring(i, target.Length - i));
                    break;
                }
            }

            return targetList;
        }

        public static string SafeJoinWith(this IEnumerable<string> targets, string spliter)
        {
            if (targets.IsNullOrEmpty())
                return string.Empty;

            return string.Join(spliter, targets.SafeToArray());
        }
    }
}
