﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PhoneBookWebApi.BasicAuthentication
{
    
        public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
        {
            public override void OnAuthorization(HttpActionContext actionContext)
            {
                if (actionContext.Request.Headers.Authorization != null)
                {
                    var authToken = actionContext.Request.Headers
                        .Authorization.Parameter;

                    var decodeauthToken = System.Text.Encoding.UTF8.GetString(
                        Convert.FromBase64String(authToken));


                    var arrUserNameandPassword = decodeauthToken.Split(':');

                    if (IsAuthorizedUser(arrUserNameandPassword[0], arrUserNameandPassword[1]))
                    {
                        Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity(arrUserNameandPassword[0]), null);
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized);
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request
                     .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            private bool IsAuthorizedUser(string Username, string Password)
            {

                return Username == "Admin" && Password == "admin";
            }
        }
    }

