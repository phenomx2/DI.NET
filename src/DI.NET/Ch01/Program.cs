using System;
using System.IO;

namespace Ch01
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessageWriter writer = new ConsoleMessageWritter();
            Saludation saludation = new Saludation(writer);

            saludation.Exclaim();
        }
    }

    public interface IMessageWriter
    {
        void Write(string message);
    }

    public class ConsoleMessageWritter : IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class FileMessageWriter : IMessageWriter
    {
        public void Write(string message)
        {
            File.WriteAllText(@"C:\test\filewriter.txt", message);
        }
    }

    public class Saludation
    {
        private readonly IMessageWriter _writer;

        public Saludation(IMessageWriter writer)
        {
            if (writer == null)
                throw new ArgumentException("writer");

            _writer = writer;
        }

        public void Exclaim()
        {
            _writer.Write("Hello DI");
        }
    }

}
