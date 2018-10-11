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
using Xamarin.Forms;
using Mdia.Mobile.Droid.Effects;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using Mdia.Mobile.Behaviours;


[assembly: ExportEffect(typeof(EntryLineColourEffect), "EntryLineColourEffect")]
namespace Mdia.Mobile.Droid.Effects
{
    public class EntryLineColourEffect : PlatformEffect
    {
        EditText control;

        protected override void OnAttached()
        {
            try
            {
                control = Control as EditText;
                UpdateLineColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
            control = null;
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args.PropertyName == LineColourBehaviour.LineColorProperty.PropertyName)
            {
                UpdateLineColor();
            }
        }

        private void UpdateLineColor()
        {
            try
            {
                if (control != null)
                {
                    control.Background.SetColorFilter(LineColourBehaviour.GetLineColor(Element).ToAndroid(), Android.Graphics.PorterDuff.Mode.SrcAtop);
                }
            }
            catch (Exception ex)
            {
                //throw;
                //Debug.WriteLine(ex.Message);
            }
        }






    }

}