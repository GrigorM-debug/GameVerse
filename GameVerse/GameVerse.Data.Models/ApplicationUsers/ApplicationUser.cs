﻿using GameVerse.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Data.Models.ApplicationUsers
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
        }

        [PersonalData]
        [Required]
        [StringLength(ApplicationUserConstants.ApplicationUserFirstNameMaxLength, MinimumLength = ApplicationUserConstants.ApplicationUserFirtNameMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The FirstName of the ApplicationUser")]
        public string FirstName { get; set; } = null!;

        [PersonalData]
        [Required]
        [StringLength(ApplicationUserConstants.ApplicationUserLastNameMaxLength, MinimumLength = ApplicationUserConstants.ApplicationUserLastNameMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The LastName of the ApplicationUser")]
        public string LastName { get; set; } = null!;
    }
}