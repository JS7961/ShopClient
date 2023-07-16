using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ShopClient.Model;
using System.ComponentModel;
using ShopClient.MVVM;

namespace ShopClient.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        

       // public RelayCommand AddCommand => new RelayCommand(execute => AddItem(), canExecute => { return true; } );
        public RelayCommand ProduktCommand => new RelayCommand(ShowProdukte , canExecute =>  SelectedViewModel.GetType() != typeof(ProduktViewModel) );

        public RelayCommand HomeCommand => new RelayCommand(ShowHome, canExecute => SelectedViewModel.GetType() != typeof(HomeViewModel));
        public RelayCommand WarenkorbCommand => new RelayCommand(ShowWarenkorb, canExecute => SelectedViewModel.GetType() != typeof(WarenkorbViewModel));

        public RelayCommand KasseCommand => new RelayCommand(ShowKasse, canExecute => SelectedViewModel.GetType() != typeof(HomeViewModel));
        public RelayCommand SaveCommand
        {
            get
            {
                return new RelayCommand(Save, canExecute => CanSave());
            }
        }

        ProduktViewModel ProduktViewModel1;
        HomeViewModel HomeViewModel1;
        WarenkorbViewModel WarenkorbViewModel1;


        public MainWindowViewModel()
        {
            ProduktViewModel1 = new ProduktViewModel();
            HomeViewModel1 = new HomeViewModel();  
            WarenkorbViewModel1 = new WarenkorbViewModel(); 


            selectedViewModel = HomeViewModel1;
            
        }

        
        

        private Item selectedItem;

        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }


        

        private void Save(object exec)
        {
            //Save to file/db
        }

        private bool CanSave()
        {
            return true;
        }

        private void ShowProdukte(object exec)
        {
            SelectedViewModel = ProduktViewModel1;
        }

        private void ShowHome(object exec)
        {           
            SelectedViewModel = new HomeViewModel(); ;
        }

        private void ShowWarenkorb(object exec)
        {
            SelectedViewModel = WarenkorbViewModel1;
        }

        private void ShowKasse(object exec)
        {
            SelectedViewModel = new KasseViewModel();
        }



        private ViewModelBase selectedViewModel ;

        public ViewModelBase SelectedViewModel
        {
            get { return selectedViewModel; }
            set 
            { 
                selectedViewModel = value;
                OnPropertyChanged("SelectedViewModel");
            }
        }

        public void ChangeViewModel(int wert)
        {
            switch (wert)
            {
                case 0: 
                    SelectedViewModel = HomeViewModel1;
                break;
                case 1:
                    SelectedViewModel = ProduktViewModel1;
                    break;
                case 2:
                    SelectedViewModel = WarenkorbViewModel1;
                    break;

                default:
                    break;
            }
        }




    }
}
