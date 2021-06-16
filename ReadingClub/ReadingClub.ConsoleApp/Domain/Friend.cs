namespace ReadingClub.ConsoleApp.Domain
{
    public class Friend : Entity
    {
        private string name;
        private string nameGuardian;
        private string telephone;
        private string address;

        public Friend(int id, string name, string nameGuardian, string telephone, string address)
        {
            this.id = id;
            this.name = name;
            this.nameGuardian = nameGuardian;
            this.telephone = telephone;
            this.address = address;
        }

        public override string ToString()
        {
            return $"Friend {id}: [{name},{nameGuardian},{telephone},{address}]";
        }

        public string Name { get => name; }
        public string NameGuardian { get => nameGuardian; }
        public string Telephone { get => telephone; }
        public string Address { get => address; }


    }
}
