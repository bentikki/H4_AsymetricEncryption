using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsymetricEncryption;

namespace ConsoleVersion
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

                    IAsymetricEncrypter encrypter = new RSAEncrypterXML();
                    byte[] encryptedValue = null;

                    Console.WriteLine("----------Asymetric Encryption with RSA----------");
                    Console.WriteLine();
                    Console.WriteLine("1. Create new Public and Private keys");
                    Console.WriteLine("2. Create an encrypted message.");

                    string menuSelction = Console.ReadLine();

                    switch (menuSelction)
                    {
                        case "1":
                            encrypter.AssignNewKey();
                            break;

                        case "2":
                            Console.Write("Input to encrypt: ");
                            string plaintTextInput = Console.ReadLine();

                            timer.Start();
                            encryptedValue = encrypter.Encrypt(Encoding.UTF8.GetBytes(plaintTextInput));
                            timer.Stop();
                            Console.Write($"{encrypter.Name} encryption: ");
                            Console.WriteLine();
                            Console.WriteLine($"Encrypt Benchmark : " + timer.TimingResult());
                            timer.Reset();

                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Cipher string:");
                            string bitConvertedString = BitConverter.ToString(encryptedValue);
                            Console.WriteLine(bitConvertedString);
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Press any key to try again...");
                            Console.ReadKey();
                            break;

                        default:
                            break;
                    }
                }
                    catch (Exception e)
                {
                    Console.WriteLine("An error has occured.");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to try again...");
                }
            } while (true);

            
        }
    }
}
