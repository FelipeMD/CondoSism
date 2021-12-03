using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Files.Interfaces
{
    public interface IFileService
    {
        public byte[] GetFile(string fileName);
        public Task<FileDetailVo> SaveFileToDisk(IFormFile file);
        public Task<List<FileDetailVo>> SaveFilesToDisk(IList<IFormFile> files);
    }
}