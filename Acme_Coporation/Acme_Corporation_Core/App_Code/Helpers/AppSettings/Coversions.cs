using System;

namespace Acme_Corporation_Core.App_Code.Helpers
{
	public static class Coversions
	{
		public static bool ToBool(this string value)
		{
			return Convert.ToBoolean(value);
		}

		public static int ToInt(this string value)
		{
			return int.Parse(value);
		}
	}
}