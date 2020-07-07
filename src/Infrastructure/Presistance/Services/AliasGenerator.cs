using System;
using System.Linq;

namespace Presistance.Services
{
    public class AliasGenerator : IAliasGenerator
    {
        private readonly Random _random;
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";


        public AliasGenerator()
        {
            _random = new Random();
        }

        public string Generate(int length)
        {
            return new string(Enumerable.Repeat(Chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public string Generate(int length, Random random)
        {
            return new string(Enumerable.Repeat(Chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}