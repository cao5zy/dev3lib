using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Dev3Lib.Media
{
    public sealed class Mp3TagID3V1
    {

        #region inner class
        sealed class Tag
        {
            public readonly int _startPos;
            public readonly int _length;

            private readonly Encoding _encoding;
            public Tag(int startPos, int length)
            {
                _startPos = startPos;
                _length = length;
                _encoding = Encoding.ASCII;
            }

            public string Read(byte[] buffer)
            {
                ShowBuffer(buffer);

                return _encoding
                    .GetString(buffer)
                    .Substring(_startPos, _length)
                    .Trim(new char[]{'\0'});
            }

            public void Update(byte[] buffer, string value)
            {
                byte[] valueBytes = new byte[_length];
                byte[] bytes = _encoding.GetBytes(value);
                int len = bytes.Length;
                if (len > _length)
                    len = _length;

                Array.Copy(bytes, 0, valueBytes, 0, len);
                Array.Copy(valueBytes, 0, buffer, _startPos, _length);
            }

            [Conditional("DEBUG")]
            public void ShowBuffer(byte[] buffer)
            {
                string bufferStr = _encoding.GetString(buffer);
            }
        }
        #endregion
        public readonly string _fileName;
        private const int bufferLen = 128;
        private const string tagFlag = "TAG";
        private readonly byte[] _tagBuffer = new byte[bufferLen];
        private readonly byte[] _oldTagBuffer = new byte[bufferLen];

        #region editable properties

        public string Title
        {
            get
            {
                return _title.Read(_tagBuffer);
            }
            set
            {
                _title.Update(_tagBuffer, value);
            }
        }

        public string Artist
        {
            get
            {
                return _artist.Read(_tagBuffer);
            }
            set
            {
                _artist.Update(_tagBuffer, value);
            }
        }

        public string Album
        {
            get
            {
                return _album.Read(_tagBuffer);
            }
            set
            {
                _album.Update(_tagBuffer, value);
            }
        }

        public string Year
        {
            get
            {
                return _year.Read(_tagBuffer);
            }
            set
            {
                _year.Update(_tagBuffer, value);
            }
        }

        public string Comment
        {
            get
            {
                return _comment.Read(_tagBuffer);
            }
            set
            {
                _comment.Update(_tagBuffer, value);
            }
        }

        #endregion

        #region tags
        private readonly Tag _tag = new Tag(0, 3);
        private readonly Tag _title = new Tag(3, 30);
        private readonly Tag _artist = new Tag(33, 30);
        private readonly Tag _album = new Tag(63, 30);
        private readonly Tag _year = new Tag(93, 4);
        private readonly Tag _comment = new Tag(97, 28);

        #endregion

        public Mp3TagID3V1(string fileName)
        {
            _fileName = fileName;
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                fs.Seek(-bufferLen, SeekOrigin.End);
                fs.Read(_tagBuffer, 0, bufferLen);
            }

            if (string.CompareOrdinal(_tag.Read(_tagBuffer), tagFlag) != 0)
            {
                for (int i = 0; i < bufferLen; i++)
                { _tagBuffer[i] = byte.MinValue; }
            }

            Array.Copy(_tagBuffer, _oldTagBuffer, bufferLen);

        }

        public bool IsEdited()
        {
            for (int i = 0; i < bufferLen; i++)
            {
                if (!_oldTagBuffer[i].Equals(_tagBuffer[i]))
                    return true;
            }

            return false;
        }

        public bool Save()
        {
            using (FileStream fs = new FileStream(_fileName, FileMode.Open))
            {
                if (string.CompareOrdinal(_tag.Read(_tagBuffer), tagFlag) == 0)
                    fs.Seek(-128, SeekOrigin.End);
                else
                {
                    fs.Seek(0, SeekOrigin.End);
                    _tag.Update(_tagBuffer, tagFlag);
                }

                fs.Write(_tagBuffer, 0, 128);

                return true;
            }
        }
    }
}
