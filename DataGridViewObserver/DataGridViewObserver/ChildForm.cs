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
    public partial class ChildForm : Form, IObservable<User>
    {
        private User _user;
        IObserver<User> _observer;

        private ChildForm()
        {
            InitializeComponent();
        }

        public ChildForm(User user)
            : this()
        {
            this._user = user;
        }

        private void ChildForm_Load(object sender, EventArgs e)
        {
            this.TextBox_FirstName.Text = this._user.FirstName;
            this.TextBox_LastName.Text = this._user.LastName;
            this.TextBox_PhoneNumber.Text = this._user.PhoneNumber;
        }

        private void Button_Update_Click(object sender, EventArgs e)
        {
            this._user.FirstName = this.TextBox_FirstName.Text;
            this._user.LastName = this.TextBox_LastName.Text;
            this._user.PhoneNumber = this.TextBox_PhoneNumber.Text;
            Repository.Update(this._user);

            if (this._observer != null)
            {
                this._observer.OnNext(this._user);
            }

            this.Close();
        }

        #region IObservable<User> Members

        public IDisposable Subscribe(IObserver<User> observer)
        {
            this._observer = observer;
            return null;
        }

        #endregion
    }
}
