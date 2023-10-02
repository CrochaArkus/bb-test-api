using Challenge.Entities.Entities;
using Content.Dtos.Request;
using Contents.lnterfaces;
using ExceptionContents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;

namespace Contents.Infrastructure.Repositories
{
    public class ContentsRespository : IContentsRespository
    {
        private readonly ApplicationContext _context;

        public ContentsRespository(ApplicationContext context) { _context = context; }

        public async Task<int> Create(ContentRequest contentRequest)
        {
            try
            {
                Challenge.Entities.Entities.Content content = SetContent(contentRequest);
                _context.contents.Add(content);
                await _context.SaveChangesAsync();
                return content.id_content;
            }
            catch (Exception)
            {
                throw new ExecptionCreateContent();
            }
        }

        public async Task<MagnamentContentsCategories> CreateManageContent(ListCategories request, int idContent)
        {
            try
            {
                MagnamentContentsCategories content = SetManageContent(request, idContent);
                _context.magnamentContentsCategories.Add(content);
                await _context.SaveChangesAsync();
                return content;
            }
            catch (Exception)
            {
                throw new ExceptionCreateManageContent();
            }
        }

        public List<ManageContentResponse> GetManageContenteCreateContent(List<MagnamentContentsCategories> request)
        {
            try
            {
                return (from a in request
                        join b in _context.interiorSubCategories on new
                        {
                            c = a.id_categories,
                            s = a.id_subcategories,
                            i = a.id_interior_subcategories
                        }
                        equals new { c = b.id_catgeory, s = b.id_subcategory, i = b.id_interior_subcategory }
                        join c in _context.categories on b.id_catgeory equals c.id_categories
                        join d in _context.subCategories on new { c = b.id_catgeory, s = b.id_subcategory }
                        equals new { c = d.id_categories, s = d.id_subcategories }
                        join e in _context.contents on a.id_content equals e.id_content
                        select new ManageContentResponse
                        {
                            id_content = a.id_content,
                            title = e.title,
                            category_name = c.name,
                            id_category = b.id_catgeory,
                            Display = e.active ? "On Display" : "Hidden",
                            active = e.active,
                            unlocked = e.unLocked,
                            id_interior_subCategory = a.id_interior_subcategories,
                            id_subCategory = a.id_subcategories
                        }).ToList();
            }
            catch (Exception)
            {
                throw new ExecptionCreateContent();
            }
        }

        public List<ManageContentResponse> GetManageContenteByCategory(int categoryId)
        {
            var query = from magnamentContent in _context.magnamentContentsCategories
                        join interiorSubCategory in _context.interiorSubCategories
                        on new { c = magnamentContent.id_categories, s = magnamentContent.id_subcategories, i = magnamentContent.id_interior_subcategories }
                        equals new { c = interiorSubCategory.id_catgeory, s = interiorSubCategory.id_subcategory, i = interiorSubCategory.id_interior_subcategory }
                        join category in _context.categories
                        on interiorSubCategory.id_catgeory equals category.id_categories
                        join subCategory in _context.subCategories
                        on new { c = interiorSubCategory.id_catgeory, s = interiorSubCategory.id_subcategory }
                        equals new { c = subCategory.id_categories, s = subCategory.id_subcategories }
                        join content in _context.contents
                        on magnamentContent.id_content equals content.id_content
                        where magnamentContent.id_categories == categoryId
                        select new ManageContentResponse
                        {
                            id_content = magnamentContent.id_content,
                            title = content.title,
                            category_name = category.name,
                            id_category = interiorSubCategory.id_catgeory,
                            Display = content.active ? "On Display" : "Hidden",
                            active = content.active,
                            unlocked = content.unLocked,
                            id_interior_subCategory = magnamentContent.id_interior_subcategories,
                            id_subCategory = magnamentContent.id_subcategories
                        };

            return query.ToList();
        }

