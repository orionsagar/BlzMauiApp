using BlzMauiApp.Services.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Security.Claims;

namespace BlzMauiApp.AuthProvider
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        LoginDatabase loginDatabase = new LoginDatabase();

        /// <summary>
        /// This method should be called upon a successful user login, and it will store the user's JWT token in SecureStorage.
        /// Upon saving this it will also notify .NET that the authentication state has changed which will enable authenticated views
        /// </summary>
        /// <param name="token">Our JWT to store</param>
        /// <returns></returns>
        public async Task Login(Models.UserInfo token)
        {
            string userBasicInfoStr = JsonConvert.SerializeObject(token);

            //Again, this is what I'm doing, but you could do/store/save anything as part of this process
            await SecureStorage.SetAsync("accounttoken", userBasicInfoStr);

            //Providing the current identity ifnormation
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        /// <summary>
        /// This method should be called to log-off the user from the application, which simply removed the stored token and then
        /// notifies of the change
        /// </summary>
        /// <returns></returns>
        public async Task Logout()
        {
            SecureStorage.Remove("accounttoken");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var cusinfo = await loginDatabase.GetItemsAsync();
                if (cusinfo != null)
                {
                    foreach (Models.UserInfo lg in cusinfo)
                    {
                        var claims = new[] {
                            new Claim(ClaimTypes.Name, lg.username),
                            new Claim("UserID", lg.userID,"string"),
                            new Claim(ClaimTypes.Role, lg.role),
                            new Claim("RoleID",lg.roleID,"string"),
                            new Claim("BID",lg.roleID,"string"),
                            new Claim("RID",lg.rid,"string"),
                            new Claim("CompID",lg.compID,"string"),
                            new Claim("YearID",lg.yearID,"string"),
                            new Claim("AID",lg.aid,"string"),
                            new Claim("ZoneID",lg.zoneID.ToString(),"string"),
                            new Claim("YearCode",lg.yearCode,"string"),
                            new Claim("StartDate",lg.startDate,"Date"),
                            new Claim("EndDate",lg.endDate,"Date"),
                        };
                        var identity = new ClaimsIdentity(claims, "Custom_Authentication");
                        return new AuthenticationState(new ClaimsPrincipal(identity));


                        //                    var identity = new ClaimsIdentity(new[]{
                        //    new Claim(ClaimTypes.Email, userProfile.Email),
                        //    new Claim(ClaimTypes.Name, $"{userProfile.FirstName} {userProfile.LastName}"),
                        //    new Claim("UserId", userProfile.ToString())
                        //}, "AuthCookie");

                        //                    claimsPrincipal = new ClaimsPrincipal(identity);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Request failed:" + ex.ToString());
            }

            return new AuthenticationState(new ClaimsPrincipal());
        }
    }
}
