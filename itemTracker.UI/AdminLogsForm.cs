using itemTracker.BLL;
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
    public partial class AdminLogsForm : Form
    {
        private readonly LogService _logService = new LogService();
        private readonly User _currentUser;
        public AdminLogsForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            LoadLogs();
        }

        private void LoadLogs()
        {
            var logs = _logService.GetAllLogs();
            dgvLogs.DataSource = logs;
        }
    }
}
