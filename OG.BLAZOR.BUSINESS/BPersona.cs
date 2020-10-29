using OG.BLAZOR.DATA;
using OG.BLAZOR.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace OG.BLAZOR.BUSINESS
{
    public class BPersona
    {
        private DPersona _data = new DPersona();

        public async Task<List<EPersona>> GetPersonas()
        {
            List<EPersona> personas = new List<EPersona>();
            DataTable dt = _data.GetPersonas().Result;
            foreach (DataRow r in dt.Rows)
            {
                personas.Add(new EPersona(r));
            }
            return await Task.FromResult(personas);
        }

        public async Task<EPersona> GetPersona(int Id)
        {
            EPersona persona;
            DataRow r = _data.GetPersona(Id).Result;
            persona = new EPersona(r);
            return await Task.FromResult(persona);
        }

        public async Task<int> IngresarBD(EPersona persona)
        {
            int commandResult = 0;
            commandResult = _data.Ingresar(persona).Result;
            return await Task.FromResult(commandResult);
        }

        public async Task<int> ModificarBD(EPersona persona)
        {
            int commandResult = _data.Modificar(persona).Result;
            return await Task.FromResult(commandResult);
        }

        public async Task<int> ElminarBD(EPersona persona)
        {
            int commandResult = _data.Eliminar(persona).Result;
            return await Task.FromResult(commandResult);
        }
    }
}
