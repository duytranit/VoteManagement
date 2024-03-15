using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;

namespace VoteManagement.Models.Entities
{
    public class Department
    {
        public Department() { }
        public IEnumerable<Models.Department> Departments { get 
            {
                Models.VoteManagementEntities db = new VoteManagementEntities();
                return db.Departments;
            } 
        }

        public void Insert(string _name, bool _status)
        {
            Models.VoteManagementEntities db = new VoteManagementEntities();
            Models.Department department = new Models.Department();
            department.Name = _name;
            department.Status = _status;
            db.Departments.Add(department);
            db.SaveChanges();
            db.Dispose();
        }

        public void Update(int _departmentID, string _name, bool _status)
        {
            Models.VoteManagementEntities db = new Models.VoteManagementEntities();
            Models.Department department = db.Departments.FirstOrDefault(x => x.ID == _departmentID);
            department.Name = _name;
            department.Status = _status;
            db.SaveChanges();
            db.Dispose();
        }

        public void Delete(int _departmentID)
        {
            Models.VoteManagementEntities db = new VoteManagementEntities();
            Models.Department department =  db.Departments.FirstOrDefault(x => x.ID == _departmentID);
            db.Departments.Remove(department);
            db.SaveChanges();
            db.Dispose();
        }
        public Models.Department Find(int _departmentID)
        {
            Models.VoteManagementEntities db = new VoteManagementEntities();
            return db.Departments.FirstOrDefault(x => x.ID == _departmentID);
        }

        public void Load_AllDepartment_RadComboBox(RadComboBox _cbb)
        {
            _cbb.DataSource = this.Departments.ToList();
            _cbb.DataValueField = "ID";
            _cbb.DataTextField = "Name";
            _cbb.DataBind();
        }
        public void Load_AllDepartment_RadGrid(RadGrid _rg)
        {
            _rg.DataSource = this.Departments.ToList();
        }
    }
}