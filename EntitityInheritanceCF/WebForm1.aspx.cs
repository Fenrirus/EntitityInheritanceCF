using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EntitityInheritanceCF
{
    public partial class WebForm1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private DataTable Dane(List<Employee> employees)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("Gender");
            dt.Columns.Add("AnuualSalary");
            dt.Columns.Add("HourlyPay");
            dt.Columns.Add("HoursWorked");
            dt.Columns.Add("Type");
            foreach(Employee employee in employees)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = employee.ID;
                dr["FirstName"] = employee.FirstName;
                dr["LastName"] = employee.LastName;
                dr["Gender"] = employee.Gender;

                if (employee is PermanentEmployee)
                {
                    dr["AnuualSalary"] = ((PermanentEmployee)employee).AnnualSalary;
                    dr["Type"] = "Permanent";
                }
                else
                {
                    dr["HourlyPay"] = ((ContractEmployee)employee).HourlyPay;
                    dr["HoursWorked"] = ((ContractEmployee)employee).HoursWorked;
                    dr["Type"] = "Contract";
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pokazpola();
        }

        private void pokazpola()
        {
            EmployeeDbcontext db = new EmployeeDbcontext();
            switch (RadioButtonList1.SelectedValue)
            {
                case "Permament":
                    {
                        GridView1.DataSource = db.Employees.OfType<PermanentEmployee>().ToList();
                        GridView1.DataBind();
                        break;
                    }
                case "Contract":
                    {
                        GridView1.DataSource = db.Employees.OfType<ContractEmployee>().ToList();
                        GridView1.DataBind();
                        break;
                    }
                default:
                    {
                        GridView1.DataSource = Dane(db.Employees.ToList());
                        GridView1.DataBind();
                        break;
                    }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            EmployeeDbcontext db = new EmployeeDbcontext();
            PermanentEmployee pe = new PermanentEmployee()
            {

                FirstName = "Mike",
                LastName = "Brown",
                Gender = "Male",
                AnnualSalary = 70000,

        };
            db.Employees.Add(pe);
            db.SaveChanges();
            pokazpola();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EmployeeDbcontext db = new EmployeeDbcontext();
            ContractEmployee ce = new ContractEmployee()
            {
                FirstName = "Stacy",
                LastName = "Josh",
                Gender = "Female",
                HourlyPay = 50,
                HoursWorked = 120
            };
            db.Employees.Add(ce);
            db.SaveChanges();
            pokazpola();
        }
    }
}