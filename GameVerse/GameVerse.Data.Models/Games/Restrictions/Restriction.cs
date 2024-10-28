using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameVerse.Common.ApplicationConstants;

namespace GameVerse.Data.Models.Games.Restrictions
{
    public class Restriction
    {
        [Key]
        [Required]
        [Comment("The restriction unique indentifier")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(RestrictionsConstants.RestrictionNameMaxLength, MinimumLength = RestrictionsConstants.RestrictionNameMinLength, ErrorMessage = LengthErrorMessage)]
        [Comment("The name of the restriction")]
        public string Name { get; set; } = null!;

        public ICollection<GameRestriction> GamesRestrictions { get; set; } = new HashSet<GameRestriction>();
    }
}
