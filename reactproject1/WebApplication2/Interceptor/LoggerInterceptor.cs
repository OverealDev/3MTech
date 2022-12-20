

using System.Reflection;
using Castle.DynamicProxy;
using Newtonsoft.Json;
using Serilog;
using System;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]


public class LoggerInterceptor :Attribute , IInterceptor
{
   

    public void Intercept(IInvocation called)
    {
        try
        {
            called.Proceed();
            this.AppendToFile($"Called  -> {called.Method.GetType} {called.Method.Name} {string.Join(" ", called.Method.Attributes)}");

        }



        catch (Exception e)
        {
            this.AppendToFile($"Exception -> {e.Message}");
            throw;
        }



        finally
        {
            this.AppendToFile("Exit");
        }

    }

    
    private void AppendToFile(string line)
    {
        File.AppendAllLines("log.txt", new string[] { line });
        Console.WriteLine(">> " + line);
    }
}