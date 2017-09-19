using System;
using System.IO;

namespace RifKeyOut
{
    class IdParser
    {
        public void Parse(string path)
        {
            try
            {
            BinaryReader reader = new BinaryReader(new FileStream(path, FileMode.Open));
            //Set the position of the reader
            reader.BaseStream.Position = 0x10;
            //Read the offset
            String outPut = System.Text.Encoding.ASCII.GetString((reader.ReadBytes(36)));
            String titleId = outPut.Substring(7, 9);
            Console.WriteLine("Title ID : \t" + titleId); //reader.ReadBytes(32)
            Console.WriteLine("Full pkg ID : \t" + outPut);

            reader.BaseStream.Position = 0x50;
            //Read the offset
            String titleKey = BitConverter.ToString(reader.ReadBytes(16)).Replace("-", null);
            String outPutFile = AppDomain.CurrentDomain.BaseDirectory + "\\" + titleId + ".txt";
            Console.WriteLine("Title key : \t" + titleKey); //reader.ReadBytes(16)
            File.WriteAllText(outPutFile, titleKey);
                }catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
                throw;
            }
        }
    }
}