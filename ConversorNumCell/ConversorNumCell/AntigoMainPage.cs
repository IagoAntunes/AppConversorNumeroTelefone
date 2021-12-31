using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ConversorNumCell
{
    public class AntigoMainPage : ContentPage
    {
        Entry numeroCelular;
        String numeroConvertido;
        Button ButtonConverter;
        Button ButtonLigar;
        public AntigoMainPage()
        {
            //---------------------------------------------------------------------------------------------------------
            //Declarando Interface
            this.Padding = new Thickness(20, 20, 20, 20);

            StackLayout panel = new StackLayout()
            {
                Spacing = 15
            };

            panel.Children.Add(new Label()
            {
                Text = "Inserir um numero de Celular:",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });
            panel.Children.Add(numeroCelular = new Entry()
            {
                Text = "1 - 855 - XAMARIN",
            });
            panel.Children.Add(ButtonConverter = new Button()
            {
                Text = "Converter"
            });
            panel.Children.Add(ButtonLigar = new Button()
            {
                Text = "Chamar",
                IsEnabled = false
            }) ;
            this.Content = panel;

            //---------------------------------------------------------------------------------------------------------
            //Logica propriedades 
            ButtonConverter.Clicked += OnTranslate;

 
            ButtonConverter.Clicked += OnTranslate;

            ButtonLigar.Clicked += OnCall;
            this.Content = panel;
        }

        private async void OnCall(object sender, EventArgs e)
        {
            if(await DisplayAlert("Discar um Número", "Gostaria de ligar para " + numeroConvertido, "Sim", "Nao")){
                try
                {
                    PhoneDialer.Open(numeroConvertido);
                }
                catch (ArgumentNullException)
                {
                    await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
                }
                catch (FeatureNotSupportedException)
                {
                    await DisplayAlert("Unable to dial", "Phone dialing not supported.", "OK");
                }
                catch (Exception)
                {
                    // Other error has occurred.
                    await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
                }
            }
        }

        public void OnTranslate(Object sender,EventArgs args)
        {
            string numeroDigitado = numeroCelular.Text;

            numeroConvertido = ConversorNumero.ToNumber(numeroDigitado);

            if (!string.IsNullOrEmpty(numeroConvertido))
            {
                // TODO:
                numeroCelular.Text = "Cell:" + numeroConvertido;

                ButtonLigar.IsEnabled = true;
            }
            else
            {
                // TODO:
                numeroCelular.Text = "Cell:";
                ButtonLigar.IsEnabled = false;
            }
        }



    }
}
