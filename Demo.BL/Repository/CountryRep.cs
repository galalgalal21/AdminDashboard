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
    public class CountryRep : ICountryRep
    {
        private readonly DemoContext db;

        public CountryRep(DemoContext db)
        {
            this.db = db;
        }

        public IEnumerable<Country> Get()
        {
            var data = db.Country.Select(a => a);
            return data;
        }

        public Country GetById(int id)
        {
            var data = db.Country.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }

        
    }
}
