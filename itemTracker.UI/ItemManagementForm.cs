using itemTracker.BLL;
using itemTracker.DAL.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using taskForTrackItem.Models.Models;

namespace itemTracker.UI
{
    public partial class ItemManagementForm : Form
    {
        private readonly UnitRepository _unitRepo = new UnitRepository();
        private readonly ItemService _itemService = new ItemService();
        private readonly User _loggedInUser;
        private string _selectedImagePath;
        private Item _selectedItem;

        public ItemManagementForm(User user)
        {
            InitializeComponent();
          
            _loggedInUser = user;
            LoadUnits();
            LoadItems();
        }

        private void LoadUnits()
        {
            var units = _unitRepo.GetAllUnits();
            cmbUnits.DataSource = units;
            cmbUnits.DisplayMember = "UnitName";
            cmbUnits.ValueMember = "UnitID";
        }

        private void LoadItems()
        {
            var items = _itemService.GetAllItems();
            dgvItems.DataSource = items;
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _selectedImagePath = dialog.FileName;
                picItemImage.Image = Image.FromFile(_selectedImagePath);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Please enter item name.");
                return;
            }

            var newItem = new Item
            {
                ItemName = txtItemName.Text,
                ImagePath = _selectedImagePath,
                Size = txtSize.Text,
                Type = txtType.Text,
                Description = txtDescription.Text,
                UnitID = (int)cmbUnits.SelectedValue,
                CreatedBy = _loggedInUser.UserID
            };

            if (_selectedItem == null)
            {
                
                _itemService.AddItem(newItem);
                MessageBox.Show("Item added successfully!");
            }
            else
            {
                
                newItem.ItemID = _selectedItem.ItemID;

                var oldItem = _itemService.GetItemById(_selectedItem.ItemID);

                _itemService.UpdateItem(oldItem, newItem, _loggedInUser.UserID);
                MessageBox.Show("Item updated successfully!");

                _selectedItem = null;
                btnSave.Text = "Save"; 
            }

            ClearForm();
            LoadItems();
        }


        private void ClearForm()
        {
            txtItemName.Text = "";
            txtSize.Text = "";
            txtType.Text = "";
            txtDescription.Text = "";
            cmbUnits.SelectedIndex = 0;
            picItemImage.Image = null;
            _selectedImagePath = null;
        }

       


        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvItems.Rows[e.RowIndex];
                _selectedItem = (Item)row.DataBoundItem;

                txtItemName.Text = _selectedItem.ItemName;
                txtSize.Text = _selectedItem.Size;
                txtType.Text = _selectedItem.Type;
                txtDescription.Text = _selectedItem.Description;
                cmbUnits.SelectedValue = _selectedItem.UnitID;
                picItemImage.ImageLocation = _selectedItem.ImagePath;
                _selectedImagePath = _selectedItem.ImagePath;

                btnSave.Text = "Update";
            }
        }
    }
}
