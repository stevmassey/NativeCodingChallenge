using AE.CoreUtility;
using System;

namespace AE.CoreInterface
{
    public class User
    {
        public string UserName { get; set; }
        public PermissionSet Permissions { get; set; }
        public DateTime CreateDate { get; set; }
        public string Timezone { get; set; }
        public string FavoriteColor { get; set; }

        public BlobIO Serialize()
        {
            BlobIO blob = null;
            blob += UserName;
            blob += Permissions;
            blob += CreateDate;
            blob += Timezone;
            blob += FavoriteColor;

            return blob;
        }
    }
}
