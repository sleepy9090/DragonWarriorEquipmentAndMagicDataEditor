using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/*
 * Author: Shawn M. Crawford [sleepy]
 * sleepy3d@gmail.com
 * 2018+
 */
namespace DragonWarriorEquipmentAndMagicDataEditor
{
    class Backend
    {
        string path;

        public Backend(string gamePath)
        {
            path = gamePath;
        }

        public string getPriceSingleByte(int offset)
        {
            string price = getHexStringFromFile(offset, 1);
            string priceDec = convertHexToDecTwoChar(price);
            string prettyPriceFinal = priceDec.TrimStart('0');
            return prettyPriceFinal;
        }

        public bool setPriceSingleByte(int offset, string price)
        {
            string hexValue = convertDecToHex(price);
            hexValue = hexValue.PadLeft(0x2, '0');

            return writeByteArrayToFile(this.path, offset, StringToByteArray(hexValue));
        }

        #region common methods
        private static string convertHexToDecFourChar(String hexString)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 4)
                {
                    String hs = string.Empty;

                    hs = hexString.Substring(i, 4);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    // char character = System.Convert.ToChar(decval);
                    ascii += decval;

                }

                return ascii;
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
            }

            return string.Empty;
        }

        private static string convertHexToDecTwoChar(String hexString)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 2)
                {
                    String hs = string.Empty;

                    hs = hexString.Substring(i, 2);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    // char character = System.Convert.ToChar(decval);
                    ascii += decval;

                }

                return ascii;
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
            }

            return string.Empty;
        }

        private static string convertDecToHex(String decString)
        {
            int value = Convert.ToInt32(decString);
            string hexValue = String.Format("{0:X}", value);

            return hexValue;
        }

        private string getHexStringFromFile(int startPoint, int length)
        {
            string hexString = "";
            using (FileStream fileStream = new FileStream(@path, FileMode.Open, FileAccess.Read))
            {
                long offset = fileStream.Seek(startPoint, SeekOrigin.Begin);

                for (int x = 0; x < length; x++)
                {
                    hexString += fileStream.ReadByte().ToString("X2");
                }

            }

            return hexString;
        }

        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private bool writeByteArrayToFile(string fileName, int startPoint, byte[] byteArray)
        {
            bool result = false;
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    fs.Position = startPoint;
                    fs.Write(byteArray, 0, byteArray.Length);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error writing file: {0}", ex);
                result = false;
            }

            return result;
        }
        #endregion
    }
}
