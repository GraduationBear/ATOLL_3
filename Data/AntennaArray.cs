namespace ATOLL_3;
using System.Globalization;
public class AntennaArray
{
    public string name { get; private set; }
    public string text { get; private set; }
    public int NbAntennes { get; private set; }
    public bool Type { get; private set; }
    public List<string> splited { get; private set; } = null;
    public double Antenna1Height { get; private set; }
    public double Antenna2Height { get; private set; }
    public string Antenna1Diagram { get; private set; }
    public string Antenna2Diagram { get; private set; }
    public List<string> AntennaPaires { get; private set; }
    public List<bool> HbuttonsState { get; private set; }
    public List<double> AntennaSpacing { get; private set; }
    public List<String> AntennaLabels1 { get; private set; }
    public List<String> AntennaLabels2 { get; private set; }
    public List<double> DeltaX { get; private set; }
    public List<double> DeltaY { get; private set; }
    public List<double> DeltaZ { get; private set; }
    public double AntennaRotation { get; private set; }
    public double ArrayYoffset { get; private set; }

    public void SetAntennaArray(string text)
    {

        bool found = false;
        this.HbuttonsState = new List<bool>();
        this.AntennaSpacing = new List<double>();
        this.AntennaPaires = new List<string>();
        this.AntennaLabels1 = new List<string>();
        this.AntennaLabels2 = new List<string>();
        this.DeltaX = new List<double>();
        this.DeltaY = new List<double>();
        this.DeltaZ = new List<double>();


        this.text = text;
        this.splited = new List<string>(text.Split(new char[] { '\n', '\t', ':', '\r', '(', ')', '=', ';' }));
        this.splited.RemoveAll(EstVide);

        //On enlève les espaces des éléments de notre tableau
        for (int i = 0; i < this.splited.Count - 1; i++)
        {
            this.splited[i] = this.splited[i].Trim();
        }


        //Récupération des parties inchangés selon le fichier
        this.name = this.splited[0];
        this.NbAntennes = int.Parse(this.splited[2]);

        if (this.splited[4].Trim() == "1")
        {
            this.Type = true;
        }
        else
        {
            this.Type = false;
        }
        this.Antenna1Height = double.Parse(this.splited[9], CultureInfo.InvariantCulture);
        this.Antenna2Height = double.Parse(this.splited[11], CultureInfo.InvariantCulture);
        this.Antenna1Diagram = this.splited[15];
        this.Antenna2Diagram = this.splited[18];

        //On récupère les éléments qui varient selon les fichiers
        for (int i = 0; i < this.splited.Count - 1; i++)
        {

            switch (this.splited[i])
            {
                case "Antennas paires":
                    for (int j = i + 1; j <= i + (this.NbAntennes / 2); j++)
                    {
                        this.AntennaPaires.Add(this.splited[j]);
                    }
                    break;
                case "H buttons state":
                    for (int j = i + 1; j <= i + (this.NbAntennes / 2); j++)
                    {
                        if (this.splited[j] == "0")
                        {
                            this.HbuttonsState.Add(false);
                        }
                        else
                        {
                            this.HbuttonsState.Add(true);
                        }
                    }
                    break;
                case "Antenna spacing":
                    for (int j = i + 1; j <= i + (this.NbAntennes / 2); j++)
                    {
                        this.AntennaSpacing.Add(double.Parse(this.splited[j], CultureInfo.InvariantCulture));
                    }
                    break;
                case "Antennas labels":
                    //Ligne 1
                    if (!found)
                    {
                        for (int j = i + 1; j <= i + this.NbAntennes; j++)
                        {
                            this.AntennaLabels1.Add(this.splited[j]);
                        }
                        found = !found;
                    }
                    else// Ligne 2
                    {
                        for (int j = i + 1; j <= i + this.NbAntennes; j++)
                        {
                            this.AntennaLabels2.Add(this.splited[j]);
                        }
                    }
                    break;
                case "Ant pos X error":
                    for (int j = i + 2; j <= i + 1 + this.NbAntennes; j++)
                    {
                        this.DeltaX.Add(double.Parse(this.splited[j], CultureInfo.InvariantCulture));
                    }
                    break;
                case "Ant pos Y error":
                    for (int j = i + 2; j <= i + 1 + this.NbAntennes; j++)
                    {
                        this.DeltaY.Add(double.Parse(this.splited[j], CultureInfo.InvariantCulture));
                    }
                    break;

                case "Ant pos Z error":
                    for (int j = i + 2; j <= i + 1 + this.NbAntennes; j++)
                    {
                        this.DeltaZ.Add(double.Parse(this.splited[j], CultureInfo.InvariantCulture));
                    }
                    break;
                case "Array Rotation":
                    this.AntennaRotation=double.Parse(this.splited[i+2], CultureInfo.InvariantCulture);
                    break;
                case "Array Y offset":
                    this.ArrayYoffset= double.Parse(this.splited[i + 2], CultureInfo.InvariantCulture);
                    break;
            }
        }
    }
    private static bool EstVide(string s) { return s == "" || s == " " || s == "  "; }

}