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
    /// This class represent an order
    /// </summary>
    public class Order
    {
        #region Variables

        public Int32 id;
        public byte document_type;
        public DateTime order_date;
        public Int32 company_id;
        public string country_code;
        public string language_code;
        public string currency_code;
        public decimal conversion_rate;
        public Int32 customer_id;
        public byte customer_type;
        public string customer_org_number;
        public string customer_vat_number;
        public string customer_name;
        public string customer_phone;
        public string customer_mobile_phone;
        public string customer_email;
        public string invoice_name;
        public string invoice_address_1;
        public string invoice_address_2;
        public string invoice_post_code;
        public string invoice_city;
        public Int32 invoice_country_id;
        public string delivery_name;
        public string delivery_address_1;
        public string delivery_address_2;
        public string delivery_post_code;
        public string delivery_city;
        public Int32 delivery_country_id;
        public decimal net_sum;
        public decimal vat_sum;
        public decimal rounding_sum;
        public decimal total_sum;
        public byte vat_code;
        public Int32 payment_option;
        public string payment_token;
        public string payment_status;
        public bool exported_to_erp;
        public string order_status;
        public DateTime desired_date_of_delivery;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new order with default properties
        /// </summary>
        public Order()
        {
            // Set values for instance variables
            this.id = 0;
            this.document_type = 0;
            this.order_date = new DateTime(2000, 1, 1);
            this.company_id = 0;
            this.country_code = "";
            this.language_code = "";
            this.currency_code = "";
            this.conversion_rate = 0;
            this.customer_id = 0;
            this.customer_type = 0;
            this.customer_org_number = "";
            this.customer_vat_number = "";
            this.customer_name = "";
            this.customer_phone = "";
            this.customer_mobile_phone = "";
            this.customer_email = "";
            this.invoice_name = "";
            this.invoice_address_1 = "";
            this.invoice_address_2 = "";
            this.invoice_post_code = "";
            this.invoice_city = "";
            this.invoice_country_id = 0;
            this.delivery_name = "";
            this.delivery_address_1 = "";
            this.delivery_address_2 = "";
            this.delivery_post_code = "";
            this.delivery_city = "";
            this.delivery_country_id = 0;
            this.net_sum = 0;
            this.vat_sum = 0;
            this.rounding_sum = 0;
            this.total_sum = 0;
            this.vat_code = 0;
            this.payment_option = 0;
            this.payment_token = "";
            this.payment_status = "";
            this.exported_to_erp = false;
            this.order_status = "";
            this.desired_date_of_delivery = DateTime.Now;

        } // End of the constructor

        #endregion

        #region Insert methods

        /// <summary>
        /// Add a order
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Add(ClientConnection cn, Order post)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<Order>("/api/orders/add", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Add method

        #endregion

        #region Update methods

        /// <summary>
        /// Update a order
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Update(ClientConnection cn, Order post)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<Order>("/api/orders/update", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Update method method

        /// <summary>
        /// Set an order as exported
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="orderId">The order id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> SetAsExported(ClientConnection cn, Int32 orderId)
        {
            // Update the post
            HttpResponseMessage response = await cn.GetAsync("/api/orders/set_as_exported/" + orderId);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Update method method

        #endregion

        #region Count methods

        /// <summary>
        /// Get the count of posts by a search
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="keywords">A string with keywords, delimited by space</param>
        /// <returns>The count of posts as an int</returns>
        public async static Task<Int32> GetCountBySearch(ClientConnection cn, string keywords)
        {
            // Create the integer to return
            Int32 count = 0;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/orders/get_count_by_search?keywords=" + keywords);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                count = await response.Content.ReadAsAsync<Int32>();
            }

            // Return the count
            return count;

        } // End of the GetCountBySearch method

        #endregion

        #region Get methods

        /// <summary>
        /// Get one order by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of the post</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<Order> GetById(ClientConnection cn, Int32 id)
        {
            // Create the post to return
            Order post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/orders/get_by_id/" + id.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<Order>();
            }

            // Return the post
            return post;

        } // End of the GetById method

        /// <summary>
        /// Get not exported orders
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<Order>> GetNotExported(ClientConnection cn, string sortField, string sortOrder)
        {
            // Create the list to return
            List<Order> posts = new List<Order>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/orders/get_not_exported?sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Order>>();
            }

            // Return the list
            return posts;

        } // End of the GetNotExported method

        /// <summary>
        /// Get not exported orders by company id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The company id</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<Order>> GetNotExportedByCompanyId(ClientConnection cn, Int32 id, string sortField, string sortOrder)
        {
            // Create the list to return
            List<Order> posts = new List<Order>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/orders/get_not_exported_by_company_id/" + id.ToString() + "?sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Order>>();
            }

            // Return the list
            return posts;

        } // End of the GetNotExportedByCompanyId method

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param> 
        /// <returns>A list with posts</returns>
        public async static Task<List<Order>> GetAll(ClientConnection cn, string sortField, string sortOrder)
        {
            // Create the list to return
            List<Order> posts = new List<Order>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/orders/get_all?sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Order>>();
            }

            // Return the list
            return posts;

        } // End of the GetAll method

        /// <summary>
        /// Get posts by a search
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="keywords">A string of keywords, delimited by space</param>
        /// <param name="pageSize">The number of posts to get on one page</param>
        /// <param name="pageNumber">The page number</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<Order>> GetBySearch(ClientConnection cn, string keywords, Int32 pageSize, Int32 pageNumber,
            string sortField, string sortOrder)
        {
            // Create the list to return
            List<Order> posts = new List<Order>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/orders/get_by_search?keywords=" + keywords + "&pageSize="
                + pageSize + "&pageNumber=" + pageNumber + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Order>>();
            }

            // Return the list
            return posts;

        } // End of the GetBySearch method

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete a order
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Delete(ClientConnection cn, Int32 id)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/orders/delete/" + id);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Delete method

        #endregion

    } // End of the class

} // End of the namespace
