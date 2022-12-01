using et12.edu.ar.AGBD.Ado;
using Fifa.Core;

namespace Fifa.AdoEt12.Test;

    public class TransferenciaTest
    {
        public AdoFifa Ado { get; set; }
        public TransferenciaTest()
        {
        var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        Ado = new AdoFifa(adoAGBD);
        }
        [Fact]
        public void ObtenerTransferencias()
        {
            var transferencia = Ado.MapTransferencia.FiltrarPorPK("idVendedor",1);
            if (transferencia is null)
                throw new ArgumentNullException ("Trasferencia no existe");
            Assert.True(transferencia.Vendedor == 1 && transferencia.Comprador == 2);
        }
        
    }
