using ShopClient.Data;
using ShopClient.Model;
using ShopClient.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopClient.ViewModel
{
    internal class WarenkorbViewModel:ViewModelBase
    {

        public ObservableCollection<Item> ItemListe { get; set; }

        public WarenkorbViewModel()
        {
            ItemListe = new ObservableCollection<Item>();

            for (int i = 0; i < Warenkorb.ItemListe.Count(); i++)
            {
                ItemListe.Add(Warenkorb.ItemListe[i]);
            }

            WarenkorbLeerCheck();
            GesamtsummeAnzeigeErneuern();
        }

        public RelayCommand DeleteFromCart
        {
            get
            {
                return new RelayCommand(Delete, canExecute => true);
            }
        }



        public void Delete(Object parameter)
        {
            int wert = 0, index = 0;

            if (parameter != null)
            {
                wert = (int)parameter;
            }            

            index = Warenkorb.GetProduktIndex(wert);

            Warenkorb.ItemListe.RemoveAt(index);
            ItemListe.RemoveAt(index);
            WarenkorbLeerCheck();
            GesamtsummeAnzeigeErneuern();
            //Erneuern();
        }



        public RelayCommand AnzahlErhöhen
        {
            get
            {
                return new RelayCommand(Erhöhen, canExecute => true);
            }
        }

        public void Erhöhen(Object parameter)
        {
            int wert = 0,index=0;

            if (parameter != null)
            {
                wert = (int)parameter;
            }

            index=Warenkorb.GetProduktIndex(wert);

            
            Warenkorb.ItemListe[index].AnzahlWarenkorb++;
            Erneuern();
            
        }


        public RelayCommand AnzahlSenken
        {
            get
            {
                return new RelayCommand(Senken, KannSenken);
            }
        }

        public void Senken(Object parameter)
        {
            int wert = 0, index = 0;

            if (parameter != null)
            {
                wert = (int)parameter;
            }

            index = Warenkorb.GetProduktIndex(wert);

            
            Warenkorb.ItemListe[index].AnzahlWarenkorb--;
            Erneuern();
        }

        public bool KannSenken(Object parameter)
        {
            int wert = 0, index = 0;

            if (parameter != null)
            {
                wert = (int)parameter;
            }

            index = Warenkorb.GetProduktIndex(wert);

            if (Warenkorb.ItemListe.Count() > 0)
            {
                if (Warenkorb.ItemListe[index].AnzahlWarenkorb > 1)
                {
                    return true;
                }
            }
            return false;
        }



        public void Erneuern()
        {
            //ItemListe.Add(new Item(0, "", "", 0, "", 0));
           // ItemListe.RemoveAt(ItemListe.Count - 1);
            //ItemListe.Add(new Item(0, "", "", 0, "", 0));

            
                ItemListe.Clear();
            

            for (int i = 0; i < Warenkorb.ItemListe.Count(); i++)
            {
                ItemListe.Add(Warenkorb.ItemListe[i]);
            }
            WarenkorbLeerCheck();

            GesamtsummeAnzeigeErneuern();
        }


        private Visibility leer;

        public Visibility Leer
        {
            get { return leer; }
            set 
            { 
                leer = value;
                OnPropertyChanged("Leer");
            }
        }

        private void WarenkorbLeerCheck()
        {
            if (Warenkorb.WarenkorbLeerCheck() == true)
            {
                Leer = Visibility.Visible;
            }
            else
            {
                Leer = Visibility.Hidden;
            }
        }



        private string gesamtsummeanzeige;

        public string GesamtsummeAnzeige 
        { 
            get
            {
                return gesamtsummeanzeige;
            }

            set 
            { 
                gesamtsummeanzeige = value;
                OnPropertyChanged("GesamtsummeAnzeige");
            }           
        }
        


        private void GesamtsummeAnzeigeErneuern()
        {
            Warenkorb.GesamtsummeBerechnen();
            GesamtsummeAnzeige = "€ " + Warenkorb.Gesamtsumme;

        }


    }
}
