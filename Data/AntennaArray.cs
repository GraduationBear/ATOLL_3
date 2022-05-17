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
    public List<bool> HbuttonsState { get; private set; }

    public void SetAntennaArray(string text)
    {
        this.HbuttonsState = new List<bool>();
        this.text = text;
        this.splited = new List<string>(text.Split(new char[] { '\n', '\t', ':', '\r', '(', ')', '=', ';' }));
        this.splited.RemoveAll(EstVide);
        for (int i = 0; i < this.splited.Count - 1; i++)
        {
            this.splited[i] = this.splited[i].Trim();
        }
        for (int i = 0; i < this.splited.Count - 1; i++)
        {
            
            switch (this.splited[i])
            {
                case "H buttons state":
                    int j = i + 1;
                    while (this.splited[j]=="0" || this.splited[j] == "1")
                    {
                        if (this.splited[j] == "0")
                        {
                            this.HbuttonsState.Add(false);
                        }
                        else
                        {
                            this.HbuttonsState.Add(true);
                        }
                        j++;
                    }
                    break;
            }

        }
        //Récupération
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
    }
    private static bool EstVide(string s) { return s == "" || s == " " || s == "  "; }


}