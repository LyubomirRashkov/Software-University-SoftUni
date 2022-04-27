namespace TemplatePattern
{
    public abstract class Bread
    {
        protected abstract void MixIngredients();

        protected abstract void Bake();

        protected abstract void Slice(); 

        public void Make() 
        {
            this.MixIngredients();
            this.Bake();
            this.Slice();
        }
    }
}
