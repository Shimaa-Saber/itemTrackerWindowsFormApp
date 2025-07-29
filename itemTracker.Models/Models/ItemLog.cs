using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskForTrackItem.Models.Models
{
    //public enum ActionTypeEnum
    //{
    //    Add,
    //    Update
    //}

    public class ItemLog
    {
        public int LogID { get; set; }
        public int ItemID { get; set; }
        public string FieldChanged { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ItemName { get; set; }
        public string ActionType { get; set; }
        public DateTime ActionDate { get; set; }
        public string UserName { get; set; }
    }

}
