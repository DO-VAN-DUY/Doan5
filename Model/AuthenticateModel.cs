using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class AuthenticateModel
    {
        [Required]
        public string taikhoan { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
