using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using Models;

namespace Controllers
{
    public class ExcelController
    {
        /// <summary>
        /// Check the column order in the Excel Sheet
        /// </summary>
        public enum Columns : int
        {
            NroAfiliado = 1,
            ApellidoNombre = 2,
            DNI = 12,
            Localidad = 5,
            Empresa = 14
        }

        string path;

        public ExcelController(string _path)
        {
            path = _path;
        }

        public List<Afiliados> GetList()
        {
            var result = new List<Afiliados>();

            Application xlApp = new Application();
            Workbook xlWorkbook = xlApp.Workbooks.Open(path);
            _Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 4; i <= rowCount; i++)
            {
                var nroAfiliado = xlRange.Cells[i, Columns.NroAfiliado];
                var ApellidoNombre = xlRange.Cells[i, Columns.ApellidoNombre];
                var Dni = xlRange.Cells[i, Columns.DNI];
                var Localidad = xlRange.Cells[i, Columns.Localidad];
                var Empresa = xlRange.Cells[i, Columns.Empresa];

                if (nroAfiliado != null
                    && nroAfiliado?.Value2 != null
                    && ApellidoNombre != null
                    && ApellidoNombre?.Value2 != null
                        && Dni != null
                    && Dni?.Value2 != null
                    )
                {
                    result.Add(new Afiliados
                    {
                        NroAfiliado = Convert.ToString(nroAfiliado?.Value2).Trim(),
                        ApellidoNombre = Convert.ToString(ApellidoNombre?.Value2).Trim(),
                        DNI = Convert.ToString(Dni?.Value2).Trim(),
                        Localidad = Convert.ToString(Localidad?.Value2).Trim(),
                        Empresa = Convert.ToString(Empresa?.Value2).Trim()
                    });
                }
            }

            //cleanup  
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:  
            //  never use two dots, all COM objects must be referenced and released individually  
            //  ex: [somthing].[something].[something] is bad  

            //release com objects to fully kill excel process from running in the background  
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release  
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release  
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            return result;
        }
    }
}
