﻿using Demo.BL.Interface;
using Demo.DAL.Database;
using Demo.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repository
{
    public class EmployeeRep : IEmployeeRep
    {
        private readonly DemoContext db;

        public EmployeeRep(DemoContext db)
        {
            this.db = db;
        }

        public IEnumerable<Employee> Get()
        {
            var data = db.Employee.Include("Department").Select(a => a);
            return data;
        }

        public Employee GetById(int id)
        {
            var data = db.Employee.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }

        public Employee Create(Employee obj)
        {


            db.Employee.Add(obj);
            db.SaveChanges();
            return db.Employee.OrderBy(a => a.Id).LastOrDefault();
        }

        public Employee Edit(Employee obj)
        {
            db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();
            return db.Employee.Find(obj.Id);
        }

        public void Delete(Employee obj)
        {
            db.Employee.Remove(obj);
            db.SaveChanges();
        }

        public IEnumerable<Employee> SearchByName(string Name)
        {
            var data = db.Employee.Include("Department").Where(a => a.Name.Contains(Name));
            return data;
        }
    }
}
