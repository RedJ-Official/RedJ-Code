using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RedJ_Code
{
    internal static class ProcessManager
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESSENTRY32
        {
            public uint dwSize;
            public uint cntUsage;
            public uint th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public uint th32ModuleID;
            public uint cntThreads;
            public uint th32ParentProcessID;
            public int pcPriClassBase;
            public uint dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExeFile;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateToolhelp32Snapshot(uint dwFlags, uint th32ProcessID);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Process32First(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Process32Next(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);

        const uint TH32CS_SNAPPROCESS = 0x00000002;

        public static void KillSubprocesses(this Process process)
        {
            int parentPid = process.Id;
            IntPtr hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
            if (hSnapshot == IntPtr.Zero)
            {
                return;
            }

            try
            {
                PROCESSENTRY32 processEntry = new PROCESSENTRY32 { dwSize = (uint)Marshal.SizeOf(typeof(PROCESSENTRY32)) };
                if (Process32First(hSnapshot, ref processEntry))
                {
                    do
                    {
                        if ((int)processEntry.th32ParentProcessID == parentPid)
                        {
                            Process childProcess = Process.GetProcessById((int)processEntry.th32ProcessID);
                            if (!childProcess.ProcessName.Equals("conhost", StringComparison.InvariantCultureIgnoreCase))
                                childProcess.Kill(true);
                        }
                    } while (Process32Next(hSnapshot, ref processEntry));
                }
            }
            finally
            {
                CloseHandle(hSnapshot);
            }
        }
    }
}
