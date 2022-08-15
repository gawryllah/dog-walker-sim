using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "ClientExtensSO", menuName = "ScriptableObjects/ClientExtensSO")]
public class SOExtens : ScriptableObject
{
    [SerializeField] private List<ClientSO> clientExtens = new List<ClientSO>();
    [SerializeField] private List<DogSO> dogExtens = new List<DogSO>();

    [SerializeField] private Dictionary<int, DogSO> ownerDogRelation = new Dictionary<int, DogSO>();



    [SerializeField] private GameObject addresses;
    [SerializeField] private GameObject tempAddress;

    [SerializeField] static int addressGoIndex = 0;

    [SerializeField] private bool initialized = false;

    public List<ClientSO> ClientsSO { get { return clientExtens; } }
    public List<DogSO> DogsSO { get { return dogExtens; } }



    private void OnEnable()
    {
        Initialize();
    }

    void Initialize()
    {
        if (!initialized)
        {


            foreach (ClientSO client in clientExtens)
            {
                client.initClient((names[Random.Range(0, names.Length - 1)]), (surnames[Random.Range(0, surnames.Length - 1)]), assignNextAddress());
                addressGoIndex++;


                //Debug.Log($"At {this}, Client: {client.getClientInfo()} ");
            }

            foreach (DogSO dog in dogExtens)
            {
                dog.initDog(dognames[Random.Range(0, dognames.Length - 1)], Random.Range(0f, 100f), Random.Range(0f, 100f), 0, Random.Range(0f, 50f));
            }

            if (clientExtens.Count == dogExtens.Count)
            {
                Debug.Log($"CE Length: {clientExtens.Count}, DE Length: {dogExtens.Count}");
                for (int i = 0; i < clientExtens.Count; i++)
                {
                    ownerDogRelation.Add(clientExtens[i].ID, dogExtens[i]);
                    clientExtens[i].DogSO = dogExtens[i];
                }

            }
            else
            {
                Debug.Log($"{ (clientExtens.Count > dogExtens.Count ? "Not enough dogs" : "Not enough clients")}");
            }


            initialized = true;

            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
        }

    }



    GameObject assignNextAddress()
    {
        return addresses.transform.childCount - 1 > addressGoIndex ? addresses.transform.GetChild(addressGoIndex).gameObject : tempAddress;
    }



    public Dictionary<int, DogSO> getDictonaryOwnerDogRelation()
    {
        return ownerDogRelation;
    }

    /*
    public DogSO getDogOfOwner(ClientSO client)
    {
        if (ownerDogRelation.ContainsKey(client.ID))
        {
            DogSO dog = ownerDogRelation[client.ID];

            return dog;
        }
        else
        {
            return null;
        }

    }
    */

    public DogSO getDogOfOwner(Client client)
    {
        if (ownerDogRelation.ContainsKey(client.ID))
        {
            DogSO dog = ownerDogRelation[client.ID];

            return dog;
        }
        else
        {
            return null;
        }

    }

    public DogSO getDogOfOwner(int id)
    {
        if (ownerDogRelation.ContainsKey(id))
        {
            DogSO dog = ownerDogRelation[id];

            return dog;
        }
        else
        {
            return null;
        }

    }

    public int getIdOfDog(Client client)
    {
        if (ownerDogRelation.ContainsKey(client.ID))
        {
            return ownerDogRelation[client.ID].ID;
        }
        else
        {
            throw new Exception($"No dog found for ID: {client.ID}");
        }
    }

    public ClientSO getClinet(int index)
    {
        return clientExtens[index];
    }

    public List<ClientSO> getClientExtens()
    {
        return clientExtens;
    }


