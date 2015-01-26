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
    /// This class represent a category
    /// </summary>
    public class Category
    {
        #region Variables

        public Int32 id;
        public Int32 parent_category_id;
        public string meta_robots;
        public DateTime date_added;
        public Int32 page_views;
        public string title;
        public string main_content;
        public string meta_description;
        public string meta_keywords;
        public string page_name;
        public bool use_local_images;
        public bool inactive;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new category with default properties
        /// </summary>
        public Category()
        {
            // Set values for instance variables
            this.id = 0;
            this.parent_category_id = 0;
            this.meta_robots = "";
            this.date_added = DateTime.Now;
            this.page_views = 0;
            this.title = "";
            this.main_content = "";
            this.meta_description = "";
            this.meta_keywords = "";
            this.page_name = "";
            this.use_local_images = false;
            this.inactive = false;

        } // End of the constructor

        #endregion

        #region Insert methods

        /// <summary>
        /// Add a category
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Add(ClientConnection cn, Category post, Int32 languageId)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<Category>("/api/categories/add?languageId=" + languageId.ToString(), post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Add method

        #endregion

        #region Update methods

        /// <summary>
        /// Update a category
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Update(ClientConnection cn, Category post, Int32 languageId)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<Category>("/api/categories/update?languageId=" + languageId.ToString(), post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Update method

        /// <summary>
        /// Translate a category
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Translate(ClientConnection cn, Category post, Int32 languageId)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<Category>("/api/categories/translate?languageId=" + languageId.ToString(), post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Translate method

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
            HttpResponseMessage response = await cn.GetAsync("/api/categories/get_count_by_search?keywords=" + keywords + "&languageId=" + languageId);

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
        /// Get one category by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<Category> GetById(ClientConnection cn, Int32 id, Int32 languageId)
        {
            // Create the post to return
            Category post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/categories/get_by_id/" + id.ToString() + "?languageId=" + languageId.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<Category>();
            }

            // Return the post
            return post;

        } // End of the GetById method

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="languageId">The language id</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param> 
        /// <returns>A list with posts</returns>
        public async static Task<List<Category>> GetAll(ClientConnection cn, Int32 languageId, string sortField, string sortOrder)
        {
            // Create the list to return
            List<Category> posts = new List<Category>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/categories/get_all?languageId=" + languageId.ToString() + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Category>>();
            }

            // Return the list
            return posts;

        } // End of the GetAll method

        /// <summary>
        /// Get all active categories
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="languageId">The language id</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<Category>> GetAllActive(ClientConnection cn, Int32 languageId, string sortField, string sortOrder)
        {
            // Create the list to return
            List<Category> posts = new List<Category>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/categories/get_all_active?languageId=" + languageId.ToString() + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Category>>();
            }

            // Return the list
            return posts;

        } // End of the GetAllActive method

        /// <summary>
        /// Get child categories for the category
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="parentId">The parent category id</param>
        /// <param name="languageId">The language id</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<Category>> GetChildCategories(ClientConnection cn, Int32 parentId, Int32 languageId, string sortField, string sortOrder)
        {
            // Create the list to return
            List<Category> posts = new List<Category>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/categories/get_child_categories/" + parentId.ToString() + "?languageId=" + languageId.ToString() + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Category>>();
            }

            // Return the list
            return posts;

        } // End of the GetChildCategories method

        /// <summary>
        /// Get active child categories for the category
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="parentId">The parent category id</param>
        /// <param name="languageId">The language id</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<Category>> GetActiveChildCategories(ClientConnection cn, Int32 parentId, Int32 languageId, string sortField, string sortOrder)
        {
            // Create the list to return
            List<Category> posts = new List<Category>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/categories/get_active_child_categories/" + parentId.ToString() + "?languageId=" + languageId.ToString() + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Category>>();
            }

            // Return the list
            return posts;

        } // End of the GetActiveChildCategories method

        /// <summary>
        /// Get category images by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<List<string>> GetImagesById(ClientConnection cn, Int32 id, Int32 languageId)
        {
            // Create the list to return
            List<string> posts = new List<string>(0);

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/categories/get_images_by_id/" + id.ToString() + "?languageId=" + languageId.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<string>>();
            }

            // Return the post
            return posts;

        } // End of the GetImagesById method

        /// <summary>
        /// Get all category images
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A dictionary with image urls</returns>
        public async static Task<Dictionary<Int32, List<string>>> GetAllImages(ClientConnection cn, Int32 languageId)
        {
            // Create the dictionary to return
            Dictionary<Int32, List<string>> posts = new Dictionary<Int32, List<string>>(0);

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/categories/get_all_images?languageId=" + languageId.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<Dictionary<Int32, List<string>>>();
            }

            // Return the dictionary
            return posts;

        } // End of the GetAllImages method

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
        public async static Task<List<Category>> GetBySearch(ClientConnection cn, string keywords, Int32 languageId, Int32 pageSize, Int32 pageNumber,
            string sortField, string sortOrder)
        {
            // Create the list to return
            List<Category> posts = new List<Category>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/categories/get_by_search?keywords=" + keywords + "&languageId=" + languageId + "&pageSize="
                + pageSize + "&pageNumber=" + pageNumber + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Category>>();
            }

            // Return the list
            return posts;

        } // End of the GetBySearch method

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete a category, set the language id to 0 if you want to delete the master post and all the connected posts
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The id</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Delete(ClientConnection cn, Int32 id, Int32 languageId)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/categories/delete/" + id.ToString() + "?languageId=" + languageId.ToString());

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Delete method

        #endregion

        #region Images

        /// <summary>
        /// Upload a main image
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The category id</param>
        /// <param name="languageId">The language id, 0 for global images</param>
        /// <param name="imageUrl">The image url as a string</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> UploadMainImage(ClientConnection cn, Int32 id, Int32 languageId, string imageUrl)
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
            requestMessage.RequestUri = new Uri(cn.BaseAddress + "/api/categories/upload_main_image/" + id.ToString() + "?languageId=" + languageId.ToString());

            // Send the message
            HttpResponseMessage response = await cn.SendAsync(requestMessage);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the UploadMainImage method

        /// <summary>
        /// Upload environment images
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="images">A list with image file paths</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> UploadEnvironmentImages(ClientConnection cn, Int32 id, Int32 languageId, List<string> images)
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
            requestMessage.RequestUri = new Uri(cn.BaseAddress + "/api/categories/upload_environment_images/" + id.ToString() + "?languageId=" + languageId.ToString());

            // Send the message
            HttpResponseMessage response = await cn.SendAsync(requestMessage);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the UploadEnvironmentImages method

        /// <summary>
        /// Delete images by id
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> DeleteImagesById(ClientConnection cn, Int32 categoryId)
        {
            // Delete the image
            HttpResponseMessage response = await cn.DeleteAsync("/api/categories/delete_images_by_id/" + categoryId.ToString());

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the DeleteImagesById method

        /// <summary>
        /// Delete images by id and language
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> DeleteImagesByIdAndLanguage(ClientConnection cn, Int32 categoryId, Int32 languageId)
        {
            // Delete the image
            HttpResponseMessage response = await cn.DeleteAsync("/api/categories/delete_images_by_id_and_language/" + categoryId.ToString() + "?languageId=" + languageId.ToString());

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the DeleteImagesByIdAndLanguage method

        #endregion

    } // End of the class

} // End of the namespace
