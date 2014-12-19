a-webshop-client-api
====================

A client API in ASP.NET and C# that can be used to interact with a-webshop. You can use this client API to create applications in ASP.NET that interacts with a-webshop. The documentation for the API is under development, more information will come later.

This client API is available as a NuGet package: <a href="https://www.nuget.org/packages/AnnytabWebshopClientAPI/">a-webshop-client-api (NuGet Gallery)</a>

<b>A quick start guide</b><br />
Create an administrator in a-webshop with a API role, there is three different roles (API Full Trust, API Medium Trust, API Minimal Trust). The namespace for the classes in the API is Annytab.WebshopClientAPI.

<i>Example: Add a campaign</i>
<pre>
// Create the connection
ClientConnection connection = new ClientConnection(&quot;https://localhost:44301&quot;, &quot;TestAPI&quot;, &quot;test&quot;);

// Create a new post
Campaign campaign = new Campaign();
campaign.id = 0;
campaign.language_id = 1;
campaign.name = &quot;Name SV&quot;;
campaign.category_name = &quot;category name SV&quot;;
campaign.image_name = &quot;image name SV&quot;;
campaign.link_url = &quot;link url SV&quot;;
campaign.inactive = false;

// Add the post
ResponseMessage response = await Campaign.Add(connection, campaign);

// Dispose of the connection
connection.Dispose();</pre>

<i>Example: Get all campaigns</i>
<pre>
// Create the connection
ClientConnection connection = new ClientConnection(&quot;https://localhost:44301&quot;, &quot;TestAPI&quot;, &quot;test&quot;);

// Get posts
List&lt;Campaign&gt; campaigns = await Campaign.GetAll(connection, 0, &quot;id&quot;, &quot;ASC&quot;);

// Dispose of the connection
connection.Dispose();</pre>
