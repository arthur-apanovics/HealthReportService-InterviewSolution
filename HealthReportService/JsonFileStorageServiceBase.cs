using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using HealthReportService.Interfaces;
using Microsoft.Extensions.Logging;

namespace HealthReportService
{
    internal abstract class JsonFileStorageServiceBase : IStorageService
    {
        /// <summary>
        /// Relative root directory to write files to
        /// </summary>
        protected abstract string Directory { get; }
        
        private readonly ILogger<JsonFileStorageServiceBase> _logger;

        protected JsonFileStorageServiceBase(ILogger<JsonFileStorageServiceBase> logger)
        {
            _logger = logger;
        }
        
        /// <summary>
        /// Deserializes object and writes contents to json at specified path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="serializableObject"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task Write<T>(string path, T serializableObject) where T : new()
        {
            var finalPath = $"{Directory}/{path}.json";
            try
            {
                var content = JsonSerializer.Serialize(serializableObject);
                await File.WriteAllTextAsync(finalPath, content);
                
                _logger.Log(LogLevel.Information, $"Wrote file to {finalPath}");
            }
            catch (Exception exception)
            {
                _logger.Log(LogLevel.Error, exception, $"Failed writing {typeof(T)} to {finalPath}");
            }
        }
    }
}