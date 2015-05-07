using System;
using AutoMapper;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Dynamic;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.DAL.Models;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Model;


namespace OnlineCookbook.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        
        protected IRepository Repository { get; private set; }
       

        public RecipeRepository(IRepository repository)
        {
            Repository = repository;       
        }

        private IUnitOfWork CreateUnitOfWork()
        {
            return Repository.CreateUnitOfWork();
        }


        public virtual async Task<List<IRecipe>> GetAsync(string sortOrder = "recipeId", int pageNumber = 1, int pageSize = 20)
        {
            try
            {
                List<IRecipe> page;
                pageSize = (pageSize > 20) ? 20 : pageSize;

                switch (sortOrder)
                { //poco?
                    case "recipeId":
                       page = new List<IRecipe>(Mapper.Map<List<RecipePOCO>>(
                             await Repository.WhereAsync<Recipe>()
                            .OrderBy(item => item.CategoryId) //po kategorijama?
                            .Skip<Recipe>((pageNumber - 1) * pageSize)
                            .Take<Recipe>(pageSize)
                            .ToListAsync<Recipe>())
                            );
                        break;
                    default:
                        throw new ArgumentException("Wrong order.");
                }

                foreach (var recipe in page)
                {
                    if (recipe.HasPicture)
                    {
                          //RecipePictures iz Collections? Mapping?                  
                        recipe.RecipePictures = new List<IRecipePicture>(Mapper.Map<List<RecipePicturePOCO>>(
                            await Repository.WhereAsync<RecipePicture>()
                           .Where<RecipePicture>(item => item.RecipeId == recipe.Id)
                           .ToListAsync())
                            );                      
                    }
                    else
                    {
                        recipe.RecipePictures = null;
                    }
                }

                return page;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //insert recipe -->insert preparation step, step picture?
        public virtual async Task<int> InsertRecipe(IUnitOfWork unitOfWork, List<IRecipe> recipes = null, List<IRecipePicture> recipePicture = null)
        {
            try 
            {
                if (recipes == null)
                {
                    return 0;
                }


                foreach (var recipe in recipes) //prolazim po svim receptima
                {
                    await unitOfWork.AddAsync<Recipe>(Mapper.Map<Recipe>(recipe));//iz Dala ili iz modela i zašto?

                    var recipePictures = recipePicture.Find(r => recipe.Id == r.RecipeId);
                    
                    if (recipe.HasPicture && recipePicture != null)
                    {
                        await unitOfWork.AddAsync<RecipePicturePOCO>(Mapper.Map<RecipePicturePOCO>(recipePicture));
                    }
                    else if (recipe.HasPicture && recipePicture == null)
                    {
                        throw new ArgumentNullException("Needed picture for recipe with Id =" + recipe.Id + ".");
                    }
                    else if (!recipe.HasPicture && recipePicture != null)
                    {
                        throw new ArgumentException("No picture dor recipe with Id " + recipe.Id + ".");
                    }
                    //if for preparation step and preparation step picture                    
                }
                return 1;          
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        //provjeriti
        protected async Task<int> UpdateRecipe(IUnitOfWork unitOfWork, List<IPreparationStep> preparations = null, List<IPreparationStep> preparationPictures = null)
        {
            try
            {
                if (preparations == null)
                {
                    return 0;
                }

              
                foreach (var preparation in preparations)
                {
                    await unitOfWork.UpdateAsync<PreparationStep>(Mapper.Map<PreparationStep>(preparation));

                    var preparationPicture = preparationPictures.Find(p => preparation.Id == p.Id);
                    if (preparation.HasPicture && preparationPicture != null)
                    {
                        await unitOfWork.UpdateAsync<PreparationStepPicture>(Mapper.Map<PreparationStepPicture>(preparationPicture));
                    }
                    else if (preparation.HasPicture && preparationPicture == null)
                    {
                        throw new ArgumentNullException("Picture needed for AnswerChoice with id=" + preparation.Id + ".");
                    }
                    else if (!preparation.HasPicture && preparationPicture != null)
                    {
                        throw new ArgumentException("AnswerChoice with id=" + preparation.Id + " should not have picture.");
                    }
                }
                return 1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //jos update koraka?
        protected async Task<int> AddPreparationSteps(IUnitOfWork unitOfWork, List<IPreparationStep> steps = null, List<IPreparationStepPicture> stepPictures = null)
        {
            try
            {
                if (steps == null)
                {
                    return 0;
                }

                foreach (var step in steps)
                {
                    await unitOfWork.AddAsync<PreparationStep>(Mapper.Map<PreparationStep>(step)); //provjeri

                    var stepPicture = stepPictures.Find(c => step.Id == c.PreparationStepId);
                    if (step.HasPicture && stepPicture != null)
                    {
                        await unitOfWork.AddAsync<PreparationStepPicture>(Mapper.Map<PreparationStepPicture>(stepPicture));
                    }
                    else if (step.HasPicture && stepPicture == null)
                    {
                        throw new ArgumentNullException("Need picture for id =" + step.Id + "!");
                    }
                    else if (!step.HasPicture && stepPicture != null)
                    {
                        throw new ArgumentException("There shouldn't be pictures with Id =" + step.Id + ".");
                    }
                }
                return 1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<IRecipe> GetAsync(Guid id)
        {   //hasPicture? ili jos jednu metodu GetAsync?
            try 
            {
                return Mapper.Map<RecipePOCO>(await Repository.SingleAsync<Recipe>(id));           
            }
            catch (Exception e)
            {
                throw e;
            }        
        }

        public virtual Task<int> InsertAsync(IRecipe entity)
        {
            try
            {
                return Repository.InsertAsync<Recipe>(Mapper.Map<Recipe>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> UpdateAsync(IRecipe entity)
        {
            try
            {
                return Repository.UpdateAsync<Recipe>(Mapper.Map<Recipe>(entity));
            }

            catch (Exception e)
            {
                throw e;
            }     
        }

        //provjeriti (tako isto i za alergen), lista recepata koja ima tj alergen?
        public virtual async Task<List<IRecipe>> GetByAlergenAsync(Guid alergenId)
        {
            try
            {
                List<IRecipeAlergen> recipes = new List<IRecipeAlergen>(Mapper.Map<List<RecipeAlergenPOCO>>(
                    await Repository.WhereAsync<RecipeAlergen>()
                    .Where<RecipeAlergen>(item => item.Id == alergenId)
                    .ToListAsync<RecipeAlergen>())
                    );

                return  alergens;
            }
                

            catch (Exception e)
            {
                throw e;
            }

        }


        public virtual async Task<int> DeleteAsync(IRecipe entity)
        {
            try
            {
                IUnitOfWork unitOfWork = CreateUnitOfWork();

                if (entity.HasPicture)
                {
                    var picture = await Repository.WhereAsync<RecipePicture>()
                        .Where(p => entity.Id == p.RecipeId)
                        .SingleAsync();
                    await unitOfWork.DeleteAsync<RecipePicture>(picture);               
                }

                //potrebno?
                 if (entity.HasSteps) 
                  {
                      var steps = await Repository.WhereAsync<PreparationStep>()
                          .Where(s => entity.Id == s.RecipeId)
                          .ToListAsync();

                      foreach (var step in steps) //provjera da li mi koraci imaju sliku
                      {
                          if (step.HasPicture)
                          {
                              var stepPicture = await Repository.WhereAsync<PreparationStepPicture>()
                                  .Where(s => step.Id == s.PreparationStepId)
                                  .SingleAsync();
                              await unitOfWork.DeleteAsync<PreparationStepPicture>(stepPicture);
                          }
                          await unitOfWork.DeleteAsync<PreparationStep>(step);
                      }
                  }

                 if (entity.HasComment)
                 {
                     var comment = await Repository.WhereAsync<Comment>()
                           .Where(com => entity.Id == com.RecipeId)
                           .SingleAsync();

                     await unitOfWork.DeleteAsync<Comment>(comment);  //provjeriti 
                 }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



         public virtual async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                var recipe = await Repository.SingleAsync<Recipe>(id);
                return await DeleteAsync(Mapper.Map<RecipePOCO>(recipe));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }   
}


        






     


