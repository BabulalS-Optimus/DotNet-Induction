using System;
using MvpPattern.View;

namespace MvpPattern
{
    public partial class Default : System.Web.UI.Page, IView
    {

        /// <summary>
        /// Public variable can be accessed by View
        /// </summary>
        #region IView Members
        public string Label
        {
            get
            {
                return lblInstruction.Text;
            }
            set
            {
                lblInstruction.Text = value;
            }
        }

        public string TextBox
        {
            get
            {
                return txtMessage.Text;
            }
            set
            {
                txtMessage.Text = value;
            }
        }
        #endregion

        /// <summary>
        /// Click event for btnGo
        /// </summary>
        /// <param name="sender">Control object on which event has occured</param>
        /// <param name="e">Args for event</param>
        protected void btnGo_Click(object sender, EventArgs e)
        {
            //Setting up the values over Controls on view
            MvpPattern.Presenter.Presenter p = new MvpPattern.Presenter.Presenter(this, new MvpPattern.Model.Model());
            p.BindModelView();
        }
    }
}