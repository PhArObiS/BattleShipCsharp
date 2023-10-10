const int BOARD_SIZE = 10;
char[,] matrix = new char[BOARD_SIZE, BOARD_SIZE];

int[] lengths = { 2, 3, 3, 4, 5 };


// Fill the matrix with wave symbol
for (int i = 0; i < BOARD_SIZE; i++)
{
    for (int j = 0; j < BOARD_SIZE; j++)
    {
        matrix[i, j] = '~';
    }
}

int placedShips = 0;

while (placedShips < 5)
{

    Random randomGeneration = new Random();

    int randomRow =
        randomGeneration.Next(0, BOARD_SIZE);
    int randomColumn =
        randomGeneration.Next(0, BOARD_SIZE);

    int randomDirection =
        randomGeneration.Next(0, 4);

    int directionXToCheck = 0;
    int directionYToCheck = 0;

    switch (randomDirection)
    {
        case 0:
            directionYToCheck = -1;
            break;
        case 1:
            directionXToCheck = 1;
            break;
        case 2:
            directionYToCheck = 1;
            break;
        case 3:
            directionXToCheck = -1;
            break;
        default:
            break;
    }

    // Place the ship if there is space
    // First, check if the picked adjacent square is indeed
    // within the 10 x 10 board

    bool shipCanBePlaced = true;

    for (int L = 0; L < lengths[placedShips]; L++)
    {
        if (randomColumn + (L * directionXToCheck) < 0
            || randomColumn + (L * directionXToCheck) >= BOARD_SIZE
            || randomRow + (L * directionYToCheck) < 0
            || randomRow + (L * directionYToCheck) >= BOARD_SIZE)
        {
            shipCanBePlaced = false;
        }

    }

    if (shipCanBePlaced)
    {
        for (int L = 0; L < lengths[placedShips]; L++)
        {
            matrix[randomColumn + (L * directionXToCheck), randomRow + (L * directionYToCheck)] = (char)('0' + L);
        }

        placedShips++;
    }
}


// Print the board
for (int i = 0; i < BOARD_SIZE; i++)
{
    for (int j = 0; j < BOARD_SIZE; j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}
