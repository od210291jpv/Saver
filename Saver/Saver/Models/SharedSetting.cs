using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saver.Models
{
    public class SharedSetting : RealmObject
    {
        public Guid SettingGuid { get; private set; }

        public string Name { get; set; }

        public bool Param { get; set; }

        public SharedSetting()
        {
            this.SettingGuid = Guid.NewGuid();
        }
    }
}
