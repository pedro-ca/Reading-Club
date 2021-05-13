using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.View
{
    interface IRegistrable
    {
        void RegisterElement();
        void VisualizeAllElements();
        void ModifyElement();
        void RemoveElement();
    }
}
