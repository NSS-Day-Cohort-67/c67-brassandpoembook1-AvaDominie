
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.

List<ProductType> productTypes = new List<ProductType>()
{

    new ProductType()
    {
        Id = 1,
        Title = "Apparel"
    },

    new ProductType()
    {
        Id = 2,
        Title = "Brass"
    },

    new ProductType()
    {
        Id = 3,
        Title = "Poem"
    },
};



//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "T-Shirt",
        Price = 19.99m,
        ProductTypeId = 1
    },

    new Product()
    {
        Name = "Trumpet",
        Price = 599.99m,
        ProductTypeId = 2
    },

    new Product()
    {
        Name = "Sonnet Book",
        Price = 14.99m,
        ProductTypeId = 3
    },

    new Product()
    {
        Name = "Brass Necklace",
        Price = 29.99m,
        ProductTypeId = 1
    },

    new Product()
    {
        Name = "Poetry Collection",
        Price = 24.99m,
        ProductTypeId = 3
    },
};




//put your greeting here

Console.WriteLine(@"Welcome to Brass & Poem! 
                    For all your poetry books and brass musical instrument needs.");


//implement your loop 

string choice = null;
while (choice != "5")
{
    Console.WriteLine(@"Choose an option:
                        1. View All Products
                        2. Add a New Product
                        3. Delete A Product
                        4. Update a Products Details
                        5. Exit ");

    choice = Console.ReadLine();
    try
    {
        int response = int.Parse(choice);
        // Display all products 
        if (response == 1)
        {
            DisplayAllProducts(products, productTypes);

            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
            Console.Clear();
        }
        // Add product
        else if (response == 2)
        {
            AddProduct(products, productTypes);

            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
            Console.Clear();

        }
        // Delete product
        else if (response == 3)
        {
            DeleteProduct(products, productTypes);

            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
            Console.Clear();
        }

        // Update a Products details
        else if (response == 4)
        {
            UpdateProduct(products, productTypes);

            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
            Console.Clear();
        }

        // Exit program
        else if (response == 5)
        {
            Console.WriteLine("Goodbye!");
            Console.Clear();
        }

    }
    catch (FormatException)
    {
        Console.WriteLine("Please type only integers!");
    }
    catch (ArgumentOutOfRangeException)
    {
        Console.WriteLine("Please choose an existing item only!");
    }
    catch (Exception)
    {
        Console.WriteLine("Do Better!");
    }
}


// void DisplayMenu()
// {
//     throw new NotImplementedException();
// }




void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{

    Console.WriteLine("Products:");
    for ( int i = 0; i < products.Count; i++) 
    {
        // find the ProductType that matches the product id
        var ProductType = productTypes.FirstOrDefault(productTypes => productTypes.Id == products[i].ProductTypeId);

        // if the ProductType is found set it to productTypeName value, if not found, display unknown
        string productTypeName = ProductType != null ? ProductType.Title : "Unknown";

        Console.WriteLine(@$"{i + 1}. {products[i].Name} which is ${products[i].Price} and {productTypeName} is the product type.");

    }

}





void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    
    Console.WriteLine("Products:");
    for ( int i = 0; i < products.Count; i++) 
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }

    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }
    }

    int index = products.IndexOf(chosenProduct);
    if (index != -1)
    {
        products.RemoveAt(index);
        Console.WriteLine("Product has been deleted successfully!");
    }
    else
    {
        Console.WriteLine("Product not found in the list.");
    }

}



void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    
    
    Console.WriteLine("Enter the name of the product:");
    string name = Console.ReadLine();

    Console.WriteLine("Enter the asking price of the product:");
    decimal price = decimal.Parse(Console.ReadLine());

    Console.WriteLine("Product Types:");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
    }

    Console.WriteLine("Enter product type number:");
    int productNumber = int.Parse(Console.ReadLine());

    ProductType productType = productTypes[productNumber - 1];


    // New product
    Product product = new Product
    {
        Name = name,
        Price = price,
        ProductTypeId = productType.Id,

    };

    products.Add(product);

    Console.WriteLine("Product added successfully.");



}






void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine($"Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    };

    Console.WriteLine("Enter product number to update:");
    int id = int.Parse(Console.ReadLine());

    // Find the product in the list of products
    Product product = products.FirstOrDefault(p => p.ProductTypeId == id);

    Console.WriteLine("Enter the new name of the product:");
    product.Name = Console.ReadLine();

    Console.WriteLine("Enter the new price of the product:");
    product.Price = decimal.Parse(Console.ReadLine());

    Console.WriteLine("Product Types:");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
    }


    Console.WriteLine("Enter the new product type by number:");
    product.ProductTypeId = int.Parse(Console.ReadLine());

    Console.WriteLine("Product updated successfully.");
}
























// don't move or change this!
public partial class Program { }