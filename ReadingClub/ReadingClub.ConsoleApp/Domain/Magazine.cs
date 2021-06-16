using System;

namespace ReadingClub.ConsoleApp.Domain
{
    class Magazine : Entity
    {
        private string magazineCollection;
        private int editionNumber;
        private DateTime releaseYear;
        private StorageBox boxStored;

        public Magazine(int id, string magazineCollection, int editionNumber, DateTime releaseYear, StorageBox boxStored)
        {
            if (!isValidStorageBox(boxStored))
                throw new ArgumentException("Friend property cannot be set instantiated as a null value.");
            if (!IsValidDateTime(releaseYear))
                throw new ArgumentException("ReleaseYear property cannot be set as a date from the future.");

            this.id = id;
            this.magazineCollection = magazineCollection;
            this.editionNumber = editionNumber;
            this.releaseYear = releaseYear;
            this.boxStored = boxStored;
        }

        private bool IsValidDateTime(DateTime date)
        {
            return date <= DateTime.Now;
        }

        private bool isValidStorageBox(StorageBox box)
        {
            return box != null;
        }

        public override string ToString()
        {
            return $"Magazine {id}: [{magazineCollection}, {editionNumber}, {releaseYear}, {boxStored}]";
        }

        public string MagazineCollection { get => magazineCollection; }
        public int EditionNumber { get => editionNumber; }
        public DateTime ReleaseYear { get => releaseYear; }
        internal StorageBox BoxStored { get => boxStored; }
    }
}
