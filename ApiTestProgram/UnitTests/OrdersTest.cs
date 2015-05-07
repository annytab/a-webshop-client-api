using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Annytab.WebshopClientAPI;

namespace ApiTestProgram
{
    [TestClass]
    public class OrdersTest
    {
        [TestMethod]
        public async Task TestAdd()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            Order order = new Order();
            order.id = 0;
            order.document_type = 0;
            order.order_date = DateTime.Now;
            order.company_id = 1;
            order.country_code = "SE";
            order.language_code = "SV";
            order.currency_code = "SEK";
            order.conversion_rate = 1.4M;
            order.customer_id = 1;
            order.customer_type = 0;
            order.customer_org_number = "Org number";
            order.customer_vat_number = "Vat number";
            order.customer_name = "Contact name";
            order.customer_phone = "Phone";
            order.customer_mobile_phone = "Mobile phone";
            order.customer_email = "Email";
            order.invoice_name = "Invoice name";
            order.invoice_address_1 = "Invoice address 1";
            order.invoice_address_2 = "Invoice adress 2";
            order.invoice_post_code = "Invoice post code";
            order.invoice_city = "Invoice city";
            order.invoice_country_id = 1;
            order.delivery_name = "Delivery name";
            order.delivery_address_1 = "Delivery address 1";
            order.delivery_address_2 = "Delivery address 2";
            order.delivery_post_code = "Delivery post code";
            order.delivery_city = "Delivery city";
            order.delivery_country_id = 1;
            order.net_sum = 100.50M;
            order.vat_sum = 50.20M;
            order.rounding_sum = 0.30M;
            order.total_sum = 151.00M;
            order.vat_code = 0;
            order.payment_option = 1;
            order.payment_token = "Payment token";
            order.payment_status = "Payment_status";
            order.exported_to_erp = false;
            order.order_status = "Order status";
            order.desired_date_of_delivery = new DateTime(2015, 2, 3);
            order.discount_code = "TEST";
            order.gift_cards_amount = 100.66455M;

            // Add the post
            ResponseMessage response = await Order.Add(connection, order);

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
            Order order = new Order();
            order.id = 59;
            order.document_type = 1;
            order.order_date = DateTime.Now;
            order.company_id = 1;
            order.country_code = "SU";
            order.language_code = "VU";
            order.currency_code = "USD";
            order.conversion_rate = 1.8M;
            order.customer_id = 2;
            order.customer_type = 1;
            order.customer_org_number = "Org number UPP";
            order.customer_vat_number = "Vat number UPP";
            order.customer_name = "Contact name UPP";
            order.customer_phone = "Phone UPP";
            order.customer_mobile_phone = "Mobile phone UPP";
            order.customer_email = "Email UPP";
            order.invoice_name = "Invoice name UPP";
            order.invoice_address_1 = "Invoice address 1 UPP";
            order.invoice_address_2 = "Invoice adress 2 UPP";
            order.invoice_post_code = "Invoice post code UPP";
            order.invoice_city = "Invoice city UPP";
            order.invoice_country_id = 2;
            order.delivery_name = "Delivery name UPP";
            order.delivery_address_1 = "Delivery address 1 UPP";
            order.delivery_address_2 = "Delivery address 2 UPP";
            order.delivery_post_code = "Delivery post code UPP";
            order.delivery_city = "Delivery city UPP";
            order.delivery_country_id = 2;
            order.net_sum = 200.50M;
            order.vat_sum = 100.30M;
            order.rounding_sum = 0.20M;
            order.total_sum = 301.00M;
            order.vat_code = 1;
            order.payment_option = 2;
            order.payment_token = "Payment token UPP";
            order.payment_status = "Payment status UPP";
            order.exported_to_erp = true;
            order.order_status = "Order status UPP";
            order.desired_date_of_delivery = new DateTime(2019, 3, 30);
            order.discount_code = "TEST UPP";
            order.gift_cards_amount = 2000.44444221M;

            // Add the post
            ResponseMessage response = await Order.Update(connection, order);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestUpdate method

        [TestMethod]
        public async Task TestSetAsExported()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Add the post
            ResponseMessage response = await Order.SetAsExported(connection, 26);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestSetAsExported method

        [TestMethod]
        public async Task TestUpdateGiftCardsAmount()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Add the post
            ResponseMessage response = await Order.UpdateGiftCardsAmount(connection, 58, 5000.66646465464M);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestUpdateGiftCardsAmount method

        [TestMethod]
        public async Task TestGetCountBySearch()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get the count
            Int32 count = await Order.GetCountBySearch(connection, "");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, count);

        } // End of the TestGetCountBySearch method

        [TestMethod]
        public async Task TestGetCountByCustomerId()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get the count
            Int32 count = await Order.GetCountByCustomerId(connection, 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, count);

        } // End of the TestGetCountByCustomerId method

        [TestMethod]
        public async Task TestGetCountByDiscountCode()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get the count
            Int32 count = await Order.GetCountByDiscountCode(connection, "XXXSSS");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, count);

        } // End of the TestGetCountByDiscountCode method

        [TestMethod]
        public async Task TestGetById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            Order post = await Order.GetById(connection, 7);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(null, post);

        } // End of the TestGetById method

        [TestMethod]
        public async Task TestGetByDiscountCodeAndCustomer()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            Order post = await Order.GetByDiscountCodeAndCustomer(connection, "XXXSSS", 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(null, post);

        } // End of the TestGetByDiscountCodeAndCustomer method

        [TestMethod]
        public async Task TestGetNotExported()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<Order> orders = await Order.GetNotExported(connection, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, orders.Count);

        } // End of the TestGetNotExported method

        [TestMethod]
        public async Task TestGetNotExportedByCompanyId()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<Order> orders = await Order.GetNotExportedByCompanyId(connection, 1, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, orders.Count);

        } // End of the TestGetNotExported method

        [TestMethod]
        public async Task TestGetAll()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<Order> orders = await Order.GetAll(connection, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, orders.Count);

        } // End of the TestGetAll method

        [TestMethod]
        public async Task TestGetBySearch()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<Order> posts = await Order.GetBySearch(connection, "", 10, 1, "id", "DESC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, posts.Count);

        } // End of the TestGetBySearch method

        [TestMethod]
        public async Task TestGetByCustomerId()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<Order> posts = await Order.GetByCustomerId(connection, 1, 10, 1, "id", "DESC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, posts.Count);

        } // End of the TestGetByCustomerId method

        [TestMethod]
        public async Task TestGetByDiscountCode()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<Order> posts = await Order.GetByDiscountCode(connection, "XXXSSS", 10, 1, "id", "DESC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, posts.Count);

        } // End of the TestGetByDiscountCode method

        [TestMethod]
        public async Task TestDeletePost()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Delete the master post
            ResponseMessage response = await Order.Delete(connection, 26);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeletePost method

    } // End of the class

} // End of the namespace
