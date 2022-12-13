
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class LoggerInterceptor : Attribute, IInterceptor
{
    public void OnEnter(Type declaringType, object instance, MethodBase methodbase, object[] values)
    {
        this.AppendToFile($"Called  -> {declaringType.Name} {methodbase.Name} {string.Join(" ", values)}");
    }

    public void OnException(Exception e)
    {
        this.AppendToFile($"Exception -> {e.Message}");
    }
    
    public void OnExit()
    {
        this.AppendToFile("Exit");
    }

  

    private void AppendToFile(string line)
    {
        File.AppendAllLines("log.txt", new string[] { line });
        Console.WriteLine(">> " + line);
    }
}