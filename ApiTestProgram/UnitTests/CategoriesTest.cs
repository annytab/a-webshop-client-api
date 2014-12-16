using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Annytab.WebshopClientAPI;

namespace ApiTestProgram
{
    [TestClass]
    public class CategoriesTest
    {
        [TestMethod]
        public async Task TestAdd()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            Category category = new Category();
            category.id = 0;
            category.title = "Titel API SE";
            category.parent_category_id = 0;
            category.page_name = "page_name_api_se";
            category.main_content = "Text API SE";
            category.meta_description = "Metabeskrv API";
            category.meta_keywords = "Nyckelord API";
            category.meta_robots = "Robots API";
            category.use_local_images = false;
            category.date_added = new DateTime(2013, 1, 1);
            category.page_views = 0;
            category.inactive = false;

            // Add the post
            ResponseMessage response = await Category.Add(connection, category, 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestAdd method

        [TestMethod]
        public async Task TestUpdate()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            Category category = new Category();
            category.id = 20;
            category.title = "Titel API SE UPP";
            category.parent_category_id = 0;
            category.page_name = "page_name_api_se";
            category.main_content = "Text API SE UPP";
            category.meta_description = "Metabeskrv API UPP";
            category.meta_keywords = "Nyckelord API UPP";
            category.meta_robots = "Robots API UPP";
            category.use_local_images = true;
            category.date_added = new DateTime(2014, 2, 2);
            category.page_views = 100;
            category.inactive = true;

            // Add the post
            ResponseMessage response = await Category.Update(connection, category, 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestUpdate method

        [TestMethod]
        public async Task TestTranslate()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            Category category = new Category();
            category.id = 20;
            category.title = "Titel API US";
            category.parent_category_id = 0;
            category.page_name = "page_name_api_us";
            category.main_content = "Text API US";
            category.meta_description = "Metabeskrv API US";
            category.meta_keywords = "Nyckelord API US";
            category.meta_robots = "Robots API US";
            category.use_local_images = false;
            category.date_added = new DateTime(2014, 2, 2);
            category.page_views = 0;
            category.inactive = true;

            // Add the post
            ResponseMessage response = await Category.Translate(connection, category, 2);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestTranslate method

        [TestMethod]
        public async Task TestGetCountBySearch()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get the count
            Int32 count = await Category.GetCountBySearch(connection, "", 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, count);

        } // End of the TestGetCountBySearch method

        [TestMethod]
        public async Task TestGetBySearch()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<Category> posts = await Category.GetBySearch(connection, "", 1, 10, 1, "id", "DESC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, posts.Count);

        } // End of the TestGetBySearch method

        [TestMethod]
        public async Task TestGetAll()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<Category> categories = await Category.GetAll(connection, 1, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, categories.Count);

        } // End of the TestGetAll method

        [TestMethod]
        public async Task TestGetAllActive()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<Category> categories = await Category.GetAllActive(connection, 1, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, categories.Count);

        } // End of the TestGetAllActive method

        [TestMethod]
        public async Task TestGetById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            Category post = await Category.GetById(connection, 10, 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(null, post);

        } // End of the TestGetById method

        [TestMethod]
        public async Task TestGetChildCategories()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<Category> categories = await Category.GetChildCategories(connection, 10, 1, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, categories.Count);

        } // End of the TestGetChildCategories method

        [TestMethod]
        public async Task TestGetActiveChildCategories()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<Category> categories = await Category.GetActiveChildCategories(connection, 10, 1, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, categories.Count);

        } // End of the TestGetActiveChildCategories method

        [TestMethod]
        public async Task TestDeletePost()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Delete the master post
            ResponseMessage response = await Category.Delete(connection, 20, 0);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeletePost method

        [TestMethod]
        public async Task TestGetImagesById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<string> images = await Category.GetImagesById(connection, 10, 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, images.Count);

        } // End of the TestGetImagesById method

        [TestMethod]
        public async Task TestGetAllImages()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            Dictionary<Int32, List<string>> images = await Category.GetAllImages(connection, 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, images.Count);

        } // End of the TestGetAllImages method

        [TestMethod]
        public async Task TestUploadMainImage()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create the image url
            string imageUrl = "d:\\Bilder\\anders_borg.jpg";

            // Delete the master post
            ResponseMessage response = await Category.UploadMainImage(connection, 50, 2, imageUrl);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestUploadMainImage method

        [TestMethod]
        public async Task TestUploadEnvironmentImages()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create the list with images
            List<string> imageUrls = new List<string>(2);
            imageUrls.Add("d:\\Bilder\\1960.jpg");
            imageUrls.Add("d:\\Bilder\\1970.jpg");

            // Delete the master post
            ResponseMessage response = await Category.UploadEnvironmentImages(connection, 50, 2, imageUrls);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestUploadEnvironmentImages method

        [TestMethod]
        public async Task TestDeleteImagesById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Delete the master post
            ResponseMessage response = await Category.DeleteImagesById(connection, 50);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeleteImagesById method

        [TestMethod]
        public async Task TestDeleteImagesByIdAndLanguage()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Delete the master post
            ResponseMessage response = await Category.DeleteImagesByIdAndLanguage(connection, 50, 2);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeleteImagesByIdAndLanguage method

    } // End of the class

} // End of the namespace
