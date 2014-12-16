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
    /// This class represent a campaign
    /// </summary>
    public class Campaign
    {
        #region Variables

        public Int32 id;
        public Int32 language_id;
        public string name;
        public string category_name;
        public string image_name;
        public string link_url;
        public bool inactive;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new campaign with default properties
        /// </summary>
        public Campaign()
        {
            // Set values for instance variables
            this.id = 0;
            this.language_id = 0;
            this.name = "";
            this.category_name = "";
            this.image_name = "";
            this.link_url = "";
            this.inactive = false;

        } // End of the constructor

        #endregion

        #region Insert methods

        /// <summary>
        /// Add a campaign
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Add(ClientConnection cn, Campaign post)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<Campaign>("/api/campaigns/add", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Add method

        #endregion

        #region Update methods

        /// <summary>
        /// Update a campaign
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Update(ClientConnection cn, Campaign post)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<Campaign>("/api/campaigns/update", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Update method

        #endregion

        #region Count methods

        /// <summary>
        /// Get the count of posts by a search
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="keywords">A string with keywords, delimited by space</param>
        /// <param name="languageId">The language id</param>
        /// <returns>The count of posts as an int</returns>
        public async static Task<Int32> GetCountBySearch(ClientConnection cn, string keywords)
        {
            // Create the integer to return
            Int32 count = 0;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/campaigns/get_count_by_search?keywords=" + keywords);

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
        /// Get one campaign by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of the post</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<Campaign> GetById(ClientConnection cn, Int32 id)
        {
            // Create the post to return
            Campaign post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/campaigns/get_by_id/" + id.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<Campaign>();
            }

            // Return the post
            return post;

        } // End of the GetById method

        /// <summary>
        /// Get all campaigns, set the language id to 0 to get all campaigns for all languages
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="languageId">The language id</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<Campaign>> GetAll(ClientConnection cn, Int32 languageId, string sortField, string sortOrder)
        {
            // Create the list to return
            List<Campaign> posts = new List<Campaign>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/campaigns/get_all?languageId=" + languageId + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Campaign>>();
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
        public async static Task<List<Campaign>> GetBySearch(ClientConnection cn, string keywords, Int32 pageSize, Int32 pageNumber,
            string sortField, string sortOrder)
        {
            // Create the list to return
            List<Campaign> posts = new List<Campaign>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/campaigns/get_by_search?keywords=" + keywords + "&pageSize="
                + pageSize + "&pageNumber=" + pageNumber + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Campaign>>();
            }

            // Return the list
            return posts;

        } // End of the GetBySearch method

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete a campaign
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Delete(ClientConnection cn, Int32 id)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/campaigns/delete/" + id.ToString());

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Delete method

        #endregion

        #region Images

        /// <summary>
        /// Upload campaign images
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="images">A list with image file paths</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> UploadImages(ClientConnection cn, List<string> images)
        {
            // Create the message and the content
            HttpRequestMessage requestMessage = new HttpRequestMessage();
            MultipartFormDataContent content = new MultipartFormDataContent();

            // Loop the list of image urls
            foreach (string file in images)
            {
                FileStream filestream = new FileStream(file, FileMode.Open);
                string fileName = System.IO.Path.GetFileName(file);
                content.Add(new StreamContent(filestream), "file", fileName);
            }

            // Set data for the message
            requestMessage.Method = HttpMethod.Post;
            requestMessage.Content = content;
            requestMessage.RequestUri = new Uri(cn.BaseAddress + "/api/campaigns/upload_images");

            // Send the message
            HttpResponseMessage response = await cn.SendAsync(requestMessage);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the UploadImages method

        /// <summary>
        /// Delete a campaign image
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="name">The image name including the extension</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> DeleteImage(ClientConnection cn, string name)
        {
            // Delete the image
            HttpResponseMessage response = await cn.DeleteAsync("/api/campaigns/delete_image?name=" + name);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the DeleteImage method

        /// <summary>
        /// Delete all images
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> DeleteAllImages(ClientConnection cn)
        {
            // Delete the image
            HttpResponseMessage response = await cn.DeleteAsync("/api/campaigns/delete_all_images");

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the DeleteAllImages method

        #endregion

    } // End of the class

} // End of the namespace
