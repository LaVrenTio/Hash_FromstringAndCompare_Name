using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Hash_fromstring_compare_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string datiSorgente = "";
            byte[] tempdatiSorgenteBytes;
            byte[] tempHash;
            string esaStringHash = "";
            string esaStringHashToCheck = "";

            datiSorgente = "LorenzoMalvezzi";
            //trasformo la stringa in un array di byte
            tempdatiSorgenteBytes = ASCIIEncoding.ASCII.GetBytes(datiSorgente);
            //traformo l'array di byte appena creato in un hash di byte
            tempHash = new MD5CryptoServiceProvider().ComputeHash(tempdatiSorgenteBytes);
            //ritrasformo tutto in una stringa esadecimale
            Console.Out.WriteLine(ByteArrayToString(tempHash));
            Console.ReadKey();
            esaStringHash = ByteArrayToString(tempHash);
            datiSorgente = "Lorenzo Malvezzi";
            //in modo super compatto creo la mia stringa esadecimale rappresentante l'Hash di unaltra stringa di origine:
            esaStringHashToCheck = ByteArrayToString(ArrayHashFromArrayByte(ByteArrayFromString(datiSorgente)));
            Console.Out.WriteLine(esaStringHashToCheck);
            Console.ReadKey();
            
            Console.Out.WriteLine($"i due codici hash sono uguali?:\n{CheckTwoStrings(esaStringHash, esaStringHashToCheck)}");
            Console.ReadKey();
        }
        //confronta se due stringhe sono uguali
        public static bool CheckTwoStrings(string string1, string string2)
        {
            bool result = false;
            if (string1.Length == string2.Length)
            {
                int i = 0;
                while ((i < string1.Length) && (string1[i] == string2[i]))
                {
                    i++;
                }
                if (i == string1.Length) { result = true; }
            }
            return result;
        }
        //trasformo una stringa in un array di bytes
        public static byte[] ByteArrayFromString(string str)
        {
            byte[] bytesDaString = ASCIIEncoding.ASCII.GetBytes(str);
            return bytesDaString;
        }
        //traasformo un array di bytes in un array hash di bytes che per semplicità di lettura andrà successivamente riconvertito in stringa esadecimale
        public static byte[] ArrayHashFromArrayByte(byte[] bytes)
        {
            byte[] hashFromArrayBites = new MD5CryptoServiceProvider().ComputeHash(bytes);
            return hashFromArrayBites;
        }
        //trasformo un array di bytes in una stringa esadecimale
        public static string ByteArrayToString(byte[] arrInputbytes)
        {
            int i;
            StringBuilder stringBuilder = new StringBuilder(arrInputbytes.Length);
            for (i = 0; i < arrInputbytes.Length; i++)
            {
                stringBuilder.Append(arrInputbytes[i].ToString("X2"));
            }
            return stringBuilder.ToString();
        }
    }

}
