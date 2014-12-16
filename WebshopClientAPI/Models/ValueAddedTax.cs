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
    /// This class represent a value added tax
    /// </summary>
    public class ValueAddedTax
    {
        #region Variables

        public Int32 id;
        public decimal value;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new value added tax with default properties
        /// </summary>
        public ValueAddedTax()
        {
            // Set values for instance variables
            this.id = 0;
            this.value = 0.00M;

        } // End of the constructor

        #endregion

        #region Insert methods

        /// <summary>
        /// Add a value added tax
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Add(ClientConnection cn, ValueAddedTax post)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<ValueAddedTax>("/api/value_added_taxes/add", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Add method

        #endregion

        #region Update methods

        /// <summary>
        /// Update a value added tax
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Update(ClientConnection cn, ValueAddedTax post)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<ValueAddedTax>("/api/value_added_taxes/update", post);

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
            HttpResponseMessage response = await cn.GetAsync("/api/value_added_taxes/get_count_by_search?keywords=" + keywords);

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
        /// Get one value added tax by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of the post</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<ValueAddedTax> GetById(ClientConnection cn, Int32 id)
        {
            // Create the post to return
            ValueAddedTax post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/value_added_taxes/get_by_id/" + id.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<ValueAddedTax>();
            }

            // Return the post
            return post;

        } // End of the GetById method

        /// <summary>
        /// Get all value added taxes
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<ValueAddedTax>> GetAll(ClientConnection cn, string sortField, string sortOrder)
        {
            // Create the list to return
            List<ValueAddedTax> posts = new List<ValueAddedTax>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/value_added_taxes/get_all?sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<ValueAddedTax>>();
            }

            // Return the list
            return posts;

        } // End of the GetAll method

        /// <summary>
        /// Get all value added taxes as a dictionary
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A dictionary with posts</returns>
        public async static Task<Dictionary<Int32, ValueAddedTax>> GetAllAsDictionary(ClientConnection cn, string sortField, string sortOrder)
        {
            // Create the list to return
            Dictionary<Int32, ValueAddedTax> posts = new Dictionary<Int32, ValueAddedTax>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/value_added_taxes/get_all_as_dictionary?sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<Dictionary<Int32, ValueAddedTax>>();
            }

            // Return the list
            return posts;

        } // End of the GetAllAsDictionary method

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
        public async static Task<List<ValueAddedTax>> GetBySearch(ClientConnection cn, string keywords, Int32 pageSize, Int32 pageNumber,
            string sortField, string sortOrder)
        {
            // Create the list to return
            List<ValueAddedTax> posts = new List<ValueAddedTax>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/value_added_taxes/get_by_search?keywords=" + keywords + "&pageSize="
                + pageSize + "&pageNumber=" + pageNumber + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<ValueAddedTax>>();
            }

            // Return the list
            return posts;

        } // End of the GetBySearch method

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete a value added tax
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Delete(ClientConnection cn, Int32 id)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/value_added_taxes/delete/" + id);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Delete method

        #endregion

    } // End of the class

} // End of the namespace
