using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApplication1.Data.ValueObjetcs;

namespace WebApplication1.Domain.Files.Interfaces
{
    public interface IFileService
    {
        public byte[] GetFile(string fileName);
        public Task<FileDetailVo> SaveFileToDisk(IFormFile file);
        public Task<List<FileDetailVo>> SaveFileToDisk(IList<IFormFile> files);
    }
}