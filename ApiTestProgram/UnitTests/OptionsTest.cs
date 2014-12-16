using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Annytab.WebshopClientAPI;

namespace ApiTestProgram
{
    [TestClass]
    public class OptionsTest
    {

        [TestMethod]
        public async Task TestAdd()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            Option option = new Option();
            option.id = 0;
            option.title = "Title SE";
            option.product_code_suffix = "TSE";
            option.sort_order = 0;
            option.option_type_id = 21;

            // Add the post
            ResponseMessage response = await Option.Add(connection, option, 1);

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
            Option option = new Option();
            option.id = 55;
            option.title = "Title SE UPP";
            option.product_code_suffix = "TSE-UPP";
            option.sort_order = 1;
            option.option_type_id = 20;

            // Add the post
            ResponseMessage response = await Option.Update(connection, option, 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestUpdate method

        [TestMethod]
        public async Task TestTranslate()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            Option option = new Option();
            option.id = 55;
            option.title = "Title US";
            option.product_code_suffix = "TSE-US";
            option.sort_order = 3;
            option.option_type_id = 0;

            // Add the post
            ResponseMessage response = await Option.Translate(connection, option, 2);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestTranslate method

        [TestMethod]
        public async Task TestGetById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            Option post = await Option.GetById(connection, 51, 2);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(null, post);

        } // End of the TestGetById method

        [TestMethod]
        public async Task TestGetByOptionTypeId()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<Option> options = await Option.GetByOptionTypeId(connection, 5, 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, options.Count);

        } // End of the TestGetByOptionTypeId method

        [TestMethod]
        public async Task TestGetAll()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<Option> options = await Option.GetAll(connection, 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, options.Count);

        } // End of the TestGetAll method

        [TestMethod]
        public async Task TestDeletePost()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Delete the language post
            ResponseMessage response = await Option.Delete(connection, 48, 0);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " " + response.reason_phrase + " " + response.message);

        } // End of the TestDeletePost method

    } // End of the class

} // End of the namespace
