using System.Collections.Generic;

public sealed class PlayerStats
{
    private readonly Dictionary<string, float> stats = new();

    public void AddStat(string name, float value)
    {
        this.stats.Add(name, value);
    }

    public float GetStat(string name)
    {
        return this.stats[name];
    }

    public IReadOnlyDictionary<string, float> GetStats()
    {
        return this.stats;
    }

    public void RemoveStat(string name)
    {
        this.stats.Remove(name);
    }

    public void ChangeStat(string key, float value)
    {
        if (stats.ContainsKey(key))
        {
            stats[key] += value;
        }
        else
        {
            AddStat(key, value);
        }
    }
}