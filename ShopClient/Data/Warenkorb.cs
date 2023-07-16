using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopClient.Model;

namespace ShopClient.Data
{
    public static class Warenkorb
    {
       public static List<Item> ItemListe;

        public static decimal Gesamtsumme;

        static Warenkorb()
        {
            ItemListe = new List<Item>();
            
        }

        public static int GetProduktIndex(int Id)
        {
            int index = 0;
            for (int i = 0; i < ItemListe.Count(); i++)
            {
                if (ItemListe[i].Id == Id)
                {
                    index = i;
                }
            }
            return index;
        }


        public static void GesamtsummeBerechnen()
        {
            Gesamtsumme = 0;
            for (int i = 0; i < ItemListe.Count(); i++)
            {
                Gesamtsumme += ItemListe[i].WarenkorbPostenPreis;
            }
        }

        public static bool WarenkorbLeerCheck()
        {
            if (Warenkorb.ItemListe.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetMessageString()
        {
            string message = string.Empty;

            for (int i = 0; i < ItemListe.Count; i++)
            {
                message += ItemListe[i].GetMessageString();
            }

            return message; 
        }
        

    }
}
