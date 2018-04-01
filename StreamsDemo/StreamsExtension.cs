using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace StreamsDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx

    public static class StreamsExtension
    {
        #region Public members

        #region 1. TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using (FileStream stream = new FileStream(sourcePath, FileMode.Open))
            {
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                using (FileStream newStream = new FileStream(destinationPath, FileMode.OpenOrCreate))
                {
                    newStream.Write(bytes, 0, bytes.Length);
                }
            }

            byte[] count = File.ReadAllBytes(destinationPath);

            return count.Length;
        }

        #endregion

        #region 2. TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            // TODO: step 1. Use StreamReader to read entire file in string

            // TODO: step 2. Create byte array on base string content - use  System.Text.Encoding class

            // TODO: step 3. Use MemoryStream instance to read from byte array (from step 2)

            // TODO: step 4. Use MemoryStream instance (from step 3) to write it content in new byte array

            // TODO: step 5. Use Encoding class instance (from step 2) to create char array on byte array content

            // TODO: step 6. Use StreamWriter here to write char array content in new file

            InputValidation(sourcePath, destinationPath);

            int count = 0;
            using (StreamReader streamReader = new StreamReader(sourcePath))
            {

                Encoding encoding = Encoding.ASCII;
                byte[] bytes = encoding.GetBytes(streamReader.ReadToEnd());

                using (MemoryStream memoryStream = new MemoryStream(bytes, 0, bytes.Length))
                {
                    byte[] newBytes = memoryStream.ToArray();

                    char[] symbols = encoding.GetChars(newBytes);
                    using (StreamWriter streamWriter = new StreamWriter(destinationPath))
                    {
                        streamWriter.Write(symbols);
                    }
                    count = newBytes.Length;
                }
            }

            return count;
        }

        #endregion

        #region 3. TODO: Implement by block copy logic using FileStream buffer.

        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using (FileStream stream = new FileStream(sourcePath, FileMode.Open))
            {
                using (FileStream newStream = new FileStream(destinationPath, FileMode.OpenOrCreate))
                {
                    stream.CopyTo(newStream);
                }
            }

            byte[] bytes = File.ReadAllBytes(destinationPath);

            return bytes.Length;
        }


        #endregion

        #region 4. TODO: Implement by block copy logic using MemoryStream.

        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            // TODO: Use InMemoryByByteCopy method's approach
            throw new NotImplementedException();
        }

        #endregion

        #region 5. TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            using (FileStream stream = new FileStream(sourcePath, FileMode.Open))
            {
                using (BufferedStream newStream = new BufferedStream(new FileStream(destinationPath, FileMode.OpenOrCreate)))
                {
                    stream.CopyTo(newStream);
                }
            }
            byte[] bytes = File.ReadAllBytes(destinationPath);

            return bytes.Length;
        }

        #endregion

        #region 6. TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            using (StreamReader streamReader = new StreamReader(sourcePath))
            {
                using (StreamWriter streamWriter = new StreamWriter(destinationPath))
                {
                    streamWriter.Write(streamReader.ReadToEnd());
                }
            }

            byte[] bytes = File.ReadAllBytes(destinationPath);

            return bytes.Length;

        }

        #endregion

        #region 7. TODO: Implement content comparison logic of two files 

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            if (File.ReadAllBytes(sourcePath).SequenceEqual(File.ReadAllBytes(destinationPath)))
            {
                return true;
            }

            return false;
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (sourcePath == null)
            {
                throw new ArgumentNullException(nameof(sourcePath));
            }

            if (destinationPath == null)
            {
                throw new ArgumentNullException(nameof(destinationPath));
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException(nameof(sourcePath));
            }
        }

        #endregion

        #endregion

    }
}

