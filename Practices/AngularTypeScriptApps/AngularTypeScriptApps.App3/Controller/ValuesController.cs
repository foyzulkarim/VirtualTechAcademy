﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularTypeScriptApps.App3.Controller
{
    public class ValuesController : ApiController
    {
        public string Get()
        {
            return DateTime.Now.ToString();
        }
    }
}
