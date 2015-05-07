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
    /// This class represent a order gift card
    /// </summary>
    public class OrderGiftCard
    {
        #region Variables

        public Int32 order_id;
        public string gift_card_id;
        public decimal amount;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new order gift card with default properties
        /// </summary>
        public OrderGiftCard()
        {
            // Set values for instance variables
            this.order_id = 0;
            this.gift_card_id = "";
            this.amount = 0;

        } // End of the constructor

        #endregion

        #region Insert methods

        /// <summary>
        /// Add a order gift card
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Add(ClientConnection cn, OrderGiftCard post)
        {
            // Add the post
            HttpResponseMessage response = await cn.PostAsJsonAsync<OrderGiftCard>("/api/orders_gift_cards/add", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Add method

        #endregion

        #region Update methods

        /// <summary>
        /// Update a order gift card
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="post">A reference to the post</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Update(ClientConnection cn, OrderGiftCard post)
        {
            // Update the post
            HttpResponseMessage response = await cn.PutAsJsonAsync<OrderGiftCard>("/api/orders_gift_cards/update", post);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Update method method

        #endregion

        #region Get methods

        /// <summary>
        /// Get one order gift card by id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of an order</param>
        /// <param name="giftCardId">The id of a gift card</param>
        /// <returns>A reference to a post, null if nothing is found</returns>
        public async static Task<OrderGiftCard> GetById(ClientConnection cn, Int32 id, string giftCardId)
        {
            // Create the post to return
            OrderGiftCard post = null;

            // Get the post
            HttpResponseMessage response = await cn.GetAsync("/api/orders_gift_cards/get_by_id/" + id.ToString() + "?giftCardId=" + giftCardId);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<OrderGiftCard>();
            }

            // Return the post
            return post;

        } // End of the GetById method

        /// <summary>
        /// Get order gift cards by order id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of an order</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param> 
        /// <returns>A list with posts</returns>
        public async static Task<List<OrderGiftCard>> GetByOrderId(ClientConnection cn, Int32 id, string sortField, string sortOrder)
        {
            // Create the list to return
            List<OrderGiftCard> posts = new List<OrderGiftCard>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/orders_gift_cards/get_by_order_id/" + id.ToString() + "?sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<OrderGiftCard>>();
            }

            // Return the list
            return posts;

        } // End of the GetByOrderId method

        /// <summary>
        /// Get order gift cards by gift card id
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="id">The id of a gift card</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param> 
        /// <returns>A list with posts</returns>
        public async static Task<List<OrderGiftCard>> GetByGiftCardId(ClientConnection cn, string id, string sortField, string sortOrder)
        {
            // Create the list to return
            List<OrderGiftCard> posts = new List<OrderGiftCard>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/orders_gift_cards/get_by_gift_card_id/" + id + "?sortField=" + sortField + "&sortOrder=" + sortOrder);

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<OrderGiftCard>>();
            }

            // Return the list
            return posts;

        } // End of the GetByGiftCardId method

        /// <summary>
        /// Get all order gift cards
        /// </summary>
        /// <param name="cn">A reference to a client connection</param>
        /// <param name="sortField">The field to sort on</param>
        /// <param name="sortOrder">The sort order, ASC or DESC</param> 
        /// <returns>A list with posts</returns>
        public async static Task<List<OrderGiftCard>> GetAll(ClientConnection cn)
        {
            // Create the list to return
            List<OrderGiftCard> posts = new List<OrderGiftCard>();

            // Get all posts
            HttpResponseMessage response = await cn.GetAsync("/api/orders_gift_cards/get_all");

            // Make sure that the response is successful
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<List<OrderGiftCard>>();
            }

            // Return the list
            return posts;

        } // End of the GetAll method

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete a order gift card
        /// </summary>
        /// <param name="cn">A reference to the client connection</param>
        /// <param name="id">The id of an order</param>
        /// <param name="giftCardId">The id of a gift card</param>
        /// <returns>A response message</returns>
        public async static Task<ResponseMessage> Delete(ClientConnection cn, Int32 id, string giftCardId)
        {
            // Delete the post
            HttpResponseMessage response = await cn.DeleteAsync("/api/orders_gift_cards/delete/" + id.ToString() + "?giftCardId=" + giftCardId);

            // Create the response message
            ResponseMessage message = new ResponseMessage((Int32)response.StatusCode, response.IsSuccessStatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());

            // Return the response message
            return message;

        } // End of the Delete method

        #endregion

    } // End of the class

} // End of the namespace
