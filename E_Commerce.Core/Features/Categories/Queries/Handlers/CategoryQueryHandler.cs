using AutoMapper;
using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Categories.Queries.Models;
using E_Commerce.Core.Features.Categories.Queries.Results;
using E_Commerce.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Data.Entites;
using Microsoft.AspNetCore.Http;
namespace E_Commerce.Core.Features.Categories.Queries.Handlers
{
        public class CategoryQueryHandler : ResponseHandler,
    IRequestHandler<GetCategoryByIDQuery, Response<GetSingleCategoryResponse>>,
    IRequestHandler<GetCategoryListQuery, Response<List<GetCategoryListResponse>>>,
            IRequestHandler<GetCategoryByNameQuery, Response<List<GetCategoryListResponse>>>
    {
        #region Fields
        private readonly ICategoryServices _categoryServices;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IImageServices _imageServices;
        #endregion

        #region Constructor
        public CategoryQueryHandler(
            ICategoryServices categoryServices,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IImageServices imageServices)
        {
            _categoryServices = categoryServices;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _imageServices = imageServices;
        }
        #endregion
        #region Handle Function
        public async Task<Response<GetSingleCategoryResponse>> Handle(GetCategoryByIDQuery request, CancellationToken cancellationToken)
        {
            // Retrieve the category including related entities (e.g., products)
            var response = await _categoryServices.GetByIdWithIncludeAsync(request.Id);

            // Check if the response is null
            if (response == null)
                return NotFound<GetSingleCategoryResponse>( "Category not found");

            // Map the response entity to the GetSingleCategoryResponse DTO
            var mappedResponse = _mapper.Map<GetSingleCategoryResponse>(response);

            // Return a successful response with the mapped data
              return Success<GetSingleCategoryResponse>(mappedResponse);
        }



        public async Task<Response<List<GetCategoryListResponse>>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            // Retrieve the list of categories including related products and images
            var categories = await _categoryServices.GetCategorytListAsync();

            // Check if the categories list is null or empty
            if (categories == null || !categories.Any())
                return NotFound<List<GetCategoryListResponse>>("No categories found");

            // Map the response entities to the GetCategoryListResponse DTOs
            var mappedCategories = _mapper.Map<List<GetCategoryListResponse>>(categories);

            // Retrieve the HTTP context
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
                return new Response<List<GetCategoryListResponse>>("HttpContext is not available");

            // For each category, retrieve product images and set image URLs
            foreach (var category in mappedCategories)
            {
                foreach (var product in category.ProductResponseList)
                {
                    var images = await _imageServices.GetProductImagesByProductIdAsync(product.Id);
                    product.ImageUrls = images.Select(img =>
                        $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/images/{img.ImagePath}")
                        .ToList();
                }
            }

            // Return a successful response with the mapped data
            return Success<List<GetCategoryListResponse>>(mappedCategories);
        }

        public async Task<Response<List<GetCategoryListResponse>>> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryServices.GetByNameAsunc(request.Name);

            // Check if the categories list is null or empty
            if (categories == null || !categories.Any())
                return NotFound<List<GetCategoryListResponse>>("No categories found");

            var mappedCategories = _mapper.Map<List<GetCategoryListResponse>>(categories);
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
                return new Response<List<GetCategoryListResponse>>("HttpContext is not available");

            // For each category, retrieve product images and set image URLs
            foreach (var category in mappedCategories)
            {
                foreach (var product in category.ProductResponseList)
                {
                    var images = await _imageServices.GetProductImagesByProductIdAsync(product.Id);
                    product.ImageUrls = images.Select(img =>
                        $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/images/{img.ImagePath}")
                        .ToList();
                }
            }
            return Success<List<GetCategoryListResponse>>(mappedCategories);
        }
            #endregion
        }
    }
