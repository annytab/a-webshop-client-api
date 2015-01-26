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
    /// This class represent a static page
    /// </summary>
    public class StaticPage
    {
        #region Variables

        public Int32 id;
        public byte connected_to_page;
        public string meta_robots;
        public string link_name;
        public string title;
        public string main_content;
        public string meta_description;
        public string meta_keywords;
        public string page_name;
        public bool inactive;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new static page post with default properties
        /// </summary>
        public StaticPage()
        {
            // Set values for instance variables
            this.id = 0;
            this.connected_to_page = 0;
            this.meta_robots = "";
            this.link_name = "";
            this.title = "";
            this.main_content = "";
            this.meta_description = "";
            this.meta_keywords = "";
            this.page_name = "";
            this.inactive = false;

        } // End of the constructor

        #endregion

        #region Insert methods

        /// <summary>
        /// Add a static page
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Add(ClientConnection cn, StaticPage post, Int32 languageId)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<StaticPage>("/api/static_pages/add?languageId=" + languageId, post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Add method

        #endregion

        #region Update methods

        /// <summary>
        /// Update a static page
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Update(ClientConnection cn, StaticPage post, Int32 languageId)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<StaticPage>("/api/static_pages/update?languageId=" + languageId, post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Update method method

        /// <summary>
        /// Translate a static page
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Translate(ClientConnection cn, StaticPage post, Int32 languageId)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<StaticPage>("/api/static_pages/translate?languageId=" + languageId, post);

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
            HttpResponseMessage response = await cn.GetAsync("/api/static_pages/get_count_by_search?keywords=" + keywords + "&languageId=" + languageId);

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
        /// Get one static page by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<StaticPage> GetById(ClientConnection cn, Int32 id, Int32 languageId)
        {
            // Create the post to return
            StaticPage post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/static_pages/get_by_id/" + id.ToString() + "?languageId=" + languageId);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<StaticPage>();
            }

            // Return the post
            return post;

        } // End of the GetById method

        /// <summary>
        /// Get all static pages
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="languageId">The language id</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param> 
        /// <returns>A list with posts</returns>
        public async static Task<List<StaticPage>> GetAll(ClientConnection cn, Int32 languageId, string sortField, string sortOrder)
        {
            // Create the list to return
            List<StaticPage> posts = new List<StaticPage>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/static_pages/get_all?languageId=" + languageId + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<StaticPage>>();
            }

            // Return the list
            return posts;

        } // End of the GetAll method

        /// <summary>
        /// Get all active static pages
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="languageId">The language id</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param> 
        /// <returns>A list with posts</returns>
        public async static Task<List<StaticPage>> GetAllActive(ClientConnection cn, Int32 languageId, string sortField, string sortOrder)
        {
            // Create the list to return
            List<StaticPage> posts = new List<StaticPage>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/static_pages/get_all_active?languageId=" + languageId + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<StaticPage>>();
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
        public async static Task<List<StaticPage>> GetBySearch(ClientConnection cn, string keywords, Int32 languageId, Int32 pageSize, Int32 pageNumber,
            string sortField, string sortOrder)
        {
            // Create the list to return
            List<StaticPage> posts = new List<StaticPage>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/static_pages/get_by_search?keywords=" + keywords + "&languageId=" + languageId + "&pageSize="
                + pageSize + "&pageNumber=" + pageNumber + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<StaticPage>>();
            }

            // Return the list
            return posts;

        } // End of the GetBySearch method

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete a static page, set the language id to 0 if you want to delete the master post and all the connected posts
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The id</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Delete(ClientConnection cn, Int32 id, Int32 languageId)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/static_pages/delete/" + id + "?languageId=" + languageId);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Delete method

        #endregion

    } // End of the class

} // End of the namespace
