﻿using QuizzerAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace QuizzerAPI
{
    public class Service1 : IService1
    {
        public IEnumerable<Quiz> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
