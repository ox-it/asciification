using System;
using System.Collections.Generic;
using System.Text;

namespace asciify
{
	static class Asciify
	{
		public static void Main (string[] args)
		{
			Console.WriteLine (asciify("Héllöþ☺"));
		}

		private static Dictionary<char,String> specialCases = new Dictionary<char,String> () {
			{'æ', "ae"},
			{'Æ', "AE"},
			{'œ', "oe"},
			{'Œ', "OE"},
			{'þ', "th"},
			{'Þ', "TH"},
			{'ä', "ae"},
			{'Ä', "AE"},
			{'ö', "oe"},
			{'Ö', "OE"},
			{'ü', "ue"},
			{'Ü', "UE"},
			{'ß', "ss"},
		};

		public static String asciify(String text) {
			text = text.Normalize (System.Text.NormalizationForm.FormC);
			StringBuilder newText = new StringBuilder ();
			foreach (char c in text) {
				newText.Append (specialCases.ContainsKey(c) ? specialCases[c] : c.ToString ());
			}

			text = newText.ToString().Normalize (System.Text.NormalizationForm.FormD);
			newText = new StringBuilder ();
			foreach (char c in text) {
				if (c <= 127) {
					newText.Append (c);
				}
			}
			return newText.ToString ();
		}
	}
}
