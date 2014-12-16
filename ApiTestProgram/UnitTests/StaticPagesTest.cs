using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Annytab.WebshopClientAPI;

namespace ApiTestProgram
{
    [TestClass]
    public class StaticPagesTest
    {
        [TestMethod]
        public async Task TestAdd()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            StaticPage staticPage = new StaticPage();
            staticPage.id = 0;
            staticPage.link_name = "Link name SE";
            staticPage.title = "Title SE";
            staticPage.main_content = "Main content SE";
            staticPage.meta_description = "Meta description SE";
            staticPage.meta_keywords = "Meta keywords SE";
            staticPage.meta_robots = "Meta robots SE";
            staticPage.page_name = "page_name_1";
            staticPage.connected_to_page = 0;
            staticPage.inactive = false;

            // Add the post
            ResponseMessage response = await StaticPage.Add(connection, staticPage, 1);

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
            StaticPage staticPage = new StaticPage();
            staticPage.id = 7;
            staticPage.link_name = "Link name UPP";
            staticPage.title = "Title UPP";
            staticPage.main_content = "Main content UPP";
            staticPage.meta_description = "Meta description UPP";
            staticPage.meta_keywords = "Meta keywords UPP";
            staticPage.meta_robots = "Meta robots UPP";
            staticPage.page_name = "page_name";
            staticPage.connected_to_page = 1;
            staticPage.inactive = true;

            // Add the post
            ResponseMessage response = await StaticPage.Update(connection, staticPage, 1);

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
            StaticPage staticPage = new StaticPage();
            staticPage.id = 8;
            staticPage.link_name = "Link name US";
            staticPage.title = "Title US";
            staticPage.main_content = "Main content US";
            staticPage.meta_description = "Meta description US";
            staticPage.meta_keywords = "Meta keywords US";
            staticPage.meta_robots = "Meta robots US";
            staticPage.page_name = "page_name_us2";
            staticPage.connected_to_page = 2;
            staticPage.inactive = false;

            // Add the post
            ResponseMessage response = await StaticPage.Translate(connection, staticPage, 2);

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
            Int32 count = await StaticPage.GetCountBySearch(connection, "", 1);

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
            List<StaticPage> posts = await StaticPage.GetBySearch(connection, "", 1, 10, 1, "id", "DESC");

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
            List<StaticPage> staticPages = await StaticPage.GetAll(connection, 1, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, staticPages.Count);

        } // End of the TestGetAll method

        [TestMethod]
        public async Task TestGetAllActive()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<StaticPage> staticPages = await StaticPage.GetAllActive(connection, 1, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, staticPages.Count);

        } // End of the TestGetAllActive method

        [TestMethod]
        public async Task TestGetById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            StaticPage post = await StaticPage.GetById(connection, 7, 2);

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

            // Delete the master post
            ResponseMessage response = await StaticPage.Delete(connection, 7, 0);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeletePost method

    } // End of the class

} // End of the namespace
