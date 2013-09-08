using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RegisterStudents
{
    public partial class RegisterStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            HtmlGenericControl mainContainer = new HtmlGenericControl("div");

            HtmlGenericControl header = new HtmlGenericControl("h3");
            header.InnerText = "Registered student data";
            mainContainer.Controls.Add(header);

            HtmlGenericControl firstName = new HtmlGenericControl("p");
            firstName.InnerText = "First Name: " + this.TextBoxFirstName.Text; // Text box is cool and escapes the input
            mainContainer.Controls.Add(firstName);

            HtmlGenericControl lastName = new HtmlGenericControl("p");
            lastName.InnerText = "Last Name: " + this.TextBoxLastName.Text;
            mainContainer.Controls.Add(lastName);

            HtmlGenericControl facultyNumber = new HtmlGenericControl("p");
            facultyNumber.InnerText = "Faculty Number: " + this.TextBoxFacultyNumber.Text;
            mainContainer.Controls.Add(facultyNumber);

            HtmlGenericControl university = new HtmlGenericControl("p");
            university.InnerText = "University: " + this.DropDownListUniversities.SelectedValue;
            mainContainer.Controls.Add(university);

            HtmlGenericControl coursesLabel = new HtmlGenericControl("span");
            coursesLabel.InnerText = "Courses: ";
            mainContainer.Controls.Add(coursesLabel);

            HtmlGenericControl courses = new HtmlGenericControl("ul");
            var coursesCount = this.CkeckBoxListCourses.Items.Count;
            for (int i = 0; i < coursesCount; i++)
            {
                if (CkeckBoxListCourses.Items[i].Selected)
                {
                    HtmlGenericControl currentCourse = new HtmlGenericControl("li");
                    currentCourse.InnerText = this.CkeckBoxListCourses.Items[i].Text;
                    courses.Controls.Add(currentCourse);
                }
            }
            mainContainer.Controls.Add(courses);
            Controls.Add(mainContainer);
        }
    }
}