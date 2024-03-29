﻿using Microsoft.AspNetCore.Mvc;
using RAShop.Shared.DTO;

namespace RAShop.CustomerSite.Interfaces
{
    public interface ICategory 
    {
        Task<List<CategoryDTO>> GetAll();
    }
}