    private string[] names = new string[] {
    "Albina","Alyce","Amie","Angela","Annis","Carol","Carra","Clarence","Clarinda","Delphia","Dillie","Doshie","Drucilla","Etna","Eugenie","Eulalia","Eve","Felicia","Florance","Fronie","Geraldine","Gina","Glenna","Grayce","Hedwig","Jessica","Jossie","Katheryn","Katy","Lea","Leanna","Leitha","Leone","Lidie","Loma","Lular","Magdalen","Maymie","Minervia","Muriel","Neppie","Olie","Onie","Osa","Otelia","Paralee","Patience","Rella","Rillie","Rosanna","Theo","Tilda","Tishie","Tressa","Viva","Yetta","Zena","Zola","Abby","Aileen","Alba","Alda","Alla","Alverta","Ara","Ardelia","Ardella","Arrie","Arvilla","Augustine","Aurora","Bama","Bena","Byrd","Calla","Camilla","Carey","Carlotta","Celestia","Cherry","Cinda","Classie","Claudine","Clemie","Clifford","Clyda","Creola","Debbie","Dee","Dinah","Doshia","Ednah","Edyth","Eleanora","Electa","Eola","Erie","Eudora","Euphemia","Evalena","Evaline","Faith","Fidelia","Freddie","Golda","Harry","Helma","Hermine","Hessie","Ivah","Janette","Jennette","Joella","Kathryne","Lacy","Lanie","Lauretta","Leana","Leatha","Leo","Liller","Lillis","Louetta","Madie","Mai","Martina","Maryann","Melva","Mena","Mercedes","Merle","Mima","Minda","Monica","Nealie","Netta","Nolia","Nonie","Odelia","Ottilie","Phyllis","Robbie","Sabina","Sada","Sammie","Suzanne","Sybilla","Thea","Tressie","Vallie","Venie","Viney","Wilhelmine","Winona","Zelda","Zilpha","Adelle","Adina","Adrienne","Albertine","Alys","Ana","Araminta","Arthur","Birtha","John","William","James","Charles","George","Frank","Joseph","Thomas","Henry","Robert","Edward","Harry","Walter","Arthur","Fred","Albert","Samuel","David","Louis","Joe","Charlie","Clarence","Richard","Andrew","Daniel","Ernest","Will","Jesse","Oscar","Lewis","Peter","Benjamin","Frederick","Willie","Alfred","Sam","Roy","Herbert","Jacob","Tom","Elmer","Carl","Lee","Howard","Martin","Michael","Bert","Herman","Jim","Francis","Harvey","Earl","Eugene","Ralph","Ed","Claude","Edwin","Ben","Charley","Paul","Edgar","Isaac","Otto","Luther","Lawrence","Ira","Patrick","Guy","Oliver","Theodore","Hugh","Clyde","Alexander","August","Floyd","Homer","Jack","Leonard","Horace","Marion","Philip","Allen","Archie","Stephen","Chester","Willis","Raymond","Rufus","Warren","Jessie","Milton","Alex","Leo","Julius","Ray","Sidney","Bernard","Dan","Jerry","Calvin","Perry","Dave","Anthony","Eddie","Amos","Dennis","Clifford","Leroy","Wesley","Alonzo","Garfield","Franklin","Emil","Leon","Nathan","Harold","Matthew","Levi","Moses","Everett","Lester","Winfield","Adam","Lloyd","Mack","Fredrick","Jay","Jess","Melvin","Noah","Aaron","Alvin","Norman","Gilbert","Elijah","Victor","Gus","Nelson","Jasper","Silas","Jake","Christopher","Mike","Percy","Adolph","Maurice","Cornelius","Felix","Reuben","Wallace","Claud","Roscoe","Sylvester","Earnest","Hiram","Otis","Simon","Willard","Irvin","Mark","Jose","Wilbur","Abraham","Virgil","Clinton","Elbert","Leslie","Marshall","Owen","Wiley","Anton","Morris","Manuel","Phillip","Augustus","Emmett","Eli","Nicholas","Wilson","Alva","Harley","Newton","Timothy","Marvin","Ross","Curtis","Edmund","Jeff","Elias","Harrison","Stanley","Columbus","Lon","Ora","Ollie","Pearl","Russell","Solomon","Arch","Asa","Clayton","Enoch","Irving","Mathew","Nathaniel","Scott","Hubert","Lemuel","Andy","Ellis","Emanuel","Joshua","Millard","Vernon","Wade","Cyrus","Miles","Rudolph","Sherman","Austin","Bill","Chas","Lonnie","Monroe","Byron","Edd","Emery","Grant","Jerome","Max","Mose","Steve","Gordon","Abe","Pete","Chris","Clark","Gustave","Orville","Lorenzo","Bruce","Marcus","Preston","Bob","Dock","Donald","Jackson","Cecil","Barney","Delbert","Edmond","Anderson","Christian","Glenn","Jefferson","Luke","Neal","Burt","Ike","Myron","Tony","Conrad","Joel","Matt","Riley","Vincent","Emory","Isaiah","Nick","Ezra","Green","Juan","Clifton","Lucius","Porter","Arnold","Bud","Jeremiah","Taylor","Forrest","Roland","Spencer","Burton","Don","Emmet","Gustav","Louie","Morgan","Ned","Van","Ambrose","Chauncey","Elisha","Ferdinand","General","Julian","Kenneth","Mitchell","Allie","Josh","Judson","Lyman","Napoleon","Pedro","Berry","Dewitt","Ervin","Forest","Lynn","Pink","Ruben","Sanford","Ward","Douglas","Ole","Omer","Ulysses","Walker","Wilbert","Adelbert","Benjiman","Ivan","Jonas","Major","Abner","Archibald","Caleb","Clint","Dudley","Granville","King","Mary","Merton","Antonio","Bennie","Carroll","Freeman","Josiah","Milo","Royal","Dick","Earle","Elza","Emerson","Fletcher","Judge","Laurence","Neil","Roger","Seth","Glen","Hugo","Jimmie","Johnnie","Washington","Elwood","Gust","Harmon","Jordan","Simeon","Wayne","Wilber","Clem","Evan","Frederic","Irwin","Junius","Lafayette","Loren","Madison","Mason","Orval","Abram","Aubrey","Elliott","Hans","Karl","Minor","Wash","Wilfred","Allan","Alphonse","Dallas","Dee","Isiah","Jason","Johnny","Lawson","Lew","Micheal","Orin","Addison","Cal","Erastus","Francisco","Hardy","Lucien","Randolph","Stewart","Vern","Wilmer","Zack","Adrian","Alvah","Bertram","Clay","Ephraim","Fritz","Giles","Grover","Harris","Isom","Jesus","Johnie","Jonathan","Lucian","Malcolm","Merritt","Otho","Perley","Rolla","Sandy","Tomas","Wilford","Adolphus","Angus","Arther","Carlos","Cary","Cassius","Davis","Hamilton","Harve","Israel","Leander","Melville","Merle","Murray","Pleasant","Sterling","Steven","Axel","Boyd","Bryant","Clement","Erwin","Ezekiel","Foster","Frances","Geo","Houston","Issac","Jules","Larkin","Mat","Morton","Orlando","Pierce","Prince","Rollie","Rollin","Sim","Stuart","Wilburn","Bennett","Casper","Christ","Dell","Egbert","Elmo","Fay","Gabriel","Hector","Horatio","Lige","Saul","Smith","Squire","Tobe","Tommie","Wyatt","Alford","Alma","Alton","Andres","Burl","Cicero","Dean","Dorsey","Enos","Howell","Lou","Loyd","Mahlon","Nat","Omar","Oran","Parker","Raleigh","Reginald","Rubin","Seymour","Wm","Young","Benjamine","Carey","Carlton","Eldridge","Elzie","Garrett","Isham","Johnson","Larry","Logan","Merrill","Mont","Oren","Pierre","Rex","Rodney","Ted","Webster","West","Wheeler","Willam","Al","Aloysius","Alvie","Anna","Art","Augustine","Bailey","Benjaman","Beverly","Bishop","Clair","Cloyd","Coleman","Dana","Duncan","Dwight","Emile","Evert","Henderson","Hunter","Jean","Lem","Luis","Mathias","Maynard","Miguel","Mortimer","Nels","Norris","Pat","Phil","Rush","Santiago","Sol","Sydney","Thaddeus","Thornton","Tim","Travis","Truman","Watson","Webb","Wellington","Winfred","Wylie","Alec","Basil","Baxter","Bertrand","Buford","Burr","Cleveland","Colonel","Dempsey","Early","Ellsworth","Fate","Finley","Gabe","Garland","Gerald","Herschel","Hezekiah","Justus","Lindsey","Marcellus","Olaf","Olin","Pablo","Rolland","Turner","Verne","Volney","Williams","Almon","Alois","Alonza","Anson","Authur","Benton","Billie","Cornelious","Darius","Denis","Dillard","Doctor","Elvin","Emma","Eric","Evans","Gideon","Haywood","Hilliard","Hosea","Lincoln","Lonzo","Lucious","Lum","Malachi","Newt","Noel","Orie","Palmer","Pinkney","Shirley","Sumner","Terry","Urban","Uriah","Valentine","Waldo","Warner","Wong","Zeb","Abel","Alden","Archer","Avery","Carson","Cullen","Doc","Eben","Elige","Elizabeth","Elmore","Ernst","Finis","Freddie","Godfrey","Guss","Hamp","Hermann","Isadore","Isreal","Jones","June","Lacy","Lafe","Leland","Llewellyn","Ludwig","Manford","Maxwell","Minnie","Obie","Octave","Orrin","Ossie","Oswald","Park","Parley","Ramon","Rice","Stonewall","Theo","Tillman","Addie","Aron","Ashley","Bernhard","Bertie","Berton","Buster","Butler","Carleton","Carrie","Clara","Clarance","Clare","Crawford","Danial","Dayton","Dolphus","Elder","Ephriam","Fayette","Felipe","Fernando","Flem","Florence","Ford","Harlan","Hayes","Henery","Hoy","Huston","Ida","Ivory","Jonah","Justin","Lenard","Leopold","Lionel","Manley","Marquis","Marshal","Mart","Odie","Olen","Oral","Orley","Otha","Press","Price","Quincy","Randall","Rich","Richmond","Romeo","Russel","Rutherford","Shade","Shelby","Solon","Thurman","Tilden","Troy","Woodson","Worth","Aden","Alcide","Alf","Algie","Arlie","Bart","Bedford","Benito","Billy","Bird","Birt","Bruno","Burley","Chancy","Claus","Cliff","Clovis","Connie","Creed","Delos","Duke","Eber","Eligah","Elliot","Elton","Emmitt","Gene","Golden","Hal","Hardin","Harman","Hervey","Hollis","Ivey","Jennie","Len","Lindsay","Lonie","Lyle","Mac","Mal","Math","Miller","Orson","Osborne","Percival","Pleas","Ples","Rafael","Raoul","Roderick","Rose","Shelton","Sid","Theron","Tobias","Toney","Tyler","Vance","Vivian","Walton","Watt","Weaver","Wilton","Adolf","Albin","Albion","Allison","Alpha","Alpheus","Anastacio","Andre","Annie","Arlington","Armand","Asberry","Asbury","Asher","Augustin","Auther","Author","Ballard","Blas","Caesar","Candido","Cato","Clarke","Clemente","Colin","Commodore","Cora","Coy","Cruz","Curt","Damon","Davie","Delmar","Dexter","Dora","Doss","Drew","Edson","Elam","Elihu","Eliza","Elsie","Erie","Ernie","Ethel","Ferd","Friend","Garry","Gary","Grace","Gustaf","Hallie","Hampton","Harrie","Hattie","Hence","Hillard","Hollie","Holmes","Hope","Hyman","Ishmael","Jarrett","Jessee","Joeseph","Junious","Kirk","Levy","Mervin","Michel","Milford","Mitchel","Nellie","Noble","Obed","Oda","Orren","Ottis","Rafe","Redden","Reese","Rube","Ruby","Rupert","Salomon","Sammie","Sanders","Soloman","Stacy","Stanford","Stanton","Thad","Titus","Tracy","Vernie","Wendell","Wilhelm","Willian","Yee","Zeke","Ab","Abbott","Agustus","Albertus","Almer","Alphonso","Alvia","Artie","Arvid","Ashby","Augusta","Aurthur","Babe","Baldwin","Barnett","Bartholomew","Barton","Bernie","Blaine","Boston","Brad","Bradford","Bradley","Brooks","Buck","Budd","Ceylon","Chalmers","Chesley","Chin","Cleo","Crockett","Cyril","Daisy","Denver","Dow","Duff","Edie","Edith","Elick","Elie","Eliga","Eliseo","Elroy","Ely","Ennis","Enrique","Erasmus","Esau","Everette","Firman","Fleming","Flora","Gardner","Gee","Gorge","Gottlieb","Gregorio","Gregory","Gustavus","Halsey","Handy","Hardie","Harl","Hayden","Hays","Hermon","Hershel","Holly","Hosteen","Hoyt","Hudson","Huey","Humphrey","Hunt","Hyrum","Irven","Isam","Ivy","Jabez","Jewel","Jodie","Judd","Julious","Justice","Katherine","Kelly","Kit","Knute","Lavern","Lawyer","Layton","Leonidas","Lewie","Lillie","Linwood","Loran","Lorin","Mace","Malcom","Manly","Manson","Matthias","Mattie","Merida","Miner","Montgomery","Moroni","Murdock","Myrtle","Nate","Nathanial","Nimrod","Nora","Norval","Nova","Orion","Orla","Orrie","Payton","Philo","Phineas","Presley","Ransom","Reece","Rene","Roswell","Bulah","Caddie","Celie","Charlotta","Clair","Concepcion","Cordella","Corrine","Delila","Delphine","Dosha","Edgar","Elaine","Elisa","Ellar","Elmire","Elvina","Ena","Estie","Etter","Fronnie","Genie","Georgina","Glenn","Gracia","Guadalupe","Gwendolyn","Hassie","Honora","Icy","Isa","Isadora","Jesse","Jewel","Joe","Johannah","Juana","Judith","Judy","Junie","Lavonia","Lella","Lemma","Letty","Linna","Littie","Lollie","Lorene","Louis","Love","Lovisa","Lucina","Lynn","Madora","Mahalia","Manervia","Manuela","Margarett","Margaretta","Margarita","Marilla","Mignon","Mozella","Natalie","Nelia","Nolie","Omie","Opal","Ossie","Ottie","Ottilia","Parthenia","Penelope","Pinkey","Pollie","Rennie","Reta","Roena","Rosalee","Roseanna","Ruthie","Sabra","Sannie","Selena","Sibyl","Tella","Tempie","Tennessee","Teressa","Texas","Theda","Thelma","Thursa","Ula","Vannie","Verona","Vertie","Wilma","Mary","Anna","Emma","Elizabeth","Margaret","Minnie","Ida","Annie","Bertha","Alice","Clara","Sarah","Ella","Nellie","Grace","Florence","Martha","Cora","Laura","Carrie","Maude","Bessie","Mabel","Gertrude","Ethel","Jennie","Edith","Hattie","Mattie","Julia","Rose","Lillian","Lillie","Eva","Jessie","Lula","Myrtle","Pearl","Edna","Catherine","Ada","Louise","Helen","Lucy","Frances","Dora","Fannie","Josephine","Daisy","Lena","Maggie","Katherine","Rosa","Marie","Nora","Effie","Blanche","May","Nancy","Della","Agnes","Nettie","Sallie","Stella","Ellen","Mamie","Lizzie","Susie","Sadie","Elsie","Maud","Flora","Caroline","Etta","Mae","Lulu","Lydia"
    };


