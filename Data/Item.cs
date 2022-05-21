using System;
namespace ATOLL_3;

	public class Item
	{

		public string Id{get;set;}
        public string ParentId{get;set;}
        public bool HasSubFolders{get;set;}
        public bool Expanded{get;set;}
        public string Name{get;set;}
        public bool selected{get;set;}
        public string path{get;set;}

        //classe représentant un Item de la TreeView
        public Item(string Id,string Name,bool HasSubFolders,string ParentId=null,bool Selected=false,string path=null){
            this.Id=Id;
            this.ParentId=ParentId;
            this.Name=Name;
            this.HasSubFolders=HasSubFolders;
            this.Expanded=false;
            this.selected=Selected;
            this.path= path;
        }
	}


