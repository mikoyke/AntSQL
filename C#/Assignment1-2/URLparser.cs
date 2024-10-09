namespace Assignment1_2;

public class URLparser
{
    public void Main( )
    {
        Console.WriteLine("Enter a URL to parse:");
        string url = Console.ReadLine();
        string protocol = null;
        string server = null;
        string resource = null;
        
        int protocolEndIndex = url.IndexOf("://");

        if (protocolEndIndex != -1) 
        {
            protocol = url.Substring(0, protocolEndIndex);  
            url = url.Substring(protocolEndIndex + 3);   
        }

        int serverEndIndex = url.IndexOf('/');
        if (serverEndIndex != -1)  
        {
            server = url.Substring(0, serverEndIndex);  
            resource = url.Substring(serverEndIndex + 1);  
        }
        else 
        {
            server = url;
        }
        
        Console.WriteLine("[protocol] = " + '"' + (protocol ?? "(none)" + '"'));
        Console.WriteLine("[server] = " + '"' + server + '"');
        Console.WriteLine("[resource] = " + '"' + (resource ?? "(none)")+ '"');
    }
}