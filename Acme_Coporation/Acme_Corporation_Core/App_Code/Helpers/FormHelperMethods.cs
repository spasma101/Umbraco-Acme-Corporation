using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acme_Corporation_Core.App_Code.Helpers
{
	public class FormHelperMethods
	{
		public static string RandomString(int length)
		{
			var rand = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[rand.Next(s.Length)]).ToArray());
		}
	}
}