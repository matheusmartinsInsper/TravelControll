using ClosedXML.Excel;
using CsvHelper;
using CsvHelper.Configuration;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using System.Formats.Asn1;
using System.Globalization;
using TravelControll.Data;
using TravelControll.Models;
using TravelControll.Services.Interfaces;

namespace TravelControll.Services
{
    public class GeneratorRelatoryQuantity:IRelatory<RelatoryQuantity>
    {
        private readonly TravelControllContextDb _context;
        public GeneratorRelatoryQuantity(TravelControllContextDb context)
        {
            _context = context;
        }

        public async Task<List<RelatoryQuantity>> BuscarDadosRelatorio(int id)
        {
            return _context.GerarRelatorioDeQuantidade(id);
        }

        public async void GerarRelatorio(int id)
        {
            var data = await BuscarDadosRelatorio(id);
            string pathFileRlatory = @$"C:\Users\User\RelatoriosTravelControll\RelatoryQuantity{id}.xlsx";
            IEnumerable<string> listStrings=data.Select(x => $"Email: {x.email}, Id: {x.id_empresa}, Status: {x.status}, Quantidade:{x.quantidade}");     
            foreach(var result in  listStrings)
            {
                Console.WriteLine(result);
            }
            EscreverCsv(data,pathFileRlatory);
        }
        static void EscreverCsv(List<RelatoryQuantity> dados, string caminhoArquivo)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Dados");
                // Escrever cabeçalho
                worksheet.Cells[1, 1].Value = "E-mail";
                worksheet.Cells[1, 2].Value = "IdEmpresa";
                worksheet.Cells[1, 3].Value = "Status";
                worksheet.Cells[1, 4].Value = "Quantidade";

                // Escrever dados
                for (int i = 0; i < dados.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = dados[i].email;
                    worksheet.Cells[i + 2, 2].Value = dados[i].id_empresa;
                    worksheet.Cells[i + 2, 3].Value = dados[i].status;
                    worksheet.Cells[i + 2, 4].Value = dados[i].quantidade;
                }
                var chart = worksheet.Drawings.AddChart("ClusteredColumnChart", eChartType.ColumnClustered);
                chart.SetPosition(0, 0, 5, 0);
                chart.SetSize(600, 400);
                chart.Title.Text = "Quantidade por Status";

                // Definir dados do gráfico
                var series = chart.Series.Add(worksheet.Cells["D2:D" + (dados.Count + 1)], worksheet.Cells["C2:C" + (dados.Count + 1)]);
                series.Header = worksheet.Cells["C1"].Text;
                // Salvar o arquivo Excel
                package.SaveAs(new System.IO.FileInfo(caminhoArquivo));
            }
        }
    }
}
