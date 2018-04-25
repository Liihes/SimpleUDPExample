/* * The purpose of this program is to provide a minimal example of using UDP to 
* send data.
* It transmits broadcast packets and displays the text in a console window.
* This was created to work with the program UDP_Minimum_Listener.
* Run both programs, send data with Talker, receive the data with Listener.*/

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
  static void Main(string[] args)
  {
    Boolean done = false;
    Boolean exception_thrown = false;
    
    Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,ProtocolType.Udp);
    IPAddress send_to_address = IPAddress.Parse("192.168.2.255");
    IPEndPoint sending_end_point = new IPEndPoint(send_to_address, 11000);
    
    Console.WriteLine("Enter text to broadcast via UDP.");
    Console.WriteLine("Enter a blank line to exit the program.");
    
    while (!done)
    {
      Console.WriteLine("Enter text to send, blank line to quit");
      string text_to_send = Console.ReadLine();
      
      if (text_to_send.Length == 0) { done = true; } 
      else { 
      byte[] send_buffer = Encoding.ASCII.GetBytes(text_to_send);
      Console.WriteLine("sending to address: {0} port: {1}", sending_end_point.Address, sending_end_point.Port);
      
      try { sending_socket.SendTo(send_buffer, sending_end_point); } 
      catch ( Exception Ex ) { Console.WriteLine("The Massage could not be sent: {0}" , Ex.Message); }
    }
  }
} 
      
    
    
    
    
    
    
