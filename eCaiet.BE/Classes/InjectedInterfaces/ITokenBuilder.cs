using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCaiet.BE.Classes.InjectedInterfaces
{
    public interface ITokenBuilder
    {
        string Generate<T>(T key);
    }
}