        public List<ManageContentResponse> GetManageContenteByCategorySubcategory(int categoryId, int subcategory)
        {
            var query = from magnamentContent in _context.magnamentContentsCategories
                        join interiorSubCategory in _context.interiorSubCategories
                        on new { c = magnamentContent.id_categories, s = magnamentContent.id_subcategories, i = magnamentContent.id_interior_subcategories }
                        equals new { c = interiorSubCategory.id_catgeory, s = interiorSubCategory.id_subcategory, i = interiorSubCategory.id_interior_subcategory }
                        join category in _context.categories
                        on interiorSubCategory.id_catgeory equals category.id_categories
                        join subCategory in _context.subCategories
                        on new { c = interiorSubCategory.id_catgeory, s = interiorSubCategory.id_subcategory }
                        equals new { c = subCategory.id_categories, s = subCategory.id_subcategories }
                        join content in _context.contents
                        on magnamentContent.id_content equals content.id_content
                        where magnamentContent.id_categories == categoryId 
                        && magnamentContent.id_subcategories == subcategory
                        select new ManageContentResponse
                        {
                            id_content = magnamentContent.id_content,
                            title = content.title,
                            category_name = category.name,
                            id_category = interiorSubCategory.id_catgeory,
                            Display = content.active ? "On Display" : "Hidden",
                            active = content.active,
                            unlocked = content.unLocked,
                            id_interior_subCategory = magnamentContent.id_interior_subcategories,
                            id_subCategory = magnamentContent.id_subcategories
                        };

            return query.ToList();
        }

        public List<ManageContentResponse> GetManageContenteByCategorySubcategoryInteriorSubCategory(int categoryId, 
            int subcategoryId, int interiorSubcategoryId)
        {
            var query = from magnamentContent in _context.magnamentContentsCategories
                        join interiorSubCategory in _context.interiorSubCategories
                        on new { c = magnamentContent.id_categories, s = magnamentContent.id_subcategories, i = magnamentContent.id_interior_subcategories }
                        equals new { c = interiorSubCategory.id_catgeory, s = interiorSubCategory.id_subcategory, i = interiorSubCategory.id_interior_subcategory }
                        join category in _context.categories
                        on interiorSubCategory.id_catgeory equals category.id_categories
                        join subCategory in _context.subCategories
                        on new { c = interiorSubCategory.id_catgeory, s = interiorSubCategory.id_subcategory }
                        equals new { c = subCategory.id_categories, s = subCategory.id_subcategories }
                        join content in _context.contents
                        on magnamentContent.id_content equals content.id_content
                        where magnamentContent.id_categories == categoryId
                        && magnamentContent.id_subcategories == subcategoryId
                        && magnamentContent.id_subcategories == interiorSubcategoryId
                        select new ManageContentResponse
                        {
                            id_content = magnamentContent.id_content,
                            title = content.title,
                            category_name = category.name,
                            id_category = interiorSubCategory.id_catgeory,
                            Display = content.active ? "On Display" : "Hidden",
                            active = content.active,
                            unlocked = content.unLocked,
                            id_interior_subCategory = magnamentContent.id_interior_subcategories,
                            id_subCategory = magnamentContent.id_subcategories
                        };

            return query.ToList();
        }

        public List<ManageContentResponse> GetManageContenteByName(string name)
        {
            var query = from magnamentContent in _context.magnamentContentsCategories
                        join interiorSubCategory in _context.interiorSubCategories
                        on new { c = magnamentContent.id_categories, s = magnamentContent.id_subcategories, i = magnamentContent.id_interior_subcategories }
                        equals new { c = interiorSubCategory.id_catgeory, s = interiorSubCategory.id_subcategory, i = interiorSubCategory.id_interior_subcategory }
                        join category in _context.categories
                        on interiorSubCategory.id_catgeory equals category.id_categories
                        join subCategory in _context.subCategories
                        on new { c = interiorSubCategory.id_catgeory, s = interiorSubCategory.id_subcategory }
                        equals new { c = subCategory.id_categories, s = subCategory.id_subcategories }
                        join content in _context.contents
                        on magnamentContent.id_content equals content.id_content
                        where interiorSubCategory.name.Contains(name) 
                        || subCategory.name.Contains(name)
                        || category.name.Contains(name)
                        select new ManageContentResponse
                        {
                            id_content = magnamentContent.id_content,
                            title = content.title,
                            category_name = category.name,
                            id_category = interiorSubCategory.id_catgeory,
                            Display = content.active ? "On Display" : "Hidden",
                            active = content.active,
                            unlocked = content.unLocked,
                            id_interior_subCategory = magnamentContent.id_interior_subcategories,
                            id_subCategory = magnamentContent.id_subcategories
                        };

            return query.ToList();
        }

