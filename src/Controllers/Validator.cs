using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers
{
    public class Validator
    {
        List<Afiliados> DataModelList = new List<Afiliados>();
        List<AfiliadosGoogle> GSheet = new List<AfiliadosGoogle>();
        List<AfiliadosGoogle> ValidatedList = new List<AfiliadosGoogle>();

        public Validator(List<Afiliados> dataModelList, List<AfiliadosGoogle> gsheet)
        {
            DataModelList = dataModelList;
            GSheet = gsheet;
        }

        public bool Validate(AfiliadosGoogle afiliado)
        {
            if (DataModelList.Where(i => i.DNI.Trim() == afiliado.DNI.Trim()
                                       && i.NroAfiliado.Trim() == afiliado.NroAfiliado.Trim()).Count() == 1)
                return true;
            return false;
        }

        public Task<List<AfiliadosGoogle>> ValidateAll()
        {
            return Task.Run(() =>
               {
                   for (int i = 0; i < GSheet.Count; i++)
                   {
                       if (Validate(GSheet[i]) &&
                                (ValidatedList.Where(x => x.DNI.Trim() == GSheet[i].DNI.Trim()
                                                    && x.NroAfiliado.Trim() == GSheet[i].NroAfiliado.Trim()).Count() == 0))
                           ValidatedList.Add(GSheet[i]);
                   }
                   return ValidatedList;
               });
        }
    }
}
