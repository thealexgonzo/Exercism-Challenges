
using System.Net.NetworkInformation;
using System.Security.Cryptography;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] payload = Array.Empty<byte>();
        byte[] buffer = new byte[9];

        if (reading > uint.MaxValue && reading <= long.MaxValue)
        {
            buffer[0] = 256 - sizeof(long);
            payload = BitConverter.GetBytes((long)reading);
        }
        else if(reading > int.MaxValue && reading <= uint.MaxValue)
        {
            buffer[0] = sizeof(uint);
            payload = BitConverter.GetBytes((uint)reading);
        }
        else if(reading > ushort.MaxValue && reading <= int.MaxValue)
        {
            buffer[0] = 256 - sizeof(int);
            payload = BitConverter.GetBytes((int)reading);
        }
        else if(reading >= 0 && reading <= ushort.MaxValue)
        {
            buffer[0] = sizeof(ushort);
            payload = BitConverter.GetBytes((ushort)reading);
        }
        else if(reading >= short.MinValue && reading <= -1)
        {
            buffer[0] = 256 - sizeof(short);
            payload = BitConverter.GetBytes((short)reading);
        }
        else if(reading >= int.MinValue && reading < short.MinValue)
        {
            buffer[0] = 256 - sizeof(int);
            payload = BitConverter.GetBytes((int)reading);
        }
        else if(reading >= long.MinValue && reading < int.MinValue)
        {
            buffer[0] = 256 - sizeof(long);
            payload = BitConverter.GetBytes((long)reading);
        }

        Array.Copy(payload, 0, buffer, 1, payload.Length);

        return buffer;
    }

    public static long FromBuffer(byte[] buffer) => buffer[0] switch
    {
        2 => BitConverter.ToUInt16(buffer, 1),
        254 => BitConverter.ToInt16(buffer, 1),
        4 => BitConverter.ToUInt32(buffer, 1),
        252 => BitConverter.ToInt32(buffer, 1),
        248 => BitConverter.ToInt64(buffer, 1),
        _ => 0
    };
    
}