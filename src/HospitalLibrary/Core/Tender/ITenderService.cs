﻿using System.Collections.Generic;

namespace HospitalLibrary.Core.Tender
{
    public interface ITenderService
    {
        IEnumerable<Tender> GetAll();
        Tender GetById(int id);
        void Create(Tender tender);
        void Update(Tender tender);
        void Delete(Tender tender);
        
     
    }
}
