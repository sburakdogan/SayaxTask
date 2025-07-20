namespace SayaxTask.Business.Abstracts
{
    public interface IExcelReaderService
    {
        List<Dictionary<string, string>> GetExcelDataBySheetName(string sheetName);
    }
}
