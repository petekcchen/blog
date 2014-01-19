using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewObserver
{
    public partial class MainForm : Form, IObserver<User>
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.LoadLatestUsers();
        }

        private void DataGridView_Users_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            DataGridViewRow currentRow = this.DataGridView_Users.CurrentRow;

            User user = currentRow.DataBoundItem as User;

            if (user == null)
            {
                return;
            }

            ChildForm form = new ChildForm(user);
            form.Subscribe(this);
            form.ShowDialog();
        }

        private void LoadLatestUsers()
        {
            this.DataGridView_Users.DataSource = Repository.GetUsers();
        }

        #region IObserver<User> Members

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(User value)
        {
            this.LoadLatestUsers();
        }

        #endregion
    }
}
