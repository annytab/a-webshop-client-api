using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Annytab.WebshopClientAPI;
using System.Net.Http;

namespace ApiTestProgram
{
    [TestClass]
    public class CustomDesignTest
    {
        [TestMethod]
        public async Task TestAddTheme()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            CustomTheme theme = new CustomTheme();
            theme.id = 0;
            theme.name = "Theme name";

            // Add the post
            ResponseMessage response = await CustomDesign.AddTheme(connection, theme);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestAddTheme method

        [TestMethod]
        public async Task TestAddTemplate()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            CustomThemeTemplate template = new CustomThemeTemplate();
            template.custom_theme_id = 6;
            template.user_file_name = "user file name";
            template.master_file_url = " master file name";
            template.user_file_content = "user file content";
            template.comment = "comment";

            // Add the post
            ResponseMessage response = await CustomDesign.AddTemplate(connection, template);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestAddTemplate method

        [TestMethod]
        public async Task TestUpdateTheme()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            CustomTheme theme = new CustomTheme();
            theme.id = 6;
            theme.name = "Theme name UPP";

            // Add the post
            ResponseMessage response = await CustomDesign.UpdateTheme(connection, theme);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestUpdateTheme method

        [TestMethod]
        public async Task TestUpdateTemplate()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            CustomThemeTemplate template = new CustomThemeTemplate();
            template.custom_theme_id = 6;
            template.user_file_name = "user file name";
            template.master_file_url = " master file name UPP";
            template.user_file_content = "user file content UPP";
            template.comment = "comment UPP";

            // Add the post
            ResponseMessage response = await CustomDesign.UpdateTemplate(connection, template);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestUpdateTemplate method

        [TestMethod]
        public async Task TestGetThemeById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            CustomTheme post = await CustomDesign.GetThemeById(connection, 5);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(null, post);

        } // End of the TestGetThemeById method

        [TestMethod]
        public async Task TestGetTemplateById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            CustomThemeTemplate post = await CustomDesign.GetTemplateById(connection, 5, "standard_layout.cshtml");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(null, post);

        } // End of the TestGetTemplateById method

        [TestMethod]
        public async Task TestGetThemeCountBySearch()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get the count
            Int32 count = await CustomDesign.GetThemeCountBySearch(connection, "");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, count);

        } // End of the TestGetThemeCountBySearch method

        [TestMethod]
        public async Task TestGetThemesBySearch()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<CustomTheme> posts = await CustomDesign.GetThemesBySearch(connection, "", 10, 1, "id", "DESC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, posts.Count);

        } // End of the TestGetThemesBySearch method

        [TestMethod]
        public async Task TestGetAllThemes()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<CustomTheme> themes = await CustomDesign.GetAllThemes(connection, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, themes.Count);

        } // End of the TestGetAllThemes method

        [TestMethod]
        public async Task TestGetTemplatesByThemeId()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<CustomThemeTemplate> templates = await CustomDesign.GetTemplatesByThemeId(connection, 5, "user_file_name", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, templates.Count);

        } // End of the TestGetTemplatesByThemeId method

        [TestMethod]
        public async Task TestGetAllTemplates()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<CustomThemeTemplate> templates = await CustomDesign.GetAllTemplates(connection, "user_file_name", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, templates.Count);

        } // End of the TestGetAllTemplates method

        [TestMethod]
        public async Task TestDeleteTheme()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Delete the master post
            ResponseMessage response = await CustomDesign.DeleteTheme(connection, 4);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeleteTheme method

        [TestMethod]
        public async Task TestDeleteTemplate()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Delete the master post
            ResponseMessage response = await CustomDesign.DeleteTemplate(connection, 5, "search.cshtml");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeleteTemplate method

        [TestMethod]
        public async Task TestUploadImages()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create the list with images
            List<string> imageUrls = new List<string>(2);
            imageUrls.Add("d:\\Bilder\\1960.jpg");
            imageUrls.Add("d:\\Bilder\\1970.jpg");

            // Delete the master post
            ResponseMessage response = await CustomDesign.UploadImages(connection, imageUrls);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestUploadImages method

        [TestMethod]
        public async Task TestUploadFiles()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create the list with images
            List<string> fileUrls = new List<string>(2);
            fileUrls.Add("d:\\E-butik.se\\_export_777customers.asp.txt");
            fileUrls.Add("d:\\E-butik.se\\_export_orders.txt");

            // Delete the master post
            ResponseMessage response = await CustomDesign.UploadFiles(connection, fileUrls);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestUploadFiles method

        [TestMethod]
        public async Task TestDeleteImage()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create the list with images
            string imageName = "1960.jpg";

            // Delete the master post
            ResponseMessage response = await CustomDesign.DeleteImage(connection, imageName);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeleteImage method

        [TestMethod]
        public async Task TestDeleteFile()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create the list with images
            string fileName = "_export_777customers.asp.txt";

            // Delete the master post
            ResponseMessage response = await CustomDesign.DeleteFile(connection, fileName);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeleteFile method

        [TestMethod]
        public async Task TestDeleteAllImages()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Delete the master post
            ResponseMessage response = await CustomDesign.DeleteAllImages(connection);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeleteAllImages method

        [TestMethod]
        public async Task TestDeleteAllFiles()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Delete the master post
            ResponseMessage response = await CustomDesign.DeleteAllFiles(connection);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeleteAllFiles method

    } // End of the class

} // End of the namespace
