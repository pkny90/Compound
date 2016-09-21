<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Compound
{
	public partial class AboutPage : ContentPage
	{
		public AboutPage()
		{

	
			this.BackgroundImage = "backgound1.png";
		    /*var scroll = new ScrollView();
            Content = scroll;
            var stack = new StackLayout();
            stack.Children.Add(new BoxView { BackgroundColor = Color.Red, HeightRequest = 600, WidthRequest = 600 });
            stack.Children.Add(new Entry());
       
            Button WriteFeedback = new Button { Text = "Email" };
            WriteFeedback.Clicked += (sender, e) =>
            {
                Device.OpenUri(new Uri("mailto:youremail@test.com"));
            };*/
        }

    }
}

=======
﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Compound
{
	public partial class AboutPage : ContentPage
	{
		public AboutPage()
		{
			

		    var scroll = new ScrollView();
            Content = scroll;
            var stack = new StackLayout();
            stack.Children.Add(new BoxView { BackgroundColor = Color.Red, HeightRequest = 600, WidthRequest = 600 });
            stack.Children.Add(new Entry());
       
            Button WriteFeedback = new Button { Text = "Email" };
            WriteFeedback.Clicked += (sender, e) =>
            {
                Device.OpenUri(new Uri("mailto:youremail@test.com"));
            };
        }

    }
}

>>>>>>> master
