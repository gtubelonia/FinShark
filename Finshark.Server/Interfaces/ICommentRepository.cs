using FinShark.Dtos.Comment;
using FinShark.Helpers;
using FinShark.Models;

namespace FinShark.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Models.Comment>> GetAllAsync(CommentQueryObject queryObject);
        Task<Models.Comment?> GetByIdAsync(int id);
        Task<Models.Comment> CreateAsync(Comment commentModel);
        Task<Models.Comment?> UpdateAsync(int id, UpdateCommentDto commentDto);
        Task<Models.Comment?> DeleteAsync(int id);
    }
}
