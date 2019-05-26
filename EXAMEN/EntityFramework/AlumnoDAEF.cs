using EntidadesEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class AlumnoDAEF
    {
        public List<Alumno> GetAll()
        {
            var result = new List<Alumno>();

            using (var db = new DBModel())
            {
                result = db.Alumno.ToList();
            }

            return result;
        }
    }
}
