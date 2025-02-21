using System.Diagnostics.CodeAnalysis;

namespace Base.Shared.Extensions;

public static class StringExtensions
{
    public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value)
        => string.IsNullOrWhiteSpace(value);
    public static string GetEmailPrefix(this string? email)
    {
        if (email.IsNullOrWhiteSpace()) return "";
        var namePart = email!.Split('@')[0];

        return !namePart.IsNullOrWhiteSpace()
            ? char.ToUpper(namePart[0]) + namePart[1..].ToLower()
            : email;
    }

    public static bool Like(this string? value, string pattern) => 
        !value.IsNullOrWhiteSpace() && value!.Contains(pattern.Trim(), StringComparison.CurrentCultureIgnoreCase);
}