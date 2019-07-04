﻿using System;
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
        IList<IngredientEnergy> GetUnitsOfMesurement(int ingredientId);
        IList<string> GetMealNames(int noOfMeals);
        Ingredient GetRandomIngredient(int typeId);
        IDictionary<string, int> GetAllIngredientTypes();

    }
}