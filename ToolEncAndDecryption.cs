using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WinFormTool
{
    /// <summary>
    /// 加密、解密
    /// </summary>
    class ToolEncAndDecryption
    {
        #region Base64加密、解密

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="str">Base64编码的字符串</param>
        /// <returns>解密后的字符串</returns>
        public ToolResult Base64DecryptString(string str)
        {
            ToolResult toolResult = new ToolResult();
            try
            {
                if ((str.Length % 4) != 0)
                {
                    throw new ArgumentException("不是正确的BASE64编码，请检查。", "str");
                }
                if (!Regex.IsMatch(str, "^[A-Z0-9/+=]*$", RegexOptions.IgnoreCase))
                {
                    throw new ArgumentException("包含不正确的BASE64编码，请检查。", "str");
                }
                string str2 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789+/=";
                int num = str.Length / 4;
                ArrayList list = new ArrayList(num * 3);
                char[] chArray = str.ToCharArray();
                for (int i = 0; i < num; i++)
                {
                    byte[] buffer = new byte[] { (byte)str2.IndexOf(chArray[i * 4]), (byte)str2.IndexOf(chArray[(i * 4) + 1]), (byte)str2.IndexOf(chArray[(i * 4) + 2]), (byte)str2.IndexOf(chArray[(i * 4) + 3]) };
                    byte[] buffer2 = new byte[3];
                    buffer2[0] = (byte)((buffer[0] << 2) ^ ((buffer[1] & 0x30) >> 4));
                    if (buffer[2] != 0x40)
                    {
                        buffer2[1] = (byte)((buffer[1] << 4) ^ ((buffer[2] & 60) >> 2));
                    }
                    else
                    {
                        buffer2[2] = 0;
                    }
                    if (buffer[3] != 0x40)
                    {
                        buffer2[2] = (byte)((buffer[2] << 6) ^ buffer[3]);
                    }
                    else
                    {
                        buffer2[2] = 0;
                    }
                    list.Add(buffer2[0]);
                    if (buffer2[1] != 0)
                    {
                        list.Add(buffer2[1]);
                    }
                    if (buffer2[2] != 0)
                    {
                        list.Add(buffer2[2]);
                    }
                }
                byte[] bytes = (byte[])list.ToArray(Type.GetType("System.Byte"));
                toolResult.ObjResult= Encoding.Default.GetString(bytes);
                toolResult.IsSucess = true;
            }catch(Exception ex)
            {
                toolResult.IsSucess = false;
                toolResult.StrErrMessage = ex.Message;
            }
            return toolResult;
        }
        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public ToolResult Base64EncryptString(string str)
        {
            ToolResult toolResult = new ToolResult();
            try
            {
                int num5;
                char[] chArray = new char[] {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
            'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F',
            'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
            'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/',
            '='
         };
                byte num = 0;
                ArrayList list = new ArrayList(Encoding.Default.GetBytes(str));
                int count = list.Count;
                int num3 = count / 3;
                int num4 = 0;
                num4 = count % 3;
                if (num4 > 0)
                {
                    for (num5 = 0; num5 < (3 - num4); num5++)
                    {
                        list.Add(num);
                    }
                    num3++;
                }
                StringBuilder builder = new StringBuilder(num3 * 4);
                for (num5 = 0; num5 < num3; num5++)
                {
                    byte[] buffer = new byte[] { (byte)list[num5 * 3], (byte)list[(num5 * 3) + 1], (byte)list[(num5 * 3) + 2] };
                    int[] numArray = new int[4];
                    numArray[0] = buffer[0] >> 2;
                    numArray[1] = ((buffer[0] & 3) << 4) ^ (buffer[1] >> 4);
                    if (!buffer[1].Equals(num))
                    {
                        numArray[2] = ((buffer[1] & 15) << 2) ^ (buffer[2] >> 6);
                    }
                    else
                    {
                        numArray[2] = 0x40;
                    }
                    if (!buffer[2].Equals(num))
                    {
                        numArray[3] = buffer[2] & 0x3f;
                    }
                    else
                    {
                        numArray[3] = 0x40;
                    }
                    builder.Append(chArray[numArray[0]]);
                    builder.Append(chArray[numArray[1]]);
                    builder.Append(chArray[numArray[2]]);
                    builder.Append(chArray[numArray[3]]);
                }
                toolResult.ObjResult = builder.ToString();
                toolResult.IsSucess = true;
            }catch(Exception ex)
            {
                toolResult.IsSucess = false;
                toolResult.StrErrMessage = ex.Message;
            }
            return toolResult;
        }

        #endregion
    }
}
