using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Annytab.WebshopClientAPI;
using System.Net.Http;

namespace ApiTestProgram
{
    [TestClass]
    public class PaymentOptionsTest
    {
        [TestMethod]
        public async Task TestAdd()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            PaymentOption paymentOption = new PaymentOption();
            paymentOption.id = 0;
            paymentOption.product_code = "Product code";
            paymentOption.name = "Name SE";
            paymentOption.payment_term_code = "T-code SE";
            paymentOption.fee = 5.12M;
            paymentOption.unit_id = 1;
            paymentOption.connection = 0;
            paymentOption.value_added_tax_id = 1;
            paymentOption.account_code = "Acco SE";
            paymentOption.inactive = false;

            // Add the post
            ResponseMessage response = await PaymentOption.Add(connection, paymentOption, 1);

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
            PaymentOption paymentOption = new PaymentOption();
            paymentOption.id = 11; // 11
            paymentOption.product_code = "Product code";
            paymentOption.name = "Name SE UPP";
            paymentOption.payment_term_code = "T-code SUP";
            paymentOption.fee = 5.68M;
            paymentOption.unit_id = 2;
            paymentOption.connection = 225;
            paymentOption.value_added_tax_id = 2;
            paymentOption.account_code = "Acco SU";
            paymentOption.inactive = true;

            // Add the post
            ResponseMessage response = await PaymentOption.Update(connection, paymentOption, 1);

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
            PaymentOption paymentOption = new PaymentOption();
            paymentOption.id = 11; // 8
            paymentOption.product_code = "Product code";
            paymentOption.name = "Name US";
            paymentOption.payment_term_code = "T-code US";
            paymentOption.fee = 5.68M;
            paymentOption.unit_id = 0;
            paymentOption.connection = 0;
            paymentOption.value_added_tax_id = 3;
            paymentOption.account_code = "Acco US";
            paymentOption.inactive = false;

            // Add the post
            ResponseMessage response = await PaymentOption.Translate(connection, paymentOption, 2);

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
            Int32 count = await PaymentOption.GetCountBySearch(connection, "", 1);

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
            List<PaymentOption> posts = await PaymentOption.GetBySearch(connection, "", 1, 10, 1, "id", "DESC");

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
            List<PaymentOption> paymentOptions = await PaymentOption.GetAll(connection, 1, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, paymentOptions.Count);

        } // End of the TestGetAll method

        [TestMethod]
        public async Task TestGetAllActive()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<PaymentOption> paymentOptions = await PaymentOption.GetAllActive(connection, 1, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, paymentOptions.Count);

        } // End of the TestGetAllActive method

        [TestMethod]
        public async Task TestGetById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            PaymentOption post = await PaymentOption.GetById(connection, 8, 1);

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
            ResponseMessage response = await PaymentOption.Delete(connection, 8, 0);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeletePost method

    } // End of the class

} // End of the namespace
