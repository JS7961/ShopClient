using ShopClient.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClient.Data
{
    public static class Produkte
    {
        public static List<Item> ItemListe;


        

        

        static Produkte()
        {
            ItemListe = new List<Item>();         

            if (Client.Bereit == true)
            {
                Client.ProduktListeAnfragen();
            }
            else
            {
                ItemListe.Add(new Item(1, "Brot", 15.99m));
                ItemListe.Add(new Item(2, "Hut", 1.50m));
                ItemListe.Add(new Item(3, "Fisch", 85.99m));
            }
           
        }



        public static Item GetProdukt(int Id)
        {
            Item Item1;

            Item1 = ItemListe.Find((x) => { return x.Id == Id; });
            

            if (Item1 == null)
            {
                Item1 = new Item(0, "", 0);
                return Item1;
            }
            else
            {
                return Item1;   
            }
        }


        



    }
}
