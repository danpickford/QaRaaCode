using System;
using Android.Content.PM;
using ZXing;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ZXing.Common;
using ZXing.QrCode.Internal;

namespace QaRaa_Code_Generator
{
	[Activity (Label = "QaRaa Code Generator", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			RequestWindowFeature(WindowFeatures.NoTitle);
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			EditText QrText = FindViewById<EditText>(Resource.Id.Qrtext);
			Button generateButton = FindViewById<Button>(Resource.Id.GenerateButton);
			ImageView QRCodeImage = FindViewById <ImageView>(Resource.Id.QRCodeImage);

			generateButton.Click += (object sender, EventArgs e) => {

                var writer = new BarcodeWriter
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new EncodingOptions
                    {
						Height = 800,
						Width = 800
                    }
                };

				var image = writer.Write(QrText.Text);
                QRCodeImage.SetImageBitmap(image);
			};
		}
	}
}


