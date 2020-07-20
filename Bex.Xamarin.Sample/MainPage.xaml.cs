using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Bex.Xamarin.Sample
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage, IBexPaymentListener, IBexPairingListener
    {
        public MainPage()
        {
            InitializeComponent();
            BexSDK.Instance.Init(true);
        }

        void OnPaymentButtonClicked(object sender, EventArgs args)
        {
            BexSDK.Instance.Payment("token", this);
        }

        void OnSubmitButtonClicked(object sender, EventArgs args)
        {
            BexSDK.Instance.SubmitConsumer("token", this);
        }

        void OnReSubmitButtonClicked(object sender, EventArgs args)
        {
            BexSDK.Instance.ResubmitConsumer("ticket", this);
        }

        public void OnPaymentCancelled()
        {
            DisplayAlert("Alert", "OnPaymentCancelled", "OK");
        }

        public void OnPaymentFailure(int errorId, string errorMsg)
        {
            DisplayAlert("Alert", "OnPaymentFailure", "OK");
        }

        public void OnPaymentSuccess(BexPosResult posResult)
        {
            DisplayAlert("Alert", "OnPaymentSuccess", "OK");
        }

        public void OnPairingSuccess(string first6, string last2)
        {
            DisplayAlert("Alert", "OnPairingSuccess", "OK");
        }

        public void OnPairingCancelled()
        {
            DisplayAlert("Alert", "OnPairingCancelled", "OK");
        }

        public void OnPairingFailure(int errorId, string errorMsg)
        {
            DisplayAlert("Alert", "OnPairingFailure", "OK");
        }
    }
}
