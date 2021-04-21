using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Configuration;

namespace MVCBlog.Helpers
{
    
    public static class UserHelper
    {
        private static Random random
        {
            get
            {
                if (random != null)
                {
                    return random;
                }
                return new Random();
            } }

        private static List<char> characters = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'q', 'p', 'r', 's', 't', 'u', 'v', 'x', 'w', 'y', 'z' };
        private static List<char> numbers = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static string imageString = "iVBORw0KGgoAAAANSUhEUgAAAEAAAABACAIAAAAlC+aJAAADm0lEQVR42uyaa0/rOBCGaye9Q0UBVYj9//+MbcK2TXrL3XH2rX0OlB4kmngOTiT8oR8gdf3MvDMej+NWVdXr8uC9jo8fgB+AH4COD/fvTV2qgTTNOXMch3OnGwB5ngfBJstSKaXaZBhjp08wjEbj+fy+3+8T/hwj3Mhg79dXP00TNSUMD32elq4/waNg2GQyXiye1H/bBACT+74HBrXKryKPO8/P/7iu+/Wj3xPEkI3nLctSnCzMrvFVsVy+KNoWZCFoQ61eMnbtbHhSytL3l0pXtgE2m7UQRX1JM/jteDxYBoAMouigdFNbzfgW4A2FZAqw3QaQgUksqqxV2QHADx+Px6oyyiRBEFgDEEJAANhoTSYpiryqpB2AJEnULmu2EzFWFIUdAOQQQ/3oEcdRYxVxsxQkSDZyeNKCB7B0tXkReACxZMED1WlIivX3TPZjIwD1SQCgbPHtHtDlPomEbO3EZAcJZQULMUBpyMazcTOzUa2+uRQNAZj1zqprAkAYwBY8oE7ljCSUTQ743MwDNBLCCdOCB7TlSGohx3HsADgOJ4kD13XsVKOuS3PBMx5P7XhA/TBBX2M4HNg50AyHQ0bR2nMc1w7AYDBQcSwNdwAEsR0A1amdGsbxfP5gokNTBT88LFy33/hE0u8PZrOZiQUIJCxl6XleliV1DTkeE/TZadrrmMTz/k2S9Poe0c3N7ePjwnwX4VSlmCoHqlp7CEktSHbJJ0RRq0cUxzGJ82kAEAZCiFpizvOsRQBhGOKIX7fDHsdRKwDKstzv9w0EvV6vzW9ommchfBG6T5Jkuw3LUjS44FCh3L+7uxuNxo0v/GoAqF6iyPPicNhDwfoS2zx8tAqQxFBUoza5vZ1hdwMPAQCWWBQ5bJymib4K+N1Bk2fnWEbUmJBvU+mkjMMG/DOZTIbDkS66rgXAX/b73W63VSvGdBUCVJ8eDe8y6vPoxMD0ywrz+f10enOhtEsARNVy+ZJluToxWm4bnttUewYF/NPT87k3+MVzvr/M8xxLb8/q3xoIvdONYLpa/XdewH8ASJIYT7AWrfwTEuweRSE+AYD5kZj1+yW9do/V6vXNCe8AsL26cO/AK1AQObLiJUAQbHrdGShePgAgYwKLsc4ARNFRlyH8rK6S7Vf/hZDeAXa7sHOvIIdh8AsAFQ4SE2MdA0CBg3MIV3qKOpE9/xyoGE4AqHx63Ryo5DlyP3IqY6yLAFDR/wEAAP//rj0uQbClyOAAAAAASUVORK5CYII=";

        public static string UserNameHelper(string email)
        {
            email.ToArray<char>();

            List<char> letters = new List<char>();

            foreach (char item in email)
            {
                if (item == '@')
                {
                    break;
                }
                else if (characters.Contains(item) || numbers.Contains(item))
                {
                    letters.Add(item);
                }
                
            }

            return new string(letters.ToArray());
        }

        public static string UrlHelper(string email)
        {
            email.ToArray<char>();

            List<char> letters = new List<char>();

            foreach (char item in email)
            {
                if (item == '@')
                {
                    break;
                }
                else if (characters.Contains(item) || numbers.Contains(item))
                {
                    letters.Add(item);
                }
                
            }

            return new string(letters.ToArray());
        }

        public static string NameHelper(string email)
        {
            email.ToArray<char>();

            List<char> letters = new List<char>();

            foreach (char item in email)
            {
                if (item == '@')
                {
                    break;
                }
                else if (!characters.Contains(item))
                {
                    letters.Add(' ');
                    continue;
                }

                letters.Add(item);
            }

            return new string(letters.ToArray()).Trim();
        }

        public static string ChangeUserName(string username)
        {
            return username += random.Next(1, 9); 
        }

        public static byte[] EmptyImage()
        {
            byte[] image = Convert.FromBase64String(imageString);

            return image;
        }
    }
}  
