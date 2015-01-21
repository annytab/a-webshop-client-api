using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Annytab.WebshopClientAPI;

namespace ApiTestProgram
{
    [TestClass]
    public class DomainsTest
    {
        [TestMethod]
        public async Task TestAdd()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            Domain domain = new Domain();
            domain.id = 0;
            domain.webshop_name = "Webshop name";
            domain.domain_name = "Domain name 2";
            domain.web_address = "Web address";
            domain.country_id = 1;
            domain.front_end_language = 1;
            domain.back_end_language = 2;
            domain.currency = "SEK";
            domain.company_id = 1;
            domain.default_display_view = 0;
            domain.mobile_display_view = 1;
            domain.custom_theme_id = 0;
            domain.prices_includes_vat = false;
            domain.analytics_tracking_id = "Analytics tracking id";
            domain.facebook_app_id = "FB APP ID";
            domain.facebook_app_secret = "FB APP SECRET";
            domain.google_app_id = "GOOGLE APP ID";
            domain.google_app_secret = "GOOGLE APP SECRET";
            domain.noindex = false;

            // Add the post
            ResponseMessage response = await Domain.Add(connection, domain);

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
            Domain domain = new Domain();
            domain.id = 2;
            domain.webshop_name = "Webshop name UPP";
            domain.domain_name = "Domain name UPP";
            domain.web_address = "Web address UPP";
            domain.country_id = 3;
            domain.front_end_language = 1;
            domain.back_end_language = 1;
            domain.currency = "EUR";
            domain.company_id = 1;
            domain.default_display_view = 1;
            domain.mobile_display_view = 2;
            domain.custom_theme_id = 0;
            domain.prices_includes_vat = true;
            domain.analytics_tracking_id = "Analytics tracking id UPP";
            domain.facebook_app_id = "FB APP ID UPP";
            domain.facebook_app_secret = "FB APP SECRET UPP";
            domain.google_app_id = "GOOGLE APP ID UPP";
            domain.google_app_secret = "GOOGLE APP SECRET UPP";
            domain.noindex = true;

            // Add the post
            ResponseMessage response = await Domain.Update(connection, domain);

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
            Int32 count = await Domain.GetCountBySearch(connection, "");

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
            List<Domain> posts = await Domain.GetBySearch(connection, "", 10, 1, "id", "DESC");

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
            List<Domain> domains = await Domain.GetAll(connection, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, domains.Count);

        } // End of the TestGetAll method

        [TestMethod]
        public async Task TestGetById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            Domain post = await Domain.GetById(connection, 2);

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
            ResponseMessage response = await Domain.Delete(connection, 4);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeletePost method

    } // End of the class

} // End of the namespace
