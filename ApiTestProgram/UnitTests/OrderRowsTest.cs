using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Annytab.WebshopClientAPI;

namespace ApiTestProgram
{
    [TestClass]
    public class OrderRowsTest
    {
        [TestMethod]
        public async Task TestAdd()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            OrderRow orderRow = new OrderRow();
            orderRow.order_id = 25; //25
            orderRow.product_code = "Product code";
            orderRow.manufacturer_code = "Manufacture code";
            orderRow.product_id = 100;
            orderRow.gtin = "Gtin";
            orderRow.product_name = "Product name";
            orderRow.vat_percent = 0.12M;
            orderRow.quantity = 5;
            orderRow.unit_id = 2;
            orderRow.unit_price = 499.99M;
            orderRow.account_code = "Acc code";
            orderRow.supplier_erp_id = "Supplier id";
            orderRow.sort_order = 2;

            // Add the post
            ResponseMessage response = await OrderRow.Add(connection, orderRow);

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
            OrderRow orderRow = new OrderRow();
            orderRow.order_id = 25;
            orderRow.product_code = "Product code";
            orderRow.manufacturer_code = "Manufacture code UPP";
            orderRow.product_id = 200;
            orderRow.gtin = "Gtin UPP";
            orderRow.product_name = "Product name UPP";
            orderRow.vat_percent = 0.25M;
            orderRow.quantity = 1;
            orderRow.unit_id = 1;
            orderRow.unit_price = 88.88M;
            orderRow.account_code = "Acc UPP";
            orderRow.supplier_erp_id = "Supplier UPP";
            orderRow.sort_order = 0;

            // Add the post
            ResponseMessage response = await OrderRow.Update(connection, orderRow);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestUpdate method

        [TestMethod]
        public async Task TestGetAll()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<OrderRow> orderRows = await OrderRow.GetAll(connection);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, orderRows.Count);

        } // End of the TestGetAll method

        [TestMethod]
        public async Task TestGetByOrderId()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<OrderRow> orderRows = await OrderRow.GetByOrderId(connection, 25);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, orderRows.Count);

        } // End of the TestGetByOrderId method

        [TestMethod]
        public async Task TestGetById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            OrderRow post = await OrderRow.GetById(connection, 25, "Product code");

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
            ResponseMessage response = await OrderRow.Delete(connection, 25, "Product code");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeletePost method

    } // End of the class

} // End of the namespace
