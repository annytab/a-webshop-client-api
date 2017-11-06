using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Annytab.WebshopClientAPI;
using System.Net.Http;

namespace ApiTestProgram
{
    [TestClass]
    public class AdditionalServicesTest
    {
        
        [TestMethod]
        public async Task TestAdd()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            AdditionalService service = new AdditionalService();
            service.id = 0;
            service.product_code = "XX";
            service.name = "Test SV";
            service.fee = 5555555555555;
            service.unit_id = 3;
            service.price_based_on_mount_time = false;
            service.value_added_tax_id = 1;
            service.account_code = "10";
            service.inactive = false;
            service.selected = false;

            // Add the post
            ResponseMessage response = await AdditionalService.Add(connection, service, 2);

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
            AdditionalService service = new AdditionalService();
            service.id = 3;
            service.product_code = "TT5";
            service.name = "Test SV uppdaterad";
            service.fee = 9.99M;
            service.unit_id = 2;
            service.price_based_on_mount_time = true;
            service.value_added_tax_id = 2;
            service.account_code = "10U";
            service.inactive = true;
            service.selected = true;

            // Add the post
            ResponseMessage response = await AdditionalService.Update(connection, service, 2);

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
            AdditionalService service = new AdditionalService();
            service.id = 3;
            service.product_code = "TTeee";
            service.name = "Test ES Espanol";
            service.fee = 7;
            service.unit_id = 0;
            service.price_based_on_mount_time = false;
            service.value_added_tax_id = 3;
            service.account_code = "11";
            service.inactive = false;
            service.selected = false;

            // Add the post
            ResponseMessage response = await AdditionalService.Translate(connection, service, 2);

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
            Int32 count = await AdditionalService.GetCountBySearch(connection, "", 1);

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
            List<AdditionalService> posts = await AdditionalService.GetBySearch(connection, "", 1, 10, 1, "id", "DESC");

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
            List<AdditionalService> additionalServices = await AdditionalService.GetAll(connection, 1, "id", "ASC");
            
            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, additionalServices.Count);

        } // End of the TestGetAll method

        [TestMethod]
        public async Task TestGetAllActive()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<AdditionalService> additionalServices = await AdditionalService.GetAllActive(connection, 1, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, additionalServices.Count);

        } // End of the TestGetAllActive method

        [TestMethod]
        public async Task TestGetById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            AdditionalService post = await AdditionalService.GetById(connection, 1, 1);

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
            ResponseMessage response = await AdditionalService.Delete(connection, 5, 0);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeletePost method

    } // End of the class

} // End of the namespace
