namespace Classlib.Dictionaries;

public static class DomainDictionaries 
{
 //   public static GetCambio(int cod) => Dictionary<int,string>
    public static string GetCambio(int cod) => Cambio[cod];
    public static string GetFabricante(int cod)
    {
        string? resp;
        var ok = Fabricante.TryGetValue(cod,out resp);
        return ok ? resp! : "FABRICANTE NÃO DEFINIDO";
    }

    public static string GetCombustivel(int cod)
        => Combustiveis[cod];
    
    public static string GetGrupo(int cod)
        => Grupo[cod];
    
    public static string GetTipo(int cod)
        => Tipo[cod];
    private static Dictionary<int,string> Tipo = new()
    {
        {1,"CAMINHÃO"},
        {2,"ESPORTIVO"},
        {3,"MODELO ESPECIAL"},
        {4,"MOTOCICLETA"},
        {5,"MOTOR HOME"},
        {6,"ÔNIBUS"},
        {7,"PASSEIO"},
        {8,"PICK-UP LEVE"},
        {9,"PICK-UP PESADA PESSOA"},
        {10,"PICK-UP PESADA CARGA"},
        {11,"REBOCADOR"},
        {12,"REBOQUE E SEMIREBOQUE"},
        {13,"TRATOR, MÁQUINA AGRÍCOLA"},
        {14,"VAN"}
    };
    private static Dictionary<int,string> Grupo = new()
    {
        {1,"PASSEIO"},
        {2,"PICK-UP"},
        {3,"CAMINHÃO"},
        {4,"MOTO"},
        {5,"OUTROS"}
    };
    private static Dictionary<int,string> Combustiveis = new()
    {
        {1,"GASOLINA"},
        {2,"ÁLCOOL"},
        {3,"DIESEL"},
        {4,"GNV"},
        {5,"ELÉTRICO"},
        {6,"OUTROS"},
        {7,"GASOLINA / ÁLCOOL"},
        {8,"GASOLINA / GNV"},
        {9,"ÁLCOOL / GNV"},
        {10,"GASOLINA / ÁLCOOL / GNV"},
        {11,"INDEFINIDO"},
        {99,"QUALQUER"}
    };
    
    private static Dictionary<int,string> Cambio = new()
    {
        {1, "Manual"},
        {2, "Automático/Semi automático"},
        {3, "Indefinido"},
        {99, "Indefinido"}

    };

    private static Dictionary<int,string> Fabricante = new()
    {
        {1,"MODELO ESPECIAL"},
        {2,"BAZZA"},
        {3,"GM"},
        {4,"DODGE"},
        {5,"FIAT"},
        {6,"FORD"},
        {7,"MERCEDES BENZ"},
        {8,"REBOQUES"},
        {9,"SCANIA"},
        {10,"TOYOTA"},
        {11,"VOLKSWAGEN"},
        {12,"VOLVO"},
        {13,"CHRYSLER"},
        {14,"F.N.M."},
        {15,"ÔNIBUS"},
        {16,"IDEROL"},
        {17,"FRUEHAUF"},
        {18,"GUERRA"},
        {19,"MASSARI"},
        {20,"RANDON"},
        {21,"RODOVIARIA"},
        {22,"CLARK"},
        {23,"RIZZO"},
        {24,"FURGLASS"},
        {25,"PAULISTA"},
        {26,"CARRIZO"},
        {27,"GURGEL"},
        {28,"RENHA"},
        {29,"PUMA"},
        {30,"ROSSETTI"},
        {31,"KRONE"},
        {32,"RECRUSUL"},
        {33,"DAMBROZ"},
        {34,"GRALH"},
        {35,"MARCOFRIGO"},
        {36,"INCREAL"},
        {37,"FURGARE"},
        {38,"INTERNAC."},
        {39,"NOMA"},
        {40,"METALPI"},
        {42,"CONTIN"},
        {43,"AGRALE"},
        {44,"INVEL"},
        {45,"SCHIFFER"},
        {46,"CAPRINI"},
        {47,"BISSELI"},
        {48,"GOTTI"},
        {49,"MATRA"},
        {50,"MOTO"},
        {51,"VEIC ESTR"},
        {52,"EQUIPAMENT"},
        {53,"SEMI REB."},
        {54,"BAU"},
        {55,"FACCHINI"},
        {56,"JPX"},
        {57,"KIA MOTORS"},
        {58,"ASIA MOTORS"},
        {59,"DAEWOO"},
        {60,"DAIHATSU"},
        {61,"HONDA"},
        {62,"HYUNDAI"},
        {63,"MITSUBISHI"},
        {64,"PEUGEOT"},
        {65,"AUDI"},
        {66,"MAZDA"},
        {67,"SUZUKI"},
        {68,"CITROEN"},
        {69,"NISSAN"},
        {70,"RENAULT"},
        {71,"YAMAHA"},
        {72,"BMW"},
        {73,"LADA"},
        {74,"SUBARU"},
        {75,"PASTRE"},
        {76,"KAWASAKI"},
        {77,"LAND ROVER"},
        {78,"ISUZU"},
        {79,"SEAT"},
        {80,"JAGUAR"},
        {81,"JIANMSHE"},
        {82,"PONTIAC"},
        {83,"HYOSUNG"},
        {84,"OLDSMOBILE"},
        {85,"MINSK"},
        {86,"NAVISTAR INTERNATIONAL"},
        {87,"GOYDO"},
        {88,"HC HORNBURG"},
        {89,"HARLEY DAVIDSON"},
        {90,"SSANGYONG"},
        {91,"TRAMONTINI"},
        {92,"BRANDY"},
        {93,"ENGESA"},
        {94,"BENTLEY"},
        {95,"LOTUS"},
        {96,"ROLLS ROYCE"},
        {97,"SAAB"},
        {98,"PORSCHE"},
        {99,"DAELIN"},
        {100,"PLYMOUTH"},
        {101,"TROLLER"},
        {102,"MARCOPOLO"},
        {103,"BUGGY"},
        {104,"ENVEMO"},
        {105,"ANTONINI"},
        {106,"COLON"},
        {107,"GALEGO"},
        {108,"TURISCAR"},
        {109,"TURISCAR"},
        {110,"KRONORTE"},
        {112,"CALOI"},
        {113,"EMME"},
        {114,"JIALING"},
        {115,"KAHENA"},
        {116,"KASINSKI"},
        {117,"KTM"},
        {118,"L'AQUILA"},
        {119,"ORCA"},
        {120,"PIAGGIO"},
        {121,"SANYANG"},
        {122,"SUNDOWN"},
        {123,"TRIUMPH"},
        {124,"MONARK"},
        {125,"FERRARI"},
        {126,"BERTOLINI"},
        {127,"BLAYA"},
        {128,"ENGERAUTO"},
        {129,"JUSTARI"},
        {130,"KUME"},
        {131,"LIDER"},
        {132,"LINSHALM"},
        {133,"TECTRAN"},
        {134,"THERMOSUL"},
        {135,"MASERATI"},
        {136,"UNICARR"},
        {137,"TRES EIXOS"},
        {138,"UNIDAS"},
        {139,"LIESS"},
        {140,"BETONTECH"},
        {141,"CIOATO"},
        {142,"RODINE"},
        {143,"RODOSINOS"},
        {144,"AM GENERAL HUMMER"},
        {145,"ROVER"},
        {146,"ALFA ROMEO"},
        {147,"ACURA"},
        {148,"CBT"},
        {149,"JEEP"},
        {150,"MERCURY"},
        {151,"LEXUS"},
        {152,"GMC"},
        {153,""}
    };
}