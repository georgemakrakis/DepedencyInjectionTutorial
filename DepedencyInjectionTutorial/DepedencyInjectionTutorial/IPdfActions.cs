using System;
using System.Collections.Generic;
using System.Text;

namespace DepedencyInjectionTutorial
{
    public interface IPdfActions
    {
        void WriteReadData(string fileName, byte[] data);
    }
}
