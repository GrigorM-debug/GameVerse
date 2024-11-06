using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameVerse.Common.Enums;
using GameVerse.Web.ViewModels.Game.Details.Genres;
using GameVerse.Web.ViewModels.Game.Details.Platforms;
using GameVerse.Web.ViewModels.Game.Details.Restrictions;
using static GameVerse.Common.ApplicationConstants;
using static GameVerse.Common.ApplicationConstants.GameConstants;

namespace GameVerse.Web.ViewModels.Game
{
    public class GameInputViewModel
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string PublishingStudio { get; set; } = string.Empty;

        public int YearPublished { get; set; }

        public string CreatedOn { get; set; } = DateTime.Now.ToString(DateTimeFormat, CultureInfo.InvariantCulture);

        public decimal Price { get; set; }

        public string Image { get; set; } = string.Empty;

        public int QuantityInStock { get; set; }

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
