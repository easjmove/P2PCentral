using P2PCentral.Models;

namespace P2PCentral.Repositories
{
    public class FileEndpointsRepository
    {
        private Dictionary<string, List<FileEndpoint>> _data;

        public FileEndpointsRepository()
        {
            _data = new Dictionary<string, List<FileEndpoint>>();
        }

        public List<string> GetFileNames()
        {
            return _data.Keys.ToList();
        }

        public List<FileEndpoint>? GetEndpoints(string fileName)
        {
            if (_data.ContainsKey(fileName))
            {
                return _data[fileName];
            }
            return null;
        }

        public FileEndpoint Add(string fileName, FileEndpoint newEndpoint)
        {
            if (!_data.ContainsKey(fileName))
            {
                _data.Add(fileName, new List<FileEndpoint>());
            }
            _data[fileName].Add(newEndpoint);
            return newEndpoint;
        }

        public FileEndpoint? Delete(string fileName, FileEndpoint endpointToBeDeleted)
        {
            if (_data.ContainsKey(fileName))
            {
                List<FileEndpoint> list = _data[fileName];
                foreach (var endpoint in list)
                {
                    if (endpoint.IpAddress == endpointToBeDeleted.IpAddress &&
                        endpoint.Port == endpointToBeDeleted.Port)
                    {
                        list.Remove(endpoint);
                    }
                }
            }
            return null;
        }
    }
}
