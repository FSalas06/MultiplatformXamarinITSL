
namespace UnitTestDemo.Contracts.Services.General
{    
    public interface IPreferencesService
    {        
        string Username { get; set; }
                
        string UserId { get; set; }
                
        bool ContainsKey(string key);
                
        bool ContainsKey(string key, string sharedName);
               
        void Clear();
        
        void Clear(string sharedName);
        
        T Get<T>(string key, T defaultValue);
                
        T Get<T>(string key, T defaultValue, string sharedName);
                 
        void Set<T>(string key, T value);
                
        void Set<T>(string key, T value, string sharedName);
                       
        void Remove(string key);
               
        void Remove(string key, string sharedName);
    }
}
