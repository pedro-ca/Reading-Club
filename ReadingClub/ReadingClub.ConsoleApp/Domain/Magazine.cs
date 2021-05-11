using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.Domain
{
    class Magazine
    {
        string magazineCollection;
        int editionNumber;
        DateTime releaseYear;
        StorageBox boxStored;

        public Magazine(string magazineCollection, int editionNumber, DateTime releaseYear, StorageBox boxStored)
        {
            this.magazineCollection = magazineCollection;
            this.editionNumber = editionNumber;
            this.releaseYear = releaseYear;
            this.boxStored = boxStored;
        }
    }
}
