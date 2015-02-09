using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleWebApp;
using System.Web.UI.WebControls;

namespace SampleWebApp.Test
{
    [TestClass]
    public class UnitTest1 : Default
    {
        [TestMethod]
        public void TestBoundary()
        {
            double value;
            txtPercentage = new TextBox();
            txtPercentage.Text = "70";
            value = Convert.ToDouble(txtPercentage.Text);
            Assert.AreEqual(true, (value >= 0 && value <= 100));
        }

        [TestMethod]
        public void TestException()
        {
            try
            {
                double value;
                txtPercentage = new TextBox();

                txtPercentage.Text = "abc";
                value = Convert.ToDouble(txtPercentage.Text);
            }
            catch (Exception ex)
            {
                Assert.Fail("Found exception.");
            }
        }

        [TestMethod]
        public void TestPositive()
        {
            double value;
            txtPercentage = new TextBox();

            txtPercentage.Text = "170";
            value = Convert.ToDouble(txtPercentage.Text);
            Assert.AreEqual(true, (value <= 100));

        }
        [TestMethod]
        public void TestNegative()
        {
            double value;
            txtPercentage = new TextBox();

            txtPercentage.Text = "-4";
            value = Convert.ToDouble(txtPercentage.Text);
            Assert.AreEqual(true, (value >= 0));




        }

    }
}
