using System;
using UnitTestDemo.Contracts.Services.General;
using Xamarin.Essentials;

namespace UnitTestDemo.Services.General
{    
    public class PreferencesService : IPreferencesService
    {       
        public string Username 
        {
            get => Get(nameof(Username), string.Empty); 
            set => Set(nameof(Username), value); 
        }
                
        public string UserId 
        {
            get => Get(nameof(UserId), string.Empty);
            set => Set(nameof(UserId), value);
        }
                
        public bool ContainsKey(string key)
        {
            return InternalContainsKey(key, null);
        }
               
        public bool ContainsKey(string key, string sharedName)
        {
            return InternalContainsKey(key, sharedName);
        }
               
        public void Clear()
        {
            Preferences.Clear();
        }
                
        public void Clear(string sharedName)
        {
            Preferences.Clear(sharedName);
        }
               
        public T Get<T>(string key, T defaultValue)
        {
            return InternalGet(key, defaultValue, null);
        }
        
        public T Get<T>(string key, T defaultValue, string sharedName)
        {
            return InternalGet(key, defaultValue, sharedName);
        }
                   
        public void Set<T>(string key, T value)
        {
            InternalSet(key, value, null);
        }
                
        public void Set<T>(string key, T value, string sharedName)
        {
            InternalSet(key, value, sharedName);
        }
                       
        public void Remove(string key)
        {
            InternalRemove(key, null);
        }
                
        public void Remove(string key, string sharedName)
        {
            InternalRemove(key, sharedName);
        }
                
        private T InternalGet<T>(string key, T defaultValue, string sharedName)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Unsupported key name", nameof(key));
            }

            if (typeof(T) == typeof(bool))
            {
                if (string.IsNullOrWhiteSpace(sharedName))
                {
                    return (T)(object)Preferences.Get(key, (bool)(object)defaultValue);
                }
                else
                {
                    return (T)(object)Preferences.Get(key, (bool)(object)defaultValue, sharedName);
                }
            }
            else if (typeof(T) == typeof(double))
            {
                if (string.IsNullOrWhiteSpace(sharedName))
                {
                    return (T)(object)Preferences.Get(key, (double)(object)defaultValue);
                }
                else
                {
                    return (T)(object)Preferences.Get(key, (double)(object)defaultValue, sharedName);
                }
            }
            else if (typeof(T) == typeof(int))
            {
                if (string.IsNullOrWhiteSpace(sharedName))
                {
                    return (T)(object)Preferences.Get(key, (int)(object)defaultValue);
                }
                else
                {
                    return (T)(object)Preferences.Get(key, (int)(object)defaultValue, sharedName);
                }
            }
            else if (typeof(T) == typeof(float))
            {
                if (string.IsNullOrWhiteSpace(sharedName))
                {
                    return (T)(object)Preferences.Get(key, (float)(object)defaultValue);
                }
                else
                {
                    return (T)(object)Preferences.Get(key, (float)(object)defaultValue, sharedName);
                }
            }
            else if (typeof(T) == typeof(long))
            {
                if (string.IsNullOrWhiteSpace(sharedName))
                {
                    return (T)(object)Preferences.Get(key, (long)(object)defaultValue);
                }
                else
                {
                    return (T)(object)Preferences.Get(key, (long)(object)defaultValue, sharedName);
                }
            }
            else if (typeof(T) == typeof(string))
            {
                if (string.IsNullOrWhiteSpace(sharedName))
                {
                    return (T)(object)Preferences.Get(key, (string)(object)defaultValue);
                }
                else
                {
                    return (T)(object)Preferences.Get(key, (string)(object)defaultValue, sharedName);
                }
            }
            else if (typeof(T) == typeof(DateTime))
            {
                if (string.IsNullOrWhiteSpace(sharedName))
                {
                    return (T)(object)Preferences.Get(key, (DateTime)(object)defaultValue);
                }
                else
                {
                    return (T)(object)Preferences.Get(key, (DateTime)(object)defaultValue, sharedName);
                }
            }
            else
            {
                throw new ArgumentException("Unsupported value type", nameof(T));
            }
        }
                
        private void InternalSet<T>(string key, T value, string sharedName)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Unsupported key name", nameof(key));
            }

            if (typeof(T) == typeof(bool))
            {
                if (string.IsNullOrWhiteSpace(sharedName))
                {
                    Preferences.Set(key, (bool)(object)value);
                }
                else
                {
                    Preferences.Set(key, (bool)(object)value, sharedName);
                }
            }
            else if (typeof(T) == typeof(double))
            {
                if (string.IsNullOrWhiteSpace(sharedName))
                {
                    Preferences.Set(key, (double)(object)value);
                }
                else
                {
                    Preferences.Set(key, (double)(object)value, sharedName);
                }
            }
            else if (typeof(T) == typeof(int))
            {
                if (string.IsNullOrWhiteSpace(sharedName))
                {
                    Preferences.Set(key, (int)(object)value);
                }
                else
                {
                    Preferences.Set(key, (int)(object)value, sharedName);
                }
            }
            else if (typeof(T) == typeof(float))
            {
                if (string.IsNullOrWhiteSpace(sharedName))
                {
                    Preferences.Set(key, (float)(object)value);
                }
                else
                {
                    Preferences.Set(key, (float)(object)value, sharedName);
                }
            }
            else if (typeof(T) == typeof(long))
            {
                if (string.IsNullOrWhiteSpace(sharedName))
                {
                    Preferences.Set(key, (long)(object)value);
                }
                else
                {
                    Preferences.Set(key, (long)(object)value, sharedName);
                }
            }
            else if (typeof(T) == typeof(string))
            {
                if (string.IsNullOrWhiteSpace(sharedName))
                {
                    Preferences.Set(key, (string)(object)value);
                }
                else
                {
                    Preferences.Set(key, (string)(object)value, sharedName);
                }
            }
            else if (typeof(T) == typeof(DateTime))
            {
                if (string.IsNullOrWhiteSpace(sharedName))
                {
                    Preferences.Set(key, (DateTime)(object)value);
                }
                else
                {
                    Preferences.Set(key, (DateTime)(object)value, sharedName);
                }
            }
            else
            {
                throw new ArgumentException("Unsupported value type", nameof(value));
            }
        }
                
        private bool InternalContainsKey(string key, string sharedName)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Unsupported key name", nameof(key));
            }

            if (string.IsNullOrWhiteSpace(sharedName))
            {
                return Preferences.ContainsKey(key);
            }
            else
            {
                return Preferences.ContainsKey(key, sharedName);
            }
        }
        
        private void InternalRemove(string key, string sharedName)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Unsupported key name", nameof(key));
            }

            if (string.IsNullOrWhiteSpace(sharedName))
            {
                Preferences.Remove(key);
            }
            else
            {
                Preferences.Remove(key, sharedName);
            }
        }
    }
}
