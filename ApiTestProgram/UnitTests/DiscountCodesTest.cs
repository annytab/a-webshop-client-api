using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Annytab.WebshopClientAPI;

namespace ApiTestProgram
{
    [TestClass]
    public class DiscountCodesTest
    {
        [TestMethod]
        public async Task TestAdd()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            DiscountCode discountCode = new DiscountCode();
            discountCode.id = "TEST6";
            discountCode.language_id = 1;
            discountCode.currency_code = "SEK";
            discountCode.discount_value = 0.55556M;
            discountCode.free_freight = false;
            discountCode.end_date = new DateTime(2016,3,5);
            discountCode.once_per_customer = true;
            discountCode.exclude_products_on_sale = true;
            discountCode.minimum_order_value = 599;

            // Add the post
            ResponseMessage response = await DiscountCode.Add(connection, discountCode);

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
            DiscountCode discountCode = new DiscountCode();
            discountCode.id = "TEST";
            discountCode.language_id = 2;
            discountCode.currency_code = "USD";
            discountCode.discount_value = 0.4333M;
            discountCode.free_freight = true;
            discountCode.end_date = new DateTime(2018, 4, 6);
            discountCode.once_per_customer = true;
            discountCode.exclude_products_on_sale = true;
            discountCode.minimum_order_value = 568.4556M;

            // Add the post
            ResponseMessage response = await DiscountCode.Update(connection, discountCode);

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
            Int32 count = await DiscountCode.GetCountBySearch(connection, "TEST");

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
            DiscountCode post = await DiscountCode.GetById(connection, "TEST");

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
            List<DiscountCode> posts = await DiscountCode.GetAll(connection, "id", "ASC");

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
            List<DiscountCode> posts = await DiscountCode.GetBySearch(connection, "TEST", 10, 1, "id", "DESC");

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
            ResponseMessage response = await DiscountCode.Delete(connection, "TEST2");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeletePost method

    } // End of the class

} // End of the namespace