using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Annytab.WebshopClientAPI;

namespace ApiTestProgram
{
    [TestClass]
    public class ProductOptionTypesTest
    {
        [TestMethod]
        public async Task TestAdd()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            ProductOptionType productOptionType = new ProductOptionType();
            productOptionType.id = 0;
            productOptionType.product_id = 2;
            productOptionType.option_type_id = 21;
            productOptionType.google_name = "google name";
            productOptionType.title = "Title";
            productOptionType.sort_order = 2;
            productOptionType.selected = false;

            // Add the post
            ResponseMessage response = await ProductOptionType.Add(connection, productOptionType);

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
            ProductOptionType productOptionType = new ProductOptionType();
            productOptionType.id = 18;
            productOptionType.product_id = 2;
            productOptionType.option_type_id = 20;
            productOptionType.google_name = "google name UPP";
            productOptionType.title = "Title UPP";
            productOptionType.sort_order = 9;
            productOptionType.selected = false;

            // Add the post
            ResponseMessage response = await ProductOptionType.Update(connection, productOptionType);

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
            ProductOptionType post = await ProductOptionType.GetById(connection, 18, 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(null, post);

        } // End of the TestGetById method

        [TestMethod]
        public async Task TestGetByProductId()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<ProductOptionType> productOptionTypes = await ProductOptionType.GetByProductId(connection, 2, 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, productOptionTypes.Count);

        } // End of the TestGetByProductId method

        [TestMethod]
        public async Task TestGetAll()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<ProductOptionType> productOptionTypes = await ProductOptionType.GetAll(connection, 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, productOptionTypes.Count);

        } // End of the TestGetAll method

        [TestMethod]
        public async Task TestDeletePost()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Delete the master post
            ResponseMessage response = await ProductOptionType.Delete(connection, 18);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeletePost method

    } // End of the class

} // End of the namespace
