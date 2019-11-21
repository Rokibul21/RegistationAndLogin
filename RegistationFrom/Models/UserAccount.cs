using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistationFrom.Models
{
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage ="Frist Name Is Required.")]
        public string FristName { get; set; }
        [Required(ErrorMessage = "Last Name Is Required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Is Required.")]
        [EmailAddress(ErrorMessage = "Please Enter A Valid Email Address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "User Name Is Required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Gender is Required.")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Password Is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }     
        [Compare("Password",ErrorMessage = "Please Confirm Your Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

    public enum Gender
    {
        Male,
        Fimale
    }
}