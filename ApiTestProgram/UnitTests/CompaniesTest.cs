using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Annytab.WebshopClientAPI;

namespace ApiTestProgram
{
    [TestClass]
    public class CompaniesTest
    {
        [TestMethod]
        public async Task TestAdd()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            Company company = new Company();
            company.id = 0;
            company.name = "Name SE";
            company.registered_office = "Registered office SE";
            company.org_number = "Org number SE";
            company.vat_number = "VAT number SE";
            company.phone_number = "Phone number SE";
            company.mobile_phone_number = "Mobile phone SE";
            company.email = "Email SE";
            company.post_address_1 = "Post 1 SE";
            company.post_address_2 = "Post 2 SE";
            company.post_code = "Post code SE";
            company.post_city = "Post city SE";
            company.post_country = "Post country SE";

            // Add the post
            ResponseMessage response = await Company.Add(connection, company);

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
            Company company = new Company();
            company.id = 3;
            company.name = "Name UPP";
            company.registered_office = "Registered office UPP";
            company.org_number = "Org number UPP";
            company.vat_number = "VAT number UPP";
            company.phone_number = "Phone number UPP";
            company.mobile_phone_number = "Mobile phone UPP";
            company.email = "Email UPP";
            company.post_address_1 = "Post 1 UPP";
            company.post_address_2 = "Post 2 UPP";
            company.post_code = "Post code UPP";
            company.post_city = "Post city UPP";
            company.post_country = "Post country UPP";

            // Add the post
            ResponseMessage response = await Company.Update(connection, company);

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
            Int32 count = await Company.GetCountBySearch(connection, "");

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
            List<Company> posts = await Company.GetBySearch(connection, "", 10, 1, "id", "DESC");

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
            List<Company> companies = await Company.GetAll(connection, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, companies.Count);

        } // End of the TestGetAll method

        [TestMethod]
        public async Task TestGetById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            Company post = await Company.GetById(connection, 3);

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
            ResponseMessage response = await Company.Delete(connection, 4);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeletePost method

    } // End of the class

} // End of the namespace
