using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Hybrid.Models.DAL
{
    class SQLRepo : IRepository
    {
        public static DataSet ds { get; set; }
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public void InsertUser(User user)
        {
            throw new NotImplementedException();
        }

        public void InsertIngredient(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        public Ingredient GetIngredient(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Ingredient> GetAllIngredients()
        {
            throw new NotImplementedException();
        }

        public IList<IngredientEnergy> GetUnitsOfMesurement(int ingredientId)
        {
            ds = SqlHelper.ExecuteDataset(cs, "getUnitsOfMesurementForIngredient", ingredientId);
            IList<IngredientEnergy> units = new List<IngredientEnergy>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var unitOFMesurement = new UnitOfMesurement
                {
                    Id = (int)row["IDUnitOfMesurement"],
                    Type = row["Type"].ToString()
                };

                var ingredient = new Ingredient
                {
                    Name = row["Ingredient"].ToString(),
                    Id = (int)row["IDIngredient"],
                    TypeId = (int)row["IDIngredientType"]
                };

                units.Add
                    (
                        new IngredientEnergy
                        {
                            Energy = (float)row["EnergyKcal"],
                            Ingredient = ingredient,
                            Value = (float)row["Value"],
                            Unit =  unitOFMesurement

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
                names.Add( row["Name"].ToString());
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

        public IDictionary<string, int> GetAllIngredientTypes()
        {
            throw new NotImplementedException();
        }
    }
}