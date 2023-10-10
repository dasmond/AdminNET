// 麻省理工学院许可证
//
// 版权所有 (c) 2021-2023 zuohuaijun，大名科技（天津）有限公司  联系电话/微信：18020030720  QQ：515096995
//
// 特此免费授予获得本软件的任何人以处理本软件的权利，但须遵守以下条件：在所有副本或重要部分的软件中必须包括上述版权声明和本许可声明。
//
// 软件按“原样”提供，不提供任何形式的明示或暗示的保证，包括但不限于对适销性、适用性和非侵权的保证。
// 在任何情况下，作者或版权持有人均不对任何索赔、损害或其他责任负责，无论是因合同、侵权或其他方式引起的，与软件或其使用或其他交易有关。

using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities.Encoders;

namespace Admin.NET.Core;

/// <summary>
/// SM3工具类
/// </summary>
public class SM3Util
{
    public static string Sm3Encrypt(string data, string key)
    {
        var result = ToSM3byte(data, key);
        return Encoding.UTF8.GetString(Hex.Encode(result));
    }

    public static byte[] ToSM3byte(string data, string key)
    {
        byte[] msg1 = Encoding.UTF8.GetBytes(data);
        KeyParameter keyParameter = new KeyParameter(Hex.Decode(key));
        HMac hMac = new HMac(new SM3Digest());
        hMac.Init(keyParameter);
        hMac.BlockUpdate(msg1, 0, msg1.Length);
        byte[] result = new byte[hMac.GetMacSize()];
        hMac.DoFinal(result, 0);
        return result;
    }


    public static string Sm3Encrypt(string data)
    {
        var result = ToSM3byte(data);
        return Encoding.UTF8.GetString(Hex.Encode(result));
    }

    public static byte[] ToSM3byte(string data)
    {
        byte[] msg1 = Encoding.UTF8.GetBytes(data);
        var sm3 = new SM3Digest();
        sm3.BlockUpdate(msg1, 0, msg1.Length);
        byte[] result = new byte[sm3.GetDigestSize()];
        sm3.DoFinal(result, 0);
        return result;
    }
}