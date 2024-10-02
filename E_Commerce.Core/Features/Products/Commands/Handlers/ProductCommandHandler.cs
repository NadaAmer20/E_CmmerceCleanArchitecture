using AutoMapper;
using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Categories.Commands.Models;
using E_Commerce.Core.Features.Products.Commands.Models;
using E_Commerce.Core.Features.Products.Commands.Validations;
using E_Commerce.Data.Entites;
using E_Commerce.Service.Abstracts;
using E_Commerce.Service.Implementations;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Products.Commands.Handlers
{
    public class ProductCommandHandler : ResponseHandler, IRequestHandler<CreateProductCommand, Response<string>>,
         IRequestHandler<UpdateProductCommand, Response<string>>,
         IRequestHandler<DeleteProductCommand, Response<string>>

    {
        #region Feilds
        private readonly IMapper _mapper;
        private readonly IProductServices _productServices;
        private readonly IWebHostEnvironment _webHostEnvironment;
        #endregion

        #region Constructor
        public ProductCommandHandler(IMapper mapper, IProductServices productServices, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _productServices = productServices;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion
        #region HandleFunction
        public async Task<Response<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Ensure the uploads folder exists
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            Directory.CreateDirectory(uploadsFolder);

            // Initialize a list to hold the image paths
            var imagePaths = new List<ProductImages>();

            foreach (var file in request.File)
            {
                if (file != null && file.Length > 0)
                {
                    // Generate a unique file name and define the file path
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Ensure the directory exists
                    Directory.CreateDirectory(uploadsFolder);

                    // Save the file to the server
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                  

                    // Create a ProductImages instance and add it to the list
                    imagePaths.Add(new ProductImages
                    {

                        ImagePath = uniqueFileName,
                        // ProductId will be set after creating the product
                    });
                }
            }

            // Map the request to the Product entity
            var product = _mapper.Map<Product>(request);

            // Add the list of image paths to the product entity
            product.Images = imagePaths;

            // Create the product using the service
            var result = await _productServices.CreateProduct(product);

            if (result == "Added SuccessFully")  
            {
                return Created("");
            }
            else
            {
                return BadRequest<string>();
            }
        }


        public async Task<Response<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productServices.GetByIdAsync(request.Id);
            var productMapper = _mapper.Map<Product>(request);
            var result = await _productServices.EditAsync(productMapper);

            if (result == "Null")
                return NotFound<string>("Product Not Exsists");

            return Success<string>("Success");

        }

        public async Task<Response<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productServices.GetByIdAsync(request.Id);
            if (product == null)
                return NotFound<string>("Product Not Exsists");
            await _productServices.DeleteAsync(product);
            return Deleted<string>("Delete Success");
        }
        #endregion
    }
}
