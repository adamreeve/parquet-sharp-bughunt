using System;

using ParquetSharp;

namespace ParquetSharpBughunt;

class Program {
    public static void Main()
    {
        var objectIds = new int[] { 1,2,3,4,5,6 };
        var values = new float[] { 1.0f,2.0f,3.0f,4.0f,5.0f,6.0f };

        var columns = new Column[]
        {
            new Column<int>("ObjectId"),
            new Column<float>("Value")
        };

        using var file = new ParquetFileWriter("float_timeseries.parquet", columns);
        using var rowGroup = file.AppendRowGroup();

        using (var objectIdWriter = rowGroup.NextColumn().LogicalWriter<int>())
        {
            objectIdWriter.WriteBatch(objectIds);
        }
        using (var valueWriter = rowGroup.NextColumn().LogicalWriter<float>())
        {
            valueWriter.WriteBatch(values);
        }

        file.Close();

        Console.WriteLine("Hello, World!");
    }
}
