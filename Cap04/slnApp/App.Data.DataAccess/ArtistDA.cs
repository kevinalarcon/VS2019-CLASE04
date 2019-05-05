using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DataAccess
{
    public class ArtistDA
    {
        public List<Artist> GetAll()
        {
            var result = new List<Artist>();

            using (var db = new DbModel())
            {
                result = db.Artist.ToList();
            }

            return result;
        }
    }
}
