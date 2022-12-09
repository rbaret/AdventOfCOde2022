int[,] input = Utility.ImportInput.ToIntMatrix("input.txt");

int visibleTrees = checkTreeVisibility(input);

// Add edge trees to visible trees
visibleTrees += (input.GetLength(0) + input.GetLength(1))*2 - 4;

Console.WriteLine("Part 1 : There are {0} visble trees",visibleTrees);
Console.WriteLine("Part 2 : The best scenic score is {0}",getBestScenicScore(input));

int checkTreeVisibility(int[,] input){
    int visibleTrees = 0;
    for(int i=1; i<input.GetLength(0)-1; i++){
        for(int j=1; j<input.GetLength(1)-1; j++){
            if(treeIsVisible(input, i, j)){
                visibleTrees++;
            }
        }
    }
    return visibleTrees;
}

int getBestScenicScore(int[,] input){
    int bestScore = 0;
    for(int i=1; i<input.GetLength(0)-1; i++){ // Don't check the edges
        for(int j=1; j<input.GetLength(1)-1; j++){ // Don't check the edges
            int score = ScenicScore(input, i, j);
            if(score>bestScore){
                bestScore = score;
            }
        }
    }
    return bestScore;
}

bool treeIsVisible(int[,] input, int i, int j){
    // Look if there is a smaller tree in the 4 directions
    // If there is, return true
    // Look Left
    bool isVisibleFromLeft = true;
    bool isVisibleFromRight = true;
    bool isVisibleFromUp = true;
    bool isVisibleFromDown = true;

    for(int left = j-1;left>=0;left--){
        if(input[i,left]>=input[i,j]){
            isVisibleFromLeft = false;
        }
    }

    // Look Right
    for(int right = j+1;right<input.GetLength(1);right++){
        if(input[i,right]>=input[i,j]){
            isVisibleFromRight = false;
        }
    }

    // Look Up
    for(int up = i-1;up>=0;up--){
        if(input[up,j]>=input[i,j]){
            isVisibleFromUp = false;
        }
    }

    // Look Down
    for(int down = i+1;down<input.GetLength(0);down++){
        if(input[down,j]>=input[i,j]){
            isVisibleFromDown = false;
        }
    }

    return (isVisibleFromLeft || isVisibleFromRight || isVisibleFromUp || isVisibleFromDown);
}

// Part 2
// Calculate the scenic score
int ScenicScore(int[,] input, int i, int j){
    // Look for the first tree (if any) which is the same size or higher in the 4 directions
    // Count the number of visible trees between the current tree and the first high tree (included)
    int score = 1;
    for(int left = j-1;left>=0;left--){
        if(input[i,left]>=input[i,j] || left==0){
            score *= j-left;
            break;
        }
    }

    // Look Right
    for(int right = j+1;right<input.GetLength(1);right++){
        if(input[i,right]>=input[i,j] || right==input.GetLength(1)-1){
            score *= right-j;
            break;
        }
    }

    // Look Up
    for(int up = i-1;up>=0;up--){
        if(input[up,j]>=input[i,j] || up==0){
            score *= i-up;
            break;
        }
    }

    // Look Down
    for(int down = i+1;down<input.GetLength(0);down++){
        if(input[down,j]>=input[i,j] || down==input.GetLength(0)-1){
            score *= down-i;
            break;
        }
    }

    return score;
}