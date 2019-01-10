using Aspose.Cells;
using Core.Models;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{ }
    class Program
    {
        static void Main(string[] args)
        {
            EFRepository Repository = new EFRepository();
            Import_Excel import_Excel = new Import_Excel();
            import_Excel.OpenFile(@"C:\Users\User\Desktop\FinalProject\Core\App_Data\客戶資料.xlsx");
            List<Customer> result = new List<Customer>();
            result = import_Excel.Get_Data(import_Excel.Get_WorkSheet(0));
            result.ForEach(x =>
            {
                Repository.Insert(x);
            });
            Console.ReadKey();
        }
        public static void ShowData(List<Customer> result)
        {
            result.ForEach(x =>
            {
                var message = $"客戶編號:{x.客戶編號},客戶名稱:{x.客戶名稱},";
                Console.WriteLine(message);
            });
        }
    }
class Import_Excel
{
    private Workbook workbok;
    private WorksheetCollection worksheets;
    public void OpenFile(string filename)
    {
        workbok = new Workbook(filename);
        worksheets = workbok.Worksheets;
    }
    public Workbook Get_Book()
    {
        return workbok;
    }
    public Worksheet Get_WorkSheet(int index)
    {
        return worksheets[index];
    }
    public List<Customer> Get_Data(Worksheet worksheet)
    {
        List<Customer> result = new List<Customer>();
        Range range = worksheet.Cells.MaxDisplayRange;
        Cells cells = worksheet.Cells;
        for (int i = 0; i <= range.RowCount; i++)
        {
            Customer item = new Customer();
            for (int j = 1; j <= range.ColumnCount; j++)
            {
                if (cells[i, j].Type != CellValueType.IsNull)
                {
                    switch (j)
                    {
                        case 1:
                            item.客戶編號 = (string)cells[i, j].Value;
                            break;
                        case 2:
                            item.客戶名稱 = (string)cells[i, j].Value;
                            break;
                        case 3:
                            item.統一編號 = (string)cells[i, j].Value;
                            break;
                        case 4:
                            item.帳單地址 = (string)cells[i, j].Value;
                            break;
                        case 5:
                            item.鄉鎮市區 = (string)cells[i, j].Value;
                            break;
                        case 6:
                            item.縣市 = (string)cells[i, j].Value;
                            break;
                        case 7:
                            item.郵遞區號 = (string)cells[i, j].Value.ToString();
                            break;
                        case 8:
                            item.含稅 = (string)cells[i, j].Value;
                            break;
                        case 9:
                            item.聯絡人 = (string)cells[i, j].Value;
                            break;
                        case 10:
                            item.聯絡人電話 = cells[i, j].Value.ToString();
                            break;
                        case 11:
                            item.公司電話 = cells[i, j].Value.ToString();
                            break;
                        case 12:
                            item.公司傳真 = cells[i, j].Value.ToString();
                            break;
                        case 13:
                            item.附註 = (string)cells[i, j].Value;
                            break;
                    }
                }
            }
            if (item.客戶名稱 != "" && item.客戶名稱 != " " && item.客戶名稱 != null && item.客戶名稱 != "客戶名稱")
            {
                result.Add(item);
            }
        }
        return result;
    }

}