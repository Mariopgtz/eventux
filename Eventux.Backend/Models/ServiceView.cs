using Eventux.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eventux.Backend.Models
{
    public class ServiceView : Servicios
    {
        public HttpPostedFileBase ImageFile { get; set; }
    }
}