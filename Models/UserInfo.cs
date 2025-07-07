using SQLite;

namespace BlzMauiApp.Models
{
    public class UserInfo
    {
        [PrimaryKey]
        [AutoIncrement]
        public int LocalLoginID { get; set; }
        public string userID { get; set; }
        public string username { get; set; }
        public string compID { get; set; }
        public string bid { get; set; }
        public string rid { get; set; }
        public string yearID { get; set; }
        public string yearCode { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string aid { get; set; }
        public string roleID { get; set; }
        public string role { get; set; }
        public int zoneID { get; set; }
    }
}
