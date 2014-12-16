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
    /// This class represent a customer
    /// </summary>
    public class Customer
    {
        #region Variables

        public Int32 id;
        public Int32 language_id;
        public string email;
        public string customer_password;
        public byte customer_type;
        public string org_number;
        public string vat_number;
        public string contact_name;
        public string phone_number;
        public string mobile_phone_number;
        public string invoice_name;
        public string invoice_address_1;
        public string invoice_address_2;
        public string invoice_post_code;
        public string invoice_city;
        public Int32 invoice_country;
        public string delivery_name;
        public string delivery_address_1;
        public string delivery_address_2;
        public string delivery_post_code;
        public string delivery_city;
        public Int32 delivery_country;
        public bool newsletter;
        public string facebook_user_id;
        public string google_user_id;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new customer with default properties
        /// </summary>
        public Customer()
        {
            // Set values for instance variables
            this.id = 0;
            this.language_id = 0;
            this.email = "";
            this.customer_password = "";
            this.customer_type = 0;
            this.org_number = "";
            this.vat_number = "";
            this.contact_name = "";
            this.phone_number = "";
            this.mobile_phone_number = "";
            this.invoice_name = "";
            this.invoice_address_1 = "";
            this.invoice_address_2 = "";
            this.invoice_post_code = "";
            this.invoice_city = "";
            this.invoice_country = 0;
            this.delivery_name = "";
            this.delivery_address_1 = "";
            this.delivery_address_2 = "";
            this.delivery_post_code = "";
            this.delivery_city = "";
            this.delivery_country = 0;
            this.newsletter = true;
            this.facebook_user_id = "";
            this.google_user_id = "";

        } // End of the constructor

        #endregion

        #region Insert methods

        /// <summary>
        /// Add a customer
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Add(ClientConnection cn, Customer post)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<Customer>("/api/customers/add", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Add method

        #endregion

        #region Update methods

        /// <summary>
        /// Update a customer
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Update(ClientConnection cn, Customer post)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<Customer>("/api/customers/update", post);

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
            HttpResponseMessage response = await cn.GetAsync("/api/customers/get_count_by_search?keywords=" + keywords);

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
        /// Get one customer by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of the post</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<Customer> GetById(ClientConnection cn, Int32 id)
        {
            // Create the post to return
            Customer post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/customers/get_by_id/" + id.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<Customer>();
            }

            // Return the post
            return post;

        } // End of the GetById method

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<Customer>> GetAll(ClientConnection cn, string sortField, string sortOrder)
        {
            // Create the list to return
            List<Customer> posts = new List<Customer>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/customers/get_all?sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Customer>>();
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
        public async static Task<List<Customer>> GetBySearch(ClientConnection cn, string keywords, Int32 pageSize, Int32 pageNumber,
            string sortField, string sortOrder)
        {
            // Create the list to return
            List<Customer> posts = new List<Customer>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/customers/get_by_search?keywords=" + keywords + "&pageSize="
                + pageSize + "&pageNumber=" + pageNumber + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Customer>>();
            }

            // Return the list
            return posts;

        } // End of the GetBySearch method

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete a customer
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Delete(ClientConnection cn, Int32 id)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/customers/delete/" + id);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Delete method

        #endregion

    } // End of the class

} // End of the namespace
