using DonutQueen.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;

namespace DonutQueen.Data
{
    public static class DonutQueenInitialiser
    {
        public static void MaakLeveranciers(DonutQueenContext context)
        {
            DonutQueenContext _context = context;

            if(_context.Leveranciers.Any())
            {
                if(_context.LeverancierDonuts.Any())
                {
                    return; //Afbreken als er al Leveranciers bestaan
                }
                else
                {
                    var leverancierdonut = new List<LeverancierDonut>
                 {
                    new LeverancierDonut{LeverancierId=1,DonutId=3},
                    new LeverancierDonut{LeverancierId=1,DonutId=4},
                    new LeverancierDonut{LeverancierId=1,DonutId=6},
                    new LeverancierDonut{LeverancierId=2,DonutId=4},
                    new LeverancierDonut{LeverancierId=2,DonutId=6},
                    new LeverancierDonut{LeverancierId=2,DonutId=8},
                    new LeverancierDonut{LeverancierId=1,DonutId=7},
                    new LeverancierDonut{LeverancierId=3,DonutId=9},
                    new LeverancierDonut{LeverancierId=3,DonutId=3},
                    new LeverancierDonut{LeverancierId=3,DonutId=10},

                  };
                    leverancierdonut.ForEach(k => _context.LeverancierDonuts.Add(k));
                    _context.SaveChanges();


                }
                               
            }
            else
            {
                var leveranciers = new List<Leverancier>
                 {
                new Leverancier{LeveranciersNaam="Het Bakkertje",VoornaamContact="Mark",FamilienaamContact="Huygens",Emailadres="Mark.Huygens@gmail.com",Straat="Kerkstraat",Huisnummer=15,Postcode=2300 },
                new Leverancier{LeveranciersNaam="Uw warme bakker",VoornaamContact="Samira",FamilienaamContact="Ben Akkra",Emailadres="uwb_Samira@hotmail.com",Straat="Grote Markt",Huisnummer=46,Postcode=2440 },
                new Leverancier{LeveranciersNaam="t Banketbakkertje",VoornaamContact="Jean",FamilienaamContact="François",Emailadres="mrjean@yahoo.com",Straat="Stationsplein",Huisnummer=5,Postcode=2500 },
                new Leverancier{LeveranciersNaam="Apnos groothandel",VoornaamContact="Marcel",FamilienaamContact="",Emailadres="info@apnos.be",Straat="Industrieterrein",Huisnummer=137,Postcode=1000 }
                 };
                leveranciers.ForEach(k => _context.Leveranciers.Add(k));
                _context.SaveChanges();
            }






        }

    }
}
