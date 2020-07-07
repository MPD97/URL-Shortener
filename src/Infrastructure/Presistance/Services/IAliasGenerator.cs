using System;

namespace Presistance.Services
{
    public interface IAliasGenerator
    {
        public string Generate(int length);
        public string Generate(int length, Random random);

    }
}