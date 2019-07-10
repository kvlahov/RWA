using Hybrid.Models.Enums;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Hybrid.Models.DAL
{
    class SQLRepo : IRepository
    {
        private static DataSet ds;
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public void InsertUser(User user)
        {
            SqlHelper.ExecuteNonQuery(cs, "insertUser",
                user.EntityID,
                user.Name,
                user.Surname,
                user.Height,
                user.Weight,
                user.Sex,
                user.DateOFBirth,
                user.LevelOfActivityID,
                user.DiabetesType
                );
        }

        public void InsertIngredient(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        public Ingredient GetIngredient(int id)
        {
            ds = SqlHelper.ExecuteDataset(cs, "getIngredient", id);
            DataRow row = ds.Tables[0].Rows[0];
            return new Ingredient
            {
                Id = (int)row["IDIngredient"],
                Name = row["Name"].ToString(),
                TypeId = (int)row["IngredientTypeID"]

            };
        }

        public IList<Ingredient> GetAllIngredients()
        {
            throw new NotImplementedException();
        }

        public IList<UnitEnergy> GetUnitsOfMesurement(int ingredientId)
        {
            ds = SqlHelper.ExecuteDataset(cs, "getUnitsOfMesurementForIngredient", ingredientId);
            IList<UnitEnergy> units = new List<UnitEnergy>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var unitOFMesurement = new UnitOfMesurement
                {
                    Id = (int)row["IDUnitOfMesurement"],
                    Type = row["UnitOfMesurement"].ToString()
                };

                units.Add
                    (
                        new UnitEnergy
                        {
                            Kcal = Double.Parse(row["EnergyKcal"].ToString()),
                            Value = Double.Parse(row["Value"].ToString()),
                            Unit = unitOFMesurement

                        }
                    );
            }

            return units;
        }

        public IList<string> GetMealNames(int noOfMeals)
        {
            ds = SqlHelper.ExecuteDataset(cs, "getMealNames", noOfMeals);
            IList<string> names = new List<string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                names.Add(row["Name"].ToString());
            }
            return names;
        }

        public Ingredient GetRandomIngredient(int typeId)
        {
            ds = SqlHelper.ExecuteDataset(cs, "getRandomIngredient", typeId);
            DataRow row = ds.Tables[0].Rows[0];
            return new Ingredient
            {
                Id = (int)row["IDIngredient"],
                Name = row["Name"].ToString(),
                TypeId = (int)row["IngredientTypeID"]

            };
        }

        public IDictionary<IngredientType, int> GetAllIngredientTypes()
        {
            ds = SqlHelper.ExecuteDataset(cs, "getAllIngredientTypes");
            var types = new Dictionary<IngredientType, int>();
            IngredientType ingType = IngredientType.Other;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                switch (row["Type"].ToString())
                {
                    case "Ugljikohidrati":
                        ingType = IngredientType.Carbs;
                        break;
                    case "Proteini":
                        ingType = IngredientType.Protein;
                        break;
                    case "Masti":
                        ingType = IngredientType.Fat;
                        break;
                    default:
                        break;
                }
                types.Add(ingType, (int)row["IDIngredientType"]);
            }
            return types;
        }

        public bool isUserSetup(string entityID)
        {
            //var result = (bool) SqlHelper.ExecuteScalar(cs, "isUserSetup", userID);

            ds = SqlHelper.ExecuteDataset(cs, "isUserSetup", entityID);
            DataRow row = ds.Tables[0].Rows[0];
            var result = (bool)row[0];
            return result;

        }

        public IList<LevelOfActivity> GetLvlsOfActivity()
        {
            IList<LevelOfActivity> result = new List<LevelOfActivity>();
            ds = SqlHelper.ExecuteDataset(cs, "getLvlsOfActivity");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                result.Add(
                    new LevelOfActivity
                    {
                        Id = (int)row["IDLvlOfActivity"],
                        Type = row["Type"].ToString()
                    });
            }

            return result;
        }

        public User GetUser(string entityID)
        {
            ds = SqlHelper.ExecuteDataset(cs, "getUser", entityID);
            DataRow row = ds.Tables[0].Rows[0];

            User u = new User();
            u.Id = (int)row["IDUser"];
            u.EntityID = row["CredentialsID"].ToString();
            u.Name = row["Name"].ToString();
            u.Surname = row["Surname"].ToString();
            u.Height = float.Parse(row["HeightCm"].ToString());
            u.Weight = float.Parse(row["WightKg"].ToString());
            u.Sex = char.Parse(row["Sex"].ToString());
            u.DateOFBirth = DateTime.Parse(row["DateOfBirth"].ToString());
            u.LevelOfActivityID = (int)row["LevelOfActivityID"];
            u.DiabetesType = int.Parse(row["DiabetesType"].ToString());

            return u;
        }

        public IList<NutrientsPerMeal> GetNutrientsPerMeal(int noOfMeals)
        {
            ds = SqlHelper.ExecuteDataset(cs, "getNutrientsPerMeal", noOfMeals);
            IList<NutrientsPerMeal> nutrients = new List<NutrientsPerMeal>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var meal = new NutrientsPerMeal();

                meal.PercentCarbs = double.Parse(row["PercentageOfCarbs"].ToString());
                meal.PercentFat = double.Parse(row["PercentageOfCarbs"].ToString());
                meal.PercentProtein = double.Parse(row["PercentageOfCarbs"].ToString());
                meal.MealId = (int)row["IDMealName"];
                meal.MealName = row["Name"].ToString();
                meal.OfMeals = int.Parse(row["OfMeals"].ToString());
                meal.PercentCalorie = double.Parse(row["PercentageOfCal"].ToString());

                nutrients.Add(meal);
            }
            return nutrients;
        }

        public void InsertMenu(MenuViewModel menu)
        {
            int menuId = Convert.ToInt32(SqlHelper.ExecuteScalar(cs, "insertMenu", menu.ForDay, menu.User.Id));

            foreach (var meal in menu.Meals)
            {
                int mealId = Convert.ToInt32(SqlHelper.ExecuteScalar(cs, "insertMeal", menuId, meal.MealNameId));

                foreach (var ing in meal.Ingredients)
                {
                    ing.CalculatedUnitEnergy.ToList().ForEach(unit => {
                    SqlHelper.ExecuteNonQuery(cs, "insertIngredientForMeal", mealId, ing.Id, unit.Value, unit.Unit.Id);
                    });

                }
            }
        }

        public MenuViewModel GetMenu(DateTime date, int userId)
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetMenuForUser", userId, date);
            MenuViewModel menu = new MenuViewModel();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                /*
                IDMenu	

                MealName	
                PercentageOfCal

                Ingredient	
                IDIngredientType	
                IngredientType
                
                CalculatedValue	
                UnitOfMesurement
                 */

                //menu.
            }

            return menu;
        }
    }
}