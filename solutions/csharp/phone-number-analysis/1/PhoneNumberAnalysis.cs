public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        string[] sections = phoneNumber.Split('-');
        return (sections[0] == "212", sections[1] == "555", sections[2]);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {   
        return phoneNumberInfo.Item2 == true ? true : false;
    }
}
