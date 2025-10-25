

Console.WriteLine(@"
 _    _      _                          
| |  | |    | |                         
| |  | | ___| | ___ ___  _ __ ___   ___ 
| |/\| |/ _ \ |/ __/ _ \| '_ ` _ \ / _ \
\  /\  /  __/ | (_| (_) | | | | | |  __/
 \/  \/ \___|_|\___\___/|_| |_| |_|\___|
                                        
                                        ");


Console.WriteLine("Vitaj v Aplikacii \n Made by Alex Ozaniak");
Console.WriteLine(" nacitavam program...");
await Task.Delay(1250);
Console.Clear();

Console.WriteLine("Zadaj cestu k svojmu súboru s hrami (napr. C:\\Users\\TvojeMeno\\Documents\\MojeHry.txt): alebo napis [skip pre preskocenie tohto kroku");
string filename = Console.ReadLine();
if (filename == null)
{
    Console.WriteLine("musis tam nieco napisat sigma");
}
else if (filename == "skip")
{
    Console.WriteLine("dobre sigma");
}
else
{
    string text = File.ReadAllText(filename);
}
// menuzoznam
List<string> Hry = new List<string>();
if (File.Exists(filename))
{
    Hry = File.ReadAllLines(filename).ToList();
}

// menu
Console.WriteLine(@"
___  ___                 
|  \/  |                 
| .  . | ___ _ __  _   _ 
| |\/| |/ _ \ '_ \| | | |
| |  | |  __/ | | | |_| |AC
\_|  |_/\___|_| |_|\__,_|
                         
                         ");
int VstupMenu;
do
{
    Console.Clear();
    Console.WriteLine("1: Pridat Hru \n2: Zobrazit vsetky hry \n3: Vyhladat hru \n4: Vymazat hru \n5: Ukoncit program");
    VstupMenu = int.Parse(Console.ReadLine());

    switch (VstupMenu)
    {
        case 1: GetGame(); break;
        case 2: ShowGames(); break;
        case 3: searchGame(); break;
        case 4: DeleteGame(); break;
        case 5: EndProgram(); break;
        default: Console.WriteLine("Neplatna volba!"); break;
    }

} while (VstupMenu != 5);

void SaveGames()
{
    File.WriteAllLines(filename, Hry);
}


void GetGame()
{
    Console.Clear();
    Console.WriteLine("aku hru chces pridat do zoznamu:");
    string pridathru = Console.ReadLine();
    if (Hry.Contains(pridathru))
    {
        return;
    }
    Hry.Add(pridathru);
    SaveGames();
    if (Hry.Contains(pridathru))
    {
        Console.WriteLine($" hra {pridathru} bola uspesne pridana");
        return;
    }
    else
    {
        Console.WriteLine(" Hra nebola pridana");
        return;
    }
}
void ShowGames()
{
    Console.Clear();
    Console.WriteLine("Momentalne mas ulozene tieto hry:");
    foreach (var game in Hry)
    {
        Console.WriteLine($"- {game}");
    }


    Console.WriteLine("pre vratenie sa do menui stlac klavesu  [G] ");
    char menu2 = char.Parse(Console.ReadLine());
    if (menu2.ToString().ToUpper() == "G")
    {
        return;
    }
    else
    {
        Console.WriteLine(" okay no tak si tu ostan");
    }
}



void searchGame()
{
    Console.Clear();
    Console.WriteLine("zadaj nazov hry ktoru chces vyhladat:");
    string GameSearch = Console.ReadLine().ToUpper();
    if (Hry.Any(h => h.Equals(GameSearch, StringComparison.OrdinalIgnoreCase)))

    {

        Console.WriteLine($" {GameSearch} sa uz nachadza v tvojom zozname");
    }

    else
    {
        Console.WriteLine("tato hra sa v tvojom zozname nenachadza");
    }
    Console.WriteLine("pre vratenie sa do menui stlac klavesu  [G] ");
    char menu2 = char.Parse(Console.ReadLine());


}
void DeleteGame()
{
    Console.Clear();
    Console.WriteLine(" aku hru si prajes vymazat");
    string gamedelete = Console.ReadLine();
    if (Hry.Contains(gamedelete))
    {

        Hry.Remove(gamedelete);
        SaveGames();
        Console.WriteLine($"hra {gamedelete} bola vymazana ");
    }
    else
    {
        Console.WriteLine("nastal error hra nebola vymazana");
    }
    Console.WriteLine("pre vratenie sa do menui stlac klavesu  [G] ");
    char menu2 = char.Parse(Console.ReadLine());

}
void EndProgram()
{
    Console.Clear();
    Console.WriteLine("program sa ukoncuje....");

}



