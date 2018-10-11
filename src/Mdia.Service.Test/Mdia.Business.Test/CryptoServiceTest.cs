using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mdia.Business.Interfaces;

namespace Mdia.Business.Test
{
    [TestClass]
    public class CryptoServiceTest
    {
        private static ICryptoService _cryptoService;

        [ClassInitialize]
        public static void Intitialise(TestContext context)
        {
            //arrange
            _cryptoService = new CryptoService();
        }

        [TestMethod]
        public void SaltIsCorrectlyGenerated()
        {
            //act
            string salt = _cryptoService.GenerateSalt();

            //assert
            Assert.IsNotNull(salt);

        }

        [TestMethod]
        public void DifferentSaltIsCorrectlyGenerated()
        {
            //act
            string salt1 = _cryptoService.GenerateSalt();
            string salt2 = _cryptoService.GenerateSalt();
            string salt3 = _cryptoService.GenerateSalt();
            string salt4 = _cryptoService.GenerateSalt();

            //assert
            Assert.IsNotNull(salt1);
            Assert.IsNotNull(salt2);
            Assert.IsNotNull(salt3);
            Assert.IsNotNull(salt4);

            Assert.AreNotEqual(salt1, salt2);
            Assert.AreNotEqual(salt1, salt3);
            Assert.AreNotEqual(salt1, salt4);
            Assert.AreNotEqual(salt2, salt1);
            Assert.AreNotEqual(salt2, salt3);
            Assert.AreNotEqual(salt2, salt4);
            Assert.AreNotEqual(salt3, salt1);
            Assert.AreNotEqual(salt3, salt2);
            Assert.AreNotEqual(salt3, salt4);
            Assert.AreNotEqual(salt4, salt1);
            Assert.AreNotEqual(salt4, salt2);
            Assert.AreNotEqual(salt4, salt3);

        }




    }



}
