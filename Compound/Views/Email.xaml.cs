using System;
using System.Collections.Generic;
using Plugin.Messaging;
using Xamarin.Forms;

namespace Compound
{
	public partial class Email : ContentPage
	{
		public Email()
		{
			InitializeComponent();
		}

		private void SendSMS_OnClicked(object sender, EventArgs e)
		{
			var smsMessenget = CrossMessaging.Current.SmsMessenger;
			if (smsMessenget.CanSendSms)
				smsMessenget.SendSms("+27213894839493", "Well hello there from Xamarin");
		}

		private void PhoneCall_Clicked(object sender, EventArgs e)
		{
			var phoneCallTask = CrossMessaging.Current.PhoneDialer;
			if (phoneCallTask.CanMakePhoneCall)
			{
				phoneCallTask.MakePhoneCall("+21629903563", "House Detai");
			}
		}

		private void SendEmail_Clicked(object sender, EventArgs e)
		{
			var emailMessenger = CrossMessaging.Current.EmailMessenger;
			if (emailMessenger.CanSendEmail)
			{
				emailMessenger.SendEmail("to.plugin@xamarin,com", "Xamarin Messaging Plugin", "Well hello there from Xamarin");

				var email = new EmailMessageBuilder()
					.To("to.plugins@xamarin.com")
					.Cc("cc.plugins@xamarin.com")
					.Bcc(new[] { "bcc1.plugins@xamarin.com", "bcc2.plugins@xamarin.com" })
					.Subject("Xamarin Messaging Plugin")
					.Body("Well hello there from Xam.Messaging.Plugin")
					.Build();
				emailMessenger.SendEmail(email);
			}
		}

	}
}

