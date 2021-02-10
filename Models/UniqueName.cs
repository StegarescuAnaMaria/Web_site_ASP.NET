using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Starset.Models;
using AutoMapper;


namespace Starset.Models
{
    public class UniqueName: ValidationAttribute
    {
        private ApplicationDbContext _context;
        public UniqueName()
        {
            _context = new ApplicationDbContext();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var userName = value.ToString();
            var userNameExist = _context.Users.Any(u => u.Name == userName);
            if (userNameExist) return new ValidationResult("Username Taken");
            return ValidationResult.Success;
        }
    }
}