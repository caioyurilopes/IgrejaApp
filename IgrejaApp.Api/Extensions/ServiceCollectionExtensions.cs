namespace IgrejaApp.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSection = configuration.GetSection("JwtSettings");
        services.Configure<JwtSettings>(jwtSection);
        services.Configure<ApiSecurityOptions>(configuration.GetSection("ApiSecurity"));

        var jwt = jwtSection.Get<JwtSettings>()!;
        var key = Encoding.UTF8.GetBytes(jwt.SecretKey);

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwt.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwt.Audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

        services.AddAuthorization();

        services.AddDataServices(configuration);
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IMembrosService, MembrosService>();
        services.AddHttpClient<ICepService, CepService>();
        services.AddScoped<TokenService>();
        return services;
    }
}