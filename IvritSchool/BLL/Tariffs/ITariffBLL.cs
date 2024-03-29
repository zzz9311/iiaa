﻿using IvritSchool.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvritSchool.BLL.Tariffs
{
    public interface ITariffBLL
    {
        public void Insert(Tariff tariff, string daysPredicate = null);
        public Tariff Get(int id);
        public void Edit(Tariff tariff, string daysPrecidate = null);
        public Tariff[] GetList();
        public void DeleteTariff(int id);
    }
}
