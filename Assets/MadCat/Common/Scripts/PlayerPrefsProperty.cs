using UnityEngine;
using System;

[Serializable]
public abstract class PlayerPrefsProperty2<T, U>
{
	[SerializeField] string name;
	[SerializeField] U defaultValue;
	
	public PlayerPrefsProperty2(string name, U defaultValue)
	{
		this.name = name;
		this.defaultValue = defaultValue;
	}
	
	public string Name { get { return name; } }
	protected U DefaultValue { get { return defaultValue; } }
	
	abstract public T Value { get; set; }
	
	public static implicit operator T(PlayerPrefsProperty2<T, U> p)
    {
        return p.Value;
    }

	public override string ToString()
	{
		return Value.ToString();
	}
}

[Serializable]
public abstract class PlayerPrefsProperty1<T> : PlayerPrefsProperty2<T, T>
{
	public PlayerPrefsProperty1(string name, T defaultValue)
		: base(name, defaultValue)
	{
		
	}
}

[Serializable]
public class PlayerPrefsString : PlayerPrefsProperty1<string>
{
	public PlayerPrefsString(string name, string defaultValue = "")
		: base (name, defaultValue) { }
		
	public override string Value
	{
		get
		{
			return PlayerPrefs.GetString(Name, DefaultValue);
		}
		set
		{
			PlayerPrefs.SetString(Name, value);
		}
	}
}

[Serializable]
public class PlayerPrefsInt : PlayerPrefsProperty1<int>
{
	public PlayerPrefsInt(string name, int defaultValue = 0)
		: base (name, defaultValue) { }
		
	public override int Value
	{
		get
		{
			return PlayerPrefs.GetInt(Name, DefaultValue);
		}
		set
		{
			PlayerPrefs.SetInt(Name, value);
		}
	}
}

[Serializable]
public class PlayerPrefsFloat : PlayerPrefsProperty1<float>
{
	public PlayerPrefsFloat(string name, float defaultValue = 0)
		: base (name, defaultValue) { }
		
	public override float Value
	{
		get
		{
			return PlayerPrefs.GetFloat(Name, DefaultValue);
		}
		set
		{
			PlayerPrefs.SetFloat(Name, value);
		}
	}
}

[Serializable]
public class PlayerPrefsBool : PlayerPrefsProperty1<bool>
{
	public PlayerPrefsBool(string name, bool defaultValue = false)
		: base (name, defaultValue) { }
		
	public override bool Value
	{
		get
		{
			return PlayerPrefs.GetInt(Name, DefaultValue ? 1 : 0) != 0;
		}
		set
		{
			PlayerPrefs.SetInt(Name, value ? 1 : 0);
		}
	}
}

[Serializable]
public class PlayerPrefsDateTime : PlayerPrefsProperty2<DateTime, string>
{
    public PlayerPrefsDateTime(string name, DateTime defaultValue) 
        : base (name, defaultValue.ToString()) { }

    public override DateTime Value
    {
        get
        {
            return DateTime.Parse(PlayerPrefs.GetString(Name, DefaultValue));
        }
        set
        {
            PlayerPrefs.SetString(Name, value.ToString());
        }
    }
}
