using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Profissionais.Data;
using Profissionais.Models.ModelsDb;
using Profissionais.Repositorios;

namespace Profissionais
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //Configurações de Compatibilidade
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //Configurando Strings de Conexão (...)

            //serviço de Usuaro padrão
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => options.LoginPath = "/Inicio/Inicio");
            services.AddIdentityCore<Usuarios>(I => new IdentityOptions
            {

            });
            //serviço de Usuaro padrão

            //Serviços transitorios -------
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<IProfissionaisRepository, ProfissionaisRepository>();
            services.AddTransient<IEspecialidadesRepository, EspecialidadesRepository>();
            services.AddTransient<IEnderecosRepository, EnderecosRepository>();
            services.AddTransient<IBuscaRepository, BuscaRepository>();
            services.AddTransient<IGaleriaRepository, GaleriaRepository>();
            services.AddTransient<IUsuariosRepository, UsuariosRepository>();
            //Serviços transitorios -------

            //ConfigurarContexto<AplicationDbContext>(services, "AzureSql");
            ConfigurarContexto<AplicationDbContext>(services, "SqlServer");
        }
        private void ConfigurarContexto<T>(IServiceCollection services, string nomeConexao) where T : DbContext
        {
            string connectionString = Configuration.GetConnectionString(nomeConexao);

            services.AddDbContext<T>(options =>
                options.UseSqlServer(connectionString)
            );
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Inicio}/{action=Inicio}/{id?}");
            });
        }
    }
}
