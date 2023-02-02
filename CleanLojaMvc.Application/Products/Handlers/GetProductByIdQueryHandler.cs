using CleanLojaMvc.Application.Products.Queries;
using CleanLojaMvc.Domain.Entities;
using CleanLojaMvc.Domain.Interfaces;
using MediatR;

namespace CleanLojaMvc.Application.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(ProductUpdateCommandHandler));
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByIdAsync(request.Id);
        }
    }
}
