using System.IO;
using UnityEngine;
using UnityEngine.Profiling;

public class ExportProfilerData : MonoBehaviour
{
    public string fileName = "ProfilerData.csv";
    private StreamWriter writer;
    private float elapsedTime = 0f;
    private float loggingInterval = 1.0f; // Khoảng thời gian ghi dữ liệu mỗi giây

    void Start()
    {
        string path = Path.Combine(Application.dataPath, fileName);
        writer = new StreamWriter(path, false);
        writer.WriteLine("Time,Total Reserved Memory (MB),Total Used Memory (MB),FPS");
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= loggingInterval)
        {
            LogProfilerData();
            elapsedTime = 0f;
        }
    }

    void LogProfilerData()
    {
        float time = Time.time;
        float reservedMemory = Profiler.GetTotalReservedMemoryLong() / (1024f * 1024f); // MB
        float usedMemory = Profiler.GetTotalAllocatedMemoryLong() / (1024f * 1024f); // MB
        float fps = 1.0f / Time.deltaTime;

        writer.WriteLine($"{time},{reservedMemory},{usedMemory},{fps}");
    }

    void OnApplicationQuit()
    {
        if (writer != null)
        {
            writer.Close();
        }
    }
}
