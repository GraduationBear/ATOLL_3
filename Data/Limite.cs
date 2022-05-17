namespace ATOLL_3;


public class Limite
    {
        public List<Point> pointsPos { get; set; }
        public List<Point> pointsNeg { get; set; }
        public string nom { get; set; }
        public Limite(string nom){
            this.pointsNeg= new List<Point>();
            this.pointsPos=new List<Point>();
            this.nom= nom;
        }
    }