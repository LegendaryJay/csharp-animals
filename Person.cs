namespace csharp_animals
{
    public abstract class Person
    {
        private string _name;

        protected Person(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }
    }
}