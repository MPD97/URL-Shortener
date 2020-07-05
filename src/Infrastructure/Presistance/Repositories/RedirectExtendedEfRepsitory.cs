﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Context;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Presistance.Repositories
{
    public class RedirectExtendedEfRepsitory : IRedirectExtendedRepsitory
    {
        private readonly ShortenerContext _shortenerContext;

        public RedirectExtendedEfRepsitory(ShortenerContext shortenerContext)
        {
            _shortenerContext = shortenerContext;
        }

        public async Task<RedirectExtended> FindByIdAsync(long id)
        {
            return await _shortenerContext.RedirectExtendeds
                .SingleOrDefaultAsync(a => a.RedirectExtendedId == id);
        }

        public async Task<RedirectExtended> FindByUrlAsync(string url)
        {
            return await _shortenerContext.RedirectExtendeds
                .SingleOrDefaultAsync(a => a.Url == url);
        }

        public async Task<long> GetCountAsync()
        {
            return await _shortenerContext.RedirectExtendeds
                .CountAsync();
        }

        public async Task<List<RedirectExtended>> GetAllAsync()
        {
            return await _shortenerContext.RedirectExtendeds
                .OrderByDescending(a => a.RedirectExtendedId)
                .ToListAsync();
        }

        public async Task<List<RedirectExtended>> GetAllAsync(int take, int skip)
        {
            return await _shortenerContext.RedirectExtendeds
                .OrderByDescending(a => a.RedirectExtendedId)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task InsertAsync(RedirectExtended redirectExtended)
        {
            await _shortenerContext.RedirectExtendeds.AddAsync(redirectExtended);
        }

        public async Task DeleteAsync(RedirectExtended redirectExtended)
        {
            _shortenerContext.RedirectExtendeds.Remove(redirectExtended);
        }

        public async Task UpdateAsync(RedirectExtended redirectExtended)
        {
            _shortenerContext.RedirectExtendeds.Update(redirectExtended);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _shortenerContext.SaveChangesAsync();
        }
    }
}