using UnityEngine;
using Unity.Profiling;
using System.IO;

public class PerformanceMetricsLogger : MonoBehaviour
{
    // ProfilerRecorders to track performance metrics
    private ProfilerRecorder cpuUsageRecorder;
    private ProfilerRecorder memoryUsageRecorder;

    // File path to save the data
    private string filePath;

    void Start()
    {
        cpuUsageRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Internal, "Main Thread");
        memoryUsageRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "System Used Memory");

        filePath = Path.Combine(Application.persistentDataPath, "ProfilerData.csv");

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Time,FPS,CPU Usage (%),Memory Usage (MB)\n");
        }
    }

    void Update()
    {
        // Calculate FPS
        float fps = 1.0f / Time.smoothDeltaTime;

        // Get CPU Time (in ms) from the Profiler
        float cpuTime = cpuUsageRecorder.Valid ? cpuUsageRecorder.LastValue / 1000f : 0.0f; // CPU Time in milliseconds

        // Get Frame Time (in ms)
        float frameTime = Time.deltaTime * 1000f; // Frame Time in milliseconds

        // Calculate CPU Usage (%)
        float cpuUsage = (cpuTime / frameTime) * 100f;

        // Get Memory Usage (in MB)
        float memoryUsage = memoryUsageRecorder.Valid ? memoryUsageRecorder.LastValue / (1024f * 1024f) : 0.0f;

        // Append data to CSV file
        string logEntry = $"{Time.time:F2},{fps:F2},{cpuUsage:F2},{memoryUsage:F2}\n";
        File.AppendAllText(filePath, logEntry);
    }

    void OnDestroy()
    {
        // Dispose ProfilerRecorders
        cpuUsageRecorder.Dispose();
        memoryUsageRecorder.Dispose();
    }
}
