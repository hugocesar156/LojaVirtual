using LojaVirtual.Data;
using LojaVirtual.Repositories;
using LojaVirtual.Scheduling;
using LojaVirtual.Sessions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Coravel;
using System;
using WSCorreios;

namespace LojaVirtual
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddHttpContextAccessor();
            services.AddScoped<Sessao>();

            services.AddLogging();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<DatabaseContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<UsuarioR>();
            services.AddScoped<ProdutoR>();
            services.AddScoped<ImagemR>();
            services.AddScoped<CarrinhoR>();
            services.AddScoped<FreteR>();
            services.AddScoped<ClienteR>();
            services.AddScoped<PedidoR>();

            services.AddScoped<CalcPrecoPrazoWSSoap>(options => {
                return new CalcPrecoPrazoWSSoapClient(CalcPrecoPrazoWSSoapClient.EndpointConfiguration.CalcPrecoPrazoWSSoap);
            });

            services.AddTransient<AtualizarPedido>();
            services.AddScheduler();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Erro/Mensagem");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            //Verifica pedidos aguardando pagamento
            app.ApplicationServices.UseScheduler(scheduler => {
                scheduler.Schedule<AtualizarPedido>().EveryFifteenMinutes();
            });

            //Verifica se produtos de pedidos foram entregues
            app.ApplicationServices.UseScheduler(scheduler => {
                scheduler.Schedule<AtualizarProduto>().DailyAtHour(12);
            });

            //Libera produtos de pedidos para envio
            app.ApplicationServices.UseScheduler(scheduler => {
                scheduler.Schedule<EnviarProduto>().Hourly();
            });

            //Vefifica se pedido está finalizado
            app.ApplicationServices.UseScheduler(scheduler => {
                scheduler.Schedule<FinalizarPedido>().Hourly();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Inicio}/{id?}");
            });
        }
    }
}
