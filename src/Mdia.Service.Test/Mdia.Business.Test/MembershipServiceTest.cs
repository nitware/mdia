using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mdia.Business.Interfaces;
using Mdia.Data;
using Mdia.Model.Model;
using System.Threading.Tasks;

namespace Mdia.Business.Test
{
    [TestClass]
    public class MembershipServiceTest
    {
        private static IRepository _da;
        private static ICryptoService _cryptoService;
        private static IMembershipService _membershipService;

        //setup
        [ClassInitialize]
        public static void Intitialise(TestContext context)
        {
            

            _da = new Repository();
            _cryptoService = new CryptoService();
            _membershipService = new MembershipService(_da, _cryptoService);
        }


        [TestMethod]
        public async Task UserExistReturnsCorrectResult()
        {
            //arrange
            await UserExistReturnsCorrectResultHelper("daniel@yahoo.com", false);
            await UserExistReturnsCorrectResultHelper("dani@yahoo.com", true);
        }
        private async Task UserExistReturnsCorrectResultHelper(string username, bool expectedResult)
        {
            //act
            bool exist = await _membershipService.UserExistAsync(username);

            //assert
            Assert.AreEqual(expectedResult, exist);
        }


        [TestMethod]
        public async Task ValidateUserReturnsCorrectUserContext()
        {
            //arrange
            await ValidateUserReturnsCorrectUserContextHelper("daniel@yahoo.com", "xxx", false);
            await ValidateUserReturnsCorrectUserContextHelper("dani@yahoo.com", "password", true);
            await ValidateUserReturnsCorrectUserContextHelper("dan@yahoo.com", "password", true);
        }
        private async Task ValidateUserReturnsCorrectUserContextHelper(string username, string password, bool exist)
        {
            //act
            UserContext userContext = await _membershipService.ValidateUserAsync(username, password);

            //assert
            Assert.AreEqual(userContext != null, exist);
            if (userContext != null)
            {
                Assert.IsNotNull(userContext.User);
                Assert.IsNotNull(userContext.Principal);
                Assert.IsNotNull(userContext.Principal.Identity);
                Assert.AreEqual(userContext.User.Name, userContext.Principal.Identity.Name);
                Assert.AreEqual(username, userContext.User.Email);
            }
        }

                
        [TestMethod]
        public async Task UserIsCorrectlyCreated()
        {
            //arrange
            User user = new User();
            user.FirstName = "Evlyn";
            user.Surname = "Aniebo";
            user.Email = "evlyn.aniebo@yahoo.com";
            user.MobileNumber = "09011111097";
            user.Password = "password";

            //act
            User newUser = await _membershipService.CreateUserAsync(user);

            //assert
            Assert.IsNotNull(newUser);
            Assert.AreEqual(user, newUser);

        }





    }







}
