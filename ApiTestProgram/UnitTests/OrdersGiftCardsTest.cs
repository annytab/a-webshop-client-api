using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Annytab.WebshopClientAPI;

namespace ApiTestProgram
{
    [TestClass]
    public class OrdersGiftCardsTest
    {
        [TestMethod]
        public async Task TestAdd()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            OrderGiftCard post = new OrderGiftCard();
            post.order_id = 5;
            post.gift_card_id = "TEST1";
            post.amount = 100.5788M;

            // Add the post
            ResponseMessage response = await OrderGiftCard.Add(connection, post);

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
            OrderGiftCard post = new OrderGiftCard();
            post.order_id = 5;
            post.gift_card_id = "TEST1";
            post.amount = 5000.112222M;

            // Add the post
            ResponseMessage response = await OrderGiftCard.Update(connection, post);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestUpdate method

        [TestMethod]
        public async Task TestGetById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            OrderGiftCard post = await OrderGiftCard.GetById(connection, 5, "TEST1");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(null, post);

        } // End of the TestGetById method

        [TestMethod]
        public async Task TestGetByOrderId()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<OrderGiftCard> posts = await OrderGiftCard.GetByOrderId(connection, 25, "gift_card_id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, posts.Count);

        } // End of the TestGetByOrderId method

        [TestMethod]
        public async Task TestGetByGiftCardId()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<OrderGiftCard> posts = await OrderGiftCard.GetByGiftCardId(connection, "TEST1", "order_id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, posts.Count);

        } // End of the TestGetByGiftCardId method

        [TestMethod]
        public async Task TestGetAll()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<OrderGiftCard> posts = await OrderGiftCard.GetAll(connection);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, posts.Count);

        } // End of the TestGetAll method

        [TestMethod]
        public async Task TestDeletePost()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Delete the master post
            ResponseMessage response = await OrderGiftCard.Delete(connection, 5000, "TEST1");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeletePost method

    } // End of the class

} // End of the namespace