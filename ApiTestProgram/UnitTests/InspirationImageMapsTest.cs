using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Annytab.WebshopClientAPI;

namespace ApiTestProgram
{
    [TestClass]
    public class InspirationImageMapsTest
    {
        [TestMethod]
        public async Task TestAdd()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            InspirationImageMap imageMap = new InspirationImageMap();
            imageMap.id = 0;
            imageMap.language_id = 0;
            imageMap.name = "TEST API";
            imageMap.image_name = "Image name";
            imageMap.image_map_points = "Image map points";
            imageMap.category_id = 0;

            // Add the post
            ResponseMessage response = await InspirationImageMap.Add(connection, imageMap);

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
            InspirationImageMap imageMap = new InspirationImageMap();
            imageMap.id = 4;
            imageMap.language_id = 1;
            imageMap.name = "TEST API UPP";
            imageMap.image_name = "Image name UPP";
            imageMap.image_map_points = "Image map points UPP";
            imageMap.category_id = 0;

            // Add the post
            ResponseMessage response = await InspirationImageMap.Update(connection, imageMap);

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
            Int32 count = await InspirationImageMap.GetCountBySearch(connection, "Test A");

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
            InspirationImageMap post = await InspirationImageMap.GetById(connection, 1);

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
            List<InspirationImageMap> posts = await InspirationImageMap.GetAll(connection, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, posts.Count);

        } // End of the TestGetAll method

        [TestMethod]
        public async Task TestGetByCategoryId()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<InspirationImageMap> posts = await InspirationImageMap.GetByCategoryId(connection, 0, 1, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, posts.Count);

        } // End of the TestGetByCategoryId method

        [TestMethod]
        public async Task TestGetBySearch()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<InspirationImageMap> posts = await InspirationImageMap.GetBySearch(connection, "7", 2, 1, "id", "DESC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, posts.Count);

        } // End of the TestGetBySearch method

        [TestMethod]
        public async Task TestGetImageById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            string url = await InspirationImageMap.GetImageById(connection, 6);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual("", url);

        } // End of the TestGetImageById method

        [TestMethod]
        public async Task TestGetAllImages()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            Dictionary<Int32, string> images = await InspirationImageMap.GetAllImages(connection);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, images.Count);

        } // End of the TestGetAllImages method

        [TestMethod]
        public async Task TestDeletePost()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Delete the master post
            ResponseMessage response = await InspirationImageMap.Delete(connection, 7);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeletePost method

        [TestMethod]
        public async Task TestUploadImage()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create the list with images
            string imageUrl = "d:\\Bilder\\1970.jpg";

            // Delete the master post
            ResponseMessage response = await InspirationImageMap.UploadImage(connection, 7, imageUrl);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestUploadImages method

        [TestMethod]
        public async Task TestDeleteImage()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Delete the master post
            ResponseMessage response = await InspirationImageMap.DeleteImage(connection, 6);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeleteImage method

    } // End of the class

} // End of the namespace
