using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Annytab.WebshopClientAPI
{
    /// <summary>
    /// This class represent an order row
    /// </summary>
    public class OrderRow
    {

        #region Variables

        public Int32 order_id;
        public string product_code;
        public string manufacturer_code;
        public Int32 product_id;
        public string gtin;
        public string product_name;
        public decimal vat_percent;
        public decimal quantity;
        public Int32 unit_id;
        public decimal unit_price;
        public string account_code;
        public string supplier_erp_id;
        public Int16 sort_order;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new order row with default properties
        /// </summary>
        public OrderRow()
        {
            // Set values for instance variables
            this.order_id = 0;
            this.product_code = "";
            this.manufacturer_code = "";
            this.product_id = 0;
            this.gtin = "";
            this.product_name = "";
            this.vat_percent = 0;
            this.quantity = 0;
            this.unit_id = 0;
            this.unit_price = 0;
            this.account_code = "";
            this.supplier_erp_id = "";
            this.sort_order = 0;

        } // End of the constructor

        #endregion

        #region Insert methods

        /// <summary>
        /// Add a order row
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Add(ClientConnection cn, OrderRow post)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<OrderRow>("/api/order_rows/add", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Add method

        #endregion

        #region Update methods

        /// <summary>
        /// Update a order row
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Update(ClientConnection cn, OrderRow post)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<OrderRow>("/api/order_rows/update", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Update method method

        #endregion

        #region Get methods

        /// <summary>
        /// Get one order row by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="orderId">The order id</param>
        /// <param name="productCode">The product code</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<OrderRow> GetById(ClientConnection cn, Int32 orderId, string productCode)
        {
            // Create the post to return
            OrderRow post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/order_rows/get_by_id/" + orderId.ToString() + "?productCode=" + productCode);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<OrderRow>();
            }

            // Return the post
            return post;

        } // End of the GetById method

        /// <summary>
        /// Get orders by order id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="orderId">The order id</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<List<OrderRow>> GetByOrderId(ClientConnection cn, Int32 orderId)
        {
            // Create the post to return
            List<OrderRow> posts = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/order_rows/get_by_order_id/" + orderId.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<OrderRow>>();
            }

            // Return the list
            return posts;

        } // End of the GetByOrderId method

        /// <summary>
        /// Get all order rows
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<OrderRow>> GetAll(ClientConnection cn)
        {
            // Create the list to return
            List<OrderRow> posts = new List<OrderRow>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/order_rows/get_all");

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<OrderRow>>();
            }

            // Return the list
            return posts;

        } // End of the GetAll method

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete a order row
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="orderId">The order id</param>
        /// <param name="productCode">The product code</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Delete(ClientConnection cn, Int32 orderId, string productCode)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/order_rows/delete/" + orderId.ToString() + "?productCode=" + productCode);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Delete method

        #endregion

    } // End of the class

} // End of the namespace
