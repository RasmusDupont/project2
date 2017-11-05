using System;
using System.Collections.Generic;
using System.Text;
using WebAPI;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace XUnitTest
{
    public class DataServiceTest
    {


        [Fact]
        public void Test_connection()
        {
            DataService service = new DataService();
            Boolean con = service.CheckConnection();
            Assert.True(con);
        }

    }
}
