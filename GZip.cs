using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERSaveIDEditor
{
    public class GZip
    {
        public static byte[] compress(byte[] data)
        {
            using (var output = new MemoryStream())
            {
                using (var gzip = new GZipStream(output, CompressionMode.Compress))
                using (var source = new MemoryStream(data))
                    source.CopyTo(gzip);
                return output.ToArray();
            }
        }

        public static byte[] decompress(byte[] compressed)
        {
            using (var source = new MemoryStream(compressed))
            using (var gzip = new GZipStream(source, CompressionMode.Decompress))
            using (var output = new MemoryStream())
            {
                gzip.CopyTo(output);
                return output.ToArray();
            }
        }
    }
}
