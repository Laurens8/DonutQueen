using DonutQueen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutQueen.Data
{
    public interface IUnitOfWork
    {
        IGenericRepository<Donut> DonutRepository { get; }
        IGenericRepository<Leverancier> LeverancierRepository { get; }
        IGenericRepository<Winkel> WinkelRepository { get; }

        IGenericRepository<WinkelDonut> WinkelDonutRepository { get; }

        IGenericRepository<LeverancierDonut> LeverancierDonutRepository { get; }

        Task Save();
    }
}
