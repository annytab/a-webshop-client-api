using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Annytab.WebshopClientAPI;

namespace ApiTestProgram
{
    [TestClass]
    public class ProductOptionsTest
    {
        [TestMethod]
        public async Task TestAdd()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            ProductOption productOption = new ProductOption();
            productOption.product_option_type_id = 17;
            productOption.option_id = 22;
            productOption.title = "Title";
            productOption.product_code_suffix = "Pro suff";
            productOption.mpn_suffix = "mpn suff";
            productOption.price_addition = 5.66M;
            productOption.freight_addition = 4.44M;
            productOption.selected = false;
            
            // Add the post
            ResponseMessage response = await ProductOption.Add(connection, productOption);

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
            ProductOption productOption = new ProductOption();
            productOption.product_option_type_id = 17;
            productOption.option_id = 22;
            productOption.title = "Title UPP";
            productOption.product_code_suffix = "Pro suff U";
            productOption.mpn_suffix = "mpn suff U";
            productOption.price_addition = 22.22M;
            productOption.freight_addition = 11.11M;
            productOption.selected = false;

            // Add the post
            ResponseMessage response = await ProductOption.Update(connection, productOption);

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
            ProductOption post = await ProductOption.GetById(connection, 17, 22, 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(null, post);

        } // End of the TestGetById method

        [TestMethod]
        public async Task TestGetByProductOptionId()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<ProductOption> productOptions = await ProductOption.GetByProductOptionTypeId(connection, 17, 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, productOptions.Count);

        } // End of the TestGetByProductOptionId method

        [TestMethod]
        public async Task TestGetAll()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<ProductOption> productOptions = await ProductOption.GetAll(connection, 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, productOptions.Count);

        } // End of the TestGetAll method

        [TestMethod]
        public async Task TestDeletePost()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Delete the master post
            ResponseMessage response = await ProductOption.Delete(connection, 17, 22);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeletePost method

    } // End of the class

} // End of the namespace
