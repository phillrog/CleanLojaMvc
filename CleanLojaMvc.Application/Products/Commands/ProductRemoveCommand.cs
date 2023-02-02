using CleanLojaMvc.Domain.Entities;
using MediatR;

namespace CleanLojaMvc.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public ProductRemoveCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        
    }
}
