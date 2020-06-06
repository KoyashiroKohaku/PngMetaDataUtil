using System;
using System.Text;

namespace KoyashiroKohaku.PngMetaDataTool
{
    /// <summary>
    /// ChunkType
    /// </summary>
    public class ChunkType
    {
        /// <summary>
        /// ChunkType
        /// </summary>
        private readonly byte[] _chunkType;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="data"></param>
        public ChunkType(Span<byte> type)
        {
            if (type == null)
            {
                throw new ArgumentNullException($"argument error. argument: '{nameof(type)}' is null.");
            }

            _chunkType = type.ToArray();
        }

        /// <summary>
        /// <see cref="PngMetaDataParser"/>のSpan構造体を返却します。
        /// </summary>
        public Span<byte> Value => _chunkType.AsSpan();

        /// <summary>
        /// <see cref="PngMetaDataParser"/>を文字列に変換して返却します。
        /// </summary>
        /// <param name="encoding">文字エンコーディンgy</param>
        /// <returns></returns>
        public string GetString(Encoding encoding = null)
        {
            if (encoding is null)
            {
                encoding = Encoding.UTF8;
            }

            return encoding.GetString(_chunkType);
        }

        public override string ToString()
        {
            return GetString();
        }
    }
}
