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
    /// This class represent a product option type
    /// </summary>
    public class ProductOptionType
    {
        #region Variables

        public Int32 id;
        public Int32 product_id;
        public Int32 option_type_id;
        public string google_name;
        public string title;
        public Int16 sort_order;
        public bool selected;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new product option type with default properties
        /// </summary>
        public ProductOptionType()
        {
            // Set values for instance variables
            this.id = 0;
            this.product_id = 0;
            this.option_type_id = 0;
            this.google_name = "";
            this.title = "";
            this.sort_order = 0;
            this.selected = false;

        } // End of the constructor

        #endregion

        #region Insert methods

        /// <summary>
        /// Add a product option type
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Add(ClientConnection cn, ProductOptionType post)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<ProductOptionType>("/api/product_option_types/add", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Add method

        #endregion

        #region Update methods

        /// <summary>
        /// Update a product option type
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Update(ClientConnection cn, ProductOptionType post)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<ProductOptionType>("/api/product_option_types/update", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Update method method

        #endregion

        #region Get methods

        /// <summary>
        /// Get one product option type by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<ProductOptionType> GetById(ClientConnection cn, Int32 id, Int32 languageId)
        {
            // Create the post to return
            ProductOptionType post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/product_option_types/get_by_id/" + id.ToString() + "?languageId=" + languageId.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<ProductOptionType>();
            }

            // Return the post
            return post;

        } // End of the GetById method

        /// <summary>
        /// Get by product id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="productId">The product id</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<ProductOptionType>> GetByProductId(ClientConnection cn, Int32 productId, Int32 languageId)
        {
            // Create the list to return
            List<ProductOptionType> posts = new List<ProductOptionType>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/product_option_types/get_by_product_id/" + productId + "?languageId=" + languageId.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<ProductOptionType>>();
            }

            // Return the list
            return posts;

        } // End of the GetByProductId method

        /// <summary>
        /// Get all product option types
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<ProductOptionType>> GetAll(ClientConnection cn, Int32 languageId)
        {
            // Create the list to return
            List<ProductOptionType> posts = new List<ProductOptionType>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/product_option_types/get_all?languageId=" + languageId.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<ProductOptionType>>();
            }

            // Return the list
            return posts;

        } // End of the GetAll method

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete a product option type
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Delete(ClientConnection cn, Int32 id)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/product_option_types/delete/" + id);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Delete method

        #endregion

    } // End of the class

} // End of the namespace
