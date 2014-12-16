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
    /// This class represent a product option
    /// </summary>
    public class ProductOption
    {
        #region Variables

        public Int32 product_option_type_id;
        public Int32 option_id;
        public string title;
        public string product_code_suffix;
        public string mpn_suffix;
        public decimal price_addition;
        public decimal freight_addition;
        public bool selected;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new product option with default properties
        /// </summary>
        public ProductOption()
        {
            // Set values for instance variables
            this.product_option_type_id = 0;
            this.option_id = 0;
            this.title = "";
            this.product_code_suffix = "";
            this.mpn_suffix = "";
            this.price_addition = 0;
            this.freight_addition = 0;
            this.selected = false;

        } // End of the constructor

        #endregion


        #region Insert methods

        /// <summary>
        /// Add a product option
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Add(ClientConnection cn, ProductOption post)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<ProductOption>("/api/product_options/add", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Add method

        #endregion

        #region Update methods

        /// <summary>
        /// Update a product option
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Update(ClientConnection cn, ProductOption post)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<ProductOption>("/api/product_options/update", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Update method method

        #endregion

        #region Get methods

        /// <summary>
        /// Get one product option by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="productOptionTypeId">The product option type id</param>
        /// <param name="optionId">The option id</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<ProductOption> GetById(ClientConnection cn, Int32 productOptionTypeId, Int32 optionId, Int32 languageId)
        {
            // Create the post to return
            ProductOption post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/product_options/get_by_id/" + productOptionTypeId.ToString() + "?optionId=" 
                + optionId.ToString() + "&languageId=" + languageId.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<ProductOption>();
            }

            // Return the post
            return post;

        } // End of the GetById method

        /// <summary>
        /// Get product options by product option type id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<ProductOption>> GetByProductOptionTypeId(ClientConnection cn, Int32 productOptionTypeId, Int32 languageId)
        {
            // Create the list to return
            List<ProductOption> posts = new List<ProductOption>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/product_options/get_by_product_option_type_id/" + productOptionTypeId + "?languageId=" + languageId);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<ProductOption>>();
            }

            // Return the list
            return posts;

        } // End of the GetAll method

        /// <summary>
        /// Get all product options
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<ProductOption>> GetAll(ClientConnection cn, Int32 languageId)
        {
            // Create the list to return
            List<ProductOption> posts = new List<ProductOption>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/product_options/get_all?languageId=" + languageId.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<ProductOption>>();
            }

            // Return the list
            return posts;

        } // End of the GetAll method

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete a product option
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="productOptionTypeId">The product option type id</param>
        /// <param name="optionId">The option id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Delete(ClientConnection cn, Int32 productOptionTypeId, Int32 optionId)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/product_options/delete/" + productOptionTypeId.ToString() + "?optionId=" + optionId.ToString());

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Delete method

        #endregion

    } // End of the class

} // End of the namespace
