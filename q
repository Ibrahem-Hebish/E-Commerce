warning: in the working copy of 'ECommerce.Api/obj/Debug/net8.0/EndpointInfo/ECommerce.Api.json', LF will be replaced by CRLF the next time Git touches it
[1mdiff --git a/ECommerce.Api/AppExtentions.cs b/ECommerce.Api/AppExtentions.cs[m
[1mindex dcc6044..126ff3c 100644[m
[1m--- a/ECommerce.Api/AppExtentions.cs[m
[1m+++ b/ECommerce.Api/AppExtentions.cs[m
[36m@@ -1,4 +1,6 @@[m
[31m-﻿namespace ECommerce.Api;[m
[32m+[m[32m﻿using Hangfire;[m
[32m+[m
[32m+[m[32mnamespace ECommerce.Api;[m
 [m
 public static class AppExtentions[m
 {[m
[36m@@ -22,8 +24,12 @@[m [mpublic static class AppExtentions[m
 [m
         app.UseHttpsRedirection();[m
 [m
[32m+[m[32m        app.UseAuthentication();[m
[32m+[m
         app.UseAuthorization();[m
 [m
[32m+[m[32m        app.UseHangfireDashboard("/hangfire");[m
[32m+[m
         app.MapControllers();[m
 [m
     }[m
[1mdiff --git a/ECommerce.Api/DependencyInjection.cs b/ECommerce.Api/DependencyInjection.cs[m
[1mindex ccde27f..82a462f 100644[m
[1m--- a/ECommerce.Api/DependencyInjection.cs[m
[1m+++ b/ECommerce.Api/DependencyInjection.cs[m
[36m@@ -1,5 +1,4 @@[m
[31m-﻿using ECommerce.Infrustructure.Persistance.Interceptors;[m
[31m-using Microsoft.EntityFrameworkCore;[m
[32m+[m[32m﻿using Microsoft.EntityFrameworkCore;[m
 [m
 namespace ECommerce.Api;[m
 [m
[36m@@ -10,8 +9,7 @@[m [mpublic static class DependencyInjection[m
 [m
         services.AddDbContext<AppDbContext>(opt =>[m
         {[m
[31m-            opt.UseSqlServer(configuration.GetConnectionString("ConnectionString"))[m
[31m-                .AddInterceptors(new SoftDeleteInterceptor());[m
[32m+[m[32m            opt.UseSqlServer(configuration.GetConnectionString("ConnectionString"));[m
         });[m
 [m
         services.AddControllers();[m
[1mdiff --git a/ECommerce.Api/ECommerce.Api.csproj b/ECommerce.Api/ECommerce.Api.csproj[m
[1mindex 3975ede..dbda4f4 100644[m
[1m--- a/ECommerce.Api/ECommerce.Api.csproj[m
[1m+++ b/ECommerce.Api/ECommerce.Api.csproj[m
[36m@@ -4,6 +4,7 @@[m
     <TargetFramework>net8.0</TargetFramework>[m
     <Nullable>enable</Nullable>[m
     <ImplicitUsings>enable</ImplicitUsings>[m
[32m+[m[32m    <UserSecretsId>7d543a5b-73f4-4195-b1fe-289e8fdf6243</UserSecretsId>[m
   </PropertyGroup>[m
 [m
   <ItemGroup>[m
[36m@@ -14,10 +15,6 @@[m
     <PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2" />[m
   </ItemGroup>[m
 [m
[31m-  <ItemGroup>[m
[31m-    <Folder Include="Controllers\" />[m
[31m-  </ItemGroup>[m
[31m-[m
   <ItemGroup>[m
     <ProjectReference Include="..\ECommerce.Applcation\ECommerce.Application.csproj" />[m
     <ProjectReference Include="..\ECommerce.Infrustructure\ECommerce.Infrustructure.csproj" />[m
[1mdiff --git a/ECommerce.Api/ECommerce.Api.csproj.user b/ECommerce.Api/ECommerce.Api.csproj.user[m
[1mindex 9ff5820..2c8f5c1 100644[m
[1m--- a/ECommerce.Api/ECommerce.Api.csproj.user[m
[1m+++ b/ECommerce.Api/ECommerce.Api.csproj.user[m
[36m@@ -2,5 +2,7 @@[m
 <Project ToolsVersion="Current" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">[m
   <PropertyGroup>[m
     <ActiveDebugProfile>https</ActiveDebugProfile>[m
[32m+[m[32m    <Controller_SelectedScaffolderID>ApiControllerEmptyScaffolder</Controller_SelectedScaffolderID>[m
[32m+[m[32m    <Controller_SelectedScaffolderCategoryPath>root/Common/Api</Controller_SelectedScaffolderCategoryPath>[m
   </PropertyGroup>[m
 </Project>[m
\ No newline at end of file[m
[1mdiff --git a/ECommerce.Api/GlobalUsing.cs b/ECommerce.Api/GlobalUsing.cs[m
[1mindex 072fa0d..530733a 100644[m
[1m--- a/ECommerce.Api/GlobalUsing.cs[m
[1m+++ b/ECommerce.Api/GlobalUsing.cs[m
[36m@@ -1,6 +1,16 @@[m
 ﻿global using ECommerce.Api;[m
[32m+[m[32mglobal using ECommerce.Application.Features.Authentication.Login;[m
[32m+[m[32mglobal using ECommerce.Application.Features.Authentication.RefreshToken;[m
[32m+[m[32mglobal using ECommerce.Application.Features.Authentication.Register;[m
[32m+[m[32mglobal using ECommerce.Application.Features.Users.ActivateUser;[m
[32m+[m[32mglobal using ECommerce.Application.Features.Users.DeactivateUser;[m
[32m+[m[32mglobal using ECommerce.Application.Features.Users.GetAllUsers;[m
[32m+[m[32mglobal using ECommerce.Application.Features.Users.GetUserById;[m
[32m+[m[32mglobal using ECommerce.Application.Features.Users.UpdateUser;[m
 global using ECommerce.Application.Services.PasswordHashing;[m
[31m-global using ECommerce.Application.Services.UnitOfWork;[m
 global using ECommerce.Infrustructure.Persistance.AppContext;[m
 global using ECommerce.Infrustructure.Persistance.Seeders;[m
[31m-global using ECommerce.Infrustructure.Persistance.UnitOfWork;[m
[32m+[m[32mglobal using MediatR;[m
[32m+[m[32mglobal using Microsoft.AspNetCore.Authorization;[m
[32m+[m[32mglobal using Microsoft.AspNetCore.Mvc;[m
[32m+[m[32mglobal using System.Security.Claims;[m
[1mdiff --git a/ECommerce.Api/Program.cs b/ECommerce.Api/Program.cs[m
[1mindex ebe7f3e..6623498 100644[m
[1m--- a/ECommerce.Api/Program.cs[m
[1m+++ b/ECommerce.Api/Program.cs[m
[36m@@ -1,9 +1,14 @@[m
[32m+[m[32musing ECommerce.Application;[m
 using ECommerce.Infrustructure;[m
 [m
 var builder = WebApplication.CreateBuilder(args);[m
 [m
[32m+[m[32mbuilder.Configuration.AddUserSecrets(typeof(Program).Assembly);[m
[32m+[m
 builder.Services.AddInfrustructure();[m
 [m
[32m+[m[32mbuilder.Services.AddApplication();[m
[32m+[m
 builder.Services.AddWeb(builder.Configuration);[m
 [m
 var app = builder.Build();[m
[1mdiff --git a/ECommerce.Api/bin/Debug/net8.0/ECommerce.Api.deps.json b/ECommerce.Api/bin/Debug/net8.0/ECommerce.Api.deps.json[m
[1mindex 4953588..9afa63b 100644[m
[1m--- a/ECommerce.Api/bin/Debug/net8.0/ECommerce.Api.deps.json[m
[1m+++ b/ECommerce.Api/bin/Debug/net8.0/ECommerce.Api.deps.json[m
[36m@@ -17,6 +17,19 @@[m
           "ECommerce.Api.dll": {}[m
         }[m
       },[m
[32m+[m[32m      "AutoMapper/15.1.0": {[m
[32m+[m[32m        "dependencies": {[m
[32m+[m[32m          "Microsoft.Extensions.Logging.Abstractions": "9.0.10",[m
[32m+[m[32m          "Microsoft.Extensions.Options": "9.0.10",[m
[32m+[m[32m          "Microsoft.IdentityModel.JsonWebTokens": "8.14.0"[m
[32m+[m[32m        },[m
[32m+[m[32m        "runtime": {[m
[32m+[m[32m          "lib/net8.0/AutoMapper.dll": {[m
[32m+[m[32m            "assemblyVersion": "15.0.0.0",[m
[32m+[m[32m            "fileVersion": "15.1.0.0"[m
[32m+[m[32m          }[m
[32m+[m[32m        }[m
[32m+[m[32m      },[m
       "Azure.Core/1.47.1": {[m
         "dependencies": {[m
           "Microsoft.Bcl.AsyncInterfaces": "8.0.0",[m
[36m@@ -60,6 +73,117 @@[m
           }[m
         }[m
       },[m
[32m+[m[32m      "FluentValidation/12.1.0": {[m
[32m+[m[32m        "runtime": {[m
[32m+[m[32m          "lib/net8.0/FluentValidation.dll": {[m
[32m+[m[32m            "assemblyVersion": "12.0.0.0",[m
[32m+[m[32m            "fileVersion": "12.1.0.0"[m
[32m+[m[32m          }[m
[32m+[m[32m        }[m
[32m+[m[32m      },[m
[32m+[m[32m      "FluentValidation.DependencyInjectionExtensions/12.1.0": {[m
[32m+[m[32m        "dependencies": {[m
[32m+[m[32m          "FluentValidation": "12.1.0",[m
[32m+[m[32m          "Microsoft.Extensions.DependencyInjection.Abstractions": "9.0.10"[m
[32m+[m[32m        },[m
[32m+[m[32m        "runtime": {[m
[32m+[m[32m          "lib/net8.0/FluentValidation.DependencyInjectionExtensions.dll": {[m
[32m+[m[32m            "assemblyVersion": "12.0.0.0",[m
[32m+[m[32m            "fileVersion": "12.1.0.0"[m
[32m+[m[32m          }[m
[32m+[m[32m        }[m
[32m+[m[32m      },[m
[32m+[m[32m      "Hangfire.AspNetCore/1.8.22": {[m
[32m+[m[32m        "dependencies": {[m
[32m+[m[32m          "Hangfire.NetCore": "1.8.22"[m
[32m+[m[32m        },[m
[32m+[m[32m        "runtime": {[m
[32m+[m[32m          "lib/netcoreapp3.0/Hangfire.AspNetCore.dll": {[m
[32m+[m[32m            "assemblyVersion": "1.8.22.0",[m
[32m+[m[32m            "fileVersion": "1.8.22.0"[m
[32m+[m[32m          }[m
[32m+[m[32m        }[m
[32m+[m[32m      },[m
[32m+[m[32m      "Hangfire.Core/1.8.22": {[m
[32m+[m[32m        "dependencies": {[m
[32m+[m[32m          "Newtonsoft.Json": "11.0.1"[m
[32m+[m[32m        },[m
[32m+[m[32m        "runtime": {[m
[32m+[m[32m          "lib/netstandard2.0/Hangfire.Core.dll": {[m
[32m+[m[32m            "assemblyVersion": "1.8.22.0",[m
[32m+[m[32m            "fileVersion": "1.8.22.0"[m
[32m+[m[32m          }[m
[32m+[m[32m        },[m
[32m+[m[32m        "resources": {[m
[32m+[m[32m          "lib/netstandard2.0/ca/Hangfire.Core.resources.dll": {[m
[32m+[m[32m            "locale": "ca"[m
[32m+[m[32m          },[m
[32m+[m[32m          "lib/netstandard2.0/de/Hangfire.Core.resources.dll": {[m
[32m+[m[32m            "locale": "de"[m
[32m+[m[32m          },[m
[32m+[m[32m          "lib/netstandard2.0/es/Hangfire.Core.resources.dll": {[m
[32m+[m[32m            "locale": "es"[m
[32m+[m[32m          },[m
[32m+[m[32m          "lib/netstandard2.0/fa/Hangfire.Core.resources.dll": {[m
[32m+[m[32m            "locale": "fa"[m
[32m+[m[32m          },[m
[32m+[m[32m          "lib/netstandard2.0/fr/Hangfire.Core.resources.dll": {[m
[32m+[m[32m            "locale": "fr"[m
[32m+[m[32m          },[m
[32m+[m[32m          "lib/netstandard2.0/nb/Hangfire.Core.resources.dll": {[m
[32m+[m[32m            "locale": "nb"[m
[32m+[m[32m          },[m
[32m+[m[32m          "lib/netstandard2.0/nl/Hangfire.Core.resources.dll": {[m
[32m+[m[32m            "locale": "nl"[m
[32m+[m[32m          },[m
[32m+[m[32m          "lib/netstandard2.0/pt-BR/Hangfire.Core.resources.dll": {[m
[32m+[m[32m            "locale": "pt-BR"[m
[32m+[m[32m          },[m
[32m+[m[32m          "lib/netstandard2.0/pt-PT/Hangfire.Core.resources.dll": {[m
[32m+[m[32m            "locale": "pt-PT"[m
[32m+[m[32m          },[m
[32m+[m[32m          "lib/netstandard2.0/pt/Hangfire.Core.resources.dll": {[m
[32m+[m[32m            "locale": "pt"[m
[32m+[m[32m          },[m
[32m+[m[32m          "lib/netstandard2.0/sv/Hangfire.Core.resources.dll": {[m
[32m+[m[32m            "locale": "sv"[m
[32m+[m[32m          },[m
[32m+[m[32m          "lib/netstandard2.0/tr-TR/Hangfire.Core.resources.dll": {[m
[32m+[m[32m            "locale": "tr-TR"[m
[32m+[m[32m          },[m
[32m+[m[32m          "lib/netstandard2.0/zh-TW/Hangfire.Core.resources.dll": {[m
[32m+[m[32m            "locale": "zh-TW"[m
[32m+[m[32m          },[m
[32m+[m[32m          "lib/netstandard2.0/zh/Hangfire.Core.resources.dll": {[m
[32m+[m[32m            "locale": "zh"[m
[32m+[m[32m          }[m
[32m+[m[32m        }[m
[32m+[m[32m      },[m
[32m+[m[32m      "Hangfire.NetCore/1.8.22": {[m
[32m+[m[32m        "dependencies": {[m
[32m+[m[32m          "Hangfire.Core": "1.8.22",[m
[32m+[m[32m          "Microsoft.Extensions.DependencyInjection.Abstractions": "9.0.10",[m
[32m+[m[32m          "Microsoft.Extensions.Hosting.Abstractions": "9.0.0",[m
[32m+[m[32m          "Microsoft.Extensions.Logging.Abstractions": "9.0.10"[m
[32m+[m[32m        },[m
[32m+[m[32m        "runtime": {[m
[32m+[m[32m          "lib/netstandard2.1/Hangfire.NetCore.dll": {[m
[32m+[m[32m            "assemblyVersion": "1.8.22.0",[m
[32m+[m[32m            "fileVersion": "1.8.22.0"[m
[32m+[m[32m          }[m
[32m+[m[32m        }[m
[32m+[m[32m      },[m
[32m+[m[32m      "Hangfire.SqlServer/1.8.22": {[m
[32m+[m[32m        "dependencies": {[m
[32m+[m[32m          "Hangfire.Core": "1.8.22"[m
[32m+[m[32m        },[m
[32m+[m[32m        "runtime": {[m
[32m+[m[32m          "lib/netstandard2.0/Hangfire.SqlServer.dll": {[m
[32m+[m[32m            "assemblyVersion": "1.8.22.0",[m
[32m+[m[32m            "fileVersion": "1.8.22.0"[m
[32m+[m[32m          }[m
[32m+[m[32m        }[m
[32m+[m[32m      },[m
       "Humanizer.Core/2.14.1": {[m
         "runtime": {[m
           "lib/net6.0/Humanizer.dll": {[m
[36m@@ -102,6 +226,28 @@[m
           }[m
         }[m
       },[m
[32m+[m[32m      "Microsoft.AspNetCore.Authentication.JwtBearer/8.0.10": {[m
[32m+[m[32m        "dependencies": {[m
[32m+[m[32m          "Microsoft.IdentityModel.Protocols.OpenIdConnect": "7.7.1"[m
[32m+[m[32m        },[m
[32m+[m[32m        "runtime": {[m
[32m+[m[32m          "lib/net8.0/Microsoft.AspNetCore.Authentication.JwtBearer.dll": {[m
[32m+[m[32m            "assemblyVersion": "8.0.10.0",[m
[32m+[m[32m            "fileVersion": "8.0.1024.46804"[m
[32m+[m[32m          }[m
[32m+[m[32m        }[m
[32m+[m[32m      },[m
[32m+[m[32m      "Microsoft.AspNetCore.Http.Abstractions/2.3.0": {[m
[32m+[m[32m        "dependencies": {[m
[32m+[m[32m          "Microsoft.AspNetCore.Http.Features": "2.3.0",[m
[32m+[m[32m          "System.Text.Encodings.Web": "9.0.10"[m
[32m+[m[32m        }[m
[32m+[m[32m      },[m
[32m+[m[32m      "Microsoft.AspNetCore.Http.Features/2.3.0": {[m
[32m+[m[32m        "dependencies": {[m
[32m+[m[32m          "Microsoft.Extensions.Primitives": "9.0.10"[m
[32m+[m[32m        }[m
[32m+[m[32m      },[m
       "Microsoft.Bcl.AsyncInterfaces/8.0.0": {[m
         "runtime": {[m
           "lib/netstandard2.1/Microsoft.Bcl.AsyncInterfaces.dll": {[m
[36m@@ -955,6 +1101,14 @@[m
           }[m
         }[m
       },[m
[32m+[m[32m      "Newtonsoft.Json/11.0.1": {[m
[32m+[m[32m        "runtime": {[m
[32m+[m[32m          "lib/netstandard2.0/Newtonsoft.Json.dll": {[m
[32m+[m[32m            "assemblyVersion": "11.0.0.0",[m
[32m+[m[32m            "fileVersion": "11.0.1.21818"[m
[32m+[m[32m          }[m
[32m+[m[32m        }[m
[32m+[m[32m      },[m
       "Serilog/4.3.0": {[m
         "runtime": {[m
           "lib/net8.0/Serilog.dll": {[m
[36m@@ -1338,8 +1492,20 @@[m
       "System.Threading.Channels/7.0.0": {},[m
       "ECommerce.Application/1.0.0": {[m
         "dependencies": {[m
[32m+[m[32m          "AutoMapper": "15.1.0",[m
           "ECommerce.Domain": "1.0.0",[m
[31m-          "MediatR": "13.1.0"[m
[32m+[m[32m          "FluentValidation": "12.1.0",[m
[32m+[m[32m          "FluentValidation.DependencyInjectionExtensions": "12.1.0",[m
[32m+[m[32m          "Hangfire.AspNetCore": "1.8.22",[m
[32m+[m[32m          "Hangfire.Core": "1.8.22",[m
[32m+[m[32m          "Hangfire.SqlServer": "1.8.22",[m
[32m+[m[32m          "MediatR": "13.1.0",[m
[32m+[m[32m          "Microsoft.AspNetCore.Http.Abstractions": "2.3.0",[m
[32m+[m[32m          "Microsoft.Extensions.Caching.Memory": "9.0.10",[m
[32m+[m[32m          "Microsoft.Extensions.Configuration.Json": "9.0.10",[m
[32m+[m[32m          "Serilog.AspNetCore": "9.0.0",[m
[32m+[m[32m          "Serilog.Sinks.Console": "6.1.1",[m
[32m+[m[32m          "Serilog.Sinks.MSSqlServer": "9.0.2"[m
         },[m
         "runtime": {[m
           "ECommerce.Application.dll": {[m
[36m@@ -1365,13 +1531,11 @@[m
           "ECommerce.Application": "1.0.0",[m
           "ECommerce.Domain": "1.0.0",[m
           "MailKit": "4.14.1",[m
[32m+[m[32m          "Microsoft.AspNetCore.Authentication.JwtBearer": "8.0.10",[m
           "Microsoft.EntityFrameworkCore": "9.0.10",[m
           "Microsoft.EntityFrameworkCore.SqlServer": "9.0.10",[m
           "Microsoft.Extensions.Configuration.Json": "9.0.10",[m
[31m-          "Microsoft.Extensions.Configuration.UserSecrets": "6.0.1",[m
[31m-          "Serilog.AspNetCore": "9.0.0",[m
[31m-          "Serilog.Sinks.Console": "6.1.1",[m
[31m-          "Serilog.Sinks.MSSqlServer": "9.0.2"[m
[32m+[m[32m          "Microsoft.Extensions.Configuration.UserSecrets": "6.0.1"[m
         },[m
         "runtime": {[m
           "ECommerce.Infrustructure.dll": {[m
[36m@@ -1388,6 +1552,13 @@[m
       "serviceable": false,[m
       "sha512": ""[m
     },[m
[32m+[m[32m    "AutoMapper/15.1.0": {[m
[32m+[m[32m      "type": "package",[m
[32m+[m[32m      "serviceable": true