﻿using Gi7.Client.Model;
using Gi7.Client.Request.Base;

namespace Gi7.Client.Request
{
    public class RepositoriesRequest : PaginatedRequest<Repository>
    {
        public RepositoriesRequest()
        {
            Uri = "/user/repos";
        }

        protected override void preRequest(RestSharp.RestClient client, RestSharp.RestRequest request)
        {
            request.Resource += "&sort=pushed";
        }
    }
}