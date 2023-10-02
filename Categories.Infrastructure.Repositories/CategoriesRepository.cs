using Categories.Dtos;
using Categories.lnterfaces;
using Challenge.Entities.Entities;
using ExceptionCategories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Categories.Infrastructure.Repositories
{
    public class CategoriesRepository: ICategoriesRepository
    {
        private readonly ApplicationContext _context;

        public CategoriesRepository(ApplicationContext context) { _context = context; }

        public async Task<int> CreateCategory(string name)
        {
            try
            {
                Challenge.Entities.Entities.Categories category = SetCategories(name);
                _context.categories.Add(category);
                await _context.SaveChangesAsync();

                return category.id_categories;
            }
            catch (Exception)
            {
                throw new ExceptionCreateCategories();
            }
        }

        public async Task<int> CreateInteriorSubCategory(int idCategoria,int idSubcategory, string name)
        {
            try
            {
                InteriorSubcategoriesCategories InteriorSubcategory = SetInteriorSubacategoria(idCategoria, 
                    idSubcategory, name);
                _context.interiorSubCategories.Add(InteriorSubcategory);
                await _context.SaveChangesAsync();
                return InteriorSubcategory.id_interior_subcategory;
            }
            catch (Exception)
            {
                throw new ExceptionCretaetInteriorSubcategories();
            }
        }

        public async Task<int> CreateSubCategory(int idCategoria, string name)
        {
            try
            {
                SubCategories subcategory = SetSubacategoria(idCategoria, name);
                _context.subCategories.Add(subcategory);
                await _context.SaveChangesAsync();
                return subcategory.id_subcategories;
            }
            catch (Exception)
            {
                throw new ExceptionCreateSubCategories();
            }
        }
        public async Task<List<CategoriesResponse>> GetAllCategories()
        {
            Challenge.Entities.Entities.Categories[] categories = await _context.categories.ToArrayAsync();
            return MapperCategoriesCategoriesResponse(categories.ToList());
        }

        public async Task<List<SubCategoriesResponse>> GetSubCategoriesByIdCategory(int categoryId)
        {
            List<SubCategories> categories = await _context.subCategories.Where(x => x.active == true && x.id_categories == categoryId).ToListAsync();
            return MapperSubCategoriesSubCategoriesResponse(categories);
        }

        public async Task<List<InteriorSubCategoriesResponse>> GetInteriorSubcategoriesByIdCategorySubCategories(int categoryId,
            int idSubcategory )
        {
            List<InteriorSubcategoriesCategories> categories = await _context.interiorSubCategories.Where(x => x.active == true
            && x.id_catgeory == categoryId && x.id_subcategory == idSubcategory).ToListAsync();
            return MapperInteriorSubCategoriesInteriorSubCategoriesResponse(categories);
        }
        

        public async Task UpdateCategory(int categoryId, string name) 
        {
            try
            {
                Challenge.Entities.Entities.Categories? category = _context.categories.FirstOrDefault(x => x.active == true && x.id_categories == categoryId);
                if (category == null)
                    throw new ExceptionCategoryNoExist();

                category.name = name;
                category.update_date = DateTime.Now;

                _context.ChangeTracker.Clear();
                _context.Update(category);
                await _context.SaveChangesAsync();
            }
            catch (ExceptionCategoryNoExist)
            {
                throw new ExceptionCategoryNoExist();
            }
            catch (Exception) 
            {
                throw new ExceptionUpdateCategories();
            }
        }
        public async Task UpdateSubCategory(int subCategoryId, int idCategory , string name)
        {
            try
            {
                SubCategories? subCategory = _context.subCategories.FirstOrDefault(x => x.active == true && x.id_subcategories == subCategoryId);
                if (subCategory == null)
                    throw new ExceptionSubCategoryNoExist();

                subCategory.id_categories = idCategory;
                subCategory.name = name;
                subCategory.update_date = DateTime.Now;

                _context.ChangeTracker.Clear();
                _context.Update(subCategory);
                await _context.SaveChangesAsync();
            }
            catch (ExceptionSubCategoryNoExist)
            {
                throw new ExceptionSubCategoryNoExist();
            }
            catch (Exception)
            {
                throw new ExceptionUpdateSubCategories();
            }
        }

        

        private SubCategories SetSubacategoria(int idCategoria, string name)
        {
            SubCategories subCategory = new SubCategories();

            subCategory.id_categories = idCategoria;
            subCategory.name = name;
            subCategory.create_date = DateTime.Now;
            subCategory.active = true;

            return subCategory;
        }
        private InteriorSubcategoriesCategories SetInteriorSubacategoria(int idCategoria,int idSubcategory, string name)
        {
            InteriorSubcategoriesCategories interiorSubCategory = new InteriorSubcategoriesCategories();

            interiorSubCategory.id_catgeory = idCategoria;
            interiorSubCategory.id_subcategory = idSubcategory;
            interiorSubCategory.name = name;
            interiorSubCategory.create_date = DateTime.Now;
            interiorSubCategory.active = true;

            return interiorSubCategory;
        }
        

        private Challenge.Entities.Entities.Categories SetCategories(string name)
        {
            Challenge.Entities.Entities.Categories category = new Challenge.Entities.Entities.Categories();
            category.name = name;
            category.create_date = DateTime.Now;
            category.active = true;

            return category;
        }

        private List<SubCategoriesResponse> MapperSubCategoriesSubCategoriesResponse(List<SubCategories> subCategories)
        {
            return subCategories.Select(subCategory => new SubCategoriesResponse
            {
                idCategories = subCategory.id_categories,
                idSubcategories = subCategory.id_subcategories,
                name = subCategory.name,
                acvive = subCategory.active
            }).ToList();
        }

        private List<InteriorSubCategoriesResponse> MapperInteriorSubCategoriesInteriorSubCategoriesResponse(List<InteriorSubcategoriesCategories>
            interiorSubCategories)
        {
            return interiorSubCategories.Select(subCategory => new InteriorSubCategoriesResponse
            {
                idCategories = subCategory.id_catgeory,
                idSubcategories = subCategory.id_subcategory,
                idInteriorSubcategories = subCategory.id_interior_subcategory,
                name = subCategory.name,
                acvive = subCategory.active
            }).ToList();
        }

        private List<CategoriesResponse> MapperCategoriesCategoriesResponse(List<Challenge.Entities.Entities.Categories> categories)
        {
            return categories.Select(categories => new CategoriesResponse
            {
                Id = categories.id_categories,               
                name = categories.name,
                active= categories.active
                
            }).ToList();            
        }

    }
}