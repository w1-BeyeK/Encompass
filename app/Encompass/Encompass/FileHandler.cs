using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
 
using Encompass.Models;
using Encompass.Data;

namespace Encompass
{
    public static class FileHandler
    {

        
        public static bool ExportCardTxt(int userId)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
               // Path.Combine(path, "ENCOMPASS-FILE.txt");
                Service service = new Service();

                List<Balance> balances = service.GetUserCards(userId);
                string[] balancesInString = new string[balances.Count];
 
                for (int i = 0; i < balances.Count; i++)
                {
                    balancesInString[i] = balances[i].ToString();
                }

                //   File.WriteAllLines(Path.Combine(path, "ENCOMPASS-FILE.txt"), balancesInString);
                return true;

                    }
            catch
            {
                return false;
            }
        }
        public static void ExportTransactionHistory(string filePath, string newLine)
        {
            //DateTime - userId = {userId}, transaction = 10.55 - 10.00, cardId = 3
            DateTime dateTime = DateTime.Now;
            try
            {
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, newLine);
                }
                else
                {
                    File.AppendAllText(filePath, newLine);
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
