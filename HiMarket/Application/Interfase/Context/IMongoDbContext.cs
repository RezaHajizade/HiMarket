﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfase.Context
{
    public interface IMongoDbContext<T> 
    {

        public IMongoCollection<T> GetCollection(); 
    }
}
