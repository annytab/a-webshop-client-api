using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Annytab.WebshopClientAPI;

namespace ApiTestProgram
{
    [TestClass]
    public class CustomersTest
    {

        [TestMethod]
        public async Task TestAdd()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            Customer customer = new Customer();
            customer.id = 0;
            customer.language_id = 2;
            customer.email = "email uuu";
            customer.customer_password = "password";
            customer.customer_type = 0;
            customer.org_number = "org number";
            customer.vat_number = "vat number";
            customer.contact_name = "contact name";
            customer.phone_number = "phone number";
            customer.mobile_phone_number = "mobile phone number";
            customer.invoice_name = "invoice name";
            customer.invoice_address_1 = "invoice address 1";
            customer.invoice_address_2 = "invoice address 2";
            customer.invoice_post_code = "invoice post code";
            customer.invoice_city = "invoice city";
            customer.invoice_country = 1;
            customer.delivery_name = "delivery name";
            customer.delivery_address_1 = "delivery address 1";
            customer.delivery_address_2 = "delivery address 2";
            customer.delivery_post_code = "delivery post code";
            customer.delivery_city = "delivery city";
            customer.delivery_country = 3;
            customer.newsletter = true;
            customer.facebook_user_id = "Facebook user id";
            customer.google_user_id = "Google user id";

            // Add the post
            ResponseMessage response = await Customer.Add(connection, customer);

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
            Customer customer = new Customer();
            customer.id = 9;
            customer.language_id = 3;
            customer.email = "email sdfasdf";
            customer.customer_password = "bbb";
            customer.customer_type = 1;
            customer.org_number = "org number UPP";
            customer.vat_number = "vat number UPP";
            customer.contact_name = "contact name UPP";
            customer.phone_number = "phone number UPP";
            customer.mobile_phone_number = "mobile phone number UPP";
            customer.invoice_name = "invoice name UPP";
            customer.invoice_address_1 = "invoice address 1 UPP";
            customer.invoice_address_2 = "invoice address 2 UPP";
            customer.invoice_post_code = "invoice post code UPP";
            customer.invoice_city = "invoice city UPP";
            customer.invoice_country = 2;
            customer.delivery_name = "delivery name UPP";
            customer.delivery_address_1 = "delivery address 1 UPP";
            customer.delivery_address_2 = "delivery address 2 UPP";
            customer.delivery_post_code = "delivery post code UPP";
            customer.delivery_city = "delivery city UPP";
            customer.delivery_country = 1;
            customer.newsletter = false;
            customer.facebook_user_id = "Facebook user id UPP";
            customer.google_user_id = "Google user id UPP";

            // Add the post
            ResponseMessage response = await Customer.Update(connection, customer);

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
            Int32 count = await Customer.GetCountBySearch(connection, "");

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
            List<Customer> posts = await Customer.GetBySearch(connection, "", 10, 1, "id", "DESC");

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
            List<Customer> customers = await Customer.GetAll(connection, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, customers.Count);

        } // End of the TestGetAll method

        [TestMethod]
        public async Task TestGetById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            Customer post = await Customer.GetById(connection, 5);

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
            ResponseMessage response = await Customer.Delete(connection, 5);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeletePost method

    } // End of the class

} // End of the namespace
