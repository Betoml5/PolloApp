using PolloApp.Models;
using PolloApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PolloApp.ViewModels
{
    public class PolloViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Producto> Productos { get; set; } = new ObservableCollection<Producto>();

        public ICommand LoginCommand { get; set; }
        public ICommand LogoutCommand { get; set; }

        public ICommand ChangeViewCommand { get; set; }

        public ICommand TerminarCommand { get; set; }

        //Instanciar vistas
        ComidasView comidasView;
        ComplementosView complementosView;
        BebidasView bebidasView;

        public PolloViewModel()
        {
            LoginCommand = new Command(Login);
            LogoutCommand = new Command(Logout);
            ChangeViewCommand = new Command<string>(ChangeView);

         

        }

        public void ChangeView(string vista)
        {
            if (vista == "home")
            {
                Application.Current.MainPage.Navigation.PopToRootAsync();
            }
            if (vista == "complementos")
            {
                complementosView = new ComplementosView() { BindingContext = this };
                Application.Current.MainPage.Navigation.PushAsync(complementosView);
            }
            if (vista == "bebidas")
            {
                bebidasView = new BebidasView() { BindingContext = this };
                Application.Current.MainPage.Navigation.PushAsync(bebidasView);
            }
        }

        public void Terminar()
        {
            //Implementar servidor
        }


        public void Login()
        {
            //Implementar el servicio
            comidasView = new ComidasView() { BindingContext = this };
            Application.Current.MainPage.Navigation.PushAsync(comidasView);

        }

        public void Logout()
        {
            Application.Current.MainPage.Navigation.PopToRootAsync();
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
