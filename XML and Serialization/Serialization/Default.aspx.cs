using Serialization.BusinessLayer;
using Serialization.DataLayer;
using System;
using System.Collections.Generic;

namespace Serialization
{
    public partial class Default : System.Web.UI.Page
    {
        Student stud;

        List<Student> students;

        protected void Page_Load(object sender, EventArgs e)
        {
            stud = new Student(21, "John Miller", 84);

            students = new List<Student>();
            students.Add(new Student(51, "ABC User", 78));
            students.Add(new Student(45, "FGH User", 67));
            students.Add(new Student(27, "XYZ User", 94));
        }

        protected void btnShowBeforeSerialization_Click(object sender, EventArgs e)
        {
            //show object state before serialization
            Response.Write("<h2>Student Object state before serialization</h2>");
            Response.Write(string.Format("<br /> Roll No. : {0}", stud.RollNo));
            Response.Write(string.Format("<br /> Name : {0}", stud.Name));
            Response.Write(string.Format("<br /> Total Marks : {0}", stud.TotalMarks));
            Response.Write(string.Format("<br /> Grade : {0}", stud.Grade));
        }

        protected void btnBinarySerialize_Click(object sender, EventArgs e)
        {
            //Call SerializeBinary() method to serialize
            bool result = UtilityFunctions.SerializeBinary(stud, Server.MapPath(Strings.BinaryFilePath));

            //check the status
            if (result)
            {
                Response.Write(Strings.BinarySuccess);
            }
            else
            {
                Response.Write(Strings.BinaryFailed);
            }
        }

        protected void btnShowAfterSerialization_Click(object sender, EventArgs e)
        {
            //Call DeserializeBinary() method to serialize
            Student deserializedStud = UtilityFunctions.DeserializeBinary(Server.MapPath(Strings.BinaryFilePath));

            //check the status
            if (deserializedStud == null)
            {
                Response.Write(Strings.DeserializationFailed);
            }
            else
            {
                //show object state before serialization
                Response.Write("<h2>Student Object state after Binary serialization</h2>");
                Response.Write(string.Format("<br /> Roll No. : {0}", deserializedStud.RollNo));
                Response.Write(string.Format("<br /> Name : {0}", deserializedStud.Name));
                Response.Write(string.Format("<br /> Total Marks : {0}", deserializedStud.TotalMarks));
                Response.Write(string.Format("<br /> Grade : {0}", deserializedStud.Grade));
            }
        }

        protected void btnSerializeXml_Click(object sender, EventArgs e)
        {
            //Call SerializeXml() method to serialize
            bool result = UtilityFunctions.SerializeXml(stud, Server.MapPath(Strings.XmlFilePath));

            //check the status
            if (result)
            {
                Response.Write(Strings.XmlSuccess);
            }
            else
            {
                Response.Write(Strings.XmlFailed);
            }
        }

        protected void ShowAfterSerializationXml_Click(object sender, EventArgs e)
        {
            //Call DeserializeXml() method to serialize
            Student deserializedStud = UtilityFunctions.DeserializeXml(Server.MapPath(Strings.XmlFilePath));

            //check the status
            if (deserializedStud == null)
            {
                Response.Write(Strings.DeserializationFailed);
            }
            else
            {
                //show object state before serialization
                Response.Write("<h2>Student Object state after XML serialization</h2>");
                Response.Write(string.Format("<br /> Roll No. : {0}", deserializedStud.RollNo));
                Response.Write(string.Format("<br /> Name : {0}", deserializedStud.Name));
                Response.Write(string.Format("<br /> Total Marks : {0}", deserializedStud.TotalMarks));
                Response.Write(string.Format("<br /> Grade : {0}", deserializedStud.Grade));
            }
        }

        protected void btnSerializeSoap_Click(object sender, EventArgs e)
        {
            //Call SerializeSoap() method to serialize
            bool result = UtilityFunctions.SerializeSoap(stud, Server.MapPath(Strings.SoapFilePath));

            //check the status
            if (result)
            {
                Response.Write(Strings.SoapSuccess);
            }
            else
            {
                Response.Write(Strings.SoapFailed);
            }
        }

        protected void ShowAfterSerializationSoap_Click(object sender, EventArgs e)
        {
            //Call DeserializeSoap() method to serialize
            Student deserializedStud = UtilityFunctions.DeserializeSoap(Server.MapPath(Strings.SoapFilePath));

            //check the status
            if (deserializedStud == null)
            {
                Response.Write(Strings.DeserializationFailed);
            }
            else
            {
                //show object state before serialization
                Response.Write("<h2>Student Object state after SOAP serialization</h2>");
                Response.Write(string.Format("<br /> Roll No. : {0}", deserializedStud.RollNo));
                Response.Write(string.Format("<br /> Name : {0}", deserializedStud.Name));
                Response.Write(string.Format("<br /> Total Marks : {0}", deserializedStud.TotalMarks));
                Response.Write(string.Format("<br /> Grade : {0}", deserializedStud.Grade));
            }
        }

