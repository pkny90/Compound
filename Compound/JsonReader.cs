using System;
using System.IO;
using System.Reflection;

namespace Compound
{
	// Reference for this code snippet:
	// https://github.com/xamarin/xamarin-forms-samples/blob/master/WorkingWithFiles/PCL/WorkingWithFiles/LoadResourceText.cs
	public class JsonReader
	{
		public string JsonText { get; private set; }
		public JsonReader(string fileName)
		{
			JsonText = "";

			var assembly = typeof(JsonReader).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream(fileName);
			using (var reader = new System.IO.StreamReader(stream))
			{
				this.JsonText = reader.ReadToEnd();
			}
		}
	}
}

