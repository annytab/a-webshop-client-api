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
    /// This class represent a gift card
    /// </summary>
    public class GiftCard
    {
        #region Variables

        public string id;
        public Int32 language_id;
        public string currency_code;
        public decimal amount;
        public DateTime end_date;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new gift card with default properties
        /// </summary>
        public GiftCard()
        {
            // Set values for instance variables
            this.id = "";
            this.language_id = 0;
            this.currency_code = "";
            this.amount = 0;
            this.end_date = DateTime.Now;

        } // End of the constructor

        #endregion

        #region Insert methods

        /// <summary>
        /// Add a gift card
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Add(ClientConnection cn, GiftCard post)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<GiftCard>("/api/gift_cards/add", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Add method

        #endregion

        #region Update methods

        /// <summary>
        /// Update a gift card
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Update(ClientConnection cn, GiftCard post)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<GiftCard>("/api/gift_cards/update", post);

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
            HttpResponseMessage response = await cn.GetAsync("/api/gift_cards/get_count_by_search?keywords=" + keywords);

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
        /// Get one gift card by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of the post</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<GiftCard> GetById(ClientConnection cn, string id)
        {
            // Create the post to return
            GiftCard post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/gift_cards/get_by_id/" + id);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<GiftCard>();
            }

            // Return the post
            return post;

        } // End of the GetById method

        /// <summary>
        /// Get all gift cards
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param> 
        /// <returns>A list with posts</returns>
        public async static Task<List<GiftCard>> GetAll(ClientConnection cn, string sortField, string sortOrder)
        {
            // Create the list to return
            List<GiftCard> posts = new List<GiftCard>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/gift_cards/get_all?sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<GiftCard>>();
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
        public async static Task<List<GiftCard>> GetBySearch(ClientConnection cn, string keywords, Int32 pageSize, Int32 pageNumber,
            string sortField, string sortOrder)
        {
            // Create the list to return
            List<GiftCard> posts = new List<GiftCard>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/gift_cards/get_by_search?keywords=" + keywords + "&pageSize="
                + pageSize + "&pageNumber=" + pageNumber + "&sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<GiftCard>>();
            }

            // Return the list
            return posts;

        } // End of the GetBySearch method

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete a gift card
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The id</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Delete(ClientConnection cn, string id)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/gift_cards/delete/" + id);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Delete method

        #endregion

    } // End of the class

} // End of the namespace
