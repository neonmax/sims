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
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Text; 

/// <summary>
/// Summary description for RoutoSMSTelecom
/// </summary>
public class RoutoSMSTelecom
{
    //Declare return variable at failures 
    String ConError = "error";
	public RoutoSMSTelecom()
	{
		
	}
    //Declare global variables
    public String user = "";
    public String pass = "";
    public String number = "";
    public String ownnum = "";
    public String message = "";
    public String messageId = "";
    public String type = "";
    public String model = "";
    public String op = "";

    public String SetUser(String newuser)
    {
        //Set user name
        this.user = newuser;
        return user;
    }

    public String SetPass(String newpass)
    {
        //Set password
        this.pass = newpass;
        return pass;
    }

    public String SetNumber(String newnumber)
    {
        //Set sender's mobile no
        this.number = newnumber;
        return number;
    }

    public String SetOwnNumber(String newownnum)
    {
        //Set sender's mobile no
        this.ownnum = newownnum;
        return ownnum;
    }

    public String SetType(String newtype)
    {
        //Set message type
        this.type = newtype;
        return type;
    }

    public String SetModel(String newmodel)
    {
        //Set modle
        this.model = newmodel;
        return model;
    }

    public String SetMessage(String newmessage)
    {
        //Set the message
        this.message = newmessage;
        return message;
    }

    public String SetMessageId(String newmessageid)
    {
        //Set message id
        this.messageId = newmessageid;
        return messageId;
    }

    public String SetOp(String newop)
    {
        //Set operation
        this.op = newop;
        return op;
    }

    private String urlencode(String str)
    {
        return HttpUtility.UrlEncode(str);
    }

    public String Send()
    {
        //Declaration & pass parameters
        String Body = "";
        Body += "number=" + this.number;
        Body += "&user=" + urlencode(this.user);
        Body += "&pass=" + urlencode(this.pass);
        Body += "&message=" + urlencode(this.message); 
        //Check message ID
        if ((this.messageId).Length >= 1)
        {
            Body += "&mess_id=" + urlencode(this.messageId) + "&delivery=1";
        }
        //Check mobile no
        if ((this.ownnum) != "")
        {
            Body += "&ownnum=" + urlencode(this.ownnum);
        }
        //Check modle
        if ((this.model) != "")
        {
            Body += "&model=" + urlencode(this.model);
        }
        //Check operation
        if ((this.op) != "")
        {
            Body += "&op=" + urlencode(this.op);
        }
        //Check message type
        if ((this.type) != "")
        {
            Body += "&type=" + urlencode(this.type);
        }
        //Calculate body string length
        int ContentLength = Body.Length;
        //Assign a host | remote service
        String Host = "smsc5.routotelecom.com";
        //Create header message
        String Header = "Message Sent";//"POST /cgi-bin/SMSsend HTTP/1.0\n" + "Host: " + Host + "\n" + "Content-Type: application/x-www-form-urlencoded\n" + "Content-Length: " + ContentLength + "\n\n" + Body + "\n";
        //Socket set to null
        Socket mysocket = null;
        //Create tcpClient variable
        TcpClient tcpClient;
        //Create null object varables
        StreamWriter streamWriter = null;
        StreamReader streamReader = null;
        NetworkStream networkStream = null;
        //Declare line variable as empty.
        String line = "";

        try
        {
            //Assign new TcpClient
            tcpClient = new TcpClient();
            //Set port details
            tcpClient.Connect(Host,80);
            //Configure socket
            mysocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //Connect to the socket
            mysocket.Connect(Host,80);
            //Get stream
            networkStream = tcpClient.GetStream();
            //Create StreamReader
            streamReader = new StreamReader(networkStream);
            //Create StreamWriter
            streamWriter = new StreamWriter(networkStream);
            //Get header in to writer
            streamWriter.WriteLine(Header);
            //Pass the value to service
            streamWriter.Flush();
            //Read stream start to end
            line = streamReader.ReadToEnd();

        }
        catch (Exception ex)
        {
            //throw new Exception(ex.Message);
            //Return variable
            return ConError;
        }
        //return string
        return Header + " " + line;
    }

    //Get values
    public String GetUser()
    {
        return this.user;
    }

    public String GetPass()
    {
        return this.pass;
    }

    public String GetNumber()
    {
        return this.number;
    }

    public String GetMessage()
    {
        return this.message;
    }

    public String GetMessageId()
    {
        return this.messageId;
    }

    public String GetOwnNum()
    {
        return this.ownnum;
    }

    public String GetOp()
    {
        return this.op;
    }

    public String GetType()
    {
        return this.type;
    }

    public String GetModel()
    {
        return this.model;
    }

    public static byte[] ReadFully(Stream stream)
    {
        //Create buffer
        byte[] buffer = new byte[32768];
        //create memoryStream & use
        using (MemoryStream ms = new MemoryStream())
        {
            while (true)
            {
                int read = stream.Read(buffer, 0, buffer.Length);
                if (read <= 0)
                    return ms.ToArray();
                ms.Write(buffer, 0, read);
            }
        }
    }
    //Implementation to get a immage
    public string getImage(string url)
    {
        try

        {   //create a web request
            WebRequest request = WebRequest.Create(url);
            //set buffer size
            byte[] file = new byte[1024 * 1024];
            //get stream
            Stream stream = request.GetResponse().GetResponseStream();
            
            file = ReadFully(stream);

            return Convert.ToBase64String(file, Base64FormattingOptions.InsertLineBreaks);
        }

        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
