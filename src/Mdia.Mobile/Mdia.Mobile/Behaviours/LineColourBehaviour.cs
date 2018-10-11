using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Mdia.Mobile.Effects;

namespace Mdia.Mobile.Behaviours
{
    public class LineColourBehaviour
    {
        public static readonly BindableProperty ApplyLineColorProperty =
            BindableProperty.CreateAttached("ApplyLineColor", typeof(bool), typeof(LineColourBehaviour), false,
                propertyChanged: OnApplyLineColorChanged);

        public static readonly BindableProperty LineColorProperty =
            BindableProperty.CreateAttached("LineColor", typeof(Color), typeof(LineColourBehaviour), Color.Default);

        public static bool GetApplyLineColor(BindableObject view)
        {
            return (bool)view.GetValue(ApplyLineColorProperty);
        }

        public static void SetApplyLineColor(BindableObject view, bool value)
        {
            view.SetValue(ApplyLineColorProperty, value);
        }

        public static Color GetLineColor(BindableObject view)
        {
            return (Color)view.GetValue(LineColorProperty);
        }

        public static void SetLineColor(BindableObject view, Color value)
        {
            view.SetValue(LineColorProperty, value);
        }

        private static void OnApplyLineColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;

            if (view == null)
            {
                return;
            }

            bool hasLine = (bool)newValue;

            if (hasLine)
            {
                view.Effects.Add(new EntryLineColourEffect());
            }
            else
            {
                var entryLineColorEffectToRemove = view.Effects.FirstOrDefault(e => e is EntryLineColourEffect);
                if (entryLineColorEffectToRemove != null)
                {
                    view.Effects.Remove(entryLineColorEffectToRemove);
                }
            }
        }



    }
}
