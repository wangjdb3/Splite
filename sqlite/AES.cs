
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sqlite
{
    class AES
    {
        private const byte BPOLY = 0x1b;
        private const int BLOCKSIZE = 16;
        private const int KEYBITS = 256;
        private const int ROUNDS = 14;
        private const int KEYLENGTH = 32;
        private const int EXPANDED_KEY_SIZE = (BLOCKSIZE * (ROUNDS + 1));

        static string key = "PMB^C==w4a;>!6)W";
        static byte[] AES_Key_Table = System.Text.Encoding.Default.GetBytes(key);

        static byte[] block1 = new byte[256];
        static byte[] block2 = new byte[256];
        static byte[] tempbuf = new byte[256];

        static byte[] powTbl; //!< Final location of exponentiation lookup table.
        static byte[] logTbl; //!< Final location of logarithm lookup table.
        static byte[] sBox; //!< Final location of s-box.
        static byte[] sBoxInv; //!< Final location of inverse s-box.
        static byte[] expandedKey; //!< Final location of expanded key.

        private void CalcPowLog(ref byte[] powTbl, ref byte[] logTbl)
        {
            byte i = 0;
            byte t = 1;

            do
            {
                // Use 0x03 as root for exponentiation and logarithms.
                powTbl[i] = t;
                logTbl[t] = i;
                i++;

                // Muliply t by 3 in GF(2^8).
                t ^= (byte)((t << 1) ^ ((t & 0x80)==0x80 ? BPOLY : 0));
            } while (t != 1); // Cyclic properties ensure that i < 255.

            powTbl[255] = powTbl[0]; // 255 = '-0', 254 = -1, etc.
        }
        void CalcSBox(ref byte[] sBox, ref byte[] logTbl)
        {
            byte i, rot;
            byte temp;
            byte result;

            // Fill all entries of sBox[].
            i = 0;
            do
            {
                //Inverse in GF(2^8).
                if (i > 0)
                {
                    temp = powTbl[255 - logTbl[i]];
                }
                else
                {
                    temp = 0;
                }

                // Affine transformation in GF(2).
                result = (byte)(temp ^ 0x63); // Start with adding a vector in GF(2).
                for (rot = 0; rot < 4; rot++)
                {
                    // Rotate left.
                    temp = (byte)((temp << 1) | (temp >> 7));

                    // Add rotated byte in GF(2).
                    result ^= temp;
                }

                // Put result in table.
                sBox[i] = result;
            } while (++i != 0);
        }

        void CalcSBoxInv(ref byte[] sBox, ref byte[] sBoxInv)
        {
            byte i = 0;
            byte j = 0;

            // Iterate through all elements in sBoxInv using  i.
            do
            {
                // Search through sBox using j.
                do
                {
                    // Check if current j is the inverse of current i.
                    if (sBox[j] == i)
                    {
                        // If so, set sBoxInc and indicate search finished.
                        sBoxInv[i] = j;
                        j = 255;
                    }
                } while (++j != 0);
            } while (++i != 0);
        }
    }
}
