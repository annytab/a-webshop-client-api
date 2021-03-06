﻿using System;
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
    /// This class represent a additional service
    /// </summary>
    public class AdditionalService
    {
        #region Variables

        public Int32 id;
        public string product_code;
        public string name;
        public decimal fee;
        public Int32 unit_id;
        public bool price_based_on_mount_time;
        public Int32 value_added_tax_id;
        public string account_code;
        public bool inactive;
        public bool selected;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new additional service with default properties
        /// </summary>
        public AdditionalService()
        {
            // Set values for instance variables
            this.id = 0;
            this.product_code = "";
            this.name = "";
            this.fee = 0.00M;
            this.unit_id = 0;
            this.price_based_on_mount_time = false;
            this.value_added_tax_id = 0;
            this.account_code = "";
            this.inactive = false;
            this.selected = false;

        } // End of the constructor

        #endregion

        #region Insert methods

        /// <summary>
        /// Add a additional service
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Add(ClientConnection cn, AdditionalService post, Int32 languageId)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<AdditionalService>("/api/additional_services/add?languageId=" + languageId, post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Add method

        #endregion

        #region Update methods

        /// <summary>
        /// Update a additional service
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Update(ClientConnection cn, AdditionalService post, Int32 languageId)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<AdditionalService>("/api/additional_services/update?languageId=" + languageId, post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Update method method

        /// <summary>
        /// Translate a additional service
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Translate(ClientConnection cn, AdditionalService post, Int32 languageId)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<AdditionalService>("/api/additional_services/translate?languageId=" + languageId, post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Translate method method

        #endregion

        #region Count methods

        /// <summary>
        /// Get the count of posts by a search
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="keywords">A string with keywords, delimited by space</param>
        /// <param name="languageId">The language id</param>
        /// <returns>The count of posts as an int</returns>
        public async static Task<Int32> GetCountBySearch(ClientConnection cn, string keywords, Int32 languageId)
        {
            // Create the integer to return
            Int32 count = 0;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/additional_services/get_count_by_search?keywords=" + keywords + "&languageId=" + languageId);

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
        /// Get one additional service by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<AdditionalService> GetById(ClientConnection cn, Int32 id, Int32 languageId)
        {
            // Create the post to return
            AdditionalService post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/additional_services/get_by_id/" + id.ToString() + "?languageId=" + languageId);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<AdditionalService>();
            }

            // Return the post
            return post;

        } // End of the GetById method

        /// <summary>
        /// Get all additional services
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="languageId">The language id</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<AdditionalService>> GetAll(ClientConnection cn, Int32 languageId, string sortField, string sortOrder)
        {
            // Create the list to return
            List<AdditionalService> posts = new List<AdditionalService>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/additional_services/get_all?languageId=" + languageId + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<AdditionalService>>();
            }

            // Return the list
            return posts;

        } // End of the GetAll method

        /// <summary>
        /// Get all active additional services
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="languageId">The language id</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<AdditionalService>> GetAllActive(ClientConnection cn, Int32 languageId, string sortField, string sortOrder)
        {
            // Create the list to return
            List<AdditionalService> posts = new List<AdditionalService>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/additional_services/get_all_active?languageId=" + languageId + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<AdditionalService>>();
            }

            // Return the list
            return posts;

        } // End of the GetAllActive method

        /// <summary>
        /// Get posts by a search
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="keywords">A string of keywords, delimited by space</param>
        /// <param name="languageId">The language id</param>
        /// <param name="pageSize">The number of posts to get on one page</param>
        /// <param name="pageNumber">The page number</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<AdditionalService>> GetBySearch(ClientConnection cn, string keywords, Int32 languageId, Int32 pageSize, Int32 pageNumber, 
            string sortField, string sortOrder)
        {
            // Create the list to return
            List<AdditionalService> posts = new List<AdditionalService>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/additional_services/get_by_search?keywords=" + keywords + "&languageId=" + languageId + "&pageSize=" 
                + pageSize + "&pageNumber=" + pageNumber + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<AdditionalService>>();
            }

            // Return the list
            return posts;

        } // End of the GetBySearch method

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete a additional service, set the language id to 0 if you want to delete the master post and all the connected posts
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The id</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Delete(ClientConnection cn, Int32 id, Int32 languageId)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/additional_services/delete/" + id + "?languageId=" + languageId);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Delete method

        #endregion

    } // End of the class

} // End of the namespace
