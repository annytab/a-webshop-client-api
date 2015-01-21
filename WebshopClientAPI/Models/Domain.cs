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
    /// This class represent a domain
    /// </summary>
    public class Domain
    {
        #region Variables

        public Int32 id;
        public string webshop_name;
        public string domain_name;
        public string web_address;
        public Int32 country_id;
        public Int32 front_end_language;
        public Int32 back_end_language;
        public string currency;
        public Int32 company_id;
        public byte default_display_view;
        public byte mobile_display_view;
        public Int32 custom_theme_id;
        public bool prices_includes_vat;
        public string analytics_tracking_id;
        public string facebook_app_id;
        public string facebook_app_secret;
        public string google_app_id;
        public string google_app_secret;
        public bool noindex;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new domain with default properties
        /// </summary>
        public Domain()
        {
            // Set values for instance variables
            this.id = 0;
            this.webshop_name = "";
            this.domain_name = "";
            this.web_address = "";
            this.country_id = 0;
            this.front_end_language = 0;
            this.back_end_language = 0;
            this.currency = "";
            this.company_id = 0;
            this.default_display_view = 0;
            this.mobile_display_view = 0;
            this.custom_theme_id = 0;
            this.prices_includes_vat = false;
            this.analytics_tracking_id = "";
            this.facebook_app_id = "";
            this.facebook_app_secret = "";
            this.google_app_id = "";
            this.google_app_secret = "";
            this.noindex = false;

        } // End of the constructor

        #endregion

        #region Insert methods

        /// <summary>
        /// Add a domain
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Add(ClientConnection cn, Domain post)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<Domain>("/api/domains/add", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Add method

        #endregion

        #region Update methods

        /// <summary>
        /// Update a domain
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Update(ClientConnection cn, Domain post)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<Domain>("/api/domains/update", post);

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
            HttpResponseMessage response = await cn.GetAsync("/api/domains/get_count_by_search?keywords=" + keywords);

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
        /// Get one domain by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of the post</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<Domain> GetById(ClientConnection cn, Int32 id)
        {
            // Create the post to return
            Domain post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/domains/get_by_id/" + id.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<Domain>();
            }

            // Return the post
            return post;

        } // End of the GetById method

        /// <summary>
        /// Get all domains
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<Domain>> GetAll(ClientConnection cn, string sortField, string sortOrder)
        {
            // Create the list to return
            List<Domain> posts = new List<Domain>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/domains/get_all?sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Domain>>();
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
        public async static Task<List<Domain>> GetBySearch(ClientConnection cn, string keywords, Int32 pageSize, Int32 pageNumber,
            string sortField, string sortOrder)
        {
            // Create the list to return
            List<Domain> posts = new List<Domain>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/domains/get_by_search?keywords=" + keywords + "&pageSize="
                + pageSize + "&pageNumber=" + pageNumber + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Domain>>();
            }

            // Return the list
            return posts;

        } // End of the GetBySearch method

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete a domain
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Delete(ClientConnection cn, Int32 id)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/domains/delete/" + id);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Delete method

        #endregion

    } // End of the class

} // End of the namespace
