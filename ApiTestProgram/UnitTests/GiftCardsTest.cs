using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Annytab.WebshopClientAPI;

namespace ApiTestProgram
{
    [TestClass]
    public class GiftCardsTest
    {
        [TestMethod]
        public async Task TestAdd()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            GiftCard giftCard = new GiftCard();
            giftCard.id = "";
            giftCard.language_id = 1;
            giftCard.currency_code = "EUR";
            giftCard.amount = 100.8995555M;
            giftCard.end_date = DateTime.Now;

            // Add the post
            ResponseMessage response = await GiftCard.Add(connection, giftCard);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestAdd method

        [TestMethod]
        public async Task TestUpdate()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            GiftCard giftCard = new GiftCard();
            giftCard.id = "";
            giftCard.language_id = 2;
            giftCard.currency_code = "SEK";
            giftCard.amount = 200.22222M;
            giftCard.end_date = new DateTime(2015,12,5);

            // Add the post
            ResponseMessage response = await GiftCard.Update(connection, giftCard);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestUpdate method

        [TestMethod]
        public async Task TestGetCountBySearch()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get the count
            Int32 count = await GiftCard.GetCountBySearch(connection, "TEST1");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, count);

        } // End of the TestGetCountBySearch method

        [TestMethod]
        public async Task TestGetById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            GiftCard post = await GiftCard.GetById(connection, "TEST11");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(null, post);

        } // End of the TestGetById method

        [TestMethod]
        public async Task TestGetAll()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<GiftCard> posts = await GiftCard.GetAll(connection, "amount", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, posts.Count);

        } // End of the TestGetAll method

        [TestMethod]
        public async Task TestGetBySearch()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<GiftCard> posts = await GiftCard.GetBySearch(connection, "TEST1", 10, 1, "id", "DESC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, posts.Count);

        } // End of the TestGetBySearch method

        [TestMethod]
        public async Task TestDeletePost()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Delete the master post
            ResponseMessage response = await GiftCard.Delete(connection, "TEST3");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeletePost method

    } // End of the class

} // End of the namespace