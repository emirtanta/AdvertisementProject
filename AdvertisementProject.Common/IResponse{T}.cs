﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementProject.Common
{
    public interface IResponse<T>:IResponse
    {
        T Data { get; set; }

        public List<CustomValidationError> ValidationErrors { get; set; }
    }
}
