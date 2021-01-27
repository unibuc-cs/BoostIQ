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
                    Name = "History"
                };

                var geographyCategory = new CategoryEntity()
                {
                    Name = "Geography"
                };

                var sportsCategory = new CategoryEntity()
                {
                    Name = "Sports"
                };

                var musicCategory = new CategoryEntity()
                {
                    Name = "Music"
                };

                repo.Add(historyCategory);
                repo.Add(geographyCategory);
                repo.Add(sportsCategory);
                repo.Add(musicCategory);

                uow.Save();
            }
        }

        private static void FillLearnLevels()
        {
            using (var uow = new UnitOfWork())
            {
                var categoryRepository = uow.GetRepository<ICategoryRepository>();

                var historyCategory = categoryRepository.GetCategoryByName("History");

                var learnLevel1History = new LearnLevelEntity()
                {
                    LearnLevelNumber = 1,
                    //TODO Petros -> change these 2 lines
                    Image = "https://www.europafm.ro/wp-content/uploads/2017/07/Stefan-Cel-Mare.jpg",
                    Text = "La 3 februarie 1531, la nici trei decenii de la trecerea în nefiinţă, Ştefan al III-lea, principele Ţării Moldovei, era amintit de Sigismund I, regele Poloniei (1506-1548), ca Stephanus ille magnus („acel mare Ştefan”). Bernard Wapowski, cartograful şi istoriograful oficial al aceluiaşi rege, consemna că domnul moldovean era „principele şi războinicul cel mai vestit” din epoca sa. Doctorul Matteo Muriano, trimis de Veneţia la Suceava, în vara anului 1502, spre a-i acorda asistenţa medicală principelui moldovean, consemna în raportul său că acesta „este un om foarte înţelept, vrednic de multă laudă, iubit mult de supuşii săi, pentru că este îndurător şi drept, veşnic treaz şi darnic”. Văzut de contemporanii lui europeni ca un şef de stat care a reuşit să se menţină la cârma ţării 47 de ani, pe plan intern el a simbolizat stabilitatea, continuitatea, dezvoltarea economică, dreptatea, încât la înmormântarea sa în Moldova „jale era, că plângea toţi ca pe un părinte al său …” (Grigore Ureche)." +
                    "Ştefan cel Mare, fiul lui Bogdan al II-lea (1449-1451) şi al soţiei sale Oltea, s-a născut cel mai probabil în anul 1438. După moartea tatălui său, Ştefan s-a refugiat în Transilvania stăpânită de către Iancu de Hunedoara (1441-1456), unde s-a familiarizat cu tacticile militare ale acestuia, care îmbinau elemente de artă militară din estul, centrul şi apusul Europei. Cu o forţă militară pusă la dispoziţie de către Vlad Ţepeş (1448; 1456-1472; 1476), la care s-au adăugat partizanii săi din sudul Moldovei, Ştefan cel Mare l-a învins pe Petru Aron la Doljeşti (Dolheşti), cucerind tronul Moldovei pe data de 12 aprilie 1457. A găsit o ţară sărăcită, sfâşiată de luptele dintre diverşii pretendenţi la domnia Moldovei, o ţară ce plătea tribut turcilor începând cu anul 1456." +
                    "În asemenea circumstanţe, domnitorul a trebuit să iniţieze ample măsuri de redresare a situaţiei social-economice. Pentru a-şi asigura suportul politic necesar stabilităţii guvernării, Ştefan cel Mare a eliminat tendinţele marii boierimi de anarhie şi de nesupunere faţă de puterea centrală, a favorizat consolidarea economică a ţărănimi libere (răzeşii), a încurajat clasa negustorească şi legăturile comerciale externe. În plus, a acordat o atenţie aparte structurilor militare tradiţionale ale ţării („oastea cea mică” – structură militară permanentă, şi „oastea cea mare” – chemată numai în caz de atac extern), susţinând introducerea unei discipline mai riguroase şi ameliorarea dotării. Măsurile sale militare au vizat şi întărirea capacităţii defensive a ţării, prin consolidarea şi modernizarea cetăţilor Hotin, Tighina, Soroca, Chilia, Cetatea Albă, Suceava, Neamţ, Crăciuna." +
                    "Prosperitatea economică a ţării i-a permis lui Ştefan cel Mare punerea în aplicare a unei politici de construire a unor edificii religioase, cu important rol cultural-artistic, dar şi militar. Acest fapt este considerat realizarea cea mai perenă a domniei voievodului moldovean. Epoca lui Ştefan cel Mare rămâne una de referinţă în istoria artei moldoveneşti, deoarece atunci se pun bazele aşa-numitului „stil moldovenesc” în arhitectura şi pictura religioasă. Arta iconografică din perioada ştefaniană este ilustrată de frescele din biserica de la Lujeni (astăzi Ucraina), Dolheşti, Bălineşti, Sf. Nicolae din Rădăuţi, Pătrăuţi, Voroneţ şi Sf. Ilie. Primele ansambluri complete ce s-au păstrat din vechea pictură ştefaniană sunt cele de la Pătrăuţi (1487), Voroneţ (1488), Sf. Ilie (1488), la care mai poate fi adăugat cu titlu de inventar şi cel de la Milişăuţi, distrus odată cu biserica în primul război mondial. Este interesant de menţionat faptul că reprezentările evangheliştilor de la Voroneţ sunt reproduceri fidele ale prototipurilor fixate de Gavril Uric în tetraevanghelul său din 1429, fapt ce sugerează o anumită continuitate de tradiţie a picturii moldoveneşti din veacul al XV-lea. Zugrăveala din altarul şi naosul bisericii mănăstirii Nemţ (1497) constituie ultimul ansamblu de pictură ce ne-a mai rămas din epoca lui Ştefan cel Mare." +
                    "Victoriile militare spectaculoase ale lui Ştefan cel Mare, repurtate practic împotriva tuturor vecinilor săi (turci, tătari, maghiari, poloni) au fost pregătite întotdeauna de o politică externă foarte abilă, ce a permis voievodului ca, înconjurat de trei adversari redutabili (Ungaria, Polonia şi Imperiul Otoman), să nu se angajeze niciodată într-un conflict pe două fronturi. Din punct de vedere diplomatic, Ştefan cel Mare a purtat negocieri şi a încheiat alianţe, în funcţie de împrejurări, cu o serie de state puternice din estul, centrul şi vestul Europei (Hanatul de Crimeea, Imperiul Otoman, cnezatul de Moscova, Polonia, Ungaria, Veneţia, Statul Papal). La acestea se adaugă şi tratativele iniţiate în vederea organizării unei alianţe antiotomane cu Uzun Hassan, şahul statului turcoman din Anatolia orientală şi Iranul Occidental."
                };
                historyCategory.LearnLevels.Add(learnLevel1History);

                var learnQuestion1LearnLevel1History = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Pe cine a invins Stefan cel Mare pentru a cuceri tronul Moldovei?",
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
                    Text = "Vlad Tepes",
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
                    Text = "Care sunt primele ansambluri complete ce s-au pastrat din vechea pictura stefaniana?",
                };
                learnLevel1History.LearnQuestions.Add(learnQuestion2LearnLevel1History);

                var learnQuestionAnswer1Question2LearnLevel1History = new LearnQuestionAnswerEntity()
                {
                    Text = "Voronet",
                    IsCorrect = true
                };
                learnQuestion2LearnLevel1History.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel1History);

                var learnQuestionAnswer2Question2LearnLevel1History = new LearnQuestionAnswerEntity()
                {
                    Text = "Doljesti",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question2LearnLevel1History = new LearnQuestionAnswerEntity()
                {
                    Text = "Chilia",
                    IsCorrect = false
                };

                var learnQuestionAnswer4Question2LearnLevel1History = new LearnQuestionAnswerEntity()
                {
                    Text = "Patrauti",
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
                    Text = "Napoleon Bonaparte (n. 15 august 1769, Ajaccio, Corsica - d. 5 mai 1821, în Insula Sfânta Elena), cunoscut mai târziu ca Napoleon I și inițial ca Napoleone di Buonaparte, a fost un lider politic și militar al Franței, ale cărui acțiuni au influențat puternic politica europeană de la începutul secolului al XIX-lea." +
                    "Născut în Corsica și specializat pe profilul de ofițer de artilerie în Franța continentală, Bonaparte a devenit cunoscut în timpul Primei Republici Franceze și a condus campanii reușite împotriva Primei și celei de-a Doua Coaliții, care luptau împotriva Franței. În 1799 a organizat o lovitură de stat și s-a proclamat Prim Consul; cinci ani mai târziu s-a încoronat ca Împărat al francezilor. În prima decadă a secolului al XIX-lea a opus armatele Imperiului Francez împotriva fiecărei puteri majore europene și a dominat Europa continentală printr-o serie de victorii militare. A menținut sfera de influență a Franței prin constituirea unor alianțe extensive și prin numirea prietenilor și membrilor familiei în calitate de conducători ai altor țări europene sub forma unor state clientelare franceze." +
                    "Invazia franceză a Rusiei din 1812 a marcat un punct de cotitură în destinul lui Napoleon. Marea sa Armată a suferit pierderi covârșitoare în timpul campaniei și nu s-a recuperat niciodată pe deplin. În 1813, a Șasea Coaliție l-a înfrânt la Leipzig; în anul următor Coaliția a invadat Franța, l-a forțat pe Napoleon să abdice și l-a exilat pe insula Elba. În mai puțin de un an, a scăpat de pe Elba și s-a întors la putere, însă a fost învins în bătălia de la Waterloo din iunie 1815. Napoleon și-a petrecut ultimii șase ani ai vieții sub supraveghere britanică pe insula Sfânta Elena. O autopsie a concluzionat că a murit de cancer la stomac, deși Sten Forshufvud și alți oameni de știință au continuat să susțină că a fost otrăvit cu arsenic." +
                    "Conflictul cu restul Europei a condus la o perioadă de război total de-a lungul continentului, iar campaniile sale sunt studiate la academii militare din întreaga lume. Deși considerat un tiran de către oponenții săi, el a rămas în istorie și datorită creării Codului Napoleonian, care a pus fundațiile legislației administrative și judiciare în majoritatea țărilor Europei de Vest." +
                    "Devenit absolvent în septembrie 1785, Bonaparte este numit ofițer cu gradul de sublocotenent în regimentul de artilerie La Fère. A servit în garnizoanele de la Valence și Auxonne până după izbucnirea Revoluției Franceze în 1789, deși în această perioadă a fost în permisie timp de aproape două luni în Corsica și Paris. Un naționalist corsican fervent, Bonaparte i-a scris liderului corsican Pasquale Paoli în mai 1789: „Pe când națiunea pierea, m-am născut eu. Treizeci de mii de francezi au fost vomitați pe malurile noastre, înecând tronul libertății în valuri de sânge. Astfel arăta priveliștea odioasă care a fost prima ce m-a impresionat.”" +
                    "A petrecut primii ani ai Revoluției în Corsica, luptând într-o bătălie complexă între regaliști, revoluționari și naționaliștii corsicani. El a sprijinit facțiunea revoluționară iacobină, a câștigat gradul de locotenent-colonel și comanda unui batalion de voluntari. După ce depășise termenul permisiei și a condus o revoltă împotriva unei armate franceze din Corsica, a reușit totuși să convingă autoritățile militare din Paris să-l promoveze în gradul de căpitan în iulie 1792. S-a întors în Corsica din nou și a intrat în conflict cu Paoli, care hotărâse să se despartă de Franța și să saboteze un asalt francez asupra insulei sardiniene La Maddalena, unul dintre liderii expediției fiind chiar Bonaparte. Acesta și familia sa au trebuit să fugă în Franța continentală în iunie 1793 din cauza înrăutățirii relațiilor cu Paoli." +
                    "Lui Napoleon i se permisese să ia cu el în exil câțiva prieteni și servitori, printre care Henri-Gratien Bertrand, fostul mareșal al palatului, și contele Charles-Tristan de Montholon, un membru al aristocrației prerevoluționare. Bertrand era în slujba lui Napoleon din 1798, dar Montholon era un aderent de ultima oră – după prima abdicare a lui Napoleon se grăbise să-și ofere serviciile monarhiei restaurate, dar a trecut de partea împăratului când acesta s-a întors de pe Insula Elba. El o adusese cu sine și pe tânăra și atrăgătoarea lui soție, ale cărei atenții față de Napoleon și vizitele nocturne pe care le făcea în dormitorul acestuia deveniseră curând subiect de bârfa pe insulă." +
                    "La un an după înfrângerea de la Leipzig, întreg imperiul s-a prăbușit. Burbonii au fost readuși la tronul Franței prin Ludovic al XVIII-lea. Aceasta revenire nu s-a bucurat însă de unanimitatea aliaților, între care au intervenit repede divergențe. Unitatea coaliției a fost însă salvată chiar de Napoleon. Înconjurat de dezbinarea aliaților, Napoleon părăsește insula Elba și începe ceea ce avea să fie aventura „celor o sută de zile”. Reîntronat, acesta începe să viseze la refacerea marelui imperiu[necesită citare]. Obține chiar câteva victorii. Pentru scurt timp însă, căci este înfrânt în bătălia de la Waterloo (18 iunie 1815). Silit să abdice din nou, Napoleon a fost exilat pe insula Sf. Elena, unde a murit în condiții neclare, câțiva ani mai târziu, la vârsta de 51 de ani (5 mai 1821). Există două teorii importante cu privire la moartea sa: otrăvirea cronică cu arsenic și cancerul la stomac. A fost înmormântat cu onoruri militare" +
                    "Controversele asupra morții împăratului Napoleon nu se mai termină... Specialiști în domeniul medicinei legale, istorici ai vieții și morții lui Napoleon s-au dedicat încă din anul 1961 cercetărilor cauzei morții acestui om de stat francez. Unii spun că moartea s-ar datora unei erori medicale, cancerului de stomac și, în cele din urmă, otrăvirii acestuia cu arsenic. Primele două supoziții - eroare medicală sau cancer de stomac, sunt definitiv respinse de Dr. Pascal Kintz."
                };

                historyCategory.LearnLevels.Add(learnLevel2History);

                var learnQuestion1LearnLevel2History = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Pe ce insula a fost exilat Napoleon Bonaparte?",
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
                    Text = "Insula Sfantul Paul",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question1LearnLevel2History = new LearnQuestionAnswerEntity()
                {
                    Text = "Insula Sfanta Elena",
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
                    Text = "Războiul Rece (1947–1991) a fost o perioadă de tensiuni și confruntări politice și ideologice, o stare de tensiune întreținută care a apărut după sfârșitul celui de-al Doilea Război Mondial și a durat până la revoluțiile din 1989. În Războiul Rece s-au confruntat două grupuri de state care aveau ideologii și sisteme politice foarte diferite. Într-un grup se aflau URSS și aliații ei, grup căruia i se spunea uzual „Blocul răsăritean” (sau oriental). Celălalt grup cuprindea SUA și aliații săi, fiind numit, uzual, „Blocul apusean” (sau occidental). La nivel politico-militar, în Europa, cele două blocuri erau reprezentate de către două alianțe internaționale. Blocul apusean era reprezentat de către Organizația Tratatului Atlanticului de Nord (NATO, North Atlantic Treaty Organization), iar cel răsăritean de către Pactul de la Varșovia. După sfârșitul celui de-al Doilea Război Mondial în Europa, Germania a fost divizată în patru zone de ocupație. Vechea capitală a Germaniei, Berlinul, ca sediu al Comisiei Aliate de Control, a fost împărțită în patru zone de ocupație corespunzătoare. Zidul Berlinului, un simbol al Războiului Rece, a fost construit, constituind, timp de aproape 28 de ani, o barieră de separare între Republica Federală Germană și Republica Democrată Germană." +
                    "Războiul Rece a fost, însă, un conflict la scară mondială, SUA și URSS mai având și multe alte state aliate în afara Europei, ce nu făceau parte din cele două alianțe militare oficiale. La nivel economic, Războiul Rece a fost o confruntare între capitalism și comunism. Pe plan ideologico-politic, a fost o confruntare între democrațiile liberale occidentale și regimurile comuniste totalitare. Ambele tabere se autodefineau în termeni pozitivi: statele blocului occidental își spuneau „lumea liberă” sau „societatea deschisă”, iar statele blocului oriental își spuneau „lumea anti-imperialistă” sau „democrațiile populare”." +
                    "Înfruntarea dintre cele două blocuri a fost numită „Război Rece”, deoarece nu s-a ajuns la confruntări militare directe între cele două superputeri, care ar fi constituit un „Război Cald”, cu toate că perioada a generat o cursă a înarmării. Din punctul de vedere al studiilor strategice, există opinia că nu s-a ajuns și nu se putea ajunge la un „Război Cald”, la o confruntare militară convențională, datorită faptului că ambele superputeri, SUA și URSS, s-au dotat cu arme nucleare, ceea ce a creat o situație militară strategică de „deterrence”, adică de descurajare și blocare reciprocă. În cazul unui război real, s-ar fi ajuns la o distrugere reciprocă totală și, totodată, la o catastrofă mondială. Un rol important l-au jucat serviciile secrete, confruntându-se, în primul rând, cele americane (CIA, NSA) cu KGB-ul sovietic. Au fost implicate, însă, și serviciile secrete vest-europene (britanice, vest-germane, franceze, italiene, etc.) și est-europene (Securitatea, STASI, etc.). Denumirea de „Război Rece” mai provine și din faptul că a fost purtat între foștii aliați din războiul împotriva regimului totalitar nazist. Din punct de vedere al mijloacelor utilizate, Războiul Rece a fost un conflict în care s-au utilizat presiunea diplomatică, militară, economică, ajutorul pe scară largă pentru statele-client, manevrele diplomatice, spionajul, curse ale înarmărilor convenționale și nucleare, coaliții militare, rivalitate la evenimentele sportive, competiție tehnologică, campanii masive de propagandă, asasinatul, operațiunile militare de intensitate mică și iminența unui război pe scară mare. Un moment în care Războiul Rece putea să devină unul „cald” îl reprezintă anul 1962, când sovieticii au plasat în Cuba, devenită comunistă sub Fidel Castro, rachete cu rază medie de acțiune. Americanii au răspuns prin instalarea unei blocade maritime, ajungând foarte aproape de a declanșa o bătălie navală cu sovieticii. În cele din urmă, însă, prin intervenția președintelui american Kennedy, s-a ajuns la normalizarea relațiilor cu sovieticii. A urmat o perioadă de destindere, marcată de întâlnirea dintre Kennedy și Nichita Hrușciov, în 1963, când au stabilit ca, în viitor, pentru comunicări urgente și de importanță majoră între Casa Albă și Kremlin să folosească „telefonul roșu” (care era, de fapt, un telex)." +
                    "Alte momente tensionate ale Războiului Rece au fost, cronologic: Blocada Berlinului (1948–1949), Războiul din Coreea (1950–1953), Criza Berlinului din 1961, Criza Suezului (1962), Războiul din Vietnam (1959–1975), Războiul de Iom Kippur (1973), Războiul Afgano-Sovietic (1979–1989), Doborârea cursei KAL 007 (1983) și Exercițiul militar NATO „Able Archer” (1983). La mijlocul anilor 1980, noul lider sovietic, Mihail Gorbaciov a introdus reformele de liberalizare numite „perestroika” (reorganizare sau restructurare) și „glasnost” (deschidere sau transparență) și a retras trupele sovietice din Afghanistan. Presat de cererile de independență națională a sateliților sovietici din estul Europei (Polonia, în special), Gorbaciov a refuzat să trimită trupele sovietice pentru a reprima revoluțiile ce se desfășurau pe cale pașnică (exceptând Revoluția din România)." +
                    "Războiul Rece s-a atenuat odată cu prăbușirea regimurilor comuniste din Europa Centrală și de Est, precum și din Mongolia, Cambodgia și Yemenul de Sud, urmată, doi ani mai târziu, în decembrie 1991, și de destrămarea Uniunii Sovietice. Lumea care a rămas este dominată de o singură superputere, SUA. Această situație este, de regulă, descrisă drept hegemonie globală a SUA într-o lume unipolară, deși unii autori consideră că lumea actuală este multipolară.Statele central-europene și est-europene (care, timp de patru decenii, se aflaseră sub dominația sovieticǎ), s-au democratizat și au ales să se integreze în NATO și Uniunea Europeană. SUA au fost ancorate în Războiul împotriva terorismului și în rǎzboaiele locale din Orientul Mijlociu (precum sunt cele din Afghanistan și Irak), mal ales, după Atentatele din 11 septembrie 2001. China a atins cea mai rapidă creștere economică, iar între anii 2004 și 2010 a depășit toate prognozele, devenind un concurent serios pentru SUA.De asemenea, criza economică mondială începută în 2008 a afectat, în special, zona occidentală, astfel că, în timp ce în Statele Unite marile bănci aveau probleme sau intrau în faliment, China a beneficiat de pe urma investițiilor strategice și au stimulat-o să declanșeze rǎzboiul economic cu SUA pentru supremația mondială. După douǎ decenii de destindere a relațiilor americano-ruse, urmatǎ, în 2008, de rǎcirea relațiilor diplomatice - consecință a rǎzboiului din Georgia - și, mai ales, pe fondul crizei din Ucraina, tensiunile, ostilitățile și rivalitǎțile anterioare dintre cele două puteri s-au acutizat, astfel că, în 2014, a reizbucnit Războiul Rece între Statele Unite ale Americii/ statele membre ale Uniunii Europene/ Organizației Tratatului Atlanticului de Nord și Federația Rusă - condusă de Vladimir Putin - și aliații acesteia. Acest rǎzboi este cunoscut în Mass-Media ca „Al Doilea Război Rece”,[2][3][4][5] însă, spre deosebire de Războiul Rece anterior, de această dată, Germania reunificată are un rol geopolitic major în Europa. Reizbucnirea și amplificarea Războiul Rece dintre SUA și Rusia, pe fondul creșterii amenințării terorismului în Orientul Mijlociu devastat de războaie civile, revoluții în nordul Africii și ascensiunea economicǎ fulminantă a Chinei, generează noi și justificate neliniști privind redimensionarea galopantă a raporturilor de putere în lumea contemporană." +
                    "Războiul Rece a lăsat în urma sa o moștenire importantă, adesea menținută în cultura populară și în mass-media, teme precum spionajul (cum este, spre exemplu, seria filmelor de succes internațional avându-l ca erou pe James Bond) și amenințarea războiului nuclear bucurându-se de o mare și constantă popularitate."
                };

                historyCategory.LearnLevels.Add(learnLevel3History);

                var learnQuestion1LearnLevel3History = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "In ce perioada a avut loc Razboiul Rece?",
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
                    Text = "Cum se numeau reformele de liberalizare introduce de Mihai Gorbaciov in anii '80?",
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

                categoryRepository.Update(historyCategory);//asta actualizeaza locatia pana unde s-a rezolvat in learn pt history

                //--------------------

                var sportsCategory = categoryRepository.GetCategoryByName("Sports");

                var learnLevel1Sports = new LearnLevelEntity()
                {
                    LearnLevelNumber = 1,
                    //TODO Petros -> change these 2 lines
                    Image = "https://upload.wikimedia.org/wikipedia/ro/thumb/e/ef/Romania_national_football_team_logo.svg/200px-Romania_national_football_team_logo.svg.png",
                    Text = "Echipa națională de fotbal a României este prima reprezentativă a României și se află sub controlul Federației Române de Fotbal (FRF). România a fost una dintre cele patru țări care au participat la primele trei campionate mondiale de fotbal, alături de selecționatele Braziliei, Franței și Belgiei. Totuși, între edițiile 1950 și 1986, România a reușit să se califice numai la un singur turneu final. Între 1990 și 2000 selecționata României s-a calificat în șaisprezecimile sau chiar optimile a trei campionate mondiale consecutive. Această perioadă prielnică și-a atins culmea în cadrul turneului final al Campionatul Mondial din 1994, când România, avându-l căpitan pe Gheorghe Hagi, a ajuns în sferturile de finală învingând Argentina cu scorul de 3-2. Ulterior a pierdut cu Suedia la penaltiuri." +
                    "România a făcut de asemenea o figură bună la Euro 2000, când a obținut un 1-1 cu Germania și a învins Anglia cu 3-2 în grupe, trecând mai departe în sferturile de finală, unde a fost învinsă de Italia." +
                    "Din 1939 până în anii 1990 golgheterul absolut al echipei naționale de fotbal a României a fost Iuliu Bodola, cu 30 de goluri marcate. În prezent recordul de goluri marcate pentru echipa națională este deținut de Gheorghe Hagi și Adrian Mutu, amândoi cu 35 de reușite." +
                    "Au urmat alți șase ani fără prezențe la turneele finale, până la Italia 1990, unde România revenea la un Mondial după 20 de ani. Din echipa condusă de Emeric Ienei făceau parte tinerii Gheorghe Hagi, Florin Răducioiu sau Ilie Dumitrescu. Campionul european cu Steaua București, Marius Lăcătuș avea să fie eroul primului meci, marcând două goluri în poarta U.R.S.S., de care România a trecut cu 2-0 la Bari. Același oraș a găzduit și al doilea meci al tricolorilor, cu reprezentativa Camerunului, pierdut cu 2-1. Golul României a fost marcat de Gavril Balint. În ultimul meci din grupă, România a întâlnit Argentina, campioana mondială en-titre și echipa în rândul căreia evolua Diego Maradona. Ca un făcut, jocul a avut loc la Napoli, orașul în care Maradona evolua la echipa de club. Sud-americanii au marcat primii, dar Balint avea să egaleze și să ducă România în optimile de finală. Aici a urmat înfruntarea cu Irlanda, și după un 0-0 la capătul a 120 de minute, disputa s-a decis la executarea loviturilor de departajare, unde singura ratare i-a aparținut lui Daniel Timofte și România rata întâlnirea cu Italia, în sferturi." +
                    "După ratarea calificării la EURO 1992, România a fost aproape să rateze și accesul la Mondialul din 1994. La jumătatea preliminariilor a fost adus însă Anghel Iordănescu în postul de selecționer, și cu trei victorii în ultimele trei meciuri, între care un succes cu Belgia la București și unul în Țara Galilor, România avea să meargă la turneul final din Statele Unite." +
                    "Pe 18 iunie 1994, la Los Angeles, România a întâlnit Columbia, echipă considerată favorită la titlu de brazilianul Pelé. Florin Răducioiu a deschis scorul, iar Gheorghe Hagi l-a majorat cu un gol incredibil, un șut din apropierea tușei din stânga a terenului, de la peste 30 de metri de poartă. Pe final, pe un contraatac, Răducioiu consfințea scorul final, 3-1, după ce columbienii reduseseră din handicap." +
                    "Patru zile mai târziu, la Detroit, într-un stadion acoperit, România a întâlnit Elveția în fața căreia avea să piardă cu 4-1. Doar un succes în fața Statelor Unite, organizatoarea competiției, ducea România în faza eliminatorie, și victoria a venit din nou pe stadionul Rose Bowl din Los Angeles. Dan Petrescu a marcat unicul gol al partidei." +
                    "În optimile de finală, adversar a fost Argentina, fără Diego Maradona care tocmai fusese suspendat pentru consum de droguri. La tricolori nu juca Răducioiu, din cauza acumulării de cartonașe galbene, dar absența lui a fost suplinită perfect de Ilie Dumitrescu, autorul unei duble, iar Gheorghe Hagi a înscris și el într-o victorie cu 3-2 care a dus în premieră pe tricolori în sferturile de finală mondiale. Aici, tot loviturile de departajare aveau să oprească România, ca și în 1990. Împotriva Suediei, Răducioiu a împins meciul în prelungiri după ce scandinavii marcaseră primii, pentru ca din nou Răducioiu să înscrie pentru 2-1 în minutul 101. Însă cu cinci minute înainte de finalul jocului, Kennet Andersson a readus egalitatea și la șuturile de la 11 metri Dan Petrescu și Miodrag Belodedici au ratat pentru tricolori după ce prima ratare aparținuse suedezilor." +
                    "În 1996, România a revenit și la Campionatul European, participând la EURO 1996 din Anglia, unde însă a pierdut toate meciurile din grupă: 0-1 cu Franța și Bulgaria și 1-2 cu Spania, golul României fiind marcat de Florin Răducioiu." +
                    "A treia prezență consecutivă la Campionatul Mondial a fost consemnată în Franța 1998, unde România a fost cap de serie la tragerea la sorți. În ciuda acestui avantaj, grupa a fost una dificilă, cu Columbia, de care tricolorii au trecut cu 1-0, gol Adrian Ilie, și Anglia. La Toulouse, Viorel Moldovan a deschis scorul, Michael Owen a egalat, dar Dan Petrescu a adus victoria și calificarea în minutele de final. În ultimul meci, contra Tunisiei, echipa condusă de Anghel Iordănescu avea nevoie de un punct pentru a termina pe primul loc în grupă și meciul se încheia 1-1, Viorel Moldovan egalând în repriza secundă. Însă în optimile de finală adversar a fost Croația care s-a impus la limită, 1-0, Davor Suker transformând un penalti înainte de pauză." +
                    "Ultimul turneu final al Generației de Aur a fost EURO 2000, în Olanda și Belgia. Anghel Iordănescu plecase după Franța 1998, Victor Pițurcă a calificat echipa dar a fost demis înainte de turneul final unde selecționer a fost Emeric Ienei. Dintr-o grupă imposibilă, România obținea calificarea după 1-1 cu Germania, gol Viorel Moldovan, 0-1 cu Portugalia și 3-2 în ultimul meci, contra Angliei. Disputa de la Charleroi a început cu golul lui Cristian Chivu, dar englezii au intrat în avantaj de un gol la cabine. Dorinel Munteanu a egalat la 2, iar Ionel Ganea a transformat un penalti în minutul 89, aducând victoria și calificarea." +
                    "Adversar în sferturile de finală a fost Italia, la Bruxelles. În minutul 35, Gheorghe Hagi a fost eliminat pentru proteste, iar cu un jucător în plus italienii s-au impus cu 2-0."
                };

                sportsCategory.LearnLevels.Add(learnLevel1Sports);

                var learnQuestion1LearnLevel1Sports = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "De cine a fost invinsa Romania in sferturile de finala a Campionatului European din 2000?",
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
                    Text = "Cine a marcat unicul gol din victoria decisiva a Romaniei contra Statelor Unite de la Cupa Mondiala 1994?",
                };
                learnLevel1Sports.LearnQuestions.Add(learnQuestion2LearnLevel1Sports);

                var learnQuestionAnswer1Question2LearnLevel1Sports = new LearnQuestionAnswerEntity()
                {
                    Text = "Florin Raducioiu",
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
                    Text = "Nadia Elena Comăneci (n. 12 noiembrie 1961, Onești, România) este o gimnastă română, prima gimnastă din lume care a primit nota zece într-un concurs olimpic de gimnastică. Este câștigătoare a cinci medalii olimpice de aur. Este considerată a fi una dintre cele mai bune sportive ale secolului XX și una dintre cele mai bune gimnaste ale lumii, din toate timpurile, „Zeița de la Montreal”, prima gimnastă a epocii moderne care a luat 10 absolut. Este primul sportiv român inclus în memorialul International Gymnastics Hall of Fame." +
                    "Nadia s-a născut la Onești, find fiica lui Gheorghe și Ștefania-Alexandrina Comăneci[3]; a fost botezată după „Nadejda” („Speranță”), eroină a unui film. Unele surse susțin că s-ar fi născut ca „Anna Kemenes”.[4][5][6] Această variantă a fost dezmințită în noiembrie 2016 atât de Nadia cât și de mama sa, Ștefania" +
                    "A concurat pentru prima dată la nivel național în România, în 1970, ca membră a echipei orașului său. Curând, a început antrenamentele cu Béla Károlyi și soția acestuia, Márta Károlyi, care au emigrat mai târziu în Statele Unite, devenind antrenori ai multor gimnaste americane. La vârsta de 13 ani, primul succes major al lui Comăneci a fost câștigarea a trei medalii de aur și una de argint la Campionatele Europene din 1975, de la Skien, Norvegia. În același an, agenția de știri Associated Press a numit-o --Atleta Anului--." +
                    "La 14 ani, Comăneci a devenit o stea a Jocurilor Olimpice de Vară din 1976 de la Montreal, Québec. Nu numai că a devenit prima gimnastă care a obținut scorul perfect de zece la olimpiadă (de șapte ori), dar a și câștigat trei medalii de aur (la individual compus, bârnă și paralele), o medalie de argint (echipă compus) și bronz (sol). Acasă, succesul său i-a adus distincția de „Erou al Muncii Socialiste”, fiind cea mai tânără româncă distinsă cu acest titlu." +
                    "Comăneci și-a apărat titlul european în 1977, dar echipa României a ieșit din competiție în finale, în semn de protest contra arbitrajului. La Campionatele Mondiale din 1978 a concurat o Nadia Comăneci cu greutate peste medie și ieșită din formă. Căderea la paralele a trimis-o pe locul 4, însă a câștigat titlul de campioană mondială la bârnă." +
                    "În 1979, Comăneci, din nou la greutate normală, a câștigat cel de-al treilea titlu european la individual compus (devenind primul sportiv din istoria gimnasticii care a reușit această performanță). La Campionatele Mondiale din decembrie, ea a câștigat concursul preliminar, dar a fost spitalizată înainte de a participa la concursul pe echipe, din cauza unei infecții, în urma unei tăieturi la încheietura mâinii, cauzată de o cataramă din metal. În ciuda recomandărilor doctorilor, ea a părăsit spitalul și a concurat la bârnă, unde a obținut nota 9,95. Performanța sa a conferit României prima medalie de aur în concursul pe echipe." +
                    "A participat și la Jocurile Olimpice din 1980 de la Moscova, clasându-se a doua după Elena Davîdova la individual compus, când a fost nevoită să aștepte pentru notă până ce Davîdova și-a încheiat exercițiul. Nadia și-a păstrat titlul la bârnă, dar a câștigat și o nouă medalie de aur, la sol, și una de argint, împreună cu echipa"

                };

                sportsCategory.LearnLevels.Add(learnLevel2Sports);

                var learnQuestion1LearnLevel2Sports = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Caderea de la paralele a Nadiei Comaneci de la Campionatele Mondiale din 1978, au trimis-o pe locul?",
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
                    Text = "Care a fost nota exacta obtinuta de Nadia Comanescu la barna in anul 1979?",
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
                    Text = "Jordan s-a născut în Brooklyn, New York, fiul lui Deloris , care a lucrat în domeniul bancar, și James R. Jordan, un supraveghetor de echipamente. Familia sa s-a mutat la Wilmington, Carolina de Nord, atunci când era copil. Jordan a mers la școală la Emsley A. Laney High School din Wilmington, unde a ancorat cariere atletice jucând baseball, fotbal american și baschet. El a încercat pentru echipa de baschet Varsity în al doilea an de studenție, dar la abia 1,80 m, el a fost considerat prea scund pentru a juca la acest nivel. Prietenul lui mai înalt, Harvest Leroy Smith, a fost singurul care a fost ales dintre Sophomores pentru a face parte din echipă." +
                    "Motivat să își dovedească valoarea, Jordan a devenit steaua echipei de juniori și a fost cel mai bun marcator în 40 de jocuri. În vara următoare, el a crescut 10 cm în înălțime,și antrenându-se în mod riguros a câștigat un loc în echipa mare, obținând o medie de aproximativ 20 de puncte pe meci.. Ca senior, a fost selectat la McDonald's All-American-Team după un sezon încheiat cu o triplă dublă ca medie: 29.2 puncte, 11.6 recuperări și 10.1 pase decisive. În 1981, Jordan a câștigat o bursă de baschet la Universitatea din Carolina de Nord la Chapel Hill, unde s-a specializat în geografie culturală. Ca un boboc în echipa condusă de Dean Smith, a fost numit bobocul ACC al anului, cu o medie de 13.4 puncte pe meci (PPG) și o medie de 53,4% la aruncarea la coș. El a realizat coșul decisiv în finala campionatului NCAA din 1982 împotriva celor de la Georgetown, la care juca viitorul său rival din NBA Patrick Ewing. Jordan a descris acel coș un moment decisiv în cariera lui de baschet. În timpul celor trei sezoane de la Carolina de Nord, el a avut o medie de 17.7 puncte pe meci la 54,0% și a adăugat 5.0 recuperări pe meci (RPG)." +
                    "Michael Jordan în timp ce joacă cu Scorpions Scottsdale,în data de 6 octombrie 1993, își anunță retragerea, citând o pierdere din dorința de a juca acest joc. Jordan a declarat mai târziu că uciderea tatălui sau mai devreme in acel i-a schimbat deciziile.. James R. Jordan Sr. a fost ucis la 23 iulie 1993, intr-o de odihna de pe autostrada în Lumberton, Carolina de Nord, de către doi adolescenți , Daniel Martin Demery verde și Larry. Atacatorii au fost trasate de apeluri au făcut apeluri de pe telefonul celular James Jordan, prins, condamnat, și condamnat la închisoare pe viață. Jordan a fost aproape de tatăl său ca un copil, având o înclinație de la el de a scoate limba în timp ce e absorbit în muncă. El,mai târziu a adoptat și semnătura proprie, de la afișarea ei de fiecare dată, la coș după coș. În 1996 el a fondat zona Chicago Boys & Girls Club și dedicat tatălui său." +
                    "Jordan a scris că el a făcut pregătirea pentru pensionare cât mai devreme,in vara anului 1992. Epuizarea adăugată datorită „Dream Team”,în timpul Jocurile Olimpice de vară din 1992 a solidificat sentimentele lui Jordan despre joc și statutul său de celebritate în continuă creștere. Anuntul lui Jordan a trimis unde de șoc în întregul NBA și a apărut pe primele pagini ale ziarelor din întreaga lume. Jordan a surprins și mai mult lumea sportului prin semnarea unui contract de baseball minor in liga cu Chicago White Sox. El a confirmat la primvara de formare și a fost repartizat la sistemul echipei de ligă minoră pe 31 martie 1994.[43] Jordan a declarat că această decizie a fost luată ca să urmarească visul tatălui său, care și l-a imaginat mereu pe fiul său ca un jucător Major League Baseball." +
                    "Jordan a jucat în două echipe olimpice care au câștigat aurul la basket. În facultate a participat la jocurile olimpice de vară din anul Jocurile Olimpice de vară din 1984 și a câștigat. Jordan a condus echipa marcând în medie 17,1 puncte pe meci în timpul campionatului. În jocurile olimpice din anul Jocurile Olimpice de vară din 1992 a fost membru al unei echipe pline de staruri împreună cu Magic Johnson, Larry Bird, and David Robinson echipa a fost denumită ”Dream team”(echipa de vis). A jucat minute limitate datorită unor probleme personale, jordan a înscris în medie 12,7 puncte pe meci, ieșind al patrulea din echipă la marcaj. Jordan, Patrick Ewing și un alt membru alt membru al „Echipei de vis”, Chris Mullin sunt singurii jucători de basket masculin din America care au câștigat aurul olimpic atât ca amatori (în 1984), dar și ca profesioniști. În plus jordan și un alt membru al „Echipei de vis” (un coechipier de la Bulls) Scottie Pippen sunt singurii jucători care au câștigat atât campionatul de NBA cât și aurul olimpic în același an (1992)."
                };

                sportsCategory.LearnLevels.Add(learnLevel3Sports);

                var learnQuestion1LearnLevel3Sports = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Cate puncte a marcat in echipa McDonald's All-American-Team la finalul sezonului in anul 1980 ?",
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
                    Text = "Dupa moartea tatalui sau, ce zona a fondat Michael Jordan, in semn de recunostinta?",
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

                categoryRepository.Update(sportsCategory);//-asta actualizeaza locatia pana unde s-a rezolvat in learn pt sports


                //--------------



                var geographyCategory = categoryRepository.GetCategoryByName("Geography");

                var learnLevel1Geography = new LearnLevelEntity()
                {
                    LearnLevelNumber = 1,
                    //TODO Petros -> change these 2 lines
                    Image = "https://www.europafm.ro/wp-content/uploads/2017/07/Stefan-Cel-Mare.jpg",
                    Text = "La 3 februarie 1531, la nici trei decenii de la trecerea în nefiinţă, Ştefan al III-lea, principele Ţării Moldovei, era amintit de Sigismund I, regele Poloniei (1506-1548), ca Stephanus ille magnus („acel mare Ştefan”). Bernard Wapowski, cartograful şi istoriograful oficial al aceluiaşi rege, consemna că domnul moldovean era „principele şi războinicul cel mai vestit” din epoca sa. Doctorul Matteo Muriano, trimis de Veneţia la Suceava, în vara anului 1502, spre a-i acorda asistenţa medicală principelui moldovean, consemna în raportul său că acesta „este un om foarte înţelept, vrednic de multă laudă, iubit mult de supuşii săi, pentru că este îndurător şi drept, veşnic treaz şi darnic”. Văzut de contemporanii lui europeni ca un şef de stat care a reuşit să se menţină la cârma ţării 47 de ani, pe plan intern el a simbolizat stabilitatea, continuitatea, dezvoltarea economică, dreptatea, încât la înmormântarea sa în Moldova „jale era, că plângea toţi ca pe un părinte al său …” (Grigore Ureche)." +
                    "Ştefan cel Mare, fiul lui Bogdan al II-lea (1449-1451) şi al soţiei sale Oltea, s-a născut cel mai probabil în anul 1438. După moartea tatălui său, Ştefan s-a refugiat în Transilvania stăpânită de către Iancu de Hunedoara (1441-1456), unde s-a familiarizat cu tacticile militare ale acestuia, care îmbinau elemente de artă militară din estul, centrul şi apusul Europei. Cu o forţă militară pusă la dispoziţie de către Vlad Ţepeş (1448; 1456-1472; 1476), la care s-au adăugat partizanii săi din sudul Moldovei, Ştefan cel Mare l-a învins pe Petru Aron la Doljeşti (Dolheşti), cucerind tronul Moldovei pe data de 12 aprilie 1457. A găsit o ţară sărăcită, sfâşiată de luptele dintre diverşii pretendenţi la domnia Moldovei, o ţară ce plătea tribut turcilor începând cu anul 1456." +
                    "În asemenea circumstanţe, domnitorul a trebuit să iniţieze ample măsuri de redresare a situaţiei social-economice. Pentru a-şi asigura suportul politic necesar stabilităţii guvernării, Ştefan cel Mare a eliminat tendinţele marii boierimi de anarhie şi de nesupunere faţă de puterea centrală, a favorizat consolidarea economică a ţărănimi libere (răzeşii), a încurajat clasa negustorească şi legăturile comerciale externe. În plus, a acordat o atenţie aparte structurilor militare tradiţionale ale ţării („oastea cea mică” – structură militară permanentă, şi „oastea cea mare” – chemată numai în caz de atac extern), susţinând introducerea unei discipline mai riguroase şi ameliorarea dotării. Măsurile sale militare au vizat şi întărirea capacităţii defensive a ţării, prin consolidarea şi modernizarea cetăţilor Hotin, Tighina, Soroca, Chilia, Cetatea Albă, Suceava, Neamţ, Crăciuna." +
                    "Prosperitatea economică a ţării i-a permis lui Ştefan cel Mare punerea în aplicare a unei politici de construire a unor edificii religioase, cu important rol cultural-artistic, dar şi militar. Acest fapt este considerat realizarea cea mai perenă a domniei voievodului moldovean. Epoca lui Ştefan cel Mare rămâne una de referinţă în istoria artei moldoveneşti, deoarece atunci se pun bazele aşa-numitului „stil moldovenesc” în arhitectura şi pictura religioasă. Arta iconografică din perioada ştefaniană este ilustrată de frescele din biserica de la Lujeni (astăzi Ucraina), Dolheşti, Bălineşti, Sf. Nicolae din Rădăuţi, Pătrăuţi, Voroneţ şi Sf. Ilie. Primele ansambluri complete ce s-au păstrat din vechea pictură ştefaniană sunt cele de la Pătrăuţi (1487), Voroneţ (1488), Sf. Ilie (1488), la care mai poate fi adăugat cu titlu de inventar şi cel de la Milişăuţi, distrus odată cu biserica în primul război mondial. Este interesant de menţionat faptul că reprezentările evangheliştilor de la Voroneţ sunt reproduceri fidele ale prototipurilor fixate de Gavril Uric în tetraevanghelul său din 1429, fapt ce sugerează o anumită continuitate de tradiţie a picturii moldoveneşti din veacul al XV-lea. Zugrăveala din altarul şi naosul bisericii mănăstirii Nemţ (1497) constituie ultimul ansamblu de pictură ce ne-a mai rămas din epoca lui Ştefan cel Mare." +
                    "Victoriile militare spectaculoase ale lui Ştefan cel Mare, repurtate practic împotriva tuturor vecinilor săi (turci, tătari, maghiari, poloni) au fost pregătite întotdeauna de o politică externă foarte abilă, ce a permis voievodului ca, înconjurat de trei adversari redutabili (Ungaria, Polonia şi Imperiul Otoman), să nu se angajeze niciodată într-un conflict pe două fronturi. Din punct de vedere diplomatic, Ştefan cel Mare a purtat negocieri şi a încheiat alianţe, în funcţie de împrejurări, cu o serie de state puternice din estul, centrul şi vestul Europei (Hanatul de Crimeea, Imperiul Otoman, cnezatul de Moscova, Polonia, Ungaria, Veneţia, Statul Papal). La acestea se adaugă şi tratativele iniţiate în vederea organizării unei alianţe antiotomane cu Uzun Hassan, şahul statului turcoman din Anatolia orientală şi Iranul Occidental."
                };
                geographyCategory.LearnLevels.Add(learnLevel1Geography);

                var learnQuestion1LearnLevel1Geography = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Pe cine a invins Stefan cel Mare pentru a cuceri tronul Moldovei?",
                };
                learnLevel1Geography.LearnQuestions.Add(learnQuestion1LearnLevel1Geography);

                var learnQuestionAnswer1Question1LearnLevel1Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Iancu de Hunedoara",
                    IsCorrect = false
                };
                learnQuestion1LearnLevel1Geography.LearnQuestionAnswers.Add(learnQuestionAnswer1Question1LearnLevel1Geography);

                var learnQuestionAnswer2Question1LearnLevel1Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Petru Aron",
                    IsCorrect = true
                };

                var learnQuestionAnswer3Question1LearnLevel1Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Vlad Tepes",
                    IsCorrect = false
                };

                var learnQuestionAnswer4Question1LearnLevel1Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Gavril Uric",
                    IsCorrect = false
                };

                learnQuestion1LearnLevel1Geography.LearnQuestionAnswers.Add(learnQuestionAnswer2Question1LearnLevel1Geography);
                learnQuestion1LearnLevel1Geography.LearnQuestionAnswers.Add(learnQuestionAnswer3Question1LearnLevel1Geography);
                learnQuestion1LearnLevel1Geography.LearnQuestionAnswers.Add(learnQuestionAnswer4Question1LearnLevel1Geography);


                var learnQuestion2LearnLevel1Geography = new LearnQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Care sunt primele ansambluri complete ce s-au pastrat din vechea pictura stefaniana?",
                };
                learnLevel1Geography.LearnQuestions.Add(learnQuestion2LearnLevel1Geography);

                var learnQuestionAnswer1Question2LearnLevel1Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Voronet",
                    IsCorrect = true
                };
                learnQuestion2LearnLevel1Geography.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel1Geography);

                var learnQuestionAnswer2Question2LearnLevel1Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Doljesti",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question2LearnLevel1Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Chilia",
                    IsCorrect = false
                };

                var learnQuestionAnswer4Question2LearnLevel1Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Patrauti",
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
                    Image = "https://upload.wikimedia.org/wikipedia/commons/4/40/Napoleon_in_His_Study.jpg",
                    Text = "Napoleon Bonaparte (n. 15 august 1769, Ajaccio, Corsica - d. 5 mai 1821, în Insula Sfânta Elena), cunoscut mai târziu ca Napoleon I și inițial ca Napoleone di Buonaparte, a fost un lider politic și militar al Franței, ale cărui acțiuni au influențat puternic politica europeană de la începutul secolului al XIX-lea." +
                    "Născut în Corsica și specializat pe profilul de ofițer de artilerie în Franța continentală, Bonaparte a devenit cunoscut în timpul Primei Republici Franceze și a condus campanii reușite împotriva Primei și celei de-a Doua Coaliții, care luptau împotriva Franței. În 1799 a organizat o lovitură de stat și s-a proclamat Prim Consul; cinci ani mai târziu s-a încoronat ca Împărat al francezilor. În prima decadă a secolului al XIX-lea a opus armatele Imperiului Francez împotriva fiecărei puteri majore europene și a dominat Europa continentală printr-o serie de victorii militare. A menținut sfera de influență a Franței prin constituirea unor alianțe extensive și prin numirea prietenilor și membrilor familiei în calitate de conducători ai altor țări europene sub forma unor state clientelare franceze." +
                    "Invazia franceză a Rusiei din 1812 a marcat un punct de cotitură în destinul lui Napoleon. Marea sa Armată a suferit pierderi covârșitoare în timpul campaniei și nu s-a recuperat niciodată pe deplin. În 1813, a Șasea Coaliție l-a înfrânt la Leipzig; în anul următor Coaliția a invadat Franța, l-a forțat pe Napoleon să abdice și l-a exilat pe insula Elba. În mai puțin de un an, a scăpat de pe Elba și s-a întors la putere, însă a fost învins în bătălia de la Waterloo din iunie 1815. Napoleon și-a petrecut ultimii șase ani ai vieții sub supraveghere britanică pe insula Sfânta Elena. O autopsie a concluzionat că a murit de cancer la stomac, deși Sten Forshufvud și alți oameni de știință au continuat să susțină că a fost otrăvit cu arsenic." +
                    "Conflictul cu restul Europei a condus la o perioadă de război total de-a lungul continentului, iar campaniile sale sunt studiate la academii militare din întreaga lume. Deși considerat un tiran de către oponenții săi, el a rămas în istorie și datorită creării Codului Napoleonian, care a pus fundațiile legislației administrative și judiciare în majoritatea țărilor Europei de Vest." +
                    "Devenit absolvent în septembrie 1785, Bonaparte este numit ofițer cu gradul de sublocotenent în regimentul de artilerie La Fère. A servit în garnizoanele de la Valence și Auxonne până după izbucnirea Revoluției Franceze în 1789, deși în această perioadă a fost în permisie timp de aproape două luni în Corsica și Paris. Un naționalist corsican fervent, Bonaparte i-a scris liderului corsican Pasquale Paoli în mai 1789: „Pe când națiunea pierea, m-am născut eu. Treizeci de mii de francezi au fost vomitați pe malurile noastre, înecând tronul libertății în valuri de sânge. Astfel arăta priveliștea odioasă care a fost prima ce m-a impresionat.”" +
                    "A petrecut primii ani ai Revoluției în Corsica, luptând într-o bătălie complexă între regaliști, revoluționari și naționaliștii corsicani. El a sprijinit facțiunea revoluționară iacobină, a câștigat gradul de locotenent-colonel și comanda unui batalion de voluntari. După ce depășise termenul permisiei și a condus o revoltă împotriva unei armate franceze din Corsica, a reușit totuși să convingă autoritățile militare din Paris să-l promoveze în gradul de căpitan în iulie 1792. S-a întors în Corsica din nou și a intrat în conflict cu Paoli, care hotărâse să se despartă de Franța și să saboteze un asalt francez asupra insulei sardiniene La Maddalena, unul dintre liderii expediției fiind chiar Bonaparte. Acesta și familia sa au trebuit să fugă în Franța continentală în iunie 1793 din cauza înrăutățirii relațiilor cu Paoli." +
                    "Lui Napoleon i se permisese să ia cu el în exil câțiva prieteni și servitori, printre care Henri-Gratien Bertrand, fostul mareșal al palatului, și contele Charles-Tristan de Montholon, un membru al aristocrației prerevoluționare. Bertrand era în slujba lui Napoleon din 1798, dar Montholon era un aderent de ultima oră – după prima abdicare a lui Napoleon se grăbise să-și ofere serviciile monarhiei restaurate, dar a trecut de partea împăratului când acesta s-a întors de pe Insula Elba. El o adusese cu sine și pe tânăra și atrăgătoarea lui soție, ale cărei atenții față de Napoleon și vizitele nocturne pe care le făcea în dormitorul acestuia deveniseră curând subiect de bârfa pe insulă." +
                    "La un an după înfrângerea de la Leipzig, întreg imperiul s-a prăbușit. Burbonii au fost readuși la tronul Franței prin Ludovic al XVIII-lea. Aceasta revenire nu s-a bucurat însă de unanimitatea aliaților, între care au intervenit repede divergențe. Unitatea coaliției a fost însă salvată chiar de Napoleon. Înconjurat de dezbinarea aliaților, Napoleon părăsește insula Elba și începe ceea ce avea să fie aventura „celor o sută de zile”. Reîntronat, acesta începe să viseze la refacerea marelui imperiu[necesită citare]. Obține chiar câteva victorii. Pentru scurt timp însă, căci este înfrânt în bătălia de la Waterloo (18 iunie 1815). Silit să abdice din nou, Napoleon a fost exilat pe insula Sf. Elena, unde a murit în condiții neclare, câțiva ani mai târziu, la vârsta de 51 de ani (5 mai 1821). Există două teorii importante cu privire la moartea sa: otrăvirea cronică cu arsenic și cancerul la stomac. A fost înmormântat cu onoruri militare" +
                    "Controversele asupra morții împăratului Napoleon nu se mai termină... Specialiști în domeniul medicinei legale, istorici ai vieții și morții lui Napoleon s-au dedicat încă din anul 1961 cercetărilor cauzei morții acestui om de stat francez. Unii spun că moartea s-ar datora unei erori medicale, cancerului de stomac și, în cele din urmă, otrăvirii acestuia cu arsenic. Primele două supoziții - eroare medicală sau cancer de stomac, sunt definitiv respinse de Dr. Pascal Kintz."
                };

                geographyCategory.LearnLevels.Add(learnLevel2Geography);

                var learnQuestion1LearnLevel2Geography = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Pe ce insula a fost exilat Napoleon Bonaparte?",
                };
                learnLevel2Geography.LearnQuestions.Add(learnQuestion1LearnLevel2Geography);

                var learnQuestionAnswer1Question1LearnLevel2Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Insula Diavolului",
                    IsCorrect = false
                };
                learnQuestion1LearnLevel2Geography.LearnQuestionAnswers.Add(learnQuestionAnswer1Question1LearnLevel2Geography);

                var learnQuestionAnswer2Question1LearnLevel2Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Insula Sfantul Paul",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question1LearnLevel2Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Insula Sfanta Elena",
                    IsCorrect = true
                };

                var learnQuestionAnswer4Question1LearnLevel2Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Insula Man",
                    IsCorrect = false
                };

                learnQuestion1LearnLevel2Geography.LearnQuestionAnswers.Add(learnQuestionAnswer2Question1LearnLevel2Geography);
                learnQuestion1LearnLevel2Geography.LearnQuestionAnswers.Add(learnQuestionAnswer3Question1LearnLevel2Geography);
                learnQuestion1LearnLevel2Geography.LearnQuestionAnswers.Add(learnQuestionAnswer4Question1LearnLevel2Geography);


                var learnQuestion2LearnLevel2Geography = new LearnQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Ce prieteni a luat in exil Napoleon Bonaparte?",
                };
                learnLevel2Geography.LearnQuestions.Add(learnQuestion2LearnLevel2Geography);

                var learnQuestionAnswer1Question2LearnLevel2Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Pierre Simon Laplace",
                    IsCorrect = false
                };

                learnQuestion2LearnLevel2Geography.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel2Geography);

                var learnQuestionAnswer2Question2LearnLevel2Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Henri-Gratien Bertrand",
                    IsCorrect = true
                };

                var learnQuestionAnswer3Question2LearnLevel2Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Charles-Tristan de Montholon",
                    IsCorrect = true
                };

                var learnQuestionAnswer4Question2LearnLevel2Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Jacques-Louis David",
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
                    Image = "https://upload.wikimedia.org/wikipedia/ro/thumb/0/0b/ColdWar.jpg/300px-ColdWar.jpg",
                    Text = "Războiul Rece (1947–1991) a fost o perioadă de tensiuni și confruntări politice și ideologice, o stare de tensiune întreținută care a apărut după sfârșitul celui de-al Doilea Război Mondial și a durat până la revoluțiile din 1989. În Războiul Rece s-au confruntat două grupuri de state care aveau ideologii și sisteme politice foarte diferite. Într-un grup se aflau URSS și aliații ei, grup căruia i se spunea uzual „Blocul răsăritean” (sau oriental). Celălalt grup cuprindea SUA și aliații săi, fiind numit, uzual, „Blocul apusean” (sau occidental). La nivel politico-militar, în Europa, cele două blocuri erau reprezentate de către două alianțe internaționale. Blocul apusean era reprezentat de către Organizația Tratatului Atlanticului de Nord (NATO, North Atlantic Treaty Organization), iar cel răsăritean de către Pactul de la Varșovia. După sfârșitul celui de-al Doilea Război Mondial în Europa, Germania a fost divizată în patru zone de ocupație. Vechea capitală a Germaniei, Berlinul, ca sediu al Comisiei Aliate de Control, a fost împărțită în patru zone de ocupație corespunzătoare. Zidul Berlinului, un simbol al Războiului Rece, a fost construit, constituind, timp de aproape 28 de ani, o barieră de separare între Republica Federală Germană și Republica Democrată Germană." +
                    "Războiul Rece a fost, însă, un conflict la scară mondială, SUA și URSS mai având și multe alte state aliate în afara Europei, ce nu făceau parte din cele două alianțe militare oficiale. La nivel economic, Războiul Rece a fost o confruntare între capitalism și comunism. Pe plan ideologico-politic, a fost o confruntare între democrațiile liberale occidentale și regimurile comuniste totalitare. Ambele tabere se autodefineau în termeni pozitivi: statele blocului occidental își spuneau „lumea liberă” sau „societatea deschisă”, iar statele blocului oriental își spuneau „lumea anti-imperialistă” sau „democrațiile populare”." +
                    "Înfruntarea dintre cele două blocuri a fost numită „Război Rece”, deoarece nu s-a ajuns la confruntări militare directe între cele două superputeri, care ar fi constituit un „Război Cald”, cu toate că perioada a generat o cursă a înarmării. Din punctul de vedere al studiilor strategice, există opinia că nu s-a ajuns și nu se putea ajunge la un „Război Cald”, la o confruntare militară convențională, datorită faptului că ambele superputeri, SUA și URSS, s-au dotat cu arme nucleare, ceea ce a creat o situație militară strategică de „deterrence”, adică de descurajare și blocare reciprocă. În cazul unui război real, s-ar fi ajuns la o distrugere reciprocă totală și, totodată, la o catastrofă mondială. Un rol important l-au jucat serviciile secrete, confruntându-se, în primul rând, cele americane (CIA, NSA) cu KGB-ul sovietic. Au fost implicate, însă, și serviciile secrete vest-europene (britanice, vest-germane, franceze, italiene, etc.) și est-europene (Securitatea, STASI, etc.). Denumirea de „Război Rece” mai provine și din faptul că a fost purtat între foștii aliați din războiul împotriva regimului totalitar nazist. Din punct de vedere al mijloacelor utilizate, Războiul Rece a fost un conflict în care s-au utilizat presiunea diplomatică, militară, economică, ajutorul pe scară largă pentru statele-client, manevrele diplomatice, spionajul, curse ale înarmărilor convenționale și nucleare, coaliții militare, rivalitate la evenimentele sportive, competiție tehnologică, campanii masive de propagandă, asasinatul, operațiunile militare de intensitate mică și iminența unui război pe scară mare. Un moment în care Războiul Rece putea să devină unul „cald” îl reprezintă anul 1962, când sovieticii au plasat în Cuba, devenită comunistă sub Fidel Castro, rachete cu rază medie de acțiune. Americanii au răspuns prin instalarea unei blocade maritime, ajungând foarte aproape de a declanșa o bătălie navală cu sovieticii. În cele din urmă, însă, prin intervenția președintelui american Kennedy, s-a ajuns la normalizarea relațiilor cu sovieticii. A urmat o perioadă de destindere, marcată de întâlnirea dintre Kennedy și Nichita Hrușciov, în 1963, când au stabilit ca, în viitor, pentru comunicări urgente și de importanță majoră între Casa Albă și Kremlin să folosească „telefonul roșu” (care era, de fapt, un telex)." +
                    "Alte momente tensionate ale Războiului Rece au fost, cronologic: Blocada Berlinului (1948–1949), Războiul din Coreea (1950–1953), Criza Berlinului din 1961, Criza Suezului (1962), Războiul din Vietnam (1959–1975), Războiul de Iom Kippur (1973), Războiul Afgano-Sovietic (1979–1989), Doborârea cursei KAL 007 (1983) și Exercițiul militar NATO „Able Archer” (1983). La mijlocul anilor 1980, noul lider sovietic, Mihail Gorbaciov a introdus reformele de liberalizare numite „perestroika” (reorganizare sau restructurare) și „glasnost” (deschidere sau transparență) și a retras trupele sovietice din Afghanistan. Presat de cererile de independență națională a sateliților sovietici din estul Europei (Polonia, în special), Gorbaciov a refuzat să trimită trupele sovietice pentru a reprima revoluțiile ce se desfășurau pe cale pașnică (exceptând Revoluția din România)." +
                    "Războiul Rece s-a atenuat odată cu prăbușirea regimurilor comuniste din Europa Centrală și de Est, precum și din Mongolia, Cambodgia și Yemenul de Sud, urmată, doi ani mai târziu, în decembrie 1991, și de destrămarea Uniunii Sovietice. Lumea care a rămas este dominată de o singură superputere, SUA. Această situație este, de regulă, descrisă drept hegemonie globală a SUA într-o lume unipolară, deși unii autori consideră că lumea actuală este multipolară.Statele central-europene și est-europene (care, timp de patru decenii, se aflaseră sub dominația sovieticǎ), s-au democratizat și au ales să se integreze în NATO și Uniunea Europeană. SUA au fost ancorate în Războiul împotriva terorismului și în rǎzboaiele locale din Orientul Mijlociu (precum sunt cele din Afghanistan și Irak), mal ales, după Atentatele din 11 septembrie 2001. China a atins cea mai rapidă creștere economică, iar între anii 2004 și 2010 a depășit toate prognozele, devenind un concurent serios pentru SUA.De asemenea, criza economică mondială începută în 2008 a afectat, în special, zona occidentală, astfel că, în timp ce în Statele Unite marile bănci aveau probleme sau intrau în faliment, China a beneficiat de pe urma investițiilor strategice și au stimulat-o să declanșeze rǎzboiul economic cu SUA pentru supremația mondială. După douǎ decenii de destindere a relațiilor americano-ruse, urmatǎ, în 2008, de rǎcirea relațiilor diplomatice - consecință a rǎzboiului din Georgia - și, mai ales, pe fondul crizei din Ucraina, tensiunile, ostilitățile și rivalitǎțile anterioare dintre cele două puteri s-au acutizat, astfel că, în 2014, a reizbucnit Războiul Rece între Statele Unite ale Americii/ statele membre ale Uniunii Europene/ Organizației Tratatului Atlanticului de Nord și Federația Rusă - condusă de Vladimir Putin - și aliații acesteia. Acest rǎzboi este cunoscut în Mass-Media ca „Al Doilea Război Rece”,[2][3][4][5] însă, spre deosebire de Războiul Rece anterior, de această dată, Germania reunificată are un rol geopolitic major în Europa. Reizbucnirea și amplificarea Războiul Rece dintre SUA și Rusia, pe fondul creșterii amenințării terorismului în Orientul Mijlociu devastat de războaie civile, revoluții în nordul Africii și ascensiunea economicǎ fulminantă a Chinei, generează noi și justificate neliniști privind redimensionarea galopantă a raporturilor de putere în lumea contemporană." +
                    "Războiul Rece a lăsat în urma sa o moștenire importantă, adesea menținută în cultura populară și în mass-media, teme precum spionajul (cum este, spre exemplu, seria filmelor de succes internațional avându-l ca erou pe James Bond) și amenințarea războiului nuclear bucurându-se de o mare și constantă popularitate."
                };

                geographyCategory.LearnLevels.Add(learnLevel3Geography);

                var learnQuestion1LearnLevel3Geography = new LearnQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "In ce perioada a avut loc Razboiul Rece?",
                };
                learnLevel3Geography.LearnQuestions.Add(learnQuestion1LearnLevel3Geography);

                var learnQuestionAnswer1Question1LearnLevel3Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "1941-1972",
                    IsCorrect = false
                };
                learnQuestion1LearnLevel3Geography.LearnQuestionAnswers.Add(learnQuestionAnswer1Question1LearnLevel3Geography);

                var learnQuestionAnswer2Question1LearnLevel3Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "1943-1989",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question1LearnLevel3Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "1947-1991",
                    IsCorrect = true
                };

                var learnQuestionAnswer4Question1LearnLevel3Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "1914-1918",
                    IsCorrect = false
                };

                learnQuestion1LearnLevel3Geography.LearnQuestionAnswers.Add(learnQuestionAnswer2Question1LearnLevel3Geography);
                learnQuestion1LearnLevel3Geography.LearnQuestionAnswers.Add(learnQuestionAnswer3Question1LearnLevel3Geography);
                learnQuestion1LearnLevel3Geography.LearnQuestionAnswers.Add(learnQuestionAnswer4Question1LearnLevel3Geography);


                var learnQuestion2LearnLevel3Geography = new LearnQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Cum se numeau reformele de liberalizare introduce de Mihai Gorbaciov in anii '80?",
                };
                learnLevel3Geography.LearnQuestions.Add(learnQuestion2LearnLevel3Geography);

                var learnQuestionAnswer1Question2LearnLevel3Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Otrezki",
                    IsCorrect = false
                };
                learnQuestion2LearnLevel3Geography.LearnQuestionAnswers.Add(learnQuestionAnswer1Question2LearnLevel3Geography);

                var learnQuestionAnswer2Question2LearnLevel3Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Bolșevica",
                    IsCorrect = false
                };

                var learnQuestionAnswer3Question2LearnLevel3Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Glasnost",
                    IsCorrect = true
                };

                var learnQuestionAnswer4Question2LearnLevel3Geography = new LearnQuestionAnswerEntity()
                {
                    Text = "Perestroika",
                    IsCorrect = true
                };

                learnQuestion2LearnLevel3Geography.LearnQuestionAnswers.Add(learnQuestionAnswer2Question2LearnLevel3Geography);
                learnQuestion2LearnLevel3Geography.LearnQuestionAnswers.Add(learnQuestionAnswer3Question2LearnLevel3Geography);
                learnQuestion2LearnLevel3Geography.LearnQuestionAnswers.Add(learnQuestionAnswer4Question2LearnLevel3Geography);

                categoryRepository.Update(geographyCategory);//-asta actualizeaza locatia pana unde s-a rezolvat in learn pt geography

                uow.Save();
            }
        }



        private static void FillTestLevels()
        {
            using (var uow = new UnitOfWork())
            {
                var categoryRepository = uow.GetRepository<ICategoryRepository>();

                var historyCategory = categoryRepository.GetCategoryByName("History");

                var testLevel1History = new TestLevelEntity()
                {
                    TestLevelNumber = 1,
                    //TODO Petros -> change these 2 lines
                    Image = "https://www.europafm.ro/wp-content/uploads/2017/07/Stefan-Cel-Mare.jpg",
                    Text = "ISTORIE " +
                    " Level 1 "
                };
                historyCategory.TestLevels.Add(testLevel1History);

                var testQuestion1TestLevel1History = new TestQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Pe cine a invins Stefan cel Mare pentru a cuceri tronul Moldovei?",
                };
                testLevel1History.TestQuestions.Add(testQuestion1TestLevel1History);

                var testQuestionAnswer1Question1TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Iancu de Hunedoara",
                    IsCorrect = false
                };
                testQuestion1TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer1Question1TestLevel1History);

                var testQuestionAnswer2Question1TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Petru Aron",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question1TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Vlad Tepes",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question1TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Gavril Uric",
                    IsCorrect = false
                };

                testQuestion1TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer2Question1TestLevel1History);
                testQuestion1TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer3Question1TestLevel1History);
                testQuestion1TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer4Question1TestLevel1History);


                var testQuestion2TestLevel1History = new TestQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Care sunt primele ansambluri complete ce s-au pastrat din vechea pictura stefaniana?",
                };
                testLevel1History.TestQuestions.Add(testQuestion2TestLevel1History);

                var testQuestionAnswer1Question2TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Voronet",
                    IsCorrect = true
                };
                testQuestion2TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer1Question2TestLevel1History);

                var testQuestionAnswer2Question2TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Doljesti",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question2TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Chilia",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question2TestLevel1History = new TestQuestionAnswerEntity()
                {
                    Text = "Patrauti",
                    IsCorrect = true
                };
                testQuestion2TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer2Question2TestLevel1History);
                testQuestion2TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer3Question2TestLevel1History);
                testQuestion2TestLevel1History.TestQuestionAnswers.Add(testQuestionAnswer4Question2TestLevel1History);

                //-------------------------

                var testLevel2History = new TestLevelEntity()
                {
                    TestLevelNumber = 2,
                    //TODO Petros -> change these 2 lines
                    Image = "https://upload.wikimedia.org/wikipedia/commons/4/40/Napoleon_in_His_Study.jpg",
                    Text = "ISTORIE " +
                    " Level 2 "
                };

                historyCategory.TestLevels.Add(testLevel2History);

                var testQuestion1TestLevel2History = new TestQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Pe ce insula a fost exilat Napoleon Bonaparte?",
                };
                testLevel2History.TestQuestions.Add(testQuestion1TestLevel2History);

                var testQuestionAnswer1Question1TestLevel2History = new TestQuestionAnswerEntity()
                {
                    Text = "Insula Diavolului",
                    IsCorrect = false
                };
                testQuestion1TestLevel2History.TestQuestionAnswers.Add(testQuestionAnswer1Question1TestLevel2History);

                var testQuestionAnswer2Question1TestLevel2History = new TestQuestionAnswerEntity()
                {
                    Text = "Insula Sfantul Paul",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question1TestLevel2History = new TestQuestionAnswerEntity()
                {
                    Text = "Insula Sfanta Elena",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question1TestLevel2History = new TestQuestionAnswerEntity()
                {
                    Text = "Insula Man",
                    IsCorrect = false
                };

                testQuestion1TestLevel2History.TestQuestionAnswers.Add(testQuestionAnswer2Question1TestLevel2History);
                testQuestion1TestLevel2History.TestQuestionAnswers.Add(testQuestionAnswer3Question1TestLevel2History);
                testQuestion1TestLevel2History.TestQuestionAnswers.Add(testQuestionAnswer4Question1TestLevel2History);


                var testQuestion2TestLevel2History = new TestQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Ce prieteni a luat in exil Napoleon Bonaparte?",
                };
                testLevel2History.TestQuestions.Add(testQuestion2TestLevel2History);

                var testQuestionAnswer1Question2TestLevel2History = new TestQuestionAnswerEntity()
                {
                    Text = "Pierre Simon Laplace",
                    IsCorrect = false
                };

                testQuestion2TestLevel2History.TestQuestionAnswers.Add(testQuestionAnswer1Question2TestLevel2History);

                var testQuestionAnswer2Question2TestLevel2History = new TestQuestionAnswerEntity()
                {
                    Text = "Henri-Gratien Bertrand",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question2TestLevel2History = new TestQuestionAnswerEntity()
                {
                    Text = "Charles-Tristan de Montholon",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question2TestLevel2History = new TestQuestionAnswerEntity()
                {
                    Text = "Jacques-Louis David",
                    IsCorrect = false
                };

                testQuestion2TestLevel2History.TestQuestionAnswers.Add(testQuestionAnswer2Question2TestLevel2History);
                testQuestion2TestLevel2History.TestQuestionAnswers.Add(testQuestionAnswer3Question2TestLevel2History);
                testQuestion2TestLevel2History.TestQuestionAnswers.Add(testQuestionAnswer4Question2TestLevel2History);


                //---------------------

                var testLevel3History = new TestLevelEntity()
                {
                    TestLevelNumber = 3,
                    //TODO Petros -> change these 2 lines
                    Image = "https://upload.wikimedia.org/wikipedia/ro/thumb/0/0b/ColdWar.jpg/300px-ColdWar.jpg",
                    Text = "ISTORIE " +
                    " Level 3 "
                };

                historyCategory.TestLevels.Add(testLevel3History);

                var testQuestion1TestLevel3History = new TestQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "In ce perioada a avut loc Razboiul Rece?",
                };
                testLevel3History.TestQuestions.Add(testQuestion1TestLevel3History);

                var testQuestionAnswer1Question1TestLevel3History = new TestQuestionAnswerEntity()
                {
                    Text = "1941-1972",
                    IsCorrect = false
                };
                testQuestion1TestLevel3History.TestQuestionAnswers.Add(testQuestionAnswer1Question1TestLevel3History);

                var testQuestionAnswer2Question1TestLevel3History = new TestQuestionAnswerEntity()
                {
                    Text = "1943-1989",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question1TestLevel3History = new TestQuestionAnswerEntity()
                {
                    Text = "1947-1991",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question1TestLevel3History = new TestQuestionAnswerEntity()
                {
                    Text = "1914-1918",
                    IsCorrect = false
                };

                testQuestion1TestLevel3History.TestQuestionAnswers.Add(testQuestionAnswer2Question1TestLevel3History);
                testQuestion1TestLevel3History.TestQuestionAnswers.Add(testQuestionAnswer3Question1TestLevel3History);
                testQuestion1TestLevel3History.TestQuestionAnswers.Add(testQuestionAnswer4Question1TestLevel3History);


                var testQuestion2TestLevel3History = new TestQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Cum se numeau reformele de liberalizare introduce de Mihai Gorbaciov in anii '80?",
                };
                testLevel3History.TestQuestions.Add(testQuestion2TestLevel3History);

                var testQuestionAnswer1Question2TestLevel3History = new TestQuestionAnswerEntity()
                {
                    Text = "Otrezki",
                    IsCorrect = false
                };
                testQuestion2TestLevel3History.TestQuestionAnswers.Add(testQuestionAnswer1Question2TestLevel3History);

                var testQuestionAnswer2Question2TestLevel3History = new TestQuestionAnswerEntity()
                {
                    Text = "Bolșevica",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question2TestLevel3History = new TestQuestionAnswerEntity()
                {
                    Text = "Glasnost",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question2TestLevel3History = new TestQuestionAnswerEntity()
                {
                    Text = "Perestroika",
                    IsCorrect = true
                };

                testQuestion2TestLevel3History.TestQuestionAnswers.Add(testQuestionAnswer2Question2TestLevel3History);
                testQuestion2TestLevel3History.TestQuestionAnswers.Add(testQuestionAnswer3Question2TestLevel3History);
                testQuestion2TestLevel3History.TestQuestionAnswers.Add(testQuestionAnswer4Question2TestLevel3History);

                categoryRepository.Update(historyCategory);//asta actualizeaza locatia pana unde s-a rezolvat in test pt history

                //--------------------

                var sportsCategory = categoryRepository.GetCategoryByName("Sports");

                var testLevel1Sports = new TestLevelEntity()
                {
                    TestLevelNumber = 1,
                    //TODO Petros -> change these 2 lines
                    Image = "https://upload.wikimedia.org/wikipedia/ro/thumb/e/ef/Romania_national_football_team_logo.svg/200px-Romania_national_football_team_logo.svg.png",
                    Text = "Echipa națională de fotbal a României este prima reprezentativă a României și se află sub controlul Federației Române de Fotbal (FRF). România a fost una dintre cele patru țări care au participat la primele trei campionate mondiale de fotbal, alături de selecționatele Braziliei, Franței și Belgiei. Totuși, între edițiile 1950 și 1986, România a reușit să se califice numai la un singur turneu final. Între 1990 și 2000 selecționata României s-a calificat în șaisprezecimile sau chiar optimile a trei campionate mondiale consecutive. Această perioadă prielnică și-a atins culmea în cadrul turneului final al Campionatul Mondial din 1994, când România, avându-l căpitan pe Gheorghe Hagi, a ajuns în sferturile de finală învingând Argentina cu scorul de 3-2. Ulterior a pierdut cu Suedia la penaltiuri." +
                    "România a făcut de asemenea o figură bună la Euro 2000, când a obținut un 1-1 cu Germania și a învins Anglia cu 3-2 în grupe, trecând mai departe în sferturile de finală, unde a fost învinsă de Italia." +
                    "Din 1939 până în anii 1990 golgheterul absolut al echipei naționale de fotbal a României a fost Iuliu Bodola, cu 30 de goluri marcate. În prezent recordul de goluri marcate pentru echipa națională este deținut de Gheorghe Hagi și Adrian Mutu, amândoi cu 35 de reușite." +
                    "Au urmat alți șase ani fără prezențe la turneele finale, până la Italia 1990, unde România revenea la un Mondial după 20 de ani. Din echipa condusă de Emeric Ienei făceau parte tinerii Gheorghe Hagi, Florin Răducioiu sau Ilie Dumitrescu. Campionul european cu Steaua București, Marius Lăcătuș avea să fie eroul primului meci, marcând două goluri în poarta U.R.S.S., de care România a trecut cu 2-0 la Bari. Același oraș a găzduit și al doilea meci al tricolorilor, cu reprezentativa Camerunului, pierdut cu 2-1. Golul României a fost marcat de Gavril Balint. În ultimul meci din grupă, România a întâlnit Argentina, campioana mondială en-titre și echipa în rândul căreia evolua Diego Maradona. Ca un făcut, jocul a avut loc la Napoli, orașul în care Maradona evolua la echipa de club. Sud-americanii au marcat primii, dar Balint avea să egaleze și să ducă România în optimile de finală. Aici a urmat înfruntarea cu Irlanda, și după un 0-0 la capătul a 120 de minute, disputa s-a decis la executarea loviturilor de departajare, unde singura ratare i-a aparținut lui Daniel Timofte și România rata întâlnirea cu Italia, în sferturi." +
                    "După ratarea calificării la EURO 1992, România a fost aproape să rateze și accesul la Mondialul din 1994. La jumătatea preliminariilor a fost adus însă Anghel Iordănescu în postul de selecționer, și cu trei victorii în ultimele trei meciuri, între care un succes cu Belgia la București și unul în Țara Galilor, România avea să meargă la turneul final din Statele Unite." +
                    "Pe 18 iunie 1994, la Los Angeles, România a întâlnit Columbia, echipă considerată favorită la titlu de brazilianul Pelé. Florin Răducioiu a deschis scorul, iar Gheorghe Hagi l-a majorat cu un gol incredibil, un șut din apropierea tușei din stânga a terenului, de la peste 30 de metri de poartă. Pe final, pe un contraatac, Răducioiu consfințea scorul final, 3-1, după ce columbienii reduseseră din handicap." +
                    "Patru zile mai târziu, la Detroit, într-un stadion acoperit, România a întâlnit Elveția în fața căreia avea să piardă cu 4-1. Doar un succes în fața Statelor Unite, organizatoarea competiției, ducea România în faza eliminatorie, și victoria a venit din nou pe stadionul Rose Bowl din Los Angeles. Dan Petrescu a marcat unicul gol al partidei." +
                    "În optimile de finală, adversar a fost Argentina, fără Diego Maradona care tocmai fusese suspendat pentru consum de droguri. La tricolori nu juca Răducioiu, din cauza acumulării de cartonașe galbene, dar absența lui a fost suplinită perfect de Ilie Dumitrescu, autorul unei duble, iar Gheorghe Hagi a înscris și el într-o victorie cu 3-2 care a dus în premieră pe tricolori în sferturile de finală mondiale. Aici, tot loviturile de departajare aveau să oprească România, ca și în 1990. Împotriva Suediei, Răducioiu a împins meciul în prelungiri după ce scandinavii marcaseră primii, pentru ca din nou Răducioiu să înscrie pentru 2-1 în minutul 101. Însă cu cinci minute înainte de finalul jocului, Kennet Andersson a readus egalitatea și la șuturile de la 11 metri Dan Petrescu și Miodrag Belodedici au ratat pentru tricolori după ce prima ratare aparținuse suedezilor." +
                    "În 1996, România a revenit și la Campionatul European, participând la EURO 1996 din Anglia, unde însă a pierdut toate meciurile din grupă: 0-1 cu Franța și Bulgaria și 1-2 cu Spania, golul României fiind marcat de Florin Răducioiu." +
                    "A treia prezență consecutivă la Campionatul Mondial a fost consemnată în Franța 1998, unde România a fost cap de serie la tragerea la sorți. În ciuda acestui avantaj, grupa a fost una dificilă, cu Columbia, de care tricolorii au trecut cu 1-0, gol Adrian Ilie, și Anglia. La Toulouse, Viorel Moldovan a deschis scorul, Michael Owen a egalat, dar Dan Petrescu a adus victoria și calificarea în minutele de final. În ultimul meci, contra Tunisiei, echipa condusă de Anghel Iordănescu avea nevoie de un punct pentru a termina pe primul loc în grupă și meciul se încheia 1-1, Viorel Moldovan egalând în repriza secundă. Însă în optimile de finală adversar a fost Croația care s-a impus la limită, 1-0, Davor Suker transformând un penalti înainte de pauză." +
                    "Ultimul turneu final al Generației de Aur a fost EURO 2000, în Olanda și Belgia. Anghel Iordănescu plecase după Franța 1998, Victor Pițurcă a calificat echipa dar a fost demis înainte de turneul final unde selecționer a fost Emeric Ienei. Dintr-o grupă imposibilă, România obținea calificarea după 1-1 cu Germania, gol Viorel Moldovan, 0-1 cu Portugalia și 3-2 în ultimul meci, contra Angliei. Disputa de la Charleroi a început cu golul lui Cristian Chivu, dar englezii au intrat în avantaj de un gol la cabine. Dorinel Munteanu a egalat la 2, iar Ionel Ganea a transformat un penalti în minutul 89, aducând victoria și calificarea." +
                    "Adversar în sferturile de finală a fost Italia, la Bruxelles. În minutul 35, Gheorghe Hagi a fost eliminat pentru proteste, iar cu un jucător în plus italienii s-au impus cu 2-0."
                };

                sportsCategory.TestLevels.Add(testLevel1Sports);

                var testQuestion1TestLevel1Sports = new TestQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "De cine a fost invinsa Romania in sferturile de finala a Campionatului European din 2000?",
                };
                testLevel1Sports.TestQuestions.Add(testQuestion1TestLevel1Sports);

                var testQuestionAnswer1Question1TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Anglia",
                    IsCorrect = false
                };
                testQuestion1TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer1Question1TestLevel1Sports);

                var testQuestionAnswer2Question1TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Germania",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question1TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Italia",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question1TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Suedia",
                    IsCorrect = false
                };

                testQuestion1TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer2Question1TestLevel1Sports);
                testQuestion1TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer3Question1TestLevel1Sports);
                testQuestion1TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer4Question1TestLevel1Sports);


                var testQuestion2TestLevel1Sports = new TestQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Cine a marcat unicul gol din victoria decisiva a Romaniei contra Statelor Unite de la Cupa Mondiala 1994?",
                };
                testLevel1Sports.TestQuestions.Add(testQuestion2TestLevel1Sports);

                var testQuestionAnswer1Question2TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Florin Raducioiu",
                    IsCorrect = false
                };
                testQuestion2TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer1Question2TestLevel1Sports);

                var testQuestionAnswer2Question2TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Ilie Dumitrescu",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question2TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Dan Petrescu",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question2TestLevel1Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Gheorghe Hagi",
                    IsCorrect = true
                };
                testQuestion2TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer2Question2TestLevel1Sports);
                testQuestion2TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer3Question2TestLevel1Sports);
                testQuestion2TestLevel1Sports.TestQuestionAnswers.Add(testQuestionAnswer4Question2TestLevel1Sports);

                //-------------------------

                var testLevel2Sports = new TestLevelEntity()
                {
                    TestLevelNumber = 2,
                    //TODO Petros -> change these 2 lines
                    Image = "https://playtech.ro/stiri/wp-content/uploads/2020/03/nadia-comaneci.jpg",
                    Text = "Nadia Elena Comăneci (n. 12 noiembrie 1961, Onești, România) este o gimnastă română, prima gimnastă din lume care a primit nota zece într-un concurs olimpic de gimnastică. Este câștigătoare a cinci medalii olimpice de aur. Este considerată a fi una dintre cele mai bune sportive ale secolului XX și una dintre cele mai bune gimnaste ale lumii, din toate timpurile, „Zeița de la Montreal”, prima gimnastă a epocii moderne care a luat 10 absolut. Este primul sportiv român inclus în memorialul International Gymnastics Hall of Fame." +
                    "Nadia s-a născut la Onești, find fiica lui Gheorghe și Ștefania-Alexandrina Comăneci[3]; a fost botezată după „Nadejda” („Speranță”), eroină a unui film. Unele surse susțin că s-ar fi născut ca „Anna Kemenes”.[4][5][6] Această variantă a fost dezmințită în noiembrie 2016 atât de Nadia cât și de mama sa, Ștefania" +
                    "A concurat pentru prima dată la nivel național în România, în 1970, ca membră a echipei orașului său. Curând, a început antrenamentele cu Béla Károlyi și soția acestuia, Márta Károlyi, care au emigrat mai târziu în Statele Unite, devenind antrenori ai multor gimnaste americane. La vârsta de 13 ani, primul succes major al lui Comăneci a fost câștigarea a trei medalii de aur și una de argint la Campionatele Europene din 1975, de la Skien, Norvegia. În același an, agenția de știri Associated Press a numit-o --Atleta Anului--." +
                    "La 14 ani, Comăneci a devenit o stea a Jocurilor Olimpice de Vară din 1976 de la Montreal, Québec. Nu numai că a devenit prima gimnastă care a obținut scorul perfect de zece la olimpiadă (de șapte ori), dar a și câștigat trei medalii de aur (la individual compus, bârnă și paralele), o medalie de argint (echipă compus) și bronz (sol). Acasă, succesul său i-a adus distincția de „Erou al Muncii Socialiste”, fiind cea mai tânără româncă distinsă cu acest titlu." +
                    "Comăneci și-a apărat titlul european în 1977, dar echipa României a ieșit din competiție în finale, în semn de protest contra arbitrajului. La Campionatele Mondiale din 1978 a concurat o Nadia Comăneci cu greutate peste medie și ieșită din formă. Căderea la paralele a trimis-o pe locul 4, însă a câștigat titlul de campioană mondială la bârnă." +
                    "În 1979, Comăneci, din nou la greutate normală, a câștigat cel de-al treilea titlu european la individual compus (devenind primul sportiv din istoria gimnasticii care a reușit această performanță). La Campionatele Mondiale din decembrie, ea a câștigat concursul preliminar, dar a fost spitalizată înainte de a participa la concursul pe echipe, din cauza unei infecții, în urma unei tăieturi la încheietura mâinii, cauzată de o cataramă din metal. În ciuda recomandărilor doctorilor, ea a părăsit spitalul și a concurat la bârnă, unde a obținut nota 9,95. Performanța sa a conferit României prima medalie de aur în concursul pe echipe." +
                    "A participat și la Jocurile Olimpice din 1980 de la Moscova, clasându-se a doua după Elena Davîdova la individual compus, când a fost nevoită să aștepte pentru notă până ce Davîdova și-a încheiat exercițiul. Nadia și-a păstrat titlul la bârnă, dar a câștigat și o nouă medalie de aur, la sol, și una de argint, împreună cu echipa"

                };

                sportsCategory.TestLevels.Add(testLevel2Sports);

                var testQuestion1TestLevel2Sports = new TestQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Caderea de la paralele a Nadiei Comaneci de la Campionatele Mondiale din 1978, au trimis-o pe locul?",
                };
                testLevel2Sports.TestQuestions.Add(testQuestion1TestLevel2Sports);

                var testQuestionAnswer1Question1TestLevel2Sports = new TestQuestionAnswerEntity()
                {
                    Text = "3",
                    IsCorrect = false
                };
                testQuestion1TestLevel2Sports.TestQuestionAnswers.Add(testQuestionAnswer1Question1TestLevel2Sports);

                var testQuestionAnswer2Question1TestLevel2Sports = new TestQuestionAnswerEntity()
                {
                    Text = "4",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question1TestLevel2Sports = new TestQuestionAnswerEntity()
                {
                    Text = "5",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question1TestLevel2Sports = new TestQuestionAnswerEntity()
                {
                    Text = "6",
                    IsCorrect = false
                };

                testQuestion1TestLevel2Sports.TestQuestionAnswers.Add(testQuestionAnswer2Question1TestLevel2Sports);
                testQuestion1TestLevel2Sports.TestQuestionAnswers.Add(testQuestionAnswer3Question1TestLevel2Sports);
                testQuestion1TestLevel2Sports.TestQuestionAnswers.Add(testQuestionAnswer4Question1TestLevel2Sports);


                var testQuestion2TestLevel2Sports = new TestQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Care a fost nota exacta obtinuta de Nadia Comanescu la barna in anul 1979?",
                };
                testLevel2Sports.TestQuestions.Add(testQuestion2TestLevel2Sports);

                var testQuestionAnswer1Question2TestLevel2Sports = new TestQuestionAnswerEntity()
                {
                    Text = "9.90",
                    IsCorrect = false
                };

                testQuestion2TestLevel2Sports.TestQuestionAnswers.Add(testQuestionAnswer1Question2TestLevel2Sports);

                var testQuestionAnswer2Question2TestLevel2Sports = new TestQuestionAnswerEntity()
                {
                    Text = "9.98",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question2TestLevel2Sports = new TestQuestionAnswerEntity()
                {
                    Text = "10.0",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question2TestLevel2Sports = new TestQuestionAnswerEntity()
                {
                    Text = "9.95",
                    IsCorrect = true
                };

                testQuestion2TestLevel2Sports.TestQuestionAnswers.Add(testQuestionAnswer2Question2TestLevel2Sports);
                testQuestion2TestLevel2Sports.TestQuestionAnswers.Add(testQuestionAnswer3Question2TestLevel2Sports);
                testQuestion2TestLevel2Sports.TestQuestionAnswers.Add(testQuestionAnswer4Question2TestLevel2Sports);

                //----------------

                var testLevel3Sports = new TestLevelEntity()
                {
                    TestLevelNumber = 3,
                    //TODO Petros -> change these 2 lines
                    Image = "https://image-cdn.essentiallysports.com/wp-content/uploads/20200912202247/michael-jordan-t.jpg",
                    Text = "Jordan s-a născut în Brooklyn, New York, fiul lui Deloris , care a lucrat în domeniul bancar, și James R. Jordan, un supraveghetor de echipamente. Familia sa s-a mutat la Wilmington, Carolina de Nord, atunci când era copil. Jordan a mers la școală la Emsley A. Laney High School din Wilmington, unde a ancorat cariere atletice jucând baseball, fotbal american și baschet. El a încercat pentru echipa de baschet Varsity în al doilea an de studenție, dar la abia 1,80 m, el a fost considerat prea scund pentru a juca la acest nivel. Prietenul lui mai înalt, Harvest Leroy Smith, a fost singurul care a fost ales dintre Sophomores pentru a face parte din echipă." +
                    "Motivat să își dovedească valoarea, Jordan a devenit steaua echipei de juniori și a fost cel mai bun marcator în 40 de jocuri. În vara următoare, el a crescut 10 cm în înălțime,și antrenându-se în mod riguros a câștigat un loc în echipa mare, obținând o medie de aproximativ 20 de puncte pe meci.. Ca senior, a fost selectat la McDonald's All-American-Team după un sezon încheiat cu o triplă dublă ca medie: 29.2 puncte, 11.6 recuperări și 10.1 pase decisive. În 1981, Jordan a câștigat o bursă de baschet la Universitatea din Carolina de Nord la Chapel Hill, unde s-a specializat în geografie culturală. Ca un boboc în echipa condusă de Dean Smith, a fost numit bobocul ACC al anului, cu o medie de 13.4 puncte pe meci (PPG) și o medie de 53,4% la aruncarea la coș. El a realizat coșul decisiv în finala campionatului NCAA din 1982 împotriva celor de la Georgetown, la care juca viitorul său rival din NBA Patrick Ewing. Jordan a descris acel coș un moment decisiv în cariera lui de baschet. În timpul celor trei sezoane de la Carolina de Nord, el a avut o medie de 17.7 puncte pe meci la 54,0% și a adăugat 5.0 recuperări pe meci (RPG)." +
                    "Michael Jordan în timp ce joacă cu Scorpions Scottsdale,în data de 6 octombrie 1993, își anunță retragerea, citând o pierdere din dorința de a juca acest joc. Jordan a declarat mai târziu că uciderea tatălui sau mai devreme in acel i-a schimbat deciziile.. James R. Jordan Sr. a fost ucis la 23 iulie 1993, intr-o de odihna de pe autostrada în Lumberton, Carolina de Nord, de către doi adolescenți , Daniel Martin Demery verde și Larry. Atacatorii au fost trasate de apeluri au făcut apeluri de pe telefonul celular James Jordan, prins, condamnat, și condamnat la închisoare pe viață. Jordan a fost aproape de tatăl său ca un copil, având o înclinație de la el de a scoate limba în timp ce e absorbit în muncă. El,mai târziu a adoptat și semnătura proprie, de la afișarea ei de fiecare dată, la coș după coș. În 1996 el a fondat zona Chicago Boys & Girls Club și dedicat tatălui său." +
                    "Jordan a scris că el a făcut pregătirea pentru pensionare cât mai devreme,in vara anului 1992. Epuizarea adăugată datorită „Dream Team”,în timpul Jocurile Olimpice de vară din 1992 a solidificat sentimentele lui Jordan despre joc și statutul său de celebritate în continuă creștere. Anuntul lui Jordan a trimis unde de șoc în întregul NBA și a apărut pe primele pagini ale ziarelor din întreaga lume. Jordan a surprins și mai mult lumea sportului prin semnarea unui contract de baseball minor in liga cu Chicago White Sox. El a confirmat la primvara de formare și a fost repartizat la sistemul echipei de ligă minoră pe 31 martie 1994.[43] Jordan a declarat că această decizie a fost luată ca să urmarească visul tatălui său, care și l-a imaginat mereu pe fiul său ca un jucător Major League Baseball." +
                    "Jordan a jucat în două echipe olimpice care au câștigat aurul la basket. În facultate a participat la jocurile olimpice de vară din anul Jocurile Olimpice de vară din 1984 și a câștigat. Jordan a condus echipa marcând în medie 17,1 puncte pe meci în timpul campionatului. În jocurile olimpice din anul Jocurile Olimpice de vară din 1992 a fost membru al unei echipe pline de staruri împreună cu Magic Johnson, Larry Bird, and David Robinson echipa a fost denumită ”Dream team”(echipa de vis). A jucat minute limitate datorită unor probleme personale, jordan a înscris în medie 12,7 puncte pe meci, ieșind al patrulea din echipă la marcaj. Jordan, Patrick Ewing și un alt membru alt membru al „Echipei de vis”, Chris Mullin sunt singurii jucători de basket masculin din America care au câștigat aurul olimpic atât ca amatori (în 1984), dar și ca profesioniști. În plus jordan și un alt membru al „Echipei de vis” (un coechipier de la Bulls) Scottie Pippen sunt singurii jucători care au câștigat atât campionatul de NBA cât și aurul olimpic în același an (1992)."
                };

                sportsCategory.TestLevels.Add(testLevel3Sports);

                var testQuestion1TestLevel3Sports = new TestQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Cate puncte a marcat in echipa McDonald's All-American-Team la finalul sezonului in anul 1980 ?",
                };
                testLevel3Sports.TestQuestions.Add(testQuestion1TestLevel3Sports);

                var testQuestionAnswer1Question1TestLevel3Sports = new TestQuestionAnswerEntity()
                {
                    Text = "19.3",
                    IsCorrect = false
                };
                testQuestion1TestLevel3Sports.TestQuestionAnswers.Add(testQuestionAnswer1Question1TestLevel3Sports);

                var testQuestionAnswer2Question1TestLevel3Sports = new TestQuestionAnswerEntity()
                {
                    Text = "15.7",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question1TestLevel3Sports = new TestQuestionAnswerEntity()
                {
                    Text = "29.2",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question1TestLevel3Sports = new TestQuestionAnswerEntity()
                {
                    Text = "11.6",
                    IsCorrect = false
                };

                testQuestion1TestLevel3Sports.TestQuestionAnswers.Add(testQuestionAnswer2Question1TestLevel3Sports);
                testQuestion1TestLevel3Sports.TestQuestionAnswers.Add(testQuestionAnswer3Question1TestLevel3Sports);
                testQuestion1TestLevel3Sports.TestQuestionAnswers.Add(testQuestionAnswer4Question1TestLevel3Sports);


                var testQuestion2TestLevel3Sports = new TestQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Dupa moartea tatalui sau, ce zona a fondat Michael Jordan, in semn de recunostinta?",
                };
                testLevel3Sports.TestQuestions.Add(testQuestion2TestLevel3Sports);

                var testQuestionAnswer1Question2TestLevel3Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Orlando Magic",
                    IsCorrect = false
                };
                testQuestion2TestLevel3Sports.TestQuestionAnswers.Add(testQuestionAnswer1Question2TestLevel3Sports);

                var testQuestionAnswer2Question2TestLevel3Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Chicago Boys & Girls Club",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question2TestLevel3Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Scottsdale Arizona",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question2TestLevel3Sports = new TestQuestionAnswerEntity()
                {
                    Text = "Forbes Stars",
                    IsCorrect = false
                };

                testQuestion2TestLevel3Sports.TestQuestionAnswers.Add(testQuestionAnswer2Question2TestLevel3Sports);
                testQuestion2TestLevel3Sports.TestQuestionAnswers.Add(testQuestionAnswer3Question2TestLevel3Sports);
                testQuestion2TestLevel3Sports.TestQuestionAnswers.Add(testQuestionAnswer4Question2TestLevel3Sports);

                categoryRepository.Update(sportsCategory);//-asta actualizeaza locatia pana unde s-a rezolvat in test pt sports


                //--------------



                var geographyCategory = categoryRepository.GetCategoryByName("Geography");

                var testLevel1Geography = new TestLevelEntity()
                {
                    TestLevelNumber = 1,
                    //TODO Petros -> change these 2 lines
                    Image = "https://i.ibb.co/vVz0Gqs",
                    Text = "GEOGRAFIE " +
                    " Level 1 "
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

                //-------------------------

                var testLevel2Geography = new TestLevelEntity()
                {
                    TestLevelNumber = 2,
                    //TODO Petros -> change these 2 lines
                    Image = "https://i.ibb.co/vVz0Gqs",
                    Text = "GEOGRAFIE " +
                    " Level 2 "
                };

                geographyCategory.TestLevels.Add(testLevel2Geography);

                var testQuestion1TestLevel2Geography = new TestQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Care este cel mai inalt munte de pe glob?",
                };
                testLevel2Geography.TestQuestions.Add(testQuestion1TestLevel2Geography);

                var testQuestionAnswer1Question1TestLevel2Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Muntele K2",
                    IsCorrect = false
                };
                testQuestion1TestLevel2Geography.TestQuestionAnswers.Add(testQuestionAnswer1Question1TestLevel2Geography);

                var testQuestionAnswer2Question1TestLevel2Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Muntele Lhotse",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question1TestLevel2Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Muntele Everest",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question1TestLevel2Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Muntele Makalu",
                    IsCorrect = false
                };

                testQuestion1TestLevel2Geography.TestQuestionAnswers.Add(testQuestionAnswer2Question1TestLevel2Geography);
                testQuestion1TestLevel2Geography.TestQuestionAnswers.Add(testQuestionAnswer3Question1TestLevel2Geography);
                testQuestion1TestLevel2Geography.TestQuestionAnswers.Add(testQuestionAnswer4Question1TestLevel2Geography);


                var testQuestion2TestLevel2Geography = new TestQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Cate state are USA?",
                };
                testLevel2Geography.TestQuestions.Add(testQuestion2TestLevel2Geography);

                var testQuestionAnswer1Question2TestLevel2Geography = new TestQuestionAnswerEntity()
                {
                    Text = "48",
                    IsCorrect = false
                };

                testQuestion2TestLevel2Geography.TestQuestionAnswers.Add(testQuestionAnswer1Question2TestLevel2Geography);

                var testQuestionAnswer2Question2TestLevel2Geography = new TestQuestionAnswerEntity()
                {
                    Text = "50",
                    IsCorrect = true
                };

                var testQuestionAnswer3Question2TestLevel2Geography = new TestQuestionAnswerEntity()
                {
                    Text = "25",
                    IsCorrect = false
                };

                var testQuestionAnswer4Question2TestLevel2Geography = new TestQuestionAnswerEntity()
                {
                    Text = "16",
                    IsCorrect = false
                };

                testQuestion2TestLevel2Geography.TestQuestionAnswers.Add(testQuestionAnswer2Question2TestLevel2Geography);
                testQuestion2TestLevel2Geography.TestQuestionAnswers.Add(testQuestionAnswer3Question2TestLevel2Geography);
                testQuestion2TestLevel2Geography.TestQuestionAnswers.Add(testQuestionAnswer4Question2TestLevel2Geography);


                //---------------------

                var testLevel3Geography = new TestLevelEntity()
                {
                    TestLevelNumber = 3,
                    //TODO Petros -> change these 2 lines
                    Image = "https://i.ibb.co/vVz0Gqs",
                    Text = "GEOGRAFIE " +
                    " Level 3 "
                };

                geographyCategory.TestLevels.Add(testLevel3Geography);

                var testQuestion1TestLevel3Geography = new TestQuestionEntity()
                {
                    Order = 1,
                    //TODO Petros -> change this
                    Text = "Cine a realizat pentru prima data calatoria in jurul pamantului?",
                };
                testLevel3Geography.TestQuestions.Add(testQuestion1TestLevel3Geography);

                var testQuestionAnswer1Question1TestLevel3Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Cristofor Columb",
                    IsCorrect = false
                };
                testQuestion1TestLevel3Geography.TestQuestionAnswers.Add(testQuestionAnswer1Question1TestLevel3Geography);

                var testQuestionAnswer2Question1TestLevel3Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Amerigo Vespucci",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question1TestLevel3Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Fernando Magellan",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question1TestLevel3Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Phileas Fogg",
                    IsCorrect = false
                };

                testQuestion1TestLevel3Geography.TestQuestionAnswers.Add(testQuestionAnswer2Question1TestLevel3Geography);
                testQuestion1TestLevel3Geography.TestQuestionAnswers.Add(testQuestionAnswer3Question1TestLevel3Geography);
                testQuestion1TestLevel3Geography.TestQuestionAnswers.Add(testQuestionAnswer4Question1TestLevel3Geography);


                var testQuestion2TestLevel3Geography = new TestQuestionEntity()
                {
                    Order = 2,
                    //TODO Petros -> change this
                    Text = "Ce tip de lac este lacul Sf Ana?",
                };
                testLevel3Geography.TestQuestions.Add(testQuestion2TestLevel3Geography);

                var testQuestionAnswer1Question2TestLevel3Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Tectonic",
                    IsCorrect = false
                };
                testQuestion2TestLevel3Geography.TestQuestionAnswers.Add(testQuestionAnswer1Question2TestLevel3Geography);

                var testQuestionAnswer2Question2TestLevel3Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Glaciar",
                    IsCorrect = false
                };

                var testQuestionAnswer3Question2TestLevel3Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Vulcanic",
                    IsCorrect = true
                };

                var testQuestionAnswer4Question2TestLevel3Geography = new TestQuestionAnswerEntity()
                {
                    Text = "Artificial",
                    IsCorrect = false
                };

                testQuestion2TestLevel3Geography.TestQuestionAnswers.Add(testQuestionAnswer2Question2TestLevel3Geography);
                testQuestion2TestLevel3Geography.TestQuestionAnswers.Add(testQuestionAnswer3Question2TestLevel3Geography);
                testQuestion2TestLevel3Geography.TestQuestionAnswers.Add(testQuestionAnswer4Question2TestLevel3Geography);

                categoryRepository.Update(geographyCategory);//-asta actualizeaza locatia pana unde s-a rezolvat in test pt geography

                uow.Save();
            }
        }


    }


}











