using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZenDeskApi.XmlSerializers;

namespace ZenDeskApi.Model
{
    [ZenDeskSerialization(Name = "organization")]
    public class Organization
    {
        [ZenDeskSerialization(Name = "id")]
        public int Id { get; set; }

        [ZenDeskSerialization(Name = "name")]
        public string Name { get; set; }

        [ZenDeskSerialization(Name = "is-shared")]
        public bool IsShared { get; set; }

        [ZenDeskSerialization(Name = "default")]
        public string Default { get; set; }

        [ZenDeskSerialization(Name = "users")]
        public List<User> Users { get; set; }

        [ZenDeskSerialization(Name = "set-tags")]
        public string SetTags { get; set; }

        [ZenDeskSerialization(Name = "created-at")]
        public DateTime CreatedAt { get; set; }

        [ZenDeskSerialization(Name = "group-id")]
        public int GroupId { get; set; }
        
        [ZenDeskSerialization(Name = "is-shared-comments")]
        public bool IsSharedComments { get; set; }
        
        [ZenDeskSerialization(Name = "notes")]
        public string Notes { get; set; }

        [ZenDeskSerialization(Name = "suspended")]
        public bool IsSuspended { get; set; }
        
        [ZenDeskSerialization(Name = "updated-at", Skip = true)]
        public DateTime UpdatedAt { get; set; }
        
        [ZenDeskSerialization(Name = "current-tags", Skip = true)]
        public string CurrentTags { get; set; }
    }
}
