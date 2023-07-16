using ShopClient.Data;
using ShopClient.Model;
using ShopClient.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopClient.ViewModel
{
    internal class KasseViewModel : ViewModelBase
    {

       

        public KasseViewModel()
        {
            Vorkasse = false;
            Paypal = false;

            KasseModel1 = new KasseModel(); 


        }


        private KasseModel kasseModel1;

        public KasseModel KasseModel1
        {
            get { return kasseModel1; }
            set 
            { 
                kasseModel1 = value;
                OnPropertyChanged("KasseModel1");
            }
        }





        private bool vorkasse;

        public bool Vorkasse
        {
            get { return vorkasse; }
            set 
            { 
                vorkasse = value;
                if (vorkasse == true)
                {
                    T1 = "Vorkasse";
                    KasseModel1.Zahlungsart = T1;
                }
                else
                {
                    //T1 = "";
                }
                
            }
        }

        private bool paypal;

        public bool Paypal
        {
            get { return paypal; }
            set
            {
                paypal = value;
                if (paypal == true)
                {
                    T1 = "Paypal";
                    KasseModel1.Zahlungsart = T1;
                }
                else
                {
                    //T1 = "";
                }

            }
        }


        private string t1;

        public string T1
        {
            get { return t1; }
            set 
            { 
                t1 = value;
                OnPropertyChanged("T1");
            }
        }




        public RelayCommand BestellungAbsendenCommand
        {
            get
            {
                return new RelayCommand(Absenden, KannSenden);
            }
        }

        public void Absenden(Object parameter)
        {
            string message = string.Empty;
            if (Client.Bereit == true)
            {


                message += "Bestellung1378\n";
                message += KasseModel1.GetMessageString();
                message += Warenkorb.GetMessageString();

                Client.Connect();
                Client.Senden(message);

                Warenkorb.ItemListe.Clear();
                KasseModel1 = new KasseModel();
            }
            else
            {
                MessageBox.Show("Nicht Verbunden");
            }
            

        }

        public bool KannSenden(Object parameter)
        {
            return (KasseModel1.IstAusgefüllt() == true && Warenkorb.WarenkorbLeerCheck() == false);          
        }















    }
}
