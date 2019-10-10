using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _contex;

        public SellerService(SalesWebMvcContext contex)
        {
            _contex = contex;
        }

        public async Task<List<Seller>> FindAllAsyn()
        {
            return await _contex.Seller.ToListAsync();
        }

        public async Task  InsertAsync(Seller seller)
        {
            _contex.Add(seller);
            await _contex.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _contex.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _contex.Seller.FindAsync(id);
            _contex.Remove(obj);
           await  _contex.SaveChangesAsync();
        }

        public  async Task UpdateAsync(Seller obj)
        {
            if (!await _contex.Seller.AnyAsync(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _contex.Update(obj);
                await _contex.SaveChangesAsync();
            } catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
