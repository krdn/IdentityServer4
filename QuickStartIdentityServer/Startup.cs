using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace QuickStartIdentityServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // 추가
            // AddIdentityServer는 DI에 IdentityServer  서비스를 등록합니다. 또한 런타임 상태를 위해 메모리 내 저장소를 등록합니다. 
            // 이것은 개발 시나리오에 유용합니다. 운영 시나리오에서는 데이터베이스나 캐시 같은 영구 또는 공유 저장소가 필요합니다. 
            // 자세한 내용은 EntityFramework quickstart를 참조하십시오.


            // AddDeveloperSigningCredential 확장은 서명 토큰을위한 임시 키 자료를 만듭니다. 
            // 다시 말하지만이 방법은 시작하는 데 유용 할 수 있지만 프로덕션 시나리오의 일부 핵심 키 재료로 대체해야합니다. 
            // 자세한 내용은 암호화 문서(http://docs.identityserver.io/en/release/topics/crypto.html#refcrypto)를 참조하십시오.


            // configure identity server with in-memory stores, keys, clients and resources
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 추가
            app.UseIdentityServer();


            // 삭제
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
