using System.Threading.Tasks;

namespace HealthReportService.Interfaces
{
    public interface IStorageService
    {
        /// <summary>
        /// Writes data to storage (file, database, etc.)
        /// </summary>
        /// <param name="destination">Destination path (file path, database table, etc.)</param>
        /// <param name="dataObject">Object to write</param>
        Task Write<T>(string destination, T dataObject) where T : new();
    }
}