using GameSimulation;

Console.Title = "Game Simulation";

Server server = new Server("Server1");
Player player = new Player("Azimut", Player.gameChampions.Warrior);
server.JoinToServer(player);


string[] nameBotChampions = {
"Shadowstrike", "Mysticdancer", "Solarflare","Ironclad",
"Emberheart", "Nightshade", "Stormchaser", "Swiftshadow",
"Frostblade","Thunderstrike", "Ebonthorn",  "Sableclaw",
"Stormrider", "Blazebringer", "Dawnbringer", "Serpentbane",
"Auroraflare", "Thornwhisper", "Silverfrost", "Ironjaw"

};

Player.gameChampions[] champions = { Player.gameChampions.Mage, Player.gameChampions.Warrior, Player.gameChampions.Dwarf };
Random randomChamp = new Random();
for (int i = 0; i < 9; i++)
{
    server.JoinToServer(new Bot(nameBotChampions[i], champions[randomChamp.Next(champions.Length)]));
}
Console.WriteLine(server);
Thread.Sleep(5000);
Console.WriteLine(server.ArenaMatch());
Console.ReadKey();
