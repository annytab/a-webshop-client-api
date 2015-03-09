using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Annytab.WebshopClientAPI;
using System.IO;

namespace ApiTestProgram
{
    [TestClass]
    public class ProductsTest
    {
        [TestMethod]
        public async Task TestAdd()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create a new post
            Product product = new Product();
            product.id = 0;
            product.product_code = "Product code SE";
            product.manufacturer_code = "Manufacturer code SE";
            product.gtin = "Gtin SE";
            product.unit_price = 10.10M;
            product.unit_freight = 5.5M;
            product.unit_id = 1;
            product.mount_time_hours = 1.11M;
            product.from_price = false;
            product.category_id = 15;
            product.brand = "Brand SE";
            product.supplier_erp_id = "Supplier ERP SE";
            product.meta_robots = "Meta Robots SE";
            product.page_views = 10;
            product.buys = 20;
            product.added_in_basket = 33;
            product.condition = "Condition SE";
            product.variant_image_filename = "Variant image filename SE";
            product.gender = "Gender SE";
            product.age_group = "Age group SE";
            product.adult_only = false;
            product.unit_pricing_measure = 0.55M;
            product.unit_pricing_base_measure = 10;
            product.comparison_unit_id = 3;
            product.energy_efficiency_class = "A+";
            product.downloadable_files = true;
            product.date_added = new DateTime(2013, 1, 1);
            product.discount = 0.300M;
            product.title = "Title SE";
            product.main_content = "Main Content SE";
            product.extra_content = "Extra content SE";
            product.meta_description = "Meta description SE";
            product.meta_keywords = "Meta keywords SE";
            product.page_name = "page_name_6";
            product.delivery_time = "Delivery time SE";
            product.affiliate_link = "Affiliate link SE";
            product.rating = 1.45M;
            product.toll_freight_addition = 2.22M;
            product.value_added_tax_id = 3;
            product.account_code = "A-Code SE";
            product.google_category = "Google category";
            product.use_local_images = false;
            product.use_local_files = true;
            product.availability_status = "Availability status SE";
            product.availability_date = new DateTime(2005, 1, 1);
            product.size_type = "petite";
            product.size_system = "US";
            product.inactive = true;

            // Add the post
            ResponseMessage response = await Product.Add(connection, product, 1);

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
            Product product = new Product();
            product.id = 30;
            product.product_code = "Product code UPP";
            product.manufacturer_code = "Manufacturer code UPP";
            product.gtin = "Gtin UPP";
            product.unit_price = 20.20M;
            product.unit_freight = 15.15M;
            product.unit_id = 2;
            product.mount_time_hours = 2.22M;
            product.from_price = true;
            product.category_id = 16;
            product.brand = "Brand UPP";
            product.supplier_erp_id = "Supplier ERP UPP";
            product.meta_robots = "Meta Robots UPP";
            product.page_views = 30;
            product.buys = 60;
            product.added_in_basket = 77;
            product.condition = "Condition UPP";
            product.variant_image_filename = "Variant image filename UPP";
            product.gender = "Gender UPP";
            product.age_group = "Age group UPP";
            product.adult_only = true;
            product.unit_pricing_measure = 0.41M;
            product.unit_pricing_base_measure = 2;
            product.comparison_unit_id = 2;
            product.energy_efficiency_class = "energy class";
            product.downloadable_files = true;
            product.date_added = new DateTime(2014, 2, 2);
            product.discount = 0.888888888M;
            product.title = "Title UPP";
            product.main_content = "Main Content UPP";
            product.extra_content = "Extra content UPP";
            product.meta_description = "Meta description UPP";
            product.meta_keywords = "Meta keywords UPP";
            product.page_name = "page_name_upp";
            product.delivery_time = "Delivery time UPP";
            product.affiliate_link = "Affiliate link UPP";
            product.rating = 3.33M;
            product.toll_freight_addition = 4.44M;
            product.value_added_tax_id = 2;
            product.account_code = "A-Code UPP";
            product.google_category = "Google category UPP";
            product.use_local_images = true;
            product.use_local_files = true;
            product.availability_status = "Availability status UPP";
            product.availability_date = new DateTime(2014, 6, 6);
            product.size_type = "size type";
            product.size_system = "size sys";
            product.inactive = false;

            // Add the post
            ResponseMessage response = await Product.Update(connection, product, 1);

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
            Product product = new Product();
            product.id = 30; //8
            product.product_code = "Product code US";
            product.manufacturer_code = "Manufacturer code US";
            product.gtin = "Gtin US";
            product.unit_id = 0;
            product.category_id = 0;
            product.brand = "Brand US";
            product.supplier_erp_id = "Supplier ERP US";
            product.meta_robots = "Meta Robots US";
            product.page_views = 30;
            product.buys = 60;
            product.added_in_basket = 77;
            product.condition = "Condition US";
            product.variant_image_filename = "Variant image filename US";
            product.gender = "Gender US";
            product.age_group = "Age group US";
            product.adult_only = true;
            product.unit_pricing_measure = 0.55M;
            product.unit_pricing_base_measure = 1;
            product.comparison_unit_id = 3;
            product.energy_efficiency_class = "A+";
            product.downloadable_files = false;
            product.date_added = new DateTime(2014, 2, 2);
            product.discount = 0.000M;
            product.title = "Title US";
            product.main_content = "Main Content US";
            product.extra_content = "Extra content US";
            product.meta_description = "Meta description US";
            product.meta_keywords = "Meta keywords US";
            product.page_name = "page_name_us";
            product.delivery_time = "Delivery time US";
            product.affiliate_link = "Affiliate link US";
            product.rating = 1.14M;
            product.toll_freight_addition = 3.45M;
            product.value_added_tax_id = 4;
            product.account_code = "A-Code US";
            product.google_category = "Google category US";
            product.use_local_images = true;
            product.use_local_files = true;
            product.availability_status = "Availability status US";
            product.availability_date = new DateTime(2014, 7, 7);
            product.size_type = "petite";
            product.size_system = "US";
            product.inactive = false;

