using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Annytab.WebshopClientAPI
{
    /// <summary>
    /// This class represent a product accessory
    /// </summary>
    public class ProductAccessory
    {
        #region Variables

        public Int32 product_id;
        public Int32 accessory_id;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new product accessory with default properties
        /// </summary>
        public ProductAccessory()
        {
            // Set values for instance variables
            this.product_id = 0;
            this.accessory_id = 0;

        } // End of the constructor

        #endregion

        #region Insert methods

        /// <summary>
        /// Add a product accessory
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Add(ClientConnection cn, ProductAccessory post)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<ProductAccessory>("/api/product_accessories/add", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Add method

        #endregion

        #region Get methods

        /// <summary>
        /// Get one product accessory by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="productId">The id of the product</param>
        /// <param name="accessoryId">The id of the accessory product</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<ProductAccessory> GetById(ClientConnection cn, Int32 productId, Int32 accessoryId)
        {
            // Create the post to return
            ProductAccessory post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/product_accessories/get_by_id/" + productId.ToString() + "?accessoryId=" + accessoryId.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<ProductAccessory>();
            }

            // Return the post
            return post;

        } // End of the GetById method

        /// <summary>
        /// Get all accessories as products for a product id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="productId">The product id</param>
        /// <param name="languageId">The language id</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param> 
        /// <returns>A list with posts</returns>
        public async static Task<List<Product>> GetByProductId(ClientConnection cn, Int32 productId, Int32 languageId, string sortField, string sortOrder)
        {
            // Create the list to return
            List<Product> posts = new List<Product>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/product_accessories/get_by_product_id/" + productId.ToString() + "?languageId=" + languageId.ToString() + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Product>>();
            }

            // Return the list
            return posts;

        } // End of the GetByProductId method

        /// <summary>
        /// Get all product accessories
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<ProductAccessory>> GetAll(ClientConnection cn)
        {
            // Create the list to return
            List<ProductAccessory> posts = new List<ProductAccessory>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/product_accessories/get_all");

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<ProductAccessory>>();
            }

            // Return the list
            return posts;

        } // End of the GetAll method

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete a product accessory
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="productId">The product id</param>
        /// <param name="accessoryId">The accessory id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Delete(ClientConnection cn, Int32 productId, Int32 accessoryId)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/product_accessories/delete/" + productId.ToString() + "?accessoryId=" + accessoryId.ToString());

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Delete method

        #endregion

    } // End of the class

} // End of the namespace
