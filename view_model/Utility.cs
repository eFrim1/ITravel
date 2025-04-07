using System.IO;
using System.Reflection;
using System.Text;
using NPOI.XWPF.UserModel;

namespace TravelAgency.view_model;

public class Utility
{
    private static string GetExportPath(string fileName, string extension)
    {
        string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\exports");
        Directory.CreateDirectory(directory);
        return Path.Combine(directory, $"{fileName}.{extension}");
    }

    public static void ExportToCsv<T>(string fileName, List<T> data)
    {
        if (data == null || !data.Any()) return;

        string filePath = GetExportPath(fileName, "csv");
        StringBuilder sb = new StringBuilder();
        PropertyInfo[] properties = typeof(T).GetProperties();
        
        sb.AppendLine(string.Join(",", properties.Select(p => p.Name)));
        
        foreach (var item in data)
        {
            sb.AppendLine(string.Join(",", properties.Select(p => p.GetValue(item)?.ToString() ?? "")));
        }

        File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
    }
    
    public static void ExportToDoc<T>(string fileName, List<T> data)
    {
        if (data == null || !data.Any()) return;

        string filePath = GetExportPath(fileName, "docx");
        XWPFDocument doc = new XWPFDocument();
        var table = doc.CreateTable(data.Count + 1, typeof(T).GetProperties().Length);

        PropertyInfo[] properties = typeof(T).GetProperties();

        for (int i = 0; i < properties.Length; i++)
        {
            table.GetRow(0).GetCell(i).SetText(properties[i].Name);
        }

        int rowIndex = 1;
        foreach (var item in data)
        {
            for (int col = 0; col < properties.Length; col++)
            {
                try
                {
                    table.GetRow(rowIndex).GetCell(col);
                }
                catch (Exception ex)
                {
                    table.GetRow(rowIndex).CreateCell();
                }
                finally
                {
                    table.GetRow(rowIndex).GetCell(col).SetText(properties[col].GetValue(item)?.ToString() ?? "");
                }
            }

            rowIndex++;
        }

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            doc.Write(stream);
        }
    }
}