﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMVCContext _context;

        public SalesRecordService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.date >= minDate.Value);    
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.date <= maxDate.Value);
            }

            return await result
                .Include(x => x.seller)
                .Include(x => x.seller.department)
                .OrderByDescending(x => x.date)
                .ToListAsync();
        }
    }
}
