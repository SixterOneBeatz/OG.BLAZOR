using Microsoft.AspNetCore.Components;
using OG.BLAZOR.BUSINESS;
using OG.BLAZOR.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OG.BLAZOR.UI.Data
{
    public class PersonaService
    {
        private BPersona _bus = new BPersona();
        public Task<List<EPersona>> GetPersonasAsync()
        {
            return _bus.GetPersonas();
        }
        public Task<EPersona> GetPersonaAsync(int id)
        {
            return _bus.GetPersona(id);
        }
        public Task<int> AgregarAsync(EPersona p)
        {
            return _bus.IngresarBD(p);
        }
        public Task<int> ModificarrAsync(EPersona p)
        {
            return _bus.ModificarBD(p);
        }
        public Task<int> EliminarAsync(EPersona p)
        {
            return _bus.ElminarBD(p);
        }
    }
}
