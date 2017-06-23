using System;
using SQLite.Net.Interop;

namespace ECommerceApp.Interfaces
{
    public interface IConfig
    {
        string DirectoryDB { get; }

        ISQLitePlatform Platform { get; }
    }
}
