using System;
using System.Collections.Generic;
using System.Text;
using CodePasswordDLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailSender.lib.Tests.Service
{
    [TestClass]
    public class TestEncoderTests
    {
        static TestEncoderTests()
        {

        }

        public TestEncoderTests()
        {

        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext Context)
        {

        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext Context)
        {

        }

        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestCleanup]
        public void TestCleanup()
        {

        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {

        }

        [TestMethod]
        public void Encode_ABC_to_BCD()
        {
            // A-A-A = Arrange - Act - Assert

            const string str = "ABC";            
            const string expected_str = "BCD";

            var actual_str = CodePassword.getCodPassword(str);

            Assert.AreEqual(expected_str, actual_str);
        }

        [TestMethod]
        public void Decode_BCD_to_ABC()
        {
            // A-A-A = Arrange - Act - Assert

            const string str = "BCD";
            const string expected_str = "ABC1";

            var actual_str = CodePassword.getPassword(str);

            Assert.AreEqual(expected_str, actual_str, "Трындец");

        }
    }
}