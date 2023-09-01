using System;
using System.Linq;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
        => phoneNumber.Split("-") switch
        {
            string[] nums => (nums[0] == "212", nums[1] == "555", nums[2]),
            _ => throw new ArgumentException("Invalid phone number", nameof(phoneNumber)),
        };

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) => phoneNumberInfo.IsFake;
}
