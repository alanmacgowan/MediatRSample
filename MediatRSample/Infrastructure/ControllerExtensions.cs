﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRSample.Infrastructure
{
    public static class ControllerExtensions
    {
        public static ActionResult RedirectToActionJson<TController>(this TController controller, string action)
            where TController : Controller
        {
            return controller.JsonNet(new
            {
                redirect = controller.Url.Action(action)
            }
            );
        }

        public static ContentResult JsonNet(this Controller controller, object model)
        {
            var serialized = JsonConvert.SerializeObject(model, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return new ContentResult
            {
                Content = serialized,
                ContentType = "application/json"
            };
        }
    }

}
