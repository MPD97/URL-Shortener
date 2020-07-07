using System;

namespace Presistance.Services
{
    public class AliasGenerator :IAliasGenerator
    {
        private readonly Random _random;

        public AliasGenerator()
        {
            _random = new Random();
        }

        public string Generate(int length)
        {
            throw new System.NotImplementedException();
        }
        public string Generate(int length, Random random)
        {
            throw new System.NotImplementedException();
        }
    }
}