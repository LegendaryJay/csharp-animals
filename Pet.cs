namespace csharp_animals
{
    public abstract class Pet
    {
        protected string Name;

        protected Pet(string name)
        {
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }
    }
}