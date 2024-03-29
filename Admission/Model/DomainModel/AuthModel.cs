﻿using Microsoft.AspNetCore.Identity;

namespace Admission.Model.DomainModel
{
    public class AuthModel
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }

        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string Tokens { get; set; }
        public DateTime ExpiredAt { get; set; }
        public bool Succeeded { get;  set; }
        public List<IdentityError>? Errors { get; set; }
    }
}
