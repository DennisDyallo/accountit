
using Taxana.Backend.Models;

namespace Taxana.Backend.Infrastructure;

public static class DbAccountInit
{
    public static List<Account> GetBaseAccounts()
    {
        var accounts = new List<Account>();

        // Add 1xxx accounts (Immateriella anläggningstillgångar)
        accounts.AddRange(
        [
            new("1010", "Utvecklingsutgifter"),
            new("1011", "Balanserade utgifter utveckling"),
            new("1012", "Balanserade utgifter för programvaror"),
            new("1018", "Ackumulerade nedskrivningar på balanserade utgifter"),
            new("1019", "Ackumulerade avskrivningar på balanserade utgifter"),
            new("1020", "Koncessioner m.m."),
            new("1028", "Ackumulerade nedskrivningar på koncessioner m.m."),
            new("1029", "Ackumulerade avskrivningar på koncessioner m.m."),
            new("1030", "Patent"),
            new("1038", "Ackumulerade nedskrivningar på patent"),
            new("1039", "Ackumulerade avskrivningar på patent"),
            new("1040", "Licenser"),
            new("1048", "Ackumulerade nedskrivningar på licenser"),
            new("1049", "Ackumulerade avskrivningar på licenser"),
            new("1050", "Varumärken"),
            new("1058", "Ackumulerade nedskrivningar på varumärken"),
            new("1059", "Ackumulerade avskrivningar på varumärken"),
            new("1060", "Hyresrätter, tomträtter och liknande"),
            new("1068", "Ackumulerade nedskrivningar på hyresrätter, tomträtter och liknande"),
            new("1069", "Ackumulerade avskrivningar på hyresrätter, tomträtter och liknande"),
            new("1070", "Goodwill"),
            new("1078", "Ackumulerade nedskrivningar på goodwill"),
            new("1079", "Ackumulerade avskrivningar på goodwill"),
            new("1080", "Förskott för immateriella anläggningstillgångar"),
            new("1081", "Pågående projekt för immateriella anläggningstillgångar"),
            new("1088", "Förskott för immateriella anläggningstillgångar"),
        ]);

        // Add 2xxx accounts
        accounts.AddRange(
        [
            // 20 Eget kapital
            new("2010", "Eget kapital, delägare 1"),
            new("2011", "Egna varuuttag"),
            new("2013", "Övriga egna uttag"),
            new("2017", "Årets kapitaltillskott"),
            new("2018", "Övriga egna insättningar"),
            new("2019", "Årets resultat, delägare 1"),
            new("2020", "Eget kapital, delägare 2"),
            new("2030", "Eget kapital, delägare 3"),
            new("2040", "Eget kapital, delägare 4"),
            new("2050", "Avsättning till expansionsfond"),
            
            // Eget kapital i ideella föreningar och stiftelser
            new("2060", "Eget kapital i ideella föreningar stiftelser och registrerade trossamfund"),
            new("2061", "Eget kapital/stiftelsekapital/grundkapital"),
            new("2065", "Förändring i fond för verkligt värde"),
            new("2066", "Värdesäkringsfond"),
            new("2067", "Balanserad vinst eller förlust/balanserat kapital"),
            new("2068", "Vinst eller förlust från föregående år"),
            new("2069", "Årets resultat"),
            new("2070", "Ändamålsbestämda medel"),
            new("2071", "Ändamål 1"),
            new("2072", "Ändamål 2"),

            // Eget kapital i aktiebolag och ekonomiska föreningar
            new("2080", "Bundet eget kapital"),
            new("2081", "Aktiekapital"),
            new("2082", "Ej registrerat aktiekapital"),
            new("2083", "Medlemsinsatser"),
            new("2084", "Förlagsinsatser"),
            new("2085", "Uppskrivningsfond"),
            new("2086", "Reservfond"),
            new("2087", "Insatsemission/Bunden överkursfond"),
            new("2088", "Fond för yttre underhåll"),
            new("2089", "Fond för utvecklingsutgifter"),
            new("2090", "Fritt eget kapital"),
            new("2091", "Balanserad vinst eller förlust"),
            new("2092", "Mottagna/lämnade koncernbidrag"),
            new("2093", "Erhållna aktieägartillskott"),
            new("2094", "Egna aktier"),
            new("2095", "Fusionsresultat"),
            new("2096", "Fond för verkligt värde"),
            new("2097", "Fri överkursfond"),
            new("2098", "Vinst eller förlust från föregående år"),
            new("2099", "Årets resultat"),

            // Moms accounts - Most of these should be VAT eligible
            new("2610", "Utgående moms, 25%", true),
            new("2611", "Utgående moms på försäljning inom Sverige, 25%", true),
            new("2612", "Utgående moms på egna uttag, 25%", true),
            new("2613", "Utgående moms för uthyrning, 25%", true),
            new("2614", "Utgående moms, omvänd skattskyldighet, 25%", true),
            new("2615", "Utgående moms, import av varor, 25%", true),
            new("2640", "Ingående moms", true),
            new("2641", "Debiterad ingående moms", true),
            new("2645", "Beräknad ingående moms på förvärv från utlandet", true),
            new("2650", "Redovisningskonto för moms", true),
        ]);

        // Add 3xxx accounts (Revenue accounts)
        accounts.AddRange(
        [
            // 30-34 Main revenue
            new("3000", "Försäljning inom Sverige"),
            new("3001", "Försäljning inom Sverige, 25 % moms", true),
            new("3002", "Försäljning inom Sverige, 12 % moms", true),
            new("3003", "Försäljning inom Sverige, 6 % moms", true),
            new("3004", "Försäljning inom Sverige, momsfri"),
            new("3100", "Försäljning av varor utanför Sverige"),
            new("3105", "Försäljning varor till land utanför EU"),
            new("3106", "Försäljning varor till annat EU-land, momspliktig", true),
            new("3108", "Försäljning varor till annat EU-land, momsfri"),
            new("3200", "Försäljning VMB och omvänd moms"),
            new("3211", "Försäljning positiv VMB 25 %", true),
            new("3212", "Försäljning negativ VMB 25 %", true),
            new("3231", "Försäljning inom byggsektorn, omvänd skattskyldighet moms"),
            new("3300", "Försäljning av tjänster utanför Sverige"),
            new("3305", "Försäljning tjänster till land utanför EU"),
            new("3400", "Försäljning, egna uttag"),
            new("3401", "Egna uttag momspliktiga, 25 %", true),
            new("3402", "Egna uttag momspliktiga, 12 %", true),
            new("3403", "Egna uttag momspliktiga, 6 %", true),
            new("3404", "Egna uttag, momsfria"),

            // 35 Invoiced costs
            new("3500", "Fakturerade kostnader"),
            new("3510", "Fakturerat emballage"),
            new("3511", "Fakturerat emballage"),
            new("3518", "Returnerat emballage"),
            new("3520", "Fakturerade frakter"),
            new("3521", "Fakturerade frakter, EU-land"),
            new("3522", "Fakturerade frakter, export"),
            new("3530", "Fakturerade tull- och speditionskostnader m.m."),
            new("3540", "Faktureringsavgifter"),
            new("3550", "Fakturerade resekostnader"),
            new("3560", "Fakturerade kostnader till koncernföretag"),
            new("3590", "Övriga fakturerade kostnader"),

            // 36 Secondary revenue
            new("3600", "Rörelsens sidointäkter"),
            new("3610", "Försäljning av material"),
            new("3670", "Intäkter från värdepapper"),
            new("3680", "Management fees"),
            new("3690", "Övriga sidointäkter"),

            // 37 Revenue adjustments
            new("3700", "Intäktskorrigeringar"),
            new("3730", "Lämnade rabatter"),
            new("3740", "Öres- och kronutjämning"),
            new("3750", "Punktskatter"),

            // 38 Activated work
            new("3800", "Aktiverat arbete för egen räkning"),
            new("3840", "Aktiverat arbete (material)"),
            new("3850", "Aktiverat arbete (omkostnader)"),
            new("3870", "Aktiverat arbete (personal)"),

            // 39 Other operating revenue
            new("3900", "Övriga rörelseintäkter"),
            new("3910", "Hyres- och arrendeintäkter"),
            new("3911", "Hyresintäkter"),
            new("3913", "Frivilligt momspliktiga hyresintäkter", true),
            new("3920", "Provisionsintäkter, licensintäkter och royalties"),
            new("3960", "Valutakursvinster på fordringar och skulder av rörelsekaraktär"),
            new("3970", "Vinst vid avyttring av immateriella och materiella anläggningstillgångar"),
            new("3980", "Erhållna offentliga bidrag"),
            new("3990", "Övriga ersättningar, bidrag och intäkter"),
            new("3999", "Övriga rörelseintäkter")
        ]);

        // Add 4xxx accounts (Costs for goods and materials)
        accounts.AddRange(
        [
            // 40-45 Purchase of goods and materials
            new("4000", "Inköp av varor från Sverige", true),
            new("4200", "Sålda varor VMB"),
            new("4211", "Sålda varor positiv VMB 25 %", true),
            new("4212", "Sålda varor negativ VMB 25 %", true),
            new("4400", "Momspliktiga inköp i Sverige", true),
            new("4415", "Inköpta varor i Sverige, omvänd skattskyldighet, 25 %", true),
            new("4416", "Inköpta varor i Sverige, omvänd skattskyldighet, 12 %", true),
            new("4417", "Inköpta varor i Sverige, omvänd skattskyldighet, 6 %", true),
            new("4425", "Inköpta tjänster i Sverige, omvänd skattskyldighet, 25 % moms", true),
            new("4426", "Inköpta tjänster i Sverige, omvänd skattskyldighet, 12 %", true),
            new("4427", "Inköpta tjänster i Sverige, omvänd skattskyldighet, 6 %", true),
            new("4500", "Övriga momspliktiga inköp", true),
            new("4515", "Inköp av varor från annat EU-land, 25 %", true),
            new("4516", "Inköp av varor från annat EU-land, 12 %", true),
            new("4517", "Inköp av varor från annat EU-land, 6 %", true),
            new("4518", "Inköp av varor från annat EU-land, momsfri"),
            new("4531", "Inköp av tjänster från ett land utanför EU, 25 %", true),
            new("4532", "Inköp av tjänster från ett land utanför EU, 12 %", true),
            new("4533", "Inköp av tjänster från ett land utanför EU, 6 %", true),
            new("4535", "Inköp av tjänster från annat EU-land, 25 %", true),
            new("4536", "Inköp av tjänster från annat EU-land, 12 %", true),
            new("4537", "Inköp av tjänster från annat EU-land, 6 %", true),
            new("4538", "Inköp av tjänster från annat EU-land, momsfri"),
            new("4545", "Import av varor, 25 %", true),
            new("4546", "Import av varor, 12 %", true),
            new("4547", "Import av varor, 6 %", true),

            // 46 Contract work and subcontractors
            new("4600", "Legoarbeten och underentreprenader"),

            // 47 Purchase price reductions
            new("4700", "Reduktion av inköpspriser"),
            new("4730", "Erhållna rabatter"),
            new("4731", "Erhållna kassarabatter"),
            new("4732", "Erhållna mängdrabatter (inkl. bonus)"),
            new("4733", "Erhållet aktivitetsstöd"),
            new("4790", "Övriga reduktioner av inköpspriser"),

            // 49 Changes in inventory and work in progress
            new("4900", "Förändring av lager"),
            new("4910", "Förändring av lager av råvaror"),
            new("4920", "Förändring av lager av tillsatsmaterial och förnödenheter"),
            new("4940", "Förändring av produkter i arbete"),
            new("4944", "Förändring av produkter i arbete, arbete material och utlägg"),
            new("4945", "Förändring av produkter i arbete, omkostnader"),
            new("4947", "Förändring av produkter i arbete, personalkostnader"),
            new("4950", "Förändring av lager av färdiga varor"),
            new("4960", "Förändring av lager av handelsvaror"),
            new("4970", "Förändring av pågående arbeten, nedlagda kostnader"),
            new("4974", "Förändring av pågående arbeten, material och utlägg"),
            new("4975", "Förändring av pågående arbeten, omkostnader"),
            new("4977", "Förändring av pågående arbeten, personalkostnader"),
            new("4980", "Förändring av lager av värdepapper"),
            new("4981", "Sålda värdepappers anskaffningsvärde"),
            new("4987", "Nedskrivning av värdepapper"),
            new("4988", "Återföring av nedskrivning av värdepapper")
        ]);

        // Add 5xxx-6xxx accounts (External operating expenses)
        accounts.AddRange(
        [   
            // 50 Premises costs
            new("5000", "Lokalkostnader"),
            new("5010", "Lokalhyra", true),
            new("5011", "Hyra för kontorslokaler", true),
            new("5012", "Hyra för garage", true),
            new("5013", "Hyra för lagerlokaler", true),
            new("5020", "El för belysning", true),
            new("5030", "Värme", true),
            new("5040", "Vatten och avlopp", true),
            new("5050", "Lokaltillbehör", true),
            new("5060", "Städning och renhållning", true),
            new("5070", "Reparation och underhåll av lokaler", true),
            new("5090", "Övriga lokalkostnader"),
            
            // 51 Property costs
            new("5100", "Fastighetskostnader"),
            new("5110", "Tomträttsavgäld/arrende", true),
            new("5120", "El för belysning", true),
            new("5130", "Värme", true),
            new("5140", "Vatten och avlopp", true),
            new("5170", "Reparation och underhåll av fastighet", true),
            new("5191", "Fastighetsskatt/fastighetsavgift"),
            new("5192", "Fastighetsförsäkringspremier"),
            
            // 52 Rental of fixed assets
            new("5200", "Hyra av anläggningstillgångar"),
            new("5210", "Hyra av maskiner och andra tekniska anläggningar", true),
            new("5220", "Hyra av inventarier och verktyg", true),
            new("5250", "Hyra av datorer", true),
            
            // 53 Energy costs
            new("5300", "Energikostnader"),
            new("5310", "El för drift", true),
            new("5320", "Gas", true),
            new("5330", "Eldningsolja", true),
            new("5360", "Bensin, fotogen och motorbrännolja", true),
            
            // 54 Consumables
            new("5400", "Förbrukningsinventarier och förbrukningsmaterial"),
            new("5410", "Förbrukningsinventarier", true),
            new("5420", "Programvaror", true),
            new("5460", "Förbrukningsmaterial", true),
            new("5480", "Arbetskläder och skyddsmaterial", true),
            
            // 55 Repairs and maintenance
            new("5500", "Reparation och underhåll"),
            new("5510", "Reparation och underhåll av maskiner", true),
            new("5520", "Reparation och underhåll av inventarier", true),
            
            // 56 Vehicle costs
            new("5600", "Kostnader för transportmedel"),
            new("5611", "Drivmedel för personbilar", true),
            new("5612", "Försäkring och skatt för personbilar"),
            new("5613", "Reparation och underhåll av personbilar", true),
            new("5615", "Leasing av personbilar", true),
            
            // 57 Freight and transport
            new("5700", "Frakter och transporter"),
            new("5710", "Frakter, transporter och försäkringar", true),
            new("5720", "Tull- och speditionskostnader", true),
            
            // 58 Travel expenses
            new("5800", "Resekostnader"),
            new("5810", "Biljetter", true),
            new("5820", "Hyrbilskostnader", true),
            new("5830", "Kost och logi", true),
            
            // 59 Advertising and PR
            new("5900", "Reklam och PR"),
            new("5910", "Annonsering", true),
            new("5930", "Reklamtrycksaker och direktreklam", true),
            new("5940", "Utställningar och mässor", true),
            
            // 60-69 Other external costs
            new("6000", "Övriga försäljningskostnader"),
            new("6040", "Kontokortsavgifter", true),
            new("6050", "Försäljningsprovisioner", true),
            new("6071", "Representation, avdragsgill", true),
            new("6072", "Representation, ej avdragsgill"),
            new("6110", "Kontorsmateriel", true),
            new("6210", "Telekommunikation", true),
            new("6310", "Företagsförsäkringar"),
            new("6420", "Ersättningar till revisor", true),
            new("6530", "Redovisningstjänster", true),
            new("6540", "IT-tjänster", true),
            new("6550", "Konsultarvoden", true),
            new("6800", "Inhyrd personal", true),
            new("6990", "Övriga externa kostnader"),
            new("6998", "Utländsk moms", true),
            new("6999", "Ingående moms, blandad verksamhet", true)
        ]);

        // Add 7xxx accounts (Personnel costs, depreciation, etc.)
        accounts.AddRange(
        [
            // 70 Wages for collective agreement employees
            new("7000", "Löner till kollektivanställda"),
            new("7010", "Löner till kollektivanställda"),
            new("7013", "Lön växa-stöd kollektivanställda 10,21 %"),
            new("7017", "Avgångsvederlag till kollektivanställda"),
            new("7018", "Bruttolöneavdrag, kollektivanställda"),
            new("7019", "Upplupna löner och vinstandelar till kollektivanställda"),
            new("7081", "Sjuklöner till kollektivanställda"),
            new("7082", "Semesterlöner till kollektivanställda"),
            new("7090", "Förändring av semesterlöneskuld"),

            // 72 Salaries for officials and management
            new("7200", "Löner till tjänstemän och företagsledare"),
            new("7210", "Löner till tjänstemän"),
            new("7213", "Lön Växa-stöd tjänstemän 10,21 %"),
            new("7220", "Löner till företagsledare"),
            new("7240", "Styrelsearvoden"),
            new("7285", "Semesterlöner till tjänstemän"),
            new("7286", "Semesterlöner till företagsledare"),

            // 73 Cost reimbursements and benefits
            new("7300", "Kostnadsersättningar och förmåner"),
            new("7321", "Skattefria traktamenten, Sverige"),
            new("7322", "Skattepliktiga traktamenten, Sverige"),
            new("7331", "Skattefria bilersättningar"),
            new("7332", "Skattepliktiga bilersättningar"),
            new("7381", "Kostnader för fri bostad"),
            new("7382", "Kostnader för fria eller subventionerade måltider"),
            new("7385", "Kostnader för fria eller subventionerade arbetskläder"),
            new("7389", "Övriga kostnader för förmåner"),

            // 74 Pension costs
            new("7400", "Pensionskostnader"),
            new("7411", "Premier för kollektiva pensionsförsäkringar"),
            new("7412", "Premier för individuella pensionsförsäkringar"),
            new("7420", "Förändring av pensionsskuld"),
            new("7460", "Pensionsutbetalningar"),
            new("7490", "Övriga pensionskostnader"),

            // 75 Social security and other statutory charges
            new("7510", "Arbetsgivaravgifter 31,42 %"),
            new("7511", "Arbetsgivaravgifter för löner och ersättningar"),
            new("7512", "Arbetsgivaravgifter för förmånsvärden"),
            new("7533", "Särskild löneskatt för pensionskostnader"),
            new("7570", "Premier för arbetsmarknadsförsäkringar"),
            new("7580", "Gruppförsäkringspremier"),

            // 76 Other personnel costs
            new("7600", "Övriga personalkostnader"),
            new("7610", "Utbildning"),
            new("7621", "Sjuk- och hälsovård, avdragsgill"),
            new("7622", "Sjuk- och hälsovård, ej avdragsgill"),
            new("7631", "Personalrepresentation, avdragsgill"),
            new("7632", "Personalrepresentation, ej avdragsgill"),
            new("7690", "Övriga personalkostnader"),

            // 77 Write-downs and reversal of write-downs
            new("7710", "Nedskrivningar av immateriella anläggningstillgångar"),
            new("7720", "Nedskrivningar av byggnader och mark"),
            new("7730", "Nedskrivningar av maskiner och inventarier"),
            new("7760", "Återföring av nedskrivningar av immateriella anläggningstillgångar"),

            // 78 Depreciation according to plan
            new("7810", "Avskrivningar på immateriella anläggningstillgångar"),
            new("7820", "Avskrivningar på byggnader och markanläggningar"),
            new("7830", "Avskrivningar på maskiner och inventarier"),
            new("7835", "Avskrivningar på datorer"),

            // 79 Other operating expenses
            new("7960", "Valutakursförluster på fordringar och skulder av rörelsekaraktär"),
            new("7970", "Förlust vid avyttring av immateriella och materiella anläggningstillgångar"),
            new("7990", "Övriga rörelsekostnader")
        ]);

        // Add 8xxx accounts (Financial income/expenses and year-end dispositions)
        accounts.AddRange(
        [
            // 80 Results from group companies
            new("8010", "Utdelning på andelar i koncernföretag"),
            new("8012", "Utdelning på andelar i dotterföretag"),
            new("8016", "Emissionsinsats, koncernföretag"),
            new("8020", "Resultat vid försäljning av andelar i koncernföretag"),
            new("8022", "Resultat vid försäljning av andelar i dotterföretag"),
            new("8070", "Nedskrivningar av andelar i och långfristiga fordringar hos koncernföretag"),
            new("8080", "Återföringar av nedskrivningar av andelar i och långfristiga fordringar hos koncernföretag"),

            // 81 Results from associated companies
            new("8110", "Utdelning på andelar i intresseföretag, gemensamt styrda företag och övriga företag"),
            new("8111", "Utdelningar på andelar i intresseföretag"),
            new("8120", "Resultat vid försäljning av andelar i intresseföretag"),
            new("8170", "Nedskrivningar av andelar i och långfristiga fordringar hos intresseföretag"),
            new("8180", "Återföringar av nedskrivningar av andelar i och långfristiga fordringar hos intresseföretag"),

            // 82 Results from other securities and long-term receivables
            new("8210", "Utdelningar på andelar i andra företag"),
            new("8220", "Resultat vid försäljning av värdepapper i och långfristiga fordringar"),
            new("8230", "Valutakursdifferenser på långfristiga fordringar"),
            new("8250", "Ränteintäkter från långfristiga fordringar"),
            new("8260", "Ränteintäkter från långfristiga fordringar hos koncernföretag"),
            new("8270", "Nedskrivningar av innehav av andelar i och långfristiga fordringar"),
            new("8280", "Återföringar av nedskrivningar av andelar i och långfristiga fordringar"),

            // 83 Other interest income and similar items
            new("8310", "Ränteintäkter från omsättningstillgångar"),
            new("8311", "Ränteintäkter från bank"),
            new("8312", "Ränteintäkter från kortfristiga placeringar"),
            new("8330", "Valutakursdifferenser på kortfristiga fordringar och placeringar"),
            new("8340", "Utdelningar på kortfristiga placeringar"),
            new("8350", "Resultat vid försäljning av kortfristiga placeringar"),
            new("8370", "Nedskrivningar av kortfristiga placeringar"),
            new("8380", "Återföringar av nedskrivningar av kortfristiga placeringar"),
            new("8390", "Övriga finansiella intäkter"),

            // 84 Interest expenses and similar items
            new("8400", "Räntekostnader"),
            new("8410", "Räntekostnader för långfristiga skulder"),
            new("8420", "Räntekostnader för kortfristiga skulder"),
            new("8430", "Valutakursdifferenser på skulder"),
            new("8460", "Räntekostnader till koncernföretag"),
            new("8490", "Övriga skuldrelaterade poster"),

            // 88 Year-end appropriations
            new("8810", "Förändring av periodiseringsfond"),
            new("8811", "Avsättning till periodiseringsfond"),
            new("8819", "Återföring från periodiseringsfond"),
            new("8820", "Mottagna koncernbidrag"),
            new("8830", "Lämnade koncernbidrag"),
            new("8850", "Förändring av överavskrivningar"),
            new("8890", "Övriga bokslutsdispositioner"),

            // 89 Taxes and profit/loss for the year
            new("8910", "Skatt som belastar årets resultat"),
            new("8920", "Skatt på grund av ändrad beskattning"),
            new("8980", "Övriga skatter"),
            new("8990", "Resultat"),
            new("8999", "Årets resultat")
        ]);

        return accounts;
    }
}