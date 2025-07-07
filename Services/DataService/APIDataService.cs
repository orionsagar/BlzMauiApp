using BlzMauiApp.Helpers;
using BlzMauiApp.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BlzMauiApp.Services.DataService
{
    public class APIDataService
    {

        /// <summary>
        /// User Info
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserInfo> GetUserInfoAsync(LoginViewModel loginViewModel)
        {
            var ideas = new List<UserInfo>();
            UserInfo localLogin = new UserInfo();
            try
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    //await APIToken();
                    //string AccessToken = "";
                    //if (Application.Current.Properties.ContainsKey("AccessToken"))
                    //{
                    //    AccessToken = Application.Current.Properties["AccessToken"].ToString();
                    //}
                    var client = new HttpClient();
                    //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    //    AppConfiguration.AccessName, AppConfiguration.AccessToken);
                    //client.Timeout = TimeSpan.FromMinutes(5);
                    //var apiurl = AppConfiguration.BaseApiAddress + "api/User/userinfo?Username=" + loginViewModel.Username + "&Password=" + loginViewModel.Password;

                    //var json = JsonConvert.SerializeObject(loginViewModel);
                    //HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var response = await client.GetAsync(AppConfiguration.BaseApiAddress + "api/User/userinfo?Username=" + loginViewModel.Username + "&Password=" + loginViewModel.Password);
                    string contactsJson = await response.Content.ReadAsStringAsync();
                    localLogin = JsonConvert.DeserializeObject<UserInfo>(contactsJson);



                    //// Start
                    //var request = new HttpRequestMessage
                    //{
                    //    Method = HttpMethod.Get,
                    //    RequestUri = new Uri(apiurl),

                    //    Content = new StringContent(json, Encoding.UTF8, "application/json")
                    //};

                    //var response = client.SendAsync(request).ConfigureAwait(false);
                    //var responseInfo = response.GetAwaiter().GetResult();
                    //// End

                    ///// start
                    /////
                    ////var request = new HttpRequestMessage(HttpMethod.Get, apiurl);
                    ////request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    ////request.Content = new StringContent(json, Encoding.UTF8);
                    ////request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    ////var response = await client.SendAsync(request);
                    ////response.EnsureSuccessStatusCode();
                    ////var contentjson = await response.Content.ReadAsStringAsync();
                    ////localLogin = JsonConvert.DeserializeObject<UserInfo>(contentjson);
                    //////localLogin = JsonSerializer.Deserialize<UserInfo>(contentjson);
                    ///// End



                    //LocalLoginList ObjContactList = new LocalLoginList();
                    //if (contactsJson != "")
                    //{
                    //    //Converting JSON Array Objects into generic list  
                    //    ObjContactList = JsonConvert.DeserializeObject<LocalLoginList>(contactsJson);
                    //}
                    ////ideas = JsonConvert.DeserializeObject<List<Products>>(json);
                    //ideas = ObjContactList.Items;

                    //localLogin = JsonConvert.DeserializeObject<LocalLogin>(contactsJson);

                    client.Dispose();
                }
                else
                {
                    //DependencyService.Get<IMessage>().LongAlert("Check your internet connection.");
                    Console.WriteLine("//------------ Error ---: Check your internet connection. ");
                }
            }
            catch (Exception ex)
            {
                //DependencyService.Get<IMessage>().LongAlert("We have been encountered api related problem. Please try again.");
                Console.WriteLine("//------------ Fetch Contact  Error ---: " + ex.Message.ToString());
            }


            return localLogin;
            //return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }



        /// <summary>
        /// Get Branch List
        /// </summary>
        /// <returns></returns>
        public async Task<List<SelectListItem>> GetBranchs(string BranchId)
        {
            List<SelectListItem> ideas = new List<SelectListItem>();
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    AppConfiguration.AccessName, AppConfiguration.AccessToken);
                client.Timeout = TimeSpan.FromMinutes(5);

                var json = await client.GetAsync(AppConfiguration.BaseApiAddress + "api/CommonCall/Branchs?BranchId=" + BranchId);

                string contactsJson = await json.Content.ReadAsStringAsync();

                //BannerList ObjContactList = new BannerList();
                //if (contactsJson != "")
                //{
                //    //Converting JSON Array Objects into generic list  
                //    ObjContactList = JsonConvert.DeserializeObject<BannerList>(contactsJson);
                //}
                ideas = JsonConvert.DeserializeObject<List<SelectListItem>>(contactsJson);
                //ideas = ObjContactList.items;
            }
            catch (TaskCanceledException ex)
            {
                //DependencyService.Get<IMessage>().LongAlert("We have been encountered api related problem. Please try again.");
                Console.WriteLine("//------------ Banner API Error ---: " + ex.Message.ToString());
            }
            return ideas;
        }



        /// <summary>
        /// Get Invoice No
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetInvoiceNo(string BranchId)
        {
            string InvNo = "";
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    AppConfiguration.AccessName, AppConfiguration.AccessToken);
                client.Timeout = TimeSpan.FromMinutes(5);

                var json = await client.GetAsync(AppConfiguration.BaseApiAddress + "api/CommonCall/InvoiceNo?BranchId=" + BranchId);

                string contactsJson = await json.Content.ReadAsStringAsync();
                InvNo = contactsJson;
                //BannerList ObjContactList = new BannerList();
                //if (contactsJson != "")
                //{
                //    //Converting JSON Array Objects into generic list  
                //    ObjContactList = JsonConvert.DeserializeObject<BannerList>(contactsJson);
                //}
                //ideas = JsonConvert.DeserializeObject<List<SelectListItem>>(contactsJson);
                //ideas = ObjContactList.items;
            }
            catch (TaskCanceledException ex)
            {
                //DependencyService.Get<IMessage>().LongAlert("We have been encountered api related problem. Please try again.");
                Console.WriteLine("//------------ Banner API Error ---: " + ex.Message.ToString());
            }
            return InvNo;
        }



        /// <summary>
        /// Get Representative List by BranchID
        /// </summary>
        /// <returns></returns>
        public async Task<List<SelectListItem>> GetRepresentativeByBranchs(string BranchId, string ComID)
        {
            List<SelectListItem> ideas = new List<SelectListItem>();
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    AppConfiguration.AccessName, AppConfiguration.AccessToken);
                client.Timeout = TimeSpan.FromMinutes(5);

                var json = await client.GetAsync(AppConfiguration.BaseApiAddress + "api/CommonCall/RepresentativeByBranch?BranchId=" + BranchId + "&ComID=" + ComID);

                string contactsJson = await json.Content.ReadAsStringAsync();

                //BannerList ObjContactList = new BannerList();
                //if (contactsJson != "")
                //{
                //    //Converting JSON Array Objects into generic list  
                //    ObjContactList = JsonConvert.DeserializeObject<BannerList>(contactsJson);
                //}
                ideas = JsonConvert.DeserializeObject<List<SelectListItem>>(contactsJson);
                //ideas = ObjContactList.items;
            }
            catch (TaskCanceledException ex)
            {
                //DependencyService.Get<IMessage>().LongAlert("We have been encountered api related problem. Please try again.");
                Console.WriteLine("//------------ Banner API Error ---: " + ex.Message.ToString());
            }
            return ideas;
        }



        /// <summary>
        /// Get Customer List by MR
        /// </summary>
        /// <returns></returns>
        public async Task<List<SelectListItem>> GetCustomerByMR(string AreaId, string BranchId, string RepresentativeId)
        {
            List<SelectListItem> ideas = new List<SelectListItem>();
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    AppConfiguration.AccessName, AppConfiguration.AccessToken);
                client.Timeout = TimeSpan.FromMinutes(5);

                var json = await client.GetAsync(AppConfiguration.BaseApiAddress + "api/CommonCall/customerbyrepresentative?AreaId=" + AreaId + "&branchId=" + BranchId + "&RepresentativeId=" + RepresentativeId);

                string contactsJson = await json.Content.ReadAsStringAsync();

                //BannerList ObjContactList = new BannerList();
                //if (contactsJson != "")
                //{
                //    //Converting JSON Array Objects into generic list  
                //    ObjContactList = JsonConvert.DeserializeObject<BannerList>(contactsJson);
                //}
                ideas = JsonConvert.DeserializeObject<List<SelectListItem>>(contactsJson);
                //ideas = ObjContactList.items;
            }
            catch (TaskCanceledException ex)
            {
                //DependencyService.Get<IMessage>().LongAlert("We have been encountered api related problem. Please try again.");
                Console.WriteLine("//------------ Banner API Error ---: " + ex.Message.ToString());
            }
            return ideas;
        }



        /// <summary>
        /// Get SR List by MR
        /// </summary>
        /// <returns></returns>
        public async Task<List<SelectListItem>> GetSRByMR(string AreaId, string RepresentativeId)
        {
            List<SelectListItem> ideas = new List<SelectListItem>();
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    AppConfiguration.AccessName, AppConfiguration.AccessToken);
                client.Timeout = TimeSpan.FromMinutes(5);

                var json = await client.GetAsync(AppConfiguration.BaseApiAddress + "api/CommonCall/srlist?AreaId=" + AreaId + "");

                string contactsJson = await json.Content.ReadAsStringAsync();

                //BannerList ObjContactList = new BannerList();
                //if (contactsJson != "")
                //{
                //    //Converting JSON Array Objects into generic list  
                //    ObjContactList = JsonConvert.DeserializeObject<BannerList>(contactsJson);
                //}
                ideas = JsonConvert.DeserializeObject<List<SelectListItem>>(contactsJson);
                //ideas = ObjContactList.items;
            }
            catch (TaskCanceledException ex)
            {
                //DependencyService.Get<IMessage>().LongAlert("We have been encountered api related problem. Please try again.");
                Console.WriteLine("//------------ Banner API Error ---: " + ex.Message.ToString());
            }
            return ideas;
        }

        /// <summary>
        /// Get MR 
        /// </summary>
        /// <param name="ComID"></param>
        /// <param name="BranchID"></param>
        /// <param name="RepresentativeId"></param>
        /// <returns></returns>
        public async Task<List<SelectListItem>> GetMR(string ComID, string BranchID, string RepresentativeId)
        {
            List<SelectListItem> ideas = new List<SelectListItem>();
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    AppConfiguration.AccessName, AppConfiguration.AccessToken);
                client.Timeout = TimeSpan.FromMinutes(5);

                var json = await client.GetAsync(AppConfiguration.BaseApiAddress + "api/CommonCall/mrlist?ComId=" + ComID + "&branchId=" + BranchID + "&RepresentativeId=" + RepresentativeId);

                string contactsJson = await json.Content.ReadAsStringAsync();

                //BannerList ObjContactList = new BannerList();
                //if (contactsJson != "")
                //{
                //    //Converting JSON Array Objects into generic list  
                //    ObjContactList = JsonConvert.DeserializeObject<BannerList>(contactsJson);
                //}
                ideas = JsonConvert.DeserializeObject<List<SelectListItem>>(contactsJson);
                //ideas = ObjContactList.items;
            }
            catch (TaskCanceledException ex)
            {
                //DependencyService.Get<IMessage>().LongAlert("We have been encountered api related problem. Please try again.");
                Console.WriteLine("//------------ Banner API Error ---: " + ex.Message.ToString());
            }
            return ideas;
        }


        /// <summary>
        /// Get Customer Details
        /// </summary>
        /// <returns></returns>
        public async Task<Customers> GetCustomerDetails(int CusId)
        {
            Customers customers = new Customers();
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    AppConfiguration.AccessName, AppConfiguration.AccessToken);
                client.Timeout = TimeSpan.FromMinutes(5);

                var json = await client.GetAsync(AppConfiguration.BaseApiAddress + "api/Customer/CustomerDetails?Id=" + CusId);

                string contactsJson = await json.Content.ReadAsStringAsync();

                customers = JsonConvert.DeserializeObject<Customers>(contactsJson);
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine("//------------ API Error ---: " + ex.Message.ToString());
            }
            return customers;
        }


        /// <summary>
        /// Serach Product By %like%
        /// </summary>
        /// <param name="SearchText"></param>
        /// <returns></returns>
        public async Task<List<Products>> GetItemAsync(string sorting, int pageNumber, int PageSize, string querytext, string querystring)
        {
            var ideas = new List<Products>();
            var retideas = new List<ProductInfo>();
            try
            {
                var current = Connectivity.NetworkAccess;

                if (current == NetworkAccess.Internet)
                {
                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        AppConfiguration.AccessName, AppConfiguration.AccessToken);
                    client.Timeout = TimeSpan.FromMinutes(5);

                    string queryStr = "";
                    queryStr = "pageNumber=" + pageNumber + "&PageSize=" + PageSize + "&QueryText=" + querytext + "&QueryString=" + querystring + "&Sorting=" + sorting;

                    var json = await client.GetAsync(AppConfiguration.BaseApiAddress + "api/Product/lists?" + queryStr.ToString());

                    string contactsJson = await json.Content.ReadAsStringAsync();

                    ProductList ObjContactList = new ProductList();
                    if (contactsJson != "")
                    {
                        //Converting JSON Array Objects into generic list  
                        ObjContactList = JsonConvert.DeserializeObject<ProductList>(contactsJson);
                    }

                    var itemInStock = false;
                    //ideas = JsonConvert.DeserializeObject<List<Products>>(json);
                    if (ObjContactList != null || ObjContactList.ToString() != "")
                    {
                        //ideas = ObjContactList.items.Where(x => x.status == "1").ToList();
                        ideas = ObjContactList.Items;

                        //if (Application.Current.Properties.ContainsKey("Product_total_count"))
                        //{
                        //    Application.Current.Properties.Remove("Product_total_count");
                        //    Application.Current.Properties["Product_total_count"] = ObjContactList.TotalCount;
                        //}
                        //else
                        //{
                        //    Application.Current.Properties["Product_total_count"] = ObjContactList.TotalCount;
                        //}
                    }



                    client.Dispose();
                    //ideas = JsonConvert.DeserializeObject<List<Products>>(contactsJson);
                }
                else
                {
                    //DependencyService.Get<IMessage>().LongAlert("Check your internet connection.");
                    Console.WriteLine("//------------ Error ---: Check your internet connection. ");
                }
            }
            catch (Exception ex)
            {
                //DependencyService.Get<IMessage>().LongAlert("We have been encountered api related problem. Please try again.");
                Console.WriteLine("//------------ Serach Product By %like% Error ---: " + ex.Message.ToString());
            }


            return ideas;
            //return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        /// <summary>
        /// Product Search 
        /// </summary>
        /// <param name="sorting"></param>
        /// <param name="pageNumber"></param>
        /// <param name="PageSize"></param>
        /// <param name="querytext"></param>
        /// <param name="querystring"></param>
        /// <returns></returns>
        public async Task<List<Products>> GetSearchItemAsync(string sorting, int pageNumber, int PageSize, string querytext, string querystring)
        {
            var ideas = new List<Products>();
            var retideas = new List<ProductInfo>();
            try
            {
                var current = Connectivity.NetworkAccess;

                if (current == NetworkAccess.Internet)
                {
                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        AppConfiguration.AccessName, AppConfiguration.AccessToken);
                    client.Timeout = TimeSpan.FromMinutes(5);

                    string queryStr = "";
                    queryStr = "pageNumber=" + pageNumber + "&PageSize=" + PageSize + "&QueryText=" + querytext + "&QueryString=" + querystring + "&Sorting=" + sorting;

                    var json = await client.GetAsync(AppConfiguration.BaseApiAddress + "api/Product/Searchlists?" + queryStr.ToString());

                    string contactsJson = await json.Content.ReadAsStringAsync();

                    ProductList ObjContactList = new ProductList();
                    if (contactsJson != "")
                    {
                        //Converting JSON Array Objects into generic list  
                        ObjContactList = JsonConvert.DeserializeObject<ProductList>(contactsJson);
                    }

                    var itemInStock = false;
                    //ideas = JsonConvert.DeserializeObject<List<Products>>(json);
                    if (ObjContactList != null || ObjContactList.ToString() != "")
                    {
                        //ideas = ObjContactList.items.Where(x => x.status == "1").ToList();
                        ideas = ObjContactList.Items;

                        //if (Application.Current.Properties.ContainsKey("Product_total_count"))
                        //{
                        //    Application.Current.Properties.Remove("Product_total_count");
                        //    Application.Current.Properties["Product_total_count"] = ObjContactList.TotalCount;
                        //}
                        //else
                        //{
                        //    Application.Current.Properties["Product_total_count"] = ObjContactList.TotalCount;
                        //}
                    }



                    client.Dispose();
                    //ideas = JsonConvert.DeserializeObject<List<Products>>(contactsJson);
                }
                else
                {
                    //DependencyService.Get<IMessage>().LongAlert("Check your internet connection.");
                    Console.WriteLine("//------------ Error ---: Check your internet connection. ");
                }
            }
            catch (Exception ex)
            {
                //DependencyService.Get<IMessage>().LongAlert("We have been encountered api related problem. Please try again.");
                Console.WriteLine("//------------ Serach Product By %like% Error ---: " + ex.Message.ToString());
            }


            return ideas;
            //return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Products>> GetAllProduct()
        {
            var ideas = new List<Products>();
            try
            {
                var current = Connectivity.NetworkAccess;

                if (current == NetworkAccess.Internet)
                {
                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        AppConfiguration.AccessName, AppConfiguration.AccessToken);
                    client.Timeout = TimeSpan.FromMinutes(5);

                    string queryStr = "";

                    var json = await client.GetAsync(AppConfiguration.BaseApiAddress + "api/Product/lists");

                    string contactsJson = await json.Content.ReadAsStringAsync();

                    ProductList ObjContactList = new ProductList();
                    if (contactsJson != "")
                    {
                        //Converting JSON Array Objects into generic list  
                        ObjContactList = JsonConvert.DeserializeObject<ProductList>(contactsJson);
                    }

                    var itemInStock = false;

                    //ideas = JsonConvert.DeserializeObject<List<Products>>(json);
                    if (ObjContactList != null || ObjContactList.ToString() != "")
                    {
                        //ideas = ObjContactList.items.Where(x => x.status == "1").ToList();
                        ideas = ObjContactList.Items;

                        //if (Application.Current.Properties.ContainsKey("Product_total_count"))
                        //{
                        //    Application.Current.Properties.Remove("Product_total_count");
                        //    Application.Current.Properties["Product_total_count"] = ObjContactList.TotalCount;
                        //}
                        //else
                        //{
                        //    Application.Current.Properties["Product_total_count"] = ObjContactList.TotalCount;
                        //}
                    }



                    client.Dispose();
                    //ideas = JsonConvert.DeserializeObject<List<Products>>(contactsJson);
                }
                else
                {
                    //DependencyService.Get<IMessage>().LongAlert("Check your internet connection.");
                    Console.WriteLine("//------------ Error ---: Check your internet connection. ");
                }
            }
            catch (Exception ex)
            {
                //DependencyService.Get<IMessage>().LongAlert("We have been encountered api related problem. Please try again.");
                Console.WriteLine("//------------ Serach Product By %like% Error ---: " + ex.Message.ToString());
            }


            return ideas;
        }

        /// <summary>
        /// Get Invoice List
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public async Task<SalesInvoiceList> GetAllInvoice(string id, int pageindex, int pagesize)
        {
            var ideas = new List<SalesInvoiceList>();
            SalesInvoiceList ObjContactList = new SalesInvoiceList();
            try
            {
                var current = Connectivity.NetworkAccess;

                if (current == NetworkAccess.Internet)
                {
                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        AppConfiguration.AccessName, AppConfiguration.AccessToken);
                    client.Timeout = TimeSpan.FromMinutes(5);

                    string queryStr = "";

                    var json = await client.GetAsync(AppConfiguration.BaseApiAddress + "api/SalesInvoice/list?PageSize=" + pagesize + "&_pageSize=" + pagesize + "&pageNumber=" + pageindex + "");

                    string contactsJson = await json.Content.ReadAsStringAsync();


                    if (contactsJson != "")
                    {
                        //Converting JSON Array Objects into generic list  
                        ObjContactList = JsonConvert.DeserializeObject<SalesInvoiceList>(contactsJson);
                    }

                    var itemInStock = false;

                    //ideas = JsonConvert.DeserializeObject<List<Products>>(json);
                    //if (ObjContactList != null || ObjContactList.ToString() != "")
                    //{
                    //    //ideas = ObjContactList.items.Where(x => x.status == "1").ToList();
                    //    //ideas = ObjContactList.items;

                    //    //if (Application.Current.Properties.ContainsKey("Product_total_count"))
                    //    //{
                    //    //    Application.Current.Properties.Remove("Product_total_count");
                    //    //    Application.Current.Properties["Product_total_count"] = ObjContactList.TotalCount;
                    //    //}
                    //    //else
                    //    //{
                    //    //    Application.Current.Properties["Product_total_count"] = ObjContactList.TotalCount;
                    //    //}
                    //}



                    client.Dispose();
                    //ideas = JsonConvert.DeserializeObject<List<Products>>(contactsJson);
                }
                else
                {
                    //DependencyService.Get<IMessage>().LongAlert("Check your internet connection.");
                    Console.WriteLine("//------------ Error ---: Check your internet connection. ");
                }
            }
            catch (Exception ex)
            {
                //DependencyService.Get<IMessage>().LongAlert("We have been encountered api related problem. Please try again.");
                Console.WriteLine("//------------ Serach Product By %like% Error ---: " + ex.Message.ToString());
            }


            return ObjContactList;
        }




        /// <summary>
        /// Get Zone 
        /// </summary>
        /// <param name="BranchID"></param>
        /// <returns></returns>
        public async Task<List<SelectListItem>> GetZone(string BranchID)
        {
            List<SelectListItem> ideas = new List<SelectListItem>();
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    AppConfiguration.AccessName, AppConfiguration.AccessToken);
                client.Timeout = TimeSpan.FromMinutes(5);

                var json = await client.GetAsync(AppConfiguration.BaseApiAddress + "api/CommonCall/getzone?BranchId=" + BranchID);

                string contactsJson = await json.Content.ReadAsStringAsync();

                //BannerList ObjContactList = new BannerList();
                //if (contactsJson != "")
                //{
                //    //Converting JSON Array Objects into generic list  
                //    ObjContactList = JsonConvert.DeserializeObject<BannerList>(contactsJson);
                //}
                ideas = JsonConvert.DeserializeObject<List<SelectListItem>>(contactsJson);
                //ideas = ObjContactList.items;
            }
            catch (TaskCanceledException ex)
            {
                //DependencyService.Get<IMessage>().LongAlert("We have been encountered api related problem. Please try again.");
                Console.WriteLine("//------------ Banner API Error ---: " + ex.Message.ToString());
            }
            return ideas;
        }


        /// <summary>
        /// Get Area 
        /// </summary>
        /// <param name="ZoneId"></param>
        /// <returns></returns>
        public async Task<List<SelectListItem>> GetArea(string ZoneId)
        {
            List<SelectListItem> ideas = new List<SelectListItem>();
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    AppConfiguration.AccessName, AppConfiguration.AccessToken);
                client.Timeout = TimeSpan.FromMinutes(5);

                var json = await client.GetAsync(AppConfiguration.BaseApiAddress + "api/CommonCall/getarea?ZoneId=" + ZoneId);

                string contactsJson = await json.Content.ReadAsStringAsync();

                //BannerList ObjContactList = new BannerList();
                //if (contactsJson != "")
                //{
                //    //Converting JSON Array Objects into generic list  
                //    ObjContactList = JsonConvert.DeserializeObject<BannerList>(contactsJson);
                //}
                ideas = JsonConvert.DeserializeObject<List<SelectListItem>>(contactsJson);
                //ideas = ObjContactList.items;
            }
            catch (TaskCanceledException ex)
            {
                //DependencyService.Get<IMessage>().LongAlert("We have been encountered api related problem. Please try again.");
                Console.WriteLine("//------------ Banner API Error ---: " + ex.Message.ToString());
            }
            return ideas;
        }


        /// <summary>
        /// Get Representative 
        /// </summary>
        /// <param name="AreaId"></param>
        /// <param name="BranchId"></param>
        /// <returns></returns>
        public async Task<List<SelectListItem>> GetRepresentative(string AreaId, string BranchId)
        {
            List<SelectListItem> ideas = new List<SelectListItem>();
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    AppConfiguration.AccessName, AppConfiguration.AccessToken);
                client.Timeout = TimeSpan.FromMinutes(5);

                var json = await client.GetAsync(AppConfiguration.BaseApiAddress + "api/CommonCall/getrepresentative?AreaId="+ AreaId + "&BranchId=" + BranchId);

                string contactsJson = await json.Content.ReadAsStringAsync();

                //BannerList ObjContactList = new BannerList();
                //if (contactsJson != "")
                //{
                //    //Converting JSON Array Objects into generic list  
                //    ObjContactList = JsonConvert.DeserializeObject<BannerList>(contactsJson);
                //}
                ideas = JsonConvert.DeserializeObject<List<SelectListItem>>(contactsJson);
                //ideas = ObjContactList.items;
            }
            catch (TaskCanceledException ex)
            {
                //DependencyService.Get<IMessage>().LongAlert("We have been encountered api related problem. Please try again.");
                Console.WriteLine("//------------ Banner API Error ---: " + ex.Message.ToString());
            }
            return ideas;
        }


        /// <summary>
        /// Get Representative 
        /// </summary>
        /// <param name="AreaId"></param>
        /// <param name="BranchId"></param>
        /// <returns></returns>
        public async Task<List<SelectListItem>> GetCustomer(string AreaId, string BranchId)
        {
            List<SelectListItem> ideas = new List<SelectListItem>();
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    AppConfiguration.AccessName, AppConfiguration.AccessToken);
                client.Timeout = TimeSpan.FromMinutes(5);

                var json = await client.GetAsync(AppConfiguration.BaseApiAddress + "api/CommonCall/getcustomer?AreaId=" + AreaId + "&BranchId=" + BranchId);

                string contactsJson = await json.Content.ReadAsStringAsync();

                //BannerList ObjContactList = new BannerList();
                //if (contactsJson != "")
                //{
                //    //Converting JSON Array Objects into generic list  
                //    ObjContactList = JsonConvert.DeserializeObject<BannerList>(contactsJson);
                //}
                ideas = JsonConvert.DeserializeObject<List<SelectListItem>>(contactsJson);
                //ideas = ObjContactList.items;
            }
            catch (TaskCanceledException ex)
            {
                //DependencyService.Get<IMessage>().LongAlert("We have been encountered api related problem. Please try again.");
                Console.WriteLine("//------------ Banner API Error ---: " + ex.Message.ToString());
            }
            return ideas;
        }
    }
}
