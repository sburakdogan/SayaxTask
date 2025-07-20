using SayaxTask.Business.Abstracts;
using SayaxTask.Business.Helper;

namespace SayaxTask.Business.Services
{
    public class ExcelReaderService : IExcelReaderService
    {
        private readonly ExcelReaderHelper _excelReaderHelper;

        public ExcelReaderService(ExcelReaderHelper excelReaderHelper)
        {
            _excelReaderHelper = excelReaderHelper;
        }

        public List<Dictionary<string, string>> GetExcelDataBySheetName(string sheetName)
        {
            return _excelReaderHelper.ReadFile(sheetName);
        }
    }
}
