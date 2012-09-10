using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Encriptor
/// </summary>
public class Encriptor
{

    public Encriptor()
    {
        
    }

    public string encript(string input)    
    {
        //create MD5 service provider
        System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
        //create byte array & encode user entered password in to it
        byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
        //hashing the encoded dyte stream
        bs = x.ComputeHash(bs);
        //create string builder object
        System.Text.StringBuilder s = new System.Text.StringBuilder();
        //append the bye stream using "x2"
        foreach (byte b in bs)
        {
            s.Append(b.ToString("x2").ToLower());
        }
        //encripted byte stream convert to string & save in password variable
        string password = s.ToString();
        //return password variable 
        return password;
    }


   
}
