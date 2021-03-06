﻿using System;
using System.Collections.Generic;

namespace ProtocolMicroservice.Repository
{
    public interface IRepository<E, ID>
        where E : IIdentifiable<ID>
        where ID : IComparable
    {
        E GetEntity(ID id);

        E GetEntityByName(E Name);

        IEnumerable<E> GetAllEntities();

        IEnumerable<E> GetAllNames();

        E AddEntity(E entity);

        void UpdateEntity(E entity);

        void DeleteEntity(E entity);
    }
}