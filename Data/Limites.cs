namespace ATOLL_3;

public class Limites{
    //Représente le localizer
    public List<Point> Loc{get; private set;}
    //Représente la piste
    public List<Point> Runway{get; private set;}
    //Stocke les différentes Echelles pour l'axe DDM
    public List<int> ListScaleApproach{get; private set;}
    public List<int> ListScaleOrbit { get; private set; }
    //Stocke la liste des limites possibles à appliquer
    public List<Limite> ApproachLimite { get; private set; } 
    public List<Limite> OrbitLimite { get; private set; } 

    //Stocke le nom de la limite selectionnée
    public string selectedApproach { get; set;}
    public string selectedOrbit { get; set; }
    //Longeur de la piste 
    public double RunwayLength{get; set;}
    //Distance de la piste avec le localizer
    public double SetBack{get; set;}
    //Interval entre les valeurs de l'axe des abscisses
    public int IntervalApproach { get; private set;}
    //Stocke la valeur de la DDM Scale
    public int scaleApproach { get; set;}

    public double minApproach { get; set;}

    public double pasApproach { get; set;}

    public double maxApproach{get; set;}

    public int IntervalOrbit { get; private set; }
    //Stocke la valeur de la DDM Scale
    public int scaleOrbit { get; set; }

    public double minOrbit { get; set; }

    public double pasOrbit { get; set; }

    public double maxOrbit { get; set; }



    public Limites(){
        //Variables de base
        this.RunwayLength=3000;
        this.SetBack=300;
        this.SetOrbit();
        this.SetApproach();
        
        
    }

    //Classe permettant de rechercher une limite par son Nom
    public Limite RechercherParNom(string onglet){
        if (onglet == "Orbit")
        {
            foreach (Limite l in OrbitLimite)
            {
                if (this.selectedOrbit == l.nom)
                {
                    return l;
                }
            }
            return null;
        }
        else
        {
            foreach (Limite l in ApproachLimite)
            {
                if (this.selectedApproach == l.nom)
                {
                    return l;
                }
            }
            return null;
        }
        
    }

    //Classe permettant de recupérer les noms des limites
    public List<string> GetNoms(string onglet){
        List<string> noms = new List<string>();
        if (onglet == "Orbit")
        {
            foreach (Limite l in OrbitLimite)
            {
                noms.Add(l.nom);
            }
            return noms;
        }
        else
        {
            foreach (Limite l in ApproachLimite)
            {
                noms.Add(l.nom);
            }
            return noms;
        }
        
    }

    //Mets en place les valeurs correspondant à l'onglet ORBIT
    public void SetOrbit(int min=-40, int max=40){
        this.selectedOrbit="OFF";
        this.IntervalOrbit=5;
        this.scaleOrbit=600;
        this.minOrbit=min;
        this.maxOrbit=max;
        
        double alpha=Math.Atan2(SetBack+RunwayLength,105);

        this.ListScaleOrbit=new List<int>();
        this.ListScaleOrbit.Add(10);
        this.ListScaleOrbit.Add(25);
        this.ListScaleOrbit.Add(50);
        this.ListScaleOrbit.Add(100);
        this.ListScaleOrbit.Add(200);
        this.ListScaleOrbit.Add(300);
        this.ListScaleOrbit.Add(400);
        this.ListScaleOrbit.Add(600);
        this.ListScaleOrbit.Add(800);
        this.ListScaleOrbit.Add(1000);

        this.OrbitLimite=new List<Limite>();
        Limite empty = new Limite("OFF");
        Limite display = new Limite("ON");
        display.pointsNeg.Add(new Point{ XValue = -100, YValue = -150 });
        display.pointsNeg.Add(new Point{ XValue = -10, YValue = -150 });
        display.pointsNeg.Add(new Point{ XValue = -10, YValue = -174 });
        display.pointsNeg.Add(new Point{ XValue = -alpha, YValue = -174 });
        display.pointsPos.Add(new Point{ XValue = 100, YValue = 150 });
        display.pointsPos.Add(new Point{ XValue = 10, YValue = 150 });
        display.pointsPos.Add(new Point{ XValue = 10, YValue = 174 });
        display.pointsPos.Add(new Point{ XValue = alpha, YValue = 174 });
        
        this.OrbitLimite.Add(empty);
        this.OrbitLimite.Add(display);
    }

