using System;

namespace Presistance.Services
{
    public interface IAliasGenerator
    {
        public string Generate(int length);
    }
}