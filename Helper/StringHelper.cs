using System;
using System.IO;

namespace Anticaptcha.Helper
{
    public class StringHelper
    {
        public static string ImageFileToBase64String(string path)
        {
            if (File.Exists(path))
            {
                // TODO: Add image check (by format and/or content)
                try
                {
                    var imageBytes = File.ReadAllBytes(path);

                    // Convert byte[] to Base64 String
                    var base64String = Convert.ToBase64String(imageBytes);

                    return base64String;
                }
                catch
                { }
            }

            return null;
        }
    }
}