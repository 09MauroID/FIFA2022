﻿using et12.edu.ar.AGBD.Ado;
using Fifa.AdoEt12.Mapeadores;
using Fifa.Core;

namespace Fifa.AdoEt12;
public class AdoFifa : IAdo
{
    public AdoAGBD AdoAGBD { get; set; }
    public MapHabilidad MapHabilidad { get; set; }
    public MapPosicion MapPosicion { get; set;}
    public AdoFifa(AdoAGBD adoAGBD)
    {
        AdoAGBD = adoAGBD;
        MapHabilidad = new MapHabilidad(adoAGBD);
        MapPosicion = new MapPosicion(adoAGBD);
    }
    public void AltaHabilidad(Habilidad habilidad)
        => MapHabilidad.AltaHabilidad(habilidad);

    public List<Habilidad> ObtenerHabilidades()
        => MapHabilidad.ColeccionDesdeTabla();

    public void AltaPosicion(Posicion posicion)
        => MapPosicion.AltaPosicion(posicion);

    public List<Posicion> ObtenerPosiciones()
        => MapPosicion.ColeccionDesdeTabla();
}
