using ShopClient.Data;
using ShopClient.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopClient.ViewModel
{
    internal class HomeViewModel : ViewModelBase
    {

        

        public HomeViewModel()
        {
            
        }


        


        private string text2;
        public string Text2
        {
            get { return text2; }
            set
            {
                text2 = value;                
                OnPropertyChanged("Text2");
            }
        }


        //über XAML
        // <Button Grid.Row="2"  Grid.Column="1" Content="Change"     Command="{Binding DataContext.ProduktCommand,RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type MVVM_Test:MainWindow }}}"/>


        public RelayCommand ReconnectCommand
        {
            get
            {
                return new RelayCommand(Reconnect, canExecute => true);
            }
        }

        public void Reconnect(object wert)
        {
            Client.ProduktListeAnfragen();
            if (Client.Verbunden() == true )
            {
                MessageBox.Show("\n Verbunden \n");
            }
        }




    }
}






// <Button Grid.Row="2" Content="change" Command="{Binding ChangeCommand}"  CommandParameter="1"/>