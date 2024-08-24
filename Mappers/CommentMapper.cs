using FinShark.Dtos.Comment;
using FinShark.Models;
using System.Runtime.CompilerServices;

namespace FinShark.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn.Date,
                StockId = commentModel.StockId
            };
        }
    }
}
