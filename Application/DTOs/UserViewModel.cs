using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.DTOs
{
    public class UserUpdateModel 
    {
        [Required, StringLength(10)]
        public string Telephone { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(100,MinimumLength = 3)]
        public string Address { get; set; }

        [Required, StringLength(100, MinimumLength = 3)]
        public string City { get; set; }

        [Required, StringLength(100, MinimumLength = 3)]
        public string Province { get; set; }

        [Required]
        public int Zip { get; set; }
    }

    public class UserCreateModel : UserUpdateModel
    {
        [Required, StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required, StringLength(50, MinimumLength = 3)]
        public string Lastname { get; set; }

        [Required, StringLength(10)]
        public string Document { get; set; }
    }

    public class UserDetailModel : UserCreateModel
    {
        public int Id { get; set; }
    }

    public class UserListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Document { get; set; }

    }

}
