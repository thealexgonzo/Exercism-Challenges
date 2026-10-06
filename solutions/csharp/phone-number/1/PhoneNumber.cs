public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        phoneNumber = phoneNumber.Trim()
                                 .Replace("(", string.Empty)
                                 .Replace(")", string.Empty)
                                 .Replace(" ", string.Empty)
                                 .Replace("-", string.Empty)
                                 .Replace(".", string.Empty);

        if (phoneNumber.StartsWith("+1") || phoneNumber.StartsWith('1'))
            phoneNumber = phoneNumber.Substring(phoneNumber.IndexOf('1') + 1);

        if (phoneNumber.Length != 10 ||
            phoneNumber.Any(c => (c >= 33 && c <= 47) ||
                                 (c >= 58 && c <= 98) ||
                                 (c >= 123 && c <= 126)) ||
            phoneNumber[0] == '1' || phoneNumber[0] == '0' ||
            phoneNumber[3] == '1' || phoneNumber[3] == '0')
                throw new ArgumentException();

        return phoneNumber;
    }
}