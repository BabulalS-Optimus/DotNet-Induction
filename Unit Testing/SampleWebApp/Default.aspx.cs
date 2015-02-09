using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {

            double percentage;
            double.TryParse(txtPercentage.Text, out percentage);
            Response.Write(string.Format("Percentage : {0}", percentage));

        }
    }
}