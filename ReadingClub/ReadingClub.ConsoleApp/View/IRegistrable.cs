using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.View
{
    interface IRegistrable
    {
        void RegisterElement(int id);
        void VisualizeElement();
        void ModifyElement();
        void RemoveElement();
    }
}
