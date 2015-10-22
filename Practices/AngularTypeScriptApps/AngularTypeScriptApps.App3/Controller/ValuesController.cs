using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularTypeScriptApps.App3.Model;

namespace AngularTypeScriptApps.App3.Controller
{
    public class ValuesController : ApiController
    {
        public IHttpActionResult Get()
        {
            List<Student> students=new List<Student>();
            students.Add(new Student()
            {
                Id = 1,
                Name = "Lion",
                Address = "Africa",
                Phone = "L123"
            });
            return Ok(students);
        }
    }
}
