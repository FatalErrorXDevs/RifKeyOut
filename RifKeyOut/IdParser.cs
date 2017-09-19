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
                // check if its a valid rif for nonpdrm
                reader.BaseStream.Position = 0x0;
                String check = BitConverter.ToString(reader.ReadBytes(16)).Replace("-", null);
                if(check.Equals("0001000100010002EFCDAB8967452301")){
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
                    
                }
                Console.WriteLine("this is not a valid NoNPDRM rif or work bin!");
            }   
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
                throw;
            }
        }
    }
}