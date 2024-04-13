using System.Collections.Generic;
using System.Text.Json;
using Scripts.Model;
using Microsoft.VisualBasic;
namespace help.Services;

public static class CurrentUserManager{
    
    public static string appDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    static string[] savedGames = [];

    public static User? currentUser;
    
    public static bool UserExists(){
        if (Path.Exists(appDir)){

        }
        return false;
    }

    static void loadUserGames(){
        savedGames = Directory.GetFiles(appDir);  
        Array.Sort(savedGames, new CustomComparer());
    }

    static void loadSaveSlot(string slotName){
        currentUser = JsonSerializer.Deserialize<User>(File.ReadAllText(slot(slotName)));
    }

    static string slot(string slotName){
        return Path.Combine(appDir, slotName);
    }
    
}

 public class CustomComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string appDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            var x_last_mod_time = File.GetLastWriteTime(Path.Combine(appDir, x));
            var y_last_mod_time = File.GetLastWriteTime(Path.Combine(appDir, y));
            return x_last_mod_time.CompareTo(y_last_mod_time); //TODO: check if this needs to be inverted
        }
    }
