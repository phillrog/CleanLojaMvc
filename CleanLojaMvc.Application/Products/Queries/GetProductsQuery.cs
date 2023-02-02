using CleanLojaMvc.Domain.Entities;
using MediatR;

namespace CleanLojaMvc.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
