using System.ComponentModel.DataAnnotations;

namespace Hybrid.Models.Enums
{
    public enum IngredientType
    {
        [Display(Name ="Ugljikohidrati")]
        Carbs,
        [Display(Name = "Masti")]
        Fat,
        [Display(Name = "Proteini")]
        Protein,
        [Display(Name = "Ostalo")]
        Other
    }
}