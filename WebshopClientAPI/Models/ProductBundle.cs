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
    /// This class represent a product bundle
    /// </summary>
    public class ProductBundle
    {
        #region Variables

        public Int32 bundle_product_id;
        public Int32 product_id;
        public decimal quantity;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new product bundle with default properties
        /// </summary>
        public ProductBundle()
        {
            // Set values for instance variables
            this.bundle_product_id = 0;
            this.product_id = 0;
            this.quantity = 0;

        } // End of the constructor

        #endregion

        #region Insert methods

        /// <summary>
        /// Add a product bundle
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Add(ClientConnection cn, ProductBundle post)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<ProductBundle>("/api/product_bundles/add", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Add method

        #endregion

        #region Update methods

        /// <summary>
        /// Update a product bundle
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Update(ClientConnection cn, ProductBundle post)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<ProductBundle>("/api/product_bundles/update", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Update method method

        #endregion

        #region Get methods

        /// <summary>
        /// Get one product bundle by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="bundleProductId">The id of the bundle product</param>
        /// <param name="productId">The product id</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<ProductBundle> GetById(ClientConnection cn, Int32 bundleProductId, Int32 productId)
        {
            // Create the post to return
            ProductBundle post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/product_bundles/get_by_id/" + bundleProductId.ToString() + "?productId=" + productId.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<ProductBundle>();
            }

            // Return the post
            return post;

        } // End of the GetById method

        /// <summary>
        /// Get product bundles by product bundle id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<ProductBundle>> GetByBundleProductId(ClientConnection cn, Int32 bundleProductId)
        {
            // Create the list to return
            List<ProductBundle> posts = new List<ProductBundle>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/product_bundles/get_by_bundle_product_id/" + bundleProductId);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<ProductBundle>>();
            }

            // Return the list
            return posts;

        } // End of the GetByBundleProductId method

        /// <summary>
        /// Get all product bundles
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<ProductBundle>> GetAll(ClientConnection cn)
        {
            // Create the list to return
            List<ProductBundle> posts = new List<ProductBundle>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/product_bundles/get_all");

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<ProductBundle>>();
            }

            // Return the list
            return posts;

        } // End of the GetAll method

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete a product bundle
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="bundleProductId">The bundle product id</param>
        /// <param name="productId">The product id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Delete(ClientConnection cn, Int32 bundleProductId, Int32 productId)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/product_bundles/delete/" + bundleProductId.ToString() + "?productId=" + productId.ToString());

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Delete method

        #endregion

    } // End of the class

} // End of the namespace
