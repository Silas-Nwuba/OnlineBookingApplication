using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineBookingApplication.Persistence;
using ProjectServices;
using ProjectServices.ApIService;
using ProjectServices.ApIService.Implementation;
using ProjectServices.CustomerImplementation;
using ProjectServices.Implementation;
using System;

namespace OnlineBookingApplication
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
           
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddDefaultUI()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllers();
            //Making THE login to be the default page
            services.AddControllersWithViews().AddRazorPagesOptions(options => {
            options.Conventions.AddAreaPageRoute("Identity","/Account/Login","");
            
            });//end here
            services.AddRazorPages();
            services.AddScoped<ICustomer, CustomerImplementation>();
            services.AddScoped<IBookingRecord,BookingImplementation>();
            services.AddScoped<ITransactionAmount, ITransactionImplentation>();
            services.AddScoped<ICardPayment, CardPayment>();
            services.AddScoped<ICharges, ChargesImplementation>();
            services.AddScoped<ITicketType,TicketReductionImplementation>();
            services.AddScoped<IPayment, paymentImplementation>();
            //Adding Dependecy for Api
            services.AddScoped<ICustomerApi, ApiCustomer>();
            services.AddScoped<IBookingApi, ApiBooking>();
           //end here


            services.Configure<IdentityOptions>(options =>
            {
                //configure default Password
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredUniqueChars = 1;

                //configure default lockout 
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
                options.Lockout.MaxFailedAccessAttempts = 5;

                
            });
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //Added the UserManager And RoleManager in the Method
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Microsoft.AspNetCore.Identity.UserManager<IdentityUser>userManager, Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            //calling the UserManger and RoleManager used for Authentication
            DataSeeding.RoleAndUser(userManager,roleManager).Wait();//Ends here
            app.UseAuthorization();
            //Default End Point 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            //Endpoint for Api 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
