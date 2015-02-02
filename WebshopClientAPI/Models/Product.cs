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
    /// This class represent a product
    /// </summary>
    public class Product
    {
        #region Variables

        public Int32 id;
        public string product_code;
        public string manufacturer_code;
        public string gtin;
        public decimal unit_price;
        public decimal unit_freight;
        public Int32 unit_id;
        public decimal mount_time_hours;
        public bool from_price;
        public Int32 category_id;
        public string brand;
        public string supplier_erp_id;
        public string meta_robots;
        public Int32 page_views;
        public decimal buys;
        public Int32 added_in_basket;
        public string condition;
        public string variant_image_filename;
        public string gender;
        public string age_group;
        public bool adult_only;
        public decimal unit_pricing_measure;
        public Int32 unit_pricing_base_measure;
        public Int32 comparison_unit_id;
        public string energy_efficiency_class;
        public bool downloadable_files;
        public DateTime date_added;
        public string title;
        public string main_content;
        public string extra_content;
        public string meta_description;
        public string meta_keywords;
        public string page_name;
        public string delivery_time;
        public string affiliate_link;
        public decimal rating;
        public decimal toll_freight_addition;
        public Int32 value_added_tax_id;
        public string account_code;
        public string google_category;
        public bool use_local_images;
        public bool use_local_files;
        public string availability_status;
        public DateTime availability_date;
        public string size_type;
        public string size_system;
        public bool inactive;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new product with default properties
        /// </summary>
        public Product()
        {
            // Set values for instance variables
            this.id = 0;
            this.product_code = "";
            this.manufacturer_code = "";
            this.gtin = "";
            this.unit_price = 0;
            this.unit_freight = 0;
            this.unit_id = 0;
            this.mount_time_hours = 0;
            this.from_price = false;
            this.category_id = 0;
            this.brand = "";
            this.supplier_erp_id = "";
            this.meta_robots = "";
            this.page_views = 0;
            this.buys = 0;
            this.added_in_basket = 0;
            this.condition = "";
            this.variant_image_filename = "";
            this.gender = "";
            this.age_group = "";
            this.adult_only = false;
            this.unit_pricing_measure = 0;
            this.unit_pricing_base_measure = 0;
            this.comparison_unit_id = 0;
            this.energy_efficiency_class = "";
            this.downloadable_files = false;
            this.date_added = DateTime.Now;
            this.title = "";
            this.main_content = "";
            this.extra_content = "";
            this.meta_description = "";
            this.meta_keywords = "";
            this.page_name = "";
            this.delivery_time = "";
            this.affiliate_link = "";
            this.rating = 0;
            this.toll_freight_addition = 0;
            this.value_added_tax_id = 0;
            this.account_code = "";
            this.google_category = "";
            this.use_local_images = false;
            this.use_local_files = false;
            this.availability_status = "";
            this.availability_date = new DateTime(2000, 1, 1);
            this.size_type = "";
            this.size_system = "";
            this.inactive = false;

        } // End of the constructor

        #endregion

        #region Insert methods

        /// <summary>
        /// Add a product
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Add(ClientConnection cn, Product post, Int32 languageId)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<Product>("/api/products/add?languageId=" + languageId.ToString(), post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Add method

        #endregion

        #region Update methods

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Update(ClientConnection cn, Product post, Int32 languageId)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<Product>("/api/products/update?languageId=" + languageId.ToString(), post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Update method method

        /// <summary>
        /// Translate a product
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Translate(ClientConnection cn, Product post, Int32 languageId)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<Product>("/api/products/translate?languageId=" + languageId.ToString(), post);

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
            HttpResponseMessage response = await cn.GetAsync("/api/products/get_count_by_search?keywords=" + keywords + "&languageId=" + languageId);

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
        /// Get one product by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<Product> GetById(ClientConnection cn, Int32 id, Int32 languageId)
        {
            // Create the post to return
            Product post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/products/get_by_id/" + id.ToString() + "?languageId=" + languageId.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<Product>();
            }

            // Return the post
            return post;

        } // End of the GetById method

        /// <summary>
        /// Get all products
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="languageId">The language id</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<Product>> GetAll(ClientConnection cn, Int32 languageId, string sortField, string sortOrder)
        {
            // Create the list to return
            List<Product> posts = new List<Product>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/products/get_all?languageId=" + languageId.ToString() + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Product>>();
            }

            // Return the list
            return posts;

        } // End of the GetAll method

        /// <summary>
        /// Get all active products
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="languageId">The language id</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param> 
        /// <returns>A list with posts</returns>
        public async static Task<List<Product>> GetAllActive(ClientConnection cn, Int32 languageId, string sortField, string sortOrder)
        {
            // Create the list to return
            List<Product> posts = new List<Product>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/products/get_all_active?languageId=" + languageId.ToString() + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Product>>();
            }

            // Return the list
            return posts;

        } // End of the GetAllActive method

        /// <summary>
        /// Get all active and unique products
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<Product>> GetAllActiveAndUnique(ClientConnection cn, Int32 languageId)
        {
            // Create the list to return
            List<Product> posts = new List<Product>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/products/get_all_active_and_unique?languageId=" + languageId.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Product>>();
            }

            // Return the list
            return posts;

        } // End of the GetAllActiveAndUnique method

        /// <summary>
        /// Get products by category id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="categoryId">The category id</param>
        /// <param name="languageId">The language id</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param> 
        /// <returns>A list with posts</returns>
        public async static Task<List<Product>> GetByCategoryId(ClientConnection cn, Int32 categoryId, Int32 languageId, string sortField, string sortOrder)
        {
            // Create the list to return
            List<Product> posts = new List<Product>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/products/get_by_category_id/" + categoryId.ToString() + "?languageId=" + languageId.ToString() + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Product>>();
            }

            // Return the list
            return posts;

        } // End of the GetByCategoryId method

        /// <summary>
        /// Get active products by category id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="categoryId">The category id</param>
        /// <param name="languageId">The language id</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param>
        /// <returns>A list with posts</returns>
        public async static Task<List<Product>> GetActiveByCategoryId(ClientConnection cn, Int32 categoryId, Int32 languageId, string sortField, string sortOrder)
        {
            // Create the list to return
            List<Product> posts = new List<Product>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/products/get_active_by_category_id/" + categoryId.ToString() + "?languageId=" + languageId.ToString() + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Product>>();
            }

            // Return the list
            return posts;

        } // End of the GetActiveByCategoryId method

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
        public async static Task<List<Product>> GetBySearch(ClientConnection cn, string keywords, Int32 languageId, Int32 pageSize, Int32 pageNumber,
            string sortField, string sortOrder)
        {
            // Create the list to return
            List<Product> posts = new List<Product>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/products/get_by_search?keywords=" + keywords + "&languageId=" + languageId + "&pageSize="
                + pageSize + "&pageNumber=" + pageNumber + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<Product>>();
            }

            // Return the list
            return posts;

        } // End of the GetBySearch method

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete a product, set the language id to 0 if you want to delete the master post and all the connected posts
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The id</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Delete(ClientConnection cn, Int32 id, Int32 languageId)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/products/delete/" + id.ToString() + "?languageId=" + languageId.ToString());

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Delete method

        /// <summary>
        /// Get product images by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of the post</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A list with image urls</returns>
        public async static Task<List<string>> GetImagesById(ClientConnection cn, Int32 id, Int32 languageId)
        {
            // Create the list to return
            List<string> posts = new List<string>(0);

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/products/get_images_by_id/" + id.ToString() + "?languageId=" + languageId.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<string>>();
            }

            // Return the post
            return posts;

        } // End of the GetImagesById method

        /// <summary>
        /// Get all product images
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="languageId">The language id</param>
        /// <returns>A dictionary with image urls</returns>
        public async static Task<Dictionary<Int32, List<string>>> GetAllImages(ClientConnection cn, Int32 languageId)
        {
            // Create the dictionary to return
            Dictionary<Int32, List<string>> posts = new Dictionary<Int32, List<string>>(0);

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/products/get_all_images?languageId=" + languageId.ToString());

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<Dictionary<Int32, List<string>>>();
            }

            // Return the dictionary
            return posts;

        } // End of the GetAllImages method

        #endregion

        #region Files

        /// <summary>
        /// Get the version date of a file
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="productId">The product id</param>
        /// <param name="languageId">The language id</param>
        /// <param name="fileName">The file name without any paths</param>
        /// <returns>A date, DateTime.MinValue if the file does not exist</returns>
        public async static Task<DateTime> GetFileVersion(ClientConnection cn, Int32 productId, Int32 languageId, string fileName)
        {
            // Create the date to return
            DateTime versionDate = DateTime.MinValue;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/products/get_file_version_date/" + productId + "?languageId=" + languageId.ToString() + "&fileName=" + fileName);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                versionDate = await response.Content.ReadAsAsync<DateTime>();
            }

            // Return the date
            return versionDate;

        } // End of the GetFileVersion method

        /// <summary>
        /// Get a file stream
        /// </summary>
        /// <param name="cn">A reference to a customer connection</param>
        /// <param name="productId">The product id</param>
        /// <param name="languageId">The language id</param>
        /// <param name="fileName">The file name without any paths</param>
        /// <returns>A stream</returns>
        public async static Task<StreamResponseMessage> GetFile(CustomerConnection cn, Int32 productId, Int32 languageId, string fileName)
        {
            // Create the response to return
            StreamResponseMessage streamResponseMessage = new StreamResponseMessage();

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/products/get_file/" + productId + "?languageId=" + languageId.ToString() + "&fileName=" + fileName);

            // Add the response message

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                // Create the response
                streamResponseMessage.stream = await response.Content.ReadAsStreamAsync();
                streamResponseMessage.result = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, "Success");

            }
            else
            {
                // Create the response
                streamResponseMessage.result = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());
            }

            // Return the stream response message
            return streamResponseMessage;

        } // End of the GetFile method

        #endregion

        #region Images

        /// <summary>
        /// Upload a main image
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The product id</param>
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
            requestMessage.RequestUri = new Uri(cn.BaseAddress + "/api/products/upload_main_image/" + id.ToString() + "?languageId=" + languageId.ToString());

            // Send the message
            HttpResponseMessage response = await cn.SendAsync(requestMessage);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the UploadMainImage method

        /// <summary>
        /// Upload other images
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="images">A list with image file paths</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> UploadOtherImages(ClientConnection cn, Int32 id, Int32 languageId, List<string> images)
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
            requestMessage.RequestUri = new Uri(cn.BaseAddress + "/api/products/upload_other_images/" + id.ToString() + "?languageId=" + languageId.ToString());

            // Send the message
            HttpResponseMessage response = await cn.SendAsync(requestMessage);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the UploadOtherImages method

        /// <summary>
        /// Delete images by id
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> DeleteImagesById(ClientConnection cn, Int32 categoryId)
        {
            // Delete the image
            HttpResponseMessage response = await cn.DeleteAsync("/api/products/delete_images_by_id/" + categoryId.ToString());

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
            HttpResponseMessage response = await cn.DeleteAsync("/api/products/delete_images_by_id_and_language/" + categoryId.ToString() + "?languageId=" + languageId.ToString());

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the DeleteImagesByIdAndLanguage method

        #endregion

    } // End of the class

} // End of the namespace
