using ClosedXML.Excel;

namespace Base.Shared.Services;

public static class ExcelFileGenerator
{
    public static MemoryStream GenerateExcelFile<T>(List<T> items, string sheetName, Dictionary<string, Func<T, string>> accessors, bool style)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add(sheetName);

        // Header
        var column = 1;
        foreach (var accessor in accessors)
        {
            var headerCell = worksheet.Cell(1, column++);
            headerCell.Value = accessor.Key;
            if (style)
            {
                headerCell.Style.Font.Bold = true;
                headerCell.Style.Fill.BackgroundColor = XLColor.LightGray;
                headerCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headerCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            }
        }

        // Data
        for (var i = 0; i < items.Count; i++)
        {
            var item = items[i];
            column = 1;
            foreach (var accessor in accessors)
            {
                var cell = worksheet.Cell(i + 2, column++);
                cell.Value = accessor.Value(item);
                if (style)
                {
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }
            }
        }

        worksheet.Columns().AdjustToContents();
        
        var stream = new MemoryStream();
        workbook.SaveAs(stream);
        stream.Position = 0;
        return stream;
    }

}