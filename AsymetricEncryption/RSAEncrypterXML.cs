using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AsymetricEncryption
{
    public class RSAEncrypterXML : IAsymetricEncrypter
    {
        private int _keyLength = 2048;
        private string _privateKeyPath = @"C:\_ProjectsGIT\H4\H4_AsymetricEncryption\KeyPath\Private_Key.xml";
        private string _publicKeyPath = @"C:\_ProjectsGIT\H4\H4_AsymetricEncryption\KeyPath\Public_Key.xml";

        public string Name => "RSA with XML";

        public void AssignNewKey()
        {
            using (var rsa = new RSACryptoServiceProvider(this._keyLength))
            {
                rsa.PersistKeyInCsp = false;

                if (File.Exists(this._privateKeyPath))
                {
                    File.Delete(this._privateKeyPath);
                }

                if (File.Exists(this._publicKeyPath))
                {
                    File.Delete(this._publicKeyPath);
                }

                var publicKeyfolder = Path.GetDirectoryName(this._publicKeyPath);
                var privateKeyfolder = Path.GetDirectoryName(this._privateKeyPath);

                if (!Directory.Exists(publicKeyfolder))
                {
                    throw new Exception("Public path does not exist.");
                }

                if (!Directory.Exists(privateKeyfolder))
                {
                    throw new Exception("Private path does not exist.");
                }

                var PublicRsaXML = rsa.ToXmlString(false);
                var PrivateRsaXML = rsa.ToXmlString(true);

                File.WriteAllText(this._publicKeyPath, PublicRsaXML);
                File.WriteAllText(this._privateKeyPath, PrivateRsaXML);
            }
        }

        public byte[] Decrypt(byte[] dataToDecrypt)
        {
            try
            {
                byte[] encryptedData;

                using (var rsa = new RSACryptoServiceProvider(this._keyLength))
                {
                    rsa.PersistKeyInCsp = false;
                    rsa.FromXmlString(File.ReadAllText(this._privateKeyPath));

                    encryptedData = rsa.Decrypt(dataToDecrypt, false);
                }

                return encryptedData;
            }
            catch (Exception e)
            {
                throw new Exception("Could not decrypt data.", e);
            }
        }

        public byte[] Encrypt(byte[] dataToEncrypt)
        {
            try
            {
                byte[] encryptedData;

                using (var rsa = new RSACryptoServiceProvider(this._keyLength))
                {
                    rsa.PersistKeyInCsp = false;
                    rsa.FromXmlString(File.ReadAllText(this._publicKeyPath));

                    encryptedData = rsa.Encrypt(dataToEncrypt, false);
                }
                
                return encryptedData;
            }
            catch (Exception e)
            {
                throw new Exception("Could not encrypt data.", e);
            }
        }
    }
}
