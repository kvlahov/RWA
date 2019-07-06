using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

        public IDictionary<string, int> GetAllIngredientTypes()
        {
            throw new NotImplementedException();
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

            //return new User
            //{
            //    Id = (int)row["IDUser"],
            //    EntityID = row["CredentialsID"].ToString(),
            //    Name = row["Name"].ToString(),
            //    Surname = row["Surname"].ToString(),
            //    Height = (float)row["HeightCm"],
            //    Weight = (float)row["WightKg"],
            //    Sex = (char)row["Sex"],
            //    DateOFBirth = DateTime.Parse(row["DateOfBirth"].ToString()),
            //    LevelOfActivityID = (int)row["LevelOfActivityID"],
            //    DiabetesType = (int)row["DiabetesType"]
            //};

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
    }
}