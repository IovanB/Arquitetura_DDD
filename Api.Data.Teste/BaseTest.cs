using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Teste
{
    public abstract class BaseTest
    {
        public BaseTest()
        {
                
        }
    }

    public class DbTeste : IDisposable
    {
        //private string dataBaseName = $"dbApiTest_"
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
