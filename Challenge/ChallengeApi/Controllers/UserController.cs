using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ChallengeApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeApi.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly static ConcurrentDictionary<string, User> Cache = new ConcurrentDictionary<string, User>();

        [HttpGet]
        [Route("api/user/{username}")]
        public IActionResult GetUser(string username)
        {
            var random = new Random();
            var user = Cache.GetOrAdd(username, _ =>
            {
                return new User
                {
                    UserName = username,
                    Permissions = new PermissionSet(new HashSet<string>() { $"perm{random.Next(1, 100)}", $"perm{random.Next(1, 100)}" }),
                    CreateDate = DateTime.UtcNow,
                    Timezone = "PST",
                    FavoriteColor = random.Next(0, 100) % 2 == 0 ? "blue" : "red"

                };
            });

            return Ok(user);
        }
    }
}
