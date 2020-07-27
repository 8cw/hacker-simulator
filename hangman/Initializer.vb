Module Initializer
    Sub Main()
        Debug.WriteLine("[INITIALIZE] Initializing")
        ' Create all the hangman objects we will use (we retrieve the amount of wrong-answers in this dictionary and it returns the hangman object to display to the user)
        HANGMAN_OBJ.Add(0, "-----------------
|               |
|               |
|          
|           
|          
|        
|        
|          
|         
|        
|       ")
        HANGMAN_OBJ.Add(1, "-----------------
|               |
|               |
|               =
|              | |
|               =
|          
|         
|        
|          
|         
|        
|       ")
        HANGMAN_OBJ.Add(2, "-----------------
|               |
|               |
|               =
|              | |
|               =
|               -
|               |
|               |
|          
|         
|        
|       ")
        HANGMAN_OBJ.Add(3, "-----------------
|               |
|               |    
|               =
|              | |
|               =
|              --
|             / | 
|            /  |  
|           
|            
|             
|              ")
        HANGMAN_OBJ.Add(4, "-----------------
|               |
|               |
|               =
|              | |
|               =
|              ---
|             / | \
|            /  |  \
|          
|         
|        
|       ")
        HANGMAN_OBJ.Add(5, "-----------------
|               |
|               |
|               =
|              | |
|               =
|              ---
|             / | \
|            /  |  \
|              / 
|             /   
|            /     
|           /       ")
        HANGMAN_OBJ.Add(6, "-----------------
|               |
|               |
|               =
|              | |
|               =
|              ---
|             / | \
|            /  |  \
|              / \
|             /   \
|            /     \
|           /       \")

        Debug.WriteLine("[INITIALIZE] Added hangman objects")

        PossibleWords.Add(3, {"ace", "ace", "aha", "aid", "ail", "aim", "air", "ale", "and", "and", "any", "ape", "are", "ark", "arm", "art", "ash", "awe", "bad", "bee", "beg", "bet", "bid", "big", "boa", "bot", "boy", "but", "can", "cay", "cel", "cow", "cub", "cup", "dad", "deb", "did", "dot", "eve", "fit", "fur", "gal", "gap", "gay", "gel", "gig", "git", "god", "got", "gym", "hay", "hey", "his", "how", "ink", "inn", "kit", "lab", "lap", "led", "max", "mid", "mid", "mix", "mix", "mod", "mod", "mum", "nut", "one", "one", "pay", "pen", "pop", "ran", "rat", "rep", "row", "run", "sad", "say", "see", "shy", "sin", "sir", "spa", "sub", "tad", "tan", "tea", "ten", "the", "tie", "use", "vat", "vet", "web", "why", "yes", "yet"})
        PossibleWords.Add(4, {"aids", "akin", "ally", "amid", "amps", "baby", "bark", "beam", "bend", "bend", "bike", "bird", "bird", "bite", "bolt", "bout", "burn", "cops", "core", "cubs", "dark", "doll", "dome", "dose", "eats", "fade", "fame", "fast", "fate", "feed", "file", "flow", "foil", "full", "gang", "give", "glue", "goes", "head", "hear", "here", "info", "jail", "knew", "lack", "laws", "link", "logo", "make", "mark", "mark", "mats", "meal", "melt", "milk", "mode", "nine", "nope", "nope", "odor", "pack", "park", "plan", "polo", "pork", "pubs", "raid", "rent", "ripe", "rule", "side", "sins", "song", "spam", "span", "star", "stat", "talk", "tape", "temp", "thee", "thin", "ties", "tire", "toes", "toll", "tone", "tool", "tour", "trim", "uses", "view", "void", "wait", "ways", "went", "woke", "wood", "yard", "yarn"})
        PossibleWords.Add(5, {"abuse", "adult", "adult", "agent", "align", "alive", "allow", "amend", "angry", "angry", "ankle", "badge", "basis", "beats", "began", "begin", "bleed", "boats", "bones", "brake", "brick", "broke", "brown", "buddy", "calls", "cargo", "cases", "chain", "chain", "chest", "climb", "clubs", "cocoa", "cough", "count", "crank", "cruel", "cubic", "dated", "dates", "decor", "downs", "downs", "drone", "drove", "ducks", "elect", "error", "facts", "fares", "farms", "fault", "ferry", "files", "finds", "finds", "fixed", "flame", "flats", "flesh", "flour", "fully", "fully", "green", "grown", "habit", "kinda", "likes", "logic", "loved", "lower", "mouth", "moved", "never", "niche", "niche", "niche", "novel", "peers", "piece", "price", "price", "query", "radio", "right", "serve", "share", "small", "smoke", "sorts", "spend", "suite", "teams", "their", "trees", "trump", "ultra", "wires", "yards", "young"})
        PossibleWords.Add(6, {"agency", "alerts", "anyone", "apples", "assure", "author", "banned", "battle", "behind", "belong", "breath", "cannon", "casino", "casino", "cattle", "causes", "cavity", "cheers", "cities", "cities", "comply", "define", "delete", "demand", "digits", "dozens", "driven", "easter", "extras", "filing", "filmed", "finger", "flight", "forces", "forest", "fought", "guards", "habits", "harbor", "hereby", "heroin", "honors", "hoping", "income", "kindle", "leaves", "length", "melted", "metals", "mighty", "modest", "nearly", "oldest", "opened", "outfit", "pantry", "peanut", "pencil", "phrase", "plasma", "prizes", "pulled", "python", "quests", "recipe", "reform", "regime", "regime", "repeat", "result", "rights", "rivers", "robust", "rubber", "rugged", "scored", "seated", "second", "select", "shades", "shield", "shower", "spices", "statue", "sticks", "stocks", "stones", "submit", "superb", "talent", "talent", "target", "theory", "tracks", "tricky", "trophy", "vessel", "winner", "wisdom", "worthy"})
        PossibleWords.Add(7, {"account", "actives", "admirer", "adoring", "aerosol", "ambient", "arising", "assumed", "athlete", "awkward", "balcony", "biggest", "brigade", "buttons", "camping", "capital", "catches", "charges", "classic", "clearer", "colored", "complex", "console", "consume", "council", "counted", "culture", "density", "differs", "doctors", "donated", "drafted", "emotion", "empathy", "expects", "failure", "feather", "filming", "foliage", "futures", "grammar", "ignored", "imaging", "implies", "inspect", "interim", "journal", "kitchen", "laundry", "leading", "lightly", "mailbox", "manager", "moments", "monster", "nations", "nearest", "nearest", "notices", "origins", "parking", "parties", "picture", "placing", "placing", "pointer", "posting", "premier", "process", "project", "quicker", "ranking", "rapidly", "restart", "running", "savings", "scanner", "scholar", "schools", "selfish", "shutter", "sisters", "sliding", "slowing", "soldier", "spreads", "squares", "squeeze", "stadium", "tablets", "targets", "telling", "thunder", "tougher", "turning", "typical", "variety", "visitor", "voltage", "warming"})
        PossibleWords.Add(8, {"abductee", "absolves", "accurate", "acidemia", "acrimony", "acrylics", "actuator", "adopters", "adsorbed", "afghanis", "agonized", "aircrews", "airstrip", "annoying", "automate", "bearings", "beginner", "borrowed", "calories", "captures", "charcoal", "charming", "chlorine", "clinical", "commonly", "complete", "courtesy", "currency", "currency", "curtains", "declined", "defenses", "deployed", "distance", "episodes", "explains", "explored", "explores", "failures", "flawless", "generate", "generous", "graduate", "guardian", "guessing", "happened", "homeland", "integral", "internet", "lowering", "meantime", "minority", "missions", "musician", "notified", "observer", "orthodox", "password", "platinum", "pleasant", "premises", "promoted", "promotes", "promotes", "realized", "receives", "recovery", "reflects", "relation", "rendered", "scenario", "seasoned", "sensible", "severely", "shipping", "shipping", "sleeping", "smoother", "spectrum", "speeches", "speeches", "spelling", "spelling", "steroids", "stopping", "stressed", "suburban", "suitable", "supplier", "theories", "thriving", "titanium", "together", "traveled", "treating", "trillion", "uniquely", "vomiting", "worrying", "writings"})
        PossibleWords.Add(9, {"abatement", "ablutions", "accessing", "adhesions", "adhesions", "admitting", "adoptions", "adoration", "agreeably", "alcoholic", "aldehydes", "allowable", "allowance", "ambergris", "analogous", "annulment", "appendage", "arduously", "armaments", "artificer", "ascetical", "autoclave", "autocross", "avoidable", "balancers", "baronetcy", "basophils", "beatified", "beauteous", "bedazzled", "beseeches", "betrothal", "billiards", "birthrate", "blastings", "bleakness", "blistered", "bloodroot", "blossomed", "bludgeons", "blueprint", "boomtowns", "boondocks", "botulinum", "boundless", "breathier", "breathier", "breezeway", "burgesses", "butternut", "cathedral", "community", "comprises", "computers", "conductor", "continued", "convicted", "customize", "dangerous", "dedicated", "delegates", "delighted", "dismissal", "effective", "emissions", "encounter", "enjoyable", "examining", "followers", "frequency", "groceries", "inability", "itinerary", "messaging", "multitude", "necessity", "northwest", "offenders", "plaintiff", "positions", "practices", "proceeded", "producing", "reactions", "realizing", "recovered", "recycling", "reflected", "repayment", "scholarly", "societies", "specialty", "specifies", "strengths", "synthesis", "trademark", "transform", "travelled", "vacations", "versatile"})
        PossibleWords.Add(10, {"abdication", "abnegation", "abnormally", "aborigines", "absorbable", "abstracted", "acceptance", "accomplice", "accomplice", "accountant", "acquitting", "additional", "additivity", "affirmance", "afterworld", "aggrandize", "airbrushed", "airmanship", "airstreams", "alcoholics", "alkalinity", "allocating", "altarpiece", "amazements", "amendments", "anatomical", "anglerfish", "apotheosis", "appealable", "appearance", "appraisals", "archivists", "archrivals", "aristocrat", "arthropods", "associates", "assumption", "auditorium", "autonomous", "avoidances", "backpacked", "ballerinas", "balloonist", "banquettes", "barricades", "bedspreads", "beefsteaks", "bipedalism", "birthmarks", "bootlegger", "bootstraps", "bowerbirds", "bracketing", "breadfruit", "breadlines", "breakaways", "breakfasts", "bridesmaid", "brownstone", "burdensome", "burglaries", "clinicians", "collateral", "connectors", "detectives", "developing", "displaying", "electronic", "expedition", "friendship", "generators", "harassment", "harassment", "historical", "immigrants", "instructor", "leadership", "organizers", "parliament", "passengers", "performers", "phenomenon", "physicians", "preferably", "programmer", "prohibited", "recommends", "refreshing", "regulation", "repetitive", "researched", "satisfying", "separately", "successful", "sufficient", "techniques", "television", "theatrical", "volatility", "yourselves"})

        Debug.WriteLine("[INITIALIZE] Added possible words")

        Debug.WriteLine("[INITIALIZE] Initializing complete")
    End Sub
End Module
