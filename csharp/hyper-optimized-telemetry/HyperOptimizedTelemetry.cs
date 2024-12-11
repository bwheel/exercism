using System;
using System.Collections.Generic;
using System.Linq;

public static class TelemetryBuffer
{


    /*
    | From                       | To                        | Type     |
    | -------------------------- | ------------------------- | -------- |
    | 4_294_967_296              | 9_223_372_036_854_775_807 | `long`   |
    | 2_147_483_648              | 4_294_967_295             | `uint`   |
    | 65_536                     | 2_147_483_647             | `int`    |
    | 0                          | 65_535                    | `ushort` |
    | -32_768                    | -1                        | `short`  |
    | -2_147_483_648             | -32_769                   | `int`    |
    | -9_223_372_036_854_775_808 | -2_147_483_649            | `long`   |

    */

    public static byte[] ToBuffer(long reading)
    {
        byte prefix = reading switch
        {
            var x when x >= 4_294_967_296 && x <= 9_223_372_036_854_775_807 => 256 - 8,
            var x when x >= 2_147_483_648 && x <= 4_294_967_295 => 4,
            var x when x >= 65_536 && x <= 2_147_483_647 => 256 - 4,
            var x when x >= 0 && x <= 65_535 => 2,
            var x when x >= -32_768 && x <= -1 => 256 - 2,
            var x when x >= -2_147_483_648 && x <= -32_769 => 256 - 4,
            var x when x >= -9_223_372_036_854_775_808 && x <= -2_147_483_649 => 256 - 8,
            _ => throw new ArgumentException(""),
        };
        int takeAmount = prefix < 256 - 8 ? prefix : 256 - prefix;
        var buffer = BitConverter.GetBytes(reading).Take(takeAmount).ToArray();
        var result = new List<byte>() { prefix };
        result.AddRange(buffer);
        for (int i = buffer.Length + 1; i < 9; i++)
            result.Add(0);
        return result.ToArray();
    }

    public static long FromBuffer(byte[] buffer)
    {
        byte prefix = buffer[0];
        if (prefix > 8 && prefix < 256 - 8)
            return 0;
        bool isNegative = prefix >= 256 - 8;
        var size = isNegative ? 256 - prefix : prefix;
        long result = 0;
        if (isNegative)
        {
            return size switch
            {
                2 => BitConverter.ToInt16(buffer, 1),
                4 => BitConverter.ToInt32(buffer, 1),
                _ => BitConverter.ToInt64(buffer, 1),
            };
        }
        else
            result = BitConverter.ToInt64(buffer, 1);
        return result;
    }
}
