using System;
using System.Collections.Generic;
using System.Linq;

namespace HttpServer
{
    public class HttpListener : IHttpListener
    {
        private readonly Dictionary<string, HttpRequest> pendingRequestsById;

        private readonly Dictionary<string, HttpRequest> pendingPriorityRequestsById;

        private readonly Dictionary<string, HttpRequest> executedRequestsById;

        private readonly Dictionary<string, Dictionary<string, HttpRequest>> collectionOfPendingRequestsByHost;

        public HttpListener()
        {
            this.pendingRequestsById = new Dictionary<string, HttpRequest>();
            this.pendingPriorityRequestsById = new Dictionary<string, HttpRequest>();
            this.executedRequestsById = new Dictionary<string, HttpRequest>();
            this.collectionOfPendingRequestsByHost = new Dictionary<string, Dictionary<string, HttpRequest>>();
        }

        public void AddRequest(HttpRequest request)
        {
            this.pendingRequestsById.Add(request.Id, request);

            this.AddToCollectionOfPendingRequestsByHost(request);
        }

		public void AddPriorityRequest(HttpRequest request)
        {
            if (this.pendingRequestsById.ContainsKey(request.Id))
            {
                throw new ArgumentException();
            }

            this.pendingRequestsById.Add(request.Id, request);

            this.pendingPriorityRequestsById.Add(request.Id, request);

            this.AddToCollectionOfPendingRequestsByHost(request);
        }

        public bool Contains(string requestId) => this.pendingRequestsById.ContainsKey(requestId);

        public int Size() => this.pendingRequestsById.Count;

        public HttpRequest GetRequest(string requestId)
        {
            if (!this.pendingRequestsById.ContainsKey(requestId))
            {
                throw new ArgumentException();
            }

            return this.pendingRequestsById[requestId];
        }

        public void CancelRequest(string requestId)
        {
			if (!this.pendingRequestsById.ContainsKey(requestId))
			{
				throw new ArgumentException();
			}

            HttpRequest request = this.pendingRequestsById[requestId];

            this.pendingRequestsById.Remove(requestId);

            this.pendingPriorityRequestsById.Remove(requestId);

            this.collectionOfPendingRequestsByHost[request.Host].Remove(requestId);
		}

        public HttpRequest Execute()
        {
            if (this.Size() == 0)
            {
				throw new ArgumentException();
			}

			HttpRequest request = this.pendingPriorityRequestsById.Values.FirstOrDefault();

            request ??= this.pendingRequestsById.Values.FirstOrDefault();

            this.pendingRequestsById.Remove(request.Id);

            this.pendingPriorityRequestsById.Remove(request.Id);

            this.collectionOfPendingRequestsByHost[request.Host].Remove(request.Id);

            this.executedRequestsById.Add(request.Id, request);

            return request;
        }

        public HttpRequest RescheduleRequest(string requestId)
        {
            if (!this.executedRequestsById.ContainsKey(requestId))
            {
                throw new ArgumentException();
            }

            HttpRequest request = this.executedRequestsById[requestId];

            this.executedRequestsById.Remove(requestId);

            this.pendingRequestsById.Add(requestId, request);

            this.AddToCollectionOfPendingRequestsByHost(request);

            return request;
        }

        public IEnumerable<HttpRequest> GetByHost(string host)
            => this.collectionOfPendingRequestsByHost[host].Values;

        public IEnumerable<HttpRequest> GetAllExecutedRequests()
            => this.executedRequestsById.Values;

		private void AddToCollectionOfPendingRequestsByHost(HttpRequest request)
		{
			if (!this.collectionOfPendingRequestsByHost.ContainsKey(request.Host))
			{
				this.collectionOfPendingRequestsByHost.Add(request.Host, new Dictionary<string, HttpRequest>());
			}

			this.collectionOfPendingRequestsByHost[request.Host].Add(request.Id, request);
		}
    }
}
