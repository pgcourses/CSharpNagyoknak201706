using System;

namespace _01Data.Model
{
    public class Severity
    {
        //Ha a kulcsmező nem követi a névkonvenciót akkor 
        //[Key] attributum kell a mezőre
        public int Id { get; set; }
        public string Title { get; set; }
        //public DateTime Created { get; set; }
    }
}