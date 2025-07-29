using itemTracker.DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskForTrackItem.Models.Models;

namespace itemTracker.BLL
{
    public class ItemService
    {
        private readonly ItemRepository _itemRepo = new ItemRepository();
        private readonly ItemLogRepository _logRepo = new ItemLogRepository();

        public void AddItem(Item item)
        {
            _itemRepo.AddItem(item);
           
        }

        public void UpdateItem(Item oldItem, Item updatedItem, int userId)
        {
         
            if (oldItem.ItemName != updatedItem.ItemName)
                AddLog(updatedItem.ItemID, "ItemName", oldItem.ItemName, updatedItem.ItemName, userId);

            if (oldItem.ImagePath != updatedItem.ImagePath)
                AddLog(updatedItem.ItemID, "ImagePath", oldItem.ImagePath, updatedItem.ImagePath, userId);

            if (oldItem.Size != updatedItem.Size)
                AddLog(updatedItem.ItemID, "Size", oldItem.Size, updatedItem.Size, userId);

            if (oldItem.Type != updatedItem.Type)
                AddLog(updatedItem.ItemID, "Type", oldItem.Type, updatedItem.Type, userId);

            if (oldItem.Description != updatedItem.Description)
                AddLog(updatedItem.ItemID, "Description", oldItem.Description, updatedItem.Description, userId);

            if (oldItem.UnitID != updatedItem.UnitID)
                AddLog(updatedItem.ItemID, "UnitID", oldItem.UnitID.ToString(), updatedItem.UnitID.ToString(), userId);

            _itemRepo.UpdateItem(updatedItem);
        }

        public Item GetItemById(int id)
        {
            return _itemRepo.GetItemById(id);
        }

        public List<Item> GetAllItems()
        {
            return _itemRepo.GetAllItems();
        }

        private void AddLog(int itemId, string field, string oldVal, string newVal, int userId)
        {
            var log = new ItemLog
            {
                ItemID = itemId,
                FieldChanged = field,
                OldValue = oldVal,
                NewValue = newVal,
                ModifiedBy = userId,
                ModifiedAt = DateTime.Now
            };

            _logRepo.AddLog(log);
        }
    }
}
