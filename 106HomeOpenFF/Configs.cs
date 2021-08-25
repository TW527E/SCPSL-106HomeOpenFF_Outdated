using Exiled.API.Interfaces;
using System.ComponentModel;

namespace P106HomeOpenFF
{
    public sealed class Configs : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Onlyff { get; set; } = false;
    }
}
