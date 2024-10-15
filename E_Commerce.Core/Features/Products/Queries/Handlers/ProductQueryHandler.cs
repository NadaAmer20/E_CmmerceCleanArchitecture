using AutoMapper;
using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Categories.Queries.Models;
using E_Commerce.Core.Features.Categories.Queries.Results;
using E_Commerce.Core.Features.Products.Commands.Models;
using E_Commerce.Core.Features.Products.Queries.Models;
using E_Commerce.Core.Features.Products.Queries.Results;
using E_Commerce.Core.Wrapper;
using E_Commerce.Data.Entites;
using E_Commerce.Infrustructure.Abstracts;
using E_Commerce.Infrustructure.Repositories;
using E_Commerce.Service.Abstracts;
using E_Commerce.Service.Implementations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Products.Queries.Handlers
{
    public class ProductQueryHandler : ResponseHandler,
        IRequestHandler<GetProductListQuery, Response<List<GetProductListResponse>>>,
          IRequestHandler<GetProductByIDQuery, Response<GetSingleProductResponse>>,
            IRequestHandler<GetProductByNameQuery, Response<List<GetProductListResponse>>>,
            IRequestHandler<GetProductPaginatedListQuery, PaginatedResult<GetProductPaginatedListResponse>>,
                    IRequestHandler<GetAllProductSortByReviewQuery, Response<List<GetAllProductSortByReviewResponse>>>


    {
        #region Feilds
        private readonly IMapper _mapper;
        private readonly IProductServices _productServices;
        private readonly IImageServices _imageServices;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IReviewServices _reviewServices;
        #endregion

        #region Constructor

        public ProductQueryHandler(IMapper mapper, IProductServices productServices,
            IImageServices imageServices, IHttpContextAccessor httpContextAccessor, IReviewServices reviewServices)
        {
            _mapper = mapper;
            _productServices = productServices;
            _imageServices = imageServices;
            _httpContextAccessor = httpContextAccessor;
            _reviewServices = reviewServices;
        }
        #endregion
        #region HandleFunction


        public async Task<Response<List<GetProductListResponse>>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await _productServices.GetProductListAsync();

            if (products == null || !products.Any())
                return NotFound<List<GetProductListResponse>> ("Products not found");

            var mappedResponse = _mapper.Map<List<GetProductListResponse>>(products);

            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
                return BadRequest<List<GetProductListResponse>>("HttpContext is not available");

            foreach (var product in mappedResponse)
            {
                var images = await _imageServices.GetProductImagesByProductIdAsync(product.id);
                product.ImageUrls = images.Select(img => $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/images/{img.ImagePath}").ToList();
            }

            return Success<List<GetProductListResponse>>(mappedResponse);
        }

        public async Task<Response<GetSingleProductResponse>> Handle(GetProductByIDQuery request, CancellationToken cancellationToken)
        {
            var response = await _productServices.GetByIdAsync(request.Id);

            if (response == null)
                return NotFound<GetSingleProductResponse>("Product not found");

            var mappedResponse = _mapper.Map<GetSingleProductResponse>(response);
            //imaged
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
                return BadRequest<GetSingleProductResponse>("HttpContext is not available");
            var images = await _imageServices.GetProductImagesByProductIdAsync(mappedResponse.id);
            mappedResponse.ImageUrls = images.Select(img => $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/images/{img.ImagePath}").ToList();
            return Success<GetSingleProductResponse>(mappedResponse);
        }

        public async Task<Response<List<GetProductListResponse>>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
        {
            var products = await _productServices.GetByName(request.Name);

            if (products == null || !products.Any())
                return NotFound<List<GetProductListResponse>>("Products not found");

            var mappedResponse = _mapper.Map<List<GetProductListResponse>>(products);

            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
                return BadRequest<List<GetProductListResponse>>("HttpContext is not available");

            foreach (var product in mappedResponse)
            {
                var images = await _imageServices.GetProductImagesByProductIdAsync(product.id);
                product.ImageUrls = images.Select(img => $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/images/{img.ImagePath}").ToList();
            }

            return Success <List<GetProductListResponse>>(mappedResponse);
        }
        public async Task<PaginatedResult<GetProductPaginatedListResponse>> Handle(GetProductPaginatedListQuery request, CancellationToken cancellationToken)
        {
            // Get the HTTP context
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
                throw new InvalidOperationException("HttpContext is not available");

            // Define the base URL for images
            var baseUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/images/";

            // Define the projection expression
            Expression<Func<Product, GetProductPaginatedListResponse>> projection = product =>
                new GetProductPaginatedListResponse(
                    product.Id,
                    product.CategoryId,
                    product.Item_Name,
                    product.price,
                    product.Description,
                    product.solditems,
                    product.quantity,
                    product.Images != null ? product.Images.Select(img => $"{baseUrl}{img.ImagePath}").ToList() : new List<string>()
                );

            // Get the queryable products and apply filtering
            IQueryable<Product> queryableProducts = _productServices.GetAllProductsQueryable();
            IQueryable<Product> filteredProducts = _productServices.FilterProductPaginatedQuerable(request.OrderBy, request.Search);

            // Apply pagination and projection
            var paginatedProducts = await filteredProducts
                .Select(projection)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            // Add meta information
            paginatedProducts.Meta = new
            {
                Count = await filteredProducts.CountAsync(cancellationToken)
            };

            return paginatedProducts;
        }

        public async Task<Response<List<GetAllProductSortByReviewResponse>>> Handle(GetAllProductSortByReviewQuery request, CancellationToken cancellationToken)
        {
            var products = await _productServices.GetAllBySortReviewAsync();

            if (products == null || !products.Any())
                return NotFound<List<GetAllProductSortByReviewResponse>>("Products not found");

            var mappedResponse = _mapper.Map<List<GetAllProductSortByReviewResponse>>(products);

            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
                return BadRequest<List<GetAllProductSortByReviewResponse>>("HttpContext is not available");

            foreach (var product in mappedResponse)
            {
                var images = await _imageServices.GetProductImagesByProductIdAsync(product.id);
                product.ImageUrls = images.Select(img => $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/images/{img.ImagePath}").ToList();
              //  var reviews = await _reviewServices.GetAllReviewsForProductAsync(product.id);
               // int averageRate = (int)reviews.Average(r => r.Rate);
             //   product.averageRate = averageRate;
             }

            return Success<List<GetAllProductSortByReviewResponse>>(mappedResponse);
        }


  
        #endregion
    }
}
