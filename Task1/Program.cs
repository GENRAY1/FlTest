using System.Text;

namespace Task1;
class Program
{
    static void Main(string[] args)
    {
        byte[] data = Encoding.Default.GetBytes("Hello;World;Bye;");
        byte divider = 59;

        
        using (MemoryStream stream = new MemoryStream(data))
        {
            List<byte[]> messages = ReadMessages(stream, divider);

            foreach (var message in messages)
            {
                string messageString = Encoding.Default.GetString(message);
                Console.WriteLine("Msg: " + messageString);
            }
        }
    }
    static List<byte[]> ReadMessages(Stream stream, byte divider)
    {
        List<byte> temp = new List<byte>();
        List<byte[]> messages = new List<byte[]>();
        int data;

        while ((data = stream.ReadByte()) != -1)
        {
            if (data == divider)
            {
                messages.Add(temp.ToArray());
                temp.Clear();
            }
            else
            {
                temp.Add((byte)data);
            }
        }
        return messages;
    }
}