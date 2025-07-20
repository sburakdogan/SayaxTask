using ClosedXML.Excel;

namespace SayaxTask.Business.Helper
{
    public class ExcelReaderHelper
    {
        private readonly string _filePath;

        public ExcelReaderHelper(string filePath)
        {
            _filePath = filePath;
        }

        public List<Dictionary<string, string>> ReadFile(string sheetName)
        {
            var result = new List<Dictionary<string, string>>();

            try
            {
                using (var workbook = new XLWorkbook(_filePath))
                {
                    var worksheet = workbook.Worksheet(sheetName);

                    if (worksheet == null)
                        throw new Exception($"Sayfa '{sheetName}' bulunamadı.");

                    var headerRow = worksheet.Rows().FirstOrDefault();

                    if (headerRow == null)
                        throw new Exception("Başlık satırı bulunamadı.");

                    var headers = headerRow.Cells().Select(cell => cell.Value.ToString()).ToList();

                    foreach (var row in worksheet.RowsUsed().Skip(1))
                    {
                        var rowData = new Dictionary<string, string>();

                        for (int i = 0; i < headers.Count; i++)
                        {
                            rowData[headers[i]] = row.Cell(i + 1).Value.ToString();
                        }

                        result.Add(rowData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }

            return result;
        }
    }
}
