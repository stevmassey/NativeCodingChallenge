using System;

namespace ChallengeApi.Models
{
    public class User
    {
        public string UserName { get; set; }
        public PermissionSet Permissions { get; set; }
        public DateTime CreateDate { get; set; }
        public string Timezone { get; set; }
        public string FavoriteColor { get; set; }
    }
}
