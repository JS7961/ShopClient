using ShopClient.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClient.Model
{
    public class Item
    {

        public Item(int id,string name, decimal preis)
        {
            Id = id;
            Name = name;            
            PreisAnzeige = preis.ToString()+ " €";
            Preis = preis;
        }



        

        public int Id { get; set; }
        public string Name { get; set; }

        public string PreisAnzeige { get; set; }
        public decimal Preis { get; set; }
        
        


        private int anzahlWarenkorb;
        public int AnzahlWarenkorb 
        {
            get { return anzahlWarenkorb; }
            set
            {
                anzahlWarenkorb = value;
                WarenkorbPostenPreis = anzahlWarenkorb * Preis;
            }
        }

        private decimal warenkorbPostenPreis;

        public decimal WarenkorbPostenPreis
        {
            get { return warenkorbPostenPreis; }
            set 
            { 
                warenkorbPostenPreis = value;
                WarenkorbPostenPreisAnzeige = "€ " + warenkorbPostenPreis;
            }
        }

        public string WarenkorbPostenPreisAnzeige { get; set; }




        public string GetMessageString()
        {
            string message = string.Empty;

            message += Id.ToString() +"\n"+ AnzahlWarenkorb.ToString()+"\n";

            return message; 
        }









    }
}
