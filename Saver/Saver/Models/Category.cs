using Realms;
using System;

namespace Saver.Models
{
    public class Category : RealmObject
    {
        public string Name { get; set; }

        public Guid CategoryId { get; set; }

    }
}
