using System;
using System.Security.AccessControl;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCarOBD
{
    [TestClass]
    public class UserInfoTest
    {
        [TestMethod]
        public void TestDesEncrypt()
        {
            Console.WriteLine(EncodeHelper.DesEncrypt("12345"));
        }

        [TestMethod]
        public void TestDesDecrypt()
        {
            EncodeHelper.DesDecrypt(EncodeHelper.DesEncrypt("123"));
        }
    }
}
