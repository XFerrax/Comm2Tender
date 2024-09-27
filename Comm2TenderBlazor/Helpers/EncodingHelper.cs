namespace Comm2TenderBlazor.Helpers
{
	public static class EncodingHelper
	{
		public static string ConvertAsciiToUtf8(string asciiString)
		{
			byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes(asciiString);
			return System.Text.Encoding.UTF8.GetString(utf8Bytes);
		}
	}
}