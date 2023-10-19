namespace WebStore.Model;
public class Address 
{
    public int Id {get;set;}
    public string City {get;set;}
    public string ZipCode {get;set;}
    public string Street {get; set;}
    public int BuildingNumber {get; set;}
    public int ApartmentNumber {get; set;}
    public string Country {get; set;}
    
}
// INSERT [dbo].[Addresses] ([Id], [City], [ZipCode], [Street], [BuildingNumber], [ApartmentNumber], [Country]) VALUES (1, N'Czestochowa', N'42-200', N'Al. Armii Krajowej', 1, 100, N'Poland')
