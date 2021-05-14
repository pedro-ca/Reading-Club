using ReadingClub.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.Control
{
    abstract class Controller
    {
        const int REGISTER_LIMIT = 100;
        protected Entity[] registeredEntities = new Entity[REGISTER_LIMIT];
        protected int lastRegisteredId = 0;

        public bool DeleteEntity(int index) 
        {
            if (index > 0 && index <= GetNumberOfEntities()) {
                for (int i = 0; i < registeredEntities.Length; i++)
                {
                    if (registeredEntities[i].Id == index)
                    {
                        registeredEntities[i] = null;

                        return true;
                    }
                }
            }

            return false;
        }

        public Entity SelectEntityById(int index)
        {
            Entity entityAux = null;

            for (int i = 0; i < registeredEntities.Length; i++)
            {
                if (registeredEntities[i] != null && registeredEntities[i].Id == index)
                {
                    entityAux = registeredEntities[i];

                    break;
                }
            }

            return entityAux;
        }

        public object[] SelectAllEntities()
        {
            object[] entityAux = new Entity[GetNumberOfEntities()];

            int i = 0;

            foreach (Entity entity in registeredEntities)
            {
                if (entity != null)
                    entityAux[i++] = entity;
            }

            return entityAux;
        }

        protected int GenerateId()
        {
            return ++lastRegisteredId;
        }

        protected int GetNumberOfEntities()
        {
            int numeroChamadosCadastrados = 0;

            for (int i = 0; i < registeredEntities.Length; i++)
            {
                if (registeredEntities[i] != null)
                {
                    numeroChamadosCadastrados++;
                }
            }

            return numeroChamadosCadastrados;
        }

        protected int SelectPositionById(int index)
        {
            for (int i = 0; i < registeredEntities.Length; i++)
            {
                if (registeredEntities[i] != null && registeredEntities[i].Id == index)
                {
                    return i;
                }
            }
            return -1;
        }
        
        protected int SelectVacantPosition()
        {
            for (int i = 0; i < registeredEntities.Length; i++)
            {
                if (registeredEntities[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
