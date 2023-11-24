using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class AllMetods
    {
        public Note GetByID(int ID)
        {
             return AppDB.Lab.Note.FirstOrDefault(x => x.ID == ID);
        }

        public Note GetByName(string Name)
        {
            return AppDB.Lab.Note.FirstOrDefault(x => x.Name == Name);
        }

        public void Add_Node(string Name, string Message)
        {       
            Note note = AppDB.Lab.Note.FirstOrDefault(x => x.Name == Name && x.Message == Message);
            if (note == null)
            {
                Note s = new Note();
                s.Name = Name;
                s.Message = Message;    
                AppDB.Lab.Note.Add(s);
                AppDB.Lab.SaveChanges();
            }
        }

        public void Update(int ID, string newMessage)
        {
            Note note = GetByID(ID);

            if (note != null)
            {
                note.Message = newMessage;

                AppDB.Lab.Note.AddOrUpdate(note);
                AppDB.Lab.SaveChanges();
            }
        }

        public void Delete(int ID)
        {
            Note note = GetByID(ID);
            if (note != null)
            {
                AppDB.Lab.Note.Remove(note);
                AppDB.Lab.SaveChanges();
            }
        }

    }
}
