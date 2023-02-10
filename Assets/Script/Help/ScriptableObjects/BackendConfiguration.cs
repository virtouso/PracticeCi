using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//using OceanExplorer.Managers;

namespace Help.Script.Help.ScriptableObjects
{
    public interface IBackendConfiguration
    {
        string EndpointUrl { get; }
        Dictionary<BackendConfiguration.RequestName, string> Requests { get; }
        void Init();
    }

    public class BackendConfiguration : UnityEngine.ScriptableObject, IBackendConfiguration
    {
        [SerializeField] private EndpointName _selectedEndpoint;
        [SerializeField] private List<Endpoint> _endPoints;

        [SerializeField] private List<BackendRequest> _backendRequests;

        private string _endPointUrl;
        public string EndpointUrl => _endPointUrl;
        public Dictionary<RequestName, string> Requests => _requests;
        private Dictionary<RequestName, string> _requests;

        public void Init()
        {
            _endPointUrl = _endPoints.First(x => x.EndpointName == _selectedEndpoint).Url;

            _requests = new Dictionary<RequestName, string>(_backendRequests.Count);

            foreach (var item in _backendRequests)
            {
                _requests.Add(item.RequestName, item.SubUrl);
            }
        }


        [System.Serializable]
        public class Endpoint
        {
            public EndpointName EndpointName;
            public string Url;
        }

        public enum EndpointName
        {
            Local,
            TestServer,
            Production
        }

        [System.Serializable]
        public class BackendRequest
        {
            public RequestName RequestName;
            public string SubUrl;
        }

        public enum RequestName
        {
         SignUp,
         Login,
         ValidateSignup
        }
    }
    
}