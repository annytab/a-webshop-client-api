using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Annytab.WebshopClientAPI;

namespace ApiTestProgram
{
    [TestClass]
    public class OptionTypesTest
    {

        [TestMethod]
        public async Task TestAdd()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            OptionType optionType = new OptionType();
            optionType.id = 0;
            optionType.google_name = "g:name";
            optionType.title = "Title SE";
            optionType.option_count = 1;

            // Add the post
            ResponseMessage response = await OptionType.Add(connection, optionType, 1);

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
            OptionType optionType = new OptionType();
            optionType.id = 27;
            optionType.google_name = "g:color";
            optionType.title = "Title SE UPP";
            optionType.option_count = 8;

            // Add the post
            ResponseMessage response = await OptionType.Update(connection, optionType, 1);

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
            OptionType optionType = new OptionType();
            optionType.id = 27;
            optionType.google_name = "g:pattern";
            optionType.title = "Title US Translated";
            optionType.option_count = 40;

            // Add the post
            ResponseMessage response = await OptionType.Translate(connection, optionType, 2);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestTranslate method

        [TestMethod]
        public async Task TestGetCountBySearch()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get the count
            Int32 count = await OptionType.GetCountBySearch(connection, "", 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, count);

        } // End of the TestGetCountBySearch method

        [TestMethod]
        public async Task TestGetBySearch()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<OptionType> posts = await OptionType.GetBySearch(connection, "", 1, 10, 1, "id", "DESC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, posts.Count);

        } // End of the TestGetBySearch method

        [TestMethod]
        public async Task TestGetAll()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<OptionType> optionTypes = await OptionType.GetAll(connection, 2);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, optionTypes.Count);

        } // End of the TestGetAll method

        [TestMethod]
        public async Task TestGetById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            OptionType post = await OptionType.GetById(connection, 25, 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(null, post);

        } // End of the TestGetById method

        [TestMethod]
        public async Task TestDeletePost()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Delete the language post
            ResponseMessage response = await OptionType.Delete(connection, 25, 0);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " " + response.reason_phrase + " " + response.message);

        } // End of the TestDeletePost method

    } // End of the class

} // End of the namespace
