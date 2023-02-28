namespace Common.Extensions;

public static class StringsExtensions
{
	public static string Truncate(this string text, int length)
	{
		if (string.IsNullOrEmpty(text)) return string.Empty;

		if (text.Length <= length) return text;

		var result = text.Substring(0, length);
		return $"{result} ...";
	}
}
