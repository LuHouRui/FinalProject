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
            int c = 0; 
            Console.WriteLine("初始化....");
            EFRepository Repository = new EFRepository();
            MySqlRepository mySqlRepository = new MySqlRepository();
            Import_Excel import_Excel = new Import_Excel();
        
            Console.WriteLine("開啟檔案中....");
            import_Excel.OpenFile(@"D:\DcTenXen0621\Data\School\107-1-SoftWare_Engerneering\FinalProject\Core\App_Data\客戶資料.xlsx");
            List<Customer> result = new List<Customer>();
            result = import_Excel.Get_Data(import_Excel.Get_WorkSheet(0));
        
            Console.Write("正在上傳檔案置資料庫");
            result.ForEach(x =>
            {
                if(++c > 50)
                {
                    Console.WriteLine("");
                    c = 0;
                }
                Console.Write(".");
                mySqlRepository.Insert(x);
            });
            Console.WriteLine("檔案上傳完成.");
            Console.ReadKey();
        }
        public static void ShowData(List<Customer> result)
        {
            result.ForEach(x =>
            {
                var message = $"客戶編號:{x.ID},客戶名稱:{x.Name},";
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
                        //case 1:
                        //    item.客戶編號 = (string)cells[i, j].Value;
                        //    break;
                        case 2:
                            item.Name = cells[i, j].Value.ToString() ?? " ";
                            break;
                        case 3:
                            item.TaxId = cells[i, j].Value.ToString() ?? " ";
                            break;
                        case 4:
                            item.BillingAddress = cells[i, j].Value.ToString() ?? " ";
                            break;
                        case 5:
                            item.Village = cells[i, j].Value.ToString() ?? " ";
                            break;
                        case 6:
                            item.City = cells[i, j].Value.ToString() ?? " ";
                            break;
                        case 7:
                            item.PostalCode = cells[i, j].Value.ToString() ?? " ";
                            break;
                        case 8:
                            item.PercentFive = cells[i, j].Value.ToString() ?? " ";
                            break;
                        case 9:
                            item.Contact = cells[i, j].Value.ToString() ?? " ";
                            break;
                        case 10:
                            item.ContactPhone = cells[i, j].Value.ToString() ?? " ";
                            break;
                        case 11:
                            item.CompanyPhone = cells[i, j].Value.ToString() ?? " ";
                            break;
                        case 12:
                            item.CompanyTax = cells[i, j].Value.ToString() ?? " " ;
                            break;
                        case 13:
                            item.Description = cells[i, j].Value.ToString() ?? " ";
                            break;
                    }
                }
            }
            if (item.Name != "" && item.Name != " " && item.Name != null && item.Name != "客戶名稱")
            {
                result.Add(item);
            }
        }
        return result;
    }

}