using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskForTrackItem.Models.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ImagePath { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int UnitID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
