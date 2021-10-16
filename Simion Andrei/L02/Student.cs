namespace lab2
{
    public class Student
    {
        public int ID{get; set;}
        public string Nume{get; set; }
        public string Prenume{get; set; }
        public string Facultate{get; set; }
        public int An{get; set; }
        public int Grupa{get; set; }
        // public Student(int ID, string Nume, string Prenume, string Facultate, int An, int Grupa){
        //     this.ID = ID;
        //     this.Nume = Nume;
        //     this.Prenume = Prenume;
        //     this.Facultate = Facultate;
        //     this.An = An;
        //     this.Grupa = Grupa;
        // }
        public Student(int id,string nume,string prenume,string facultate,int an,int grupa){
            ID = id;
            Nume = nume;
            Prenume = prenume;
            Facultate = facultate;
            An = an;
            Grupa = grupa;
        }
        public Student(Student student){
            this.ID = student.ID;
            this.Nume = student.Nume;
            this.Prenume = student.Prenume;
            this.Facultate = student.Facultate;
            this.An = student.An;
            this.Grupa = student.Grupa;
        }
    }
}