using CharityPost.Core.Domain.Entities.IdentityEntities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.DataTransferObjects.AuthObjects
{
    public class RegisterObject
    {
        [Required(ErrorMessage = "First name can't be blank.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last name can't be blank.")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Username can't be blank.")]
        [Remote(action: "IsUsernameFree", controller: "Auth", ErrorMessage = "A user with this username already exists.")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Email can't be blank.")]
        [Remote(action: "IsEmailFree", controller: "Auth", ErrorMessage = "A user with this email already exists.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Phone number can't be blank.")]
        [Remote(action: "IsPhoneNumberFree", controller: "Auth", ErrorMessage = "A user with this phone number already exists.")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Password can't be blank.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Confirm password can't be blank.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirm password doesn't match.")]
        public string ConfirmPassword { get; set; } = null!;

        public ApplicationUser ToApplicationUser()
        {
            return new ApplicationUser
            {
                FirstName = FirstName,
                LastName = LastName,
                UserName = UserName,
                Email = Email,
                PhoneNumber = PhoneNumber
            };
        }
    }
}
