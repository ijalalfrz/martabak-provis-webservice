using MartabakProvis.Models;
using MartabakProvis.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MartabakProvis.Helper
{
    public static class Util
    {
        public static string GetSHA1HashData(string data)
        {
            //create new instance of md5
            SHA1 sha1 = SHA1.Create();

            //convert the input text to array of bytes
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();
        }

        public static void initAdmin()
        {
            Database db = new Database();
            UserModel usr = new UserModel();
            UserRepo repo = new UserRepo();

            if (repo.GetByUsername("toko1") == null)
            {
                usr.nama = "Admin";
                usr.username = "toko1";
                usr.role = "admin";
                usr.id_toko = null;
                usr.password = GetSHA1HashData("mamen123");
                try
                {
                    if (!repo.Insert(usr))
                    {
                        throw new Exception("error");
                    }
                }catch(Exception e)
                {
                    int a = 1;
                }
              
            }
        }

        public static bool ValidateSHA1HashData(string inputData, string storedHashData)
        {
            //hash input text and save it string variable
            string getHashInputData = GetSHA1HashData(inputData);

            if (string.Compare(getHashInputData, storedHashData) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
