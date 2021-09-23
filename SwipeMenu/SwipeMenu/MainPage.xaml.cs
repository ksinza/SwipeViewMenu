using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SwipeMenu
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            MyMenu = GetMenus();
            this.BindingContext = this;
            pancake.IsTabStop = false;
            MainSwipeView.PropertyChanging += (object sender, Xamarin.Forms.PropertyChangingEventArgs e) => {


            };
        }

        public List<Menu> MyMenu { get; set; }

        public bool openSwipe = false;

        private List<Menu> GetMenus()
        {

            return new List<Menu>
            {
                new Menu{ Name = "Home", Icon = "home.png"},
                new Menu{ Name = "Profile", Icon = "user.png"},
                new Menu{ Name = "Notifications", Icon = "bell.png"},
                new Menu{ Name = "Messages", Icon = "envelope.png"},
                new Menu{ Name = "My Task", Icon = "tasks.png"}



            };
        }

        private async Task OpenAnimation()
        {
            await swipeContent.ScaleYTo(0.9, 300, Easing.SinOut);
            pancake.CornerRadius = 20;
            await swipeContent.RotateTo(-15, 300, Easing.SinOut);


        }


        private async Task CloseAnimation()
        {
            await swipeContent.RotateTo(0, 300, Easing.SinOut);
            pancake.CornerRadius = 0;
            await swipeContent.ScaleYTo(1, 300, Easing.SinOut);
            //await swipeContent.TranslateTo(-110, 30,300, Easing.SinOut);

        }

        private async void OpenSwipe(System.Object sender, System.EventArgs e)
        {
           
                MainSwipeView.Open(OpenSwipeItem.LeftItems);
               await OpenAnimation();
                openSwipe = !openSwipe;
                //swipeContent.IsEnabled = false;
                //pancake.Opacity = 0.5;



        }

        private async void CloseSwipe(System.Object sender, System.EventArgs e)
        {

            //MainSwipeView.Open(OpenSwipeItem.RightItems);
            //MainSwipeView.Open(OpenSwipeItem.BottomItems);

            // await CloseAnimation();
          
            await CloseAnimation();
            MainSwipeView.Close();

            //await Task.Delay(4000);

            //Device.BeginInvokeOnMainThread(() =>
            //{

            //    _ = CloseAnimation();
            //});
            //await CloseAnimation();
            //MainSwipeView.Close();
        }

        private void SwipeEnded(System.Object sender, Xamarin.Forms.SwipeEndedEventArgs e)
        {
            if (!e.IsOpen)
                CloseAnimation();
            
        }

        private void SwipeStarted(System.Object sender, Xamarin.Forms.SwipeStartedEventArgs e)
        {
            OpenAnimation();
        }

        void SwipeChanging(System.Object sender, Xamarin.Forms.SwipeChangingEventArgs e)
        {
            return;
        }

        void pancake_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }        //private void CloseRequested(System.Object sender, Xamarin.Forms.CloseRequestedEventArgs e)

        void pancake_Focused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
        }        //{
        //    CloseAnimation();
        //}
    }


    public class Menu
    {
        public string Name { get; set; }

        public string Icon { get; set; }
    }
}
