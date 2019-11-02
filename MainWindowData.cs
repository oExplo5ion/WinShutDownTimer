using System;

class MainWindowData
{
    // 0 - minutes
    // 1 - hours
    public int TimeType = 0;
    public int CurrentTime = 0;

    public void ActiveShutDown()
    {
        Console.WriteLine("ez");
        int time = getValidTime().ToString();
        Process process = getSystemProccess("shutdown -s -t " + time);
        process.Start();
    }

    public void DeactivateShutDown()
    {
        Process process = getSystemProccess("shutdown -a");
        process.Start();
    }

    private int getValidTime()
    {
        if (TimeType == 0) { return CurrentTime * 60; }
        if (TimeType == 1) { return CurrentTime * 60; }
        return CurrentTime;
    }

    private static Process getSystemProccess(string arg)
    {
        Process process = new Process();
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
        startInfo.FileName = "cmd.exe";
        startInfo.Arguments = arg;
        process.StartInfo = startInfo;
        return process;
    }
}