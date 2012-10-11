using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace CustomDialogFragmentSample
{
    public class CustomDialogFragment : Android.Support.V4.App.DialogFragment
    {
        Button Button_Dismiss;

        public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Android 3.x+ still wants to show title: disable
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);

            // Create our view
            var view = inflater.Inflate(Resource.Layout.CustomDialog, container, true);

            // Handle dismiss button click
            Button_Dismiss = view.FindViewById<Button>(Resource.Id.Button_Dismiss);
            Button_Dismiss.Click += Button_Dismiss_Click;

            return view;
        }

        public override void OnResume()
        {
            // Auto size the dialog based on it's contents
            Dialog.Window.SetLayout(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
            
            // Make sure there is no background behind our view
            Dialog.Window.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
            
            // Disable standard dialog styling/frame/theme: our custom view should create full UI
            SetStyle(Android.Support.V4.App.DialogFragment.StyleNoFrame, Android.Resource.Style.Theme);
            
            base.OnResume();
        }

        private void Button_Dismiss_Click (object sender, EventArgs e)
        {
            Dismiss();
        }
        
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            // Unwire event
            if (disposing)
                Button_Dismiss.Click -= Button_Dismiss_Click;
        }
        
    }
}

