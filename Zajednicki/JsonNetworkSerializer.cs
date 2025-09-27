using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Zajednicki
{
    public class JsonNetworkSerializer
    {
        private readonly Socket s;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public JsonNetworkSerializer(Socket s){
            this.s = s;
            stream=new NetworkStream(s);
            reader=new StreamReader(stream);
            writer=new StreamWriter(stream)
            {
                AutoFlush = true
            };
        }

        public void Send(object z)
        {
            writer.WriteLine(JsonSerializer.Serialize(z));
        }

        public T Receive<T>()
        {
            string json=reader.ReadLine();
            return JsonSerializer.Deserialize<T>(json);
        }

    }
}
