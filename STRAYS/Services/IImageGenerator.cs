using STRAYS.Models;

namespace STRAYS.Services
{
    public interface IImageGenerator
    {
        Task<link> GenerateImage(input input);
    }
}
