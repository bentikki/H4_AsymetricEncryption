using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsymetricEncryption
{
    public interface IAsymetricEncrypter
    {
        string Name { get; }
        byte[] Decrypt(byte[] dataToDecrypt);
        byte[] Encrypt(byte[] dataToEncrypt);
        void AssignNewKey();
        bool KeyExists();
    }
}
