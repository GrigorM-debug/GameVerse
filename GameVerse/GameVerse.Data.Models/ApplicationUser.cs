﻿
using GameVerse.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
        }

        [PersonalData]
        [Required]
        [StringLength(ApplicationUserConstants.ApplicationUserUserNameMaxLength, MinimumLength = ApplicationUserConstants.ApplicationUserUserNameMinLength, ErrorMessage = ApplicationConstants.LengthErrorMessage)]
        [Comment("The username of the ApplicationUser")]
        public string Username { get; set; } = null!;

        [PersonalData]
        [Required]
        [StringLength(ApplicationUserConstants.ApplicationUserFirstNameMaxLength, MinimumLength = ApplicationUserConstants.ApplicationUserFirtNameMinLength, ErrorMessage = ApplicationConstants.LengthErrorMessage)]
        [Comment("The FirstName of the ApplicationUser")]
        public string FirstName { get; set; } = null!;

        [PersonalData]
        [Required]
        [StringLength(ApplicationUserConstants.ApplicationUserLastNameMaxLength, MinimumLength = ApplicationUserConstants.ApplicationUserLastNameMinLength, ErrorMessage = ApplicationConstants.LengthErrorMessage)]
        [Comment("The LastName of the ApplicationUser")]
        public string LastName { get; set; } = null!;

        [PersonalData]
        [Comment("The ApplicationUser profile image")]
        public string? ImageUrl {  get; set; }
    }
}