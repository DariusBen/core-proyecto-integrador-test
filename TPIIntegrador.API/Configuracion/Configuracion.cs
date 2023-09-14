
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using TPIIntegrador.Infraestructura.Contextos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TPIIntegrador.Infraestructura.Repositorios;
using TPIIntegrador.Dominio.Entidades;
using TPIIntegrador.Aplicacion.Servicios;
using TPIIntegrador.Dominio.Respositorios;
using TPIIntegrador.API.Filtros;

namespace TPIIntegrador.API.Configuracion
{
    public static class Configuracion
    {

        public static void ConfigurarControllers(this IServiceCollection services)
        {
            services.AddControllers()
                      .AddMvcOptions(cOpciones => cOpciones.Filters.Add<FiltroValidacion>())
                      .ConfigureApiBehaviorOptions(cOpciones => cOpciones.SuppressModelStateInvalidFilter = true);
        }

        public static void AgregarContextoBaseDeDatos(this IServiceCollection services, IConfiguration configuracion)
        {
            services.AddDbContext<AplicacionContext>(options => options.UseSqlServer(configuracion.GetConnectionString("ConnexionAzure")));
            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(configuracion.GetConnectionString("ConnexionAzure")));

        }


        public static void ConfigurarAutenticacion(this IServiceCollection services, IConfiguration configuracion)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuracion["JWT:ValidAudience"],
                    ValidIssuer = configuracion["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuracion["JWT:Secret"]))
                };
            });

        }

        public static void ConfigurarIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                        .AddEntityFrameworkStores<IdentityContext>()
                        .AddDefaultTokenProviders();

        }

        public static void InyectarDependencias(this IServiceCollection services)
        {
            services.AddScoped<IServicioDatosPrueba, ServicioDatosPrueba>();
            services.AddScoped<IRepositorio<Subasta>, Repositorio<Subasta>>();
            services.AddScoped<IServicioUsuario, ServicioUsuario>();
            services.AddScoped<IServicioSubasta, ServicioSubasta>();
        }

        public static void AgregarValidadores(this IServiceCollection services)
        {

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssembly(Assembly.Load("TPIIntegrador.Aplicacion"));
        }


        public static void AgregarCors(this IServiceCollection services)
        {
            services.AddCors(options => 
            {
                    options.AddPolicy("Politicas", app => { app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();});

            });

        }

    }
}
