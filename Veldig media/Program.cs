class Program
{
    public static void Main(string[] args)
    {
        new FriendSpace().run();
    }
}

internal class FriendSpace
{
    public List<Users> usersList { get; private set; } = new List<Users>();
    public List<Users> friendList { get; private set; } = new List<Users>();

    public void run()
    {
        createUser();
        usersList.Add(new Users("Alice", 25, "aliceGithub", "Single"));
        usersList.Add(new Users("Bob", 30, "bobGithub", "Married"));
        var play = true;
        while (play)
        {
            Console.Clear();
            Console.WriteLine("Users:");
            foreach (var u in usersList)
                Console.WriteLine($"{u.Name} {u.Age} {u.Github} {u.Sivilstatus}");

            Console.WriteLine("Friends:");
            foreach (var f in friendList)
                Console.WriteLine($"{f.Name} {f.Age} {f.Github} {f.Sivilstatus}");

            var input = Console.ReadLine();
            Console.Clear();
            var userName = input.Substring(input.StartsWith("add ") ? 4 : input.StartsWith("remove ") ? 7 : 5).Trim();
            if (input.StartsWith("add ")) addUser(userName);
            else if (input.StartsWith("remove ")) removeUser(userName);
            else if (input.StartsWith("show ")) showUser(userName);
            else if (input == "show friends") showFriends();
            else if (input == "stop") play = false;
            Thread.Sleep(4000);
        }
    }

    private void showUser(string userName)
    {
        var user = usersList.FirstOrDefault(u => u.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));
        if (user != null) Console.WriteLine($"{user.Name} {user.Age} {user.Github} {user.Sivilstatus}");
        else Console.WriteLine($"{userName} finnes ikke i brukerslisten.");
    }

    public void createUser()
    {
        Console.WriteLine("Hva heter du?");
        var userName = Console.ReadLine();
        Console.WriteLine("Hvor gammel er du?");
        var userAge = int.Parse(Console.ReadLine());
        Console.WriteLine("Hva er githuben din?");
        var userGithub = Console.ReadLine();
        Console.WriteLine("Hva er din sivilstatus?");
        var userSivilstatus = Console.ReadLine();
        usersList.Add(new Users(userName, userAge, userGithub, userSivilstatus));
    }

    private void addUser(string userName)
    {
        var user = usersList.FirstOrDefault(u => u.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));
        if (user != null)
        {
            if (!friendList.Any(f => f.Name.Equals(userName, StringComparison.OrdinalIgnoreCase)))
            {
                friendList.Add(user);
                Console.WriteLine($"Du la til {userName} som venn.");
            }
            else Console.WriteLine($"{userName} er allerede en venn.");
            
        }
        else Console.WriteLine($"{userName} finnes ikke i brukerslisten.");
    }

    private void removeUser(string userName)
    {
        var user = friendList.FirstOrDefault(f => f.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));
        if (user != null)
        {
            friendList.Remove(user);
            Console.WriteLine($"Du fjernet {userName} som venn.");
        }
        else
        {
            Console.WriteLine($"{userName} finnes ikke i vennelisten.");
        }
    }

    private void showFriends()
    {
        Console.Clear();
        Console.WriteLine("Venner:");
        foreach (var f in friendList)
            Console.WriteLine($"{f.Name} {f.Age} {f.Github} {f.Sivilstatus}");
    }
}

public class Users
{
    public string Name;
    public int Age;
    public string Github;
    public string Sivilstatus;

    public Users(string name, int age, string github, string sivilstatus)
    {
        Name = name;
        Age = age;
        Github = github;
        Sivilstatus = sivilstatus;
    }
}