        public List<ManageContentResponse> GetManageContenteByNameCategoryId(string name, int categoryId)
        {
            var query = from magnamentContent in _context.magnamentContentsCategories
                        join interiorSubCategory in _context.interiorSubCategories
                        on new { c = magnamentContent.id_categories, s = magnamentContent.id_subcategories, i = magnamentContent.id_interior_subcategories }
                        equals new { c = interiorSubCategory.id_catgeory, s = interiorSubCategory.id_subcategory, i = interiorSubCategory.id_interior_subcategory }
                        join category in _context.categories
                        on interiorSubCategory.id_catgeory equals category.id_categories
                        join subCategory in _context.subCategories
                        on new { c = interiorSubCategory.id_catgeory, s = interiorSubCategory.id_subcategory }
                        equals new { c = subCategory.id_categories, s = subCategory.id_subcategories }
                        join content in _context.contents
                        on magnamentContent.id_content equals content.id_content
                        where (category.id_categories == categoryId) && ( interiorSubCategory.name.Contains(name)
                        || subCategory.name.Contains(name)
                        || category.name.Contains(name))
                        select new ManageContentResponse
                        {
                            id_content = magnamentContent.id_content,
                            title = content.title,
                            category_name = category.name,
                            id_category = interiorSubCategory.id_catgeory,
                            Display = content.active ? "On Display" : "Hidden",
                            active = content.active,
                            unlocked = content.unLocked,
                            id_interior_subCategory = magnamentContent.id_interior_subcategories,
                            id_subCategory = magnamentContent.id_subcategories
                        };

            return query.ToList();
        }
        public List<ManageContentResponse> GetManageContenteByNameCategoryIdSubcategoryId(string name,
            int categoryId, int SubcategoryId)
        {
            var query = from magnamentContent in _context.magnamentContentsCategories
                        join interiorSubCategory in _context.interiorSubCategories
                        on new { c = magnamentContent.id_categories, s = magnamentContent.id_subcategories, i = magnamentContent.id_interior_subcategories }
                        equals new { c = interiorSubCategory.id_catgeory, s = interiorSubCategory.id_subcategory, i = interiorSubCategory.id_interior_subcategory }
                        join category in _context.categories
                        on interiorSubCategory.id_catgeory equals category.id_categories
                        join subCategory in _context.subCategories
                        on new { c = interiorSubCategory.id_catgeory, s = interiorSubCategory.id_subcategory }
                        equals new { c = subCategory.id_categories, s = subCategory.id_subcategories }
                        join content in _context.contents
                        on magnamentContent.id_content equals content.id_content
                        where (interiorSubCategory.id_catgeory == categoryId
                        && interiorSubCategory.id_subcategory == SubcategoryId)
                        && (interiorSubCategory.name.Contains(name)
                        || subCategory.name.Contains(name)
                        || category.name.Contains(name))
                        select new ManageContentResponse
                        {
                            id_content = magnamentContent.id_content,
                            title = content.title,
                            category_name = category.name,
                            id_category = interiorSubCategory.id_catgeory,
                            Display = content.active ? "On Display" : "Hidden",
                            active = content.active,
                            unlocked = content.unLocked,
                            id_interior_subCategory = magnamentContent.id_interior_subcategories,
                            id_subCategory = magnamentContent.id_subcategories
                        };

            return query.ToList();
        }
        public List<ManageContentResponse> GetManageContenteByNameCategoryIdSubcategoryIdInteriorSubcategoryId
            (string name,int categoryId,int SubcategoryId, int interiorSubcategoryId)
        {
            var query = from magnamentContent in _context.magnamentContentsCategories
                        join interiorSubCategory in _context.interiorSubCategories
                        on new { c = magnamentContent.id_categories, s = magnamentContent.id_subcategories, i = magnamentContent.id_interior_subcategories }
                        equals new { c = interiorSubCategory.id_catgeory, s = interiorSubCategory.id_subcategory, i = interiorSubCategory.id_interior_subcategory }
                        join category in _context.categories
                        on interiorSubCategory.id_catgeory equals category.id_categories
                        join subCategory in _context.subCategories
                        on new { c = interiorSubCategory.id_catgeory, s = interiorSubCategory.id_subcategory }
                        equals new { c = subCategory.id_categories, s = subCategory.id_subcategories }
                        join content in _context.contents
                        on magnamentContent.id_content equals content.id_content
                        where (interiorSubCategory.id_catgeory == categoryId
                        && interiorSubCategory.id_subcategory == SubcategoryId
                        && interiorSubCategory.id_interior_subcategory == interiorSubcategoryId) 
                        && (interiorSubCategory.name.Contains(name)
                        || subCategory.name.Contains(name)
                        || category.name.Contains(name))
                        select new ManageContentResponse
                        {
                            id_content = magnamentContent.id_content,
                            title = content.title,
                            category_name = category.name,
                            id_category = interiorSubCategory.id_catgeory,
                            Display = content.active ? "On Display" : "Hidden",
                            active = content.active,
                            unlocked = content.unLocked,
                            id_interior_subCategory = magnamentContent.id_interior_subcategories,
                            id_subCategory = magnamentContent.id_subcategories
                        };

            return query.ToList();
        }

