using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;

namespace Part2Prog
{
    internal class Program
    {
        static Recipe[] recipes = new Recipe[100];
        static int recipeCount = 0;
        static int TCalories = 0;


        static void Main(string[] args)
        {
            Console.WriteLine("Recipie soring");
            Console.WriteLine("               ");
            while (true)
            {
                int ChoiceSelection;
                Console.WriteLine("-----------------");
                Console.WriteLine("1. Add recipe");
                Console.WriteLine("2. View recipes");
                Console.WriteLine("3. Delete recipe");
                Console.WriteLine("4. Exit");
                Console.WriteLine("-----------------");
                Console.WriteLine("                  ");
                


                ChoiceSelection= int.Parse(Console.ReadLine());     
                if (ChoiceSelection >4 )
                { Console.WriteLine("Error ,unknown value,Please try again"); }
                else { Console.WriteLine("Selection:"+ ChoiceSelection); };//just checking functionality


                switch (ChoiceSelection)//switch statement for each method
                {
                case 1:

                AddRecipe();

                break;

                case 2:

                ViewRecipes();

                break;

                case 3:

                DeleteRecipe();

                break;

                case 4:

                Console.WriteLine("Program Terminated");

                return;                
                }
            }
        }

        static void AddRecipe()//copy paste from part 1
        {
            Console.WriteLine("Please add a recipe name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter the number of ingredients for " + name);
            int numOfIngredients= int.Parse(Console.ReadLine());

            string[] ingredients = new string[numOfIngredients];
            for (int i = 0; i < numOfIngredients; i++)
            {
                Console.WriteLine("Please enter ingredient " + (i + 1) + ":");
                string ingredientName  = Console.ReadLine();

                Console.WriteLine("Please enter ingredient measurement unit:");
                string ingredientUnit= Console.ReadLine();

                Console.WriteLine("Please enter amount of " + ingredientUnit + ":");
                int ingredientAmount= int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter the ingredient calories:");
                int ingredientCalories =int.Parse(Console.ReadLine());//calories added
                TCalories += ingredientCalories;

                Console.WriteLine("Please enter the ingredient food group:");
                string ingredientGroup = Console.ReadLine();//food group added


                string ingredient = ingredientName + "( " +  ingredientAmount +  ingredientUnit +", "+ ingredientCalories+" , "+ ingredientGroup+")";//this wil add them together in the array
                ingredients[i] = ingredient;
            }
            //  Console.WriteLine("enter the number of instructions");
            //for loop for instructions doesnt work propely
            Console.WriteLine("Please enter instructions ,followed by a ',':");
            int Numinstruct=int.Parse(Console.ReadLine());
           // for (int i = 0; i < Numinstruct; i++)
           // {
                string instructions = Console.ReadLine();
                Recipe recipe = new Recipe(name, ingredients, instructions);
                recipes[recipeCount] = recipe;
                recipeCount++;
         //   }
                Console.WriteLine("Recipe added successfully.");
        }


        static void ViewRecipes()
        {
            Console.WriteLine("Recipes:");
            Console.WriteLine();


            for (int i = 0; i < recipeCount; i++)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
                Console.WriteLine("Instructions: " + recipes[i].Instructions);
                Console.WriteLine("Calories :" + TCalories);
                if (TCalories>300) { Console.WriteLine("recipies exceed 300 cal in total!"); };

                Console.WriteLine("Ingredients:");
                for (int j = 0; j < recipes[i].Ingredients.Length; j++)//for loop so i can display the ingredients
                {
                    Console.WriteLine(recipes[i].Ingredients[j]);
                }

                Console.WriteLine("-----------------------");
            }
        }


        static void DeleteRecipe()//extra funvtion
        {
            Console.WriteLine("Delete a recipe:");

            Console.WriteLine("Enter the index of the recipe to delete:");
            int indexToDelete= int.Parse(Console.ReadLine());

            for (int i = indexToDelete - 1; i < recipeCount - 1; i++)
            {
                recipes[i] = recipes[i + 1];
            }

            recipes[recipeCount - 1] = null;
            recipeCount--;

            Console.WriteLine("Recipe deleted successfully.");
        }
    }
}

    
    class Recipe
    {
        public string Name;
        public string[] Ingredients;
        public string Instructions;

        public Recipe(string name, string[] ingredients, string instructions)
        {
            Name = name;
            Ingredients = ingredients;
            Instructions = instructions;
        }
    }

