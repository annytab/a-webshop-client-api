using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Annytab.WebshopClientAPI
{
    /// <summary>
    /// This class represent the connection to the api
    /// </summary>
    public class ClientConnection : HttpClient
    {

        #region Constructors

        /// <summary>
        /// Create a new client connection
        /// </summary>
        /// <param name="baseAddress">The base address to the api</param>
        /// <param name="userName">The user name</param>
        /// <param name="password">The password</param>
        public ClientConnection(string baseAddress, string userName, string password)
            : base()
        {
            // Add values for instance variables
            this.BaseAddress = new Uri(baseAddress);
            this.DefaultRequestHeaders.Accept.Clear();
            this.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", userName, password))));
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        } // End of the constructor

        #endregion

    } // End of the class

} // End of the namespace
