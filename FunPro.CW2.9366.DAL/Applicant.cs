using System;
using System.Collections.Generic;
using System.Text;

namespace FunPro.CW2._9366.DAL
{
    public class Applicant
    {
        public int Id { get; set; }
        public string Name
        {
            get => Name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Name cannot be empty");
                Name = value;
            }
        }
        public int Score { get; set; }
        public string Tests_taken { get; set; }

        public Applicant(string name, int score, string tests_taken)
        {
            Name = name;
            Score = score;
            Tests_taken = tests_taken;
        }
    }
}
