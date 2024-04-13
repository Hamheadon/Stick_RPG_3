using System;
namespace Scripts.Model;

public class User
{
    string Name { get; set; }
    List<Job> Active_jobs { get; set; } = [];

	public Dictionary<string, int> Attributes = [];

	public int Health{ get; set; } = 100;

	public double cash{ get; set; } = 0;




	public User(string name="Oliver", Dictionary<string, int>? preset_attributes=null){
		Name = name;
		if (preset_attributes is null){
			resetAttributes();
		}
		else{
			List<string> qualities = ["Karma", "Intelligence", "Strength", "Charm"];
			foreach(string quality in qualities){
				if (! preset_attributes.ContainsKey(quality)){
					throw new Exception("One or more of the four player attributes is missing");	
				}	
			}
			Attributes = preset_attributes;
		}
		
		
	}


	public void resetAttributes(){
		Attributes.Add("Karma", 0);
		Attributes.Add("Intelligence", 0);
		Attributes.Add("Strength", 0);
		Attributes.Add("Charm", 0);
	}
}
