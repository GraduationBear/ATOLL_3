using System;


namespace ATOLL_3;

	public class Items
	{
    	public List<Item> list{get;set;} = new List<Item>();
        public string ItemSelected="";
        private static string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"../../../../../../ATOLL_3/Resources/Build in Arrays"));
        public Items(){

            //Création de la treeview
            DirectoryInfo place = new DirectoryInfo(path);
            System.IO.DirectoryInfo[] dirs = place.GetDirectories();
            System.IO.FileInfo[] files; 
            int compteur=1;
            foreach(DirectoryInfo dir in dirs){
                files=dir.GetFiles();
                string dirname= dir.Name;
                this.list.Add(new Item(compteur.ToString(),dirname,true));
                int compteur2=compteur+1;
                foreach(System.IO.FileInfo file in files){
                    this.list.Add(new Item(compteur2.ToString(),file.Name,false,compteur.ToString(),false,path+"/"+dirname+"/"+file.Name));
                    compteur2++;
                }
                compteur=compteur2;
            }
        }
	}


