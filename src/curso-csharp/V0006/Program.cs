using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Servidor conectado na porta 50291");

TcpListener listener = new TcpListener(IPAddress.Loopback, 50291);
listener.Start();

TcpClient chamada = listener.AcceptTcpClient();

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
StreamReader sr = new StreamReader(chamada.GetStream(), Encoding.GetEncoding(850));
StreamWriter sw = new StreamWriter(chamada.GetStream(), Encoding.GetEncoding(850));

Console.WriteLine("Cliente conectado, seu endereço de IP é {0}!", ((IPEndPoint)chamada.Client.RemoteEndPoint).Address);

string? mensagem;
// 1. Faça:
//    a. Ler uma linha do sr e guardar em *mensagem*
//    b. Ecoar em sw os seguintes dizeres: "Você digitou: " e concatenar *mensagem*
//    c. Ecoar uma quebra de linha em sw
//    d. Purgar sw
//    Enquanto *mensagem* não for null e *mensagem* não for "Chega!"
//
// Retirar a linha de baixo e implementar a funcionalidade
throw new NotImplementedException();

chamada.Close();
listener.Stop();

Console.WriteLine("Servidor parado! Obrigado por utilizar!");
Console.WriteLine();
