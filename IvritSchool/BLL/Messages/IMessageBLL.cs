﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvritSchool.BLL.Messages
{
    public interface IMessageBLL
    {
        public void Insert(Entities.Message message);
    }
}
