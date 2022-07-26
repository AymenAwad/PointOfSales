﻿using Core.Entities;
using Core.Interfaces.BaseService;
using Core.Interfaces.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Permission
{
    public interface IRole : IBaseService<AspNetRole>
    {
    }
}
