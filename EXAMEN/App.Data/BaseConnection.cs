﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class BaseConnection
    {
        public string GetConnection {
            get {
                string cnx = @"Data Source=MI607-ST\SQL2016PIVOT;
                            Initial Catalog=dbColegio;
                            User Id=colegio; 
                            Password=P@$$w0rd";
                return cnx;
            }
        }
    }
}
