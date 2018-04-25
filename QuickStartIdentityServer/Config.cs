using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickStartIdentityServer
{
    public class Config
    {
        // ** Defining the API
        // *****************************************************************
        // 범위는 보호하려는 시스템의 리소스를 정의합니다, 예: APIs.

        // 이 연습에 인 메모리 구성을 사용하고 있기 때문에 API를 추가하기 위해 필요한 것은 
        // ApiResource 유형의 개체를 만들고 적절한 속성을 설정하는 것입니다.
        public static IEnumerable<ApiResource> GetApiResources()
        {


            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }


        // Defining the client 
        // *******************************************
        // 다음 단계는이 API에 액세스 할 수있는 클라이언트를 정의하는 것입니다.

        // 이 시나리오의 경우 클라이언트는 대화 형 사용자를 가지지 않으며 IdentityServer와 함께 
        // 클라이언트 보안을 사용하여 인증합니다.Config.cs 파일에 다음 코드를 추가하십시오.
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                }
            };
        }
    }
}
