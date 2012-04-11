using System;
using Gi7.Client.Model;
using Gi7.Client.Request.Base;
using GalaSoft.MvvmLight;
using RestSharp;
using System.Net;

namespace Gi7.Client.Request
{
    public class UserFollowingRequest : SingleRequest<bool?>
    {
        private Type _type;

        public UserFollowingRequest(string username, Type type = Type.READ)
        {
            Uri = String.Format("/user/following/{0}", username);
            _type = type;
        }

        public override void Execute(RestClient client, Action<bool?> callback = null)
        {
            var request = new RestRequest(Uri);

            switch (_type)
            {
                case Type.READ:
                    request.Method = Method.GET;
                    break;
                case Type.FOLLOW:
                    request.Method = Method.PUT;
                    break;
                case Type.UNFOLLOW:
                    request.Method = Method.DELETE;
                    break;
            }

            RaiseLoading(true);

            client.ExecuteAsync(request, r =>
            {
                RaiseLoading(false);

                if (r.StatusCode == HttpStatusCode.Unauthorized)
                {
                    RaiseUnauthorized();
                }
                else if (r.StatusCode == HttpStatusCode.NoContent)
                {
                    RaiseSuccess(true);

                    if (callback != null)
                    {
                        callback(true);
                    }
                }
                else if (r.StatusCode == HttpStatusCode.NotFound && _type == Type.READ)
                {
                    RaiseSuccess(false);
                    if (callback != null)
                    {
                        callback(false);
                    }
                }
                else
                {
                    RaiseConnectionError();
                }
            });
        }

        public enum Type { READ, FOLLOW, UNFOLLOW };
    }
}