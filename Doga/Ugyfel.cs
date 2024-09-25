using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doga
{
    class Ugyfel
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public int Kor { get; set; }
        public string Orszag { get; set; }
        public int UtazasokSzama { get; set; }

        public Ugyfel(int id, string nev, int kor, string orszag, int utazasokSzama)
        {
            Id = id;
            Nev = nev;
            Kor = kor;
            Orszag = orszag;
            UtazasokSzama = utazasokSzama;
        }
    }
}