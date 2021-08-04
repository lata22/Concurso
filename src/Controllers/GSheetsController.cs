using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Concurso
{
    public class GSheetsController
    {
        public enum Columns : int
        {
            NroAfiliado = 2,
            Nombre = 4,
            Apellido = 5,
            DNI = 3,
            Localidad = 8,
            Empresa = 7
        }

        string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        string ApplicationName = "Concurso";
        string spreadsheetId = "17SFCwXVaYY4BJJTHXufqjIaYJ7mS7ugmOORmRDyXoK8";
        string sheetName = "Respuestas de formulario 1";
        string range;
        SheetsService service;

        public GSheetsController()
        {
            Login();
        }

        void Login()
        {
            try
            {
                GoogleCredential credential;
                using (var stream = new FileStream("ConcursoSecrets.json", FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
                }
                service = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<AfiliadosGoogle>> getAllAfiliados()
        {
            range = $"{sheetName}!A2:I";
            var result = new List<AfiliadosGoogle>();
            var request = service?.Spreadsheets.Values.Get(spreadsheetId, range);
            return Task.Run(() =>
                 {
                     var response = request.Execute();
                     var values = response.Values;
                     int i = 0;
                     try
                     {
                         for (; i < values.Count; i++)
                         {
                             result.Add(new AfiliadosGoogle
                             {
                                 NroAfiliado = (values[i])[(int)Columns.NroAfiliado].ToString().Trim().Replace(".","").Replace(",",""),
                                 Nombre = (values[i])[(int)Columns.Nombre].ToString().ToString().Trim(),
                                 Apellido = (values[i])[(int)Columns.Apellido].ToString().ToString().Trim(),
                                 DNI = (values[i])[(int)Columns.DNI].ToString().Trim().Replace(".", "").Replace(",", ""),
                                 Localidad = (values[i])[(int)Columns.Localidad].ToString().Trim(),
                                 Empresa = (values[i])[(int)Columns.Empresa].ToString().Trim()
                             });
                         }
                     }
                     catch (Exception ex)
                     {
                         throw ex;
                     }

                     return result;
                 });
        }
    }
}
