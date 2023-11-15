using Fifa.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fifa.Mvc.ViewModels
{
    public class VMFutbolista
    {
        public SelectList? Posiciones { get; set; }
        public byte IdFutbolista { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Nacimiento { get; set; }
        public byte Velocidad { get; set; }
        public byte Remate { get; set; }
        public byte Pase { get; set; }
        public byte Defensa { get; set; }

        public VMFutbolista() { }
        public VMFutbolista(IEnumerable<Posicion> posiciones)
        {
            Posiciones = new SelectList(posiciones,
                                        dataTextField: nameof(Posicion.Nombre),
                                        dataValueField: nameof(Posicion.IdPosicion));
        }
        public VMFutbolista(IEnumerable<Posicion> posiciones, Futbolista futbolista)
        {
            Posiciones = new SelectList(posiciones,
                                        dataTextField: nameof(Posicion.Nombre),
                                        dataValueField: nameof(Posicion.IdPosicion),
                                        selectedValue: futbolista.IdFutbolista);

            Nombre = futbolista.Nombre;
            Apellido = futbolista.Apellido;
        }
    }
}