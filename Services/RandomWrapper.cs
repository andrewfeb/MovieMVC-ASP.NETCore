﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMVC.Services
{
    public class RandomWrapper: IRandomWrapper
    {
        private IRandomService _randomService;

        public RandomWrapper(IRandomService randomService)
        {
            _randomService = randomService;
        }

        public int GetNumber()
        {
            return _randomService.GetNumber();
        }
    }
}
