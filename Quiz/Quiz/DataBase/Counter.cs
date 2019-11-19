using System;
using System.ComponentModel.DataAnnotations;

namespace Quiz.DataBase
{
    public class Counter
    {
        [Key]
        public int IdNote { get; set; }
        public int Id { get; set; }
        public int Value { get; set; }
        public Counter(int id, int value)
        {
            Id = id;
            Value = value;
            IdNote = Guid.NewGuid().GetHashCode();
        }

        public Counter()
        {

        }
    }
}
