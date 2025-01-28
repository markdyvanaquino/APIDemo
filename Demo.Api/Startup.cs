using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Demo.Api.Services;
using Demo.Api.Models;

[assembly: OwinStartup(typeof(Demo.Api.Startup))]

namespace Demo.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
