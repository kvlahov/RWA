﻿using Hybrid.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hybrid.Models.DAL
{
    public interface IRepository
    {
        void InsertUser(User user);
        void InsertIngredient(Ingredient ingredient);
        Ingredient GetIngredient(int id);
        IList<Ingredient> GetAllIngredients();
        IList<UnitEnergy> GetUnitsOfMesurement(int ingredientId);
        IList<string> GetMealNames(int noOfMeals);
        Ingredient GetRandomIngredient(int typeId);
        IDictionary<string, int> GetAllIngredientTypes();
        bool isUserSetup(string entityID);
        IList<LevelOfActivity> GetLvlsOfActivity();
        IList<NutrientsPerMeal> GetNutrientsPerMeal(int noOfMeals);
        User GetUser(string entityID);

        void InsertMenu(MenuViewModel menu);
        MenuViewModel GetMenu(DateTime date, int userId);
        IList<DateTime> GetDatesForMenus(int userId);

        IList<Ingredient> GetExcludedIngredients(int userID);
        void InsertExcludedIngredients(IList<int> excludedIngredientsID, int userID);
        void RemoveExcludedIngredients(IList<int> excludedIngredientsID, int userID);
        IList<UnitOfMesurement> GetUnitTypes();

        void UpdateIngredient(Ingredient newIng);
        void UpdateNutrients(NutrientsPerMeal newNutrients);
        void UpdateUnits(UnitEnergy newUnitEnergy);
        IList<int> GetNumberOfMeals();

        void InsertUnitOfMesurement(UnitOfMesurement unit);
        void InsertUnitEnergy(UnitEnergy unit, int ingID);
        void DeleteUnitEnergy(int rowID);

        IList<User> GetAllUsers();
    }
}
