using Microsoft.EntityFrameworkCore;
using ZooManager.EFPersistance;
using ZooManager.Entitis;

var context = new EFContext();
static void StartMenue()
{
    Console.WriteLine("welcome to international Zoo Manageing " +
        "\n What can we do for you" +
        "\n1 - Show all the zoos under our supervision" +
        "\n2 - Add your zoo" +
        "\n3 - Edit your zoo" +
        "\n0 - Exit" +
        "\n Choos one.." +
        "\n=====================================================");
}
void AddZooMenue()
{
    var _zoo = new List<Zoo>();
    Console.WriteLine("Whats your zoo name?");
    string zooName = Console.ReadLine();
    Console.WriteLine("Enter its address");
    string zooAdrees = Console.ReadLine();
    Console.WriteLine("How many sections does your zoo have?");
    int zooPartNumbers = int .Parse(Console.ReadLine());
    Zoo zoo = new Zoo
    {
        Name = zooName,
        Adres = zooAdrees,
        PartNumber = zooPartNumbers
    };
    context.Set<Zoo>().Add(zoo);
    context.SaveChanges();

    for (int i = 0;i < zooPartNumbers; i++)
    { 
        Console.WriteLine("Enter the area of ​​the section");
        int partArea = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the ticket price in this section");
        int ticketPrice = int.Parse(Console.ReadLine());
        Console.WriteLine("How many tickets have been sold?");
        int ticketCount = int .Parse(Console.ReadLine());
        
        Part part = new Part
        {
            Area = partArea,
            TicketNumber = ticketCount,
            ZooId =zoo.Id,
        };
        
        context.Set<Part>().Add(part);
        context.SaveChanges();
        Console.WriteLine("What is the animal species in this section?");
        string animalType = Console.ReadLine();
        Console.WriteLine("How many of them are in this section?");
        int animalCount = int .Parse(Console.ReadLine());
        Console.WriteLine("Provide explanations about this type of animal");
        string animalDescription = Console.ReadLine();
        Animal animal = new Animal
        {
            PartId = part.Id,
            AnimalType = animalType,
            Description = animalDescription,
            AnimalNumber = animalCount
        };
        context.Set<Animal>().Add(animal);
        part.AnimalCount++;
        context.SaveChanges();


        Ticket ticket = new Ticket
        {
            Price = ticketPrice,
            PartId = part.Id,
        };
        context.Set<Ticket>().Add(ticket); 
        context.SaveChanges();
        
        
    }


    
    _zoo.Add(zoo);



}


bool startMenueFinisher = false;
do
{
    StartMenue();
    int menueChoos =int.Parse(Console.ReadLine());
    switch(menueChoos)
    {
        case 0:
            startMenueFinisher=true;
            break;
        case 1:
            
            break;
        case 2:
            AddZooMenue();
            break;
        case 3:
            Console.WriteLine("Which zoo do you want to change?");

            break;
        default:
            Console.WriteLine("Irregular number");
            break;
    }
}
while (startMenueFinisher!);
