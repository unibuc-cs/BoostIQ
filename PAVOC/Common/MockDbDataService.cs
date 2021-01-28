using System;
using PAVOC.DataModel.Models;
using PAVOC.DataModel.Repository.Interface;
using PAVOC.DataModel.UnitOfWork;

namespace PAVOC.Common
{
    public class MockDbDataService
    {
        public static void Fill()
        {
            FillUsers();
            FillCategories();
            FillLearnLevels();
            FillTestLevels();
        }

        private static void FillUsers()
        {
            using (var uow = new UnitOfWork())
            {
                var repo = uow.GetRepository<IUserRepository>();
                var user = new UserEntity()
                {
                    Email = "user@gmail.com",
                    Username = "user",
                    Password = "user",
                    PointsLearn = 0,
                    PointsPlay = 0
                };
                repo.Add(user);
                uow.Save();
            }
        }

        private static void FillCategories()
        {
            using (var uow = new UnitOfWork())
            {
                var repo = uow.GetRepository<ICategoryRepository>();

                var historyCategory = new CategoryEntity()
                {
                    Name = "Istorie"
                };

                var geographyCategory = new CategoryEntity()
                {
                    Name = "Geografie"
                };

                var sportsCategory = new CategoryEntity()
                {
                    Name = "Sport"
                };

                var musicCategory = new CategoryEntity()
                {
                    Name = "Muzică"
                };

                var celebritiesCategory = new CategoryEntity()
                {
                    Name = "Celebrități"
                };

                repo.Add(historyCategory);
                repo.Add(geographyCategory);
                repo.Add(sportsCategory);
                repo.Add(musicCategory);
                repo.Add(celebritiesCategory);

                uow.Save();
            }
        }

        private static void FillLearnLevels()
        {
            using (var uow = new UnitOfWork())
            {
                var categoryRepository = uow.GetRepository<ICategoryRepository>();

                var historyCategory = categoryRepository.GetCategoryByName("Istorie");

                var learnLevel1History = new LearnLevelEntity()
                {
                    LearnLevelNumber = 1,
                    //TODO Petros -> change these 2 lines
                    Image = "https://www.europafm.ro/wp-content/uploads/2017/07/Stefan-Cel-Mare.jpg",
                    Text = "ȘTEFAN CEL MARE \n\n\n" +
                    "La 3 februarie 1531, la nici trei decenii de la trecerea în nefiinţă, Ştefan al III-lea, principele Ţării Moldovei, era amintit de Sigismund I, regele Poloniei (1506-1548), ca Stephanus ille magnus („acel mare Ştefan”). Bernard Wapowski, cartograful şi istoriograful oficial al aceluiaşi rege, consemna că domnul moldovean era „principele şi războinicul cel mai vestit” din epoca sa. Doctorul Matteo Muriano, trimis de Veneţia la Suceava, în vara anului 1502, spre a-i acorda asistenţa medicală principelui moldovean, consemna în raportul său că acesta „este un om foarte înţelept, vrednic de multă laudă, iubit mult de supuşii săi, pentru că este îndurător şi drept, veşnic treaz şi darnic”. Văzut de contemporanii lui europeni ca un şef de stat care a reuşit să se menţină la cârma ţării 47 de ani, pe plan intern el a simbolizat stabilitatea, continuitatea, dezvoltarea economică, dreptatea, încât la înmormântarea sa în Moldova „jale era, că plângea toţi ca pe un părinte al său …” (Grigore Ureche). \n\n" +
                    "Ştefan cel Mare, fiul lui Bogdan al II-lea (1449-1451) şi al soţiei sale Oltea, s-a născut cel mai probabil în anul 1438. După moartea tatălui său, Ştefan s-a refugiat în Transilvania stăpânită de către Iancu de Hunedoara (1441-1456), unde s-a familiarizat cu tacticile militare ale acestuia, care îmbinau elemente de artă militară din estul, centrul şi apusul Europei. Cu o forţă militară pusă la dispoziţie de către Vlad Ţepeş (1448; 1456-1472; 1476), la care s-au adăugat partizanii săi din sudul Moldovei, Ştefan cel Mare l-a învins pe Petru Aron la Doljeşti (Dolheşti), cucerind tronul Moldovei pe data de 12 aprilie 1457. A găsit o ţară sărăcită, sfâşiată de luptele dintre diverşii pretendenţi la domnia Moldovei, o ţară ce plătea tribut turcilor începând cu anul 1456. \n\n" +
                    "În asemenea circumstanţe, domnitorul a trebuit să iniţieze ample măsuri de redresare a situaţiei social-economice. Pentru a-şi asigura suportul politic necesar stabilităţii guvernării, Ştefan cel Mare a eliminat tendinţele marii boierimi de anarhie şi de nesupunere faţă de puterea centrală, a favorizat consolidarea economică a ţărănimi libere (răzeşii), a încurajat clasa negustorească şi legăturile comerciale externe. În plus, a acordat o atenţie aparte structurilor militare tradiţionale ale ţării („oastea cea mică” – structură militară permanentă, şi „oastea cea mare” – chemată numai în caz de atac extern), susţinând introducerea unei discipline mai riguroase şi ameliorarea dotării. Măsurile sale militare au vizat şi întărirea capacităţii defensive a ţării, prin consolidarea şi modernizarea cetăţilor Hotin, Tighina, Soroca, Chilia, Cetatea Albă, Suceava, Neamţ, Crăciuna. \n\n" +
                    "Prosperitatea economică a ţării i-a permis lui Ştefan cel Mare punerea în aplicare a unei politici de construire a unor edificii religioase, cu important rol cultural-artistic, dar şi militar. Acest fapt este considerat realizarea cea mai perenă a domniei voievodului moldovean. Epoca lui Ştefan cel Mare rămâne una de referinţă în istoria artei moldoveneşti, deoarece atunci se pun bazele aşa-numitului „stil moldovenesc” în arhitectura şi pictura religioasă. Arta iconografică din perioada ştefaniană este ilustrată de frescele din biserica de la Lujeni (astăzi Ucraina), Dolheşti, Bălineşti, Sf. Nicolae din Rădăuţi, Pătrăuţi, Voroneţ şi Sf. Ilie. Primele ansambluri complete ce s-au păstrat din vechea pictură ştefaniană sunt cele de la Pătrăuţi (1487), Voroneţ (1488), Sf. Ilie (1488), la care mai poate fi adăugat cu titlu de inventar şi cel de la Milişăuţi, distrus odată cu biserica în primul război mondial. Este interesant de menţionat faptul că reprezentările evangheliştilor de la Voroneţ sunt reproduceri fidele ale prototipurilor fixate de Gavril Uric în tetraevanghelul său din 1429, fapt ce sugerează o anumită continuitate de tradiţie a picturii moldoveneşti din veacul al XV-lea. Zugrăveala din altarul şi naosul bisericii mănăstirii Nemţ (1497) constituie ultimul ansamblu de pictură ce ne-a mai rămas din epoca lui Ştefan cel Mare. \n\n" +
                    "Victoriile militare spectaculoase ale lui Ştefan cel Mare, repurtate practic împotriva tuturor vecinilor săi (turci, tătari, maghiari, poloni) au fost pregătite întotdeauna de o politică externă foarte abilă, ce a permis voievodului ca, înconjurat de trei adversari redutabili (Ungaria, Polonia şi Imperiul Otoman), să nu se angajeze niciodată într-un conflict pe două fronturi. Din punct de vedere diplomatic, Ştefan cel Mare a purtat negocieri şi a încheiat alianţe, în funcţie de împrejurări, cu o serie de state puternice din estul, centrul şi vestul Europei (Hanatul de Crimeea, Imperiul Otoman, cnezatul de Moscova, Polonia, Ungaria, Veneţia, Statul Papal). La acestea se adaugă şi tratativele iniţiate în vederea organizării unei alianţe antiotomane cu Uzun Hassan, şahul statului turcoman din Anatolia orientală şi Iranul Occidental.\n\n"
                };
                historyCategory.LearnLevels.Add(learnLevel1History);

                var learnQuestion1LearnLevel1History = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Pe cine a învins Ștefan cel Mare pentru a cuceri tronul Moldovei?",
                };
                learnLevel1History.LearnQuestions.Add(learnQuestion1LearnLevel1History);

                var learnQuestionAnswer1Question1LearnLevel1History = new LearnQuestionAnswerEntity()
                {
                    Text = "Iancu de Hunedoara",
                    IsCorrect = false
                };
                learnQuestion1LearnLevel1History.LearnQuestionAnswers.Add(learnQuestionAnswer1Question1LearnLevel1History);

                var learnQuestionAnswer2Question1LearnLevel1History = new LearnQuestionAnswerEntity()
                {
                    Text = "Petru Aron",
                    IsCorrect = true
                };

                var learnQuestionAnswer3Question1LearnLevel1History = new LearnQuestionAnswerEntity()
                {
                    Text = "Vlad Țepeș",
                    IsCorrect = false
                };

                var learnQuestionAnswer4Question1LearnLevel1History = new LearnQuestionAnswerEntity()
                {
                    Text = "Gavril Uric",
                    IsCorrect = false
                };

                learnQuestion1LearnLevel1History.LearnQuestionAnswers.Add(learnQuestionAnswer2Question1LearnLevel1History);
                learnQuestion1LearnLevel1History.LearnQuestionAnswers.Add(learnQuestionAnswer3Question1LearnLevel1History);
                learnQuestion1LearnLevel1History.LearnQuestionAnswers.Add(learnQuestionAnswer4Question1LearnLevel1History);


                var learnQuestion2LearnLevel1History = new LearnQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Care sunt primele ansambluri complete ce s-au păstrat din vechea pictură ștefaniană?",
                };
                learnLevel1History.LearnQuestions.Add(learnQuestion2LearnLevel1History);

                var learnQuestionAnswer1Question2LearnLevel1History = new LearnQuestionAnswerEntity()
                {
                    Text = "Voroneț",
                    IsCorrect = true
                };
                learnQuestion2LearnLevel1History.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel1History);

                var learnQuestionAnswer2Question2LearnLevel1History = new LearnQuestionAnswerEntity()
                {
                    Text = "Doljești",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question2LearnLevel1History = new LearnQuestionAnswerEntity()
                {
                    Text = "Chilia",
                    IsCorrect = false
                };

                var learnQuestionAnswer4Question2LearnLevel1History = new LearnQuestionAnswerEntity()
                {
                    Text = "Pătrăuți",
                    IsCorrect = true
                };
                learnQuestion2LearnLevel1History.LearnQuestionAnswers.Add(learnQuestionAnswer2Question2LearnLevel1History);
                learnQuestion2LearnLevel1History.LearnQuestionAnswers.Add(learnQuestionAnswer3Question2LearnLevel1History);
                learnQuestion2LearnLevel1History.LearnQuestionAnswers.Add(learnQuestionAnswer4Question2LearnLevel1History);

                //-------------------------

                var learnLevel2History = new LearnLevelEntity()
                {
                    LearnLevelNumber = 2,
                    //TODO Petros -> change these 2 lines
                    Image = "https://upload.wikimedia.org/wikipedia/commons/4/40/Napoleon_in_His_Study.jpg",
                    Text = "NAPOLEON BONAPARTE\n\n\n" +
                    "Napoleon Bonaparte (n. 15 august 1769, Ajaccio, Corsica - d. 5 mai 1821, în Insula Sfânta Elena), cunoscut mai târziu ca Napoleon I și inițial ca Napoleone di Buonaparte, a fost un lider politic și militar al Franței, ale cărui acțiuni au influențat puternic politica europeană de la începutul secolului al XIX-lea.\n\n" +
                    "Născut în Corsica și specializat pe profilul de ofițer de artilerie în Franța continentală, Bonaparte a devenit cunoscut în timpul Primei Republici Franceze și a condus campanii reușite împotriva Primei și celei de-a Doua Coaliții, care luptau împotriva Franței. În 1799 a organizat o lovitură de stat și s-a proclamat Prim Consul; cinci ani mai târziu s-a încoronat ca Împărat al francezilor. În prima decadă a secolului al XIX-lea a opus armatele Imperiului Francez împotriva fiecărei puteri majore europene și a dominat Europa continentală printr-o serie de victorii militare. A menținut sfera de influență a Franței prin constituirea unor alianțe extensive și prin numirea prietenilor și membrilor familiei în calitate de conducători ai altor țări europene sub forma unor state clientelare franceze.\n\n" +
                    "Invazia franceză a Rusiei din 1812 a marcat un punct de cotitură în destinul lui Napoleon. Marea sa Armată a suferit pierderi covârșitoare în timpul campaniei și nu s-a recuperat niciodată pe deplin. În 1813, a Șasea Coaliție l-a înfrânt la Leipzig; în anul următor Coaliția a invadat Franța, l-a forțat pe Napoleon să abdice și l-a exilat pe insula Elba. În mai puțin de un an, a scăpat de pe Elba și s-a întors la putere, însă a fost învins în bătălia de la Waterloo din iunie 1815. Napoleon și-a petrecut ultimii șase ani ai vieții sub supraveghere britanică pe insula Sfânta Elena. O autopsie a concluzionat că a murit de cancer la stomac, deși Sten Forshufvud și alți oameni de știință au continuat să susțină că a fost otrăvit cu arsenic.\n\n" +
                    "Conflictul cu restul Europei a condus la o perioadă de război total de-a lungul continentului, iar campaniile sale sunt studiate la academii militare din întreaga lume. Deși considerat un tiran de către oponenții săi, el a rămas în istorie și datorită creării Codului Napoleonian, care a pus fundațiile legislației administrative și judiciare în majoritatea țărilor Europei de Vest.\n\n" +
                    "Devenit absolvent în septembrie 1785, Bonaparte este numit ofițer cu gradul de sublocotenent în regimentul de artilerie La Fère. A servit în garnizoanele de la Valence și Auxonne până după izbucnirea Revoluției Franceze în 1789, deși în această perioadă a fost în permisie timp de aproape două luni în Corsica și Paris. Un naționalist corsican fervent, Bonaparte i-a scris liderului corsican Pasquale Paoli în mai 1789: „Pe când națiunea pierea, m-am născut eu. Treizeci de mii de francezi au fost vomitați pe malurile noastre, înecând tronul libertății în valuri de sânge. Astfel arăta priveliștea odioasă care a fost prima ce m-a impresionat.”\n\n" +
                    "A petrecut primii ani ai Revoluției în Corsica, luptând într-o bătălie complexă între regaliști, revoluționari și naționaliștii corsicani. El a sprijinit facțiunea revoluționară iacobină, a câștigat gradul de locotenent-colonel și comanda unui batalion de voluntari. După ce depășise termenul permisiei și a condus o revoltă împotriva unei armate franceze din Corsica, a reușit totuși să convingă autoritățile militare din Paris să-l promoveze în gradul de căpitan în iulie 1792. S-a întors în Corsica din nou și a intrat în conflict cu Paoli, care hotărâse să se despartă de Franța și să saboteze un asalt francez asupra insulei sardiniene La Maddalena, unul dintre liderii expediției fiind chiar Bonaparte. Acesta și familia sa au trebuit să fugă în Franța continentală în iunie 1793 din cauza înrăutățirii relațiilor cu Paoli.\n\n" +
                    "Lui Napoleon i se permisese să ia cu el în exil câțiva prieteni și servitori, printre care Henri-Gratien Bertrand, fostul mareșal al palatului, și contele Charles-Tristan de Montholon, un membru al aristocrației prerevoluționare. Bertrand era în slujba lui Napoleon din 1798, dar Montholon era un aderent de ultima oră – după prima abdicare a lui Napoleon se grăbise să-și ofere serviciile monarhiei restaurate, dar a trecut de partea împăratului când acesta s-a întors de pe Insula Elba. El o adusese cu sine și pe tânăra și atrăgătoarea lui soție, ale cărei atenții față de Napoleon și vizitele nocturne pe care le făcea în dormitorul acestuia deveniseră curând subiect de bârfa pe insulă.\n\n" +
                    "La un an după înfrângerea de la Leipzig, întreg imperiul s-a prăbușit. Burbonii au fost readuși la tronul Franței prin Ludovic al XVIII-lea. Aceasta revenire nu s-a bucurat însă de unanimitatea aliaților, între care au intervenit repede divergențe. Unitatea coaliției a fost însă salvată chiar de Napoleon. Înconjurat de dezbinarea aliaților, Napoleon părăsește insula Elba și începe ceea ce avea să fie aventura „celor o sută de zile”. Reîntronat, acesta începe să viseze la refacerea marelui imperiu[necesită citare]. Obține chiar câteva victorii. Pentru scurt timp însă, căci este înfrânt în bătălia de la Waterloo (18 iunie 1815). Silit să abdice din nou, Napoleon a fost exilat pe insula Sf. Elena, unde a murit în condiții neclare, câțiva ani mai târziu, la vârsta de 51 de ani (5 mai 1821). Există două teorii importante cu privire la moartea sa: otrăvirea cronică cu arsenic și cancerul la stomac. A fost înmormântat cu onoruri militare\n\n" +
                    "Controversele asupra morții împăratului Napoleon nu se mai termină... Specialiști în domeniul medicinei legale, istorici ai vieții și morții lui Napoleon s-au dedicat încă din anul 1961 cercetărilor cauzei morții acestui om de stat francez. Unii spun că moartea s-ar datora unei erori medicale, cancerului de stomac și, în cele din urmă, otrăvirii acestuia cu arsenic. Primele două supoziții - eroare medicală sau cancer de stomac, sunt definitiv respinse de Dr. Pascal Kintz.\n\n"
                };

                historyCategory.LearnLevels.Add(learnLevel2History);

                var learnQuestion1LearnLevel2History = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Pe ce insulă a fost exilat Napoleon Bonaparte?",
                };
                learnLevel2History.LearnQuestions.Add(learnQuestion1LearnLevel2History);

                var learnQuestionAnswer1Question1LearnLevel2History = new LearnQuestionAnswerEntity()
                {
                    Text = "Insula Diavolului",
                    IsCorrect = false
                };
                learnQuestion1LearnLevel2History.LearnQuestionAnswers.Add(learnQuestionAnswer1Question1LearnLevel2History);

