
namespace Models
{
    public class AfiliadosGoogle : Afiliados
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public override string ToString()
        {
            return $"{nameof(NroAfiliado)}: {NroAfiliado} \r" +
                $"{nameof(DNI)}: {DNI} \r" +
                 $"{nameof(Nombre)}: {Nombre} \r" +
                  $"{nameof(Apellido)}: {Apellido} \r" +
                   $"{nameof(Localidad)}: {Localidad} \r" +
                    $"{nameof(Empresa)}: {Empresa} \r";
        }
    }
}
