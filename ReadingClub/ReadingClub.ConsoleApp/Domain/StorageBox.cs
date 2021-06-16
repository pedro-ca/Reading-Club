namespace ReadingClub.ConsoleApp.Domain
{
    class StorageBox : Entity
    {
        private string color;
        private string tag;
        private int number;

        public StorageBox(int id, string color, string tag, int number)
        {
            this.id = id;
            this.color = color;
            this.tag = tag;
            this.number = number;
        }
        public override string ToString()
        {
            return $"Storage Box {id}: [{color},{tag},{number}]";
        }

        public string Color { get => color; }
        public string Tag { get => tag; }
        public int Number { get => number; }
    }
}
