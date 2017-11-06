using System.IO;

namespace Annytab.WebshopClientAPI
{
    /// <summary>
    /// This class consists of a stream and a response message
    /// </summary>
    public class StreamResponseMessage
    {
        #region Variables

        public Stream stream;
        public ResponseMessage result;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new stream response message with default properties
        /// </summary>
        public StreamResponseMessage()
        {
            // Set values for instance variables
            this.stream = null;
            this.result = new ResponseMessage();

        } // End of the constructor

        /// <summary>
        /// Create a new stream response message
        /// </summary>
        /// <param name="stream">A reference to a stream</param>
        /// <param name="responseMessage">The response message</param>
        public StreamResponseMessage(Stream stream, ResponseMessage responseMessage)
        {
            // Set values for instance variables
            this.stream = stream;
            this.result = responseMessage;

        } // End of the constructor

        #endregion

    } // End of the class

} // End of the namespace
