using System;

namespace TestWork4ForPromit.Uploader
{
    class Program
    {
        static void Main(string[] args)
        {
            using var uploader = new Uploader();

            uploader.Start();
        }
    }
}
