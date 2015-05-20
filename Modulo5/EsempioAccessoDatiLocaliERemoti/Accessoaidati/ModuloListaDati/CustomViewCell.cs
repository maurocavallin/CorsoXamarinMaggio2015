using System;
using System.Linq;
using Xamarin.Forms;

namespace Accessoaidati
{
	public class CustomCell : ViewCell
	{
		PaginalistaDatiViewModel _viewModel = null;

		public CustomCell ()
		{
			_viewModel = DependencyService.Get<PaginalistaDatiViewModel> ();

			var labelTitolo = new Label ();
			labelTitolo.TextColor = Color.Blue;
			labelTitolo.FontSize = 18;

			var labelDettaglio = new Label ();

			labelTitolo.SetBinding (Label.TextProperty, "Name");
			labelDettaglio.SetBinding (Label.TextProperty, "Name");


			var stackLayoutTesto = new StackLayout (){ 
				Orientation = StackOrientation.Vertical,
			};

			stackLayoutTesto.Children.Add (labelTitolo);
			stackLayoutTesto.Children.Add (labelDettaglio);
				


			var mainStackLayoutOrizzontale = new StackLayout () {
				Orientation = StackOrientation.Horizontal, 
			};

			Image immagine = new Image ();
			immagine.Source = "icon.png";

			Button pulsante = new Button ();
			pulsante.Text = "+";

			pulsante.SetBinding(Button.CommandParameterProperty, "Name");
			pulsante.Clicked += (sender, e) => {
				var b = (Button)sender;
				var t = b.CommandParameter;

				var item = (TodoItem)this.BindingContext;
 
				_viewModel.Dati.Remove(item);
				// item.Name += "!";

				//((ContentPage)((ListView)((StackLayout)b.ParentView).ParentView).ParentView).DisplayAlert("Clicked", t + " button was clicked", "OK");
				// Debug.WriteLine("clicked" + t);
			};
			 

			mainStackLayoutOrizzontale.Children.Add (immagine);
			mainStackLayoutOrizzontale.Children.Add (stackLayoutTesto);
			mainStackLayoutOrizzontale.Children.Add (pulsante);
			this.View = mainStackLayoutOrizzontale;
		}
	}
}

