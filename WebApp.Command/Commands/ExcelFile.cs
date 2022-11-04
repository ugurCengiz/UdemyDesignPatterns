using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace WebApp.Command.Commands
{
    public class ExcelFile<T>
    {
        public readonly List<T> _List;
        public string FileName => $"{typeof(T).Name}.xlsx";
        public string FileType => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        public ExcelFile(List<T> list)
        {
            _List = list;
        }

        public MemoryStream Create()
        {
            var wb = new XLWorkbook();

            var ds = new DataSet();

            ds.Tables.Add(GetTable());

            wb.Worksheets.Add(ds);

            var excelMemory = new MemoryStream();

            wb.SaveAs(excelMemory);

            return excelMemory;
        }



        private DataTable GetTable()
        {
            var table = new DataTable();

            var type = typeof(T);

            type.GetProperties().ToList().ForEach(x => table.Columns.Add(x.Name, x.PropertyType));
            _List.ForEach(x =>
            {
                var values = type.GetProperties().Select(propertyInfo => propertyInfo.GetValue(x, null)).ToArray();

                table.Rows.Add(values);
            });
            return table;
        }

    }
}
