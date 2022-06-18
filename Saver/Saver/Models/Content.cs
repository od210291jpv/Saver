using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saver.Models
{
    public class Content : RealmObject
    {
        public string Title { get; set; }

        public string ImageUri { get; set; }

        public Guid? CategoryId { get; set; }
    }
}
