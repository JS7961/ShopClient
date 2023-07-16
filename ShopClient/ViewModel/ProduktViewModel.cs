using ShopClient.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ShopClient.Model;
using ShopClient.Data;

namespace ShopClient.ViewModel
{
    internal class ProduktViewModel: ViewModelBase
    {

        public ObservableCollection<Item> ItemListe { get; set; }


        public ProduktViewModel()
        {
            ItemListe = new ObservableCollection<Item>();
            
            for (int i = 0; i < Produkte.ItemListe.Count(); i++)
            {
                ItemListe.Add(Produkte.ItemListe[i]);
            }
        }


        public RelayCommand AddCart
        {
            get
            {
                return new RelayCommand(Add, canExecute => true);
            }
        }

        public void Add(object exec)
        {
            int wert=0;

            if (exec != null)
            {
                wert = (int)exec;
            }

            Item Item1;

            Item1 = Produkte.GetProdukt(wert);
            Item1.AnzahlWarenkorb = 1;

            if (Warenkorb.ItemListe.Contains(Item1) == false)
            {
                Warenkorb.ItemListe.Add(Item1);
            }

            
            

            
        }



    }
}