                var learnQuestionAnswer2Question1LearnLevel2History = new LearnQuestionAnswerEntity()
                {
                    Text = "Insula Sfântul Paul",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question1LearnLevel2History = new LearnQuestionAnswerEntity()
                {
                    Text = "Insula Sfânta Elena",
                    IsCorrect = true
                };

                var learnQuestionAnswer4Question1LearnLevel2History = new LearnQuestionAnswerEntity()
                {
                    Text = "Insula Man",
                    IsCorrect = false
                };

                learnQuestion1LearnLevel2History.LearnQuestionAnswers.Add(learnQuestionAnswer2Question1LearnLevel2History);
                learnQuestion1LearnLevel2History.LearnQuestionAnswers.Add(learnQuestionAnswer3Question1LearnLevel2History);
                learnQuestion1LearnLevel2History.LearnQuestionAnswers.Add(learnQuestionAnswer4Question1LearnLevel2History);


                var learnQuestion2LearnLevel2History = new LearnQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Ce prieteni a luat in exil Napoleon Bonaparte?",
                };
                learnLevel2History.LearnQuestions.Add(learnQuestion2LearnLevel2History);

                var learnQuestionAnswer1Question2LearnLevel2History = new LearnQuestionAnswerEntity()
                {
                    Text = "Pierre Simon Laplace",
                    IsCorrect = false
                };

