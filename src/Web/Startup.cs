// Copyright (c) .NET Foundation and contributors. All rights reserved. Licensed under the Microsoft Reciprocal License. See LICENSE.TXT file in the project root for full license information.

namespace WixToolset.Web
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Rewrite;
    using Microsoft.AspNetCore.StaticFiles;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Net.Http.Headers;
    using WixToolset.Web.Services;

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        private IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = this.Configuration.GetConnectionString("AzureStorageAccount");

            services.AddScoped<IStorageService>(s => new StorageService(connectionString));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/statuscode/500/");
            }

            app.UseForwardedHeaders();

            app.UseRewriter(this.LoadRewrites());

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme,
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                CookieName = "wu",
            });

            app.UseDefaultFiles(new DefaultFilesOptions
            {
                DefaultFileNames = new[] { "index.html", "index.feed" }
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = StaticContentTypes(),

                OnPrepareResponse = context =>
                {
                    var headers = context.Context.Response.GetTypedHeaders();
                    headers.CacheControl = new CacheControlHeaderValue { MaxAge = TimeSpan.FromDays(1), Public = true };
                }
            });

            app.UseStatusCodePagesWithReExecute("/statuscode/{0}/");

            app.UseMvc();
        }

        private RewriteOptions LoadRewrites()
        {
            var options = new RewriteOptions();

            foreach (var redir in this.Configuration.GetSection("Redirects").Get<IConfigurationSection[]>())
            {
                var y = redir.GetChildren().First();

                var source = y.Key;
                var target = y.Value;

                source = source.StartsWith("^") ? source : source.StartsWith("*") ? source.TrimStart('*') : "^" + source;
                source = source.EndsWith("$") ? source : source.EndsWith("*") ? source.TrimEnd('*') : source + @"/?$";

                options.AddRedirect(source, target, StatusCodes.Status301MovedPermanently);
            }

            return options;
        }

        private static FileExtensionContentTypeProvider StaticContentTypes()
        {
            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".feed"] = "application/atom+xml";
            provider.Mappings[".wxl"] = "application/xml";
            provider.Mappings[".vbs"] = "text/plain";

            return provider;
        }
    }
}
