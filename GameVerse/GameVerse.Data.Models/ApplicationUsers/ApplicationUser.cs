using GameVerse.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Data.Models.ApplicationUsers
{
    /// <summary>
    /// Represents a user in the GameVerse application, extending the IdentityUser class with a GUID key.
    /// </summary>
    [Comment("The User in the GameVerse system")]
    public class ApplicationUser : IdentityUser<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUser"/> class, setting the Id to a new <see cref="Guid"/>.
        /// </summary>
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the first name of the application user.
        /// </summary>
        /// <remarks>
        /// This is a required field with string length constraints defined by <see cref="ApplicationUserConstants.ApplicationUserFirstNameMaxLength"/> 
        /// and <see cref="ApplicationUserConstants.ApplicationUserFirtNameMinLength"/>.
        /// </remarks>
        [PersonalData]
        [Required]
        [StringLength(ApplicationUserConstants.ApplicationUserFirstNameMaxLength, MinimumLength = ApplicationUserConstants.ApplicationUserFirtNameMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The FirstName of the ApplicationUser")]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the last name of the application user.
        /// </summary>
        /// <remarks>
        /// This is a required field with string length constraints defined by <see cref="ApplicationUserConstants.ApplicationUserLastNameMaxLength"/> 
        /// and <see cref="ApplicationUserConstants.ApplicationUserLastNameMinLength"/>.
        /// </remarks>
        [PersonalData]
        [Required]
        [StringLength(ApplicationUserConstants.ApplicationUserLastNameMaxLength, MinimumLength = ApplicationUserConstants.ApplicationUserLastNameMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The LastName of the ApplicationUser")]
        public string LastName { get; set; } = null!;
    }
}
