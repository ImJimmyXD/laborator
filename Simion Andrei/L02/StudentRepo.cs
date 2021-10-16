using System;
using System.Collections.Generic;
namespace lab2
{
    public class StudentRepo
    {
        private List<Student> students = new List<Student>();

        public StudentRepo()
        {
            students.Add(new Student(1, "Simion", "Andrei", "AC", 4, 5));
            students.Add(new Student(2, "Hirsovescu", "Radu", "AC", 4, 3));
            students.Add(new Student(3, "Jack", "Daniels", "AC", 3, 2));
            students.Add(new Student(4, "Popescu", "Alex", "ETC", 1, 2));
            students.Add(new Student(5, "Johnny", "Walker", "MED", 6, 2));
        }

        public void displayStudents(List<Student> students) {
            students.ForEach(Console.WriteLine);
            
        }
        
        // public bool checkID(List<Student> students,int id)
        public void addStudent(Student student) { students.Add(new Student(student)); }

        public void addStudent(int id,string nume,string prenume,string facultate,int an,int grupa){students.Add(new Student(id,nume,prenume,facultate,an,grupa));}

        public void returnStudents(List<Student> students) { foreach(var item in students){
            Console.WriteLine(item.ToString());
        }}

        public void deleteStudent(List<Student> students,int id){
            foreach(Student item in students){ 
                if(item.ID == id){
                    students.Remove(item);
                }
            }
        }
        public void updateStudent(List<Student> students,int id, Student student){
            foreach(Student item in students){
                students[students.FindIndex(x => x.ID == student.ID)]=student;
            }
        }

        public bool checkIfStudentExists(Student student){
            var check = new StudentComparer();
            foreach(Student item in students){
                if(check.Equals(item,student)){return true;}
            }
            return false;
        }
    }

    class StudentComparer : IEqualityComparer<Student>{
        public bool Equals(Student x,Student y){
            if (x == null || y == null){return false;}

            return (x.ID == y.ID && x.Nume == y.Nume && x.Prenume == y.Prenume && x.Facultate == y.Facultate && x.An == y.An && x.Grupa == y.Grupa); 
        }

        public int GetHashCode(Student student) {
            if(Object.ReferenceEquals(student, null)){return 0;}

            int hashStudentName = student.Nume == null ? 0 : student.Nume.GetHashCode();

            return student.Nume.GetHashCode();
        }
    }
}