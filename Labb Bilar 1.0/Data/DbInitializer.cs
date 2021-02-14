using Labb_Bilar_1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_Bilar_1._0.Data
{
    public class DbInitializer
    {
        public static void Initialize(BilContext context)
        {
            context.Database.EnsureCreated();

            if (context.Bilar.Any())
            {
                return;
            }
            var städer = new Stad[]
            {
                new Stad {Namn="Stockholm"},
                new Stad {Namn="Göteborg"},
                new Stad {Namn="Malmö"},
            };
            foreach (Stad s in städer)
            {
                context.Städer.Add(s);
            }
            context.SaveChanges();

            var Volvo = new Tillverkare { Namn = "Volvo" };
            var Ford = new Tillverkare { Namn = "Ford" };

            context.Tillverkarna.Add(Volvo);
            context.Tillverkarna.Add(Ford);

            context.SaveChanges();


            var bilhandlare = new Bilhandlare[]
           {
                new Bilhandlare{Namn="PåLager", StadId=0},
                new Bilhandlare{Namn="KöpBil", StadId=1},
                new Bilhandlare{Namn="SäljDinBil", StadId=1}
           };

            foreach (Bilhandlare k in bilhandlare)
            {
                context.Bilhandlare.Add(k);
            }
            context.SaveChanges();

            var bilar = new Bil[]

            {
                new Bil{Årsmodell=1994, Motortyp="Elektrisk", Modell="Leksak", Tillverkare=Volvo},
                new Bil{Årsmodell=2014, Motortyp="Bensin", Modell="SUV",Tillverkare=Volvo},
                new Bil{Årsmodell=2012, Motortyp="Elektrisk", Modell="XC60",Tillverkare=Ford},
                new Bil{Årsmodell=2007, Motortyp="Diesel", Modell="V40",Tillverkare=Ford},
            };
            foreach (Bil b in bilar)
            {
                context.Bilar.Add(b);
            }
            context.SaveChanges();
        }
    }
}
