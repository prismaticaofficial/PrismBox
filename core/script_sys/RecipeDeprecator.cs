using PrismBox.core.script_ext;
using PrismBox.core.script_it.prism_it_comps;

namespace PrismBox.core.script_sys
{
    internal class RecipeDeprecator : ModSystem
    {
        public override void PostAddRecipes()
        {
            //Keep yourself safe tonight, ItemID.Sets.Deprecated...

            foreach (Recipe r in Main.recipe.Where(x => x.createItem.HasComponent<DeprecatedComponent>() || x.requiredItem.Any(x => x.HasComponent<DeprecatedComponent>())))
                r.DisableRecipe();

            base.PostAddRecipes();
        }
    }
}