using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Annytab.WebshopClientAPI
{
    /// <summary>
    /// This class represent the customer connection to the api
    /// </summary>
    public class CustomerConnection : HttpClient
    {

        #region Constructors

        /// <summary>
        /// Create a new customer connection
        /// </summary>
        /// <param name="baseAddress">The base address to the api</param>
        /// <param name="email">The email</param>
        /// <param name="password">The password</param>
        public CustomerConnection(string baseAddress, string email, string password)
            : base()
        {
            // Add values for instance variables
            this.BaseAddress = new Uri(baseAddress);
            this.DefaultRequestHeaders.Accept.Clear();
            this.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", email, password))));

        } // End of the constructor

        #endregion

    } // End of the class

} // End of the namespace
