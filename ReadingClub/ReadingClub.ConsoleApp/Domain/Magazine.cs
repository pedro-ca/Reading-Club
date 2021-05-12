using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.Domain
{
    class Magazine
    {
        private string magazineCollection;
        private int editionNumber;
        private DateTime releaseYear;
        private StorageBox boxStored;

        public Magazine(string magazineCollection, int editionNumber, DateTime releaseYear, StorageBox boxStored)
        {
            this.magazineCollection = magazineCollection;
            this.editionNumber = editionNumber;
            this.releaseYear = releaseYear;
            this.boxStored = boxStored;
        }

        public string MagazineCollection { get => magazineCollection;}
        public int EditionNumber { get => editionNumber;}
        public DateTime ReleaseYear { get => releaseYear;}
        internal StorageBox BoxStored { get => boxStored;}
    }
}
