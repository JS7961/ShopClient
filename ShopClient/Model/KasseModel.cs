using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopClient.Model
{
    public class KasseModel
    {


        public KasseModel()
        {
            Vorname = "";
            Nachname = "";
            Straße = "";
            Plz = "";
            Ort = "";
            Land = "";
            Telefon = "";
            Email = "";
            Zahlungsart = "";
        }



   public string Vorname { get; set; }
 public   string Nachname { get; set; }
 public   string Straße { get; set; }
 public   string  Plz { get; set; }
 public   string Ort { get; set; }
 public   string Land { get; set; }
 public   string Telefon { get; set; }
 public   string Email { get; set; }

 public   string Zahlungsart { get; set; }


        public bool IstAusgefüllt()
        {
            if (Vorname != "" && 
            Nachname != "" && 
            Straße != "" && 
            Plz != "" && 
            Ort != "" && 
            Land != "" && 
            Telefon != "" && 
            Email != "" && 
            Zahlungsart != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string GetMessageString()
        {
            string message = string.Empty;

            message += Vorname + "\n" + Nachname + "\n" + Straße + "\n" + Plz + "\n";
            message += Ort + "\n" + Land + "\n" + Telefon + "\n" + Email + "\n" + Zahlungsart + "\n";

            return message;
        }



    }
}
