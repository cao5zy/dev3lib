using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dev3Lib.DbConvert
{
    public sealed class DataReaderAdapter : IDisposable
    {
        private IDataReader _reader = null;
        private Dictionary<string, int> _dic = new Dictionary<string, int>();

        public DataReaderAdapter(IDataReader reader)
        {
            _reader = reader;
        }

        public string ToString(string name, string defaultVal = "")
        {
            int ordinal = GetOrdinal(name);

            if (_reader.IsDBNull(ordinal))
                return defaultVal;
            else
                return _reader[ordinal].ToString();
        }

        public int ToInt32(string name, int defaultVal = 0)
        {
            int ordinal = GetOrdinal(name);

            if (_reader.IsDBNull(ordinal))
                return defaultVal;
            else
                return _reader.GetInt32(ordinal);
        }

        public double ToDouble(string name, double defaultVal = 0)
        {
            int ordinal = GetOrdinal(name);

            if (_reader.IsDBNull(ordinal))
                return defaultVal;
            else
                return _reader.GetDouble(ordinal);
        }

        public decimal ToDecimal(string name, decimal defaultVal = 0)
        {
            int ordinal = GetOrdinal(name);

            if (_reader.IsDBNull(ordinal))
                return defaultVal;
            else
                return _reader.GetDecimal(ordinal);
        }

        public DateTime ToDateTime(string name)
        {
            int ordinal = GetOrdinal(name);

            if (_reader.IsDBNull(ordinal))
                return DateTime.MinValue;
            else
                return _reader.GetDateTime(ordinal);
        }

        public bool Read()
        {
            return _reader.Read();
        }

        private int GetOrdinal(string name)
        {
            int ordinal = 0;
            if (!_dic.ContainsKey(name))
            {
                ordinal = _reader.GetOrdinal(name);
                _dic.Add(name, ordinal);
            }
            else
                ordinal = _dic[name];
            return ordinal;
        }

        public void Dispose()
        {
            _reader.Close();
            _reader.Dispose();
            _reader = null;
        }
    }
}
