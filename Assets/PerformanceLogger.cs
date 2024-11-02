using UnityEngine;
using System.IO;
using System.Text;

public class PerformanceLogger : MonoBehaviour
{
    private string filePath;
    private float loggingInterval = 1.0f; // Kho?ng th?i gian ghi d? li?u (gi�y)
    private float timeSinceLastLog = 0f;

    void Start()
    {
        filePath = Path.Combine(Application.dataPath, "PerformanceData.csv");

        // Ghi ti�u ?? c?t v�o file CSV
        using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
        {
            writer.WriteLine("Time,FPS,Memory Usage (MB),CPU Usage (%)");
        }
    }

    void Update()
    {
        timeSinceLastLog += Time.deltaTime;

        if (timeSinceLastLog >= loggingInterval)
        {
            LogPerformanceData();
            timeSinceLastLog = 0f;
        }
    }

    private void LogPerformanceData()
    {
        float fps = 1.0f / Time.deltaTime;
        float memoryUsage = (float)System.GC.GetTotalMemory(false) / (1024 * 1024); // Memory usage in MB

        // CPU Usage gi? l?p, n?u c?n ?o chi ti?t, c� th? d�ng Profiler tr?c ti?p
        float cpuUsage = Random.Range(10f, 50f); // S? n�y kh�ng ch�nh x�c, ch? d�ng minh h?a

        using (StreamWriter writer = new StreamWriter(filePath, true, Encoding.UTF8))
        {
            writer.WriteLine($"{Time.time},{fps},{memoryUsage},{cpuUsage}");
        }

        Debug.Log($"Logged: Time={Time.time}, FPS={fps}, Memory={memoryUsage} MB, CPU Usage={cpuUsage}%");
    }
}
