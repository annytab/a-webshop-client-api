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
    /// This class represent an option
    /// </summary>
    public class Option
    {
        #region Variables

        public Int32 id;
        public string title;
        public string product_code_suffix;
        public Int32 sort_order;
        public Int32 option_type_id;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new option with default properties
        /// </summary>
        public Option()
        {
            // Set values for instance variables
            this.id = 0;
            this.title = "";
            this.product_code_suffix = "";
            this.sort_order = 0;
            this.option_type_id = 0;

        } // End of the constructor

        #endregion

        #region Insert methods

        /// <summary>
        /// Add an option
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Add(ClientConnection cn, Option post, Int32 languageId)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<Option>("/api/options/add?languageId=" + languageId, post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Add method

        #endregion

        #region Update methods

        /// <summary>
        /// Update an option
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Update(ClientConnection cn, Option post, Int32 languageId)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<Option>("/api/options/update?languageId=" + languageId, post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Update method method

        /// <summary>
        /// Translate an option
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Translate(ClientConnection cn, Option post, Int32 languageId)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<Option>("/api/options/translate?languageId=" + languageId, post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Translate method method

        #endregion

        #region Get methods

        /// <summary>
        /// Get one option by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<Option> GetById(ClientConnection cn, Int32 id, Int32 languageId)
        {
            // Create the post to return
            Option post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/options/get_by_id/" + id.ToString() + "?languageId=" + languageId);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<Option>();
            }

            // Return the post
            return post;

        } // End of the GetById method

        /// <summary>
        /// Get options by option type id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<Option>> GetByOptionTypeId(ClientConnection cn, Int32 id, Int32 languageId)
        {
            // Create the list to return
            List<Option> posts = new List<Option>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/options/get_by_option_type_id/" + id + "?languageId=" + languageId);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Option>>();
            }

            // Return the list
            return posts;

        } // End of the GetByOptionTypeId method

        /// <summary>
        /// Get all options
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<Option>> GetAll(ClientConnection cn, Int32 languageId)
        {
            // Create the list to return
            List<Option> posts = new List<Option>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/options/get_all?languageId=" + languageId);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Option>>();
            }

            // Return the list
            return posts;

        } // End of the GetAll method

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete an option, set the language id to 0 if you want to delete the master post and all the connected posts
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The id</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Delete(ClientConnection cn, Int32 id, Int32 languageId)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/options/delete/" + id + "?languageId=" + languageId);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Delete method

        #endregion

    } // End of the class

} // End of the namespace
