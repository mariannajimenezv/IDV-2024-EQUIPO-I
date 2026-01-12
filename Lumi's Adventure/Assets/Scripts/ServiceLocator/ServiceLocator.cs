using System;
using System.Collections.Generic;

public static class ServiceLocator
{
    private static Dictionary<Type, object> services = new Dictionary<Type, object>();

    public static void Register<T>(T service)
    {
        var type = typeof(T);

        if (services.ContainsKey(type))
        {
            services[type] = service;
        }
        else
        {
            services.Add(type, service);
        }
    }

    public static T Get<T>()
    {
        var type = typeof(T);

        if (!services.ContainsKey(type))
        {
            throw new Exception($"Service of type {type} not registered.");
        }

        return (T)services[type];
    }

    public static void Clear()
    {
        services.Clear();
    }
}
