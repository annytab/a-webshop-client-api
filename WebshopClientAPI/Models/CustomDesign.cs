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
    /// This static class handles custom design operations
    /// </summary>
    public static class CustomDesign
    {
        #region Insert methods

        /// <summary>
        /// Add a custom theme
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> AddTheme(ClientConnection cn, CustomTheme post)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<CustomTheme>("/api/custom_design/add_theme", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the AddTheme method

        /// <summary>
        /// Add a custom template
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> AddTemplate(ClientConnection cn, CustomThemeTemplate post)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<CustomThemeTemplate>("/api/custom_design/add_template", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the AddTemplate method

        #endregion

        #region Update methods

        /// <summary>
        /// Update a custom theme
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> UpdateTheme(ClientConnection cn, CustomTheme post)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<CustomTheme>("/api/custom_design/update_theme", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the UpdateTheme method

        /// <summary>
        /// Update a custom template
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> UpdateTemplate(ClientConnection cn, CustomThemeTemplate post)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<CustomThemeTemplate>("/api/custom_design/update_template", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the UpdateTemplate method

        #endregion

        #region Count methods

        /// <summary>
        /// Get the count of posts by a search
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="keywords">A string with keywords, delimited by space</param>
        /// <returns>The count of posts as an int</returns>
        public async static Task<Int32> GetThemeCountBySearch(ClientConnection cn, string keywords)
        {
            // Create the integer to return
            Int32 count = 0;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/custom_design/get_theme_count_by_search?keywords=" + keywords);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                count = await response.Content.ReadAsAsync<Int32>();
            }

            // Return the count
            return count;

        } // End of the GetThemeCountBySearch method

        #endregion

        #region Get methods

        /// <summary>
        /// Get one custom theme by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of the post</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<CustomTheme> GetThemeById(ClientConnection cn, Int32 id)
        {
            // Create the post to return
            CustomTheme post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/custom_design/get_theme_by_id/" + id.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<CustomTheme>();
            }

            // Return the post
            return post;

        } // End of the GetThemeById method

        /// <summary>
        /// Get one custom template by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of the post</param>
        /// <param name="userFileName">The file name</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<CustomThemeTemplate> GetTemplateById(ClientConnection cn, Int32 id, string userFileName)
        {
            // Create the post to return
            CustomThemeTemplate post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/custom_design/get_template_by_id/" + id.ToString() + "?userFileName=" + userFileName);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<CustomThemeTemplate>();
            }

            // Return the post
            return post;

        } // End of the GetTemplateById method

        /// <summary>
        /// Get all custom themes
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<CustomTheme>> GetAllThemes(ClientConnection cn, string sortField, string sortOrder)
        {
            // Create the list to return
            List<CustomTheme> posts = new List<CustomTheme>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/custom_design/get_all_themes?sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<CustomTheme>>();
            }

            // Return the list
            return posts;

        } // End of the GetAllThemes method

        /// <summary>
        /// Get all custom templates by theme id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<CustomThemeTemplate>> GetTemplatesByThemeId(ClientConnection cn, Int32 id, string sortField, string sortOrder)
        {
            // Create the list to return
            List<CustomThemeTemplate> posts = new List<CustomThemeTemplate>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/custom_design/get_templates_by_theme_id/" + id.ToString() + "?sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<CustomThemeTemplate>>();
            }

            // Return the list
            return posts;

        } // End of the GetTemplatesByThemeId method

        /// <summary>
        /// Get all custom templates
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param> 
        /// <returns>A list with posts</returns>
        public async static Task<List<CustomThemeTemplate>> GetAllTemplates(ClientConnection cn, string sortField, string sortOrder)
        {
            // Create the list to return
            List<CustomThemeTemplate> posts = new List<CustomThemeTemplate>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/custom_design/get_all_templates?sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<CustomThemeTemplate>>();
            }

            // Return the list
            return posts;

        } // End of the GetAllTemplates method

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
        public async static Task<List<CustomTheme>> GetThemesBySearch(ClientConnection cn, string keywords, Int32 pageSize, Int32 pageNumber,
            string sortField, string sortOrder)
        {
            // Create the list to return
            List<CustomTheme> posts = new List<CustomTheme>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/custom_design/get_themes_by_search?keywords=" + keywords + "&pageSize="
                + pageSize + "&pageNumber=" + pageNumber + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<CustomTheme>>();
            }

            // Return the list
            return posts;

        } // End of the GetThemesBySearch method

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete a custom theme
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> DeleteTheme(ClientConnection cn, Int32 id)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/custom_design/delete_theme/" + id);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the DeleteTheme method

        /// <summary>
        /// Delete a custom template
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The id</param>
        /// <param name="userFileName">The file name</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> DeleteTemplate(ClientConnection cn, Int32 id, string userFileName)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/custom_design/delete_template/" + id.ToString() + "?userFileName=" + userFileName);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the DeleteTemplate method

        #endregion

        #region Custom images and files

        /// <summary>
        /// Upload custom images
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
            requestMessage.RequestUri = new Uri(cn.BaseAddress + "/api/custom_design/upload_images");

            // Send the message
            HttpResponseMessage response = await cn.SendAsync(requestMessage);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the UploadImages method method

        /// <summary>
        /// Upload custom files
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="files">A list with file paths</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> UploadFiles(ClientConnection cn, List<string> files)
        {
            // Create the message and the content
            HttpRequestMessage requestMessage = new HttpRequestMessage();
            MultipartFormDataContent content = new MultipartFormDataContent();

            // Loop the list of image urls
            foreach (string file in files)
            {
                FileStream filestream = new FileStream(file, FileMode.Open);
                string fileName = System.IO.Path.GetFileName(file);
                content.Add(new StreamContent(filestream), "file", fileName);
            }

            // Set data for the message
            requestMessage.Method = HttpMethod.Post;
            requestMessage.Content = content;
            requestMessage.RequestUri = new Uri(cn.BaseAddress + "/api/custom_design/upload_files");

            // Send the message
            HttpResponseMessage response = await cn.SendAsync(requestMessage);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the UploadFiles method method

        /// <summary>
        /// Delete a custom image
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="name">The image name including the extension</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> DeleteImage(ClientConnection cn, string name)
        {
            // Delete the image
            HttpResponseMessage response = await cn.DeleteAsync("/api/custom_design/delete_image?name=" + name);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the DeleteImage method

        /// <summary>
        /// Delete a custom file
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="name">The file name including the extension</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> DeleteFile(ClientConnection cn, string name)
        {
            // Delete the image
            HttpResponseMessage response = await cn.DeleteAsync("/api/custom_design/delete_file?name=" + name);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the DeleteFile method

        /// <summary>
        /// Delete all images
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> DeleteAllImages(ClientConnection cn)
        {
            // Delete the image
            HttpResponseMessage response = await cn.DeleteAsync("/api/custom_design/delete_all_images");

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the DeleteAllImages method

        /// <summary>
        /// Delete all files
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> DeleteAllFiles(ClientConnection cn)
        {
            // Delete the image
            HttpResponseMessage response = await cn.DeleteAsync("/api/custom_design/delete_all_files");

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the DeleteAllFiles method

        #endregion

    } // End of the class

} // End of the namespace
