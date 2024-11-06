using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameVerse.Web.ViewModels.Game
{
    public class GameDeleteViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string PublisherId { get; set; } = null!;

        public string PublisherName { get; set;} = null!;
    }
}
