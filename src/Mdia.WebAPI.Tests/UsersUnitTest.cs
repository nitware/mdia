using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mdia.WebAPI.Controllers;
using Mdia.Data;
using Mdia.Business.Interfaces;
using Mdia.Business;
using Mdia.Model.Model;
using System.Collections.Generic;

namespace Mdia.WebAPI.Tests
{
    [TestClass]
    public class UsersUnitTest
    {
        [TestMethod]
        public void GetAllUsersTest()
        {
            IRepository da = new Repository();
            ICryptoService cryptoService = new CryptoService();
            IMembershipService ms = new MembershipService(da, cryptoService);
            UsersController uc = new UsersController(da, ms);


            List<User> users = uc.GetUsers();


            Assert.IsNotNull(users);
            Assert.AreEqual(4, users.Count);
            Assert.AreEqual("Amanda", users[0].FirstName);

        }






    }
}
