using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AE.CoreInterface
{
    public class PermissionSet
    {
        private const char PermissionsSeperator = ';';
        
        public static readonly ISet<string> ValidPermissions = new HashSet<string>(Enumerable.Range(1, 100).Select(x => $"perm{x}"));
        public ISet<string> Permissions { get; }
        public byte[] PermissionsAsByteArray { get => Encoding.UTF8.GetBytes(string.Join(PermissionsSeperator.ToString(), Permissions.ToArray())); }

        public PermissionSet(ISet<string> permissions)
        {
            if (permissions != null && permissions.Any(permission => !ValidPermissions.Contains(permission)))
                throw new ArgumentException("unknown permissions added.");

            Permissions = permissions ?? new HashSet<string>();
        }

        public PermissionSet(byte[] bytes)
        {
            var permissionString = Encoding.UTF8.GetString(bytes ?? new byte[0]);

            if (string.IsNullOrEmpty(permissionString))
            {
                Permissions = new HashSet<string>();
                return;
            }

            var permissions = new HashSet<string>(permissionString.Split(PermissionsSeperator));

            if (permissions.Any(permission => !ValidPermissions.Contains(permission)))
                throw new ArgumentException("unknown permissions added.");

            Permissions = permissions;
        }


    }
}
