using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour, IEntity
{
    private readonly List<object> components = new();

    public void Add<T>(T newComponent)
    {
        components.Add(newComponent);
    }

    public bool TryComponent<T>(out T requestedComponent)
    {
        for (int i = 0; i < components.Count; i++)
        {
            if (components[i] is T value)
            {
                requestedComponent = value;
                return true;
            }
        }

        requestedComponent = default;
        return false;
    }

    public T Get<T>()
    {
        for (int i = 0; i < components.Count; i++)
        {
            if (components[i] is T value)
            {
                return value;
            }
        }

        throw new Exception($"No component of {typeof(T)} found!");
    }
}