                learnQuestion2LearnLevel2History.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel2History);

                var learnQuestionAnswer2Question2LearnLevel2History = new LearnQuestionAnswerEntity()
                {
                    Text = "Henri-Gratien Bertrand",
                    IsCorrect = true
                };

                var learnQuestionAnswer3Question2LearnLevel2History = new LearnQuestionAnswerEntity()
                {
                    Text = "Charles-Tristan de Montholon",
                    IsCorrect = true
                };

                var learnQuestionAnswer4Question2LearnLevel2History = new LearnQuestionAnswerEntity()
                {
                    Text = "Jacques-Louis David",
                    IsCorrect = false
                };

                learnQuestion2LearnLevel2History.LearnQuestionAnswers.Add(learnQuestionAnswer2Question2LearnLevel2History);
                learnQuestion2LearnLevel2History.LearnQuestionAnswers.Add(learnQuestionAnswer3Question2LearnLevel2History);
                learnQuestion2LearnLevel2History.LearnQuestionAnswers.Add(learnQuestionAnswer4Question2LearnLevel2History);


                //---------------------

                var learnLevel3History = new LearnLevelEntity()
                {
                    LearnLevelNumber = 3,
                    //TODO Petros -> change these 2 lines
                    Image = "https://upload.wikimedia.org/wikipedia/ro/thumb/0/0b/ColdWar.jpg/300px-ColdWar.jpg",
                    Text = "RĂZBOIUL RECE \n\n\n" +
                    "Războiul Rece (1947–1991) a fost o perioadă de tensiuni și confruntări politice și ideologice, o stare de tensiune întreținută care a apărut după sfârșitul celui de-al Doilea Război Mondial și a durat până la revoluțiile din 1989. În Războiul Rece s-au confruntat două grupuri de state care aveau ideologii și sisteme politice foarte diferite. Într-un grup se aflau URSS și aliații ei, grup căruia i se spunea uzual „Blocul răsăritean” (sau oriental). Celălalt grup cuprindea SUA și aliații săi, fiind numit, uzual, „Blocul apusean” (sau occidental). La nivel politico-militar, în Europa, cele două blocuri erau reprezentate de către două alianțe internaționale. Blocul apusean era reprezentat de către Organizația Tratatului Atlanticului de Nord (NATO, North Atlantic Treaty Organization), iar cel răsăritean de către Pactul de la Varșovia. După sfârșitul celui de-al Doilea Război Mondial în Europa, Germania a fost divizată în patru zone de ocupație. Vechea capitală a Germaniei, Berlinul, ca sediu al Comisiei Aliate de Control, a fost împărțită în patru zone de ocupație corespunzătoare. Zidul Berlinului, un simbol al Războiului Rece, a fost construit, constituind, timp de aproape 28 de ani, o barieră de separare între Republica Federală Germană și Republica Democrată Germană.\n\n" +
                    "Războiul Rece a fost, însă, un conflict la scară mondială, SUA și URSS mai având și multe alte state aliate în afara Europei, ce nu făceau parte din cele două alianțe militare oficiale. La nivel economic, Războiul Rece a fost o confruntare între capitalism și comunism. Pe plan ideologico-politic, a fost o confruntare între democrațiile liberale occidentale și regimurile comuniste totalitare. Ambele tabere se autodefineau în termeni pozitivi: statele blocului occidental își spuneau „lumea liberă” sau „societatea deschisă”, iar statele blocului oriental își spuneau „lumea anti-imperialistă” sau „democrațiile populare”.\n\n" +
                    "Înfruntarea dintre cele două blocuri a fost numită „Război Rece”, deoarece nu s-a ajuns la confruntări militare directe între cele două superputeri, care ar fi constituit un „Război Cald”, cu toate că perioada a generat o cursă a înarmării. Din punctul de vedere al studiilor strategice, există opinia că nu s-a ajuns și nu se putea ajunge la un „Război Cald”, la o confruntare militară convențională, datorită faptului că ambele superputeri, SUA și URSS, s-au dotat cu arme nucleare, ceea ce a creat o situație militară strategică de „deterrence”, adică de descurajare și blocare reciprocă. În cazul unui război real, s-ar fi ajuns la o distrugere reciprocă totală și, totodată, la o catastrofă mondială. Un rol important l-au jucat serviciile secrete, confruntându-se, în primul rând, cele americane (CIA, NSA) cu KGB-ul sovietic. Au fost implicate, însă, și serviciile secrete vest-europene (britanice, vest-germane, franceze, italiene, etc.) și est-europene (Securitatea, STASI, etc.). Denumirea de „Război Rece” mai provine și din faptul că a fost purtat între foștii aliați din războiul împotriva regimului totalitar nazist. Din punct de vedere al mijloacelor utilizate, Războiul Rece a fost un conflict în care s-au utilizat presiunea diplomatică, militară, economică, ajutorul pe scară largă pentru statele-client, manevrele diplomatice, spionajul, curse ale înarmărilor convenționale și nucleare, coaliții militare, rivalitate la evenimentele sportive, competiție tehnologică, campanii masive de propagandă, asasinatul, operațiunile militare de intensitate mică și iminența unui război pe scară mare. Un moment în care Războiul Rece putea să devină unul „cald” îl reprezintă anul 1962, când sovieticii au plasat în Cuba, devenită comunistă sub Fidel Castro, rachete cu rază medie de acțiune. Americanii au răspuns prin instalarea unei blocade maritime, ajungând foarte aproape de a declanșa o bătălie navală cu sovieticii. În cele din urmă, însă, prin intervenția președintelui american Kennedy, s-a ajuns la normalizarea relațiilor cu sovieticii. A urmat o perioadă de destindere, marcată de întâlnirea dintre Kennedy și Nichita Hrușciov, în 1963, când au stabilit ca, în viitor, pentru comunicări urgente și de importanță majoră între Casa Albă și Kremlin să folosească „telefonul roșu” (care era, de fapt, un telex).\n\n" +
                    "Alte momente tensionate ale Războiului Rece au fost, cronologic: Blocada Berlinului (1948–1949), Războiul din Coreea (1950–1953), Criza Berlinului din 1961, Criza Suezului (1962), Războiul din Vietnam (1959–1975), Războiul de Iom Kippur (1973), Războiul Afgano-Sovietic (1979–1989), Doborârea cursei KAL 007 (1983) și Exercițiul militar NATO „Able Archer” (1983). La mijlocul anilor 1980, noul lider sovietic, Mihail Gorbaciov a introdus reformele de liberalizare numite „perestroika” (reorganizare sau restructurare) și „glasnost” (deschidere sau transparență) și a retras trupele sovietice din Afghanistan. Presat de cererile de independență națională a sateliților sovietici din estul Europei (Polonia, în special), Gorbaciov a refuzat să trimită trupele sovietice pentru a reprima revoluțiile ce se desfășurau pe cale pașnică (exceptând Revoluția din România).\n\n" +
                    "Războiul Rece s-a atenuat odată cu prăbușirea regimurilor comuniste din Europa Centrală și de Est, precum și din Mongolia, Cambodgia și Yemenul de Sud, urmată, doi ani mai târziu, în decembrie 1991, și de destrămarea Uniunii Sovietice. Lumea care a rămas este dominată de o singură superputere, SUA. Această situație este, de regulă, descrisă drept hegemonie globală a SUA într-o lume unipolară, deși unii autori consideră că lumea actuală este multipolară.Statele central-europene și est-europene (care, timp de patru decenii, se aflaseră sub dominația sovieticǎ), s-au democratizat și au ales să se integreze în NATO și Uniunea Europeană. SUA au fost ancorate în Războiul împotriva terorismului și în rǎzboaiele locale din Orientul Mijlociu (precum sunt cele din Afghanistan și Irak), mal ales, după Atentatele din 11 septembrie 2001. China a atins cea mai rapidă creștere economică, iar între anii 2004 și 2010 a depășit toate prognozele, devenind un concurent serios pentru SUA.De asemenea, criza economică mondială începută în 2008 a afectat, în special, zona occidentală, astfel că, în timp ce în Statele Unite marile bănci aveau probleme sau intrau în faliment, China a beneficiat de pe urma investițiilor strategice și au stimulat-o să declanșeze rǎzboiul economic cu SUA pentru supremația mondială. După douǎ decenii de destindere a relațiilor americano-ruse, urmatǎ, în 2008, de rǎcirea relațiilor diplomatice - consecință a rǎzboiului din Georgia - și, mai ales, pe fondul crizei din Ucraina, tensiunile, ostilitățile și rivalitǎțile anterioare dintre cele două puteri s-au acutizat, astfel că, în 2014, a reizbucnit Războiul Rece între Statele Unite ale Americii/ statele membre ale Uniunii Europene/ Organizației Tratatului Atlanticului de Nord și Federația Rusă - condusă de Vladimir Putin - și aliații acesteia. Acest rǎzboi este cunoscut în Mass-Media ca „Al Doilea Război Rece”,[2][3][4][5] însă, spre deosebire de Războiul Rece anterior, de această dată, Germania reunificată are un rol geopolitic major în Europa. Reizbucnirea și amplificarea Războiul Rece dintre SUA și Rusia, pe fondul creșterii amenințării terorismului în Orientul Mijlociu devastat de războaie civile, revoluții în nordul Africii și ascensiunea economicǎ fulminantă a Chinei, generează noi și justificate neliniști privind redimensionarea galopantă a raporturilor de putere în lumea contemporană.\n\n" +
                    "Războiul Rece a lăsat în urma sa o moștenire importantă, adesea menținută în cultura populară și în mass-media, teme precum spionajul (cum este, spre exemplu, seria filmelor de succes internațional avându-l ca erou pe James Bond) și amenințarea războiului nuclear bucurându-se de o mare și constantă popularitate.\n\n"
                };

                historyCategory.LearnLevels.Add(learnLevel3History);

                var learnQuestion1LearnLevel3History = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "În ce perioadă a avut loc Războiul Rece?",
                };
                learnLevel3History.LearnQuestions.Add(learnQuestion1LearnLevel3History);

                var learnQuestionAnswer1Question1LearnLevel3History = new LearnQuestionAnswerEntity()
                {
                    Text = "1941-1972",
                    IsCorrect = false
                };
                learnQuestion1LearnLevel3History.LearnQuestionAnswers.Add(learnQuestionAnswer1Question1LearnLevel3History);

                var learnQuestionAnswer2Question1LearnLevel3History = new LearnQuestionAnswerEntity()
                {
                    Text = "1943-1989",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question1LearnLevel3History = new LearnQuestionAnswerEntity()
                {
                    Text = "1947-1991",
                    IsCorrect = true
                };

                var learnQuestionAnswer4Question1LearnLevel3History = new LearnQuestionAnswerEntity()
                {
                    Text = "1914-1918",
                    IsCorrect = false
                };

                learnQuestion1LearnLevel3History.LearnQuestionAnswers.Add(learnQuestionAnswer2Question1LearnLevel3History);
                learnQuestion1LearnLevel3History.LearnQuestionAnswers.Add(learnQuestionAnswer3Question1LearnLevel3History);
                learnQuestion1LearnLevel3History.LearnQuestionAnswers.Add(learnQuestionAnswer4Question1LearnLevel3History);


                var learnQuestion2LearnLevel3History = new LearnQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Cum se numeau reformele de liberalizare introduse de Mihai Gorbaciov in anii '80?",
                };
                learnLevel3History.LearnQuestions.Add(learnQuestion2LearnLevel3History);

                var learnQuestionAnswer1Question2LearnLevel3History = new LearnQuestionAnswerEntity()
                {
                    Text = "Otrezki",
                    IsCorrect = false
                };
                learnQuestion2LearnLevel3History.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel3History);

                var learnQuestionAnswer2Question2LearnLevel3History = new LearnQuestionAnswerEntity()
                {
                    Text = "Bolșevica",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question2LearnLevel3History = new LearnQuestionAnswerEntity()
                {
                    Text = "Glasnost",
                    IsCorrect = true
                };

                var learnQuestionAnswer4Question2LearnLevel3History = new LearnQuestionAnswerEntity()
                {
                    Text = "Perestroika",
                    IsCorrect = true
                };

                learnQuestion2LearnLevel3History.LearnQuestionAnswers.Add(learnQuestionAnswer2Question2LearnLevel3History);
                learnQuestion2LearnLevel3History.LearnQuestionAnswers.Add(learnQuestionAnswer3Question2LearnLevel3History);
                learnQuestion2LearnLevel3History.LearnQuestionAnswers.Add(learnQuestionAnswer4Question2LearnLevel3History);

                categoryRepository.Update(historyCategory);

                //--------------------

                var sportsCategory = categoryRepository.GetCategoryByName("Sport");

                var learnLevel1Sports = new LearnLevelEntity()
                {
                    LearnLevelNumber = 1,
                    //TODO Petros -> change these 2 lines
                    Image = "https://upload.wikimedia.org/wikipedia/ro/thumb/e/ef/Romania_national_football_team_logo.svg/200px-Romania_national_football_team_logo.svg.png",
                    Text = "ECHIPA NAȚIONALĂ DE FOTBAL A ROMÂNIEI\n\n\n" +
                    "Echipa națională de fotbal a României este prima reprezentativă a României și se află sub controlul Federației Române de Fotbal (FRF). România a fost una dintre cele patru țări care au participat la primele trei campionate mondiale de fotbal, alături de selecționatele Braziliei, Franței și Belgiei. Totuși, între edițiile 1950 și 1986, România a reușit să se califice numai la un singur turneu final. Între 1990 și 2000 selecționata României s-a calificat în șaisprezecimile sau chiar optimile a trei campionate mondiale consecutive. Această perioadă prielnică și-a atins culmea în cadrul turneului final al Campionatul Mondial din 1994, când România, avându-l căpitan pe Gheorghe Hagi, a ajuns în sferturile de finală învingând Argentina cu scorul de 3-2. Ulterior a pierdut cu Suedia la penaltiuri.\n\n" +
                    "România a făcut de asemenea o figură bună la Euro 2000, când a obținut un 1-1 cu Germania și a învins Anglia cu 3-2 în grupe, trecând mai departe în sferturile de finală, unde a fost învinsă de Italia.\n\n" +
                    "Din 1939 până în anii 1990 golgheterul absolut al echipei naționale de fotbal a României a fost Iuliu Bodola, cu 30 de goluri marcate. În prezent recordul de goluri marcate pentru echipa națională este deținut de Gheorghe Hagi și Adrian Mutu, amândoi cu 35 de reușite.\n\n" +
                    "Au urmat alți șase ani fără prezențe la turneele finale, până la Italia 1990, unde România revenea la un Mondial după 20 de ani. Din echipa condusă de Emeric Ienei făceau parte tinerii Gheorghe Hagi, Florin Răducioiu sau Ilie Dumitrescu. Campionul european cu Steaua București, Marius Lăcătuș avea să fie eroul primului meci, marcând două goluri în poarta U.R.S.S., de care România a trecut cu 2-0 la Bari. Același oraș a găzduit și al doilea meci al tricolorilor, cu reprezentativa Camerunului, pierdut cu 2-1. Golul României a fost marcat de Gavril Balint. În ultimul meci din grupă, România a întâlnit Argentina, campioana mondială en-titre și echipa în rândul căreia evolua Diego Maradona. Ca un făcut, jocul a avut loc la Napoli, orașul în care Maradona evolua la echipa de club. Sud-americanii au marcat primii, dar Balint avea să egaleze și să ducă România în optimile de finală. Aici a urmat înfruntarea cu Irlanda, și după un 0-0 la capătul a 120 de minute, disputa s-a decis la executarea loviturilor de departajare, unde singura ratare i-a aparținut lui Daniel Timofte și România rata întâlnirea cu Italia, în sferturi.\n\n" +
                    "După ratarea calificării la EURO 1992, România a fost aproape să rateze și accesul la Mondialul din 1994. La jumătatea preliminariilor a fost adus însă Anghel Iordănescu în postul de selecționer, și cu trei victorii în ultimele trei meciuri, între care un succes cu Belgia la București și unul în Țara Galilor, România avea să meargă la turneul final din Statele Unite.\n\n" +
                    "Pe 18 iunie 1994, la Los Angeles, România a întâlnit Columbia, echipă considerată favorită la titlu de brazilianul Pelé. Florin Răducioiu a deschis scorul, iar Gheorghe Hagi l-a majorat cu un gol incredibil, un șut din apropierea tușei din stânga a terenului, de la peste 30 de metri de poartă. Pe final, pe un contraatac, Răducioiu consfințea scorul final, 3-1, după ce columbienii reduseseră din handicap.\n\n" +
                    "Patru zile mai târziu, la Detroit, într-un stadion acoperit, România a întâlnit Elveția în fața căreia avea să piardă cu 4-1. Doar un succes în fața Statelor Unite, organizatoarea competiției, ducea România în faza eliminatorie, și victoria a venit din nou pe stadionul Rose Bowl din Los Angeles. Dan Petrescu a marcat unicul gol al partidei.\n\n" +
                    "În optimile de finală, adversar a fost Argentina, fără Diego Maradona care tocmai fusese suspendat pentru consum de droguri. La tricolori nu juca Răducioiu, din cauza acumulării de cartonașe galbene, dar absența lui a fost suplinită perfect de Ilie Dumitrescu, autorul unei duble, iar Gheorghe Hagi a înscris și el într-o victorie cu 3-2 care a dus în premieră pe tricolori în sferturile de finală mondiale. Aici, tot loviturile de departajare aveau să oprească România, ca și în 1990. Împotriva Suediei, Răducioiu a împins meciul în prelungiri după ce scandinavii marcaseră primii, pentru ca din nou Răducioiu să înscrie pentru 2-1 în minutul 101. Însă cu cinci minute înainte de finalul jocului, Kennet Andersson a readus egalitatea și la șuturile de la 11 metri Dan Petrescu și Miodrag Belodedici au ratat pentru tricolori după ce prima ratare aparținuse suedezilor.\n\n" +
                    "În 1996, România a revenit și la Campionatul European, participând la EURO 1996 din Anglia, unde însă a pierdut toate meciurile din grupă: 0-1 cu Franța și Bulgaria și 1-2 cu Spania, golul României fiind marcat de Florin Răducioiu.\n\n" +
                    "A treia prezență consecutivă la Campionatul Mondial a fost consemnată în Franța 1998, unde România a fost cap de serie la tragerea la sorți. În ciuda acestui avantaj, grupa a fost una dificilă, cu Columbia, de care tricolorii au trecut cu 1-0, gol Adrian Ilie, și Anglia. La Toulouse, Viorel Moldovan a deschis scorul, Michael Owen a egalat, dar Dan Petrescu a adus victoria și calificarea în minutele de final. În ultimul meci, contra Tunisiei, echipa condusă de Anghel Iordănescu avea nevoie de un punct pentru a termina pe primul loc în grupă și meciul se încheia 1-1, Viorel Moldovan egalând în repriza secundă. Însă în optimile de finală adversar a fost Croația care s-a impus la limită, 1-0, Davor Suker transformând un penalti înainte de pauză.\n\n" +
                    "Ultimul turneu final al Generației de Aur a fost EURO 2000, în Olanda și Belgia. Anghel Iordănescu plecase după Franța 1998, Victor Pițurcă a calificat echipa dar a fost demis înainte de turneul final unde selecționer a fost Emeric Ienei. Dintr-o grupă imposibilă, România obținea calificarea după 1-1 cu Germania, gol Viorel Moldovan, 0-1 cu Portugalia și 3-2 în ultimul meci, contra Angliei. Disputa de la Charleroi a început cu golul lui Cristian Chivu, dar englezii au intrat în avantaj de un gol la cabine. Dorinel Munteanu a egalat la 2, iar Ionel Ganea a transformat un penalti în minutul 89, aducând victoria și calificarea.\n\n" +
                    "Adversar în sferturile de finală a fost Italia, la Bruxelles. În minutul 35, Gheorghe Hagi a fost eliminat pentru proteste, iar cu un jucător în plus italienii s-au impus cu 2-0.\n\n"
                };

                sportsCategory.LearnLevels.Add(learnLevel1Sports);

                var learnQuestion1LearnLevel1Sports = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "De cine a fost învinsă România în sferturile de finală a Campionatului European din 2000?",
                };
                learnLevel1Sports.LearnQuestions.Add(learnQuestion1LearnLevel1Sports);

                var learnQuestionAnswer1Question1LearnLevel1Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "Anglia",
                    IsCorrect = false
                };
                learnQuestion1LearnLevel1Sports.LearnQuestionAnswers.Add(learnQuestionAnswer1Question1LearnLevel1Sports);

                var learnQuestionAnswer2Question1LearnLevel1Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "Germania",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question1LearnLevel1Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "Italia",
                    IsCorrect = true
                };

                var learnQuestionAnswer4Question1LearnLevel1Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "Suedia",
                    IsCorrect = false
                };

                learnQuestion1LearnLevel1Sports.LearnQuestionAnswers.Add(learnQuestionAnswer2Question1LearnLevel1Sports);
                learnQuestion1LearnLevel1Sports.LearnQuestionAnswers.Add(learnQuestionAnswer3Question1LearnLevel1Sports);
                learnQuestion1LearnLevel1Sports.LearnQuestionAnswers.Add(learnQuestionAnswer4Question1LearnLevel1Sports);


                var learnQuestion2LearnLevel1Sports = new LearnQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Cine a marcat unicul gol din victoria decisivă a României contra Statelor Unite de la Cupa Mondială 1994?",
                };
                learnLevel1Sports.LearnQuestions.Add(learnQuestion2LearnLevel1Sports);

                var learnQuestionAnswer1Question2LearnLevel1Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "Florin Răducioiu",
                    IsCorrect = false
                };
                learnQuestion2LearnLevel1Sports.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel1Sports);

                var learnQuestionAnswer2Question2LearnLevel1Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "Ilie Dumitrescu",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question2LearnLevel1Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "Dan Petrescu",
                    IsCorrect = true
                };

                var learnQuestionAnswer4Question2LearnLevel1Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "Gheorghe Hagi",
                    IsCorrect = true
                };
                learnQuestion2LearnLevel1Sports.LearnQuestionAnswers.Add(learnQuestionAnswer2Question2LearnLevel1Sports);
                learnQuestion2LearnLevel1Sports.LearnQuestionAnswers.Add(learnQuestionAnswer3Question2LearnLevel1Sports);
                learnQuestion2LearnLevel1Sports.LearnQuestionAnswers.Add(learnQuestionAnswer4Question2LearnLevel1Sports);

                //-------------------------

                var learnLevel2Sports = new LearnLevelEntity()
                {
                    LearnLevelNumber = 2,
                    //TODO Petros -> change these 2 lines
                    Image = "https://playtech.ro/stiri/wp-content/uploads/2020/03/nadia-comaneci.jpg",
                    Text = "NADIA ELENA COMĂNECI \n\n\n" +
                    "Nadia Elena Comăneci (n. 12 noiembrie 1961, Onești, România) este o gimnastă română, prima gimnastă din lume care a primit nota zece într-un concurs olimpic de gimnastică. Este câștigătoare a cinci medalii olimpice de aur. Este considerată a fi una dintre cele mai bune sportive ale secolului XX și una dintre cele mai bune gimnaste ale lumii, din toate timpurile, „Zeița de la Montreal”, prima gimnastă a epocii moderne care a luat 10 absolut. Este primul sportiv român inclus în memorialul International Gymnastics Hall of Fame.\n\n" +
                    "Nadia s-a născut la Onești, find fiica lui Gheorghe și Ștefania-Alexandrina Comăneci[3]; a fost botezată după „Nadejda” („Speranță”), eroină a unui film. Unele surse susțin că s-ar fi născut ca „Anna Kemenes”.[4][5][6] Această variantă a fost dezmințită în noiembrie 2016 atât de Nadia cât și de mama sa, Ștefania\n\n" +
                    "A concurat pentru prima dată la nivel național în România, în 1970, ca membră a echipei orașului său. Curând, a început antrenamentele cu Béla Károlyi și soția acestuia, Márta Károlyi, care au emigrat mai târziu în Statele Unite, devenind antrenori ai multor gimnaste americane. La vârsta de 13 ani, primul succes major al lui Comăneci a fost câștigarea a trei medalii de aur și una de argint la Campionatele Europene din 1975, de la Skien, Norvegia. În același an, agenția de știri Associated Press a numit-o --Atleta Anului--.\n\n" +
                    "La 14 ani, Comăneci a devenit o stea a Jocurilor Olimpice de Vară din 1976 de la Montreal, Québec. Nu numai că a devenit prima gimnastă care a obținut scorul perfect de zece la olimpiadă (de șapte ori), dar a și câștigat trei medalii de aur (la individual compus, bârnă și paralele), o medalie de argint (echipă compus) și bronz (sol). Acasă, succesul său i-a adus distincția de „Erou al Muncii Socialiste”, fiind cea mai tânără româncă distinsă cu acest titlu.\n\n" +
                    "Comăneci și-a apărat titlul european în 1977, dar echipa României a ieșit din competiție în finale, în semn de protest contra arbitrajului. La Campionatele Mondiale din 1978 a concurat o Nadia Comăneci cu greutate peste medie și ieșită din formă. Căderea la paralele a trimis-o pe locul 4, însă a câștigat titlul de campioană mondială la bârnă.\n\n" +
                    "În 1979, Comăneci, din nou la greutate normală, a câștigat cel de-al treilea titlu european la individual compus (devenind primul sportiv din istoria gimnasticii care a reușit această performanță). La Campionatele Mondiale din decembrie, ea a câștigat concursul preliminar, dar a fost spitalizată înainte de a participa la concursul pe echipe, din cauza unei infecții, în urma unei tăieturi la încheietura mâinii, cauzată de o cataramă din metal. În ciuda recomandărilor doctorilor, ea a părăsit spitalul și a concurat la bârnă, unde a obținut nota 9,95. Performanța sa a conferit României prima medalie de aur în concursul pe echipe.\n\n" +
                    "A participat și la Jocurile Olimpice din 1980 de la Moscova, clasându-se a doua după Elena Davîdova la individual compus, când a fost nevoită să aștepte pentru notă până ce Davîdova și-a încheiat exercițiul. Nadia și-a păstrat titlul la bârnă, dar a câștigat și o nouă medalie de aur, la sol, și una de argint, împreună cu echipa\n\n"

                };

                sportsCategory.LearnLevels.Add(learnLevel2Sports);

                var learnQuestion1LearnLevel2Sports = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Căderea de la paralele a Nadiei Comăneci de la Campionatele Mondiale din 1978, au trimis-o pe locul?",
                };
                learnLevel2Sports.LearnQuestions.Add(learnQuestion1LearnLevel2Sports);

                var learnQuestionAnswer1Question1LearnLevel2Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "3",
                    IsCorrect = false
                };
                learnQuestion1LearnLevel2Sports.LearnQuestionAnswers.Add(learnQuestionAnswer1Question1LearnLevel2Sports);

                var learnQuestionAnswer2Question1LearnLevel2Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "4",
                    IsCorrect = true
                };

                var learnQuestionAnswer3Question1LearnLevel2Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "5",
                    IsCorrect = false
                };

                var learnQuestionAnswer4Question1LearnLevel2Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "6",
                    IsCorrect = false
                };

                learnQuestion1LearnLevel2Sports.LearnQuestionAnswers.Add(learnQuestionAnswer2Question1LearnLevel2Sports);
                learnQuestion1LearnLevel2Sports.LearnQuestionAnswers.Add(learnQuestionAnswer3Question1LearnLevel2Sports);
                learnQuestion1LearnLevel2Sports.LearnQuestionAnswers.Add(learnQuestionAnswer4Question1LearnLevel2Sports);


                var learnQuestion2LearnLevel2Sports = new LearnQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Care a fost nota exactă obținută de Nadia Comăneci la bârnă în anul 1979?",
                };
                learnLevel2Sports.LearnQuestions.Add(learnQuestion2LearnLevel2Sports);

                var learnQuestionAnswer1Question2LearnLevel2Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "9.90",
                    IsCorrect = false
                };

                learnQuestion2LearnLevel2Sports.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel2Sports);

                var learnQuestionAnswer2Question2LearnLevel2Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "9.98",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question2LearnLevel2Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "10.0",
                    IsCorrect = false
                };

                var learnQuestionAnswer4Question2LearnLevel2Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "9.95",
                    IsCorrect = true
                };

                learnQuestion2LearnLevel2Sports.LearnQuestionAnswers.Add(learnQuestionAnswer2Question2LearnLevel2Sports);
                learnQuestion2LearnLevel2Sports.LearnQuestionAnswers.Add(learnQuestionAnswer3Question2LearnLevel2Sports);
                learnQuestion2LearnLevel2Sports.LearnQuestionAnswers.Add(learnQuestionAnswer4Question2LearnLevel2Sports);

                //----------------

                var learnLevel3Sports = new LearnLevelEntity()
                {
                    LearnLevelNumber = 3,
                    //TODO Petros -> change these 2 lines
                    Image = "https://image-cdn.essentiallysports.com/wp-content/uploads/20200912202247/michael-jordan-t.jpg",
                    Text = "MICHAEL JORDAN \n\n\n" +
                    "Jordan s-a născut în Brooklyn, New York, fiul lui Deloris , care a lucrat în domeniul bancar, și James R. Jordan, un supraveghetor de echipamente. Familia sa s-a mutat la Wilmington, Carolina de Nord, atunci când era copil. Jordan a mers la școală la Emsley A. Laney High School din Wilmington, unde a ancorat cariere atletice jucând baseball, fotbal american și baschet. El a încercat pentru echipa de baschet Varsity în al doilea an de studenție, dar la abia 1,80 m, el a fost considerat prea scund pentru a juca la acest nivel. Prietenul lui mai înalt, Harvest Leroy Smith, a fost singurul care a fost ales dintre Sophomores pentru a face parte din echipă.\n\n" +
                    "Motivat să își dovedească valoarea, Jordan a devenit steaua echipei de juniori și a fost cel mai bun marcator în 40 de jocuri. În vara următoare, el a crescut 10 cm în înălțime,și antrenându-se în mod riguros a câștigat un loc în echipa mare, obținând o medie de aproximativ 20 de puncte pe meci.. Ca senior, a fost selectat la McDonald's All-American-Team după un sezon încheiat cu o triplă dublă ca medie: 29.2 puncte, 11.6 recuperări și 10.1 pase decisive. În 1981, Jordan a câștigat o bursă de baschet la Universitatea din Carolina de Nord la Chapel Hill, unde s-a specializat în geografie culturală. Ca un boboc în echipa condusă de Dean Smith, a fost numit bobocul ACC al anului, cu o medie de 13.4 puncte pe meci (PPG) și o medie de 53,4% la aruncarea la coș. El a realizat coșul decisiv în finala campionatului NCAA din 1982 împotriva celor de la Georgetown, la care juca viitorul său rival din NBA Patrick Ewing. Jordan a descris acel coș un moment decisiv în cariera lui de baschet. În timpul celor trei sezoane de la Carolina de Nord, el a avut o medie de 17.7 puncte pe meci la 54,0% și a adăugat 5.0 recuperări pe meci (RPG).\n\n" +
                    "Michael Jordan în timp ce joacă cu Scorpions Scottsdale,în data de 6 octombrie 1993, își anunță retragerea, citând o pierdere din dorința de a juca acest joc. Jordan a declarat mai târziu că uciderea tatălui sau mai devreme in acel i-a schimbat deciziile.. James R. Jordan Sr. a fost ucis la 23 iulie 1993, intr-o de odihna de pe autostrada în Lumberton, Carolina de Nord, de către doi adolescenți , Daniel Martin Demery verde și Larry. Atacatorii au fost trasate de apeluri au făcut apeluri de pe telefonul celular James Jordan, prins, condamnat, și condamnat la închisoare pe viață. Jordan a fost aproape de tatăl său ca un copil, având o înclinație de la el de a scoate limba în timp ce e absorbit în muncă. El,mai târziu a adoptat și semnătura proprie, de la afișarea ei de fiecare dată, la coș după coș. În 1996 el a fondat zona Chicago Boys & Girls Club și dedicat tatălui său.\n\n" +
                    "Jordan a scris că el a făcut pregătirea pentru pensionare cât mai devreme,in vara anului 1992. Epuizarea adăugată datorită „Dream Team”,în timpul Jocurile Olimpice de vară din 1992 a solidificat sentimentele lui Jordan despre joc și statutul său de celebritate în continuă creștere. Anuntul lui Jordan a trimis unde de șoc în întregul NBA și a apărut pe primele pagini ale ziarelor din întreaga lume. Jordan a surprins și mai mult lumea sportului prin semnarea unui contract de baseball minor in liga cu Chicago White Sox. El a confirmat la primvara de formare și a fost repartizat la sistemul echipei de ligă minoră pe 31 martie 1994.[43] Jordan a declarat că această decizie a fost luată ca să urmarească visul tatălui său, care și l-a imaginat mereu pe fiul său ca un jucător Major League Baseball.\n\n" +
                    "Jordan a jucat în două echipe olimpice care au câștigat aurul la basket. În facultate a participat la jocurile olimpice de vară din anul Jocurile Olimpice de vară din 1984 și a câștigat. Jordan a condus echipa marcând în medie 17,1 puncte pe meci în timpul campionatului. În jocurile olimpice din anul Jocurile Olimpice de vară din 1992 a fost membru al unei echipe pline de staruri împreună cu Magic Johnson, Larry Bird, and David Robinson echipa a fost denumită ”Dream team”(echipa de vis). A jucat minute limitate datorită unor probleme personale, jordan a înscris în medie 12,7 puncte pe meci, ieșind al patrulea din echipă la marcaj. Jordan, Patrick Ewing și un alt membru alt membru al „Echipei de vis”, Chris Mullin sunt singurii jucători de basket masculin din America care au câștigat aurul olimpic atât ca amatori (în 1984), dar și ca profesioniști. În plus jordan și un alt membru al „Echipei de vis” (un coechipier de la Bulls) Scottie Pippen sunt singurii jucători care au câștigat atât campionatul de NBA cât și aurul olimpic în același an (1992).\n\n"
                };

                sportsCategory.LearnLevels.Add(learnLevel3Sports);

                var learnQuestion1LearnLevel3Sports = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Câte puncte a marcat in echipa McDonald's All-American-Team la finalul sezonului in anul 1980 ?",
                };
                learnLevel3Sports.LearnQuestions.Add(learnQuestion1LearnLevel3Sports);

                var learnQuestionAnswer1Question1LearnLevel3Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "19.3",
                    IsCorrect = false
                };
                learnQuestion1LearnLevel3Sports.LearnQuestionAnswers.Add(learnQuestionAnswer1Question1LearnLevel3Sports);

                var learnQuestionAnswer2Question1LearnLevel3Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "15.7",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question1LearnLevel3Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "29.2",
                    IsCorrect = true
                };

                var learnQuestionAnswer4Question1LearnLevel3Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "11.6",
                    IsCorrect = false
                };

                learnQuestion1LearnLevel3Sports.LearnQuestionAnswers.Add(learnQuestionAnswer2Question1LearnLevel3Sports);
                learnQuestion1LearnLevel3Sports.LearnQuestionAnswers.Add(learnQuestionAnswer3Question1LearnLevel3Sports);
                learnQuestion1LearnLevel3Sports.LearnQuestionAnswers.Add(learnQuestionAnswer4Question1LearnLevel3Sports);


                var learnQuestion2LearnLevel3Sports = new LearnQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "După moartea tatălui său, ce zonă a fondat Michael Jordan, în semn de recunostinta?",
                };
                learnLevel3Sports.LearnQuestions.Add(learnQuestion2LearnLevel3Sports);

                var learnQuestionAnswer1Question2LearnLevel3Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "Orlando Magic",
                    IsCorrect = false
                };
                learnQuestion2LearnLevel3Sports.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel3Sports);

                var learnQuestionAnswer2Question2LearnLevel3Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "Chicago Boys & Girls Club",
                    IsCorrect = true
                };

                var learnQuestionAnswer3Question2LearnLevel3Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "Scottsdale Arizona",
                    IsCorrect = false
                };

                var learnQuestionAnswer4Question2LearnLevel3Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "Forbes Stars",
                    IsCorrect = false
                };

                learnQuestion2LearnLevel3Sports.LearnQuestionAnswers.Add(learnQuestionAnswer2Question2LearnLevel3Sports);
                learnQuestion2LearnLevel3Sports.LearnQuestionAnswers.Add(learnQuestionAnswer3Question2LearnLevel3Sports);
                learnQuestion2LearnLevel3Sports.LearnQuestionAnswers.Add(learnQuestionAnswer4Question2LearnLevel3Sports);

                categoryRepository.Update(sportsCategory);


                //--------------



                var geographyCategory = categoryRepository.GetCategoryByName("Geografie");

                var learnLevel1Geography = new LearnLevelEntity()
                {
                    LearnLevelNumber = 1,
                    //TODO Petros -> change these 2 lines
                    Image = "https://www.tititudorancea.com/lib/edfiles/bp/romap328.gif",
                    Text = "GEOGRAFIA ROMANIEI \n\n\n" +
                           "Asezare geografica: in sud-estul Europei; are iesire la Marea Neagra; situata intre Bulgaria si Ucraina. \n\n" +
                           "Coordonate geografice: 46° N, 25° E. \n\n" +
                           "Suprafata: totala 237,500 kmp, uscat 230,340 kmp, apa 7,160 kmp. \n\n" +
                           "Orase: Bucuresti (capitala, 2.02 milioane de locuitori), Iasi (350,000 de locuitori), Constanta (344,000 de locuitori), Timisoara (327,000 de locuitori), Cluj-Napoca (334,000 de locuitori), Galati (331,000 de locuitori), Brasov (316,000 de locuitori). \n\n" +
                           "Granite: total 2,508 km dintre care cu Bulgaria 608 km, Ungaria 443 km, Moldova 450 km, Serbia 476 km, Ucraina (la nord) 362 km, Ucraina (la est) 169 km. \n\n" +
                           "Coasta: 225 km. \n\n" +
                           "Drepturi maritime: ape teritoriale: 12 mn, zona adiacenta 24 mn, zona economica exclusiva 200 mn, platoul continental 200 m adancime sau la adancimea exploatarii. \n\n" +
                           "Climat: temperat; ierni reci, innorate cu ninsori frecvente si ceata; veri insorite cu averse de ploaie frecvente si furtuni cu descarcari electrice. \n\n" +
                           "Relief: alcatuit in principal din campii fertile, dealuri si un lant de munti care se intind de la nord la vest in centrul tarii si cunoscuti sub numele de muntii Carpati. \n\n" +
                           "Cote extreme: cea mai mica cota: 0 metri – Marea Neagra; cea mai mare cota: 2,544 metri – vf. Moldoveanu. \n\n" +
                           "Resurse naturale: petrol (rezerve in scadere), cherestea, gaze naturale, carbune, minereu de fier, sare, teren arabil, resurse hidroelectrice. \n\n" +
                           "Intrebuintarea terenului: teren arabil 39.49%, recolte permanente 1.92%, altele: 58.59%. \n\n" +
                           "Teren irigat: 30,770 kmp. \n\n" +
                           "Riscuri naturale: cutremure - foarte severe in sud si sud-est; structura geologica si clima contribuie la alunecarile de teren. \n\n" +
                           "Probleme actuale de mediu: eroziunea si degradarea solului; poluarea apei; poluarea aerului din cauza emisiilor industriale. \n\n" +
                           "Pozitia geo-strategica: controleaza cea mai usor traversabila ruta terestra dintre Balcani, Moldova si Ucraina. \n\n",
                    

            };
                
                geographyCategory.LearnLevels.Add(learnLevel1Geography);

                var learnQuestion1LearnLevel1Geography = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "România are cele mai mari granițe în km cu următoarele țări:",
                };
                learnLevel1Geography.LearnQuestions.Add(learnQuestion1LearnLevel1Geography);

                var learnQuestionAnswer1Question1LearnLevel1Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Ucraina și Serbia",
                    IsCorrect = false
                };
                learnQuestion1LearnLevel1Geography.LearnQuestionAnswers.Add(learnQuestionAnswer1Question1LearnLevel1Geography);

                var learnQuestionAnswer2Question1LearnLevel1Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Moldova și Bulgaria",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question1LearnLevel1Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Bulgaria și Ungaria",
                    IsCorrect = true
                };

                var learnQuestionAnswer4Question1LearnLevel1Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Moldova și Serbia",
                    IsCorrect = false
                };

                learnQuestion1LearnLevel1Geography.LearnQuestionAnswers.Add(learnQuestionAnswer2Question1LearnLevel1Geography);
                learnQuestion1LearnLevel1Geography.LearnQuestionAnswers.Add(learnQuestionAnswer3Question1LearnLevel1Geography);
                learnQuestion1LearnLevel1Geography.LearnQuestionAnswers.Add(learnQuestionAnswer4Question1LearnLevel1Geography);


                var learnQuestion2LearnLevel1Geography = new LearnQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Care este vârful cu cea mai mare cotă din România?",
                };
                learnLevel1Geography.LearnQuestions.Add(learnQuestion2LearnLevel1Geography);

                var learnQuestionAnswer1Question2LearnLevel1Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Vârful Omu",
                    IsCorrect = false
                };
                learnQuestion2LearnLevel1Geography.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel1Geography);

                var learnQuestionAnswer2Question2LearnLevel1Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Vârful Retezat",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question2LearnLevel1Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Vârful Paltinu",
                    IsCorrect = false
                };

                var learnQuestionAnswer4Question2LearnLevel1Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Vârful Moldoveanu",
                    IsCorrect = true
                };
                learnQuestion2LearnLevel1Geography.LearnQuestionAnswers.Add(learnQuestionAnswer2Question2LearnLevel1Geography);
                learnQuestion2LearnLevel1Geography.LearnQuestionAnswers.Add(learnQuestionAnswer3Question2LearnLevel1Geography);
                learnQuestion2LearnLevel1Geography.LearnQuestionAnswers.Add(learnQuestionAnswer4Question2LearnLevel1Geography);

                //-------------------------

                var learnLevel2Geography = new LearnLevelEntity()
                {
                    LearnLevelNumber = 2,
                    //TODO Petros -> change these 2 lines
                    Image = "https://www.tititudorancea.com/lib/edfiles/bp/ukmap.gif",
                    Text = "REGATUL UNIT AL MARII BRITANII \n\n\n" +
                           "Asezare geografica: in Europa de Vest; formata din insule; include o sesime din nordul insulei Irlanda; situata intre Oceanul Atlanticului de Nord si Marea Nordului, la nord-vest de Franta. \n\n" +
                           "Coordonate geografice: 54° N, 2° V. \n\n" +
                           "Suprafata: totala 244,820 kmp, uscat 241,590 kmp, apa 3,230 kmp. Nota: cuprinde insulele Rockall si Shetland. \n\n" +
                           "Orase: Londra (capitala), Manchester, Liverpool, Edinburgh, Glasgow, Cardiff, Belfast. \n\n" +
                           "Granite: total 360 km cu Irlanda. \n\n" +
                           "Coasta: 12,429 km. \n\n" +
                           "Drepturi maritime: ape teritoriale 12 mn, zona de pescuit exclusiva 200 mn, platoul continental, conform limitelor convenite. \n\n" +
                           "Climat: in general temperat; vremea variaza frecvent dar la extreme mici de temperatura; climatul este temperat de vanturile de sud-vest predominante in fata Curentului Atlanticului de Nord; mai mult de jumatate din zilele anului sunt innorate. \n\n" +
                           "Relief: preponderent dealuri accidentate si munti mici; campii in est si sud-est. \n\n" +
                           "Cote extreme: cea mai mica cota: -4 metri - The Fens; cea mai mare cota: 1,343 metri – varful Ben Nevis. \n\n" +
                           "Resurse naturale: carbune, petrol, gaze naturale, minereu de fier, plumb, zinc, aur, cositor, calcar, sare, argila, creta, ghips, potasiu, siliciu, gresie, teren arabil. \n\n" +
                           "Intrebuintarea terenului: teren arabil 25%, recolte permanente 0.2%, pajisti si pasuni 46%, paduri 10%, altele 19%. \n\n" +
                           "Teren irigat: 1,700 kmp. \n\n" +
                           "Riscuri naturale: iarna viscole; inundatii. \n\n" +
                           "Probleme actuale de mediu: continua sa reduca emisiile de gaze care genereaza efectul de sera; tinteste sa reduca cantitatea de deseuri industriale si comerciale ingropate si sa le recicleze sau sa le transforme in ingrasamant. \n\n" +
                           "Pozitia geo-strategica: este situata langa rutele maritime vitale din Oceanul Atlanticului de Nord; se afla la numai 35 de km departare de Franta si este legata de aceasta printr-un tunel sapat sub Canalul Manecii; deoarece coasta este puternic crestata, nici o asezare nu se afla mai departe de 125 km de fluxul apelor. \n\n"

                };

                geographyCategory.LearnLevels.Add(learnLevel2Geography);

                var learnQuestion1LearnLevel2Geography = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Care sunt potențialele riscuri naturale ce pot avea loc in Regatul Unit?",
                };
                learnLevel2Geography.LearnQuestions.Add(learnQuestion1LearnLevel2Geography);

                var learnQuestionAnswer1Question1LearnLevel2Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Tornade",
                    IsCorrect = false
                };
                learnQuestion1LearnLevel2Geography.LearnQuestionAnswers.Add(learnQuestionAnswer1Question1LearnLevel2Geography);

                var learnQuestionAnswer2Question1LearnLevel2Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Cutremure de pământ",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question1LearnLevel2Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Inundații",
                    IsCorrect = true
                };

                var learnQuestionAnswer4Question1LearnLevel2Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Alunecări de teren",
                    IsCorrect = false
                };

                learnQuestion1LearnLevel2Geography.LearnQuestionAnswers.Add(learnQuestionAnswer2Question1LearnLevel2Geography);
                learnQuestion1LearnLevel2Geography.LearnQuestionAnswers.Add(learnQuestionAnswer3Question1LearnLevel2Geography);
                learnQuestion1LearnLevel2Geography.LearnQuestionAnswers.Add(learnQuestionAnswer4Question1LearnLevel2Geography);


                var learnQuestion2LearnLevel2Geography = new LearnQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Cum este relieful în Regatul Unit?",
                };
                learnLevel2Geography.LearnQuestions.Add(learnQuestion2LearnLevel2Geography);

                var learnQuestionAnswer1Question2LearnLevel2Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Preponderent dealuri accidentate și munți mici",
                    IsCorrect = true
                };

                learnQuestion2LearnLevel2Geography.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel2Geography);

                var learnQuestionAnswer2Question2LearnLevel2Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Alcătuit din câmpii fertile și dealuri",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question2LearnLevel2Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Păduri întinse de conifere și tundră",
                    IsCorrect = false
                };

                var learnQuestionAnswer4Question2LearnLevel2Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Predomină lanțurile muntoase",
                    IsCorrect = false
                };

                learnQuestion2LearnLevel2Geography.LearnQuestionAnswers.Add(learnQuestionAnswer2Question2LearnLevel2Geography);
                learnQuestion2LearnLevel2Geography.LearnQuestionAnswers.Add(learnQuestionAnswer3Question2LearnLevel2Geography);
                learnQuestion2LearnLevel2Geography.LearnQuestionAnswers.Add(learnQuestionAnswer4Question2LearnLevel2Geography);


                //---------------------

                var learnLevel3Geography = new LearnLevelEntity()
                {
                    LearnLevelNumber = 3,
                    //TODO Petros -> change these 2 lines
                    Image = "https://www.tititudorancea.com/lib/edfiles/gm/brazilmaprowm334.jpg",
                    Text = "BRAZILIA \n\n\n" +
                           "Asezare geografica: Estul Americii de Sud, se invecineaza cu Oceanul Atlantic.\n\n" +
                           "Coordonate geografice: 10° 00` S, 55° 00` W.\n\n" +
                           "Suprafata: totala 8 514 877 kmp, uscat 8 459 417 kmp, apa 55 460 kmp.Nota: include Arquipelago de Fernando de Noronha, Atol das Rocas, Ilha da Trindade, Ilhas Martin Vaz si Penedos de Sao Pedro e Sao Paulo\n\n" +
                           "Granite terestre: 16 885 km.tarile de frontiera: Argentina 1 261 km, Bolivia 3 423 km, Columbia 1 644 km, Guyana Franceză 730 km, Guyana 1 606 km, Paraguay 1 365 km, Peru 2 995 km, Surinam 593 km, 1 068 km Uruguay, Venezuela 2 200 km\n\n" +
                           "Coasta: 7 491 km\n\n" +
                           "Drepturi maritime: ape teritoriale: 12 mnape teritoriale: 24 mn.zona economica exclusiva: 200 mnplatoul continental: 200 mn sau la marginea continentala\n\n" +
                           "Climat: cea mai mare parte tropical, dar temperat in sud.\n\n" +
                           "Relief: cea mai mare parte plat pana la deluros in nord; unele campii, dealuri, munti, si centura ingusta de coasta.\n\n" +
                           "Cote extreme: cea mai mica cota: Oceanul Atlantic 0 m; cea mai mare cota: Pico da Neblina 2 994 m.\n\n" +
                           "Resurse naturale: bauxita, aur, minereu de fier, nichel mangan, fosfati, platina, staniu, elemente de pamanturi rare, uraniu, petrol, hidroenergie, material lemnos.\n\n" +
                           "Intrebuintarea terenului: teren arabil 6,93%, culturi permanente 0,89%, altele 92,18%.\n\n" +
                           "Teren irigat: 29 200 kmp\n\n" +
                           "Total resurse regenerabile de apa: 8 233 km cubi\n\n" +
                           "Rezervele de apa dulce (domestic / industrial / agricol): total 59,3 km cubi/an (20% / 18% / 62%)pe cap de locuitor: 318 metri cubi/ an\n\n" +
                           "Riscuri naturale: secete recurente in nord-est; inundatii si inghet ocazional in sud.\n\n" +
                           "Probleme actuale de mediu: despadurirea in Bazinul Amazonului distruge habitatul si pune in pericol o multitudine de specii de plante si animale indigene; este un comert profitabil, ilegal, cu specii salbatice; poluarea aerului si a apei din Rio de Janeiro, Sao Paulo si alte cateva mari orase; degradarea terenurilor si poluarea apei cauzata de activitatile miniere improprii; degradarea zonelor umede; deversari de petrol severe.\n\n" +
                           "Mediu - acorduri internationale: parte la tratatele privind: Antarctica-protocolul mediului, Resurse marine vii din Antarctica, Focile din Antarctica, Tratatul asupra Antarcticii, Biodiversitate, Schimbarile climatice, Schimbarile climatice-Protocolul de la Kyoto, Desertificarea, Specii pe cale de disparitie, Modificarea mediului, Deseuri periculoase, Legea marii, Poluarea marii, Protectia stratului de ozon, Poluare cauzata de nave, Esentele de lemn tropical 83, Esentele de lemn tropical 94, Zone umede, Vanatoarea de balene.tratate semnate,dar neratificate: nici unul dintre acordurile selectate.\n\n" +
                           "Pozitia geo-strategica: cea mai mare tara din America de Sud; granite comune cu fiecare tara din America de Sud, cu exceptia Chile si Ecuador.\n\n"
                           
                };

                geographyCategory.LearnLevels.Add(learnLevel3Geography);

                var learnQuestion1LearnLevel3Geography = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Brazilia are granițe comune cu fiecare țară din America de Sud, cu excepția:",
                };
                learnLevel3Geography.LearnQuestions.Add(learnQuestion1LearnLevel3Geography);

                var learnQuestionAnswer1Question1LearnLevel3Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Peru și Venezuela",
                    IsCorrect = false
                };
                learnQuestion1LearnLevel3Geography.LearnQuestionAnswers.Add(learnQuestionAnswer1Question1LearnLevel3Geography);

                var learnQuestionAnswer2Question1LearnLevel3Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Surinam și Guyana",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question1LearnLevel3Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Columbia și Paraguay",
                    IsCorrect = false
                };

                var learnQuestionAnswer4Question1LearnLevel3Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Chile și Ecuador",
                    IsCorrect = true
                };

                learnQuestion1LearnLevel3Geography.LearnQuestionAnswers.Add(learnQuestionAnswer2Question1LearnLevel3Geography);
                learnQuestion1LearnLevel3Geography.LearnQuestionAnswers.Add(learnQuestionAnswer3Question1LearnLevel3Geography);
                learnQuestion1LearnLevel3Geography.LearnQuestionAnswers.Add(learnQuestionAnswer4Question1LearnLevel3Geography);


                var learnQuestion2LearnLevel3Geography = new LearnQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Care sunt coordonatele geografice ale Braziliei?",
                };
                learnLevel3Geography.LearnQuestions.Add(learnQuestion2LearnLevel3Geography);

                var learnQuestionAnswer1Question2LearnLevel3Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "20° 00` N, 60° 00` E",
                    IsCorrect = false
                };
                learnQuestion2LearnLevel3Geography.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel3Geography);

                var learnQuestionAnswer2Question2LearnLevel3Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "10° 00` S, 55° 00` W",
                    IsCorrect = true
                };

                var learnQuestionAnswer3Question2LearnLevel3Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "35° 00` N, 75° 00` E",
                    IsCorrect = false
                };

                var learnQuestionAnswer4Question2LearnLevel3Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "15° 00` S, 40° 00` W",
                    IsCorrect = false
                };

                learnQuestion2LearnLevel3Geography.LearnQuestionAnswers.Add(learnQuestionAnswer2Question2LearnLevel3Geography);
                learnQuestion2LearnLevel3Geography.LearnQuestionAnswers.Add(learnQuestionAnswer3Question2LearnLevel3Geography);
                learnQuestion2LearnLevel3Geography.LearnQuestionAnswers.Add(learnQuestionAnswer4Question2LearnLevel3Geography);

                categoryRepository.Update(geographyCategory);

                //-----------------------//

                var musicCategory = categoryRepository.GetCategoryByName("Muzică");

                var learnLevel1Music = new LearnLevelEntity()
                {
                    LearnLevelNumber = 1,
                    //TODO Petros -> change these 2 lines
                    Image ="https://i.ytimg.com/vi/GhNkPKzp-NE/maxresdefault.jpg",
                    Text = "HOLOGRAF \n\n\n" +
                           "Holograf este o formație românească de muzică rock înființată la București în 1977, de muzicianul Mihai Pocorschi. Holograf este printre cele mai de succes trupe din România, fiecare dintre albumele lor conținând câteva cântece care au ajuns hit-uri în România. Formația este în continuare foarte activă și realizează turnee lungi, cu concerte foarte bine primite de public.\n\n" +
                           "În anii 1990 trupa și-a schimbat stilul într-un rock modern.\n\n" +
                           "Printre cele mai cunoscute hituri realizate de Holograf sunt „Umbre pe cer”, „Singur pe drum”, „Ochii tăi”, „Banii vorbesc”, „Dincolo de nori”, „Ți-am dat un inel”, „Undeva departe”, „Să nu-mi iei niciodată dragostea”, „Vine o zi...”, „Viața are gust”, „Dragostea mea”, „Cât de departe”.\n\n" +
                           "În ciuda unor zvonuri care afirmau că Holograf s-ar fi despărțit în 2015, conform propriului lor site web,formația a concertat în Piatra Neamț în 12 mai 2015, la Sala Polivalentă. Dan Bittman își urmează în continuare cariera solo, cu noi piese, una dintre ele fiind „Și îngerii au demonii lor”, dar asta nu are nimic de-a face cu activitatea în cadrul grupului din care face parte începând cu anul 1985.\n\n" +
                           "Discografia formației Holograf cuprinde aproape 30 de materiale audio și video, lansate de-a lungul celor patru decenii de existență a grupului. Holograf a debutat discografic în anul 1978, cu piesa „Lungul drum al zilei către noapte” (solist vocal Ștefan Rădescu), inclusă pe albumul colectiv Formații de muzică pop 3 din cadrul seriei Formații rock, editată de casa de discuri Electrecord. Primul album integral semnat Holograf a apărut în anul 1983, avându-l ca solist vocal pe Gabriel Cotabiță. După ce Dan Bittman a preluat rolul de vocalist în Holograf în 1985, au urmat alte 11 albume de studio, cel mai recent, intitulat Life Line, fiind lansat în noiembrie 2015. În 1990 a apărut singurul maxi-single al formației, ce include patru piese. Un alt maxi-single a fost lansat de Dan Bittman (ca disc solo) în 1994, anul în care solistul de la Holograf a reprezentat România în cadrul concursului Eurovision. Discografia Holograf este completată de două albume înregistrate acustic în concert (69% Unplugged - Live și Patria Unplugged), un disc promoțional din concert (Live - Vinarte), cinci compilații (cu o parte dintre piese reînregistrate special pentru apariția acestor discuri „best of”) și patru materiale video, filmate în concert.\n\n" +
                           "Albume de studio \n\n" +
                           "Holograf 1 (1983)\n\n" +
                           "Holograf 2 (1987)\n\n" +
                           "Holograf III (1988)\n\n" +
                           "Banii vorbesc (1991)\n\n" +
                           "World Full of Lies (1993, reeditat în 2013)\n\n" +
                           "Stai în poala mea (1995)\n\n" +
                           "Supersonic (1998, reeditat în 2000)\n\n" +
                           "Holografica (2000)\n\n" +
                           "Pur și simplu (2003, reeditat în 2013)\n\n" +
                           "Taina (, 2006, reeditat în 2013)\n\n" +
                           "Love Affair (2012)\n\n" +
                           "Life Line (2015)\n\n"

                };

                musicCategory.LearnLevels.Add(learnLevel1Music);

                var learnQuestion1LearnLevel1Music = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Câte albume au reeditat trupa Holograf?",
                };
                learnLevel1Music.LearnQuestions.Add(learnQuestion1LearnLevel1Music);

                var learnQuestionAnswer1Question1LearnLevel1Music = new LearnQuestionAnswerEntity()
                {
                    Text = "1",
                    IsCorrect = false
                };
                learnQuestion1LearnLevel1Music.LearnQuestionAnswers.Add(learnQuestionAnswer1Question1LearnLevel1Music);

                var learnQuestionAnswer2Question1LearnLevel1Music = new LearnQuestionAnswerEntity()
                {
                    Text = "2",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question1LearnLevel1Music = new LearnQuestionAnswerEntity()
                {
                    Text = "3",
                    IsCorrect = false
                };
                var learnQuestionAnswer4Question1LearnLevel1Music = new LearnQuestionAnswerEntity()
                {
                    Text = "4",
                    IsCorrect = true
                };

                learnQuestion1LearnLevel1Music.LearnQuestionAnswers.Add(learnQuestionAnswer2Question1LearnLevel1Music);
                learnQuestion1LearnLevel1Music.LearnQuestionAnswers.Add(learnQuestionAnswer3Question1LearnLevel1Music);
                learnQuestion1LearnLevel1Music.LearnQuestionAnswers.Add(learnQuestionAnswer4Question1LearnLevel1Music);


                var learnQuestion2LearnLevel1Music = new LearnQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Cum se numeste piesa cu care au debutat discografic trupa Holograf?",
                };
                learnLevel1Music.LearnQuestions.Add(learnQuestion2LearnLevel1Music);

                var learnQuestionAnswer1Question2LearnLevel1Music = new LearnQuestionAnswerEntity()
                {
                    Text = "Umbre pe cer",
                    IsCorrect = false
                };
                learnQuestion2LearnLevel1Music.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel1Music);

                var learnQuestionAnswer2Question2LearnLevel1Music = new LearnQuestionAnswerEntity()
                {
                    Text = "Banii vorbesc",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question2LearnLevel1Music = new LearnQuestionAnswerEntity()
                {
                    Text = "Lungul drum al zilei către noapte",
                    IsCorrect = true
                };

                var learnQuestionAnswer4Question2LearnLevel1Music = new LearnQuestionAnswerEntity()
                {
                    Text = "Singur pe drum",
                    IsCorrect = false
                };
                learnQuestion2LearnLevel1Music.LearnQuestionAnswers.Add(learnQuestionAnswer2Question2LearnLevel1Music);
                learnQuestion2LearnLevel1Music.LearnQuestionAnswers.Add(learnQuestionAnswer3Question2LearnLevel1Music);
                learnQuestion2LearnLevel1Music.LearnQuestionAnswers.Add(learnQuestionAnswer4Question2LearnLevel1Music);

                //-------------------------

                var learnLevel2Music = new LearnLevelEntity()
                {
                    LearnLevelNumber = 2,
                    //TODO Petros -> change these 2 lines
                    Image = "https://www.rollingstone.com/wp-content/uploads/2018/08/best-deepcut-abba-songs-sheffield.jpg?resize=1800,1200&w=1800",
                    Text = "ABBA \n\n\n" +
                           "ABBA este o formație suedeză de muzică pop activă din 1972 până în 1982, reunindu-se în 2018. Trupa este formată din muzicienii Benny Andersson și Björn Ulvaeus, Anni-Frid Lyngstad și Agnetha Fältskog. Cei patru au dominat clasamentele muzicale mondiale între mijlocul anilor 1970 și începutul anilor 1980.\n\n" +
                           "Titulatura formației ABBA este un acronim, provenind de la inițialele prenumelor celor patru protagoniști: Agnetha Falkstog, Benny Andersson, Bjorn Ulvaeus si Anni-Frid Lingvstad.\n\n" +
                           "Grupul a vândut peste 370 de milioane de înregistrări până în prezent. ABBA este de asemenea primul grup pop din Europa continentală care s-a bucurat de mare succes în clasamentele lumii anglofone (în principal în Regatul Unit, Statele Unite, Canada, Australia și Noua Zeelandă), iar ca urmare a popularității sale enorme li s-au deschis apoi și ușile scenelor Europei continentale.\n\n" +
                           "Înainte de a se forma faimosul grup pop care a dominat artistic anii '70, fiecare dintre cei patru componenți s-a afirmat în viața muzicală: Björn cu Hootenanny Singers la începutul anilor '60, Benny ca lider la The Hep Stars, Agnetha înregistra din 1967, având deja la activ câteva hit-uri, iar Anni-Frid își construise o carieră solistică, în parte și cu ajutorul lui Benny, alături de care se afla din 1970.\n\n" +
                           "În 1967, Bjorn și Benny au realizat prima lor melodie, iar spre sfârșitul anului au stabilit un parteneriat ca și compozitori. Tot în această perioadă Benny a părăsit grupul The Hep Stars în timp ce Hootenanny Singers devine o formație doar de studio. Cel care avea să devină managerul formației ABBA a fost Stig Anderson, care a contribuit și la scrierea versurilor multora dintre hit-urile formației ABBA în perioada primilor ani de carieră. În primăvara anului 1969, Bjorn și Benny le-au cunoscut pe Agnetha Fältskog și Anni-Frid Lyngstad. Odată cu apariția lui Benny și Björn ca duo pe disc și în spectacole, cu cele două fete apărând ca back-up vocal, ideea cvartetului începe să prindă viață.\n\n" +
                           "În 1975 a fost lansat albumul ABBA, cuprinzând hiturile: I do, I Do, I Do, I Do, I Do; S.O.S.; Mamma Mia. În Australia grupul devine extrem de popular, albumul fiind pe locul 1 luni de zile. Filmul ABBA - The Movie, turnat în cursul turneului în Australia, deține până în ziua de azi recordul de audiență, cu 54% de spectatori din întreaga populație.\n\n" +
                           "1976 este anul în care ABBA a fost declarată una din cele mai populare formații din lume. Cel de-al 4-lea album al formației, Arrival, a fost finalizat la sfârșitul anului 1976, și cuprinde hiturile: Fernando; Dancing Queen; Money, Money, Money; Knowing me, knowing you. În 1977, ABBA a efectuat un mare turneu mondial și doi ani mai târziu cântă în Statele Unite. Discurile single și albumele se succed într-o cursă amețitoare, în aprilie 1977, Dancing Queen devine numărul 1 în Marea Britanie.\n\n" +
                           "Succesul financiar al grupului aduce economiei suedeze venituri mai mari decât cele ale companiei de autoturisme, Volvo.\n\n" +
                           "În 1977, s-a lansat The Album, printre piese numărându-se și piesele: Eagle; Take a Chance on Me; The name of the game și Thank you for the music.\n\n"
                           
                };

                musicCategory.LearnLevels.Add(learnLevel2Music);

                var learnQuestion1LearnLevel2Music = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "În ce an a fost lansat albumul “Arrival” de către ABBA?",
                };
                learnLevel2Music.LearnQuestions.Add(learnQuestion1LearnLevel2Music);

                var learnQuestionAnswer1Question1LearnLevel2Music = new LearnQuestionAnswerEntity()
                {
                    Text = "1976",
                    IsCorrect = true
                };
                learnQuestion1LearnLevel2Music.LearnQuestionAnswers.Add(learnQuestionAnswer1Question1LearnLevel2Music);

                var learnQuestionAnswer2Question1LearnLevel2Music = new LearnQuestionAnswerEntity()
                {
                    Text = "1979",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question1LearnLevel2Music = new LearnQuestionAnswerEntity()
                {
                    Text = "1977",
                    IsCorrect = false
                };

                var learnQuestionAnswer4Question1LearnLevel2Music = new LearnQuestionAnswerEntity()
                {
                    Text = "1975",
                    IsCorrect = false
                };

                learnQuestion1LearnLevel2Music.LearnQuestionAnswers.Add(learnQuestionAnswer2Question1LearnLevel2Music);
                learnQuestion1LearnLevel2Music.LearnQuestionAnswers.Add(learnQuestionAnswer3Question1LearnLevel2Music);
                learnQuestion1LearnLevel2Music.LearnQuestionAnswers.Add(learnQuestionAnswer4Question1LearnLevel2Music);


                var learnQuestion2LearnLevel2Music = new LearnQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Cum s-a numit grupul pe care l-a părăsit Benny Andersson înainte de a se forma ABBA?",
                };
                learnLevel2Music.LearnQuestions.Add(learnQuestion2LearnLevel2Music);

                var learnQuestionAnswer1Question2LearnLevel2Music = new LearnQuestionAnswerEntity()
                {
                    Text = "Hootenanny Singers",
                    IsCorrect = false
                };

                learnQuestion2LearnLevel2Music.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel2Music);

                var learnQuestionAnswer2Question2LearnLevel2Music = new LearnQuestionAnswerEntity()
                {
                    Text = "The Visitors",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question2LearnLevel2Music = new LearnQuestionAnswerEntity()
                {
                    Text = "The Hep Stars",
                    IsCorrect = true
                };

                var learnQuestionAnswer4Question2LearnLevel2Music = new LearnQuestionAnswerEntity()
                {
                    Text = "Erasure",
                    IsCorrect = false
                };

                learnQuestion2LearnLevel2Music.LearnQuestionAnswers.Add(learnQuestionAnswer2Question2LearnLevel2Music);
                learnQuestion2LearnLevel2Music.LearnQuestionAnswers.Add(learnQuestionAnswer3Question2LearnLevel2Music);
                learnQuestion2LearnLevel2Music.LearnQuestionAnswers.Add(learnQuestionAnswer4Question2LearnLevel2Music);


                //---------------------

                var learnLevel3Music = new LearnLevelEntity()
                {
                    LearnLevelNumber = 3,
                    //TODO Petros -> change these 2 lines
                    Image = "https://api.time.com/wp-content/uploads/2015/12/the-beatles2.jpg",
                    Text = "THE BEATLES \n\n\n" +
                           "The Beatles a fost unul dintre grupurile a cărui muzică a fost cea mai influentă pentru Era Rock care a urmat. Grupul a fost alcătuit din John Lennon (vocal, chitară ritmică), Paul McCartney (vocal, chitară bas), George Harrison (chitară solo) și Ringo Starr (baterie).\n\n" +
                           "Inițial The Four Fabs au avut ca țintă generațiile de tineri rezultate de după al Doilea Război Mondial, în special în țările de limbă engleză, precum Regatul Unit, SUA, Canada și Australia, dar au devenit după anul lor cel mai glorios, 1964, iubiți și admirați de multiple generații. Judecând după multiple criterii, dintre care vânzările muzicale ocupă un loc însemnat, -The Beatles- este unul din cele mai faimoase și de succes grupuri în istoria muzicii rock, contorizând peste 1,1 miliarde de discuri vândute în lumea întreagă.\n\n" +
                           "În timp ce inițial au devenit faimoși pentru ceea ce unii au etichetat drept muzică pop, lucrările lor de mai târziu au realizat o combinație de laude atât din partea criticilor cât și din partea ascultătorilor inegalată în secolul XX. În cele din urmă, ei și-au dovedit nu doar talentul de muzicieni, au pășit granița spre cinematografie, și în particular, în cazul lui John Lennon este vorba de activism politic.\n\n" +
                           "În 2004 revista Rolling Stone clasa trupa The Beatles pe locul 1 pe lista celor 100 cei mai mari artiști ai tuturor timpurilor. În conformitate cu aceeași revistă, muzica inovativă a trupei The Beatles și impactul cultural au ajutat la definirea anilor 1960.\n\n" +
                           "În 1954, John Lennon, elev la Quarry Bank High School, reunind pe câțiva dintre colegii de școală, formează grupul -Blackjacks-, pe care îl schimbă ulterior în -The Quarrymen-, după ce află că un grup local respectat avea același nume.\n\n" +
                           "Paul McCartney l-a cunoscut pe John Lennon pe 6 iulie 1957 și a intrat în formația acestuia, la 15 ani, după ce l-a impresionat pe John cu partitura unei versiuni propii după un cântec la modă al lui Eddie Cochran. McCartney l-a chemat, în februarie 1958, pe George Harrison să asculte trupa. A dat ulterior o audiție pentru a deveni membru, însă Lennon considera că este prea tânăr (Harrison avea atunci abia 14 ani), însă după o lună de insistențe, l-a acceptat ca și chitarist principal. În ianuarie 1959, prietenii lui Lennon de la Quarry Bank High School au părăsit grupul iar el a îneput studiile la Liverpool College of Art. Cei trei cântau rock and roll de fiecare dată când găseau un toboșar. Prietenul lui Lennon de la colegiu, Stuart Sutcliffe, care își vânduse recent una dintre picturi, a fost convins să-și cumpere o chitară bass și a intrat în trupă în ianuarie 1960. El a fost cel care a sugerat ca numele să fie schimbat în Beetles, ca un tribut către Buddy Holly și The Crickets („Greierii”). S-a păstrat conceptul de „insectă” (beetle) și a fost combinat cu conceptul muzical de bătaie a măsurii (beat). Ei au folosit acest nume până în mai, când au devenit The Silver Beetles. La începutul lui iulie, și-au schimbat numele în The Silver Beatles, iar apoi, la mijlocul lui august, în The Beatles.\n\n" +
                           "În acea perioadă, la baterie era Pete Best. Cântau într-un mic club numit Casbah; apoi întreprind un turneu la Hamburg. În decembrie 1961, Brian Epstein devine impresarul lor.\n\n" +
                           "În aprilie - mai 1962, fiind angajați la -Star Club- din Hamburg, cântă ocazional cu bateristul Ringo Starr (pe numele său adevărat Richard Starkey) din formația Rory Storm and the Hurricanes.\n\n" +
                           "În august 1962 Ringo Starr este cooptat în trupă; înlocuindu-l astfel pe Best, distribuția Beatles devine completă. În același an, George Martin, producător al casei Parlophone (membră a EMI), acceptă, la insistențele lui Brian Epstein, o audiere a Beatles-ilor. Este semnat imediat un prim contact.\n\n" +
                           "La 5 octombrie 1962 formația și-a lansat discul de debut Love Me Do pe partea A și P.S. I Love You pe partea B. La 26 noiembrie 1963, Beatles înregistrează al doilea disc Please Please Me care va ajunge numărul doi în topul oficial al Marii Britanii.\n\n" +
                           "Lennon a afectat imaginea The Beatles, în anul următor, când a afirmat într-un interviu că, religia creștină este pe moarte, susținînd că Beatles e mai populară ca Iisus. În cele din urmă, și-a cerut scuze, după ce a fost criticat foarte dur de către grupuri religioase, după ce albumele lor au fost interzise sau chiar arse în țări din America de Sud, și după ce au primit amenințări din partea unor grupuri ca Ku Klux Klan.\n\n" +
                           "The Beatles, după concertul din Candlestick Park, din San Francisco, pe 29 august 1966, și-au concentrat forțele în studioul de înregistrări, noile compoziții și experimente muzicale ridicându-le reputația artistică în mod remarcabil păstrându-și totuși uriașa popularitate. Însă, soarta financiară a grupului a luat o întorsătură nefavorabilă atunci când managerul lor, Brian Epstein, a murit pe 27 august 1967.\n\n" +
                           "După aceasta, membrii trupei și-au urmat interesele individuale și s-au întâlnit tot mai rar. Ultimul lor concert este considerat a fi apariția live pe acoperișul studio-urilor Apple, din Londra, în ianuarie 1969, și a apărut compilat în albumul -Let It Be-. În iulie 1969 trupa s-a reunit pentru a înregistra albumul Abbey Road. Oficial, Beatles s-a destrămat în 1970, și orice speranță a unei reuniuni a fost zdrobită când Lennon a fost asasinat de către Mark David Chapman în 1980. Totuși, o reuniune virtuală a avut loc în 1995, odată cu lansarea a două înregistrări ale lui Lennon, la care și-au adus contribuția și ceilalți 3 membri Beatles. Au rezultat piesele -Free as a Bird- și -Real Love-.Au mai fost lansate,de asemenea,3 albume ce conțineau material nelansat anterior,precum și un documentar,proiect cunoscut sub numele The Beatles Anthology.\n\n"
                           
                           
                };

                musicCategory.LearnLevels.Add(learnLevel3Music);

                var learnQuestion1LearnLevel3Music = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Care este evenimentul ce a declansat prăbușirea trupei The Beatles?",
                };
                learnLevel3Music.LearnQuestions.Add(learnQuestion1LearnLevel3Music);

                var learnQuestionAnswer1Question1LearnLevel3Music = new LearnQuestionAnswerEntity()
                {
                    Text = "Moartea lui Brian Epstein",
                    IsCorrect = true
                };
                learnQuestion1LearnLevel3Music.LearnQuestionAnswers.Add(learnQuestionAnswer1Question1LearnLevel3Music);

                var learnQuestionAnswer2Question1LearnLevel3Music = new LearnQuestionAnswerEntity()
                {
                    Text = "John Lennon afirmă “religia creștină este pe moarte”",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question1LearnLevel3Music = new LearnQuestionAnswerEntity()
                {
                    Text = "Diversele experimente muzicale",
                    IsCorrect = false
                };

                var learnQuestionAnswer4Question1LearnLevel3Music = new LearnQuestionAnswerEntity()
                {
                    Text = "Asasinarea lui John Lennon",
                    IsCorrect = false
                };

                learnQuestion1LearnLevel3Music.LearnQuestionAnswers.Add(learnQuestionAnswer2Question1LearnLevel3Music);
                learnQuestion1LearnLevel3Music.LearnQuestionAnswers.Add(learnQuestionAnswer3Question1LearnLevel3Music);
                learnQuestion1LearnLevel3Music.LearnQuestionAnswers.Add(learnQuestionAnswer4Question1LearnLevel3Music);


                var learnQuestion2LearnLevel3Music = new LearnQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Care a fost ordinea denumirilor trupei inainte de a se numi The Beatles?",
                };
                learnLevel3Music.LearnQuestions.Add(learnQuestion2LearnLevel3Music);

                var learnQuestionAnswer1Question2LearnLevel3Music = new LearnQuestionAnswerEntity()
                {
                    Text = "The Quarrymen, Blackjacks, Beetles, The Silver Beetles, The Silver Beatles ",
                    IsCorrect = false
                };
                learnQuestion2LearnLevel3Music.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel3Music);

                var learnQuestionAnswer2Question2LearnLevel3Music = new LearnQuestionAnswerEntity()
                {
                    Text = "Blackjacks, The Quarrymen, Beetles, The Silver Beetles, The Silver Beatles",
                    IsCorrect = true
                };

                var learnQuestionAnswer3Question2LearnLevel3Music = new LearnQuestionAnswerEntity()
                {
                    Text = "Blackjacks, The Quarrymen, The Silver Beetles, Beetles, The Silver Beatles",
                    IsCorrect = false
                };

                var learnQuestionAnswer4Question2LearnLevel3Music = new LearnQuestionAnswerEntity()
                {
                    Text = "The Quarrymen, Blackjacks, The Silver Beetles, Beetles, The Silver Beatles ",
                    IsCorrect = false
                };

                learnQuestion2LearnLevel3Music.LearnQuestionAnswers.Add(learnQuestionAnswer2Question2LearnLevel3Music);
                learnQuestion2LearnLevel3Music.LearnQuestionAnswers.Add(learnQuestionAnswer3Question2LearnLevel3Music);
                learnQuestion2LearnLevel3Music.LearnQuestionAnswers.Add(learnQuestionAnswer4Question2LearnLevel3Music);

                categoryRepository.Update(musicCategory);

                //----------------//

                var celebritiesCategory = categoryRepository.GetCategoryByName("Celebrități");

                var learnLevel1Celebrities = new LearnLevelEntity()
                {
                    LearnLevelNumber = 1,
                    //TODO Petros -> change these 2 lines
                    Image = "",
                    Text = " \n\n\n" 
                    };

                celebritiesCategory.LearnLevels.Add(learnLevel1Celebrities);

                var learnQuestion1LearnLevel1Celebrities = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "",
                };
                learnLevel1Celebrities.LearnQuestions.Add(learnQuestion1LearnLevel1Celebrities);

                var learnQuestionAnswer1Question1LearnLevel1Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };
                learnQuestion1LearnLevel1Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer1Question1LearnLevel1Celebrities);

                var learnQuestionAnswer2Question1LearnLevel1Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };

                var learnQuestionAnswer3Question1LearnLevel1Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var learnQuestionAnswer4Question1LearnLevel1Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                learnQuestion1LearnLevel1Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer2Question1LearnLevel1Celebrities);
                learnQuestion1LearnLevel1Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer3Question1LearnLevel1Celebrities);
                learnQuestion1LearnLevel1Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer4Question1LearnLevel1Celebrities);


                var learnQuestion2LearnLevel1Celebrities = new LearnQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "",
                };
                learnLevel1Celebrities.LearnQuestions.Add(learnQuestion2LearnLevel1Celebrities);

                var learnQuestionAnswer1Question2LearnLevel1Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };
                learnQuestion2LearnLevel1Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel1Celebrities);

                var learnQuestionAnswer2Question2LearnLevel1Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question2LearnLevel1Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var learnQuestionAnswer4Question2LearnLevel1Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };
                learnQuestion2LearnLevel1Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer2Question2LearnLevel1Celebrities);
                learnQuestion2LearnLevel1Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer3Question2LearnLevel1Celebrities);
                learnQuestion2LearnLevel1Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer4Question2LearnLevel1Celebrities);

                //-------------------------

                var learnLevel2Celebrities = new LearnLevelEntity()
                {
                    LearnLevelNumber = 2,
                    //TODO Petros -> change these 2 lines
                    Image = "",
                    Text = " \n\n\n"
                };

                celebritiesCategory.LearnLevels.Add(learnLevel2Celebrities);

                var learnQuestion1LearnLevel2Celebrities = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "",
                };
                learnLevel2Celebrities.LearnQuestions.Add(learnQuestion1LearnLevel2Celebrities);

                var learnQuestionAnswer1Question1LearnLevel2Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };
                learnQuestion1LearnLevel2History.LearnQuestionAnswers.Add(learnQuestionAnswer1Question1LearnLevel2History);

                var learnQuestionAnswer2Question1LearnLevel2Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question1LearnLevel2Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };

                var learnQuestionAnswer4Question1LearnLevel2Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                learnQuestion1LearnLevel2Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer2Question1LearnLevel2Celebrities);
                learnQuestion1LearnLevel2Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer3Question1LearnLevel2Celebrities);
                learnQuestion1LearnLevel2Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer4Question1LearnLevel2Celebrities);


                var learnQuestion2LearnLevel2Celebrities = new LearnQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "",
                };
                learnLevel2Celebrities.LearnQuestions.Add(learnQuestion2LearnLevel2Celebrities);

                var learnQuestionAnswer1Question2LearnLevel2Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                learnQuestion2LearnLevel2Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel2Celebrities);

                var learnQuestionAnswer2Question2LearnLevel2Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };

                var learnQuestionAnswer3Question2LearnLevel2Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };

                var learnQuestionAnswer4Question2LearnLevel2Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                learnQuestion2LearnLevel2Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer2Question2LearnLevel2Celebrities);
                learnQuestion2LearnLevel2Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer3Question2LearnLevel2Celebrities);
                learnQuestion2LearnLevel2Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer4Question2LearnLevel2Celebrities);


                //---------------------

                var learnLevel3Celebrities = new LearnLevelEntity()
                {
                    LearnLevelNumber = 3,
                    //TODO Petros -> change these 2 lines
                    Image = "",
                    Text = " \n\n\n"
                    };

                celebritiesCategory.LearnLevels.Add(learnLevel3Celebrities);

                var learnQuestion1LearnLevel3Celebrities = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "",
                };
                learnLevel3Celebrities.LearnQuestions.Add(learnQuestion1LearnLevel3Celebrities);

                var learnQuestionAnswer1Question1LearnLevel3Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };
                learnQuestion1LearnLevel3Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer1Question1LearnLevel3Celebrities);

                var learnQuestionAnswer2Question1LearnLevel3Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question1LearnLevel3Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };

                var learnQuestionAnswer4Question1LearnLevel3Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                learnQuestion1LearnLevel3Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer2Question1LearnLevel3Celebrities);
                learnQuestion1LearnLevel3Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer3Question1LearnLevel3Celebrities);
                learnQuestion1LearnLevel3Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer4Question1LearnLevel3Celebrities);


                var learnQuestion2LearnLevel3Celebrities = new LearnQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "",
                };
                learnLevel3Celebrities.LearnQuestions.Add(learnQuestion2LearnLevel3Celebrities);

                var learnQuestionAnswer1Question2LearnLevel3Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };
                learnQuestion2LearnLevel3Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel3Celebrities);

                var learnQuestionAnswer2Question2LearnLevel3Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question2LearnLevel3Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };

                var learnQuestionAnswer4Question2LearnLevel3Celebrities = new LearnQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };

                learnQuestion2LearnLevel3Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer2Question2LearnLevel3Celebrities);
                learnQuestion2LearnLevel3Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer3Question2LearnLevel3Celebrities);
                learnQuestion2LearnLevel3Celebrities.LearnQuestionAnswers.Add(learnQuestionAnswer4Question2LearnLevel3Celebrities);

                categoryRepository.Update(celebritiesCategory);

                uow.Save();
            }
        }



        private static void FillTestLevels()
        {
            using (var uow = new UnitOfWork())
            {
                var categoryRepository = uow.GetRepository<ICategoryRepository>();

                var historyCategory = categoryRepository.GetCategoryByName("Istorie");

                var testLevel1History = new TestLevelEntity()
                {
                    TestLevelNumber = 1,
                    //TODO Petros -> change these 2 lines
                    Image = "https://i.ibb.co/vVz0Gqs/history.png",
                    Text = ""
                };
                historyCategory.TestLevels.Add(testLevel1History);

                var testQuestion1TestLevel1History = new TestQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "In ce an a inceput al doilea razboi modial?",
                };
                testLevel1History.TestQuestions.Add(testQuestion1TestLevel1History);

                var testQuestionAnswer1Question1TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "1945",
                    IsCorrect = false
                };
                testQuestion1TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer1Question1TestLevel1History);

                var testQuestionAnswer2Question1TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "1939",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question1TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "1918",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question1TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "1940",
                    IsCorrect = false
                };

                testQuestion1TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer2Question1TestLevel1History);
                testQuestion1TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer3Question1TestLevel1History);
                testQuestion1TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer4Question1TestLevel1History);


                var testQuestion2TestLevel1History = new TestQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Cine a fost primul rege al Romaniei?",
                };
                testLevel1History.TestQuestions.Add(testQuestion2TestLevel1History);

                var testQuestionAnswer1Question2TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Carol I",
                    IsCorrect = true
                };
                testQuestion2TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer1Question2TestLevel1History);

                var testQuestionAnswer2Question2TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Ferdinand I",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question2TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Mihai I",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question2TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Alexandru II",
                    IsCorrect = false
                };
                testQuestion2TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer2Question2TestLevel1History);
                testQuestion2TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer3Question2TestLevel1History);
                testQuestion2TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer4Question2TestLevel1History);


                //add 2 more questions

                var testQuestion3TestLevel1History = new TestQuestionEntity()
                {
                    Order = 3,
                    //TODO Petros -> change this
                    Text = "In ce an a intrat Romania in primul razboi mondial?",
                };
                testLevel1History.TestQuestions.Add(testQuestion3TestLevel1History);

                var testQuestionAnswer1Question3TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "1922",
                    IsCorrect = false
                };
                testQuestion3TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer1Question3TestLevel1History);

                var testQuestionAnswer2Question3TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "1916",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question3TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "1942",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question3TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "1914",
                    IsCorrect = false
                };

                testQuestion3TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer2Question3TestLevel1History);
                testQuestion3TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer3Question3TestLevel1History);
                testQuestion3TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer4Question3TestLevel1History);


                var testQuestion4TestLevel1History = new TestQuestionEntity()
                {
                    Order = 4,
                    //TODO Petros -> change this
                    Text = "In ce secol a domnit Stefan cel Mare?",
                };
                testLevel1History.TestQuestions.Add(testQuestion4TestLevel1History);

                var testQuestionAnswer1Question4TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "15",
                    IsCorrect = true
                };
                testQuestion4TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer1Question4TestLevel1History);

                var testQuestionAnswer2Question4TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "14",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question4TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "16",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question4TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "17",
                    IsCorrect =false
                };
                testQuestion4TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer2Question4TestLevel1History);
                testQuestion4TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer3Question4TestLevel1History);
                testQuestion4TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer4Question4TestLevel1History);

               
                var testQuestion5TestLevel1History = new TestQuestionEntity()
                {
                    Order = 5,
                    //TODO Petros -> change this
                    Text = " In ce tara s-a nascut Adolf Hitler?",
                };
                testLevel1History.TestQuestions.Add(testQuestion5TestLevel1History);

                var testQuestionAnswer1Question5TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Germania",
                    IsCorrect = false
                };
                testQuestion5TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer1Question5TestLevel1History);

                var testQuestionAnswer2Question5TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Elvetia",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question5TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Austria",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question5TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Polonia",
                    IsCorrect = false
                };

                testQuestion5TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer2Question5TestLevel1History);
                testQuestion5TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer3Question5TestLevel1History);
                testQuestion5TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer4Question5TestLevel1History);


                var testQuestion6TestLevel1History = new TestQuestionEntity()
                {
                    Order = 6,
                    //TODO Petros -> change this
                    Text = "In ce oras au fost executat Nicolae Ceausescu?",
                };
                testLevel1History.TestQuestions.Add(testQuestion6TestLevel1History);

                var testQuestionAnswer1Question6TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Bucuresti",
                    IsCorrect = false
                };

                testQuestion6TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer1Question6TestLevel1History);

                var testQuestionAnswer2Question6TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Targoviste",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question6TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Alexandria",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question6TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Ploiesti",
                    IsCorrect = false
                };

                testQuestion6TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer2Question6TestLevel1History);
                testQuestion6TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer3Question6TestLevel1History);
                testQuestion6TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer4Question6TestLevel1History);


                var testQuestion7TestLevel1History = new TestQuestionEntity()
                {
                    Order = 7,
                    //TODO Petros -> change this
                    Text = "In ce perioada a avut loc Razboiul Rece?",
                };
                testLevel1History.TestQuestions.Add(testQuestion7TestLevel1History);

                var testQuestionAnswer1Question7TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "1941-1972",
                    IsCorrect = false
                };
                testQuestion7TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer1Question7TestLevel1History);

                var testQuestionAnswer2Question7TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "1943-1989",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question7TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "1947-1991",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question7TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "1914-1918",
                    IsCorrect = false
                };

                testQuestion7TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer2Question7TestLevel1History);
                testQuestion7TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer3Question7TestLevel1History);
                testQuestion7TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer4Question7TestLevel1History);


                var testQuestion8TestLevel1History = new TestQuestionEntity()
                {
                    Order = 8,
                    //TODO Petros -> change this
                    Text = "Cine a fost Mihai Viteazu?",
                };
                testLevel1History.TestQuestions.Add(testQuestion8TestLevel1History);

                var testQuestionAnswer1Question8TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Regele Romaniei",
                    IsCorrect = false
                };
                testQuestion8TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer1Question8TestLevel1History);

                var testQuestionAnswer2Question8TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Voievodul Romaniei",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question8TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Imparatul Romaniei",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question8TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Presedintele Romaniei",
                    IsCorrect = false
                };

                testQuestion8TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer2Question8TestLevel1History);
                testQuestion8TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer3Question8TestLevel1History);
                testQuestion8TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer4Question8TestLevel1History);

                var testQuestion9TestLevel1History = new TestQuestionEntity()
                {
                    Order = 9,
                    //TODO Petros -> change this
                    Text = "Cum se numea zeul Dacilor?",
                };
                testLevel1History.TestQuestions.Add(testQuestion9TestLevel1History);

                var testQuestionAnswer1Question9TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Allah",
                    IsCorrect = false
                };
                testQuestion9TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer1Question9TestLevel1History);

                var testQuestionAnswer2Question9TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Zalmoxis",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question9TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Buddha",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question9TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Zeus",
                    IsCorrect = false
                };

                testQuestion9TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer2Question9TestLevel1History);
                testQuestion9TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer3Question9TestLevel1History);
                testQuestion9TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer4Question9TestLevel1History);



                categoryRepository.Update(historyCategory);//asta actualizeaza locatia pana unde s-a rezolvat in test pt history




                //-------------------------

                var testLevel2History = new TestLevelEntity()
                {
                    TestLevelNumber = 2,
                    //TODO Petros -> change these 2 lines
                    Image = "https://upload.wikimedia.org/wikipedia/commons/4/40/Napoleon_in_His_Study.jpg",
                    Text = ""
                };

                historyCategory.TestLevels.Add(testLevel2History);

                

                //---------------------

                var testLevel3History = new TestLevelEntity()
                {
                    TestLevelNumber = 3,
                    //TODO Petros -> change these 2 lines
                    Image = "https://upload.wikimedia.org/wikipedia/ro/thumb/0/0b/ColdWar.jpg/300px-ColdWar.jpg",
                    Text = ""
                };

                historyCategory.TestLevels.Add(testLevel3History);

 









                //--------------------

                var sportsCategory = categoryRepository.GetCategoryByName("Sport");

                var testLevel1Sports = new TestLevelEntity()
                {
                    TestLevelNumber = 1,
                    //TODO Petros -> change these 2 lines
                    Image = "https://i.ibb.co/S7mwjys/Shutterstock-Lisa-Kolbasa.png",
                    Text = ""
                };

                sportsCategory.TestLevels.Add(testLevel1Sports);

                var testQuestion1TestLevel1Sports = new TestQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Cine a inscris, pana in prezent, cele mai multe goluri in fotbalul profesionist?",
                };
                testLevel1Sports.TestQuestions.Add(testQuestion1TestLevel1Sports);

                var testQuestionAnswer1Question1TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = " Lionel Messi",
                    IsCorrect = false
                };
                testQuestion1TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer1Question1TestLevel1Sports);

                var testQuestionAnswer2Question1TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Maradona",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question1TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Cristiano Ronaldo",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question1TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Pele",
                    IsCorrect = false
                };

                testQuestion1TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer2Question1TestLevel1Sports);
                testQuestion1TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer3Question1TestLevel1Sports);
                testQuestion1TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer4Question1TestLevel1Sports);


                var testQuestion2TestLevel1Sports = new TestQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Care este echipa de fotbal cu cele mai multe trofee Cupa Campionilor?",
                };
                testLevel1Sports.TestQuestions.Add(testQuestion2TestLevel1Sports);

                var testQuestionAnswer1Question2TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "FC Barcelona",
                    IsCorrect = false
                };
                testQuestion2TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer1Question2TestLevel1Sports);

                var testQuestionAnswer2Question2TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Manchester United",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question2TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Real Madrid",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question2TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "PSG",
                    IsCorrect = true
                };
                testQuestion2TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer2Question2TestLevel1Sports);
                testQuestion2TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer3Question2TestLevel1Sports);
                testQuestion2TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer4Question2TestLevel1Sports);



                var testQuestion3TestLevel1Sports = new TestQuestionEntity()
                {
                    Order = 3,
                    //TODO Petros -> change this
                    Text = "Cine este denumit cel mai bun basketballist din toate timpurile?",
                };
                testLevel1Sports.TestQuestions.Add(testQuestion3TestLevel1Sports);

                var testQuestionAnswer1Question3TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Kobe Bryant",
                    IsCorrect = false
                };
                testQuestion3TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer1Question3TestLevel1Sports);

                var testQuestionAnswer2Question3TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Michael Jordan",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question3TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Lebron James",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question3TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Stephen Curry",
                    IsCorrect = false
                };

                testQuestion3TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer2Question3TestLevel1Sports);
                testQuestion3TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer3Question3TestLevel1Sports);
                testQuestion3TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer4Question3TestLevel1Sports);


                var testQuestion4TestLevel1Sports = new TestQuestionEntity()
                {
                    Order = 4,
                    //TODO Petros -> change this
                    Text = "Care a fost nota exacta obtinuta de Nadia Comaneci la barna in anul 1979?",
                };
                testLevel1Sports.TestQuestions.Add(testQuestion4TestLevel1Sports);

                var testQuestionAnswer1Question4TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "9.90",
                    IsCorrect = false
                };

                testQuestion4TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer1Question4TestLevel1Sports);

                var testQuestionAnswer2Question4TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "9.98",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question4TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "10.0",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question4TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "9.95",
                    IsCorrect = true
                };

                testQuestion4TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer2Question4TestLevel1Sports);
                testQuestion4TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer3Question4TestLevel1Sports);
                testQuestion4TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer4Question4TestLevel1Sports);



                var testQuestion5TestLevel1Sports = new TestQuestionEntity()
                {
                    Order = 5,
                    //TODO Petros -> change this
                    Text = "Cate titluri la simplu a castigat jucatorul de tenis Ilie Nastase ?",
                };
                testLevel1Sports.TestQuestions.Add(testQuestion5TestLevel1Sports);

                var testQuestionAnswer1Question5TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "60",
                    IsCorrect = false
                };
                testQuestion5TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer1Question5TestLevel1Sports);

                var testQuestionAnswer2Question5TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "24",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question5TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "58",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question5TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "46",
                    IsCorrect = false
                };

                testQuestion5TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer2Question5TestLevel1Sports);
                testQuestion5TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer3Question5TestLevel1Sports);
                testQuestion5TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer4Question5TestLevel1Sports);


                var testQuestion6TestLevel1Sports = new TestQuestionEntity()
                {
                    Order = 6,
                    //TODO Petros -> change this
                    Text = "Cine este jucatorul de fotbal cu cele mai multe baloane de aur?",
                };
                testLevel1Sports.TestQuestions.Add(testQuestion6TestLevel1Sports);

                var testQuestionAnswer1Question6TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Cristiano Ronaldo",
                    IsCorrect = false
                };
                testQuestion6TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer1Question6TestLevel1Sports);

                var testQuestionAnswer2Question6TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Lionel Messi",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question6TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Andrea Pirlo",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question6TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Zlatan Ibrahimovic",
                    IsCorrect = false
                };

                testQuestion6TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer2Question6TestLevel1Sports);
                testQuestion6TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer3Question6TestLevel1Sports);
                testQuestion6TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer4Question6TestLevel1Sports);


                var testQuestion7TestLevel1Sports = new TestQuestionEntity()
                {
                    Order = 7,
                    //TODO Petros -> change this
                    Text = "Ce echipa a invins nationala de fotbal U21 a Romaniei in sferturile de finala la EURO U21 din 2019?",
                };
                testLevel1Sports.TestQuestions.Add(testQuestion7TestLevel1Sports);

                var testQuestionAnswer1Question7TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Anglia U21",
                    IsCorrect = false
                };
                testQuestion7TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer1Question7TestLevel1Sports);

                var testQuestionAnswer2Question7TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Germania U21",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question7TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Suedia U21",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question7TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Spania U21",
                    IsCorrect = false
                };

                testQuestion7TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer2Question7TestLevel1Sports);
                testQuestion7TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer3Question7TestLevel1Sports);
                testQuestion7TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer4Question7TestLevel1Sports);


                var testQuestion8TestLevel1Sports = new TestQuestionEntity()
                {
                    Order = 8,
                    //TODO Petros -> change this
                    Text = "Ce jucator de tenis are in palmares cele mai multe titluri Grand Slam?",
                };
                testLevel1Sports.TestQuestions.Add(testQuestion8TestLevel1Sports);

                var testQuestionAnswer1Question8TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Ilie Nastase",
                    IsCorrect = false
                };

                testQuestion8TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer1Question8TestLevel1Sports);

                var testQuestionAnswer2Question8TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Novak Djokovic",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question8TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Rafael Nadal",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question8TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Roger Federer",
                    IsCorrect = true
                };

                testQuestion8TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer2Question8TestLevel1Sports);
                testQuestion8TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer3Question8TestLevel1Sports);
                testQuestion8TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer4Question8TestLevel1Sports);



                var testQuestion9TestLevel1Sports = new TestQuestionEntity()
                {
                    Order = 9,
                    //TODO Petros -> change this
                    Text = "Care este scorul cu care s-a impus Franta in fata Croatiei in finala Cupei Mondiale din Rusia 2018 ?",
                };
                testLevel1Sports.TestQuestions.Add(testQuestion9TestLevel1Sports);

                var testQuestionAnswer1Question9TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "1-0",
                    IsCorrect = false
                };
                testQuestion9TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer1Question9TestLevel1Sports);

                var testQuestionAnswer2Question9TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "2-1",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question9TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "4-2",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question9TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "3-2",
                    IsCorrect = false
                };

                testQuestion9TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer2Question9TestLevel1Sports);
                testQuestion9TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer3Question9TestLevel1Sports);
                testQuestion9TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer4Question9TestLevel1Sports);


                var testQuestion10TestLevel1Sports = new TestQuestionEntity()
                {
                    Order = 10,
                    //TODO Petros -> change this
                    Text = "In care din urmatoarele tari s-a tinut Campionatul European de fotbal din 2016?",
                };
                testLevel1Sports.TestQuestions.Add(testQuestion10TestLevel1Sports);

                var testQuestionAnswer1Question10TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Portugalia",
                    IsCorrect = false
                };
                testQuestion10TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer1Question10TestLevel1Sports);

                var testQuestionAnswer2Question10TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Franta",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question10TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Germania",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question10TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Polonia",
                    IsCorrect = false
                };

                testQuestion10TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer2Question10TestLevel1Sports);
                testQuestion10TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer3Question10TestLevel1Sports);
                testQuestion10TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer4Question10TestLevel1Sports);



                categoryRepository.Update(sportsCategory);//-asta actualizeaza locatia pana unde s-a rezolvat in test pt sports

                //-------------------------

                var testLevel2Sports = new TestLevelEntity()
                {
                    TestLevelNumber = 2,
                    //TODO Petros -> change these 2 lines
                    Image = "https://playtech.ro/stiri/wp-content/uploads/2020/03/nadia-comaneci.jpg",
                    Text = ""
                };

                sportsCategory.TestLevels.Add(testLevel2Sports);

               

                //----------------

                var testLevel3Sports = new TestLevelEntity()
                {
                    TestLevelNumber = 3,
                    //TODO Petros -> change these 2 lines
                    Image = "https://image-cdn.essentiallysports.com/wp-content/uploads/20200912202247/michael-jordan-t.jpg",
                    Text = ""
                };

                sportsCategory.TestLevels.Add(testLevel3Sports);

                

               


                //--------------



                var geographyCategory = categoryRepository.GetCategoryByName("Geografie");

                var testLevel1Geography = new TestLevelEntity()
                {
                    TestLevelNumber = 1,
                    //TODO Petros -> change these 2 lines
                    Image = "https://i.ibb.co/zJ28X3V/30445-tumb-750-Xauto.jpg",
                    Text = ""
                };
                geographyCategory.TestLevels.Add(testLevel1Geography);

                var testQuestion1TestLevel1Geography = new TestQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Din ce tara izvoraste Dunarea?",
                };
                testLevel1Geography.TestQuestions.Add(testQuestion1TestLevel1Geography);

                var testQuestionAnswer1Question1TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Romania",
                    IsCorrect = false
                };
                testQuestion1TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer1Question1TestLevel1Geography);

                var testQuestionAnswer2Question1TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Germania",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question1TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Ungaria",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question1TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Serbia",
                    IsCorrect = false
                };

                testQuestion1TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer2Question1TestLevel1Geography);
                testQuestion1TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer3Question1TestLevel1Geography);
                testQuestion1TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer4Question1TestLevel1Geography);


                var testQuestion2TestLevel1Geography = new TestQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Care este capitala Portugaliei?",
                };
                testLevel1Geography.TestQuestions.Add(testQuestion2TestLevel1Geography);

                var testQuestionAnswer1Question2TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Lisabona",
                    IsCorrect = true
                };
                testQuestion2TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer1Question2TestLevel1Geography);

                var testQuestionAnswer2Question2TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Porto",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question2TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Aveiro",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question2TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Funchal",
                    IsCorrect = true
                };
                testQuestion2TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer2Question2TestLevel1Geography);
                testQuestion2TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer3Question2TestLevel1Geography);
                testQuestion2TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer4Question2TestLevel1Geography);


                var testQuestion3TestLevel1Geography = new TestQuestionEntity()
                {
                    Order = 3,
                    //TODO Petros -> change this
                    Text = "A cata planeta de la soare este Terra?",
                };
                testLevel1Geography.TestQuestions.Add(testQuestion3TestLevel1Geography);

                var testQuestionAnswer1Question3TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "a patra",
                    IsCorrect = false
                };
                testQuestion3TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer1Question3TestLevel1Geography);

                var testQuestionAnswer2Question3TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "a treia",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question3TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "a doua",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question3TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "a cincea",
                    IsCorrect = false
                };

                testQuestion3TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer2Question3TestLevel1Geography);
                testQuestion3TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer3Question3TestLevel1Geography);
                testQuestion3TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer4Question3TestLevel1Geography);


                var testQuestion4TestLevel1Geography = new TestQuestionEntity()
                {
                    Order = 4,
                    //TODO Petros -> change this
                    Text = "Care este forma de relief predominanta in Romania?",
                };
                testLevel1Geography.TestQuestions.Add(testQuestion4TestLevel1Geography);

                var testQuestionAnswer1Question4TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Lisabona",
                    IsCorrect = true
                };
                testQuestion4TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer1Question4TestLevel1Geography);

                var testQuestionAnswer2Question4TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Porto",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question4TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Aveiro",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question4TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Funchal",
                    IsCorrect = true
                };
                testQuestion4TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer2Question4TestLevel1Geography);
                testQuestion4TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer3Question4TestLevel1Geography);
                testQuestion4TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer4Question4TestLevel1Geography);


                var testQuestion5TestLevel1Geography = new TestQuestionEntity()
                {
                    Order = 5,
                    //TODO Petros -> change this
                    Text = "Din ce tara izvoraste Dunarea?",
                };
                testLevel1Geography.TestQuestions.Add(testQuestion5TestLevel1Geography);

                var testQuestionAnswer1Question5TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Romania",
                    IsCorrect = false
                };
                testQuestion5TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer1Question5TestLevel1Geography);

                var testQuestionAnswer2Question5TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Germania",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question5TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Ungaria",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question5TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Serbia",
                    IsCorrect = false
                };

                testQuestion5TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer2Question5TestLevel1Geography);
                testQuestion5TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer3Question5TestLevel1Geography);
                testQuestion5TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer4Question5TestLevel1Geography);


                var testQuestion6TestLevel1Geography = new TestQuestionEntity()
                {
                    Order = 6,
                    //TODO Petros -> change this
                    Text = "Care este capitala Portugaliei?",
                };
                testLevel1Geography.TestQuestions.Add(testQuestion6TestLevel1Geography);

                var testQuestionAnswer1Question6TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Lisabona",
                    IsCorrect = true
                };
                testQuestion6TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer1Question6TestLevel1Geography);

                var testQuestionAnswer2Question6TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Porto",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question6TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Aveiro",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question6TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Funchal",
                    IsCorrect = true
                };
                testQuestion6TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer2Question6TestLevel1Geography);
                testQuestion6TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer3Question6TestLevel1Geography);
                testQuestion6TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer4Question6TestLevel1Geography);


                var testQuestion7TestLevel1Geography = new TestQuestionEntity()
                {
                    Order = 7,
                    //TODO Petros -> change this
                    Text = "Cine a realizat pentru prima data calatoria in jurul pamantului?",
                };
                testLevel1Geography.TestQuestions.Add(testQuestion7TestLevel1Geography);

                var testQuestionAnswer1Question7TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Cristofor Columb",
                    IsCorrect = false
                };
                testQuestion7TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer1Question7TestLevel1Geography);

                var testQuestionAnswer2Question7TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Amerigo Vespucci",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question7TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Fernando Magellan",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question7TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Phileas Fogg",
                    IsCorrect = false
                };

                testQuestion7TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer2Question7TestLevel1Geography);
                testQuestion7TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer3Question7TestLevel1Geography);
                testQuestion7TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer4Question7TestLevel1Geography);


                var testQuestion8TestLevel1Geography = new TestQuestionEntity()
                {
                    Order = 8,
                    //TODO Petros -> change this
                    Text = "Ce tip de lac este lacul Sf Ana?",
                };
                testLevel1Geography.TestQuestions.Add(testQuestion8TestLevel1Geography);

                var testQuestionAnswer1Question8TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Tectonic",
                    IsCorrect = false
                };
                testQuestion8TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer1Question8TestLevel1Geography);

                var testQuestionAnswer2Question8TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Glaciar",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question8TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Vulcanic",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question8TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Artificial",
                    IsCorrect = false
                };

                testQuestion8TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer2Question8TestLevel1Geography);
                testQuestion8TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer3Question8TestLevel1Geography);
                testQuestion8TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer4Question8TestLevel1Geography);



                var testQuestion9TestLevel1Geography = new TestQuestionEntity()
                {
                    Order = 9,
                    //TODO Petros -> change this
                    Text = "Cine a realizat pentru prima data calatoria in jurul pamantului?",
                };
                testLevel1Geography.TestQuestions.Add(testQuestion9TestLevel1Geography);

                var testQuestionAnswer1Question9TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Cristofor Columb",
                    IsCorrect = false
                };
                testQuestion9TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer1Question9TestLevel1Geography);

                var testQuestionAnswer2Question9TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Amerigo Vespucci",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question9TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Fernando Magellan",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question9TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Phileas Fogg",
                    IsCorrect = false
                };

                testQuestion9TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer2Question9TestLevel1Geography);
                testQuestion9TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer3Question9TestLevel1Geography);
                testQuestion9TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer4Question9TestLevel1Geography);


                var testQuestion10TestLevel1Geography = new TestQuestionEntity()
                {
                    Order = 10,
                    //TODO Petros -> change this
                    Text = "Ce tip de lac este lacul Sfanta Ana?",
                };
                testLevel1Geography.TestQuestions.Add(testQuestion8TestLevel1Geography);

                var testQuestionAnswer1Question10TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Tectonic",
                    IsCorrect = false
                };
                testQuestion10TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer1Question10TestLevel1Geography);

                var testQuestionAnswer2Question10TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Glaciar",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question10TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Vulcanic",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question10TestLevel1Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Artificial",
                    IsCorrect = false
                };

                testQuestion10TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer2Question10TestLevel1Geography);
                testQuestion10TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer3Question10TestLevel1Geography);
                testQuestion10TestLevel1Geography.TestQuestionAnswers.Add(testQuestionAnswer4Question10TestLevel1Geography);

                categoryRepository.Update(geographyCategory);//-asta actualizeaza locatia pana unde s-a rezolvat in test pt geography










                //-------------------------

                var testLevel2Geography = new TestLevelEntity()
                {
                    TestLevelNumber = 2,
                    //TODO Petros -> change these 2 lines
                    Image = "https://i.ibb.co/vVz0Gqs",
                    Text = ""
                };

                geographyCategory.TestLevels.Add(testLevel2Geography);

               

                //---------------------

                var testLevel3Geography = new TestLevelEntity()
                {
                    TestLevelNumber = 3,
                    //TODO Petros -> change these 2 lines
                    Image = "https://i.ibb.co/vVz0Gqs",
                    Text = ""
                };

                geographyCategory.TestLevels.Add(testLevel3Geography);

           











                //-----------------------//

                var musicCategory = categoryRepository.GetCategoryByName("Muzică");

                var testLevel1Music = new TestLevelEntity()
                {
                    TestLevelNumber = 1,
                    //TODO Petros -> change these 2 lines
                    Image = "https://i.ibb.co/R9vY3J6/The-20-Best-Royalty-Free-Music-Sites-in-2018.png",
                    Text = ""
                };

                musicCategory.TestLevels.Add(testLevel1Music);

                var testQuestion1TestLevel1Music = new TestQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Câte albume au reeditat trupa Holograf?",
                };
                testLevel1Music.TestQuestions.Add(testQuestion1TestLevel1Music);

                var testQuestionAnswer1Question1TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "1",
                    IsCorrect = false
                };
                testQuestion1TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer1Question1TestLevel1Music);

                var testQuestionAnswer2Question1TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "2",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question1TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "3",
                    IsCorrect = false
                };
                var testQuestionAnswer4Question1TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "4",
                    IsCorrect = true
                };

                testQuestion1TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer2Question1TestLevel1Music);
                testQuestion1TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer3Question1TestLevel1Music);
                testQuestion1TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer4Question1TestLevel1Music);


                var testQuestion2TestLevel1Music = new TestQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Cum se numeste piesa cu care au debutat discografic trupa Holograf?",
                };
                testLevel1Music.TestQuestions.Add(testQuestion2TestLevel1Music);

                var testQuestionAnswer1Question2TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Umbre pe cer",
                    IsCorrect = false
                };
                testQuestion2TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer1Question2TestLevel1Music);

                var testQuestionAnswer2Question2TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Banii vorbesc",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question2TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Lungul drum al zilei către noapte",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question2TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Singur pe drum",
                    IsCorrect = false
                };
                testQuestion2TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer2Question2TestLevel1Music);
                testQuestion2TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer3Question2TestLevel1Music);
                testQuestion2TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer4Question2TestLevel1Music);



                var testQuestion3TestLevel1Music = new TestQuestionEntity()
                {
                    Order = 3,
                    //TODO Petros -> change this
                    Text = "Câte albume au reeditat trupa Holograf?",
                };
                testLevel1Music.TestQuestions.Add(testQuestion3TestLevel1Music);

                var testQuestionAnswer1Question3TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "1",
                    IsCorrect = false
                };
                testQuestion3TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer1Question3TestLevel1Music);

                var testQuestionAnswer2Question3TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "2",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question3TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "3",
                    IsCorrect = false
                };
                var testQuestionAnswer4Question3TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "4",
                    IsCorrect = true
                };

                testQuestion3TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer2Question3TestLevel1Music);
                testQuestion3TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer3Question3TestLevel1Music);
                testQuestion3TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer4Question3TestLevel1Music);


                var testQuestion4TestLevel1Music = new TestQuestionEntity()
                {
                    Order = 4,
                    //TODO Petros -> change this
                    Text = "Cum se numeste piesa cu care au debutat discografic trupa Holograf?",
                };
                testLevel1Music.TestQuestions.Add(testQuestion4TestLevel1Music);

                var testQuestionAnswer1Question4TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Umbre pe cer",
                    IsCorrect = false
                };
                testQuestion4TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer1Question4TestLevel1Music);

                var testQuestionAnswer2Question4TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Banii vorbesc",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question4TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Lungul drum al zilei către noapte",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question4TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Singur pe drum",
                    IsCorrect = false
                };
                testQuestion4TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer2Question4TestLevel1Music);
                testQuestion4TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer3Question4TestLevel1Music);
                testQuestion4TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer4Question4TestLevel1Music);


                var testQuestion5TestLevel1Music = new TestQuestionEntity()
                {
                    Order = 5,
                    //TODO Petros -> change this
                    Text = "Câte albume au reeditat trupa Holograf?",
                };
                testLevel1Music.TestQuestions.Add(testQuestion5TestLevel1Music);

                var testQuestionAnswer1Question5TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "1",
                    IsCorrect = false
                };
                testQuestion5TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer1Question5TestLevel1Music);

                var testQuestionAnswer2Question5TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "2",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question5TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "3",
                    IsCorrect = false
                };
                var testQuestionAnswer4Question5TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "4",
                    IsCorrect = true
                };

                testQuestion5TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer2Question5TestLevel1Music);
                testQuestion5TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer3Question5TestLevel1Music);
                testQuestion5TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer4Question5TestLevel1Music);


                var testQuestion6TestLevel1Music = new TestQuestionEntity()
                {
                    Order = 6,
                    //TODO Petros -> change this
                    Text = "Cum se numeste piesa cu care au debutat discografic trupa Holograf?",
                };
                testLevel1Music.TestQuestions.Add(testQuestion6TestLevel1Music);

                var testQuestionAnswer1Question6TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Umbre pe cer",
                    IsCorrect = false
                };
                testQuestion6TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer1Question6TestLevel1Music);

                var testQuestionAnswer2Question6TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Banii vorbesc",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question6TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Lungul drum al zilei către noapte",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question6TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Singur pe drum",
                    IsCorrect = false
                };
                testQuestion6TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer2Question6TestLevel1Music);
                testQuestion6TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer3Question6TestLevel1Music);
                testQuestion6TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer4Question6TestLevel1Music);


                var testQuestion7TestLevel1Music = new TestQuestionEntity()
                {
                    Order = 7,
                    //TODO Petros -> change this
                    Text = "Câte albume au reeditat trupa Holograf?",
                };
                testLevel1Music.TestQuestions.Add(testQuestion7TestLevel1Music);

                var testQuestionAnswer1Question7TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "1",
                    IsCorrect = false
                };
                testQuestion7TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer1Question7TestLevel1Music);

                var testQuestionAnswer2Question7TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "2",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question7TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "3",
                    IsCorrect = false
                };
                var testQuestionAnswer4Question7TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "4",
                    IsCorrect = true
                };

                testQuestion7TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer2Question7TestLevel1Music);
                testQuestion7TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer3Question7TestLevel1Music);
                testQuestion7TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer4Question7TestLevel1Music);


                var testQuestion8TestLevel1Music = new TestQuestionEntity()
                {
                    Order = 8,
                    //TODO Petros -> change this
                    Text = "Cum se numeste piesa cu care au debutat discografic trupa Holograf?",
                };
                testLevel1Music.TestQuestions.Add(testQuestion8TestLevel1Music);

                var testQuestionAnswer1Question8TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Umbre pe cer",
                    IsCorrect = false
                };
                testQuestion8TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer1Question8TestLevel1Music);

                var testQuestionAnswer2Question8TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Banii vorbesc",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question8TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Lungul drum al zilei către noapte",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question8TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Singur pe drum",
                    IsCorrect = false
                };
                testQuestion8TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer2Question8TestLevel1Music);
                testQuestion8TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer3Question8TestLevel1Music);
                testQuestion8TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer4Question8TestLevel1Music);


                var testQuestion9TestLevel1Music = new TestQuestionEntity()
                {
                    Order = 9,
                    //TODO Petros -> change this
                    Text = "Câte albume au reeditat trupa Holograf?",
                };
                testLevel1Music.TestQuestions.Add(testQuestion9TestLevel1Music);

                var testQuestionAnswer1Question9TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "1",
                    IsCorrect = false
                };
                testQuestion9TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer1Question9TestLevel1Music);

                var testQuestionAnswer2Question9TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "2",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question9TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "3",
                    IsCorrect = false
                };
                var testQuestionAnswer4Question9TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "4",
                    IsCorrect = true
                };

                testQuestion9TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer2Question9TestLevel1Music);
                testQuestion9TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer3Question9TestLevel1Music);
                testQuestion9TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer4Question9TestLevel1Music);


                var testQuestion10TestLevel1Music = new TestQuestionEntity()
                {
                    Order = 10,
                    //TODO Petros -> change this
                    Text = "Cum se numeste piesa cu care au debutat discografic trupa Holograf?",
                };
                testLevel1Music.TestQuestions.Add(testQuestion10TestLevel1Music);

                var testQuestionAnswer1Question10TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Umbre pe cer",
                    IsCorrect = false
                };
                testQuestion2TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer1Question10TestLevel1Music);

                var testQuestionAnswer2Question10TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Banii vorbesc",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question10TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Lungul drum al zilei către noapte",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question10TestLevel1Music = new TestQuestionAnswerEntity()
                {
                    Text = "Singur pe drum",
                    IsCorrect = false
                };
                testQuestion10TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer2Question10TestLevel1Music);
                testQuestion10TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer3Question10TestLevel1Music);
                testQuestion10TestLevel1Music.TestQuestionAnswers.Add(testQuestionAnswer4Question10TestLevel1Music);

                categoryRepository.Update(musicCategory);



                //-------------------------

                var testLevel2Music = new TestLevelEntity()
                {
                    TestLevelNumber = 2,
                    //TODO Petros -> change these 2 lines
                    Image = "https://www.rollingstone.com/wp-content/uploads/2018/08/best-deepcut-abba-songs-sheffield.jpg?resize=1800,1200&w=1800",
                    Text = ""
                };

                musicCategory.TestLevels.Add(testLevel2Music);

                
                //---------------------

                var testLevel3Music = new TestLevelEntity()
                {
                    TestLevelNumber = 3,
                    //TODO Petros -> change these 2 lines
                    Image = "https://api.time.com/wp-content/uploads/2015/12/the-beatles2.jpg",
                    Text = ""
                };

                musicCategory.TestLevels.Add(testLevel3Music);

                
                

                //----------------//








                var celebritiesCategory = categoryRepository.GetCategoryByName("Celebrități");

                var testLevel1Celebrities = new TestLevelEntity()
                {
                    TestLevelNumber = 1,
                    //TODO Petros -> change these 2 lines
                    Image = "https://i.ibb.co/t4CSnLC/hollywood-star-620x350.jpg",
                    Text = ""
                };

                celebritiesCategory.TestLevels.Add(testLevel1Celebrities);

                var testQuestion1TestLevel1Celebrities = new TestQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "",
                };
                testLevel1Celebrities.TestQuestions.Add(testQuestion1TestLevel1Celebrities);

                var testQuestionAnswer1Question1TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };
                testQuestion1TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer1Question1TestLevel1Celebrities);

                var testQuestionAnswer2Question1TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question1TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question1TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                testQuestion1TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer2Question1TestLevel1Celebrities);
                testQuestion1TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer3Question1TestLevel1Celebrities);
                testQuestion1TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer4Question1TestLevel1Celebrities);


                var testQuestion2TestLevel1Celebrities = new TestQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "",
                };
                testLevel1Celebrities.TestQuestions.Add(testQuestion2TestLevel1Celebrities);

                var testQuestionAnswer1Question2TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };
                testQuestion2TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer1Question2TestLevel1Celebrities);

                var testQuestionAnswer2Question2TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question2TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question2TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };
                testQuestion2TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer2Question2TestLevel1Celebrities);
                testQuestion2TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer3Question2TestLevel1Celebrities);
                testQuestion2TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer4Question2TestLevel1Celebrities);


                

                var testQuestion3TestLevel1Celebrities = new TestQuestionEntity()
                {
                    Order = 3,
                    //TODO Petros -> change this
                    Text = "",
                };
                testLevel1Celebrities.TestQuestions.Add(testQuestion3TestLevel1Celebrities);

                var testQuestionAnswer1Question3TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };
                testQuestion3TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer1Question3TestLevel1Celebrities);

                var testQuestionAnswer2Question3TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question3TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question3TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                testQuestion3TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer2Question3TestLevel1Celebrities);
                testQuestion3TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer3Question3TestLevel1Celebrities);
                testQuestion3TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer4Question3TestLevel1Celebrities);


                var testQuestion4TestLevel1Celebrities = new TestQuestionEntity()
                {
                    Order = 4,
                    //TODO Petros -> change this
                    Text = "",
                };
                testLevel1Celebrities.TestQuestions.Add(testQuestion4TestLevel1Celebrities);

                var testQuestionAnswer1Question4TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };
                testQuestion4TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer1Question4TestLevel1Celebrities);

                var testQuestionAnswer2Question4TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question4TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question4TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };
                testQuestion4TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer2Question4TestLevel1Celebrities);
                testQuestion4TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer3Question4TestLevel1Celebrities);
                testQuestion4TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer4Question4TestLevel1Celebrities);


                

                var testQuestion5TestLevel1Celebrities = new TestQuestionEntity()
                {
                    Order = 5,
                    //TODO Petros -> change this
                    Text = "",
                };
                testLevel1Celebrities.TestQuestions.Add(testQuestion5TestLevel1Celebrities);

                var testQuestionAnswer1Question5TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };
                testQuestion5TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer1Question5TestLevel1Celebrities);

                var testQuestionAnswer2Question5TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question5TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question5TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                testQuestion5TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer2Question5TestLevel1Celebrities);
                testQuestion5TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer3Question5TestLevel1Celebrities);
                testQuestion5TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer4Question5TestLevel1Celebrities);


                var testQuestion6TestLevel1Celebrities = new TestQuestionEntity()
                {
                    Order = 6,
                    //TODO Petros -> change this
                    Text = "",
                };
                testLevel1Celebrities.TestQuestions.Add(testQuestion6TestLevel1Celebrities);

                var testQuestionAnswer1Question6TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };
                testQuestion6TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer1Question6TestLevel1Celebrities);

                var testQuestionAnswer2Question6TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question6TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question6TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };
                testQuestion6TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer2Question6TestLevel1Celebrities);
                testQuestion6TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer3Question6TestLevel1Celebrities);
                testQuestion6TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer4Question6TestLevel1Celebrities);

                

                var testQuestion7TestLevel1Celebrities = new TestQuestionEntity()
                {
                    Order = 7,
                    //TODO Petros -> change this
                    Text = "",
                };
                testLevel1Celebrities.TestQuestions.Add(testQuestion7TestLevel1Celebrities);

                var testQuestionAnswer1Question7TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };
                testQuestion7TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer1Question7TestLevel1Celebrities);

                var testQuestionAnswer2Question7TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question7TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question7TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                testQuestion7TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer2Question7TestLevel1Celebrities);
                testQuestion7TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer3Question7TestLevel1Celebrities);
                testQuestion7TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer4Question7TestLevel1Celebrities);


                var testQuestion8TestLevel1Celebrities = new TestQuestionEntity()
                {
                    Order = 8,
                    //TODO Petros -> change this
                    Text = "",
                };
                testLevel1Celebrities.TestQuestions.Add(testQuestion8TestLevel1Celebrities);

                var testQuestionAnswer1Question8TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };
                testQuestion8TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer1Question8TestLevel1Celebrities);

                var testQuestionAnswer2Question8TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question8TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question8TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };
                testQuestion8TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer2Question8TestLevel1Celebrities);
                testQuestion8TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer3Question8TestLevel1Celebrities);
                testQuestion8TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer4Question8TestLevel1Celebrities);


                

                var testQuestion9TestLevel1Celebrities = new TestQuestionEntity()
                {
                    Order = 9,
                    //TODO Petros -> change this
                    Text = "",
                };
                testLevel1Celebrities.TestQuestions.Add(testQuestion9TestLevel1Celebrities);

                var testQuestionAnswer1Question9TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };
                testQuestion9TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer1Question9TestLevel1Celebrities);

                var testQuestionAnswer2Question9TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question9TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question9TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                testQuestion9TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer2Question9TestLevel1Celebrities);
                testQuestion9TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer3Question9TestLevel1Celebrities);
                testQuestion9TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer4Question9TestLevel1Celebrities);


                var testQuestion10TestLevel1Celebrities = new TestQuestionEntity()
                {
                    Order = 10,
                    //TODO Petros -> change this
                    Text = "",
                };
                testLevel1Celebrities.TestQuestions.Add(testQuestion10TestLevel1Celebrities);

                var testQuestionAnswer1Question10TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };
                testQuestion10TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer1Question10TestLevel1Celebrities);

                var testQuestionAnswer2Question10TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question10TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question10TestLevel1Celebrities = new TestQuestionAnswerEntity()
                {
                    Text = "",
                    IsCorrect = true
                };
                testQuestion10TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer2Question10TestLevel1Celebrities);
                testQuestion10TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer3Question10TestLevel1Celebrities);
                testQuestion10TestLevel1Celebrities.TestQuestionAnswers.Add(testQuestionAnswer4Question10TestLevel1Celebrities);







                //-------------------------

                var testLevel2Celebrities = new TestLevelEntity()
                {
                    TestLevelNumber = 2,
                    //TODO Petros -> change these 2 lines
                    Image = "",
                    Text = ""
                };

                celebritiesCategory.TestLevels.Add(testLevel2Celebrities);

                
                //---------------------

                var testLevel3Celebrities = new TestLevelEntity()
                {
                    TestLevelNumber = 3,
                    //TODO Petros -> change these 2 lines
                    Image = "",
                    Text = ""
                };

                celebritiesCategory.TestLevels.Add(testLevel3Celebrities);

                
                categoryRepository.Update(celebritiesCategory);

                uow.Save();
            }
        }


    }
}


    













