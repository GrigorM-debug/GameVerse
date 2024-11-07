using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameVerse.Common.Enums;
using Microsoft.VisualBasic;
using static GameVerse.Common.ApplicationConstants;
using static GameVerse.Common.ApplicationConstants.GameConstants;

namespace GameVerse.Web.ViewModels.Game.Add
{
    public class GameInputViewModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(PublishingStudioMaxLength, MinimumLength = PublishingStudioMinLength, ErrorMessage = LengthErrorMessage)]
        public string PublishingStudio { get; set; } = string.Empty;

        [Required]
        [Range(YearPublishedMinValue, YearPublishedMaxValue, ErrorMessage = RangeErrorMessage)]
        public int YearPublished { get; set; }

        [Required]
        public string CreatedOn { get; set; } = DateTime.Now.ToString(DateTimeFormat, CultureInfo.InvariantCulture);

        [Required]
        [Range(PriceMinValue, PriceMaxValue, ErrorMessage = RangeErrorMessage)]
        public decimal Price { get; set; }

        [Required]
        public string Image { get; set; } = string.Empty;

        [Required]
        [Range(QuantityInStockMinValue, QuantityInStockMaxValue, ErrorMessage = RangeErrorMessage)]
        public int QuantityInStock { get; set; }

        [Required]
        [EnumDataType(typeof(GameType), ErrorMessage = InvalidGameTypeErrorMessage)]
        public GameType Type { get; set; }

        public IEnumerable<Guid> SelectedGenres { get; set; } = new HashSet<Guid>();

        public IEnumerable<Guid> SelectedPlatforms { get; set; } = new HashSet<Guid>();

        public IEnumerable<Guid> SelectedRestrictions { get; set; } = new HashSet<Guid>();

        public IEnumerable<GameTypeViewModel> GameTypes { get; set; } = new HashSet<GameTypeViewModel>();

        public IEnumerable<GenreSelectList> GenreSelectList { get; set; } = new HashSet<GenreSelectList>();

        public IEnumerable<PlatformSelectList> PlatformSelectList { get; set; } = new HashSet<PlatformSelectList>();

        public IEnumerable<RestrictionSelectList> RestrictionSelectList { get; set; } =
            new HashSet<RestrictionSelectList>();
    }
}