        public List<ManageContentResponse> GetManageContente()
        {
            var query = from magnamentContent in _context.magnamentContentsCategories
                        join interiorSubCategory in _context.interiorSubCategories
                        on new { c = magnamentContent.id_categories, s = magnamentContent.id_subcategories, i = magnamentContent.id_interior_subcategories }
                        equals new { c = interiorSubCategory.id_catgeory, s = interiorSubCategory.id_subcategory, i = interiorSubCategory.id_interior_subcategory }
                        join category in _context.categories
                        on interiorSubCategory.id_catgeory equals category.id_categories
                        join subCategory in _context.subCategories
                        on new { c = interiorSubCategory.id_catgeory, s = interiorSubCategory.id_subcategory }
                        equals new { c = subCategory.id_categories, s = subCategory.id_subcategories }
                        join content in _context.contents
                        on magnamentContent.id_content equals content.id_content                        
                        select new ManageContentResponse
                        {
                            id_content = magnamentContent.id_content,
                            title = content.title,
                            category_name = category.name,
                            id_category = interiorSubCategory.id_catgeory,
                            Display = content.active ? "On Display" : "Hidden",
                            active = content.active,
                            unlocked = content.unLocked,
                            id_interior_subCategory = magnamentContent.id_interior_subcategories,
                            id_subCategory = magnamentContent.id_subcategories
                        };

            return query.ToList();
        }

        private Challenge.Entities.Entities.Content SetContent(ContentRequest request)
        {
            Challenge.Entities.Entities.Content content = new Challenge.Entities.Entities.Content();

            content.title = request.title;
            content.active = request.active;
            content.unLocked = request.unLocked;
            content.delete = false;
            content.date_create = DateTime.Now;


            return content;
        }

        private MagnamentContentsCategories SetManageContent(ListCategories request, int idContent)
        {
            MagnamentContentsCategories content = new MagnamentContentsCategories();

            content.id_content = idContent;
            content.id_categories = request.id_catgeory;
            content.id_subcategories = request.id_subcategory;
            content.id_interior_subcategories = request.id_interior_subcategory;
            return content;
        }
    }
}