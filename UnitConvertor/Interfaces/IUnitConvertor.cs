﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConvertor.Interfaces
{
    public interface IUnitConvertor
    {
        string Convert(string inputUnit, string outputUnit);
    }
}