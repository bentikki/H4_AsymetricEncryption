using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsymetricEncryption;

namespace ConsoleVersionReader
{
    class Program
    {
        static void Main(string[] args)
        {
            IBenchmarkTimer timer = FactoryInit.BenchmarkTimer;

            do
            {
                try
                {
                    Console.Clear();
                    Console.Write("Encrypted cipher: ");
                    string plaintTextInput = ReadLine();


                    byte[] bytes = plaintTextInput.Split('-')
                        .Select(x => byte.Parse(x, NumberStyles.HexNumber))
                        .ToArray();

                    IAsymetricEncrypter encrypter = new RSAEncrypterXML();
                    byte[] decryptedValue = null;

                    timer.Start();
                    decryptedValue = encrypter.Decrypt(bytes);
                    timer.Stop();
                    Console.WriteLine();
                    Console.WriteLine("Decrypted Value   : " + Encoding.UTF8.GetString(decryptedValue));
                    Console.WriteLine();
                    Console.WriteLine($"Decrypt Benchmark: " + timer.TimingResult());
                    timer.Reset();

                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error has occured.");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to try again...");
                }
                
            } while (true);


        }

        // Static function, to allow larger string input in readline. 
        // Used so the encrypted text is able to be pasted in ReadLine input.
        private static string ReadLine()
        {
            byte[] inputBuffer = new byte[1024];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
            string strInput = Console.ReadLine();
            return strInput;
        }
    }
}

