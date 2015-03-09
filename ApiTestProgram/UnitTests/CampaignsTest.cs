using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Annytab.WebshopClientAPI;

namespace ApiTestProgram
{
    [TestClass]
    public class CampaignsTest
    {
        
        [TestMethod]
        public async Task TestAdd()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            Campaign campaign = new Campaign();
            campaign.id = 0;
            campaign.language_id = 1;
            campaign.name = "Name SV";
            campaign.category_name = "category name SV";
            campaign.image_name = "image name SV";
            campaign.link_url = "link url SV";
            campaign.inactive = false;
            campaign.click_count = 5;
            
            // Add the post
            ResponseMessage response = await Campaign.Add(connection, campaign);

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
            Campaign campaign = new Campaign();
            campaign.id = 9;
            campaign.language_id = 1;
            campaign.name = "Name SV UPP";
            campaign.category_name = "category name SV UPP";
            campaign.image_name = "image name SV UPP";
            campaign.link_url = "link url SV UPP";
            campaign.inactive = true;
            campaign.click_count = 10;

            // Add the post
            ResponseMessage response = await Campaign.Update(connection, campaign);

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
            Int32 count = await Campaign.GetCountBySearch(connection, "1");

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
            List<Campaign> posts = await Campaign.GetBySearch(connection, "1", 10, 1, "id", "DESC");

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
            List<Campaign> campaigns = await Campaign.GetAll(connection, 0, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, campaigns.Count);

        } // End of the TestGetAll method

        [TestMethod]
        public async Task TestGetById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            Campaign post = await Campaign.GetById(connection, 9);

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
            ResponseMessage response = await Campaign.Delete(connection, 9);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeletePost method

        [TestMethod]
        public async Task TestUploadImages()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create the list with images
            List<string> imageUrls = new List<string>(2);
            imageUrls.Add("d:\\Bilder\\1960.jpg");
            imageUrls.Add("d:\\Bilder\\1970.jpg");

            // Delete the master post
            ResponseMessage response = await Campaign.UploadImages(connection, imageUrls);

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

            // Create the list with images
            string imageName = "1960.jpg";

            // Delete the master post
            ResponseMessage response = await Campaign.DeleteImage(connection, imageName);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeleteImage method

        [TestMethod]
        public async Task TestDeleteAllImages()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Delete the master post
            ResponseMessage response = await Campaign.DeleteAllImages(connection);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeleteAllImages method

    } // End of the class

} // End of the namespace