    private string[] surnames = new string[] {
    "Smith","Johnson","Williams","Brown","Jones","Miller","Davis","Garcia","Rodriguez","Wilson","Martinez","Anderson","Taylor","Thomas","Hernandez","Moore","Martin","Jackson","Thompson","White","Lopez","Lee","Gonzalez","Harris","Clark","Lewis","Robinson","Walker","Perez","Hall","Young","Allen","Sanchez","Wright","King","Scott","Green","Baker","Adams","Nelson","Hill","Ramirez","Campbell","Mitchell","Roberts","Carter","Phillips","Evans","Turner","Torres","Parker","Collins","Edwards","Stewart","Flores","Morris","Nguyen","Murphy","Rivera","Cook","Rogers","Morgan","Peterson","Cooper","Reed","Bailey","Bell","Gomez","Kelly","Howard","Ward","Cox","Diaz","Richardson","Wood","Watson","Brooks","Bennett","Gray","James","Reyes","Cruz","Hughes","Price","Myers","Long","Foster","Sanders","Ross","Morales","Powell","Sullivan","Russell","Ortiz","Jenkins","Gutierrez","Perry","Butler","Barnes","Fisher","Henderson","Coleman","Simmons","Patterson","Jordan","Reynolds","Hamilton","Graham","Kim","Gonzales","Alexander","Ramos","Wallace","Griffin","West","Cole","Hayes","Chavez","Gibson","Bryant","Ellis","Stevens","Murray","Ford","Marshall","Owens","Mcdonald","Harrison","Ruiz","Kennedy","Wells","Alvarez","Woods","Mendoza","Castillo","Olson","Webb","Washington","Tucker","Freeman","Burns","Henry","Vasquez","Snyder","Simpson","Crawford","Jimenez","Porter","Mason","Shaw","Gordon","Wagner","Hunter","Romero","Hicks","Dixon","Hunt","Palmer","Robertson","Black","Holmes","Stone","Meyer","Boyd","Mills","Warren","Fox","Rose","Rice","Moreno","Schmidt","Patel","Ferguson","Nichols","Herrera","Medina","Ryan","Fernandez","Weaver","Daniels","Stephens","Gardner","Payne","Kelley","Dunn","Pierce","Arnold","Tran","Spencer","Peters","Hawkins","Grant","Hansen","Castro","Hoffman","Hart","Elliott","Cunningham","Knight","Bradley","Carroll","Hudson","Duncan","Armstrong","Berry","Andrews","Johnston","Ray","Lane","Riley","Carpenter","Perkins","Aguilar","Silva","Richards","Willis","Matthews","Chapman","Lawrence","Garza","Vargas","Watkins","Wheeler","Larson","Carlson","Harper","George","Greene","Burke","Guzman","Morrison","Munoz","Jacobs","Obrien","Lawson","Franklin","Lynch","Bishop","Carr","Salazar","Austin","Mendez","Gilbert","Jensen","Williamson","Montgomery","Harvey","Oliver","Howell","Dean","Hanson","Weber","Garrett","Sims","Burton","Fuller","Soto","Mccoy","Welch","Chen","Schultz","Walters","Reid","Fields","Walsh","Little","Fowler","Bowman","Davidson","May","Day","Schneider","Newman","Brewer","Lucas","Holland","Wong","Banks","Santos","Curtis","Pearson","Delgado","Valdez","Pena","Rios","Douglas","Sandoval","Barrett","Hopkins","Keller","Guerrero","Stanley","Bates","Alvarado","Beck","Ortega","Wade","Estrada","Contreras","Barnett","Caldwell","Santiago","Lambert","Powers","Chambers","Nunez","Craig","Leonard","Lowe","Rhodes","Byrd","Gregory","Shelton","Frazier","Becker","Maldonado","Fleming","Vega","Sutton","Cohen","Jennings","Parks","Mcdaniel","Watts","Barker","Norris","Vaughn","Vazquez","Holt","Schwartz","Steele","Benson","Neal","Dominguez","Horton","Terry","Wolfe","Hale","Lyons","Graves","Haynes","Miles","Park","Warner","Padilla","Bush","Thornton","Mccarthy","Mann","Zimmerman","Erickson","Fletcher","Mckinney","Page","Dawson","Joseph","Marquez","Reeves","Klein","Espinoza","Baldwin","Moran","Love","Robbins","Higgins","Ball","Cortez","Le","Griffith","Bowen","Sharp","Cummings","Ramsey","Hardy","Swanson","Barber","Acosta","Luna","Chandler","Blair","Daniel","Cross","Simon","Dennis","Oconnor","Quinn","Gross","Navarro","Moss","Fitzgerald","Doyle","Mclaughlin","Rojas","Rodgers","Stevenson","Singh","Yang","Figueroa","Harmon","Newton","Paul","Manning","Garner","Mcgee","Reese","Francis","Burgess","Adkins","Goodman","Curry","Brady","Christensen","Potter","Walton","Goodwin","Mullins","Molina","Webster","Fischer","Campos","Avila","Sherman","Todd","Chang","Blake","Malone","Wolf","Hodges","Juarez","Gill","Farmer","Hines","Gallagher","Duran","Hubbard","Cannon","Miranda","Wang","Saunders","Tate","Mack","Hammond","Carrillo","Townsend","Wise","Ingram","Barton","Mejia","Ayala","Schroeder","Hampton","Rowe","Parsons","Frank","Waters","Strickland","Osborne","Maxwell","Chan","Deleon","Norman","Harrington","Casey","Patton","Logan","Bowers","Mueller","Glover","Floyd","Hartman","Buchanan","Cobb","French","Kramer","Mccormick","Clarke","Tyler","Gibbs","Moody","Conner","Sparks","Mcguire","Leon","Bauer","Norton","Pope","Flynn","Hogan","Robles","Salinas","Yates","Lindsey","Lloyd","Marsh","Mcbride","Owen","Solis","Pham","Lang","Pratt","Lara","Brock","Ballard","Trujillo","Shaffer","Drake","Roman","Aguirre","Morton","Stokes","Lamb","Pacheco","Patrick","Cochran","Shepherd","Cain","Burnett","Hess","Li","Cervantes","Olsen","Briggs","Ochoa","Cabrera","Velasquez","Montoya","Roth","Meyers","Cardenas","Fuentes","Weiss","Hoover","Wilkins","Nicholson","Underwood","Short","Carson","Morrow","Colon","Holloway","Summers","Bryan","Petersen","Mckenzie","Serrano","Wilcox","Carey","Clayton","Poole","Calderon","Gallegos","Greer","Rivas","Guerra","Decker","Collier","Wall","Whitaker","Bass","Flowers","Davenport","Conley","Houston","Huff","Copeland","Hood","Monroe","Massey","Roberson","Combs","Franco","Larsen","Pittman","Randall","Skinner","Wilkinson","Kirby","Cameron","Bridges","Anthony","Richard","Kirk","Bruce","Singleton","Mathis","Bradford","Boone","Abbott","Charles","Allison","Sweeney","Atkinson","Horn","Jefferson","Rosales","York","Christian","Phelps","Farrell","Castaneda","Nash","Dickerson","Bond","Wyatt","Foley","Chase","Gates","Vincent","Mathews","Hodge","Garrison","Trevino","Villarreal","Heath","Dalton","Valencia","Callahan","Hensley","Atkins","Huffman","Roy","Boyer","Shields","Lin","Hancock","Grimes","Glenn","Cline","Delacruz","Camacho","Dillon","Parrish","Oneill","Melton","Booth","Kane","Berg","Harrell","Pitts","Savage","Wiggins","Brennan","Salas","Marks","Russo","Sawyer","Baxter","Golden","Hutchinson","Liu","Walter","Mcdowell","Wiley","Rich","Humphrey","Johns","Koch","Suarez","Hobbs","Beard","Gilmore","Ibarra","Keith","Macias","Khan","Andrade","Ware","Stephenson","Henson","Wilkerson","Dyer","Mcclure","Blackwell","Mercado","Tanner","Eaton","Clay","Barron","Beasley","Oneal","Preston","Small","Wu","Zamora","Macdonald","Vance","Snow","Mcclain","Stafford","Orozco","Barry","English","Shannon","Kline","Jacobson","Woodard","Huang","Kemp","Mosley","Prince","Merritt","Hurst","Villanueva","Roach","Nolan","Lam","Yoder","Mccullough","Lester","Santana","Valenzuela","Winters","Barrera","Leach","Orr","Berger","Mckee","Strong","Conway","Stein","Whitehead","Bullock","Escobar","Knox","Meadows","Solomon","Velez","Odonnell","Kerr","Stout","Blankenship","Browning","Kent","Lozano","Bartlett","Pruitt","Buck","Barr","Gaines","Durham","Gentry","Mcintyre","Sloan","Melendez","Rocha","Herman","Sexton","Moon","Hendricks","Rangel","Stark","Lowery","Hardin","Hull","Sellers","Ellison","Calhoun","Gillespie","Mora","Knapp","Mccall","Morse","Dorsey","Weeks","Nielsen","Livingston","Leblanc","Mclean","Bradshaw","Glass","Middleton","Buckley","Schaefer","Frost","Howe","House","Mcintosh","Ho","Pennington","Reilly","Hebert","Mcfarland","Hickman","Noble","Spears","Conrad","Arias","Galvan","Velazquez","Huynh","Frederick","Randolph","Cantu","Fitzpatrick","Mahoney","Peck","Villa","Michael","Donovan","Mcconnell","Walls","Boyle","Mayer","Zuniga","Giles","Pineda","Pace","Hurley","Mays","Mcmillan","Crosby","Ayers","Case","Bentley","Shepard","Everett","Pugh","David","Mcmahon","Dunlap","Bender","Hahn","Harding","Acevedo","Raymond","Blackburn","Duffy","Landry","Dougherty","Bautista","Shah","Potts","Arroyo","Valentine","Meza","Gould","Vaughan","Fry","Rush","Avery","Herring","Dodson","Clements","Sampson","Tapia","Bean","Lynn","Crane","Farley","Cisneros","Benton","Ashley","Mckay","Finley","Best","Blevins","Friedman","Moses","Sosa","Blanchard","Huber","Frye","Krueger","Bernard","Rosario","Rubio","Mullen","Benjamin","Haley","Chung","Moyer","Choi","Horne","Yu","Woodward","Ali","Nixon","Hayden","Rivers","Estes","Mccarty","Richmond","Stuart","Maynard","Brandt","Oconnell","Hanna","Sanford","Sheppard","Church","Burch","Levy","Rasmussen","Coffey","Ponce","Faulkner","Donaldson","Schmitt","Novak"
    };

