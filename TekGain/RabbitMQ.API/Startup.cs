using Microsoft.OpenApi.Models;
using RabbitMQ.Client;
using Steeltoe.Discovery.Client;

namespace RabbitMQ.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDiscoveryClient(Configuration);
            services.AddControllers();
            services.AddSingleton<IConnection>(provider =>
            {
                var factory = new ConnectionFactory
                {
                    HostName = "localhost", // Replace with your RabbitMQ server hostname
                    UserName = "guest", // Replace with your RabbitMQ username
                    Password = "guest" // Replace with your RabbitMQ password
                };
                return factory.CreateConnection();
            });

            services.AddScoped<IModel>(provider =>
            {
                var connection = provider.GetRequiredService<IConnection>();
                return connection.CreateModel();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RabbitMQ.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RabbitMQ.API"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}