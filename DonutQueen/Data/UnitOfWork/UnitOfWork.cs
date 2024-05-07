using DonutQueen.Data;
using DonutQueen.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutQueen.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DonutQueenContext _context;

        private IGenericRepository<Donut> donutRepository;
        private IGenericRepository<Leverancier> leverancierRepository;
        private IGenericRepository<Winkel> winkelRepository;
        private IGenericRepository<WinkelDonut> winkelDonutRepository;
        private IGenericRepository<LeverancierDonut> leverancierDonutRepository;

        public UnitOfWork(DonutQueenContext context)
        {
            _context = context;
        }

        public IGenericRepository<Donut> DonutRepository
        {
            get
            {
                if (donutRepository == null) donutRepository = new GenericRepository<Donut>(_context);

                return donutRepository;
            }
        }
        public IGenericRepository<Leverancier> LeverancierRepository
        {
            get
            {
                if (leverancierRepository == null) leverancierRepository = new GenericRepository<Leverancier>(_context);

                return leverancierRepository;
            }
        }

        public IGenericRepository<Winkel> WinkelRepository
        {
            get
            {
                if (winkelRepository == null) winkelRepository = new GenericRepository<Winkel>(_context);

                return winkelRepository;
            }
        }

        public IGenericRepository<WinkelDonut> WinkelDonutRepository
        {
            get
            {
                if (winkelDonutRepository == null) winkelDonutRepository = new GenericRepository<WinkelDonut>(_context);

                return winkelDonutRepository;
            }
        }

        public IGenericRepository<LeverancierDonut> LeverancierDonutRepository
        {
            get
            {
                if (leverancierDonutRepository == null) leverancierDonutRepository = new GenericRepository<LeverancierDonut>(_context);

                return leverancierDonutRepository;
            }
        }


        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}