        protected void btnShowListBeforeSerialization_Click(object sender, EventArgs e)
        {
            //show list before serialization
            Response.Write("<h2>Students List before serialization</h2>");

            foreach (Student student in students)
            {
                Response.Write(string.Format("<br /> Roll No. : {0}", student.RollNo));
                Response.Write(string.Format("<br /> Name : {0}", student.Name));
                Response.Write(string.Format("<br /> Total Marks : {0}", student.TotalMarks));
                Response.Write(string.Format("<br /> Grade : {0}<hr />", student.Grade));
            }
        }

        protected void btnBinarySerializeList_Click(object sender, EventArgs e)
        {
            //Call SerializeListBinary() method to serialize
            bool result = UtilityFunctions.SerializeListBinary(students, Server.MapPath(Strings.BinaryListFilePath));

            //check the status
            if (result)
            {
                Response.Write(Strings.BinarySuccess);
            }
            else
            {
                Response.Write(Strings.BinaryFailed);
            }
        }

        protected void btnShowListAfterSerialization_Click(object sender, EventArgs e)
        {
            //Call DeserializeListBinary() method to serialize
            List<Student> deserializedStud = UtilityFunctions.DeserializeListBinary(Server.MapPath(Strings.BinaryListFilePath));

            //check the status
            if (deserializedStud == null)
            {
                Response.Write(Strings.DeserializationFailed);
            }
            else
            {
                //show list before serialization
                Response.Write("<h2>Students List after Binary serialization</h2>");

                foreach (Student student in deserializedStud)
                {
                    Response.Write(string.Format("<br /> Roll No. : {0}", student.RollNo));
                    Response.Write(string.Format("<br /> Name : {0}", student.Name));
                    Response.Write(string.Format("<br /> Total Marks : {0}", student.TotalMarks));
                    Response.Write(string.Format("<br /> Grade : {0}<hr />", student.Grade));
                }
            }
        }

        protected void btnSerializeListXml_Click(object sender, EventArgs e)
        {
            //Call SerializeListXml() method to serialize
            bool result = UtilityFunctions.SerializeListXml(students, Server.MapPath(Strings.XmlListFilePath));

            //check the status
            if (result)
            {
                Response.Write(Strings.XmlSuccess);
            }
            else
            {
                Response.Write(Strings.XmlFailed);
            }
        }

        protected void btnShowListAfterSerializationXml_Click(object sender, EventArgs e)
        {

            //Call DeserializeListXml() method to serialize
            List<Student> deserializedStud = UtilityFunctions.DeserializeListXml(Server.MapPath(Strings.XmlListFilePath));

            //check the status
            if (deserializedStud == null)
            {
                Response.Write(Strings.DeserializationFailed);
            }
            else
            {
                //show list before serialization
                Response.Write("<h2>Students List after XML serialization</h2>");

                foreach (Student student in deserializedStud)
                {
                    Response.Write(string.Format("<br /> Roll No. : {0}", student.RollNo));
                    Response.Write(string.Format("<br /> Name : {0}", student.Name));
                    Response.Write(string.Format("<br /> Total Marks : {0}", student.TotalMarks));
                    Response.Write(string.Format("<br /> Grade : {0}<hr />", student.Grade));
                }
            }
        }

        protected void btnSerializeSoapList_Click(object sender, EventArgs e)
        {
            //Call SerializeListSoap() method to serialize
            bool result = UtilityFunctions.SerializeListSoap(students, Server.MapPath(Strings.SoapListFilePath));

            //check the status
            if (result)
            {
                Response.Write(Strings.SoapSuccess);
            }
            else
            {
                Response.Write(Strings.SoapFailed);
            }
        }

        protected void btnShowListAfterSerializationSoap_Click(object sender, EventArgs e)
        {
            //Call DeserializeListSoap() method to serialize
            List<Student> deserializedStud = UtilityFunctions.DeserializeListSoap(Server.MapPath(Strings.SoapListFilePath));

            //check the status
            if (deserializedStud == null)
            {
                Response.Write(Strings.DeserializationFailed);
            }
            else
            {
                //show list before serialization
                Response.Write("<h2>Students List after SOAP serialization</h2>");

                foreach (Student student in deserializedStud)
                {
                    Response.Write(string.Format("<br /> Roll No. : {0}", student.RollNo));
                    Response.Write(string.Format("<br /> Name : {0}", student.Name));
                    Response.Write(string.Format("<br /> Total Marks : {0}", student.TotalMarks));
                    Response.Write(string.Format("<br /> Grade : {0}<hr />", student.Grade));
                }
            }
        }



    }
}