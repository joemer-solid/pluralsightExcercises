using SRP_FileStore.SingleResponsibilityPrinciple.Shared;

namespace SRP_FileStore.SingleResponsibilityPrinciple.Start
{
   
    public sealed class SRPFileStore_Start
    {
        private readonly Log _logger;
        private readonly FileProxyClass _file;

        public SRPFileStore_Start()
        {
            _logger = new Log();
            _file = new FileProxyClass();
        }

        public void Save(int id, string message)
        {
            _logger.Information("Saving message {0}", id);

            var file = _file.GetFileInfo(id);

            _file.WriteAllText(file.Name, message);

            _logger.Information("Saved message {0}", id);

        }

        public Maybe<string> Read(int id)
        {
            _logger.Debug("Reading File Contents For File Id: {0}", id);

            var file = _file.GetFileInfo(id);

            if (!file.Exists)
            {
                _logger.Debug("No file found {0}", id);
                return new Maybe<string>();
            }

            var fileContents = _file.ReadAllText(id);

            _logger.Debug("Returning file contents for file id: {0}", id);

            return new Maybe<string>(fileContents);
        }
    }
}
