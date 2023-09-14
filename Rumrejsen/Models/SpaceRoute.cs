namespace Rumrejsen.Models
{
    public class SpaceRoute
    {
        public string Name { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public List<String> NavigationPoints { get; set; }
        public string Duration { get; set; }
        public List<String> Dangers { get; set; }
        public string FuelUsage { get; set; }
        public string Description { get; set; }

        public List<SpaceRoute> GetCaptainRoutes()
        {
            List<SpaceRoute> routes = new List<SpaceRoute>
            {
                new SpaceRoute
                {
                    Name = "Jordens Pendulfart",
                    Start = "Jorden",
                    End = "Månens basis",
                    NavigationPoints = new List<string> { "ISS Rumstation", "Armstrong Krater" },
                    Duration = "3 dage",
                    Dangers = new List<string> { "Satellit skrot", "mikrometeoroider" },
                    FuelUsage = "Moderat",
                    Description = "Denne rute er en grundlæggende forbindelse mellem Jorden og Månens forskningsbaser."
                },
                new SpaceRoute
                {
                    Name = "Mars Expressen",
                    Start = "Jorden",
                    End = "Mars",
                    NavigationPoints = new List<string> { "Asteroidbæltet", "Phobos", "Deimos" },
                    Duration = "6-8 måneder",
                    Dangers = new List<string> { "Solstorme", "asteroider" },
                    FuelUsage = "Højt",
                    Description = "En primær rute for dem, der søger efter nye eventyr på Den Røde Planet."
                },
                new SpaceRoute
                {
                    Name = "Voyager's Passage",
                    Start = "Saturn",
                    End = "Uden for Solsystemet",
                    NavigationPoints = new List<string> { "Titan", "Kuiper-bæltet", "Oort Sky" },
                    Duration = "40 år",
                    Dangers = new List<string> { "Ukendt! Mange områder er endnu ikke fuldt udforsket." },
                    FuelUsage = "Ekstremt højt",
                    Description = "For de sande opdagelsesrejsende! Følg i fodsporene på de tidlige rumsonder."
                },
                new SpaceRoute
                {
                    Name = "Neptuns Nætter",
                    Start = "Jupiter",
                    End = "Neptun",
                    NavigationPoints = new List<string> { "Europa", "Uranus" },
                    Duration = "3 år",
                    Dangers = new List<string> { "Gasgigantens strålingsbælter", "isgejsere fra Europa" },
                    FuelUsage = "Højt",
                    Description = "En betagende rute gennem de ydre gasgiganter."
                },
                new SpaceRoute
                {
                    Name = "Andromedas Port",
                    Start = "Uden for Solsystemet",
                    End = "Andromeda Galaksen",
                    NavigationPoints = new List<string> { "Proxima Centauri", "Interstellar Medium", "Messier 31 Kerne" },
                    Duration = "10 år",
                    Dangers = new List<string> { "Ukendt rummateriale", "sorte huller", "intergalaktisk stråling" },
                    FuelUsage = "Uendelig",
                    Description = "Kun for de mest avancerede og eventyrlystne piloter. Gennemse stjernerne til vores nærmeste galaktiske nabo."
                },
                new SpaceRoute
                {
                    Name = "Orions Odyssey",
                    Start = "Jorden",
                    End = "Betelgeuse",
                    NavigationPoints = new List<string> { "Rigel", "Orions Bælte", "Den Røde Superkæmpe Zone" },
                    Duration = "5 år",
                    Dangers = new List<string> { "Supernova risiko", "stjernevind fra massive stjerner", "interstellart støv" },
                    FuelUsage = "Massivt",
                    Description = "Denne rute er for dem, der ønsker at opleve skønheden ved en af universets mest kendte konstellationer oppefra og tæt på."
                },
                new SpaceRoute
                {
                    Name = "Galaktiske Havne Rundtur",
                    Start = "Mælkevejens centrum",
                    End = "Mælkevejens centrum",
                    NavigationPoints = new List<string> { "Sagittarius A*", "Carina Arm", "Cygnus Arm", "Perseus Arm" },
                    Duration = "10 år",
                    Dangers = new List<string> { "Stjernetætheder i centrale regioner", "gravitationsfælder fra det supermassive sorte hul" },
                    FuelUsage = "Højt",
                    Description = "En storslået rundtur i vores egen galakse, hvor rejsende kan opleve dens mange vidundere."
                },
                new SpaceRoute
                {
                    Name = "Kosmisk Kystline",
                    Start = "Plutos bane",
                    End = "Den yderste kant af Kuiper-bæltet",
                    NavigationPoints = new List<string> { "Haumea", "Eris", "Sedna" },
                    Duration = "10 år",
                    Dangers = new List<string> { "Uforudsete asteroider", "ekstreme temperaturer", "ukendt rummateriale" },
                    FuelUsage = "Moderat til lav",
                    Description = "En fortryllende rejse gennem Solsystemets kolde og mystiske ydre regioner, hvor få rumskibe har vovet sig."
                }
            };
            return routes;
        }

        public List<SpaceRoute> GetCadetRoutes()
        {
            List<SpaceRoute> routes = new List<SpaceRoute>
            {
                new SpaceRoute
                {
                    Name = "Jordens Pendulfart",
                    Start = "Jorden",
                    End = "Månens basis",
                    NavigationPoints = new List<string> { "ISS Rumstation", "Armstrong Krater" },
                    Duration = "3 dage",
                    Dangers = new List<string> { "Satellit skrot", "mikrometeoroider" },
                    FuelUsage = "Moderat",
                    Description = "Denne rute er en grundlæggende forbindelse mellem Jorden og Månens forskningsbaser."
                },
                new SpaceRoute
                {
                    Name = "Mars Expressen",
                    Start = "Jorden",
                    End = "Mars",
                    NavigationPoints = new List<string> { "Asteroidbæltet", "Phobos", "Deimos" },
                    Duration = "6-8 måneder",
                    Dangers = new List<string> { "Solstorme", "asteroider" },
                    FuelUsage = "Højt",
                    Description = "En primær rute for dem, der søger efter nye eventyr på Den Røde Planet."
                }
            };
            return routes;
        }
    }
}
