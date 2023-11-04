using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Object
{
    public class Category
    {
        private int id;
        private string name;
        private int? parentId;

        public Category(int id, string name, int? parentId)
        {
            this.id = id;
            this.name = name;
            this.parentId = parentId;
        }

        //constructor for deserializeation
        public Category() 
        {
            
        }

        public string ToString()
        {
            return $"{id} - {name}";
        }

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int? ParentId { get { return parentId;} set { parentId = value; } }
    }
}
