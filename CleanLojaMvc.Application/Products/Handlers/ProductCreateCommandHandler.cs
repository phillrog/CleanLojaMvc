using CleanLojaMvc.Application.Products.Commands;
using CleanLojaMvc.Domain.Entities;
using CleanLojaMvc.Domain.Interfaces;
using MediatR;

namespace CleanLojaMvc.Application.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image);

            product.UpdateCategoryId(request.CategoryId);

            return await _productRepository.CreateAsync(product);
        }
    }
}
