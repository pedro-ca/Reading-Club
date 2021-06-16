namespace ReadingClub.ConsoleApp.Domain
{
    public abstract class Entity
    {
        protected int id;

        public int Id { get => id; set => id = value; }

        public abstract override string ToString();
    }
}