    public void SetApproach(int min=0,int max=12000){
        this.selectedApproach="OFF";
        this.IntervalApproach=1000;
        this.scaleApproach=50;
        this.minApproach=min;
        this.maxApproach=max;

        this.ListScaleApproach=new List<int>();
        this.ListScaleApproach.Add(5);
        this.ListScaleApproach.Add(10);
        this.ListScaleApproach.Add(25);
        this.ListScaleApproach.Add(50);
        this.ListScaleApproach.Add(100);
        this.ListScaleApproach.Add(200);
        this.ListScaleApproach.Add(300);
        this.ListScaleApproach.Add(400);

        this.ApproachLimite=new List<Limite>();
        Limite empty = new Limite("OFF");
        Limite Cat1 = new Limite("CAT 1");
        Limite Cat2 = new Limite("CAT 2");
        Limite Cat3 = new Limite("CAT 3");

        this.ApproachLimite.Add(empty);

        Cat1.pointsNeg.Add(new Point { XValue = SetBack+RunwayLength+572, YValue = -15 });
        Cat1.pointsNeg.Add(new Point { XValue = SetBack+RunwayLength+1000, YValue = -15 });
        Cat1.pointsNeg.Add(new Point { XValue = SetBack+RunwayLength+7400, YValue = -30 });
        Cat1.pointsNeg.Add(new Point { XValue = max, YValue = -30 });

        Cat1.pointsPos.Add(new Point { XValue = SetBack+RunwayLength+572, YValue = 15 });
        Cat1.pointsPos.Add(new Point { XValue = SetBack+RunwayLength+1000, YValue = 15 });
        Cat1.pointsPos.Add(new Point { XValue = SetBack+RunwayLength+7400, YValue = 30 });
        Cat1.pointsPos.Add(new Point { XValue = max, YValue = 30 });
        this.ApproachLimite.Add(Cat1);

        Cat2.pointsNeg.Add(new Point { XValue = SetBack+RunwayLength, YValue = -5 });
        Cat2.pointsNeg.Add(new Point { XValue = SetBack+RunwayLength+1000, YValue = -5 });
        Cat2.pointsNeg.Add(new Point { XValue = SetBack+RunwayLength+7400, YValue = -30 });
        Cat2.pointsNeg.Add(new Point { XValue = max, YValue = -30 });

        Cat2.pointsPos.Add(new Point { XValue = SetBack+RunwayLength, YValue = 5 });
        Cat2.pointsPos.Add(new Point { XValue = SetBack+RunwayLength+1000, YValue = 5 });
        Cat2.pointsPos.Add(new Point { XValue = SetBack+RunwayLength+7400, YValue = 30 });
        Cat2.pointsPos.Add(new Point { XValue = max, YValue = 30 });
        this.ApproachLimite.Add(Cat2);

        Cat3.pointsNeg.Add(new Point { XValue = SetBack+600, YValue = -10 });
        Cat3.pointsNeg.Add(new Point { XValue = SetBack+RunwayLength-900, YValue = -5 });
        Cat3.pointsNeg.Add(new Point { XValue = SetBack+RunwayLength+1000, YValue = -5 });
        Cat3.pointsNeg.Add(new Point { XValue = SetBack+RunwayLength+7400, YValue = -30 });
        Cat3.pointsNeg.Add(new Point { XValue = max, YValue = -30 });

        Cat3.pointsPos.Add(new Point { XValue = SetBack+600, YValue = 10 });
        Cat3.pointsPos.Add(new Point { XValue = SetBack+RunwayLength-900, YValue = 5 });
        Cat3.pointsPos.Add(new Point { XValue = SetBack+RunwayLength+1000, YValue = 5 });
        Cat3.pointsPos.Add(new Point { XValue = SetBack+RunwayLength+7400, YValue = 30 });
        Cat3.pointsPos.Add(new Point { XValue = max, YValue = 30 });
        this.ApproachLimite.Add(Cat3);

        this.Runway=new List<Point>();
        this.Runway.Add(new Point{ XValue= SetBack,YValue=0.5});
        this.Runway.Add(new Point{ XValue= SetBack,YValue=-0.5});
        this.Runway.Add(new Point{ XValue= SetBack+RunwayLength,YValue=-0.5});
        this.Runway.Add(new Point{ XValue= SetBack+RunwayLength,YValue=0.5});
        this.Runway.Add(new Point{ XValue= SetBack,YValue=0.5});

        this.Loc= new List<Point>();
        this.Loc.Add(new Point{ XValue= 0,YValue=-0.5});
        this.Loc.Add(new Point{ XValue= 10,YValue=-0.5});
        this.Loc.Add(new Point{ XValue= 10,YValue=0.5});
        this.Loc.Add(new Point{ XValue= 0,YValue=0.5});
        this.Loc.Add(new Point{ XValue= 0,YValue=-0.5});
    }
}