            // Add the post
            ResponseMessage response = await Product.Translate(connection, product, 2);

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
            Int32 count = await Product.GetCountBySearch(connection, "1 bauer", 1);

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
            List<Product> posts = await Product.GetBySearch(connection, "1 bauer", 1, 10, 1, "id", "DESC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, posts.Count);

        } // End of the TestGetBySearch method

        [TestMethod]
        public async Task TestGetById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            Product post = await Product.GetById(connection, 30, 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(null, post);

        } // End of the TestGetById method

        [TestMethod]
        public async Task TestGetAll()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<Product> products = await Product.GetAll(connection, 2, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, products.Count);

        } // End of the TestGetAll method

        [TestMethod]
        public async Task TestGetAllActive()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<Product> products = await Product.GetAllActive(connection, 2, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, products.Count);

        } // End of the TestGetAllActive method

        [TestMethod]
        public async Task TestGetAllActiveAndUnique()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<Product> products = await Product.GetAllActiveAndUnique(connection, 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, products.Count);

        } // End of the TestGetAllActiveAndUnique method

        [TestMethod]
        public async Task TestGetByCategoryId()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<Product> products = await Product.GetByCategoryId(connection, 2, 1, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, products.Count);

        } // End of the TestGetByCategoryId method

        [TestMethod]
        public async Task TestGetActiveByCategoryId()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<Product> products = await Product.GetActiveByCategoryId(connection, 19, 1, "id", "ASC");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, products.Count);

        } // End of the TestGetActiveByCategoryId method

        [TestMethod]
        public async Task TestGetFileVersion()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            DateTime fileVersionDate = await Product.GetFileVersion(connection, 2, 0, "laco-dsfdfn.jpg");

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(DateTime.MinValue, fileVersionDate);

        } // End of the TestGetFileVersion method

        [TestMethod]
        public async Task TestGetFile()
        {
            // Create the connection
            CustomerConnection connection = new CustomerConnection("https://localhost:44301", "info@ekonomiprogram.biz", "");

            // Get the file response
            StreamResponseMessage response = await Product.GetFile(connection, 2, 1, "laco-brown.jpg");

            // Dispose of the connection
            connection.Dispose();

            // Make sure that the stream not is null
            if(response.stream != null)
            {
                // Create the directory
                string directory = "downloads";

                // Create the directory if it does not exist
                if (Directory.Exists(directory) == false)
                {
                    Directory.CreateDirectory(directory);
                }

                // Create the file stream
                FileStream file = null;

                try
                {
                    // Get the file
                    file = new FileStream(directory + "/laco-brown.jpg", FileMode.Create);

                    // Copy the content to the filestream
                    response.stream.CopyTo(file);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    // Close streams
                    if (response.stream != null)
                    {
                        response.stream.Close();
                    }
                    if (file != null)
                    {
                        file.Close();
                    }
                }
            }

            // Test the method call
            Assert.AreEqual(true, response.result.is_success, response.result.status_code + " - " + response.result.reason_phrase + " - " + response.result.message);

        } // End of the TestGetFileVersion method

        [TestMethod]
        public async Task TestGetImagesById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Get posts
            List<string> images = await Product.GetImagesById(connection, 2, 1);

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
            Dictionary<Int32, List<string>> images = await Product.GetAllImages(connection, 1);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreNotEqual(0, images.Count);

        } // End of the TestGetAllImages method

        [TestMethod]
        public async Task TestDeletePost()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Delete the master post
            ResponseMessage response = await Product.Delete(connection, 8, 0);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeletePost method

        [TestMethod]
        public async Task TestUploadMainImage()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create the image url
            string imageUrl = "d:\\Bilder\\anders_borg.jpg";

            // Delete the master post
            ResponseMessage response = await Product.UploadMainImage(connection, 50, 2, imageUrl);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestUploadMainImage method

        [TestMethod]
        public async Task TestUploadOtherImages()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Create the list with images
            List<string> imageUrls = new List<string>(2);
            imageUrls.Add("d:\\Bilder\\1960.jpg");
            imageUrls.Add("d:\\Bilder\\1970.jpg");

            // Delete the master post
            ResponseMessage response = await Product.UploadOtherImages(connection, 50, 3, imageUrls);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestUploadOtherImages method

        [TestMethod]
        public async Task TestDeleteImagesById()
        {
            // Create the connection
            ClientConnection connection = new ClientConnection("https://localhost:44301", "TestAPI", "test");

            // Delete the master post
            ResponseMessage response = await Product.DeleteImagesById(connection, 50);

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
            ResponseMessage response = await Product.DeleteImagesByIdAndLanguage(connection, 50, 2);

            // Dispose of the connection
            connection.Dispose();

            // Test the method call
            Assert.AreEqual(true, response.is_success, response.status_code + " - " + response.reason_phrase + " - " + response.message);

        } // End of the TestDeleteImagesByIdAndLanguage method

    } // End of the class

} // End of the namespace
