using System;

namespace RifKeyOut
{
    class Program
    {
        static void Main(string[] args)
        {
            IdParser parse = new IdParser();
            if (args.Length != 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    
                    String path = args[i];
                    if (HasRifExtension(path))
                    {
                        parse.Parse(path);
                    }
                    else
                    {
                        Console.WriteLine("only rif files and work.bin are supported!");
                    }
                }

            }
            Console.WriteLine("Usage:");
            Console.WriteLine("Drag rif files onto executable, output is in same location as the executable! ");
            Console.Write("Press Enter to close window ...");
            Console.Read();
        }
        public static bool HasRifExtension(string source)
        {
            return (source.EndsWith(".rif") || source.EndsWith(".bin"));
        }
    }
}
