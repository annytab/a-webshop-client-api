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
    /// This class represent a image map for a category
    /// </summary>
    public class InspirationImageMap
    {
        #region Variables

        public Int32 id;
        public Int32 language_id;
        public string name;
        public string image_name;
        public string image_map_points;
        public Int32 category_id;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new image map with default properties
        /// </summary>
        public InspirationImageMap()
        {
            // Set values for instance variables
            this.id = 0;
            this.language_id = 0;
            this.name = "";
            this.image_name = "";
            this.image_map_points = "";
            this.category_id = 0;

        } // End of the constructor

        #endregion

        #region Insert methods

        /// <summary>
        /// Add a image map
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Add(ClientConnection cn, InspirationImageMap post)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<InspirationImageMap>("/api/inspiration_image_maps/add", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Add method

        #endregion

        #region Update methods

        /// <summary>
        /// Update a image map
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Update(ClientConnection cn, InspirationImageMap post)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<InspirationImageMap>("/api/inspiration_image_maps/update", post);

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
        /// <returns>The count of posts as an int</returns>
        public async static Task<Int32> GetCountBySearch(ClientConnection cn, string keywords)
        {
            // Create the integer to return
            Int32 count = 0;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/inspiration_image_maps/get_count_by_search?keywords=" + keywords);

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
        /// Get one image map by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of the post</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<InspirationImageMap> GetById(ClientConnection cn, Int32 id)
        {
            // Create the post to return
            InspirationImageMap post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/inspiration_image_maps/get_by_id/" + id.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<InspirationImageMap>();
            }

            // Return the post
            return post;

        } // End of the GetById method

        /// <summary>
        /// Get all image maps
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<InspirationImageMap>> GetAll(ClientConnection cn, string sortField, string sortOrder)
        {
            // Create the list to return
            List<InspirationImageMap> posts = new List<InspirationImageMap>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/inspiration_image_maps/get_all?sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<InspirationImageMap>>();
            }

            // Return the list
            return posts;

        } // End of the GetAll method

        /// <summary>
        /// Get image maps by category id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="categoryId">The category id</param>
        /// <param name="languageId">The id of the language</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<InspirationImageMap>> GetByCategoryId(ClientConnection cn, Int32 categoryId, Int32 languageId, string sortField, string sortOrder)
        {
            // Create the list to return
            List<InspirationImageMap> posts = new List<InspirationImageMap>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/inspiration_image_maps/get_by_category_id/" + categoryId + "?languageId=" + languageId + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<InspirationImageMap>>();
            }

            // Return the list
            return posts;

        } // End of the GetByCategoryId method

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
        public async static Task<List<InspirationImageMap>> GetBySearch(ClientConnection cn, string keywords, Int32 pageSize, Int32 pageNumber,
            string sortField, string sortOrder)
        {
            // Create the list to return
            List<InspirationImageMap> posts = new List<InspirationImageMap>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/inspiration_image_maps/get_by_search?keywords=" + keywords + "&pageSize="
                + pageSize + "&pageNumber=" + pageNumber + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<InspirationImageMap>>();
            }

            // Return the list
            return posts;

        } // End of the GetBySearch method

        /// <summary>
        /// Get the image url for a image map
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of the post</param>
        /// <returns>A image url</returns>
        public async static Task<string> GetImageById(ClientConnection cn, Int32 id)
        {
            // Create the string to return
            string url = "";

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/inspiration_image_maps/get_image_by_id/" + id.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                url = await response.Content.ReadAsAsync<string>();
            }

            // Return the post
            return url;

        } // End of the GetImagesById method

        /// <summary>
        /// Get all image urls
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <returns>A dictionary with image urls</returns>
        public async static Task<Dictionary<Int32, string>> GetAllImages(ClientConnection cn)
        {
            // Create the dictionary to return
            Dictionary<Int32, string> posts = new Dictionary<Int32, string>(0);

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/inspiration_image_maps/get_all_images");

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<Dictionary<Int32, string>>();
            }

            // Return the dictionary
            return posts;

        } // End of the GetAllImages method

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete a image map
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The id of the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Delete(ClientConnection cn, Int32 id)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/inspiration_image_maps/delete/" + id.ToString());

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Delete method

        #endregion

        #region Images

        /// <summary>
        /// Upload a inspiration image
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The id of the image map</param>
        /// <param name="imageUrl">The image url as a string</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> UploadImage(ClientConnection cn, Int32 id, string imageUrl)
        {
            // Create the message and the content
            HttpRequestMessage requestMessage = new HttpRequestMessage();
            MultipartFormDataContent content = new MultipartFormDataContent();

            // Add the file
            FileStream filestream = new FileStream(imageUrl, FileMode.Open);
            string fileName = System.IO.Path.GetFileName(imageUrl);
            content.Add(new StreamContent(filestream), "file", fileName);

            // Set data for the message
            requestMessage.Method = HttpMethod.Post;
            requestMessage.Content = content;
            requestMessage.RequestUri = new Uri(cn.BaseAddress + "/api/inspiration_image_maps/upload_image/" + id.ToString());

            // Send the message
            HttpResponseMessage response = await cn.SendAsync(requestMessage);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the UploadImage method

        /// <summary>
        /// Delete a inspiration image
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The id for the image map</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> DeleteImage(ClientConnection cn, Int32 id)
        {
            // Delete the image
            HttpResponseMessage response = await cn.DeleteAsync("/api/inspiration_image_maps/delete_image/" + id.ToString());

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the DeleteImage method

        #endregion

    } // End of the class

} // End of the namespace