    private string[] dognames = new string[]
    {
        "Bella", "Lucy", "Daisy", "Molly", "Lola", "Sophie", "Sadie", "Maggie", "Chloe", "Bailey", "Roxy", "Zoey", "Lily", "Luna", "Coco", "Stella", "Gracie", "Abby", "Penny", "Zoe", "Ginger", "Ruby", "Rosie", "Lilly", "Ellie", "Mia", "Sasha", "Lulu", "Pepper", "Nala", "Lexi", "Lady", "Emma", "Riley", "Dixie", "Annie", "Maddie", "Piper", "Princess", "Izzy", "Maya", "Olive", "Cookie", "Roxie", "Angel", "Belle", "Layla", "Missy", "Cali", "Honey", "Millie", "Harley", "Marley", "Holly", "Kona", "Shelby", "Jasmine", "Ella", "Charlie", "Minnie", "Willow", "Phoebe", "Callie", "Scout", "Katie", "Dakota", "Sugar", "Sandy", "Josie", "Macy", "Trixie", "Winnie", "Peanut", "Mimi", "Hazel", "Mocha", "Cleo", "Hannah", "Athena", "Lacey", "Sassy", "Lucky", "Bonnie", "Allie", "Brandy", "Sydney", "Casey", "Gigi", "Baby", "Madison", "Heidi", "Sally", "Shadow", "Cocoa", "Pebbles", "Misty", "Nikki", "Lexie", "Grace", "Sierra", "Max", "Buddy", "Charlie", "Jack", "Cooper", "Rocky", "Toby", "Tucker", "Jake", "Bear", "Duke", "Teddy", "Oliver", "Riley", "Bailey", "Bentley", "Milo", "Buster", "Cody", "Dexter", "Winston", "Murphy", "Leo", "Lucky", "Oscar", "Louie", "Zeus", "Henry", "Sam", "Harley", "Baxter", "Gus", "Sammy", "Jackson", "Bruno", "Diesel", "Jax", "Gizmo", "Bandit", "Rusty", "Marley", "Jasper", "Brody", "Roscoe", "Hank", "Otis", "Bo", "Joey", "Beau", "Ollie", "Tank", "Shadow", "Peanut", "Hunter", "Scout", "Blue", "Rocco", "Simba", "Tyson", "Ziggy", "Boomer", "Romeo", "Apollo", "Ace", "Luke", "Rex", "Finn", "Chance", "Rudy", "Loki", "Moose", "George", "Samson", "Coco", "Benny", "Thor", "Rufus", "Prince", "Chester", "Brutus", "Scooter", "Chico", "Spike", "Gunner", "Sparky", "Mickey", "Kobe", "Chase", "Oreo", "Frankie", "Mac", "Benji", "Bubba", "Champ", "Brady", "Elvis", "Copper", "Cash", "Archie", "Walter"
    };

    public string[] NamesArr { get { return names; } }
    public string[] SurnamesArr { get { return surnames; } }
    public string[] DogNamesArr { get { return dognames; } }



}
