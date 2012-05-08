using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dev3Lib.Algorithms;

namespace Dev3Lib
{
    public sealed class Pagination<T>
    {
        private readonly T[] _items;
        private readonly int _itemCount;

        public readonly int _pagesCount;
        public Pagination(T[] items, int itemCount)
        {
            if (itemCount == 0)
                throw new ArgumentException("itemCount");

            _items = items;
            _itemCount = itemCount;

            _pagesCount = (int)Math.Ceiling((decimal)items.SafeCount() / itemCount);
        }

        public T[] GetPage(int pageIndex)
        {
            if (pageIndex > _pagesCount || pageIndex < 1)
                return null;

            T[] results = null;
            int len = 0;
            if (pageIndex * _itemCount > _items.Length)
            {
                len = _items.Length;
                results = new T[_itemCount - pageIndex * _itemCount + _items.Length];
            }
            else
            {
                len = pageIndex * _itemCount;
                results = new T[_itemCount];
            }


            int index = 0;
            for (int i = (pageIndex - 1) * _itemCount;
                i < len;
                i++)
            {
                results[index++] = _items[i];
            }

            return results;
        }



    }
}
