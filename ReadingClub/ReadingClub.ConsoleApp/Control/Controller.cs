using ReadingClub.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingClub.ConsoleApp.Control
{
    class Controller<T> where T:Entity
    {
        const int REGISTER_LIMIT = 100;
        protected T[] registeredEntities = new T[REGISTER_LIMIT];
        protected int lastRegisteredId = 0;

        public string CreateEntity(T entity)
        {
            int position;
            string operationMessage;

            try
            {
                if (entity.Id == 0)
                {
                    entity.Id = GenerateId();
                    position = this.SelectVacantPosition();
                }
                else
                {
                    position = this.SelectPositionById(entity.Id);
                }


                registeredEntities[position] = entity;
                operationMessage = "OP_SUCCESS";
            }
            catch (Exception e)
            {
                operationMessage = "Error: " + e.Message;
            }

            return operationMessage;
        }

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

        public T SelectEntityById(int index)
        {
            T entityAux = null;

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
            object[] entityAux = new T[GetNumberOfEntities()];

            int i = 0;

            foreach (T entity in registeredEntities)
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
