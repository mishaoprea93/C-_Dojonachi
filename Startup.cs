using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dojonachi {
    public class Startup {
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ();
            services.AddSession ();
        }
        public void Configure (IApplicationBuilder app) {
            app.UseSession ();
            app.UseStaticFiles ();
            app.UseMvc ();
        }

    }
}