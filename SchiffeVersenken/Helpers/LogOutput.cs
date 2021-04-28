using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeVersenken.Helpers
{
    public static class LogOutput
    {
        public enum LogType
        {
            Info,
            Warning,
            Error,
            Critical,
        }

        public static void Output(string message)
        {
            Console.WriteLine(message);
        }

        public static void Output(string message, LogType type)
        {
            StackFrame stackFrame = new StackFrame(1);
            System.Reflection.MethodBase method = stackFrame.GetMethod();
            string callerName = method.DeclaringType + "." + method.Name + "(): "; // Get name of the caller's class and method

            switch (type)
            {
                case LogType.Info:
                    Output(callerName + "Info: " + message);
                    break;
                case LogType.Warning:
                    Output(callerName + "Warning: " + message, ConsoleColor.Yellow);
                    break;
                case LogType.Error:
                    Output(callerName + "Error: " + message, ConsoleColor.Red);
                    break;
                case LogType.Critical:
                    Output(callerName + "Critical: " + message, ConsoleColor.White, ConsoleColor.DarkRed);
                    break;
            }
        }

        public static void Output(string message, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Output(string message, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
