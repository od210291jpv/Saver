using Realms;
using System;

namespace Saver.Models
{
    public class FavoriteCategory : RealmObject
    {
        public bool IsFavorite { get; set; }

        public Guid CategoryId { get; set; }
    }
}
