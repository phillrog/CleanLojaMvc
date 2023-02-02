using CleanLojaMvc.Application.Products.Commands;
using CleanLojaMvc.Domain.Entities;
using CleanLojaMvc.Domain.Interfaces;
using MediatR;

namespace CleanLojaMvc.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(ProductUpdateCommandHandler));
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException("Entity could not be found.");
            } 
            
            return await _productRepository.RemoveAsync(product);
        }
    }
}
