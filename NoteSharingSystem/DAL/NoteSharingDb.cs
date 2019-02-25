namespace NoteSharingSystem.DAL
{
    using NoteSharingSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class NoteSharingDb : DbContext
    {
        // Your context has been configured to use a 'NoteSharingDb' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'NoteSharingSystem.NoteSharingDb' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'NoteSharingDb' 
        // connection string in the application configuration file.
        public NoteSharingDb()
                 : base("name=NoteSharingDb")
        {
          
    }

        public virtual DbSet<Identity> Identities { get; set; }
        public virtual DbSet<Student>  Students{ get; set; }
        public virtual DbSet<Instructer> Instructers{ get; set; }
        public virtual DbSet<Note>   Notes { get; set; }
        public virtual DbSet<Lecture> Lectures{ get; set; }
        public virtual DbSet<Deparmant>  Departmants { get; set; }
        public virtual DbSet<University> Universities{ get; set; }


    }

 
}