using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FBV.Objects
{
    public class MediaItem : OrderItem
    {
        public MediaItemTypes mediaItemType { get; set; }
    }
}
