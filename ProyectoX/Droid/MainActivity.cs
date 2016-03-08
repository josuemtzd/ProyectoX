using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.OS;
using Xamarin.Forms;

namespace ProyectoX.Droid
{
	public class App
	{
		static MasterDetailPage MDPage;

		public static Page GetMainPage()
		{
			return MDPage = new MasterDetailPage {
				Master = new ContentPage {
					Title = "Master",
					BackgroundColor = Color.Silver,
					Icon = Device.OS == TargetPlatform.iOS ? "menu.png" : null,
					Content = new StackLayout {
						Padding = new Thickness(5, 50),
						Children = { Link("A"), Link("B"), Link("C") }
					},
				},
				Detail = new NavigationPage(new ContentPage {
					Title = "A",
					Content = new Label { Text = "A" }
				}),
			};
		}

		static Button Link(string name)
		{
			var button = new Button {
				Text = name,
				BackgroundColor = Color.FromRgb(0.9, 0.9, 0.9)
			};
			button.Clicked += delegate {
				MDPage.Detail = new NavigationPage(new ContentPage {
					Title = name,
					Content = new Label { Text = name }
				});
				MDPage.IsPresented = false;
			};
			return button;
		}
	}
}
