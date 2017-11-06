using System;

namespace Annytab.WebshopClientAPI
{
    /// <summary>
    /// This class represent a response message
    /// </summary>
    public class ResponseMessage
    {
        #region Variables

        public Int32 status_code;
        public bool is_success;
        public string reason_phrase;
        public string message;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new response message with default properties
        /// </summary>
        public ResponseMessage()
        {
            // Set values for instance variables
            this.status_code = 0;
            this.is_success = false;
            this.reason_phrase = "";
            this.message = "";

        } // End of the constructor

        /// <summary>
        /// Create a new response message from parameters
        /// </summary>
        /// <param name="statusCode">The status code</param>
        /// <param name="isSuccess">Is the status code successful</param>
        /// <param name="reasonPhrase">The reason</param>
        /// <param name="message">The message</param>
        public ResponseMessage(Int32 statusCode, bool isSuccess, string reasonPhrase, string message)
        {
            // Set values for instance variables
            this.status_code = statusCode;
            this.is_success = isSuccess;
            this.reason_phrase = reasonPhrase;
            this.message = message.Length > 0 ? message : "No message";

        } // End of the constructor

        #endregion

    } // End of the class

} // End of the namespace
