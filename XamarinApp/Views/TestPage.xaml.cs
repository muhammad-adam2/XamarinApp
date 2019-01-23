using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;
using XamarinApp.Helpers;
using XamarinApp.Resources;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    public partial class TestPage : ContentPage
    {
        TestViewModel viewModel;

        public TestPage()
        {
            InitializeComponent();
            //LabelTest.Text = AppResources.TestLabel;
            BindingContext = viewModel = new TestViewModel();
        }

        void Handle_Clicked(object sender, EventArgs e)
        {
            AppResources.Culture = new CultureInfo("zu-ZA");
            Settings.culture = "zu-ZA";
            InitializeComponent();
        }

        void Handle_Clicked_1(object sender, EventArgs e)
        {
            AppResources.Culture = new CultureInfo("tn-ZA");
            Settings.culture = "tn-ZA";
            InitializeComponent();
        }

        void Handle_Clicked_2(object sender, EventArgs e)
        {
            AppResources.Culture = new CultureInfo("en-ZA");
            Settings.culture = "en-ZA";
            InitializeComponent();
        }
    }
}
